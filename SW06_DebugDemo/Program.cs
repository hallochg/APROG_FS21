using System;
using System.Threading;

namespace SW06_DebugDemo {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine("Hello World!");
            Utils.Util.WaitForDebugger();
            Console.WriteLine("Hello World 123");
            for(int i = 0; i<100; i++) {
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }
    }
}
