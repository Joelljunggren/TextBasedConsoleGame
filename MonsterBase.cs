﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedConsoleGame
{
    public class MonsterBase
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

        public void MonsterAttack()
        {
            Console.WriteLine($"The {MonsterName} starts it's attack and..");
            Thread.Sleep(600);
            HitChance();
        }

        public void Attack(Player player)
        {
            if (player.HealthPoints <= 0)
                return;

            Console.WriteLine($"\nThe {MonsterName} starts it's attack and..");
            Thread.Sleep(600);

            if(HitChance() <= 6)
                Console.WriteLine("It missed!\n");

            else
            {
                int damageTaken = Damage;
                player.HealthPoints -= damageTaken;
                player.ShowHealth();
                Console.WriteLine();
            }
        }

        public void MonsterArival()
        {
            string text = $"\nA {MonsterName} stands before you!\nIt has {HealthPoints} health points and deals {Damage} damage per hit.\n";
            Console.WriteLine(text);
        }

        public void ShowHealth()
        {
            if (HealthPoints <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You killed it!");
                Console.ResetColor();
            }
            else
                Console.WriteLine($"A fine hit, the {MonsterName} has {HealthPoints} health left!");
        }

    }
}
