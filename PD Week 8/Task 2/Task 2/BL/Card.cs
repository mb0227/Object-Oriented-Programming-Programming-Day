using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Card
    {
        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        private Suit suit;
        private Value value;

        public Suit GetSuit()
        {
            return suit;
        }

        public Value GetValue()
        {
            return value;
        }

        public string ToString()
        {
            return value.ToString() + " of " + suit.ToString();
        }
    }
}
