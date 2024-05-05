using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string option;
            MenuItem item = new MenuItem();
            CoffeeShop shop = new CoffeeShop();
            string path1 = "..//..//Files//Items.txt";
            if(!File.Exists(path1))
            {
                Environment.Exit(0);
            }
            MenuItemCRUD.ReadData(path1);
            while (true) {
                Console.Clear();
                option = ConsoleUtility.MainMenu();
                Console.Clear();
                if (option == "1")
                {
                    item = ConsoleUtility.TakeMenuItem();
                    MenuItemCRUD.AddItem(item);
                    MenuItemCRUD.StoreData(path1, item);
                }
                else if (option == "2")
                {
                    shop = ConsoleUtility.TakeCoffeeShopInput();
                    CoffeeShopCRUD.AddShop(shop);
                }
                else if (option == "3" || option == "4" || option == "5" || option == "6" || option == "7" || option == "8" || option == "9")
                {
                    shop = ConsoleUtility.TakeCoffeeShopInput();
                    if (CoffeeShopCRUD.ShopExists(shop))
                    {
                        if (option == "3")
                        {
                            string name = CoffeeShopCRUD.CheapestItem();
                            Console.WriteLine("Cheapest Item in Shop is: {0}", name);
                            Console.ReadKey();
                        }
                        else if (option == "4")
                        {
                            CoffeeShopUI.ShowItems("drinks");
                        }
                        else if (option == "5") {
                            CoffeeShopUI.ShowItems("food");
                        }
                        else if (option == "6") {
                            CoffeeShopCRUD.AddOrder(Console.ReadLine());
                        }
                        else if (option == "7") {
                            CoffeeShopCRUD.FulfilLOrder();
                        }
                        else if (option == "8") {
                            CoffeeShopUI.PrintOrders(CoffeeShopCRUD.Orders);
                        }
                        else if (option == "9") {
                            Console.WriteLine("Amount: {0}", CoffeeShopCRUD.AmountDue());
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (option == "10") {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
