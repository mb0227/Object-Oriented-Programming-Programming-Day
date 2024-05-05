using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Card
    {
        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
            FirstAce = false;
        }

        private Suit suit;
        private Value value;
        private bool FirstAce;
        public Suit GetSuit()
        {
            return suit;
        }

        //public Value GetValue()
        //{
        //    return value;
        //}

        public  int GetValue()
        {
            if (value.GetCardValue() >= 2 && value.GetCardValue() <= 10)
            {
                return value.GetCardValue();
            }
            else if (value.GetCardValue() >= 11 && value.GetCardValue() <= 13)
            {
                return 10;
            }
            else if (!FirstAce && value.GetCardValue() == 1)
            {
                FirstAce = true;
                return 11;
            }
            else
            {
                return 1;
            }
        }

        public string ToString()
        {
            return value.ToString() + " of " + suit.ToString();
        }
    }
}
