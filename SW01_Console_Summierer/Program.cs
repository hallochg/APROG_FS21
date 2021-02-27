using System;

namespace SW01_Console_Summierer
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            foreach(string arg in args)
            {
                sum += Convert.ToInt32(arg);
            }
            Console.WriteLine("Summe: " + sum);
        }
    }
}
