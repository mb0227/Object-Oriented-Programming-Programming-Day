using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class StudentCRUD
    {
        public StudentCRUD()
        {
            Students = new List<Student>();
        }

        public static List <Student> Students = new List<Student>();

        public static void AddStudent(Student Student)
        {
            Students.Add(Student);
        }

        public static void RemoveStudent(int index)
        {
            Students.RemoveAt(index);
        }

        public static List <Student> GetStudents()
        {
            return Students;
        }

        public static List<Student> SortStudents()
        {
            List<Student> sortedStudents = Students.OrderByDescending(o => o.Aggregate).ToList();
            return sortedStudents;
        }

    }
}
