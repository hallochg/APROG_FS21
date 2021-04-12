using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace SW06_Person {
    class Program {
        static void Main( string[] args ) {
            List<Person> list = new List<Person>();
            list.Add( new Person( "Agatha", "Christie", GenderType.Female ) );
            list.Add( new Person( "Pablo", "Picasso", GenderType.Male ) );
            list.Add( new Person( "Miley", "Cyrus", GenderType.Generic ) );

            foreach( Person p in list ) {
                p.Print();
            }
            Person.LanguageToSpanish();

            foreach ( Person p in list ) {
                p.Print();
            }


        }
    }
}
