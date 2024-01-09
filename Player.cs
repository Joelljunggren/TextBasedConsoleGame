using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedConsoleGame
{
    internal class Player
    {
        public int HealthPoints { get; set; }
        public string Name { get; set; }
        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; }
        public int HitChance { get; set; }

        public Player()
        {
            HealthPoints = 75;
            Name = string.Empty;
            WeaponName = string.Empty;
            WeaponDamage = 0;
            HitChance = 20;
        }

        void FightSequence()
        {

        }
    }
}
