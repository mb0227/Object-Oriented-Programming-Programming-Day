using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Deck
    {
        private List<Card> Cards;
        public Deck()
        {
            Cards = new List<Card>();

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Cards.Add(new Card(new Suit(i), new Value(j)));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int j = random.Next(Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }
        public Card Draw()
        {
            if (Cards.Count == 0)
            {
                return null;
            }
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public int CardsLeft()
        {
            return Cards.Count;
        }
    }
}
