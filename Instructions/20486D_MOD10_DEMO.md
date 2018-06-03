# Module 10: Testing and Troubleshooting

# Lesson 1: Testing MVC Applications

### Demonstration: How to Run Unit Tests

#### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod10\Democode\10_UnitTestingExample_begin**, and then double-click **UnitTestingExample.sln**.

#### Demonstration Steps

1. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **Solution 'UnitTestingExample'**, point to **Add**, and then click **New Project**.

2. In the **Add New Project** dialog box, click **MVC Controller - Empty**, and then click **Add**.

3. In the navigation pane of the **Add New Project** dialog box, expand **Installed**, expand **Visual C#**, and then click **.NET Core**.

4. In the result pane of the **Add New Project** dialog box, click **MSTest Test Project (.NET Core)**.

5. In the **Add New Project** dialog box, in the **Name** text box, type **ProductsWebsite.Tests**, and then click **OK**.

6. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, under **ProductsWebsite.Tests**, right-click **Dependencies**, and then click **Add Reference**.

7. In the navigation pane of the **Reference Manager - ProductsWebsite.Tests** dialog box, expand **Projects**, and then click **Solution**.

8. In the result pane of the **Reference Manager - ProductsWebsite.Tests** dialog box, check **UnitTestingExample**, and then click **OK**.

9. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, under **ProductsWebsite.Tests**, right-click **UnitTest1**, and then click **Rename**.

10. In the **UnitTest1.cs** text box, type **ProductControllerTest**, and then press Enter.

11. In the **Microsoft Visual Studio** dialog box, click Yes.

12. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **ProductsWebsite.Tests**, point to **Add**, and then click **New Folder**.

13. In the **NewFolder** text box, type **Mock**, and then press Enter.

14. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click the **Mock** folder, point to **Add**, and then click **Class**.

15. In the **Add New item - ProductsWebsite.Tests** dialog box, in the **Name** text box, type **FakeProductRepository**, and then click **Add**.

16. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    using System.Text;
```

17. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using UnitTestingExample.Repositories;
    using UnitTestingExample.Models;
```

18. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    class FakeProductRepository
```

19. Replace the selected code with the following code:
```cs
    internal class FakeProductRepository : IProductRepository
```

20. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    internal class FakeProductRepository : IProductRepository
    {
```

21. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    public IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new Product{ Id = 1, Name = "Product1's name", BasePrice = 1.1F, Description = "A description for product 1."},
            new Product{ Id = 2, Name = "Product2's name", BasePrice = 2.2F, Description = "A description for product 2."},
            new Product{ Id = 3, Name = "Product3's name", BasePrice = 3.3F, Description = "A description for product 3."}
        };
    }
```

22. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    using Microsoft.VisualStudio.TestTools.UnitTesting;
```

23. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using UnitTestingExample.Controllers;
    using UnitTestingExample.Models;
    using UnitTestingExample.Repositories;
```

24. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    public void TestMethod1()
    {
    }
```

25. Replace the selected code with the following code:
```cs
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
```

26. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
        Assert.AreEqual(products.Count, 3);
    }
```

27. Ensure that the cursor is at the end of the located code, press Enter twice, and then type the following code:
```cs
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
```

28. In the **UnitTestingExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

29. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.
    >**Note:** The **Test Explorer** displays 1 Failed Test: IsGetProductReturnsTheCorrectProduct, and 1 Passed Test: IsIndexReturnsAllProducts.

30. In the **ProductController.cs** code window, locate the following code:
```cs
    var product = products.Where(p => p.Id != id).FirstOrDefault();
```

31. Replace the selected code with the following code:
```cs
    var product = products.Where(p => p.Id == id).FirstOrDefault();
```

32. In the **UnitTestingExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

33. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.
    >**Note:** The **Test Explorer** displays 2 Passed Tests: IsGetProductReturnsTheCorrectProduct and IsIndexReturnsAllProducts.

34. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Handling Exceptions

### Demonstration: How to Add Routes
#### Preparation Steps