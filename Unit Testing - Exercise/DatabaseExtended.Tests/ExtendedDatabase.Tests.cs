using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorEmptyCollectionShouldReturnCountZero() 
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void ConstructorMoreThan16PeopleShouldThrowException()
        {
            Person[] people = new Person[17];
            
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void AddingUserShouldIncreaseCount()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(new Person(1, "a" ));

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddingPersonShouldBeCorectly() 
        {
            Person expectedResult = new Person(1, "a");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(expectedResult);

            Person actualResult = database.FindById(1);

            Assert.AreEqual(1, actualResult.Id);
            Assert.AreEqual("a", actualResult.UserName);
        }

        [Test]
        public void AddingMoreThan16PeopleShouldThrowException()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                people[i] = new Person(i + 1, $"a{i}");
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(20, "B")));
        }

        [Test]
        public void AddingExistingPersonUsernameShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "a"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(11, "a")));
        }

        [Test]
        public void AddingExistingPersonWithSameIDShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "a"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "aa")));
        }

        [Test]
        public void AddingPersonShouldIncreaseCount() 
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            
            database.Add(new Person(1, "a"));

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddingPersonShouldAddedCorrectly()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            Person person1 = new Person(1, "a");
            Person person2 = new Person(2, "b");
            Person person3 = new Person(3, "c");

            database.Add(person1);
            database.Add(person2);
            database.Add(person3);

            Person actualPerson = database.FindById(2);

            Assert.AreEqual(2, actualPerson.Id);
            Assert.AreEqual("b", actualPerson.UserName);
        }

        [Test]
        public void RemoveFromEmptyCollectionShouldThrowException() 
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveFromCollectionShouldDecreaseCount()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            database.Add(new Person(1, "a"));
            database.Remove();

            int expectedResult = 0;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameEmptyShouldThrowException(string username) 
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameInEmptyCollectionShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("A"));
        }

        [Test]
        public void FindNonExistingUsernameInCollectionShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("B"));
        }

        [Test]
        public void FindExistingUsernameInCollectionShouldReturnCorrectPerson()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "A"));

            Person actualPerson = database.FindByUsername("A");

            Assert.AreEqual(1, actualPerson.Id);
            Assert.AreEqual("A", actualPerson.UserName);
        }

        [Test]
        public void FindWithNegativeIDShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-100));
        }

        [Test]
        public void FindByIdInEmptyCollectionShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }

        [Test]
        public void FindNonExistingIdInCollectionShouldThrowException()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }

        [Test]
        public void FindExistingIdInCollectionShouldReturnCorrectPerson()
        {
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "A"));

            Person actualPerson = database.FindById(1);

            Assert.AreEqual(1, actualPerson.Id);
            Assert.AreEqual("A", actualPerson.UserName);
        }
    }
}