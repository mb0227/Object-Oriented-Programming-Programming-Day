using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class DegreeProgramUI
    {
        public static DegreeProgram GetDegreeInput()
        {
            Console.Write("Degree name: ");
            string name = Console.ReadLine();

            Console.Write("Duration: ");
            int duration = int.Parse(Console.ReadLine());

            Console.Write("Seats: ");
            int seats = int.Parse(Console.ReadLine());

            List<Subject> subjects = GetSubjects();

            DegreeProgram degreeProgram = new DegreeProgram(name, duration, seats, subjects);

            return degreeProgram;
        }

        public static List<Subject> GetSubjects() {
            List<Subject> subjects = new List<Subject>();
            Console.Write("Enter total no of subjects to enter: ");
            int total = int.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
            {
                Subject newSubject = SubjectUI.AddSubject();
                if(SubjectCRUD.SubjectExists(newSubject))
                {
                    subjects.Add(newSubject);
                    SubjectCRUD.AddSubject(newSubject);
                }
            }
            return subjects;
        }

        public static void PrintDegrees()
        {
            foreach (DegreeProgram d in DegreeProgramCRUD.DegreePrograms)
            {
                Console.WriteLine(d.Title);
            }
        }
    }
}
