using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddComputerShouldThrowException()
        {
            ComputerManager computerManager = new ComputerManager();

            Computer computer = new Computer("Test", "Test", 123);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputerShouldWorkAsExpected()
        {
            ComputerManager computerManager = new ComputerManager();

            Computer computer = new Computer("Test", "Test", 123);
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Count);
            Assert.AreEqual(1, computerManager.Computers.Count);
            Assert.AreEqual(computer, computerManager.GetComputer("Test", "Test"));
        }

        [Test]
        public void RemoveComputerShouldWorkAsExpected()
        {
            ComputerManager computerManager = new ComputerManager();

            Computer computer = new Computer("Test", "Test", 123);
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);
            Assert.AreEqual(0, computerManager.Count);
            Assert.AreEqual(0, computerManager.Computers.Count);
        }

        [Test]
        public void RemoveComputerShouldThrowException()
        {
            ComputerManager computerManager = new ComputerManager();

            Computer computer = new Computer("Test", "Test", 123);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "Test"));
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("Test", null));
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("wow", "haha"));
        }

        [Test]
        public void GetComputerComputerShouldThrowException()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("test", null));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "test"));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Test", "test"));
        }

        [Test]
        public void GetComputerComputerShouldWork()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Test", "Test", 100);
            computerManager.AddComputer(computer);

            var computerFromManager = computerManager.GetComputer("Test", "Test");

            Assert.AreEqual(computer, computerFromManager);
        }

        [Test]
        public void GetComputersByManufacturerShouldWork()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Test", "Test", 100);
            Computer computer2 = new Computer("Test", "Test1", 100);
            Computer computer3 = new Computer("No", "No", 100);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            var computerFromManager = computerManager.GetComputersByManufacturer("Test");

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));

            CollectionAssert.Contains(computerFromManager, computer);
            CollectionAssert.Contains(computerFromManager, computer2);
            CollectionAssert.DoesNotContain(computerFromManager, computer3);
        }
    }
}