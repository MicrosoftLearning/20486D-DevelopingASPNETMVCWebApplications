using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsWebsite.Controllers;
using ProductsWebsite.Models;
using ProductsWebsite.Repositories;
using ProductsWebsite.Tests.FakeRepositories;

namespace ProductsWebsite.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllProducts()
        {
            // Arrange
            IProductRepository fakeProductRepository = new FakeProductRepository();
            ProductController productController = new ProductController(fakeProductRepository);
            // Act
            ViewResult viewResult = productController.Index() as ViewResult;
            List<Product> products = viewResult.Model as List<Product>;
            // Assert
            Assert.AreEqual(products.Count, 3);
        }

        [TestMethod]
        public void GetProductModelShouldContainTheRightProduct()
        {
            // Arrange
            var fakeProductRepository = new FakeProductRepository();
            var productController = new ProductController(fakeProductRepository);
            // Act
            var viewResult = productController.GetProduct(2) as ViewResult;
            Product product = viewResult.Model as Product;
            // Assert
            Assert.AreEqual(product.Id, 2);
        }
    }
}
