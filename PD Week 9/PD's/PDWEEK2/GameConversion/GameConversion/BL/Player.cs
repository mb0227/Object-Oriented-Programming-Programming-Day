using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConversion.BL
{
    internal class Player
    {
        public char DisplayCharacter;
        public int X;
        public int Y;

        public Player(char displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            X = x;
            Y = y;
        }
    }
}
