using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedConsoleGame
{
    internal class Skeleton : MonsterBase
    {
        public Skeleton()
        {
            MonsterName = "Skeleton";
            HealthPoints = 50;
            Damage = 8;
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
