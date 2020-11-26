using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCOrectly()
        {
            string expectedName = "Gosho";
            int expectedDamage = 50;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void TestWithLikeNullName()
        {
            string name = null;
            int damage = 50;
            int HP = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            string name = string.Empty;
            int damage = 50;
            int HP = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void TestWithLikeWhitespaceName()
        {
            string name = " ";
            int damage = 50;
            int HP = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void TestWithZeroDamage()
        {
            string name = "Gosho";
            int damage = 0;
            int HP = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void TestWithNegativeDamage()
        {
            string name = "Gosho";
            int damage = -20;
            int HP = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void TestWithNegativeHP()
        {
            string name = "Gosho";
            int damage = 50;
            int HP = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhenLowHPShouldThrowException(int attackerHP)
        {
            string attackerName = "Gosho";
            int attackerDamage = 10;

            string defenderName = "Pesho";
            int defenderDamage = 10;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() => 
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWithLowHPShouldThrowException(int defenderHP)
        {
            string attackerName = "Gosho";
            int attackerDamage = 10;
            int attackerHP = 100;

            string defenderName = "Pesho";
            int defenderDamage = 10;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingStrongerEnemyShouldThrowException()
        {
            string attackerName = "Gosho";
            int attackerDamage = 10;
            int attackerHP = 35;

            string defenderName = "Pesho";
            int defenderDamage = 50;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingShouldDecreaseHPWhenSuccessfull()
        {
            string attackerName = "Gosho";
            int attackerDamage = 10;
            int attackerHP = 40;

            string defenderName = "Pesho";
            int defenderDamage = 5;
            int defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDamage;
            int expecedDefenderHP = defenderHP - attackerDamage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expecedDefenderHP, defender.HP);
        }

        [Test]

        public void KillingEnemyWithAttack() 
        {
            string attackerName = "Gosho";
            int attackerDamage = 80;
            int attackerHP = 100;

            string defenderName = "Pesho";
            int defenderDamage = 5;
            int defenderHP = 60;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDamage;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}