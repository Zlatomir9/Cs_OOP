using System;
using Vehicle.Utilities;

namespace Vehicle
{
    public abstract class Vehicle : IVehicle
    {
        private const double DefaultFuelQuantity = 0;
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, bool workingAirConditioner = true)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.WorkingAirConditioner = workingAirConditioner;
        }

        public double FuelQuantity 
        {
            get 
            {
                return this.fuelQuantity;
            }
            protected set 
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = DefaultFuelQuantity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            } 
        }

        public double FuelConsumption { get; }

        public bool WorkingAirConditioner { get; private set; }

        public abstract double AirConditionerFuelConsumption { get; }

        public double TankCapacity { get; }

        public void StartAirConditioner()
        {
            this.WorkingAirConditioner = true;
        }

        public bool Drive(double distance)
        {
            double consumedFuel = this.FuelConsumption * distance;
            if (this.WorkingAirConditioner)
            {
                consumedFuel += this.AirConditionerFuelConsumption * distance;
            }
            if (this.FuelQuantity < consumedFuel)
            {
                return false;
            }

            this.FuelQuantity -= consumedFuel;
            return true;
        }

        public virtual void Refuel(double liters)
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

            this.FuelQuantity += liters;
        }

        public void StopAirConditioner()
        {
            this.WorkingAirConditioner = false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}"; 
        }
    }
}
