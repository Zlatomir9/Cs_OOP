using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double meatCalories = 1.2;
        private const double veggiesCalories = 0.8;
        private const double cheeseCalories = 1.1;
        private const double sauceCalories = 0.9;
        private const double baseCalories = 2;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type 
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    this.type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double GetCalories(Topping topping)
        {
            double calories = 0;

            switch (topping.Type.ToLower())
            {
                case "meat":
                    calories = meatCalories;
                    break;
                case "veggies":
                    calories = veggiesCalories;
                    break;
                case "cheese":
                    calories = cheeseCalories;
                    break;
                case "sauce":
                    calories = sauceCalories;
                    break;
            }

            double totalCalories = (baseCalories * topping.Weight) * calories;

            return totalCalories;
        }
    }
}
