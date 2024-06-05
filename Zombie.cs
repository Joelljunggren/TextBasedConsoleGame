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
            HealthPoints = 40;
            Damage = 7;
        }
    }
}
