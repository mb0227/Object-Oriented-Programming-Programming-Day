using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Player
    {
        public Player(string name)
        {
            this.name = name;
        }

        private string name;

        public string GetName()
        {
            return name;
        }
        public string ToString()
        {
            return "Player: " + name;
        }
    }
}
