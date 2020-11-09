using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IPet> personsAndPets = new List<IPet>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split();

                string type = inputInfo[0];
                string name = inputInfo[1];

                if (type == "Citizen")
                {
                    Citizen citizen = new Citizen(name, int.Parse(inputInfo[2]), inputInfo[3], inputInfo[4]);
                    personsAndPets.Add(citizen);
                }
                else if (type == "Pet")
                {
                    Pet pet = new Pet(name, inputInfo[2]);
                    personsAndPets.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var current in personsAndPets)
            {
                if (current.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(current.Birthdate);
                }
            }
        }
    }
}
