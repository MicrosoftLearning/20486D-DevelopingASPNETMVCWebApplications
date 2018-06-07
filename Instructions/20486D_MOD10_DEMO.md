
# Module 10: Testing and Troubleshooting

# Lesson 1: Testing MVC Applications

### Demonstration: How to Run Unit Tests

#### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **Allfiles\Mod10\Democode\01_UnitTestingExample_begin**, and then double-click **UnitTestingExample.sln**.

#### Demonstration Steps

1. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **Solution 'UnitTestingExample'**, point to **Add**, and then click **New Project**.

2. In the **Add New Project** dialog box, in the navigation pane, expand **Installed**, expand **Visual C#**, and then click **.NET Core**.

3. In the **Add New Project** dialog box, in the result pane, click **MSTest Test Project (.NET Core)**.

4. In the **Add New Project** dialog box, in the **Name** text box, type **ProductsWebsite.Tests**, and then click **OK**.

5. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, under **ProductsWebsite.Tests**, right-click **Dependencies**, and then click **Add Reference**.

6. In the **Reference Manager - ProductsWebsite.Tests** dialog box, in the navigation pane, expand **Projects**, and then click **Solution**.

7. In the **Reference Manager - ProductsWebsite.Tests** dialog box, in the result pane, mark the **ProductsWebsite** check box, and then click **OK**.

8. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, under **ProductsWebsite.Tests**, right-click **UnitTest1**, and then click **Rename**.

9. In the **UnitTest1.cs** text box, type **ProductControllerTest**, and then press Enter.

10. In the **Microsoft Visual Studio** dialog box, click Yes.

11. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **ProductsWebsite.Tests**, point to **Add**, and then click **New Folder**.

12. In the **NewFolder** text box, type **Mock**, and then press Enter.

13. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click the **Mock** folder, point to **Add**, and then click **Class**.

14. In the **Add New Item - ProductsWebsite.Tests** dialog box, in the **Name** text box, type **FakeProductRepository**, and then click **Add**.

15. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    using System.Text;
```

16. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ProductsWebsite.Repositories;
    using ProductsWebsite.Models;
```

17. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    class FakeProductRepository
```

18. Replace the selected code with the following code:
```cs
    internal class FakeProductRepository : IProductRepository
```

19. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    internal class FakeProductRepository : IProductRepository
    {
```

20. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
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

21. In the **ProductControllerTest.cs** code window, locate the following code:
```cs
    using Microsoft.VisualStudio.TestTools.UnitTesting;
```

22. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using ProductsWebsite.Controllers;
    using ProductsWebsite.Models;
    using ProductsWebsite.Repositories;
    using ProductsWebsite.Tests.Mock;
```

23. In the **ProductControllerTest.cs** code window, locate the following code:
```cs
    public void TestMethod1()
    {
    }
```

24. Replace the selected code with the following code:
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

25. In the **ProductControllerTest.cs** code window, locate the following code:
```cs
        Assert.AreEqual(products.Count, 3);
    }
```

26. Ensure that the cursor is at the end of the located code, press Enter twice, and then type the following code:
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

27. In the **UnitTestingExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

28. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.
    >**Note:** The **Test Explorer** displays 1 failed test: IsGetProductReturnsTheCorrectProduct, and 1 passed test: IsIndexReturnsAllProducts.

29. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, under **ProductsWebsite**, expand **Controllers**, and then click **ProductController.cs**. 

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
    >**Note:** The **Test Explorer** displays 2 passed tests: IsGetProductReturnsTheCorrectProduct and IsIndexReturnsAllProducts.

34. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Implementing an Exception Handling Strategy

### Demonstration: How to Configure Exception Handling
#### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **Allfiles\Mod10\Democode\02_ErrorHandlingExample_begin**, and then double-click **ErrorHandlingExample.sln**.

#### Demonstration Steps

1. In the **ErrorHandlingExample - Microsoft Visual Studio** window, click the arrow next to the **▶** (run) button, and then select **Production**.​

2. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

3. In **Microsoft Edge**, click **Close**.

4. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

5. In the **ErrorHandlingExample - Microsoft Visual Studio** window, click the arrow next to the **▶** (run) button, and then select **Development**.​

6. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

7. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Startup+<>c__DisplayClass1_0+<<Configure>b__0>d.MoveNext() in Startup.cs
	+	40.  cnt.IncrementRequestPathCount(context.Request.GetDisplayUrl());
 ```

8. In **Microsoft Edge**, click the **+** sign near **40.** and inspect the code.

9. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Services.Counter.IncrementRequestPathCount(string requestPath) in Counter.cs
	+	19.  UrlCounter[requestPath]++;
 ```

10. In **Microsoft Edge**, click the **+** sign near **19.** and inspect the code.

11. In **Microsoft Edge**, click **Close**.

12. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

13. In the **ErrorHandlingExample - Microsoft Visual Studio** window, in the **Solution Explorer**, expand **Services**, and then click **Counter.cs**.

14. In the **Counter.cs** code window, select the following code:
```cs
    UrlCounter[requestPath]++;
```

15. Replace the selected code with the following code:
```cs
    if (UrlCounter.ContainsKey(requestPath))
        UrlCounter[requestPath]++;
    else
        UrlCounter.Add(requestPath, 1);
```

16. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

17. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

18. In **Microsoft Edge**, click the number **16**.
     
19. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Controllers.HomeController.GetDividedNumber(int id) in HomeController.cs
	+	27.  DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
 ```

20. In **Microsoft Edge**, click the **+** sign near **27.** and inspect the code.

21. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Services.DivisionCalculator.GetDividedNumbers(int number) in DivisionCalculator.cs
	+	21.  if (number % i == 0)
 ```

22. In **Microsoft Edge**, click the **+** sign near **21.** and inspect the code.

23. In **Microsoft Edge**, click **Close**.

24. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

25. In the **ErrorHandlingExample - Microsoft Visual Studio** window, in the **Solution Explorer**, under **Services**, click **DivisionCalculator.cs**.

26. In the **DivisionCalculator.cs** code window, select the following code:
```cs
    for (int i = 0; i < (number / 2) + 1; i++)
```

27. Replace the selected code with the following code:
```cs
    for (int i = 1; i < (number / 2) + 1; i++)
```

28. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

29. In the **ErrorHandlingExample - Microsoft Visual Studio** window, click the arrow next to the **▶** (run) button, and then select **Production**.​

30. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

31. In **Microsoft Edge**, click the number **16**.

32. In **Microsoft Edge**, click **Close**.

33. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

34. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Logging MVC Applications

### Demonstration: How to Log an MVC Application
#### Preparation Steps
