using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const double STATS_COUNT = 5;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set 
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }

        public double AverageStat => (this.Endurance + this.Sprint + this.Dribble + this.Shooting + this.Passing) / STATS_COUNT;
    }
}
