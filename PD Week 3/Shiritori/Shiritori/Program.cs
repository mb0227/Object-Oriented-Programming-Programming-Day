using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shiritori shiritori = new Shiritori();
            while (true)
            {
                Console.Clear();
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();
                string data = shiritori.play(word);
                if (data == "Game over!")
                {
                    Console.WriteLine("Game over!");
                    Console.Write("Do you want to restart? (y/n): ");
                    string restart = Console.ReadLine();
                    if (restart == "y")
                    {
                        shiritori.restart();
                    }
                    else
                    {
                        break;
                    }
                }
                if (word == "Added" || word == "Word was empty, added to list!")
                {
                    Console.WriteLine("Word added to list!");
                    Console.ReadKey();
                }
            }
        }

        
    }
}
