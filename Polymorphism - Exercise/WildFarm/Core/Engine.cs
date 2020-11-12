using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Factories;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new HashSet<Animal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = animalData[0];
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                string[] args = animalData.Skip(3).ToArray();

                Animal animal = null;

                try
                {
                    animal = this.animalFactory.Create(type, name, weight, args);
                    this.animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string foodType = foodArgs[0];
                int foodQunatity = int.Parse(foodArgs[1]);

                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQunatity);

                    animal?.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (Animal currAnimal in this.animals)
            {
                Console.WriteLine(currAnimal);
            }
        }
    }
}
