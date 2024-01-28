using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Player
    {
        public Player(int playerX,int playerY,char p)
        {
            pX = playerX;
            pY = playerY;
            player = p;
        }

    public int pX;
    public int pY;
    public char player;
        
    }
}
