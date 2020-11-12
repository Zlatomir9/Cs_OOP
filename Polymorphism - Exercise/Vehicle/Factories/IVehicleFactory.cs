namespace Vehicle.Factories
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity, bool workingAirConditioner = true);
    }
}
