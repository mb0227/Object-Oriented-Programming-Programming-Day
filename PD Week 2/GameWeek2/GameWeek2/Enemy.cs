using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Enemy
    {
        public Enemy(int enemyX, int enemyY, char p)
        {
            eX = enemyX;
            eY = enemyY;
            enemy = p;
        }
        public int eX;
        public int eY;
        public char enemy;
    }
}
