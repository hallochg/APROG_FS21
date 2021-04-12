using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace SW06_Person {
    class Person {

        string first;
        string last;
        Gender gender;
        //ResourceManager resman = new ResourceManager();

        static int Count { get; set; }
       
       
        // spanish: "Estimada señora", "Estimado señor", "Saludos,"

        public Person( string first, string last, GenderType gender) {
            this.first = first;
            this.last = last;
            this.gender = new Gender(gender);
            Count++;
            Console.WriteLine($"Created instance number: {Count} of class Person.");
        }
      
        public void Print() {
            Console.WriteLine(this.gender.GetSalutation());
            Console.WriteLine( $"{first} {last}" );
            
        }

        static public void LanguageToSpanish() {
            CultureInfo customculter = new CultureInfo("es-ES");
            Properties.language.Culture = customculter;
            

        }
    }
}
