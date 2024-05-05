using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalDuel.BL
{
    internal class Stats
    {
        public string Name;
        public double Damage;
        public string Description;
        public double Penetration;
        public double Cost;
        public double Heal;

        public Stats(string Name,double Damage, string Description, double Penetration, double Cost, double Heal)
        {
            this.Name = Name;
            this.Damage = Damage;
            this.Description = Description;
            this.Penetration = Penetration;
            this.Cost = Cost;
            this.Heal = Heal;
        }
        
    }
}
