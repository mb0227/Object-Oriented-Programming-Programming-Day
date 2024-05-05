using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            DegreeProgram degreeProgram = new DegreeProgram();
            Subject subject = new Subject();
            string path1 = "..\\..\\Files\\Subjects.txt";
            string path2 = "..\\..\\Files\\DegreePrograms.txt";
            bool run = true;
            if (File.Exists(path1)&& File.Exists(path2))
            {
                SubjectCRUD.ReadData(path1);
                DegreeProgramCRUD.ReadData(path2);
            }
            else
            {
                run = false;
            }
            while (run)
            {
                Console.Clear();
                string option = UserMenu.menu();
                Console.Clear();
                if (option == "1")
                {
                    student = StudentUI.GetStudentData();
                    StudentCRUD.AddStudent(student);
                }
                else if (option == "2")
                {
                    degreeProgram = DegreeProgramUI.GetDegreeInput();
                    DegreeProgramCRUD.AddDegreeProgram(degreeProgram);
                    DegreeProgramCRUD.StoreData(path2, degreeProgram);
                }
                else if (option == "3")
                {
                    List<Student> sortedStudents = new List<Student>();
                    sortedStudents = StudentCRUD.SortStudents();
                    DegreeProgramCRUD.GiveAdmission(sortedStudents);
                    StudentUI.PrintStudents(sortedStudents);
                    Console.ReadKey();
                }
                else if (option == "4")
                {
                    StudentUI.PrintStudents(StudentCRUD.Students);
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    DegreeProgramUI.PrintDegrees();
                    Console.ReadKey();
                }
                else if (option == "6")
                {
                    subject = SubjectUI.AddSubject();
                    student.RegisterSubject(subject);
                }
                else if(option=="7")
                {
                    subject = SubjectUI.AddSubject();
                    SubjectCRUD.AddSubject(subject);
                    SubjectCRUD.StoreData(path1, subject);
                }
                else if (option == "8")
                {
                    break;
                }
            }
            
        }
    }
}
