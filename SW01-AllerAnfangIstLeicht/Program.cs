using System;
using System.Collections.Generic;

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
            int a = 10, b = 11, c = 12;
            Console.WriteLine($"Hex: {a:X} {b:X} {c:X}");
            int[] myArray = { 1, 2, 3, 4 };
            List<int> myList = new List<int>
            {
                1,2,3,4,5
            };
            foreach (int i in myArray)
            {
                Console.WriteLine(Array.IndexOf(myArray, i));
            }
            foreach(int i in myList)
            {
                Console.WriteLine($"{i} {myList.IndexOf(i)}");
            }
        }

        static void PrintStr(string p_string)
        {
            Console.WriteLine(p_string.ToUpper());
        }
    }
}
