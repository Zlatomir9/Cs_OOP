namespace Vehicle.Models
{
    public class Bus : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity, bool workingAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, workingAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumption => DefaultAirConditionerFuelConsumption;
    }
}
