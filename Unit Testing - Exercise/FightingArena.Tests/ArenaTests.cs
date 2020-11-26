using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Pesho", 5, 50);
            this.attacker = new Warrior("Gosho", 10, 80);
            this.defender = new Warrior("Ivan", 5, 60);
        }

        [Test]
        public void TestIfConstructorWorksCorectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldPhysicalyAddWarriorToArena()
        {
            this.arena.Enroll(this.warrior);

            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(new Warrior("Ivan", 5, 60));

            int expectedCount = 2;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollSameWarriorShouldThrowException()
        {
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void EnrollTwoWarriorsWithSameNameShouldThrowException()
        {
            Warrior warriorCopy = new Warrior(warrior.Name, warrior.Damage, warrior.HP);

            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warriorCopy);
            });
        }

        [Test]
        public void TestFightingWithMissingAttacker()
        {
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }

        [Test]
        public void TestFightingWithMissingDefender()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }

        [Test]
        public void TestFightingBetweenTwoWarrior()
        {
            int expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            int expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            this.arena.Fight(this.attacker.Name, this.defender.Name);

            Assert.AreEqual(expectedAttackerHP, this.attacker.HP);
            Assert.AreEqual(expectedDefenderHP, this.defender.HP);
        }
    }
}
