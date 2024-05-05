using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMagicalDuel.BL
{
    internal class Stats
    {
        public string name;
        public double damage;
        public string description;
        public double penetration;
        public double cost;
        public double heal;

        public Stats(string name, double damage, double penetration, double heal, double cost, string description)
        {
            this.name = name;
            this.damage = damage;
            this.penetration = penetration;
            this.heal = heal;
            this.cost = cost;
            this.description = description;
        }
    }
}
