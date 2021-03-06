using System;

namespace SW2_OOP_ARRAYS_VARIABLEN
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGarbage();
            GC.Collect();
            Console.WriteLine($"Memory used after return to main: {GC.GetTotalMemory(false)}");
        }

        public static void TestGarbage() {
            GarbageCollector garbage = new GarbageCollector();
            garbage.process();
            GC.Collect();
            Console.WriteLine($"Memory used after return: {GC.GetTotalMemory(false)}");
            garbage = null;
        }

        public static void TestArray() {
            UebungArrays ueb1 = new UebungArrays();
            ueb1.process();
        }

        public static void TestVocal() {
            UebungVokale ueb_voc = new UebungVokale();
            ueb_voc.process();
        }
    }
}
