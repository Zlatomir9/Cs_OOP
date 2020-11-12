using System;
using Vehicle.Factories;
using Vehicle.IO;
using Vehicle.Models;

namespace Vehicle.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }
        public void Run()
        {
            string[] carData = this.reader.CustomReadLine().Split();
            IVehicle car = CreateVehicle(carData);

            string[] truckData = this.reader.CustomReadLine().Split();
            IVehicle truck = CreateVehicle(truckData);

            string[] busData = this.reader.CustomReadLine().Split();
            IVehicle bus = CreateVehicle(busData);

            int n = int.Parse(this.reader.CustomReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = this.reader.CustomReadLine().Split();
                string command = args[0];
                string vehicleType = args[1];
                double argument = double.Parse(args[2]);

                try
                {
                    if (command == "Drive")
                    {
                        this.DriveCommand(vehicleType, car, truck, bus, argument);
                    }
                    else if (command == "DriveEmpty")
                    {
                        this.DriveEmptyCommand(bus, argument);
                    }
                    else if (command == "Refuel")
                    {
                        this.RefuelCommand(vehicleType, car, truck, bus, argument);
                    }
                }
                catch (ArgumentException msg)
                {
                    this.writer.CustomWriteLine(msg.Message);
                }
            }

            this.writer.CustomWriteLine(car.ToString());
            this.writer.CustomWriteLine(truck.ToString());
            this.writer.CustomWriteLine(bus.ToString());
        }

        private void DriveEmptyCommand(IVehicle bus, double argument)
        {
            bus.StopAirConditioner();
            bool isDriven = bus.Drive(argument);
            
            if (isDriven)
            {
                this.writer.CustomWriteLine($"Bus travelled {argument} km");
            }
            else
            {
                this.writer.CustomWriteLine($"Bus needs refueling");
            }
        }

        private void RefuelCommand(string vehicleType, IVehicle car, IVehicle truck, IVehicle bus, double argument)
        {
            if (vehicleType == nameof(Car))
            {
                car.Refuel(argument);
            }
            else if (vehicleType == nameof(Truck))
            {
                truck.Refuel(argument);
            }
            else if (vehicleType == nameof(Bus))
            {
                bus.Refuel(argument);
            }
        }

        private IVehicle CreateVehicle(string[] data) 
        {
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);
            IVehicle vehicle = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }
        private void DriveCommand(string vehicleType, IVehicle car, IVehicle truck, IVehicle bus, double argument) 
        {
            bool isDriven = false;
            if (vehicleType == nameof(Car))
            {
                isDriven = car.Drive(argument);
            }
            else if (vehicleType == nameof(Truck))
            {
                isDriven = truck.Drive(argument);
            }
            else if (vehicleType == nameof(Bus))
            {
                bus.StartAirConditioner();
                isDriven = bus.Drive(argument);
            }

            if (isDriven)
            {
                this.writer.CustomWriteLine($"{vehicleType} travelled {argument} km");
            }
            else
            {
                this.writer.CustomWriteLine($"{vehicleType} needs refueling");
            }
        }
    }
}
