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
            HealingPotions = 2;
        }

        public int PlayerHitChance()
        {
            Random random = new Random();
            var hitChance = random.Next(1, 10);
            return hitChance;
        }

        public void PlayerAttack()
        {
            Console.WriteLine($"You raise your {WeaponName} and..");
            Thread.Sleep(600);
            PlayerHitChance();
        }

        public void ShowHealth()
        {
            if (HealthPoints <= 0)
                Console.WriteLine("You died!");
            else
                Console.WriteLine($"You took quite the hit! You now have {HealthPoints} health left.");
        }

        public void ShowCurrentPlayerHealth()
        {
            Console.WriteLine($"After a gruesome fight you have {HealthPoints} health points left.");
        }


        //Borde kunna bryta ut de här till en Healing class
        public void DrinkHealingPotion()
        {
            Console.WriteLine("\nWould you like to drink a healing potion?");
            var choice = Console.ReadLine();
            if (HealingPotions <= 0)
                Console.WriteLine("You have no healing potions left.");
            else
            if (choice == "yes")
            {
                HealthPoints += 15;
                HealingPotions -= 1;
                Console.WriteLine($"You heal up to {HealthPoints}");
                DrinkAnotherHealingPotion();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Overconfidence is a slow and insidious killer...");
            }
        }

        public void DrinkAnotherHealingPotion()
        {
            Console.WriteLine("Would you like to drink another one?");
            var choice = Console.ReadLine();
            if (HealingPotions <= 0)
                Console.WriteLine("\nYou have no healing potions left.");
            if (choice == "yes")
            {
                HealthPoints += 15;
                HealingPotions -= 1;
                Console.WriteLine($"You heal up to {HealthPoints}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Overconfidence is a slow and insidious killer...");
            }

        }
    }
}
