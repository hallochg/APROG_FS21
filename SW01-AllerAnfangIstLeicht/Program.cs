using System;

namespace SW01_AllerAnfangIstLeicht
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConsoleKeyInfo key = Console.ReadKey();
            if (ConsoleKey.A == key.Key)
            {
                Console.WriteLine("\nYou got it");
            }
            else
            {
                PrintStr("\nu are so useless");
            }
        }

        static void PrintStr(string p_string)
        {
            Console.WriteLine(p_string.ToUpper());
        }
    }
}
