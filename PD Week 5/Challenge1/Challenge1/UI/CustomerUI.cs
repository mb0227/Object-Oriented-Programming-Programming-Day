using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class CustomerUI
    {

        public static Customer TakeCustomerInput()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Contact: ");
            int contact = int.Parse(Console.ReadLine());

            Customer customer = new Customer(username, password,email, address, contact);

            return customer;
        }

        public static void DisplayData(Customer user)
        {
            Console.WriteLine("Name: " + user.Username);

        }
    }
}
