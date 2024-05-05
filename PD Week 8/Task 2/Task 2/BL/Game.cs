using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Game
    {
        private Player player;
        public Game()
        {
            player = new Player("");
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }


    }
}
