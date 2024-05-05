using MagicalDuel.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicalDuel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110, 50, 10);
            Player bob = new Player("Bob", 100, 60, 20);

            Stats fireball = new Stats("fireball", 23, "a fiery magical attack", 1.2, 15, 5);
            alice.learnSkill(fireball);
            Console.WriteLine(alice.attack(bob));

            Stats superbeam = new Stats("superbeam", 200, "an overpowered attack, pls nerf", 50, 50, 75);
            bob.learnSkill(superbeam);
            Console.WriteLine(bob.attack(alice));

            Console.ReadKey();
        }
    }
}
