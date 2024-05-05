using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class DegreeProgram
    {
        public DegreeProgram() { }

        public DegreeProgram(string title, int duration, int seats, List<Subject> subjects) {
            Title = title;
            Duration = duration;
            Seats = seats;
            Subjects = subjects;
        }

        public string Title;
        public int Duration;
        public int Seats;

        public List <Subject> Subjects;

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

    }
}
