using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW06_LEDs_RaspberryPi {
    class Process {
        public event LEDEventHandler led_changed;
        public event LEDEventHandler function_changed;
        public event LEDEventHandler terminate;
        public bool exit = false;
        public ConsoleKeyInfo c_key { get; private set; }
        public ConsoleKeyInfo c_key_func { get; private set; }
        public void doProcess() {
            LEDEventArgs led_e = new LEDEventArgs();
            bool led_set = false;
            while (!exit) {
                if (readLED()) {
                    switch (c_key.Key) {
                        case ConsoleKey.R:
                            led_e.led = LEDs.red;
                            led_changed.Invoke(this, led_e);
                            break;
                        case ConsoleKey.G:
                            led_e.led = LEDs.green;
                            led_changed.Invoke(this, led_e);
                            break;
                        case ConsoleKey.T:
                            led_e.function = Led_Function.toggle;
                            function_changed.Invoke(this, led_e);
                            break;
                        case ConsoleKey.P:
                            led_e.function = Led_Function.periodic;
                            led_e.set = true;
                            function_changed.Invoke(this, led_e);
                            break;
                        case ConsoleKey.S:
                            led_e.function = Led_Function.periodic;
                            led_e.set = false;
                            function_changed.Invoke(this, led_e);
                            break;
                        case ConsoleKey.Q:
                            led_e.set = true;
                            terminate.Invoke(this, led_e);
                            break;

                    }
                }
               
            }

        }

        public bool readLED() {
            if (Console.KeyAvailable) {
                c_key = Console.ReadKey();
                return true;
            }
            return false;
        }

        public void Print(string text) {
            Console.WriteLine(text);
        }


    }
}
