using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK1.BL;

namespace TASK1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator c = null;
            int option = 0;
            while (option != 8)
            {
                Console.Clear();
                Console.WriteLine("Calculator Menu:");
                Console.WriteLine("1. Create a Single Object of Calculator");
                Console.WriteLine("2. Change Values of Attributes");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Subtract");
                Console.WriteLine("5. Multiply");
                Console.WriteLine("6. Divide");
                Console.WriteLine("7. Modulo");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                option = int.Parse(Console.ReadLine()); 
                if(option == 1)
                {
                    Console.Clear();
                    Console.Write("Enter the value for Number1: ");
                    double num1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for Number2: ");
                    double num2 = double.Parse(Console.ReadLine()); 
                    c = new Calculator(num1,num2);
                    Console.WriteLine("Calculator object created successfully!");
                    Console.ReadKey();
                }
                else if(option == 2)
                {
                    Console.Clear();
                    if (c != null)
                    {
                        Console.Write("Enter the new value for Number1: ");
                        c.Number1 = double.Parse(Console.ReadLine());
                        Console.Write("Enter the new value for Number2: ");
                        c.Number2 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Values changed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Calculator object not created yet.");
                    }
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of addition: {c.Add()}");
                    else
                        Console.WriteLine("Error: Calculator object not created yet.");Console.ReadKey();
                }
                else if(option == 4)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of subtraction: {c.Subtract()}");
                    else
                        Console.WriteLine("Error: Calculator object not created yet."); Console.ReadKey();
                }
                else if(option == 5)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of multiplication: {c.Multiply()}");
                    else
                        Console.WriteLine("Error: Calculator object not created yet."); Console.ReadKey();
                }
                else if(option == 6)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of division: {c.Divide()}");
                    else
                        Console.WriteLine("Error: Calculator object not created yet."); Console.ReadKey();
                }
                else if(option == 7) 
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of modulo: {c.Modulo()}");
                    else
                        Console.WriteLine("Error: Calculator object not created yet."); Console.ReadKey();
                }
                else if(option == 8)
                {
                    return;
                }
            }

        }
    }
}
