using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class CoffeeShopCRUD
    {
        public static List <MenuItem> ShopMenu = new List<MenuItem> ();
        public static List <string> Orders = new List<string>();
        public static List <CoffeeShop> Shops = new List<CoffeeShop>();

        public static void AddMenuItem(MenuItem item)
        {
            ShopMenu.Add(item);
        }

        public static void AddShop(CoffeeShop name)
        {
            Shops.Add(name);
        }

        public static void AddOrder(string order)
        {
            Orders.Add(order);
        }

        public static string FulfilLOrder()
        {
            if(Orders.Count!=0)
            {
                Orders.RemoveAt(Orders.Count - 1);
                return "The " + Orders[Orders.Count-1]+" is ready";
            }
            else
            {
                return "All order have been fulfilled";
            }
        }

        public static List <string> ListOrders()
        {
            if(Orders.Count>0)
            {
                return Orders;
            }
            return null;
        }

        public static int AmountDue()
        {
            int total = 0;
            for (int i=0;i<Orders.Count;i++)
            {
                for (int j = 0; j < ShopMenu.Count;j++)
                {
                    if (Orders[i] == ShopMenu[j].Name)
                    {
                        total += ShopMenu[j].Price;
                    }
                }
            }
            return total;
        }

        public static string CheapestItem()
        {
            if (ShopMenu.Count > 1)
            {
                List<MenuItem> Cheapest = ShopMenu.OrderBy(o => o.Price).ToList();
                return Cheapest[ShopMenu.Count - 1].Name;
            }
            return null;
        }

        public static List<string> ReturnFoodItems()
        {
            List <string> Items = new List<string>();
            
            foreach(MenuItem item in ShopMenu)
            {
                if(item.Type=="food")
                {
                   Items.Add(item.Name);
                }
            }      
            return Items;
        }

        public static List<string> ReturnDrinkItems()
        {
            List<string> Items = new List<string>();

            foreach (MenuItem item in ShopMenu)
            {
                if (item.Type == "drinks")
                {
                    Items.Add(item.Name);
                }
            }
            return Items;
        }

        public static bool ShopExists(CoffeeShop shop)
        {
            foreach(CoffeeShop c in Shops)
            {
                if(shop.ShopName==c.ShopName)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
