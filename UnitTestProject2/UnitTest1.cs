using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PostiveTest()
        {
            int expectedQty = 20;
            //Arrange
            InventoryPurchase invPurchase = new InventoryPurchase() { inventory = 100 };
            //Act
            int actualQty = invPurchase.Purchase(expectedQty);
            //Assert
            Assert.AreEqual(expectedQty, actualQty);
        }
        [TestMethod]
        [ExpectedException(typeof(OutOfProduct),"An out of product.")]
        public void NegativeTest()
        {
            int expectedQty = 20;
            //Arrange
            InventoryPurchase invPurchase = new InventoryPurchase() { inventory = 0};
            //Act
            int actualQty = invPurchase.Purchase(expectedQty);
        }
    }
}
