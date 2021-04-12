using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SW06_LEDs_RaspberryPi {
    public delegate void LEDEventHandler(object sender, LEDEventArgs e);
    public class LEDEventArgs : EventArgs {
        internal LEDs led;
        internal Led_Function function;
        internal bool set;
    }
    class Controller {
        Process proc;
        Dictionary<LEDs, LED_pi> availableLEDs;
        Dictionary<LEDs, Thread> t_periodic;
        StateMachine sm;
        LEDs led;
        
        public Controller(Process p) {
            this.proc = p;
            this.proc.function_changed += new LEDEventHandler(this.e_function_changed);
            this.proc.led_changed += new LEDEventHandler(this.e_led_changed);
            this.proc.terminate += new LEDEventHandler(this.e_terminate);
            sm = new StateMachine();
            availableLEDs = new Dictionary<LEDs, LED_pi>();
            t_periodic = new Dictionary<LEDs, Thread>();
        }

        public void e_terminate(object sender, LEDEventArgs e) {
            if (e.set) {
                StateHandler(sm.MoveNext(Command.terminate));
            }
        }

        public void e_led_changed(object sender, LEDEventArgs e) {
            this.led = e.led;
            availableLEDs[this.led] = new LED_pi(this.led);
            t_periodic[this.led] = new Thread(() => availableLEDs[this.led].Periodic_Task());
            StateHandler(sm.MoveNext(Command.setting_LED));
        }
        
        public void e_function_changed(object sender, LEDEventArgs e) {
            switch (e.function) {
                case Led_Function.deactivate_act_function:
                    break;
                case Led_Function.toggle:
                    StateHandler(sm.MoveNext(Command.toggle));
                    break;
                case Led_Function.set_standart_function:
                    break;
                case Led_Function.periodic:
                    if (e.set) {
                        StateHandler(sm.MoveNext(Command.set_periodic));
                    } else {
                        StateHandler(sm.MoveNext(Command.clear_periodic));
                    }
                    break;
                default:
                    break;
            }
        }


        void StateHandler(ProcessState state) {
            switch (state) {
                case ProcessState.no_LED:
                    break;
                case ProcessState.LED_set:
                    StateHandler(sm.MoveNext(Command.no_condition));
                    break;
                case ProcessState.wait:
                    break;
                case ProcessState.Toggle:
                    availableLEDs[this.led].Set_Led(!availableLEDs[this.led].read_led());
                    StateHandler(sm.MoveNext(Command.no_condition));
                    break;
                case ProcessState.Periodic_set:
                    t_periodic[this.led].Start();
                    StateHandler(sm.MoveNext(Command.no_condition));
                    break;
                case ProcessState.Periodic_clear:
                    availableLEDs[this.led].StopPeriodic = true;
                    StateHandler(sm.MoveNext(Command.no_condition));
                    break;
                case ProcessState.Error:
                    StateHandler(sm.MoveNext(Command.no_condition));
                    break;
                case ProcessState.Error_lednotset:
                    this.proc.Print("Please set LED first!");
                    StateHandler(sm.MoveNext(Command.no_condition));
                    break;
                case ProcessState.Exit:
                    foreach (KeyValuePair<LEDs, Thread> items in t_periodic) {
                        if (items.Value.IsAlive) {
                            availableLEDs[items.Key].StopPeriodic = true;
                        }
                        availableLEDs[items.Key].SetStandard();
                    }
                    this.proc.exit = true;
                    break;
                default:
                    break;
            }
        }
    }
}
