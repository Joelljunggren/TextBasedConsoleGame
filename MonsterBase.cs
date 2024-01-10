using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedConsoleGame
{
    internal class MonsterBase
    {
        public string MonsterName { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }

        public MonsterBase()
        {

        }

        public int HitChance()
        {
            var random = new Random();
            var attackChance = random.Next(1, 10);
            return attackChance;
        }

    }
}
