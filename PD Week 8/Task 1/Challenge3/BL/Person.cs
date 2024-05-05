using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Person
    {
        public Person(string n, string a)
        {
            Name = n;
            Address = a;
        }

        protected string Name;
        protected string Address;

        public string GetName()
        {
            return Name;
        }

        public string GetAddress()
        {
            return Address;
        }

        public void SetName(string n)
        {
            Name = n;
        }

        public void SetAddress(string a)
        {
            Address = a;
        }

        public string ToString()
        {
            return "Person "+ "[Name: " + Name + ", Address: " + Address+"]";
        }
    }
}
