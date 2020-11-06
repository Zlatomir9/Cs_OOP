using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double whiteCalories = 1.5;
        private const double wholegrainCalories = 1.0;
        private const double crispyCalories = 0.9;
        private const double chewyCalories = 1.1;
        private const double homemadeCalories = 1.0;
        private const double baseCalories = 2;
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.grams = value;
            }
        }

        public double GetCalories(Dough dough) 
        {
            double flourCalories = 0;
            double bakingCalories = 0;

            switch (dough.FlourType.ToLower())
            {
                case "white": 
                    flourCalories = whiteCalories;
                    break;
                case "wholegrain":
                    flourCalories = wholegrainCalories;
                    break;
            }
            switch (dough.BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingCalories = crispyCalories;
                    break;
                case "chewy":
                    bakingCalories = chewyCalories;
                    break;
                case "homemade":
                    bakingCalories = homemadeCalories;
                    break;
            }

            double calories = (baseCalories * dough.Grams) * flourCalories * bakingCalories;

            return calories;
        }
    }
}
