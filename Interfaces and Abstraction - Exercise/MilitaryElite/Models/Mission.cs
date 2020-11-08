using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            this.CodeName = codeName;
            this.MissionStateEnum = missionStateEnum;
        }
        public string CodeName { get; }

        public MissionStateEnum MissionStateEnum { get; private set; }

        public void CompleteMission(string missionName)
        {
            if (this.CodeName == missionName && this.MissionStateEnum == (MissionStateEnum)(1))
            {
                this.MissionStateEnum = (MissionStateEnum)(2);
            }
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {MissionStateEnum}";
        }
    }
}
