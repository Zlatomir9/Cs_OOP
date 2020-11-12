namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public int defaultHeroPower;
        protected BaseHero(string name)
        {
            this.Name = name;
            this.Power = defaultHeroPower;
        }

        public string Name { get; }

        public virtual int Power
        {
            get
            {
                return this.defaultHeroPower;
            }
            set
            {
                this.defaultHeroPower = value;
            }
        }

        public string CastAbility()
        {
            if ((this.GetType().Name == "Druid")
                || (this.GetType().Name == "Paladin"))
            {
                return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
            }
            else
            {
                return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
            }
        }
    }
}
