using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team() 
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name 
        {
            get 
            {
                return this.name;
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine($"A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Rating => 
            this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.OverallSkill)) : 0;

        public void AddPlayer(Player player) 
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName) 
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
