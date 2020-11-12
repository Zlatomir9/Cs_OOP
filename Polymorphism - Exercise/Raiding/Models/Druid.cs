namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power
        {
            set 
            {
                this.defaultHeroPower = DruidPower;
            }
        }
    }
}
