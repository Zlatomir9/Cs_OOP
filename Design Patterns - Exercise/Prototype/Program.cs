using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Drink drink = new Drink("Coke");
            Sandwich sandwich = new Sandwich("bread", "cheese", "veggies", "meat", drink);
            Sandwich sandwich2 = sandwich.ShallowCopy();
            Sandwich sandwich3 = sandwich.DeepCopy();

            Console.WriteLine("Original: " + sandwich);
            Console.WriteLine("Shallow copy: " + sandwich2);
            Console.WriteLine("Deep copy: " + sandwich3);
            Console.WriteLine();

            sandwich.Bread = "dark bread";
            sandwich.Cheese = "blue cheese";
            sandwich.Veggies = "tomato";
            sandwich.Meat = "chicken";
            sandwich.Drink.Name = "cold tea";

            Console.WriteLine("Original: " + sandwich);
            Console.WriteLine("Shallow copy: " + sandwich2);
            Console.WriteLine("Deep copy: " + sandwich3);
        }
    }
}
