using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Threading;

namespace SW07_FancyGPIO_rpi {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello What is u doing\n GPIO21 (LED D1) -> symbole when pi is ready for ssh");
            Console.WriteLine("GPIO26 -> Joystick push -> toggle GPIO20 (LED D2)");
            Pi.Init<BootstrapWiringPi>();
            var led_ssh_ready = Pi.Gpio[BcmPin.Gpio21];
            led_ssh_ready.PinMode = GpioPinDriveMode.Output;
            led_ssh_ready.Write(true);
            var joystic_push = Pi.Gpio[BcmPin.Gpio26];
            joystic_push.PinMode = GpioPinDriveMode.Input;
            var led_push = Pi.Gpio[BcmPin.Gpio20];
            led_push.PinMode = GpioPinDriveMode.Output;
            bool pushed = false;
            bool pushed_old = false;
            bool led_push_state = false;
            led_push.Write(led_push_state);
            while (true) {
                pushed = joystic_push.Read();
                if (!pushed & pushed != pushed_old) {
                    led_push_state = !led_push_state;
                    led_push.Write(led_push_state);
                    Thread.Sleep(100);  // entprellen

                }
                pushed_old = pushed;
            }
        }
    }
}
