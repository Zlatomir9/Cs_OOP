using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The first name cannot be null or empty.");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The last name cannot be null or empty.");
                }
                this.lastName = value;
            }
        }
        public int Age 
        {
            get
            {
                return this.age;
            }
            set 
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age should be in the range [0 ... 120].");
                }
            } 
        }
    }
}
