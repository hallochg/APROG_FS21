using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SW06_LEDs_RaspberryPi {
    
    internal enum LEDs {
        green,
        red
    }

    internal enum Led_Function {
        deactivate_act_function,
        toggle,
        set_standart_function,
        periodic
    }
    class LED_pi {
        public bool StopPeriodic { get; set; }
        private static Dictionary<LEDs, string> Led_path = new Dictionary<LEDs, string>() {
            {LEDs.green, "/sys/class/leds/led0/" },
            {LEDs.red, "/sys/class/leds/led1/" }
        };
        private static Dictionary<Led_Function, string> Led_function = new Dictionary<Led_Function, string>() {
            {Led_Function.deactivate_act_function, "trigger" },
            {Led_Function.toggle, "brightness" },
            {Led_Function.set_standart_function, "trigger" }
        };

        public LEDs led { get; private set; }
        private string super_path;
        public LED_pi(LEDs led) {
            this.led = led;
            super_path = Led_path[this.led];
            Deactivate_Function();
            StopPeriodic = false;
        }

        public void Deactivate_Function() {
            StreamWriter writer_st = new StreamWriter(this.super_path + Led_function[Led_Function.deactivate_act_function]);
            writer_st.Write("none");
            writer_st.Flush();
            writer_st.Close();
        }

        public void Set_Led(bool set) {
            StreamWriter writer_St = new StreamWriter(this.super_path + Led_function[Led_Function.toggle]);
            writer_St.Write(Convert.ToInt32(set).ToString());
            writer_St.Flush();
            writer_St.Close();
        }

        public void Periodic_Task() {
            while (!StopPeriodic) {
                Set_Led(true);
                Thread.Sleep(500);
                Set_Led(false);
                Thread.Sleep(500);
            }
        }

        public void SetStandard() {
            StreamWriter writer_St = new StreamWriter(this.super_path + Led_function[Led_Function.set_standart_function]);
            writer_St.Write("default-on");
            writer_St.Flush();
            writer_St.Close();
        }

        public bool read_led() {
            StreamReader reader = new StreamReader(this.super_path + Led_function[Led_Function.toggle]);
           if(reader.ReadLine() == "0") {
                reader.Close();
                return false;
            } else {
                reader.Close();
                return true;
            }
        }
    }
}
