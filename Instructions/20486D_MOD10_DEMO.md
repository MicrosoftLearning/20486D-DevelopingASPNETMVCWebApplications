

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

10. In the **Microsoft Visual Studio** dialog box, click **Yes**.

11. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **ProductsWebsite.Tests**, point to **Add**, and then click **New Folder**.

12. In the **NewFolder** text box, type **Mock**, and then press Enter.

13. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **Mock**, point to **Add**, and then click **Class**.

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
            new Product{ Id = 1, Name = "Product1's name", BasePrice = 1.1F, Description = "A description for product 1.", ImageName = "image-name-1" },
            new Product{ Id = 2, Name = "Product2's name", BasePrice = 2.2F, Description = "A description for product 2.", ImageName = "image-name-2" },
            new Product{ Id = 3, Name = "Product3's name", BasePrice = 3.3F, Description = "A description for product 3.", ImageName = "image-name-3" }
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

1. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

2. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

3. In **Microsoft Edge**, click **Close**.

4. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

5. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on toolbar, click the arrow next to the **Start Debugging** button, and then click **Development**.​

6. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

7. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Startup+<>c__DisplayClass1_0+<<Configure>b__0>d.MoveNext() in Startup.cs
	+	38.  cnt.IncrementRequestPathCount(context.Request.GetDisplayUrl());
 ```

8. In **Microsoft Edge**, click the **+** (plus) sign near **38**, and then inspect the code.

9. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Services.Counter.IncrementRequestPathCount(string requestPath) in Counter.cs
	+	19.            UrlCounter[requestPath]++;
 ```

10. In **Microsoft Edge**, click the **+** (plus) sign near **19**, and then inspect the code.

11. In **Microsoft Edge**, click **Close**.

12. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

13. In the **ErrorHandlingExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Services**, and then click **Counter.cs**.

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

18. In **Microsoft Edge**, click **16**.
     
19. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Controllers.HomeController.GetDividedNumber(int id) in HomeController.cs
	+	28.  DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
 ```

20. In **Microsoft Edge**, click the **+** (plus) sign near **28**, and then inspect the code.

21. In **Microsoft Edge**, locate the following text:
 ```
    ErrorHandlingExample.Services.DivisionCalculator.GetDividedNumbers(int number) in DivisionCalculator.cs
	+	20.  if (number % i == 0)
 ```

22. In **Microsoft Edge**, click the **+** (plus) sign near **20**, and then inspect the code.

23. In **Microsoft Edge**, click **Close**.

24. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

25. In the **ErrorHandlingExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Services**, click **DivisionCalculator.cs**.

26. In the **DivisionCalculator.cs** code window, select the following code:
```cs
    for (int i = 0; i < (number / 2) + 1; i++)
```

27. Replace the selected code with the following code:
```cs
    for (int i = 1; i < (number / 2) + 1; i++)
```

28. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

29. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

30. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

31. In **Microsoft Edge**, click **16**.

32. In **Microsoft Edge**, click **Close**.

33. In the **ErrorHandlingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

34. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Logging MVC Applications

### Demonstration: How to Log an MVC Application
#### Preparation Steps

1. In the **LoggingExample - Microsoft Visual Studio** window, on the **VIEW** menu, point to **Other Windows**, and then click **Package Manager Console**.

2. In the **Package Manager Console** type **Install-Package Serilog.Extensions.Logging.File -Version 2.0.0-dev-00024**.

3. In **Solution Explorer**, click **Program.cs**. 

4. In the **Program.cs** code window, locate the following code:
```cs
    WebHost.CreateDefaultBuilder(args)
```

5. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    .ConfigureLogging((hostingContext, logging) =>
    {
        var env = hostingContext.HostingEnvironment;
        var config = hostingContext.Configuration.GetSection("Logging");

        if (env.IsDevelopment())
        {
            logging.AddConfiguration(config);
            logging.AddConsole();
        }

        if (env.IsProduction())
        {
            logging.AddFile(config);
        }                
    })
```

6. In **Solution Explorer**, expand **appsettings.json**, and then click **appsettings.development.json**

7. Place the cursor after the **{** (opening brackets) sign, press Enter, and then type the following code:
```cs
    "Logging": {
       "LogLevel": {
         "Default": "Trace"
       }
    }
```

8. In **Solution Explorer**, under **appsettings.json**, and then click **appsettings.production.json**

9. Place the cursor after the **{** (opening brackets) sign, press Enter, and then type the following code:
```cs
    "Logging": {
      "PathFormat": "myLog.txt",
      "LogLevel": {
        "Default": "Warning"
      }
    }
```

10. In **Solution Explorer**, expand **Controllers**, and then click **HomeController.cs**. 

11. In the **HomeController.cs** code window, locate the following code:
```cs
    ICounter _counter;
```

12. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ILogger _logger;
```

13. In the **HomeController.cs** code window, select the following code:
```cs
    public HomeController(IDivisionCalculator numberCalculator, ICounter counter)
```

14. Replace the selected code with the following code:
```cs
    public HomeController(IDivisionCalculator numberCalculator, ICounter counter, ILogger<HomeController> logger)
```

15. In the **HomeController.cs** code window, locate the following code:
```cs
    _numberCalculator = numberCalculator;
```

16. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    _logger = logger;
```

17. In the **HomeController.cs** code window, select the following code:
```cs
    _counter.IncrementNumberCount(id);
    ViewBag.NumberOfViews = _counter.NumberCounter[id];
    ViewBag.CounterSucceeded = true;
```

18. Replace the selected code with the following code:
```cs
    try
    {
        _counter.IncrementNumberCount(id);
        ViewBag.NumberOfViews = _counter.NumberCounter[id];
        ViewBag.CounterSucceeded = true;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"An error occured while trying to increase or retrieve the time the page was viewed. Number parameter is: {id}");
    }
```

19. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

20. In the **LoggingExample - Microsoft Visual Studio** window, on toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

21. In the **LoggingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

22. In **Microsoft Edge**, click **16**.
    >**Note:** The browser does not display a text that shows the number of times that the page was displayed.

23. In **Microsoft Edge**, click **Close**.

24. In the **LoggingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

25. In the **LoggingExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **myLog-XXXXXXXX.txt**, and then inspect the **KeyNotFoundException** stack trace.

26. In **Solution Explorer**, expand **Services**, and then click **Counter.cs**. 

27. In the **Counter.cs** code window, select the following code:
```cs
    NumberCounter[number]++;
```

28. Replace the selected code with the following code:
```cs
    if (NumberCounter.ContainsKey(number))
    {
        NumberCounter[number]++;
        _logger.LogDebug($"The views count for number {number} was increased to {NumberCounter[number]}.");
    }
    else
    {
        NumberCounter.Add(number, 1);
        _logger.LogDebug($"The number {number} was added to the views count dictionary");
    }
```
29. In the **ErrorHandlingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

30. In the **LoggingExample - Microsoft Visual Studio** window, on toolbar, click the arrow next to the **Start Debugging** button, and then click **Development**.​

31. In the **LoggingExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

32. In the **LoggingExample - Microsoft Visual Studio** window,  In the **Output** window, click  the **Show output from** drop down, select the **ASP .NET Core Web Server** option, and then click the **Clear All** button.

34. In **Microsoft Edge**, click **16**.
    >**Note:** The browser displays a text that shows the number of times that the page was displayed.

33. In the **LoggingExample (Running) - Microsoft Visual Studio** window, in the **Output** window, locate the text: "The number 16 was added to the views count dictionary".

35. In **Microsoft Edge**, click **Close**.

36. In the **LoggingExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

37. In the **LoggingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

