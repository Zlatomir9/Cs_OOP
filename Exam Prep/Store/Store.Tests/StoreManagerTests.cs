using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddProductShouldThrowExceptions()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("Test", 0, 10);
            Product product2 = new Product("Test", -100, 10);

            Assert.Throws<ArgumentNullException>(() => storeManager.AddProduct(null));
            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(product));
            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(product2));
        }

        [Test]
        public void AddProductShouldWork()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("Test", 10, 10);
            Product product2 = new Product("Test2", 50, 10);
            storeManager.AddProduct(product);
            storeManager.AddProduct(product2);

            Assert.AreEqual(2, storeManager.Count);
            Assert.AreEqual(2, storeManager.Products.Count);
        }

        [Test]
        public void BuyProductShouldThrowExceptions()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("Test", 10, 10);
            storeManager.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() => storeManager.BuyProduct(null, 10));
            Assert.Throws<ArgumentException>(() => storeManager.BuyProduct("Test", 100));
        }

        [Test]
        public void BuyProductShouldWork()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("Test", 100, 10);
            storeManager.AddProduct(product);
            storeManager.BuyProduct("Test", 10);

            var expectedPrice = 100;
            var expctedQuantity = 90;

            Assert.AreEqual(expectedPrice, product.Price * 10);
            Assert.AreEqual(expctedQuantity, product.Quantity);
        }

        [Test]
        public void GetMostExpensiveProductShouldWork()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("Test", 100, 100);
            Product product2 = new Product("Test", 1000, 1);
            Product product3 = new Product("Test", 5, 1000);
            Product product4 = new Product("Test", 9000, 9000);
            storeManager.AddProduct(product);
            storeManager.AddProduct(product2);
            storeManager.AddProduct(product3);
            storeManager.AddProduct(product4);

            Assert.AreEqual(product4, storeManager.GetTheMostExpensiveProduct());
        }
    }
}