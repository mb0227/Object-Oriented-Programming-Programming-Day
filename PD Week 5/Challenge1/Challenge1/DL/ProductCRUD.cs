using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class ProductCRUD
    {
        public static List <Product> Products = new List <Product> ();

        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static void BuyProduct(Product product)
        {
            foreach(Product i in Products)
            {
                if(i.Name == product.Name)
                {
                    i.Stock--;
                }
            }
        }

        public static double GenerateInvoice(Product product)
        {
            return product.Price;
        }

        public static void ViewProduct()
        {
            foreach (Product product in Products)
            {
                Console.WriteLine($"Name: {product.Name}");
            }
        }

        public static bool FindByPrice(int price)
        {
            foreach(Product i in Products)
            {
                if(i.Price == price) 
                    return true;
            }
            return false;
        }

        public static Product HigestPrice()
        {
            if(Products.Count>0)
            {  
              Product product = Products.OrderByDescending(o => o.Price).FirstOrDefault();
              return product;
            }
            return null;
        }

        public static double ReturnTax()
        {
            double sum = 0;
            foreach(Product i in Products)
            {
                if(i.Category == "Food")
                {
                    sum += i.Price * 0.15;
                }
                else if(i.Category == "Grocery")
                {
                    sum += i.Price * 0.5;
                }
                else
                {
                    sum += i.Price * 0.25;
                }
            }
            return sum;
        }

        public static void StoreData(string path, Product item)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(item.Name + "," + item.Price + "," + item.Category+","+item.Stock);
            writer.Close();
        }

        public static void ReadData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string record;
            while ((record = reader.ReadLine()) != null)
            {
                string[] split = record.Split(',');
                string name = split[0];
                int price = int.Parse(split[1]);
                string type = split[2];
                int stock = int.Parse(split[3]);

                Product product = new Product(name, type, price, stock);
                Products.Add(product);
            }
            reader.Close();
        }
    }
}
