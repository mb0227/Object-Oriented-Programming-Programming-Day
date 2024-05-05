using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class ConsoleUtility
    {
        public static string MainMenu()
        {
            Console.WriteLine("1. Add Item\n2. Add a Coffee Shop\n3. View Cheapest Item to specific shop\n4. View Drinks Menu to specific shop\n5. View Food Menu to specific shop\n6. Add Order to specific shop\n7. Fulfill Order from specific shop\n8. View Orders from specific shop\n9. Total Amount for specific shop \n10. Exit");
            string option = Console.ReadLine();
            return option;
        }

        public static MenuItem TakeMenuItem() {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Price: ");
            int price = int.Parse(Console.ReadLine());

            MenuItem newItem = new MenuItem(name, type, price);
            return newItem;
        }

        public static CoffeeShop TakeCoffeeShopInput()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            CoffeeShop newShop = new CoffeeShop(name);

            return newShop;
        }
    }
}
