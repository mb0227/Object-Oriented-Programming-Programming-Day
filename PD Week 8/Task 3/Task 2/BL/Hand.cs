using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Hand
    {
        public Hand() { }
        private List<Card> cards = new List<Card>();

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void Clear()
        {
            cards.Clear();
        }

        public int GetCardCount()
        {
            return cards.Count;
        }

        public List <Card> GetCards()
        {
            return cards;
        }

        public void RemoveCard(Card c)
        {
            cards.Remove(c);
        }

        public void RemoveCardByIndex(int index)
        {
            cards.RemoveAt(index);
        }

        public int Sum()
        {
            int sum = 0;
            foreach (Card card in cards)
            {
                sum += card.GetValue();
            }
            return sum;
        }

        public bool isAcePresent()
        {
            foreach (Card c in cards)
            {
                if (c.GetValue() == 1)
                    return true;
            }
            return false;
        }

    }
}