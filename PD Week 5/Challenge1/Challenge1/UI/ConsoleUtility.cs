using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class ConsoleUtility
    {
        public static string MainMenu()
        {
            Console.WriteLine("Sign Up");
            Console.WriteLine("Sign In");
            Console.WriteLine("Exit");
            Console.Write("Input: ");
            string input = Console.ReadLine();
            return input;
        }

        public static string AdminMenu()
        {
            Console.WriteLine("1. Add Product.\r\n2. View All Products.\r\n3. Find Product with Highest Unit Price.\r\n4. View Sales Tax of All Products.\r\n5. Products to be Ordered. (less than threshold)\r\n6. View Profile (Username, Password)\r\n7. Exit");
            string input = Console.ReadLine();
            return input;
        }

        public static string CustomerMenu()
        {
            Console.WriteLine("1. View all the products\r\n2. Buy the products\r\n3. Generate invoice\r\n4. View Profile (Username, Password, Email, Address and Contact Number)\r\n5. Exit");
            string input = Console.ReadLine();
            return input;
        }
    }
}
