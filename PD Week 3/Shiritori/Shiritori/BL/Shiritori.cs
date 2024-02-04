using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Shiritori
    {
        public Shiritori()
        {
            words = new List<string>();
            gameOver = false;
        }

        public bool gameOver;
        public List<string> words;

        public string play(string word)
        {
            string result = "";
            if(gameOver)
            {
                result= "Game over!";
            }
            if(words.Count == 0)
            {
                words.Add(word);
                result = "Word was empty, added to list!";
            }
            else
            {
                for(int i = 0; i < words.Count; i++)
                {
                    if (words[i] == word)
                    {
                        gameOver = true;
                        result= "Game over!";
                    }
                }
                if(!gameOver)
                {
                    string lastWord = words[words.Count - 1];
                    if (word[0] == lastWord[lastWord.Length - 1])
                    {
                        words.Add(word);
                        result = "Added";
                    }
                    else
                    {
                        gameOver = true;
                        result= "Game over!";
                    }
                }
            }
            return result;
        }

        public string restart()
        {
            words.Clear();
            gameOver = false;
            return "Game restarted!";
        }
    }
}
