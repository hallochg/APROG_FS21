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


        public Person(string plastname, string pfirstname, int p_age, Gender pgender) {
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
            mage = p_age;
            mgender = pgender;
        }

    }
}
