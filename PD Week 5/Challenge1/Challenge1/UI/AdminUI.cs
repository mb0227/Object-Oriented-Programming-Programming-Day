using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class AdminUI
    {
        public static Admin TakeAdminInput()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();   

            Admin admin = new Admin(username, password);

            return admin;
        }

        public static void DisplayData(Admin admin)
        {
            Console.WriteLine("Name: " + admin.Username);
        }
    }
}
