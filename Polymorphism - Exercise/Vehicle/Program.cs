using Vehicle.Core;
using Vehicle.Factories;
using Vehicle.IO;

namespace Vehicle
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            IEngine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
