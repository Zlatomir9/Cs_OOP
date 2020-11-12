using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBaseHero> raidGroup = new List<IBaseHero>();

            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            while (counter != n)
            {
                IBaseHero hero = null;
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    if (heroType == nameof(Druid))
                    {
                        hero = new Druid(heroName);
                    }
                    else if (heroType == nameof(Paladin))
                    {
                        hero = new Paladin(heroName);
                    }
                    else if (heroType == nameof(Rogue))
                    {
                        hero = new Rogue(heroName);
                    }
                    else if (heroType == nameof(Warrior))
                    {
                        hero = new Warrior(heroName);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }

                    raidGroup.Add(hero);
                    counter++;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;

            foreach (var hero in raidGroup)
            {
                heroesPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (bossPower <= heroesPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
