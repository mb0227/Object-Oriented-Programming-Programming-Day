using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                string player = ConsoleUtility.GetName();
                string input = ConsoleUtility.StartGame();
                if (input == "y")
                {
                    Console.Clear();
                    Game game = new Game();
                    game.SetPlayer(new Player(player));
                    int score = 0;
                    Deck deck = new Deck();
                    deck.Shuffle();
                    while (deck.CardsLeft()>0)
                    {
                        Console.Clear();
                        string highlow = ConsoleUtility.HigherOrLower();
                        string guess = ConsoleUtility.TakeGuess();
                        string[] x= guess.Split(' ');
                        int val = ConsoleUtility.GetIntValue(x[0]);
                        int cardVal = ConsoleUtility.GetCardValue(x[2]);
                        if (val==0 || cardVal==0)
                        {
                            Console.WriteLine("Invalid input");
                            Console.Read();
                            continue;
                        }
                        Card card = deck.Draw();
                        Card Guess = new Card(new Suit(cardVal), new Value(val));
                        if (card != null)
                        {
                            Console.WriteLine("The card is: " + card.ToString());
                            Console.WriteLine("The guess is: " + Guess.ToString());
                            Console.Read();
                            if (highlow == "h")
                            {
                                if (card.GetValue().GetCardValue() > Guess.GetValue().GetCardValue())
                                {
                                    Console.WriteLine("You guessed right");
                                    Console.Read();
                                    score++;
                                }
                                else
                                {
                                    Console.WriteLine("You guessed wrong. Game Over");
                                    Console.Read();
                                    break;
                                }
                            }
                            else
                            {
                                if (card.GetValue().GetCardValue() < Guess.GetValue().GetCardValue())
                                {
                                    Console.WriteLine("You guessed right");
                                    Console.Read();
                                    score++;
                                }
                                else
                                {
                                    Console.WriteLine("You guessed wrong. Game Over");
                                    Console.Read();
                                    Console.WriteLine("Your score is: " + score);
                                    Console.Read();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No more cards in the deck");
                        }
                    }
                }
                else
                {
                    break;
                }
                
                Console.WriteLine("Do you want to play again? (y/n)");
                string answer = Console.ReadLine();
                if (answer == "n")
                    break;
            }
        }
    }
}
