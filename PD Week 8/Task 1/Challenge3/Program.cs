using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Bilal", "Khalid Hall", "Computer Science", 2023, 10000);
            Staff t = new Staff("Ali", "Edhi Hall", "School of Computer Science", 50000);
            Staff t2 = new Staff("Hamza", "Tariq Hall", "School of Computer Engg", 5000);

            Console.WriteLine(s.ToString());
            Console.WriteLine(t.ToString());
            Console.WriteLine(t2.ToString());
            Console.Read();
        }
    }
}
