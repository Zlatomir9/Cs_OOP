namespace Prototype
{
    public class Drink
    {
        public Drink(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
    public class Sandwich : SandwichPrototype<Sandwich>
    {
        public Sandwich(string bread, string cheese, string veggies, string meat, Drink drink)
        {
            Bread = bread;
            Cheese = cheese;
            Veggies = veggies;
            Meat = meat;
            Drink = drink;
        }

        public string Bread { get; set; }

        public string Cheese { get; set; }

        public string Veggies { get; set; }

        public string Meat { get; set; }
        public Drink Drink { get; set; }

        public override Sandwich DeepCopy()
        {
            var sandwich = this.MemberwiseClone() as Sandwich;

            sandwich.Bread = new string(this.Bread);
            sandwich.Cheese = new string(this.Cheese);
            sandwich.Veggies = new string(this.Veggies);
            sandwich.Meat = new string(this.Meat);
            sandwich.Drink = new Drink(this.Drink.Name);

            return sandwich;
        }

        public override Sandwich ShallowCopy()
        {
            return this.MemberwiseClone() as Sandwich;
        }

        public override string ToString()
        {
            return $"{this.Bread}, {this.Cheese}, {this.Veggies}, {this.Meat}, {this.Drink.Name}";
        }
    }
}
