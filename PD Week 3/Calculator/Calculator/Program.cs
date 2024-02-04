using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string option;
            Calculator calculator = new Calculator();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create a Single Object of Calculator");
                Console.WriteLine("2. Change Values of Attributes");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Subtract");
                Console.WriteLine("5. Multiply");
                Console.WriteLine("6. Divide");
                Console.WriteLine("7. Modulo");
                Console.WriteLine("8. Exit");
                option = takeInput();
                Console.Clear();
                if(option=="1")
                {
                    calculator = new Calculator();
                }
                else if(option=="2")
                {
                    Console.Write("Enter new value for Number1: ");
                    double newNumber1 = double.Parse(Console.ReadLine());

                    Console.Write("Enter new value for Number2: ");
                    double newNumber2 = double.Parse(Console.ReadLine());

                    calculator.modifyValues(newNumber1, newNumber2);
                    Console.WriteLine("Values updated successfully.");
                    Console.ReadKey();
                }
                else if (option == "3")
                {
                    Console.WriteLine(calculator.add());
                    Console.ReadKey();
                }
                else if (option == "4")
                {
                    Console.WriteLine(calculator.subtract());
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    Console.WriteLine(calculator.multiply());
                    Console.ReadKey();
                }
                else if (option == "6")
                {
                    Console.WriteLine(calculator.divide());
                    Console.ReadKey();
                }
                else if (option == "7")
                {
                    Console.WriteLine(calculator.modulo());
                    Console.ReadKey();

                }
                else if(option=="8")
                {
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
        }

        static string takeInput()
        {
            string option = Console.ReadLine();
            return option;
        }
    }
}