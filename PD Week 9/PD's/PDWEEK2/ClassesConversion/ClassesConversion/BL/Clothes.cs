using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesConversion.BL
{
    internal class Clothes
    {
        public int Id;
        public string Name;
        public double Price;

        public Clothes(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
