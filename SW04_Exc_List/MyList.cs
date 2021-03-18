using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW04_Exc_List {
    public class MyList {
        private object[] data;
        public uint capacity { get; private set; }
        public uint Count { get; private set; }
        public MyList(uint p_capacity) {
            capacity = p_capacity;
            Count = 0;
        }

        public void Add(object p_number) {
            if(Count < capacity) {
                data[Count] = p_number;
                Count++;
            } else {
                throw new OutOfMemoryException($"Capacity is full! count: {Count} / capacity {capacity}");
            }
        }

        public object Get(uint index) {
            if(index < capacity) {
                return data[index];
            } else {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
