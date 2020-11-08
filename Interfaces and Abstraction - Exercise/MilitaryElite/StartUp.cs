using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();
            ISoldier soldier;
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandTokens = command.Split();
                string soldierType = commandTokens[0];

                if (soldierType == typeof(Private).Name)
                {
                    soldier = new Private(int.Parse(commandTokens[1]), commandTokens[2], commandTokens[3], decimal.Parse(commandTokens[4]));
                    soldiers.Add(soldier);
                }
                else if (soldierType == typeof(LieutenantGeneral).Name)
                {
                    ICollection<IPrivate> privates = new List<IPrivate>();
                    for (int i = 5; i < commandTokens.Length; i++)
                    {
                        privates.Add((IPrivate)(soldiers.FirstOrDefault(x => x.Id == int.Parse(commandTokens[i]))));
                    }
                    soldier = new LieutenantGeneral(int.Parse(commandTokens[1]), commandTokens[2], commandTokens[3],
                        decimal.Parse(commandTokens[4]), privates);
                    soldiers.Add(soldier);
                }
                else if (soldierType == typeof(SpecialisedSoldier).Name)
                {
                    if (IsCorrectCorpsName(commandTokens[5]))
                    {
                        soldier = new SpecialisedSoldier(int.Parse(commandTokens[1]), commandTokens[2], commandTokens[3],
                        decimal.Parse(commandTokens[4]), (SoldierCorpEnum)Enum.Parse(typeof(SoldierCorpEnum), commandTokens[5]));
                        soldiers.Add(soldier);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (soldierType == typeof(Engineer).Name)
                {
                    if (IsCorrectCorpsName(commandTokens[5]))
                    {
                        ICollection<IRepair> repairs = new List<IRepair>();

                        for (int i = 6; i < commandTokens.Length; i += 2)
                        {
                            string partName = commandTokens[i];
                            int hours = int.Parse(commandTokens[i + 1]);

                            repairs.Add(new Repair(partName, hours));
                        }
                        soldier = new Engineer(int.Parse(commandTokens[1]), commandTokens[2], commandTokens[3],
                        decimal.Parse(commandTokens[4]), (SoldierCorpEnum)Enum.Parse(typeof(SoldierCorpEnum), commandTokens[5]), repairs);
                        soldiers.Add(soldier);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (soldierType == typeof(Commando).Name)
                {
                    ICollection<IMission> missions = new List<IMission>();

                    for (int i = 6; i < commandTokens.Length; i += 2)
                    {
                        string missionType = commandTokens[i + 1];
                        if ((missionType == ((MissionStateEnum)(1)).ToString())
                            || (missionType == ((MissionStateEnum)(2)).ToString()))
                        {
                            string codeName = commandTokens[i];
                            missions.Add(new Mission(codeName, (MissionStateEnum)Enum.Parse(typeof(MissionStateEnum), commandTokens[i + 1])));
                        }
                        else
                        {
                            continue;
                        }
                    }
                    soldier = new Commando(int.Parse(commandTokens[1]), commandTokens[2], commandTokens[3],
                        decimal.Parse(commandTokens[4]), (SoldierCorpEnum)Enum.Parse(typeof(SoldierCorpEnum), commandTokens[5]), missions);
                    soldiers.Add(soldier);
                }
                else if (soldierType == typeof(Spy).Name)
                {
                    soldier = new Spy(int.Parse(commandTokens[1]), commandTokens[2], commandTokens[3], int.Parse(commandTokens[4]));
                    soldiers.Add(soldier);
                }
            }

            PrintResult(soldiers);
        }

        public static bool IsCorrectCorpsName(string corpsName)
        {
            if ((corpsName == ((SoldierCorpEnum)(1)).ToString())
                || (corpsName == ((SoldierCorpEnum)(2)).ToString()))
            {
                return true;
            }
            return false;
        }

        public static void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
