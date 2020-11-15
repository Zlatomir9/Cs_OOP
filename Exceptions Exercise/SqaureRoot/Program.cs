using System;

namespace SqaureRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new NotFiniteNumberException("Number must be positive");
                }
                double result = Math.Sqrt(n);

                Console.WriteLine(result);
            }
            catch (NotFiniteNumberException fne)
            {
                Console.WriteLine(fne.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
