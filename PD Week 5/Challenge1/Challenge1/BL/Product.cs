using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Product
    {
        public Product() { }
        public Product(string name, string category, double price, int stock)
        {
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }

        public string Name;
        public string Category;
        public double Price;
        public int Stock;

    }
}
