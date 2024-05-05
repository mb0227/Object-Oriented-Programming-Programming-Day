using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class ConsoleUtility
    {
        public static string GetName()
        {
            Console.Write("Please Enter your name: ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static string StartGame()
        {
            Console.Write("Do you want to Play a HighLow game? ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static string HigherOrLower()
        {
            string input = "";
            bool breakloop = false;
            while (!breakloop)
            {
                Console.Write("Do you think the next card will be higher or lower?(h/l) ");
                input = Console.ReadLine();       
                if (input == "h" || input == "l")
                    breakloop = true;
                else
                    Console.WriteLine("Invalid input");
            }
            return input;
        }
        public static string TakeGuess()
        {
            Console.Write("Take a guess? ");
            string input = Console.ReadLine();
            return input;
        }

        public static void DisplayCard(Card card)
        {
            Console.WriteLine("The card is: " + card.ToString());
        }

        public static int GetIntValue(string val)
        {
            if (val == "Jack")
                return 11;
            else if (val == "Queen")
                return 12;
            else if (val == "King")
                return 13;
            else if (val == "Ace")
                return 1;
            else
            {
                for (int i = 2;i<11;i++)
                {
                    if (i == int.Parse(val))
                        return i;
                }
                return 0;
            }
        }

        public static int GetCardValue(string val)
        {
            if (val == "Clubs")
                return 1;
            else if (val == "Diamonds")
                return 2;
            else if (val == "Spades")
                return 3;
            else if (val == "Hearts")
                return 4;
            else
                return 0;
        }

        public int CompareCards(Card card1, Card card2)
        {
            if (card1.GetValue().GetCardValue() > card2.GetValue().GetCardValue())
                return 1;
            else if (card1.GetValue().GetCardValue() < card2.GetValue().GetCardValue())
                return -1;
            else
                return 0;
        }

    }
}
