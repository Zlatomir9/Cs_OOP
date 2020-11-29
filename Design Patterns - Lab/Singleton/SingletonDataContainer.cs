using System;
using System.Collections.Generic;
using System.IO;

namespace Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i++)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        public static SingletonDataContainer Instance => instance;
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
