using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW2_OOP_ARRAYS_VARIABLEN {
    class GarbageCollector {
        public void process() {
            Console.WriteLine($"Memory used first: {GC.GetTotalMemory(false)}");
            int[][] arr = new int[20][];
            Console.WriteLine($"Memory used after arr dim1 = 20: {GC.GetTotalMemory(false)}");
            for(int i = 0; i < arr.Length; i++) {
                arr[i] = new int[1000000];
                Console.WriteLine($"Memory used after {i}: {GC.GetTotalMemory(false)}");
            }
            GC.Collect();
            Console.WriteLine($"Memory used after collect: {GC.GetTotalMemory(false)}");
            arr = null;
            GC.Collect();
            Console.WriteLine($"Memory used after null: {GC.GetTotalMemory(false)}");
        }
    }
}
