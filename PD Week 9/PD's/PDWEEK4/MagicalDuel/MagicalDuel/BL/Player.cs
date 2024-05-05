using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalDuel.BL
{
    internal class Player
    {
        public string name;
        public double Health;
        private double hp;
        private double maxHp;
        private double energy;
        private double maxEnergy;
        private double armor;
        private Stats skillStatistics;

        public Player(string name, double Health, double energy, double armor)
        {
            this.name = name;
            this.Health = Health;
            this.energy = energy;
            this.armor = armor;
        }

        public void updateHealth(double amount)
        {
            hp += amount;
            if (hp < 0)
                hp = 0;
            else if (hp > maxHp)
                hp = maxHp;
        }

        public void updateEnergy(double amount)
        {
            energy += amount;
            if (energy < 0)
                energy = 0;
            else if (energy > maxEnergy)
                energy = maxEnergy;
        }

        public void updateArmor(double amount)
        {
            armor += amount;
            if (armor < 0)
                armor = 0;
        }

        public void learnSkill(Stats stats)
        {
            skillStatistics = stats;
        }

        public string attack(Player target)
        {
            if (skillStatistics == null)
            {
                return $"{name} attempted to attack, but hasn't learned any skill yet!";
            }

            if (energy < skillStatistics.Cost)
            {
                return $"{name} attempted to use {skillStatistics.Name}, but didn't have enough energy!";
            }

            energy -= skillStatistics.Cost;

            double effectiveArmor = Math.Max(0, target.armor - skillStatistics.Penetration);
            double calculatedDamage = skillStatistics.Damage * ((100 - effectiveArmor) / 100);

            target.updateHealth(-calculatedDamage);
            updateHealth(skillStatistics.Heal);

            string result = $"{name} used {skillStatistics.Name}, {skillStatistics.Description}, against {target.name}, doing {calculatedDamage} damage!";

            if (skillStatistics.Heal > 0)
            {
                result += $" {name} healed for {skillStatistics.Heal} health!";
            }

            if (target.hp <= 0)
            {
                result += $" {target.name} died.";
            }
            else
            {
                double targetHpPercentage = (target.hp / target.maxHp) * 100;
                result += $" {target.name} is at {targetHpPercentage:F2}% health.";
            }

            return result;
        }
    }
}
