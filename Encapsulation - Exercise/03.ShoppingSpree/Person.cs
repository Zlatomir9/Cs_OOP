using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.bag = new List<Product>();
            this.Name = name;
            this.Money = money;
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            } 
        }

        public decimal Money 
        {
            get 
            {
                return this.money;
            }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Bag 
        {
            get 
            {
                return this.bag;
            }
            private set 
            {
                this.bag = value;
            }
        }

        public string BuyProduct(Product product) 
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.bag.Add(product);

            return $"{this.Name} bought {product.Name}";
        }
    }
}
