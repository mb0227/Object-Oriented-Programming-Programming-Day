using CompleteUAMS.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.DL
{
    internal class StudentDL
    {
        public static List<Student> studentList = new List<Student>();
        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.Name && s.RegDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach (Student s in studentList)
            {
                s.CalculateMerit();
            }
            sortedStudentList = studentList.OrderByDescending(o => o.Merit).ToList();
            return sortedStudentList;
        }
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.Preferences)
                {
                    if (d.Seats > 0 && s.RegDegree == null)
                    {
                        s.RegDegree = d;
                        d.Seats = d.Seats - 1;
                        break;
                    }
                }
            }
        }

        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }
        public static bool storeintoDB ( Student s, string connectionString)
        {
          SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = string .Format("insert into Student (Name,Age,FscMars,EcatMarks) VALUES ('{0}','{1}','{2}','{3}')", s.Name, s.Age, s.FscMarks, s.EcatMarks);
            SqlCommand command = new SqlCommand(query, connection);
            int rows = command.ExecuteNonQuery();
            connection.Close();
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
             
            
        }
       
    }
}

