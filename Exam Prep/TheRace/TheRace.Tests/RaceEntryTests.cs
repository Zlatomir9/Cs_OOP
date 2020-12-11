using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverExists()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Pesho", new UnitCar("", 1, 1));
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldWork()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Pesho", new UnitCar("", 1, 1));
            var result = raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);
            Assert.AreEqual("Driver Pesho added in race.", result);
        }

        [Test]
        public void CalculateHPShouldThrowExceptionWhenParticipantsAreNotEnough()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Pesho", new UnitCar("", 1, 1));

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateHPShouldWork()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Pesho", new UnitCar("", 10, 1));
            UnitDriver driver2 = new UnitDriver("Gosho", new UnitCar("", 10, 1));
            UnitDriver driver3 = new UnitDriver("Strahil", new UnitCar("", 10, 1));
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);

            Assert.AreEqual(10, raceEntry.CalculateAverageHorsePower());
        }
    }
}