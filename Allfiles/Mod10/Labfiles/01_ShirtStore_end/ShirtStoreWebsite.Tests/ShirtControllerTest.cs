using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using ShirtStoreWebsite.Controllers;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using ShirtStoreWebsite.Tests.Mock;

namespace ShirtStoreWebsite.Tests
{
    [TestClass]
    class ShirtControllerTest
    {
        [TestMethod]
        public void IsIndexReturnsAllShirts()
        {
            IShirtRepository fakeShirtRepository = new FakeShirtRepository();
            ShirtController shirtController = new ShirtController(fakeShirtRepository);
            ViewResult viewResult = shirtController.Index() as ViewResult;
            List<Shirt> products = viewResult.Model as List<Shirt>;
            Assert.AreEqual(products.Count, 3);
        }
    }
}
