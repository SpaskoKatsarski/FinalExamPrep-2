using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(int health, int mana)
        {
            this.Health = health;
            this.Mana = mana;
        }
        
        public int Health { get; set; }

        public int Mana { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxHealth = 100;
            const int MaxMana = 200;

            Dictionary<string, Hero> allHeroes = new Dictionary<string, Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroesInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroesInfo[0];
                int health = int.Parse(heroesInfo[1]);
                int mana = int.Parse(heroesInfo[2]);

                if (health > MaxHealth)
                {
                    health = MaxHealth;
                }

                if (mana > MaxMana)
                {
                    mana = MaxMana;
                }

                allHeroes.Add(heroName, new Hero(health, mana));
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                string heroName = cmdArgs[1];

                if (action == "CastSpell")
                {
                    int manaNeeded = int.Parse(cmdArgs[2]);
                    string spellName = cmdArgs[3];

                    if (allHeroes[heroName].Mana >= manaNeeded)
                    {
                        allHeroes[heroName].Mana -= manaNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {allHeroes[heroName].Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];

                    allHeroes[heroName].Health -= damage;

                    if (allHeroes[heroName].Health > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {allHeroes[heroName].Health} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        allHeroes.Remove(heroName);
                    }
                }
                else if (action == "Recharge")
                {
                    int manaToRecharge = int.Parse(cmdArgs[2]);

                    if (allHeroes[heroName].Mana + manaToRecharge > MaxMana)
                    {
                        manaToRecharge = MaxMana - allHeroes[heroName].Mana;
                    }

                    allHeroes[heroName].Mana += manaToRecharge;

                    Console.WriteLine($"{heroName} recharged for {manaToRecharge} MP!");
                }
                else if (action == "Heal")
                {
                    int healthToRecharge = int.Parse(cmdArgs[2]);

                    // 70 + 50 > 100 ???
                    if (allHeroes[heroName].Health + healthToRecharge > MaxHealth)
                    {
                        healthToRecharge = MaxHealth - allHeroes[heroName].Health;
                    }

                    allHeroes[heroName].Health += healthToRecharge;
                    
                    Console.WriteLine($"{heroName} healed for {healthToRecharge} HP!");
                }
            }

            foreach (KeyValuePair<string, Hero> hero in allHeroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.Health}");
                Console.WriteLine($"  MP: {hero.Value.Mana}");
            }
        }
    }
}
