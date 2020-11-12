using System;
using Vehicle.Utilities;

namespace Vehicle
{
    public class Truck : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumption = 1.6;
        private const double RefuelCapacity = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity, bool workingAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, workingAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumption => DefaultAirConditionerFuelConsumption;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeFuelAmount);
            }
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                string msg = string.Format(ExceptionMessages.InvalidFuelAmount, liters);
                throw new ArgumentException(msg);
            }

            base.Refuel(liters * RefuelCapacity);
        }
    }
}
