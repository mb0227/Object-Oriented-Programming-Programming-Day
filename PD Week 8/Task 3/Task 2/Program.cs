using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            while (!gameOver)
            {
                Console.Clear();
                Deck deck = new Deck();
                deck.Shuffle();
                while (!gameOver)
                {
                    string input = ConsoleUtility.DrawCards();
                    if (input == "d") //Draw cards
                    {
                        Hand playerHand = new Hand();
                        Hand dealerHand = new Hand();
                        for (int i = 0; i < 2; i++)
                        {
                            playerHand.AddCard(deck.Draw());
                            dealerHand.AddCard(deck.Draw());
                        } //Cards drawn

                        Console.WriteLine();
                        ConsoleUtility.DisplayCards(playerHand.GetCards());
                        Console.WriteLine();
                        Console.WriteLine("Dealer: ");
                        ConsoleUtility.DisplayCard(dealerHand.GetCards(), 0);

                        int playerCardsSum = playerHand.Sum();
                        int dealerCardSum = dealerHand.Sum();

                        ConsoleUtility.DisplayCardSum("Player", playerCardsSum);
                        int check = ConsoleUtility.checkConditions(playerCardsSum);
                        if (check == 1)
                        {
                            ConsoleUtility.PlayerBlackJackWinMessage();
                            gameOver = true;
                            break;
                        }
                        else if (ConsoleUtility.checkConditions(playerHand.Sum()) == -1)
                        {
                            ConsoleUtility.PlayerLoseMessage();
                            gameOver = true;
                            break;
                        }
                        else
                        {
                            Console.Write("Do you want to hit or stand?(h/s) ");
                            string answer = Console.ReadLine();
                            if (answer == "h")
                            {
                                Console.WriteLine("You chose to hit");
                                playerHand.AddCard(deck.Draw());
                                ConsoleUtility.DisplayCards(playerHand.GetCards());
                                playerCardsSum = playerHand.Sum();
                                ConsoleUtility.DisplayCardSum("Player", playerCardsSum);
                                if (dealerHand.Sum() < 17 && playerCardsSum < 22)
                                {
                                    ConsoleUtility.DisplayCardSum("Dealer", dealerHand.Sum());
                                    Console.WriteLine("So Dealer draws more cards");
                                    if (ConsoleUtility.DealerDraws(ref dealerHand, ref playerHand, ref deck) == 1)
                                    {
                                        ConsoleUtility.PlayerLoseMessage();
                                        gameOver = true;
                                        break;
                                    }
                                    else if (ConsoleUtility.DealerDraws(ref dealerHand, ref playerHand, ref deck) == -5)
                                    {
                                        ConsoleUtility.PlayerWinMessage();
                                        gameOver = true;
                                        break;
                                    }
                                    else if (ConsoleUtility.DealerDraws(ref dealerHand, ref playerHand, ref deck) == 2)
                                    {
                                        ConsoleUtility.TieMessage();
                                        dealerHand.Clear();
                                        playerHand.Clear();
                                        continue;
                                    }
                                    else if (playerHand.Sum() > 21)
                                    {
                                        ConsoleUtility.PlayerLoseMessage();
                                        gameOver = true;
                                        break;
                                    }
                                    else
                                    {
                                        ConsoleUtility.PlayerWinMessage();
                                        gameOver = true;
                                        break;
                                    }

                                }
                                else if (ConsoleUtility.checkConditions(playerHand.Sum()) == 1 && dealerHand.Sum() > 17)
                                {
                                    ConsoleUtility.PlayerBlackJackWinMessage();
                                    gameOver = true;
                                    break;
                                }
                                else if (ConsoleUtility.checkConditions(playerHand.Sum()) == -1 && dealerHand.Sum() > 17)
                                {
                                    ConsoleUtility.PlayerLoseMessage();
                                    gameOver = true;
                                    break;
                                }
                                else if (playerHand.Sum() > dealerHand.Sum() && dealerHand.Sum() > 17)
                                {
                                    ConsoleUtility.PlayerWinMessage();
                                    gameOver = true;
                                    break;
                                }

                            }
                            else if (answer == "s")
                            {
                                Console.WriteLine("You chose to stand");
                                if (dealerCardSum < 17 && playerCardsSum < 22)
                                {
                                    ConsoleUtility.DisplayCardSum("Dealer", dealerCardSum);
                                    Console.WriteLine("So Dealer draws more cards");
                                    dealerCardSum = dealerHand.Sum();
                                    if (ConsoleUtility.DealerDraws(ref dealerHand, ref playerHand, ref deck) == 1)
                                    {
                                        ConsoleUtility.DisplayCardSum("Dealer", dealerCardSum);
                                        ConsoleUtility.PlayerLoseMessage();
                                        gameOver = true;
                                        break;
                                    }
                                    else if (ConsoleUtility.DealerDraws(ref dealerHand, ref playerHand, ref deck) == -5)
                                    {
                                        ConsoleUtility.PlayerWinMessage();
                                        gameOver = true;
                                        break;
                                    }
                                    else if (ConsoleUtility.DealerDraws(ref dealerHand, ref playerHand, ref deck) == 2)
                                    {
                                        ConsoleUtility.TieMessage();
                                        dealerHand.Clear();
                                        playerHand.Clear();
                                        continue;
                                    }
                                    else
                                    {
                                        ConsoleUtility.PlayerWinMessage();
                                        gameOver = true;
                                        break;
                                    }

                                }
                                else if (ConsoleUtility.CheckDealerCards(dealerHand.Sum(), playerHand.Sum()) == 1 && dealerHand.Sum() > 17)
                                {
                                    Console.WriteLine("Dealer hits blackjack");
                                    ConsoleUtility.PlayerLoseMessage();
                                    gameOver = true;
                                    break;
                                }
                                else if (ConsoleUtility.CheckDealerCards(dealerHand.Sum(), playerHand.Sum()) == 2 && dealerHand.Sum() > 17)
                                {
                                    ConsoleUtility.PlayerLoseMessage();
                                    gameOver = true;
                                    break;
                                }
                                else if (ConsoleUtility.CheckDealerCards(dealerHand.Sum(), playerHand.Sum()) == -1 && dealerHand.Sum() > 17)
                                {
                                    ConsoleUtility.PlayerWinMessage();
                                    gameOver = true;
                                    break;
                                }
                                else if (ConsoleUtility.CheckDealerCards(dealerHand.Sum(), playerHand.Sum()) == 0 && dealerHand.Sum() > 17)
                                {
                                    ConsoleUtility.TieMessage();
                                    dealerHand.Clear();
                                    playerHand.Clear();
                                    continue;
                                }


                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
    }
}


