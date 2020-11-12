namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;
        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power
        {
            set
            {
                this.defaultHeroPower = RoguePower;
            }
        }
    }
}
