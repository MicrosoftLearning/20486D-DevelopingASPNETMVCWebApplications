using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using ShirtStoreWebsite.Controllers;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using ShirtStoreWebsite.Tests.FakeRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace ShirtStoreWebsite.Tests
{
    [TestClass]
    public class ShirtControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllShirts()
        {
            IShirtRepository fakeShirtRepository = new FakeShirtRepository();
            Mock<ILogger<ShirtController>> mockLogger = new Mock<ILogger<ShirtController>>();
            ShirtController shirtController = new ShirtController(fakeShirtRepository, mockLogger.Object);
            ViewResult viewResult = shirtController.Index() as ViewResult;
            List<Shirt> shirts = viewResult.Model as List<Shirt>;
            Assert.AreEqual(shirts.Count, 3);
        }
    }
}
