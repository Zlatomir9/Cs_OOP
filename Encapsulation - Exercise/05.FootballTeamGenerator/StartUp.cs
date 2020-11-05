using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splittedCommand = command.Split(';');

                string commandType = splittedCommand[0];

                try
                {
                    if (commandType == "Team")
                    {
                        string teamName = splittedCommand[1];
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (commandType == "Add")
                    {
                        string teamName = splittedCommand[1];
                        string playerName = splittedCommand[2];
                        int endurance = int.Parse(splittedCommand[3]);
                        int sprint = int.Parse(splittedCommand[4]);
                        int dribble = int.Parse(splittedCommand[5]);
                        int passing = int.Parse(splittedCommand[6]);
                        int shooting = int.Parse(splittedCommand[7]);

                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                            Player player = new Player(playerName, stats);
                            Team team = teams.First(t => t.Name == teamName);
                            team.AddPlayer(player);
                        }
                    }
                    else if (commandType == "Remove")
                    {
                        string teamName = splittedCommand[1];
                        string playerName = splittedCommand[2];

                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Team team = teams.First(t => t.Name == teamName);
                            team.RemovePlayer(playerName);
                        }
                    }
                    else if (commandType == "Rating")
                    {
                        string teamName = splittedCommand[1];
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Team team = teams.First(t => t.Name == teamName);
                            Console.WriteLine(team);
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                catch (InvalidOperationException ioe) 
                {
                    Console.WriteLine(ioe.Message);
                }
                
                command = Console.ReadLine();
            }
        }
    }
}
