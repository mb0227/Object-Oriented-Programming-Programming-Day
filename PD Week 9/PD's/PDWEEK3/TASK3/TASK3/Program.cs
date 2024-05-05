using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK3.BL;

namespace TASK3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shiritori myShiritori = new Shiritori();

            int option = 0;
            while (option != 3)
            {
                Console.Clear();
                Console.WriteLine("Shiritori Menu:");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Restart");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter a word: ");
                        string word = Console.ReadLine();
                        myShiritori.Play(word);
                        Console.WriteLine("CHAIN: " + string.Join(", ", myShiritori.Words));
                        break;
                    case 2:
                        Console.WriteLine(myShiritori.Restart());
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
