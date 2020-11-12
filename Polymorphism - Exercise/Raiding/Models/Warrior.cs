namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power 
        {
            set
            {
                this.defaultHeroPower = WarriorPower;
            }
        }
    }
}
