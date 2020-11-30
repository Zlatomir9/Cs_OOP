using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
              .Info
                .WithType("BMW")
                .WithColor("Blue")
                .WithNumberOfDoors(3)
              .Built
                .InCity("Munich")
                .AtAddress("BMW HeadQuaters")
              .Build();

            Console.WriteLine(car);
        }
    }
}
