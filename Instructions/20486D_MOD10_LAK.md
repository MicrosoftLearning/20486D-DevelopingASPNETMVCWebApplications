# Module 10: Testing and Troubleshooting

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Testing and Troubleshooting

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **[Repository Root]\Allfiles\Mod10\Labfiles\01_ShirtStore_begin**, and then open the **ShirtStore.sln**.

    >**Note**: If a **Security Warning for ShirtStore** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this lab.

5. In Microsoft Edge, click **Close**.

### Exercise 1: Testing a Model

#### Task 1: Add a Testing Project

1. Navigate to **[Repository Root]\Allfiles\Mod10\Labfiles\01_ShirtStore_begin**, and then double-click **ShirtStore.sln**.

    >**Note**: If a **Security Warning for ShirtStore** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **ShirtStore – Microsoft Visual Studio** window, in Solution Explorer, right-click **Solution 'ShirtStore'**, point to **Add**, and then click **New Project**.

3. In the **Add New Project** dialog box, in the navigation pane, expand **Installed**, expand **Visual C#**, and then click **.NET Core**.

4. In the **Add New Project** dialog box, in the result pane, click **MSTest Test Project (.NET Core)**.

5. In the **Add New Project** dialog box, in the **Name** box, type **ShirtStoreWebsite.Tests**, and then click **OK**.
   
6. In Solution Explorer, under **ShirtStoreWebsite.Tests**, right-click **Dependencies**, and then click **Add Reference**.

7. In the **Reference Manager - ShirtStoreWebsite.Tests** dialog box, in the navigation pane, expand **Projects**, and then click **Solution**.

8. In the **Reference Manager - ShirtStoreWebsite.Tests** dialog box, in the result pane, select the **ShirtStoreWebsite** check box, and then click **OK**.
   
#### Task 2: Write a test for a model

1. In Solution Explorer, right-click **ShirtStoreWebsite.Tests**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Models**, and then press Enter.

3. In Solution Explorer, under **ShirtStoreWebsite.Tests**, right-click **UnitTest1.cs**, and then click **Rename**.

4. In the **UnitTest1** box, type **ShirtTest**, and then press Enter.

5. In the **Microsoft Visual Studio** dialog box, click **Yes**.

6. In Solution Explorer, right-click **ShirtTest.cs**, and then click **Cut**.

7. In Solution Explorer, right-click **Models**, and then click **Paste**.

8. In the **ShirtTest.cs** code window, locate the following code:
```cs
    using Microsoft.VisualStudio.TestTools.UnitTesting;
```

9. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ShirtStoreWebsite.Models;
```

10. In the **ShirtTest.cs** code window, select the following code:
```cs
    public void TestMethod1()
    {
    }
```

11. Replace the selected code with the following code:
```cs
    public void IsGetFormattedTaxedPriceReturnsCorrectly()
    {
        Shirt shirt = new Shirt
        {
            Price = 10F,
            Tax = 1.2F
        };

        string taxedPrice = shirt.GetFormattedTaxedPrice();

        Assert.AreEqual("$12.00", taxedPrice);
    }
```

12. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 3: Run the unit test – it should fail

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.

    >**Note**: The **Test Explorer** displays one failed test: **IsGetFormattedTaxedPriceReturnsCorrectly**.

#### Task 4: Implement the model class so the test will pass

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, under **ShirtStoreWebsite**, expand **Models**, and then click **Shirt.cs**. 

2. In the **Shirt.cs** code window, select the following code:
```cs
    return Price.ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
```

3. Replace the selected code with the following code:
```cs
    return (Price * Tax).ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
```

4. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 5: Run the unit test – it succeeds

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.

    >**Note**: The **Test Explorer** displays one passed test: **IsGetFormattedTaxedPriceReturnsCorrectly**.

>**Results**: After completing this exercise, you will be able to create a test project and test a model while fixing its code, as in a Test Driven Development environment.

### Exercise 2: Testing a Controller using a Fake Repository

#### Task 1: Create an interface repository

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **ShirtStoreWebsite**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Services**, and then press Enter.

3. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **Services**, point to **Add**, and then click **New Item**.

4. In the **Add New Item – ShirtStoreWebsite** dialog box, click **Interface**.

5. In the **Add New Item – ShirtStoreWebsite** dialog box, in the **Name** box, type **IShirtRepository**, and then click **Add**.

6. In the **IShirtRepository.cs** code window, locate the following code:
```cs
    using System.Threading.Tasks;
```

7. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ShirtStoreWebsite.Models;
```

8. In the **IShirtRepository.cs** code window, select the following code:
```cs
    interface IShirtRepository
    {
    }
```

9. Replace the selected code with the following code:
```cs
    public interface IShirtRepository
    {
        IEnumerable<Shirt> GetShirts();
        bool AddShirt(Shirt shirt);
        bool RemoveShirt(int id);
    }
```

#### Task 2: Implement the interface repository using a fake repository

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **ShirtStoreWebsite.Tests**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **FakeRepositories**, and then press Enter.

3. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **FakeRepositories**, point to **Add**, and then click **Class**.

4. In the **Add New Item - ShirtStoreWebsite.Tests** dialog box, in the **Name** box, type **FakeShirtRepository**, and then click **Add**.

5. In the **FakeShirtRepository.cs** code window, locate the following code:
```cs
    using System.Text;
```

6. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ShirtStoreWebsite.Services;
    using ShirtStoreWebsite.Models;
```

7. In the **FakeShirtRepository.cs** code window, select the following code:
```cs
    class FakeShirtRepository
```

8. Replace the selected code with the following code:
```cs
    internal class FakeShirtRepository : IShirtRepository
```

9. In the **FakeShirtRepository.cs** code window, locate the following code:
```cs
    internal class FakeShirtRepository : IShirtRepository
    {
```

10. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    public IEnumerable<Shirt> GetShirts()
    {
        return new List<Shirt>()
        {
            new Shirt { Color = ShirtColor.Black, Size = ShirtSize.S, Price = 11F },
            new Shirt { Color = ShirtColor.Gray, Size = ShirtSize.M, Price = 12F },
            new Shirt { Color = ShirtColor.White, Size = ShirtSize.L, Price = 13F }
        };
    }

    public bool AddShirt(Shirt shirt)
    {
        return true;
    }

    public bool RemoveShirt(int id)
    {
        return true;
    }
```

#### Task 3: Pass the fake repository to the constructor of a controller

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **ShirtController.cs**.

2. In the **ShirtController.cs** code window, locate the following code:
```cs
    using ShirtStoreWebsite.Models;
``` 

3. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using ShirtStoreWebsite.Services;
``` 

4. In the **ShirtController.cs** code window, locate the following code:
```cs
    public class ShirtController : Controller
    {
``` 

5. Place the cursor after the **{** (opening braces) sign, press Enter, and then type the following code:
```cs
    private IShirtRepository _repository;

    public ShirtController(IShirtRepository repository)
    {
        _repository = repository;
    }
```

#### Task 4: Write a test for a controller

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**. 

2. In the **Package Manager Console** window, type the following text, and then press Enter.
```
    Install-Package Microsoft.AspNetCore.Mvc 2.1.1 -ProjectName ShirtStoreWebsite.Tests
```
3. In Solution Explorer, right-click **ShirtStoreWebsite.Tests**, point to **Add**, and then click **New Folder**.

4. In the **NewFolder** box, type **Controllers**, and then press Enter.

5. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **Controllers**, point to **Add**, and then click **Class**.

6. In the **Add New Item - ShirtStoreWebsite.Tests** dialog box, in the **Name** box, type **ShirtControllerTest**, and then click **Add**.

7. In the **ShirtControllerTest.cs** code window, locate the following code:
```cs
    using System;
    using System.Collections.Generic;
    using System.Text;
``` 

8. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.AspNetCore.Mvc;
    using ShirtStoreWebsite.Controllers;
    using ShirtStoreWebsite.Models;
    using ShirtStoreWebsite.Services;
    using ShirtStoreWebsite.Tests.FakeRepositories;
```

9. In the **ShirtControllerTest.cs** code window, select the following code:
```cs
    class ShirtControllerTest
    {
    }
``` 

10. Replace the selected code with the following code:
```cs
    [TestClass]
    public class ShirtControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllShirts()
        {
            IShirtRepository fakeShirtRepository = new FakeShirtRepository();
            ShirtController shirtController = new ShirtController(fakeShirtRepository);
            ViewResult viewResult = shirtController.Index() as ViewResult;
            List<Shirt> shirts = viewResult.Model as List<Shirt>;
            Assert.AreEqual(shirts.Count, 3);
        }
    }
```

11. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 5: Run the unit test – it should fail

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.

    >**Note**: The **Test Explorer** displays one failed test: **IndexModelShouldContainAllShirts**, and one passed test: **IsGetFormattedTaxedPriceReturnsCorrectly**.

#### Task 6: Implement the controller class so the test will pass

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, under **ShirtStoreWebsite**, under **Controllers**, click **ShirtController.cs**.

2. In the **ShirtController.cs** code window, select the following code:
```cs
    return View();
``` 

3. Replace the selected code with the following code:
```cs
    IEnumerable<Shirt> shirts = _repository.GetShirts();
    return View(shirts);
```

4. In the **ShirtController.cs** code window, locate the following code:
```cs
    public IActionResult AddShirt(Shirt shirt)
    {
``` 

5. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    _repository.AddShirt(shirt);
``` 

6. In the **ShirtController.cs** code window, locate the following code:
```cs
    public IActionResult Delete(int id)
    {
``` 

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    _repository.RemoveShirt(id);
```

8. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 7: Run the unit test – it succeeds

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.

    >**Note**: The **Test Explorer** displays two passed tests: **IndexModelShouldContainAllShirts** and **IsGetFormattedTaxedPriceReturnsCorrectly**.


>**Results**: After completing this exercise, you will be able to test a controller by using a fake repository.

### Exercise 3: Implementing a Repository in the MVC Project

#### Task 1: Implement the interface repository in a repository class

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **Services**, point to **Add**, and then click **Class**.

2. In the **Add New Item - ShirtStoreWebsite** dialog box, in the **Name** box, type **ShirtRepository**, and then click **Add**.

3. In the **ShirtRepository.cs** code window, locate the following code:
```cs
    using System.Threading.Tasks;
```

4. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ShirtStoreWebsite.Models;
    using ShirtStoreWebsite.Data;
```

5. In the **ShirtRepository.cs** code window, select the following code:
```cs
    public class ShirtRepository
```

6. Replace the selected code with the following code:
```cs
    public class ShirtRepository : IShirtRepository
```

7. In the **ShirtRepository.cs** code window, locate the following code:
```cs
    public class ShirtRepository : IShirtRepository
    {
```

8. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    private ShirtContext _context;

    public ShirtRepository(ShirtContext context)
    {
        _context = context;
    }

    public IEnumerable<Shirt> GetShirts()
    {
        return _context.Shirts.ToList();
    }

    public bool AddShirt(Shirt shirt)
    {
        _context.Add(shirt);
        int entries = _context.SaveChanges();
        if(entries > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool RemoveShirt(int id)
    {
        var shirt = _context.Shirts.SingleOrDefault(m => m.Id == id);
        _context.Shirts.Remove(shirt);
        int entries = _context.SaveChanges();
        if (entries > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
```

#### Task 2: Register the repository as a service

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

2. In the **Startup.cs** code window, locate the following code:
```cs
    using Microsoft.EntityFrameworkCore;
```

3. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
```cs
    using ShirtStoreWebsite.Services;
```

4. In the **Startup.cs** code window, locate the following code:
```cs
    services.AddDbContext<ShirtContext>(options =>
        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
```

5. Ensure that the cursor is at the end of the located code, press Enter twice, and then type the following code:
```cs
    services.AddScoped<IShirtRepository, ShirtRepository>();
```

6. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 3: Run the MVC application

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays the **Shirt Store** page.

2. In Microsoft Edge, click **Close**.

>**Results**: After completing this exercise, you have developed a repository to have a functional MVC application.

### Exercise 4: Adding Exception Handling

#### Task 1: Add exception handling in Startup.cs

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, in the **Startup.cs** code window, locate the following code:
```cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ShirtContext shirtContext)
    {
```

2. Ensure that the cursor is at the end of the located code, press Enter twice, and then type the following code:
```cs
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/error.html");
    }
```

#### Task 2: Create a temporary exception for testing

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **ShirtController.cs**.

2. In the **ShirtController.cs** code window, select the following code:
```cs
    _repository.RemoveShirt(id);
```

3. Replace the selected code with the following code:
```cs
    _repository.RemoveShirt(-1);
```

4. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 3: Run the application in the development environment

1. In the **ShirtStore - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Development**.​

2. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In Microsoft Edge, at the top of the **Shirts in stock** table, click the **Delete** link.
    >**Note**: The browser displays the **detailed exception** page.

4. In Microsoft Edge, click **Close**.

#### Task 4: Run the application in the production environment

1. In the **ShirtStore - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

2. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In Microsoft Edge, at the top of the **Shirts in stock** table, click the **Delete** link.
    >**Note**: The browser displays a custom error page **error.html**, which is located in the **wwwroot** folder.

4. In Microsoft Edge, click **Close**.

#### Task 5: Remove the temporary exception

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **ShirtController.cs**.

2. In the **ShirtController.cs** code window, select the following code:
```cs
    _repository.RemoveShirt(-1);
```

3. Replace the selected code with the following code:
```cs
    _repository.RemoveShirt(id);
```

4. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

>**Results**: After completing this exercise, you have added exception handling to an MVC application, by displaying a custom error page or the developer exception page if an exception is thrown.

### Exercise 5: Adding Logging

#### Task 1: Add logging to the MVC application

1. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **ShirtStoreWebsite**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – ShirtStoreWebsite** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

3. In the **Add New Item – ShirtStoreWebsite** dialog box, in the result pane, click **App Settings File**.

4. In the **Add New Item - ShirtStoreWebsite** dialog box, in the **Name** box, type **appsettings.development.json**, and then click **Add**.

5. In the **appsettings.development.json** code window, select the following code:
```cs
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=_CHANGE_ME;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
```

6. Replace the selected code with the following code:
```cs
    "Logging": {
        "LogLevel": {
            "Default": "Trace"
        }
    }
```

7. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, right-click **ShirtStoreWebsite**, point to **Add**, and then click **New Item**.

8. In the **Add New Item – ShirtStoreWebsite** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

9. In the **Add New Item – ShirtStoreWebsite** dialog box, in the result pane, click **App Settings File**.

10. In the **Add New Item - ShirtStoreWebsite** dialog box, in the **Name** box, type **appsettings.production.json**, and then click **Add**.

11. In the **appsettings.production.json** code window, select the following code:
```cs
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=_CHANGE_ME;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
```

12. Replace the selected code with the following code:
```cs
    "Logging": {
      "PathFormat": "shirt_store_logs.txt",
      "LogLevel": {
        "Default": "Warning"
      }
    }
```

13. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, click **Program.cs**. 

14. In the **Program.cs** code window, locate the following code:
```cs
    WebHost.CreateDefaultBuilder(args)
```

15. Place the cursor at the end of the located code, press Enter, and then type the following code:
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

16. In Solution Explorer, under **Controllers**, click **ShirtController.cs**. 

17. In the **ShirtController.cs** code window, locate the following code:
```cs
    using ShirtStoreWebsite.Services;
```

18. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.Extensions.Logging;
```

19. In the **ShirtController.cs** code window, locate the following code:
```cs
    private IShirtRepository _repository;
```

20. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    private ILogger _logger;
```

21. In the **ShirtController.cs** code window, select the following code:
```cs
    public ShirtController(IShirtRepository repository)
```

22. Replace the selected code with the following code:
```cs
    public ShirtController(IShirtRepository repository, ILogger<ShirtController> logger)
```

23. In the **ShirtController.cs** code window, locate the following code:
```cs
    _repository = repository;
```

24. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    _logger = logger;
```

25. In the **ShirtController.cs** code window, locate the following code:
```cs
    _repository.AddShirt(shirt);
```

26. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    _logger.LogDebug($"A {shirt.Color.ToString()} shirt of size {shirt.Size.ToString()} with a price of {shirt.GetFormattedTaxedPrice()} was added successfully.");
```

27. In the **ShirtController.cs** code window, select the following code:
```cs
    _repository.RemoveShirt(id);
    return RedirectToAction("Index");
```

28. Replace the selected code with the following code:
```cs
    try
    {
        _repository.RemoveShirt(id);
        _logger.LogDebug($"A shirt with id {id} was removed successfully.");
        return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"An error occured while trying to delete shirt with id of {id}.");
        throw ex;
    }
```

29. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

#### Task 2: Test the controller by using a mocking framework

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**.  

2. In the **Package Manager Console** window, type the following text, and then press Enter.
```
    Install-Package Moq -Version 4.9.0 -ProjectName ShirtStoreWebsite.Tests
```

3. In the **ShirtStore - Microsoft Visual Studio** window, in Solution Explorer, under **ShirtStoreWebsite.Tests**,  click **ShirtControllerTest.cs**.

4. In the **ShirtControllerTest.cs** code window, locate the following code:
```cs
    using ShirtStoreWebsite.Tests.FakeRepositories;
``` 

5. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.Extensions.Logging;
    using Moq;
```

6. In the **ShirtControllerTest.cs** code window, select the following code:
```cs
    ShirtController shirtController = new ShirtController(fakeShirtRepository);
``` 

7. Replace the selected code with the following code:
```cs
    Mock<ILogger<ShirtController>> mockLogger = new Mock<ILogger<ShirtController>>();
    ShirtController shirtController = new ShirtController(fakeShirtRepository, mockLogger.Object);
```

8. In the **ShirtStore – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

      >**Note**: **ShirtControllerTest** must be updated because we added a parameter to the ShirtController constructor **ILogger<ShirtController> logger**; following the update the test will pass correctly.

#### Task 3: Run the unit test

1. In the **ShirtStore - Microsoft Visual Studio** window, on the **TEST** menu, point to **Run**, and then click **All Tests**.
    >**Note**: The **Test Explorer** displays two passed tests: **IndexModelShouldContainAllShirts** and **IsGetFormattedTaxedPriceReturnsCorrectly**.

#### Task 4: Run the application in the development environment

1. In the **ShirtStore - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Development**.​

2. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
   
3. In the **ShirtStore - Microsoft Visual Studio** window, on the **Output** tab, in the **Show output from** list, select **ASP.NET Core Web Server**, and then click the **Clear All** button.

4. In Microsoft Edge, on the **Size** list, select **M**.

5. In Microsoft Edge, on the **Color** list, select **Yellow**.

6. In Microsoft Edge, on the **Price** box, type **10**.

7. In Microsoft Edge, on the **Tax** box, type **1.2**.

8. In Microsoft Edge, click **Add Shirt to Stock**.
    >**Note**: The new shirt was added to the bottom of the **Shirts in Stock** table.

9. In the **ShirtStore - Microsoft Visual Studio** window, on the **Output** tab, press **ctrl + F**, and then locate the following text:
```
    A Yellow shirt of size M with a price of $12.00 was added successfully.
```
10.  In the **ShirtStore - Microsoft Visual Studio** window,  on the **Output** tab, click **Clear All**.

11. In Microsoft Edge, on the **Shirts in stock** table, click the top **Delete** link.

12. In the **ShirtStore - Microsoft Visual Studio** window, in the **Output** tab, press **ctrl + F**, and then locate the following text:
```
    A shirt with id 1 was removed successfully.
```

13. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Shirt/Delete/-1**, and then press Enter.

    >**Note**: The browser displays the **DeveloperException** page.

14. In Microsoft Edge, click **Close**.

#### Task 5: Run the application in the production environment

1. In the **ShirtStore - Microsoft Visual Studio** window, on the toolbar, click the arrow next to the **Start Debugging** button, and then click **Production**.​

2. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start without Debugging**.

3. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Shirt/Delete/-1**, and then press Enter.
    >**Note**: The browser displays **error.html** content, located in **wwwroot**, under **ShirtStoreWebsite**.

4. In Microsoft Edge, click **Close**.

5. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod10\Labfiles\01_ShirtStore_begin\ShirtStoreWebsite**, and then double-click **shirt_store_logs-XXXXXXXX.txt**.

    >**Note**: Inspect the **ArgumentNullException** stack trace.

6. In the **shirt_store_logs-XXXXXXXX - Notepad** window, click **Close**.

7. In the **ShirtStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start without Debugging**.

8. In Microsoft Edge, on the **Size** list, select **M**.

9. In Microsoft Edge, on the **Color** list, select **Yellow**.

10. In Microsoft Edge, on the **Price** box, type **10**.

11. In Microsoft Edge, on the **Tax** box, type **1.2**.

12. In Microsoft Edge, click **Add Shirt to Stock**.
    >**Note**: The new shirt was added to the bottom of **Shirts in Stock** table.

13. In Microsoft Edge, click **Close**.

14. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod10\Labfiles\01_ShirtStore_begin\ShirtStoreWebsite**, and then double-click **shirt_store_logs-XXXXXXXX.txt**.

    >**Note**: The log file does not contain another message because the action was successful and there are no errors.

15. In **shirt_store_logs-XXXXXXXX - Notepad** window, click **Close**.

16. In the **ShirtStore - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Results**: At the end of this exercise, you will be able to add logging in different logging levels in different environments, displaying errors or information by writing into a log file or a console output in the desired format, and creating a mock substitute by using a mocking framework.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
