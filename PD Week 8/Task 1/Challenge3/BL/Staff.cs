using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Staff : Person
    {
        public Staff(string n, string a, string s, double w) : base(n, a)
        {
            School = s;
            Pay = w;
        }

        private string School;
        private double Pay;

        public string GetSchool()
        {
            return School;
        }

        public void SetSchool(string s)
        {
            School = s;
        }

        public double GetPay()
        {
            return Pay;
        }

        public void SetPay(double w)
        {
            Pay = w;
        }

        public new string ToString()
        {
            return "Staff[" + base.ToString() + "], [School: " + this.School + ", Pay: " + this.Pay + "]]";
        }
    }
}
