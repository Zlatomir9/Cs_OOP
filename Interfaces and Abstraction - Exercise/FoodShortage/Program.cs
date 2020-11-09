using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebel);
                }
            }

            string name = Console.ReadLine();
            int boughtFood = 0;

            while (name != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == name)
                    {
                        buyer.BuyFood();
                        boughtFood += buyer.Food;
                    }
                }
                name = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(f => f.Food));
        }
    }
}
