using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW2_OOP_ARRAYS_VARIABLEN {
    /// <summary>
    /// 1. Benutzer gibt Gr¨osse des eindimensionalen Arrays uber Konsole ein
    /// 2. Programm fragt nach den Werten fur den Array
    /// 3. Programm gibt die Werte mit einem foreach wieder aus
    /// 4. Programm bestimmt den gr¨ossten Wert im Array
    /// </summary>
    class UebungArrays {
        private int[] m_UserArray;
        private uint mlength;
        public UebungArrays() {
            mlength = 0;
        }

        private bool getSizeUserArray() {
            Console.WriteLine("Please type to length of the array: ");
            string input = Console.ReadLine();
            return (uint.TryParse(input, out mlength) && mlength > 0);

        }

        private void getArrayElements() {

            bool isnumber = false;
            for (int i = 0; i < mlength; i++) {
                int element;
                do {
                    Console.WriteLine($"please type in element {i}");
                    string input = Console.ReadLine();
                    isnumber = int.TryParse(input, out element);
                } while (isnumber == false);
                m_UserArray[i] = element;
            }
        }

        private void printArray() {
            Console.WriteLine("your elements are:");
            foreach (int elem in m_UserArray) {
                Console.WriteLine(elem.ToString());
            }
        }

        private void printMax() {
            Console.WriteLine($"The biggest value in the array is: {m_UserArray.Max()}");
        }

        public void process() {
            while (!getSizeUserArray()) ;
            Console.WriteLine($"your length is: {mlength}");
            m_UserArray = new int[mlength];
            getArrayElements();
            printArray();
            printMax();
        }
    }
}
