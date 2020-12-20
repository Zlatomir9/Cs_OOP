using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddItemShouldThrowExceptionWhenNoSuchCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("1213", item));            
        }

        [Test]
        public void AddItemShouldThrowExceptionWhenCellIsFull()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");
            Item item2 = new Item("Test2", "3");

            bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item2));
        }

        [Test]
        public void AddItemShouldThrowExceptionWhenItemIsAlreadyInCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");
            Item item2 = new Item("Test2", "2");

            bankVault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("C3", item2));
        }

        [Test]
        public void AddItemShouldWorkAsExpected()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");
            Item item2 = new Item("Test2", "10");

            bankVault.AddItem("A1", item);
            bankVault.AddItem("B1", item2);

            Assert.AreEqual(item.ItemId, bankVault.VaultCells["A1"].ItemId);
            Assert.AreEqual(item2.ItemId, bankVault.VaultCells["B1"].ItemId);
            Assert.AreEqual(item.Owner, bankVault.VaultCells["A1"].Owner);
            Assert.AreEqual(item2.Owner, bankVault.VaultCells["B1"].Owner);
        }

        [Test]
        public void RemoveItemShouldThrowExceptionWhenNoSuchCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("1213", item));
        }

        [Test]
        public void RemoveItemShouldThrowExceptionWhenItemIsDiferrent()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");
            Item item2 = new Item("Test2", "3");

            bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item2));
        }

        [Test]
        public void RemoveItemShouldWorkAsExpected()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "2");
            Item item2 = new Item("Test2", "10");

            bankVault.AddItem("A1", item);
            bankVault.AddItem("B1", item2);
            bankVault.RemoveItem("A1", item);
            bankVault.RemoveItem("B1", item2);

            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
            Assert.AreEqual(null, bankVault.VaultCells["B1"]);
        }
    }
}