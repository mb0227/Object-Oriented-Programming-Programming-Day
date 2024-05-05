using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class StudentUI
    {
        public static Student GetStudentData()
        {
            string name;
            double fscMarks, ecatMarks;
            int age;
            Student student;

            Console.Write("Enter student name: ");
            name = Console.ReadLine();

            Console.Write("Enter ECAT Marks: ");
            ecatMarks = float.Parse(Console.ReadLine());

            Console.Write("Enter FSC MArks: ");
            fscMarks = float.Parse(Console.ReadLine());

            Console.Write("Enter Age: ");
            age = int.Parse(Console.ReadLine());

            List <DegreeProgram> preferences = GetUserPrefernces();

            student = new Student(name, age, fscMarks, ecatMarks, preferences);
            return student;
        }


        public static void DisplayStudent(Student student)
        {
            Console.WriteLine(student.Name + " " + student.EcatMarks + " " + student.FscMarks + "  " + student.Age);
        }

        public static void DisplayAllStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                DisplayStudent(student);
            }
        }

        public static List<DegreeProgram> GetUserPrefernces()
        {   
            List <DegreeProgram> preferences = new List <DegreeProgram> (); 
            Console.Write("Enter total no of preferences to enter: ");
            int total = int.Parse(Console.ReadLine());
            for(int i = 0; i < total;i++) 
            { 
                string x = Console.ReadLine();
                if(DegreeProgramCRUD.ProgramExists(x)!=null)
                {
                    preferences.Add(DegreeProgramCRUD.ProgramExists(x));
                }
            }
            return preferences;
        }

        public static void PrintStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.EnrolledProgram != null)
                {
                    Console.WriteLine("Name: " + student.Name + " Merit: " + student.Aggregate + " Degree: " + student.EnrolledProgram.Title);
                }
                else
                {
                    Console.WriteLine("Name: " + student.Name + " Merit: " + student.Aggregate + " Degree: Not Assigned");
                }
            }
        }

    }
}
