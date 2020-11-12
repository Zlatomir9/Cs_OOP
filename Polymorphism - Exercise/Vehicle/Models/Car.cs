namespace Vehicle
{
    public class Car : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity, bool workingAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, workingAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumption => DefaultAirConditionerFuelConsumption;
    }
}
