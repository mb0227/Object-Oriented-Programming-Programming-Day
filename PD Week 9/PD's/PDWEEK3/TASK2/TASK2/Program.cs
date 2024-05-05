using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK2.BL;

namespace TASK2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorEx c = null;
            int option = 0;
            while (option != 14)
            {
                Console.Clear();
                Console.WriteLine("CalculatorEx Menu:");
                Console.WriteLine("1. Create a Single Object of CalculatorEx");
                Console.WriteLine("2. Change Values of Attributes");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Subtract");
                Console.WriteLine("5. Multiply");
                Console.WriteLine("6. Divide");
                Console.WriteLine("7. Modulo");
                Console.WriteLine("8. Square Root");
                Console.WriteLine("9. Exponential Function");
                Console.WriteLine("10. Logarithm");
                Console.WriteLine("11. Sine");
                Console.WriteLine("12. Cosine");
                Console.WriteLine("13. Tangent");
                Console.WriteLine("14. Exit");
                Console.Write("Enter your choice: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Clear();
                    Console.Write("Enter the value for Number1: ");
                    double num1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for Number2: ");
                    double num2 = double.Parse(Console.ReadLine());
                    c = new CalculatorEx(num1, num2);
                    Console.WriteLine("CalculatorEx object created successfully!");
                    Console.ReadKey();
                }
                else if (option == 2)
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
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    }
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of addition: {c.Add()}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 4)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of subtraction: {c.Subtract()}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 5)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of multiplication: {c.Multiply()}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 6)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of division: {c.Divide()}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 7)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Result of modulo: {c.Modulo()}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 8)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Square root of Number1: {c.Sqrt(c.Number1)}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 9)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Exponential function of Number1: {c.Exp(c.Number1)}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 10)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Natural logarithm of Number1: {c.Log(c.Number1)}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 11)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Sine of Number1: {c.Sin(c.Number1)}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 12)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Cosine of Number1: {c.Cos(c.Number1)}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 13)
                {
                    Console.Clear();
                    if (c != null)
                        Console.WriteLine($"Tangent of Number1: {c.Tan(c.Number1)}");
                    else
                        Console.WriteLine("Error: CalculatorEx object not created yet.");
                    Console.ReadKey();
                }
                else if (option == 14)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 14.");
                    Console.ReadKey();
                }
            }
        }
    }
}
