using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] input = Console.ReadLine().Split(';');
                foreach (string person in input)
                {
                    string[] currPerson = person.Split('=');
                    string personName = currPerson[0];
                    decimal personMoney = decimal.Parse(currPerson[1]);

                    Person per = new Person(personName, personMoney);
                    people.Add(per);
                }

                string[] productsInput = Console.ReadLine().Split(';');
                foreach (string product in productsInput)
                {
                    string[] currProduct = product.Split('=');
                    string productName = currProduct[0];
                    decimal productCost = decimal.Parse(currProduct[1]);

                    Product prod = new Product(productName, productCost);
                    products.Add(prod);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] tokens = command.Split(' ').ToArray();

                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person person = people.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        Console.WriteLine(person.BuyProduct(product));
                    }

                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if (person.Bag.Count > 0)
                    {
                        Console.Write($"{person.Name} - ");
                        Console.Write(String.Join(", ", person.Bag));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    } 
}
