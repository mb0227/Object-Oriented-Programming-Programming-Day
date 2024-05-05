using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Student
    {

        public Student()
        {
            Preferences = new List<DegreeProgram>();
            EnrolledProgram = null;
            RegisteredSubjects = new List<Subject>();
        }

        public Student(string name, int age, double fscMarks, double ecatMarks, List <DegreeProgram> preferences) {
            Name = name;
            Age = age;
            FscMarks = fscMarks;
            EcatMarks = ecatMarks;
            Preferences = preferences;
        }

        public string Name;
        public int Age;
        public double FscMarks;
        public double EcatMarks;
        public double Aggregate;

        public List<DegreeProgram> Preferences;
        public DegreeProgram EnrolledProgram;
        public List <Subject> RegisteredSubjects;

        public void EnrollStudent(DegreeProgram degree)
        {
            if(EnrolledProgram == null)
            {
                EnrolledProgram = degree;
            }
        }

        public void CalculateMerit()
        {
            Aggregate = (((FscMarks / 1100) * 0.45) + ((EcatMarks / 400) * 55));
        }

        public int CalculateCreditHours()
        {
            int sum = 0;
            foreach(Subject subject in RegisteredSubjects)
            {
                sum += subject.CreditHours;
            }
            return sum;
        }

        public bool RegisterSubject(Subject subject)
        {
            int creditHours = CalculateCreditHours();
            if (EnrolledProgram != null  && creditHours <= 9)
            {
                RegisteredSubjects.Add(subject);
                return true;
            }
            return false;
        }

    }
}
