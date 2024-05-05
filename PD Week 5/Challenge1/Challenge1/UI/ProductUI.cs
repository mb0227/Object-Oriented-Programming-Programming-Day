using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class ProductUI
    {
        public static Product TakeProductInput()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            Product product = new Product(name, category, price, stock);

            return product;
        }


        public static void ShowProducts()
        {
            foreach (Product product in ProductCRUD.Products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
