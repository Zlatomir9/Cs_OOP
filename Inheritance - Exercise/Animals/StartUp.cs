using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            
            List<Animal> animals = new List<Animal>();

            while (type != "Beast!")
            {
                string input = Console.ReadLine();
                string[] splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = splitted[0];
                int age = int.Parse(splitted[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    type = Console.ReadLine();
                    continue;
                }

                if (type == "Dog")
                {
                    string gender = splitted[2];
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (type == "Cat")
                {
                    string gender = splitted[2];
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (type == "Frog")
                {
                    string gender = splitted[2];
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (type == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }
                else if (type == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }

                type = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                string animalType = animal.GetType().ToString();
                Console.WriteLine(animalType.Remove(0, 8));
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
