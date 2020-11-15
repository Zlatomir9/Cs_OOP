using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int number;
            List<int> numbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    number = ReadNumber(start, end);

                    if (number <= start || number >= end)
                    {
                        throw new ArgumentOutOfRangeException("Number is outside the bounds");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Number is not valid");
                    numbers.Clear();
                    i = -1;
                    Console.WriteLine("Enter 10 numbers again");
                    start = 1;
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Number must be bigger than {start} and smaller than {end}!");
                    numbers.Clear();
                    i = -1;
                    Console.WriteLine("Enter 10 numbers again");
                    start = 1;
                    continue;
                }

                start = number;
                numbers.Add(number);
            }

            Console.Write("The numbers are: ");
            Console.Write(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int num))
            {
                throw new FormatException();
            }

            return num;
        }
    }
}
