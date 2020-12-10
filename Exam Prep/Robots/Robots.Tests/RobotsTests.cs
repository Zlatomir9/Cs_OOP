namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Test", 10);
            robotManager = new RobotManager(10);
        }

        [Test]
        public void WhenRobotIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("Test", robot.Name);
            Assert.AreEqual(10, robot.Battery);
            Assert.AreEqual(10, robot.MaximumBattery);
        }

        [Test]
        public void WhenRobotManagerIsCreated_CapacityShouldBeSet()
        {
            Assert.AreEqual(10, robotManager.Capacity);
        }

        [Test]
        public void WhenRobotManagerIsNegative_CapacityExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentException>(() => 
            { 
                RobotManager roboManager = new RobotManager(-5); 
            });
        }

        [Test]
        public void WhenRobotManagerIsCreated_CountShouldBeZero()
        {
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void WhenAddSameRobots_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() => 
            { 
                robotManager.Add(robot); 
                robotManager.Add(robot); 
            });
        }

        [Test]
        public void WhenAddWithoutCapacity_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager rb = new RobotManager(1);
                rb.Add(robot);
                rb.Add(new Robot("Test 123", 15));
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager rb = new RobotManager(0);
                rb.Add(robot);
            });
        }

        [Test]
        public void WhenAddWithCorrectData_ShouldWork()
        {
            robotManager.Add(robot);
            Assert.AreEqual(1, robotManager.Count);
            robotManager.Add(new Robot("Test2", 20));
            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void WhenRemoveNotExistingRobot_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("12");
            });
        }

        [Test]
        public void WhenRemoveExistingRobot_ShouldWork()
        {
            robotManager.Add(new Robot("Testttt", 20));
            robotManager.Remove("Testttt");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void WhenWorkNotExistingRobot_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("12", "", 5);
            });
        }

        [Test]
        public void WhenWorkNotChargedRobot_ExceptionShouldBeThrown()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robot.Name, "gj", 1000);
            });
        }

        [Test]
        public void WhenWorkChargedRobot_ShouldDecreaseBattery()
        {
            robotManager.Add(robot);

            robotManager.Work(robot.Name, "gj", 5);

            Assert.AreEqual(robot.Battery, 5);
        }

        [Test]
        public void WhenChargeNotExistingRobot_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("");
            });
        }

        [Test]
        public void WhenChargedRobot_ShouldIncreaseBattery()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "gj", 5);
            robotManager.Charge(robot.Name);
            Assert.AreEqual(robot.Battery, 10);
        }
    }
}
