using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class DegreeProgramCRUD
    {

        public DegreeProgramCRUD()
        {
            DegreePrograms = new List<DegreeProgram>();
        }

        public static List<DegreeProgram> DegreePrograms = new List<DegreeProgram>();

        public static void AddDegreeProgram(DegreeProgram degree)
        {
            DegreePrograms.Add(degree);
        }

        public static void RemoveProgram(int index)
        {
            DegreePrograms.RemoveAt(index);
        }

        public static DegreeProgram ProgramExists(string x)
        {
            if (DegreePrograms.Count > 0)
            {
                foreach (DegreeProgram d in DegreePrograms)
                {
                    if (x == d.Title)
                        return d;
                }
                return null;
            }
            return null;
        }

        public static void GiveAdmission(List<Student> students)
        {
            foreach (Student student in students)
            {
                foreach (DegreeProgram degreeProgram in student.Preferences)
                {
                    if (degreeProgram.Seats > 0 && student.EnrolledProgram == null)
                    {
                        student.EnrolledProgram = degreeProgram;
                        degreeProgram.Seats--;
                        break;
                    }
                }
            }
        }

        public static void ReadData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string record;
            DegreeProgram degreeProgram = new DegreeProgram();
            List<Subject> subjects = new List<Subject>();
            while ((record = reader.ReadLine()) != null)
            {
                string[] splitRecord = record.Split(',');
                string title = splitRecord[0];
                int duration = int.Parse(splitRecord[1]);
                int seats = int.Parse(splitRecord[2]);
                string[] splitForSubject = splitRecord[3].Split(';');
                for(int i=0; i<splitForSubject.Length; i++)
                {
                    if (SubjectCRUD.SubjectByCode(splitForSubject[i]) != null)
                    {
                        subjects.Add(SubjectCRUD.SubjectByCode(splitForSubject[i]));
                    }
                }
                DegreeProgram d = new DegreeProgram(title, duration, seats, subjects);
                DegreePrograms.Add(d);
            }
            Console.WriteLine(DegreePrograms[0].Subjects[0].SubjectCode);
            Console.ReadKey();
            reader.Close();
        }

        public static void StoreData(string path, DegreeProgram degreeProgram)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.Write(degreeProgram.Title + "," + degreeProgram.Duration + "," + degreeProgram.Seats+",");
            for(int i=0;i< degreeProgram.Subjects.Count - 1;i++)
            {
                writer.Write(degreeProgram.Subjects[i].SubjectCode+";");
            }
            writer.Write(degreeProgram.Subjects[degreeProgram.Subjects.Count - 1].SubjectCode);
            writer.Write('\n');
            writer.Flush();
            writer.Close();
        }

    }
}
