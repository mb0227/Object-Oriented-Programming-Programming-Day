using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Student : Person
    {
        public Student(string n, string a, string p, int y, double f) : base(n, a)
        {
            Program = p;
            Year = y;
            Fee = f;
        }
        private string Program;
        private int Year;
        public double Fee;

        public string GetProgram()
        {
            return Program;
        }

        public void SetProgram(string p)
        {
            Program = p;
        }

        public int GetYear()
        {
            return Year;
        }

        public void SetYear(int y)
        {
            Year = y;
        }

        public double GetFee()
        {
            return Fee;
        }

        public void SetFee(double f)
        {
            Fee = f;
        }

        public new string ToString()
        {
            return "Student["+ base.ToString()+"],[Program: "+this.Program+", Year: "+this.Year+", Fee: "+this.Fee+"]]";
        }
    }
}
