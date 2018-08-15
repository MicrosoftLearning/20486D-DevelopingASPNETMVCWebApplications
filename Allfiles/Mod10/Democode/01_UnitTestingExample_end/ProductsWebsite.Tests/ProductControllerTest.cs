using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsWebsite.Controllers;
using ProductsWebsite.Models;
using ProductsWebsite.Repositories;
using ProductsWebsite.Tests.Mock;

namespace ProductsWebsite.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IsIndexReturnsAllProducts()
        {
            // arrange
            IProductRepository fakeProductRepository = new FakeProductRepository();
            ProductController productController = new ProductController(fakeProductRepository);
            // act
            ViewResult viewResult = productController.Index() as ViewResult;
            List<Product> products = viewResult.Model as List<Product>;
            // assert
            Assert.AreEqual(products.Count, 3);
        }

        [TestMethod]
        public void IsGetProductReturnsTheCorrectProduct()
        {
            // arrange
            var fakeProductRepository = new FakeProductRepository();
            var productController = new ProductController(fakeProductRepository);
            // act
            var viewResult = productController.GetProduct(2) as ViewResult;
            Product product = viewResult.Model as Product;
            // assert
            Assert.AreEqual(product.Id, 2);
        }
    }
}
