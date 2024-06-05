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
            HealthPoints = 35;
            Damage = 9;
        }
    }
}
