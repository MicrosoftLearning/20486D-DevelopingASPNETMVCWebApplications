# Module 10: Testing and Troubleshooting

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lesson 1: Testing MVC Applications

### Demonstration: How to Run Unit Tests

#### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod10\Democode\01_UnitTestingExample_begin**, and then double-click **UnitTestingExample.sln**.

    >**Note**: If a **Security Warning for ProductsWebsite** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **UnitTestingExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Solution 'UnitTestingExample'**, point to **Add**, and then click **New Project**.

3. In the **Add New Project** dialog box, in the navigation pane, expand **Installed**, expand **Visual C#**, and then click **.NET Core**.

4. In the **Add New Project** dialog box, in the result pane, click **MSTest Test Project (.NET Core)**.

5. In the **Add New Project** dialog box, in the **Name** box, type **ProductsWebsite.Tests**, and then click **OK**.

6. In the **UnitTestingExample - Microsoft Visual Studio** window, in Solution Explorer, under **ProductsWebsite.Tests**, right-click **Dependencies**, and then click **Add Reference**.

7. In the **Reference Manager - ProductsWebsite.Tests** dialog box, in the navigation pane, expand **Projects**, and then click **Solution**.

8. In the **Reference Manager - ProductsWebsite.Tests** dialog box, in the result pane, select the **ProductsWebsite** check box, and then click **OK**.

9. In the **UnitTestingExample - Microsoft Visual Studio** window, in Solution Explorer, under **ProductsWebsite.Tests**, right-click **UnitTest1.cs**, and then click **Rename**.

10. In the **UnitTest1.cs** box, type **ProductControllerTest.cs**, and then press Enter.

11. In the **Microsoft Visual Studio** dialog box, click **Yes**.

12. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**. 

    >**Note**: In Package Manager Console if prompted **Only run scripts from trusted publishers** type **R** and then press Enter".

13. In the **Package Manager Console** window, type the following text, and then press Enter.
```
    Install-Package Microsoft.AspNetCore.Mvc -ProjectName ProductsWebsite.Tests
```

14. In the **UnitTestingExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **ProductsWebsite.Tests**, point to **Add**, and then click **New Folder**.

15. In the **NewFolder** box, type **FakeRepositories**, and then press Enter.

16. In the **UnitTestingExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **FakeRepositories**, point to **Add**, and then click **Class**.

17. In the **Add New Item - ProductsWebsite.Tests** dialog box, in the **Name** box, type **FakeProductRepository**, and then click **Add**.

18. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    using System.Text;
```

19. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ProductsWebsite.Repositories;
    using ProductsWebsite.Models;
```

20. In the **FakeProductRepository.cs** code window, select the following code:
```cs
    class FakeProductRepository
```

21. Replace the selected code with the following code:
```cs
    internal class FakeProductRepository : IProductRepository
```

22. In the **FakeProductRepository.cs** code window, locate the following code:
```cs
    internal class FakeProductRepository : IProductRepository
    {
```

23. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    public IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new Product{ Id = 1, Name = "Product1's name", BasePrice = 1.1F, Description = "A description for product 1.", ImageName = "image-name-1" },
            new Product{ Id = 2, Name = "Product2's name", BasePrice = 2.2F, Description = "A description for product 2.", ImageName = "image-name-2" },
            new Product{ Id = 3, Name = "Product3's name", BasePrice = 3.3F, Description = "A description for product 3.", ImageName = "image-name-3" }
        };
    }
```

24. In the **ProductControllerTest.cs** code window, locate the following code:
```cs
    using Microsoft.VisualStudio.TestTools.UnitTesting;
```

25. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using ProductsWebsite.Controllers;
    using ProductsWebsite.Models;
    using ProductsWebsite.Repositories;
    using ProductsWebsite.Tests.FakeRepositories;
```

26. In the **ProductControllerTest.cs** code window, select the following code:
```cs
    public void TestMethod1()
    {
    }
```

27. Replace the selected code with the following code:
```cs
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
```

28. In the **ProductControllerTest.cs** code window, locate the following code:
```cs
        Assert.AreEqual(products.Count, 3);
    }
```

29. Ensure that the cursor is at the end of the located code, press Enter twice, and then type the following code:
```cs
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
```

30. In the **UnitTestingExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

31. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.
    >**Note**: The **Test Explorer** displays one failed test: **GetProductModelShouldContainTheRightProduct**, and one passed test: **IndexModelShouldContainAllProducts**.

32. In the **UnitTestingExample - Microsoft Visual Studio** window, in Solution Explorer, under **ProductsWebsite**, expand **Controllers**, and then click **ProductController.cs**. 

33. In the **ProductController.cs** code window, select the following code:
```cs
    var product = products.Where(p => p.Id != id).FirstOrDefault();
```

34. Replace the selected code with the following code:
```cs
    var product = products.Where(p => p.Id == id).FirstOrDefault();
```

35. In the **UnitTestingExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

36. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.
    >**Note**: The **Test Explorer** displays two passed tests: **GetProductModelShouldContainTheRightProduct** and **IndexModelShouldContainAllProducts**.

37. In the **UnitTestingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Implementing an Exception Handling Strategy

### Demonstration: How to Configure Exception Handling
#### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod10\Democode\02_ErrorHandlingExample_begin**, and then double-click **ErrorHandlingExample.sln**.

    >**Note**: If a **Security Warning for ErrorHandlingExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

3. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser  displays an Internal Server Error page.

4. In Microsoft Edge, click **Close**.

6. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Development**.​

7. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

8. In Microsoft Edge, locate the following text:
 ```
    ErrorHandlingExample.Startup+<>c__DisplayClass1_0+<<Configure>b__0>d.MoveNext() in Startup.cs
	+	38.  cnt.IncrementRequestPathCount(context.Request.GetDisplayUrl());
 ```

8. In Microsoft Edge, click the **+** (plus) sign near **38**, and then inspect the code.

9. In Microsoft Edge, locate the following text:
 ```
    ErrorHandlingExample.Services.Counter.IncrementRequestPathCount(string requestPath) in Counter.cs
	+	19.            UrlCounter[requestPath]++;
 ```

10. In Microsoft Edge, click the **+** (plus) sign near **19**, and then inspect the code.

11. In Microsoft Edge, click **Close**.

12. In the **ErrorHandlingExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Services**, and then click **Counter.cs**.

13. In the **Counter.cs** code window, select the following code:
```cs
    UrlCounter[requestPath]++;
```

14. Replace the selected code with the following code:
```cs
    if (UrlCounter.ContainsKey(requestPath))
    {
        UrlCounter[requestPath]++;
    }
    else
    {
        UrlCounter.Add(requestPath, 1);
    }
```

15. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

16. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

17. In Microsoft Edge, click **16**.
     
18. In Microsoft Edge, locate the following text:
 ```
    ErrorHandlingExample.Controllers.HomeController.GetDividedNumber(int id) in HomeController.cs
	+	32.  DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
 ```

19. In Microsoft Edge, click the **+** (plus) sign near **32**, and then inspect the code.

20. In Microsoft Edge, locate the following text:
 ```
    ErrorHandlingExample.Services.DivisionCalculator.GetDividedNumbers(int number) in DivisionCalculator.cs
	+	20.  if (number % i == 0)
 ```

21. In Microsoft Edge, click the **+** (plus) sign near **20**, and then inspect the code.

22. In Microsoft Edge, click **Close**.

23. In the **ErrorHandlingExample - Microsoft Visual Studio** window, in Solution Explorer, under **Services**, click **DivisionCalculator.cs**.

24. In the **DivisionCalculator.cs** code window, select the following code:
```cs
    for (int i = 0; i < (number / 2) + 1; i++)
```

25. Replace the selected code with the following code:
```cs
    for (int i = 1; i < (number / 2) + 1; i++)
```

26. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

27. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

28. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

29. In Microsoft Edge, click **16**.
    >**Note**: The browser displays the numbers by which **16** can be divided.

30. In Microsoft Edge, click **Close**.

31. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Logging MVC Applications

### Demonstration: How to Log an MVC Application

#### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod10\Democode\03_LoggingExample_begin**, and then double-click **LoggingExample.sln**.

    >**Note**: If a **Security Warning for LoggingExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **LoggingExample - Microsoft Visual Studio** window, in Solution Explorer, click **Program.cs**. 

3. In the **Program.cs** code window, locate the following code:
```cs
    WebHost.CreateDefaultBuilder(args)
```

4. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    .ConfigureLogging((hostingContext, logging) =>
    {
        var env = hostingContext.HostingEnvironment;
        var config = hostingContext.Configuration.GetSection("Logging");

        logging.ClearProviders();

        if (env.IsDevelopment())
        {
            logging.AddConfiguration(config);
            logging.AddConsole();
        }
        else
        {
            logging.AddFile(config);
        }
    })
```

5. In Solution Explorer, expand **appsettings.json**, and then click **appsettings.development.json**.

6. Place the cursor after the **{** (opening braces) sign, press Enter, and then type the following code:
```cs
    "Logging": {
       "LogLevel": {
         "Default": "Trace"
       }
    }
```

7. In Solution Explorer, click **appsettings.production.json**.

8. Place the cursor after the **{** (opening braces) sign, press Enter, and then type the following code:
```cs
    "Logging": {
      "PathFormat": "myLog.txt",
      "LogLevel": {
        "Default": "Warning"
      }
    }
```

9. In Solution Explorer, expand **Controllers**, and then click **HomeController.cs**. 

10. In the **HomeController.cs** code window, locate the following code:
```cs
    ICounter _counter;
```

11. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ILogger _logger;
```

12. In the **HomeController.cs** code window, select the following code:
```cs
    public HomeController(IDivisionCalculator numberCalculator, ICounter counter)
```

13. Replace the selected code with the following code:
```cs
    public HomeController(IDivisionCalculator numberCalculator, ICounter counter, ILogger<HomeController> logger)
```

14. In the **HomeController.cs** code window, locate the following code:
```cs
    _numberCalculator = numberCalculator;
```

15. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    _logger = logger;
```

16. In the **HomeController.cs** code window, locate the following code:
```cs
    ViewBag.CounterSucceeded = false;
```

17. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    try
    {
        _counter.IncrementNumberCount(id);
        ViewBag.NumberOfViews = _counter.NumberCounter[id];
        ViewBag.CounterSucceeded = true;
        _logger.LogError("GetDividedNumber - Success");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"An error occured while trying to increase or retrieve the page display count. Number parameter is: {id}");
    }
```

18. In the **LoggingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

19. In the **LoggingExample - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

20. In the **LoggingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

21. In Microsoft Edge, click **16**.

    >**Note**: The browser does not display how many times the number **16** was viewed.

22. In Microsoft Edge, click **Close**.

23. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod10\Democode\03_LoggingExample_begin\LoggingExample**, and then double-click **myLog-XXXXXXXX - Notepad**.

    >**Note**: Inspect the **KeyNotFoundException** stack trace.

24. In the **myLog-XXXXXXXX - Notepad** window, click **Close**.

25. In Solution Explorer, expand **Services**, and then click **Counter.cs**. 

26. In the **Counter.cs** code window, select the following code:
```cs
    NumberCounter[number]++;
```

27. Replace the selected code with the following code:
```cs
    if (NumberCounter.ContainsKey(number))
    {
        NumberCounter[number]++;
        _logger.LogDebug($"The number of times the page was displayed for the number {number} was increased to {NumberCounter[number]}.");
    }
    else
    {
        NumberCounter.Add(number, 1);
        _logger.LogDebug($"The number {number} was added to the page display count dictionary.");
    }
```
28. In the **LoggingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

29. In the **LoggingExample - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Development**.​

30. In the **LoggingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

31. In Microsoft Edge, click **16**.

32. In the **LoggingExample - Microsoft Visual Studio** window, on the **View** menu, click **Output**.

33. On the **Output** tab, in the **Show output from** box, select **ASP.NET Core Web Server**.

34. In the **LoggingExample - Microsoft Visual Studio** window, on the **Output** tab, press **Ctrl + F**, and then locate the following text:
```
    The number 16 was added to the page display count dictionary.
```

35. In Microsoft Edge, click **Close**.

36. In the **LoggingExample - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

37. In the **LoggingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

38. In Microsoft Edge, click **16**.

    >**Note**: The browser displays the numbers by which **16** can be divided.

39. In Microsoft Edge, click **Close**.

40. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod10\Democode\03_LoggingExample_begin\LoggingExample**, and then double-click **myLog-XXXXXXXX.txt**.

    >**Note**: Press **Ctrl + F**, and then locate the following the sentence **GetDividedNumber - Success**.

41. In the **myLog-XXXXXXXX - Notepad** window, click **Close**.

42. In the **LoggingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
