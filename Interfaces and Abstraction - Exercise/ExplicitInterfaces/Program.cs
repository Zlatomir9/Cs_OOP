using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputTokens = input.Split();
                string name = inputTokens[0];
                string country = inputTokens[1];
                int age = int.Parse(inputTokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
