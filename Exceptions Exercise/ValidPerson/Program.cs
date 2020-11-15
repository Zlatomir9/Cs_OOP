using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
           
                Person person = new Person("Pesho", "Peshev", 24);
            try
            {
                Person noName = new Person(string.Empty, "Goshev", 31);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}", ane.Message);
            }
            try
            {
                Person noLastName = new Person("Ivan", null, 50);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}", ane.Message);
            }
            try
            {
                Person negativeAge = new Person("Peter", "Georgiev", -10);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("Exception thrown: {0}", aore.Message);
            }
            try 
            { 
                Person tooBigAge = new Person("Stoyan", "Stefanov", 130);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("Exception thrown: {0}", aore.Message);
            }
        }
    }
}
