using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class MenuItem
    {
        public MenuItem() { }
        public MenuItem(string name, string type, int price) {
            Name = name; Type = type; Price = price;
        }

        public string Name;
        public string Type;
        public int Price;

    }
}
