using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class StudentDL
    {
        private static List<Student> Students = new List<Student>();

        public static void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public static List<Student> GetStudents()
        {
            return Students;
        }   
    }
}
