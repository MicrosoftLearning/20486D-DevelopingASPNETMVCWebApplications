using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Tests
{
    [TestClass]
    public class ShirtTest
    {
        [TestMethod]
        public void IsGetFormattedTaxedPriceReturnsCorrectly()
        {
            Shirt shirt = new Shirt
            {
                Price = 10F
            };

            string taxedPrice = shirt.GetFormattedTaxedPrice(1.2F);

            Assert.AreEqual(12F, taxedPrice);
        }
    }
}
