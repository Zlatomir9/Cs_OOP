using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split();
                string[] doughArgs = Console.ReadLine().Split();
                Dough dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);
                List<Topping> toppings = new List<Topping>();

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppingArgs = input.Split();
                    Topping topping = new Topping(toppingArgs[1], double.Parse(toppingArgs[2]));
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
