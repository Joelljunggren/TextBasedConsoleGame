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
        public int HealingPotions { get; set; }

        public Player()
        {
            HealthPoints = 75;
            Name = string.Empty;
            WeaponName = string.Empty;
            WeaponDamage = 0;
        }

        public int PlayerHitChance()
        {
            Random random = new Random();
            var hitChance = random.Next(1, 10);
            return hitChance;
        }

        public void ShowHealth()
        {
            if (HealthPoints <= 0)
                Console.WriteLine("You died!");
            else
                Console.WriteLine($"You took quite the hit! You now have {HealthPoints} health left.");
        }

        void DrinkHealingPotion()
        {

        }
    }
}
