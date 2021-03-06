using System;

namespace SW02_Person {
    class Program {
        static void Main(string[] args) {
            Person person = new Person("Muster", "Max", 45, Gender.Male);
            Person person2 = new Person("",null,Gender.Selfdefined);
            Person child = new Person("Muster", "Tochter", 12, Gender.Female);
            person.Print(false);
            person2.Print();
            child.Print();
        }
    }
}
