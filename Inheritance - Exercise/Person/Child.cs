using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) 
            : base(name, age)
        {

        }

        public override int Age
        {
            get 
            { 
                return base.Age; 
            }
            set
            {
                if (value > 15)
                {
                    throw new AggregateException("Child can't be older than 15!");
                }
                base.Age = value;
            }
        }
    }
}
