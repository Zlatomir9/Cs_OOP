using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorist;
        private List<IPlayer> counterTerrorist;

        public Map()
        {
            terrorist = new List<IPlayer>();
            counterTerrorist = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while (IsTeamAlive(terrorist) && IsTeamAlive(counterTerrorist))
            {
                AttackTeam(terrorist, counterTerrorist);
                AttackTeam(counterTerrorist, terrorist);
            }

            if (IsTeamAlive(counterTerrorist))
            {
                return "Counter Terrorist wins!";
            }
            else if (IsTeamAlive(terrorist))
            {
                return "Terrorist wins!";
            }

            return "WOOOW";
        }

        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }

        private void AttackTeam(List<IPlayer> attackingTeam, List<IPlayer> defendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
                //if (!attacker.IsAlive) continue;

                foreach (var defender in defendingTeam)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }
        private void SeparateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is CounterTerrorist)
                {
                    counterTerrorist.Add(player);
                }
                else if (player is Terrorist)
                {
                    terrorist.Add(player);
                }
            }
        }
    }
}
