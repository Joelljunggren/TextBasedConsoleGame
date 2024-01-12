using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextBasedConsoleGame
{
    internal class Werewolf : MonsterBase
    {
        public Werewolf()
        {
            MonsterName = "Werewolf";
            HealthPoints = 55;
            Damage = 9;
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
