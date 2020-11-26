using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string make = "BMW";
            string model = "M3";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(null, "M3", 10, 100)]
        [TestCase("BMW", null, 10, 100)]
        [TestCase("BMW", "M3", -10, 100)]
        [TestCase("BMW", "M3", 0, 100)]
        [TestCase("BMW", "M3", 10, -100)]
        [TestCase("BMW", "M3", 10, 0)]
        public void AllPropertiesShouldThrowExceptionForInvalidValues
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "BMW";
            string model = "M3";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            double expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void ShouldRefuelUntilTheTotalFuelCapacity()
        {
            string make = "BMW";
            string model = "M3";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(150);

            double expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExceptionWhenInputAmountIsNegative(double inputAmount)
        {
            string make = "BMW";
            string model = "M3";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            string make = "BMW";
            string model = "M3";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmout = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmout);
        }

        [Test]
        public void DriveShouldThrowExceptionWhenFuelAmountIsBelowZero()
        {
            string make = "BMW";
            string model = "M3";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}