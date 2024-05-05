using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class SubjectUI
    {
        public static Subject AddSubject()
        {
            Console.Write("Enter Subject Code: ");
            string subjectCode = Console.ReadLine();

            Console.Write("Enter Subject Type: ");
            string subjectType = Console.ReadLine();

            Console.Write("Enter Subject's Credit Hours: ");
            int creditHours = int.Parse(Console.ReadLine());

            Subject newSubject = new Subject(subjectCode, creditHours, subjectType);
            return newSubject;
        }

    }
}
