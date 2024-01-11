using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedConsoleGame
{
    internal class Zombie : MonsterBase
    {
        public Zombie()
        {
            MonsterName = "Zombie";
            HealthPoints = 60;
            Damage = 7;
        }

        public void ShowHealth()
        {
            if (HealthPoints <= 0)
                Console.WriteLine("You killed it!");
            else
                Console.WriteLine($"A fine hit, the {MonsterName} has {HealthPoints} health left!");
        }

    }
}
