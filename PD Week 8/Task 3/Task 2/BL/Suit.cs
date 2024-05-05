using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Suit
    {
        public Suit(int value)
        {
            SuitValue = value;
        }

        private int SuitValue;
        public int GetValue()
        {
            return SuitValue;
        }
        public string ToString()
        {
            if (SuitValue == 1)
                return "Clubs";
            else if (SuitValue == 2)
                return "Diamonds";
            else if (SuitValue == 3)
                return "Spades";
            else
                return "Hearts";
        }
    }
}
