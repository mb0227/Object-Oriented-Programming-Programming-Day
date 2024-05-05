using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK1.BL
{
    internal class Calculator
    {
        public double Number1;
        public double Number2;

        public Calculator(double num1 = 10, double num2 = 10)
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
    }
}
