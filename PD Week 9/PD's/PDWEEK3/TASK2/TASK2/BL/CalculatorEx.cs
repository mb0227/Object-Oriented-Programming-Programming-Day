using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK2.BL
{
    internal class CalculatorEx
    {
        public double Number1;
        public double Number2;
        public CalculatorEx(double num1 = 10, double num2 = 10)
        {
            Number1 = num1;
            Number2 = num2;
        }

        public double Add()
        {
            return Number1 + Number2;
        }

        public double Subtract()
        {
            return Number1 - Number2;
        }

        public double Multiply()
        {
            return Number1 * Number2;
        }

        public double Divide()
        {
            if (Number2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                return 0;
            }
            else
            {
                return Number1 / Number2;
            }
        }

        public double Modulo()
        {
            if (Number2 == 0)
            {
                Console.WriteLine("Error: Cannot calculate modulo with divisor zero!");
                return 0;
            }
            else
            {
                return Number1 % Number2;
            }
        }
        public double Sqrt(double number)
        {
            if (number < 0)
            {
                Console.WriteLine("Error: Cannot calculate square root of a negative number!");
                return 0;
            }
            else
            {
                return Math.Sqrt(number);
            }
        }
        public double Exp(double exponent)
        {
            return Math.Exp(exponent);
        }
        public double Log(double number)
        {
            if (number <= 0)
            {
                Console.WriteLine("Error: Cannot calculate logarithm of a non-positive number!");
                return 0;
            }
            else
            {
                return Math.Log(number);
            }
        }

        public double Sin(double angle)
        {
            return Math.Sin(angle * Math.PI / 180);
        }

        public double Cos(double angle)
        {
            return Math.Cos(angle * Math.PI / 180);
        }

        public double Tan(double angle)
        {
            return Math.Tan(angle * Math.PI / 180);
        }
    }
}
