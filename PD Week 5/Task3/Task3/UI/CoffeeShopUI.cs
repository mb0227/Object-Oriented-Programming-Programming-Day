using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class CoffeeShopUI
    {

        public static void PrintOrders(List <string> orders)
        {
            if (orders.Count != 0)
            {
                foreach (string order in orders)
                {
                    Console.WriteLine(order);
                }
            }
        }

        public static void ShowItems(string type)
        {
            if(type=="drinks")
            {
                foreach(MenuItem item in CoffeeShopCRUD.ShopMenu)
                {
                    if(item.Type=="drinks")
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
            else if(type =="food")
            {
                foreach (MenuItem item in CoffeeShopCRUD.ShopMenu)
                {
                    if (item.Type == "food")
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
            Console.ReadKey();
        }

    }
}
