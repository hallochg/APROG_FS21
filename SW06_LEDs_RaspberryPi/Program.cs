using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace SW06_LEDs_RaspberryPi {

    
    class Program {
        static event LEDEventHandler led_changed;
        static void Main(string[] args) {
           
            Console.WriteLine("first press 'g' for the green LED or 'r' for the red LED, then:\n" +
                "press 't' for toggle the choosen LED on\n" +
                "press 'p' to activate periodic blinking\n" +
                "press 's' to stop periodic\n" +
                "press 'q' to exit programm");

            Process p = new Process();
            Controller c = new Controller(p);
            p.doProcess();
                
            }
        
    }

}
