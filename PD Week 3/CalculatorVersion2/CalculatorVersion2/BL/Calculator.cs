using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorVersion2
{
    internal class Calculator
    {
        public double Number1;
        public double Number2;

        public Calculator()
        {
            Number1 = 10;
            Number2 = 10;
        }

        public Calculator(double number1, double number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public void modifyValues(double number1, double number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public double add()
        {
            return Number1 + Number2;
        }

        public double subtract()
        {
            return Number1 - Number2;
        }

        public double multiply()
        {
            return Number1 * Number2;
        }

        public double divide()
        {
            if (Number2 != 0)
                return Number1 / Number2;
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return double.NaN;
            }
        }

        public double modulo()
        {
            if (Number2 != 0)
                return Number1 % Number2;
            else
            {
                Console.WriteLine("Error: Modulo by zero is not allowed.");
                return double.NaN;
            }
        }

        public double squareRoot(double number)
        {
            return Math.Sqrt(number);
        }

        public double exponent(double exponent)
        {
            return Math.Exp(exponent);
        }

        public double log(double number)
        {
            return Math.Log(number);
        }

        public double trignometricFunctions(string type, double number)
        {
            if (type == "sin")
                return Math.Sin(number);
            else if (type == "cos")
                return Math.Cos(number);
            else if (type == "tan")
                return Math.Tan(number);
            else
                return double.NaN;
        }
    }
}
