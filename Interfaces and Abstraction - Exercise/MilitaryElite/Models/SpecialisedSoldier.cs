using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Text;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum) 
            : base(id, firstName, lastName, salary)
        {
            this.SoldierCorpEnum = soldierCorpEnum;
        }

        public SoldierCorpEnum SoldierCorpEnum { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {SoldierCorpEnum}");
            return sb.ToString().Trim();
        }
    }
}
