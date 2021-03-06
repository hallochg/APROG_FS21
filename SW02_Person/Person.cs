using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW02_Person {
    class Person {
        private string mlastname;
        private string mfirstname;
        private int mage;
        private Gender mgender;
        public string lastname {
            get { return mlastname; }
            set { mlastname = value; }
        }

        public string firstname {
            get { return mfirstname; }
            set { mfirstname = value; }
        }

        public int age {
            get { return mage; }
            set { mage = value; }
        }

        public Gender gender {
            get { return mgender; }
            set { mgender = value; }
        }


        public Person(string plastname, string pfirstname, int p_age, Gender pgender)
            :this(plastname, pfirstname, pgender) {
            mage = p_age;
        }
        public Person(string plastname, string pfirstname, Gender pgender) {
            if (String.IsNullOrEmpty(plastname)) {
                mlastname = "xxx";
            } else {
                mlastname = plastname;
            }
            if (String.IsNullOrEmpty(pfirstname)) {
                mfirstname = "xxx";
            } else {
                mfirstname = pfirstname;
            }
            mage = -1;
            mgender = pgender;

        }
        public void Print() {
            Print(true);
        }

        public void Print(bool pshowtitle) {
                if ((mage > 15)&&(pshowtitle == true)) {
                    string title;
                    switch (gender) {
                        case Gender.Male:
                            title = "Herr";
                            break;

                        case Gender.Female:
                            title = "Frau";
                            break;
                        case Gender.Selfdefined:
                            title = "";
                            break;
                        default:
                            title = "--";
                            break;
                    }
                    Console.WriteLine(title);
                }
                Console.WriteLine($"{firstname} {lastname}");
        }
    }
}
