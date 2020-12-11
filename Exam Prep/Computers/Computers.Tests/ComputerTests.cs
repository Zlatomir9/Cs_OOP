namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerNameNullShouldThrowExc()
        {
            Computer computer;
            Assert.Throws<ArgumentNullException>(() => computer = new Computer(null));
        }

        [Test]
        public void ComputerNameWhiteSpaceShouldThrowExc()
        {
            Computer computer;
            Assert.Throws<ArgumentNullException>(() => computer = new Computer(" "));
        }

        [Test]
        public void ComputerNameShouldWork()
        {
            Computer computer = new Computer("NASA");
            Assert.AreEqual("NASA", computer.Name);
        }

        [Test]
        public void AddPartNullShouldThrowExc()
        {
            Part part = null;
            Computer computer = new Computer("NASA");
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(part));
        }

        [Test]
        public void AddPartShouldWork()
        {
            Part part = new Part("keyboard", 100);
            Computer computer = new Computer("NASA");
            computer.AddPart(part);
            Assert.AreEqual("keyboard", part.Name);
            Assert.AreEqual(100, part.Price);
        }

        [Test]
        public void RemovePartShouldWork()
        {
            Part part = new Part("keyboard", 100);
            Computer computer = new Computer("NASA");
            computer.AddPart(part);
            computer.RemovePart(part);
            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void RemovePartShouldNotRemove()
        {
            Part part = new Part("keyboard", 100);
            Computer computer = new Computer("NASA");
            Part part1 = new Part("mouse", 50);
            computer.AddPart(part);
            computer.RemovePart(part1);
            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        public void GetPartPartShouldWork()
        {
            Part part = new Part("keyboard", 100);
            Computer computer = new Computer("NASA");
            computer.AddPart(part);

            string partName = "keyboard";
            var result = computer.GetPart(partName);

            Assert.AreEqual(part, result);
        }

        [Test]
        public void TotalPriceShouldWork()
        {
            Part part = new Part("keyboard", 100);
            Part part1 = new Part("mouse", 50);
            Computer computer = new Computer("NASA");
            computer.AddPart(part);
            computer.AddPart(part1);

            var result = computer.TotalPrice;

            Assert.AreEqual(150, result);
        }
    }
}