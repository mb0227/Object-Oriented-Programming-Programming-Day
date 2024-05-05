using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class UserMenu
    {
        static public string menu()
        {
            string option;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Students");
            Console.WriteLine("5. View degrees programs");
            Console.WriteLine("6. Register subject");
            Console.WriteLine("7. Enter new subject");
            Console.WriteLine("8. Exit");
            Console.Write("Input: ");
            option = Console.ReadLine();
            return option;
        }
    }
}
