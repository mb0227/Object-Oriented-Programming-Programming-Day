using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Value
    {
        public Value(int value)
        {
            this.value = value;
        }

        private int value;

        public int GetCardValue()
        {
            return value;
        }

        public string ToString()
        {
            if(value >= 2 && value <= 10)
                return value.ToString();
            else if (value == 10)
                return "FaceCard";
            else
                return "Ace";
        }
    }
}
