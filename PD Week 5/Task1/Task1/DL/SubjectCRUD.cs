using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class SubjectCRUD
    {
        public static List<Subject> Subjects = new List<Subject>();

        public static void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        public static void StoreData(string path, Subject subject)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(subject.SubjectCode+","+ subject.CreditHours+","+subject.SubjectType);
            writer.Flush();
            writer.Close();
        }

        public static void ReadData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string record;
            while ((record = reader.ReadLine()) != null)
            {
                string[] splitRecord = record.Split(',');
                Subject subject = new Subject(splitRecord[0], int.Parse(splitRecord[1]), splitRecord[2]);
                Subjects.Add(subject);
            }
            reader.Close();
        }

        public static bool SubjectExists(Subject s)
        {
            foreach (Subject subject in Subjects)
            {
                if(s.SubjectCode == subject.SubjectCode)
                {
                    return true;
                }
            }
            return false;
        }

        public static Subject SubjectByCode(string code)
        {
            foreach (Subject subject in Subjects)
            {
                if (code == subject.SubjectCode)
                {
                    return subject;
                }
            }
            return null;
        }
    }
}
