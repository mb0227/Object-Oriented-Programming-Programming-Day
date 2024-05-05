using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class ConsoleUtility
    {
        public static string DrawCards()
        {
            Console.Write("Press d to draw cards: ");
            string input = Console.ReadLine();
            return input;
        }

        public static void DisplayCards(List<Card> cards)
        {
            Console.WriteLine("Player Cards: ");
            foreach (Card card in cards)
                Console.WriteLine(card.ToString());
        }

        public static void DisplayCard(List <Card> cards,int index) 
        { 
            Console.WriteLine("The Dealer's card is: " + cards[index].ToString());
            Console.Read();
        }

        public static int checkConditions(int sum)
        {
            if (sum == 21)
            {
                return 1;
            }
            else if (sum > 21)
            {
                return -1;
            }
            return 0;
        }

        public static int CheckDealerCards(int sum,int psum)
        {
            Console.WriteLine("The sum of Dealers cards is: " + sum);
            Console.Read();
            if (sum == 21)
            {
                return 1;
            }
            else if (sum > 21)
            {
                return -1;
            }
            else if (sum > psum)
            {
                return 2;
            }
            else if (sum == psum)
            {
                return 0;
            }
            else
            {
                return -2;
            }
        }

        public static int DealerDraws(ref Hand dealerHand,ref Hand playerHand,ref Deck deck)
        {
            while (dealerHand.Sum() < 17)
            {
                dealerHand.AddCard(deck.Draw());
                DisplayCard(dealerHand.GetCards(), dealerHand.GetCardCount()-1);
                Console.WriteLine("The sum of Dealer's cards is: " + dealerHand.Sum());
                Console.Read();
                if(dealerHand.Sum()>21)
                {
                    return -5;
                }
                else if (dealerHand.Sum() > playerHand.Sum())
                {
                    return 1;
                }
                else if (dealerHand.Sum() == playerHand.Sum())
                {
                    return 2;
                }
                else if(playerHand.Sum()>21)
                {
                    return 4;
                }
            }
            return 0;
        }

        public static void PlayerBlackJackWinMessage()
        {
            Console.WriteLine("Player Won as he got a blackjack");
            Console.Read();
        }
        public static void PlayerWinMessage()
        {
            Console.WriteLine("Player Won");
            Console.Read();
        }

        public static void PlayerLoseMessage()
        {
            Console.WriteLine("Player lost");
            Console.Read();
        }

        public static void TieMessage()
        {
            Console.WriteLine("Tied");
            Console.Read();

        }
        public static void DisplayCardSum(string type,int sum)
        {
            Console.WriteLine("The sum of "+ type +" cards is: " + sum);
            Console.Read();
        }
        //pub
        //lic static int GetIntValue(string val)
        //{
        //    if (val == "Jack")
        //        return 11;
        //    else if (val == "Queen")
        //        return 12;
        //    else if (val == "King")
        //        return 13;
        //    else if (val == "Ace")
        //        return 1;
        //    else
        //    {
        //        for (int i = 2;i<11;i++)
        //        {
        //            if (i == int.Parse(val))
        //                return i;
        //        }
        //        return 0;
        //    }
        //}



    }
}
