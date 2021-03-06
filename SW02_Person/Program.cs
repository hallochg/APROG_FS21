using System;

namespace SW02_Person {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Person person = new Person("Muster", "Max", 45, Gender.Male);
            Console.WriteLine($"Nachname: {person.lastname}, Vorname: {person.firstname}, " +
                $"Alter {person.age}, Geschlecht {person.gender}");
            Person person_dummy = new Person("",null,100,Gender.Selfdefined);
            Console.WriteLine($"Nachname: {person_dummy.lastname}, Vorname: {person_dummy.firstname}, " +
                $"Alter {person_dummy.age}, Geschlecht {person_dummy.gender}");
        }
    }
}
