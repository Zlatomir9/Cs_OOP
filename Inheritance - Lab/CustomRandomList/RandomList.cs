using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rand = new Random();
        public string RandomString() 
        {
            int index = rand.Next(0, this.Count);
            string removedElement = this[index];
            RemoveAt(index);
            return removedElement;
        }
    }
}
