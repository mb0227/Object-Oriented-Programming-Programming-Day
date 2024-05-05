using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3.BL
{
    internal class Shiritori
    {
        public List<string> Words;
        public bool GameOver;
        public Shiritori()
        {
            Words = new List<string>();
            GameOver = false;
        }
        public void Play(string word)
        {
            if (GameOver)
            {
                Console.WriteLine("Game is already over.");
                return;
            }

            if (Words.Count > 0 && word[0] != Words[Words.Count - 1][Words[Words.Count - 1].Length - 1])
            {
                GameOver = true;
                Console.WriteLine("Game over! Word does not match the rules.");
                return;
            }

            if (Words.Contains(word))
            {
                GameOver = true;
                Console.WriteLine("Game over! Word has already been said.");
                return;
            }

            Words.Add(word);
        }

        public string Restart()
        {
            Words.Clear();
            GameOver = false;
            return "Game restarted.";
        }
    }
}
