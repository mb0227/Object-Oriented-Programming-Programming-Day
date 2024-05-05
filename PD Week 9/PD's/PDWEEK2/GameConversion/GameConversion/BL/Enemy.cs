using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConversion.BL
{
    internal class Enemy
    {
        public char DisplayCharacter;
        public int X;
        public int Y;
        public bool Collided;
        public Enemy(char displayCharacter, int x, int y)
        {
            DisplayCharacter = displayCharacter;
            X = x;
            Y = y;
        }
    }
}
