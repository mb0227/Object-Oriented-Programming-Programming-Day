using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Subject
    {

        public Subject() { 
        
        }
        public Subject(string code, int creditHours, string subjectType) {
            SubjectCode = code;
            CreditHours = creditHours;
            SubjectType = subjectType;
        }

        public string SubjectCode;
        public int CreditHours;
        public string SubjectType;
    }
}
