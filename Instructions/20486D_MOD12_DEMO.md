# Module 12: Performance and Communication

# Lesson 1: Implementing a Caching Strategy

### Demonstration: How to Use Configure Cashing

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod12\Democode\01_CachingExample_begin**, and then double-click **CachingExample.sln**.

2. In the **CachingExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **Product.cs**.

3. In the **Product.cs** code window, locate the following code:
```cs
    [Display(Name = "Price")]
    public string FormattedPrice
    {
        get
        {
            return BasePrice.ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
        }
    }
```

4. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
```cs
    [NotMapped]
    [Display(Name = "Last retrieved on")]
    public DateTime LoadedFromDatabase { get; set; }
```

5. In the **CachingExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Repositories**, and then click **ProductRepository.cs**.

6. In the **ProductRepository.cs** code window, locate the following code:
```cs
    Product product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    if (product != null)
    {
        product.LoadedFromDatabase = DateTime.Now;
    }
```

8. In the **CachingExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Shared**, expand **Components**, expand **Product**, and then click **SelectedProduct.cshtml**.

9. In the **SelectedProduct.cshtml** code window, locate the following code:
```cs
    <div>
        <span class="display-label">
            @Html.DisplayNameFor(model => Model.Description)
        </span>
        <span class="display-field">
            @Html.DisplayFor(model => Model.Description)
        </span>
    </div>
```

10. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <div>
        <span class="display-label">
            @Html.DisplayNameFor(model => Model.LoadedFromDatabase)
        </span>
        <span class="display-field">
            @Model.LoadedFromDatabase.ToString("G")
        </span>
    </div>
```

11.  In the **CachingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.
        
12. In the **CachingExample –  Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays a list of products.

13. In **Microsoft Edge**, click **Basketball**.
    >**Note**: The browser displays the basketball details, and the last time that the product was retrieved from the database.

14. In **Microsoft Edge**, click **Basketball**.
    >**Note**: The browser displays the same page, but the **Last retrieved on** has changed since the item was retrieved from data base.

15.  In **Microsoft Edge**, click **Close**.
   
16. In the **CachingExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Product**, and then click **Index.cshtml**.

17. In the **index.cshtml** code window, select the following code:
```cs
    <div>
        @await Component.InvokeAsync("Product", @ViewBag.SelectedProductId)
    </div>
```

18. Replace the selected code with the following code:
```cs
    <cache vary-by="@ViewBag.SelectedProductId">
        <div>
            @await Component.InvokeAsync("Product", @ViewBag.SelectedProductId)
        </div>
    </cache>
```

19.   In the **CachingExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.
    
20. In the **CachingExample –  Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

21. In **Microsoft Edge**, click **Basketball**.

22. In **Microsoft Edge**, click **Basketball**.
    >**Note**: The browser displays the same page, but the **Last retrieved on** hasn't changed since the item was cached.

23.  In **Microsoft Edge**, click **Close**.

24. In the **CachingExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Managing State

### Demonstration: How to Store and Retrieve State Information

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos.(**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod12\Democode\02_StateExample_begin**, and then double-click **StateExample.sln**.

3. In the **StateExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

4. In the **Startup.cs** code window, locate the following code:
```cs
    public void ConfigureServices(IServiceCollection services)
    {
```

5. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    services.AddSession();
```

6. In the **Startup.cs** code window, locate the following code:
```cs
    public void Configure(IApplicationBuilder app)
    {
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    app.UseSession();
```

8. In the **StateExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **HomeController.cs**.

9. In the **HomeController.cs** code window, locate the following code:
```cs
    using Microsoft.AspNetCore.Mvc;
```

10. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.AspNetCore.Http;
```

11. In the **HomeController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

12. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    int? overallVisitsNumber = HttpContext.Session.GetInt32("Overall");
    int? controllerVisitsNumber = HttpContext.Session.GetInt32("Home");
    if (overallVisitsNumber == null)
    {
        overallVisitsNumber = 1;
    }
    else
    {
        overallVisitsNumber++;
    }
    if (controllerVisitsNumber == null)
    {
        controllerVisitsNumber = 1;
    }
    else
    {
        controllerVisitsNumber++;
    }
    HttpContext.Session.SetInt32("Overall", overallVisitsNumber.Value);
    HttpContext.Session.SetInt32("Home", controllerVisitsNumber.Value);
```

13. In the **StateExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **AnotherController.cs**.

14. In the **AnotherController.cs** code window, locate the following code:
```cs
    using Microsoft.AspNetCore.Mvc;
```

15. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.AspNetCore.Http;
```

16. In the **AnotherController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

17. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    int? overallVisitsNumber = HttpContext.Session.GetInt32("Overall");
    int? controllerVisitsNumber = HttpContext.Session.GetInt32("Another");
    if (overallVisitsNumber == null)
    {
        overallVisitsNumber = 1;
    }
    else
    {
        overallVisitsNumber++;
    }
    if (controllerVisitsNumber == null)
    {
        controllerVisitsNumber = 1;
    }
    else
    {
        controllerVisitsNumber++;
    }
    HttpContext.Session.SetInt32("Overall", overallVisitsNumber.Value);
    HttpContext.Session.SetInt32("Another", controllerVisitsNumber.Value);
```

18. In the **StateExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, and then click **_ViewImports.cshtml**.

19. In the **_ViewImports.cshtml** code window, locate the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

20. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @using Microsoft.AspNetCore.Http
```

21. In the **StateExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Home**, and then click **Index.cshtml**.

22. In the **Index.cshtml** code window, locate the following code:
```cs
    <div class="info-panel">
```

23. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <div>Number of times that this controller was visited during this session: @Context.Session.GetInt32("Home")</div>
    <div>Number of times that this controller was visited during this session: @Context.Session.GetInt32("Another")</div>
    <div>Number of times visited overall during this session: @Context.Session.GetInt32("Overall")</div>
```

24. In the **StateExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Another**, and then click **Index.cshtml**.

25. In the **Index.cshtml** code window, locate the following code:
```cs
    <div class="info-panel">
```

26. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <div>Number of times that this controller was visited during this session: @Context.Session.GetInt32("Home")</div>
    <div>Number of times that this controller was visited during this session: @Context.Session.GetInt32("Another")</div>
    <div>Number of times visited overall during this session: @Context.Session.GetInt32("Overall")</div>
```

27.  In the **StateExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

28. In the **StateExample –  Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note:** Examine the browser content.

29. In **Microsoft Edge**, click **Another**.

30. In **Microsoft Edge**, click **Home**.

31. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New InPrivate Window**.

32. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]**, and then press Enter.

33.  Close all the **Microsoft Edge** windows.

34. In the **StateExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Two-Way Communication

### Demonstration: How to Use SignalR

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod12\Democode\03_SignalRExample_begin**, and then double-click **SignalRExample.sln**.

2. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

3. In the **Startup.cs** code window, locate the following code:
```cs
    services.AddSingleton<ISquareManager, SquareManager>();
```

4. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    services.AddSignalR();
```

5. In the **Startup.cs** code window, locate the following code:
```cs
    app.UseNodeModules(env.ContentRootPath);
```

6. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
```cs
    app.UseSignalR(routes =>
    {
    });
```

7. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **SignalRExample**, point to **Add**, and then click **New Folder**.

8. In the **NewFolder** text box, type **Hubs**, and then press Enter.

9. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Hubs**, point to **Add**, and then click **Class**.

10.	In the **Add New Item - SignalRExample** dialog box, in the **Name** text box, type **SquaresHub**, and then click **Add**.

11. In the **SquaresHub.cs** code window, locate the following code:
```cs
    using System.Threading.Tasks;
```

12. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.AspNetCore.SignalR;
    using SignalRExample.Services;
```
13. In the **SquaresHub.cs** code window, select the following code:
```cs
    public class SquaresHub
```

14. Replace the selected code with the following code:
```cs
    public class SquaresHub : Hub
```

15. In the **SquaresHub.cs** code window, locate the following code:
```cs
    public class SquaresHub : Hub
    {
```

16. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    private ISquareManager _manager;

    public SquaresHub(ISquareManager manager)
    {
        _manager = manager;
    }

    public async Task SwapColor(int rowIndex, int columnIndex)
    {
        _manager.SwapColor(rowIndex, columnIndex);
        await Clients.Others.SendAsync("SwapSquareColor", rowIndex, columnIndex);
    }
```

17. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.
    
18. In the **Startup.cs** code window, locate the following code:
```cs
    using SignalRExample.Services;
```

19. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using SignalRExample.Hubs;
```

20. In the **Startup.cs** code window, locate the following code:
```cs
    app.UseSignalR(routes =>
    {
```

21. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    routes.MapHub<SquaresHub>("/squareshub");
```

22. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **package.json**.

23. In the **Startup.cs** code window, locate the following code:
```cs
    "dependencies": {
```

24. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    "@aspnet/signalr": "^1.0.0",
```

25. In the **SignalRExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

26. In the **Microsoft Visual Studio** dialog box, click **Yes to All**.

    >**Note**: In **Solution Explorer**, under **Depenndencies**, a new folder named **npm** has been added, which contains the **@aspnet/signalr** package.

27. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Square**, and then click **index.cshtml**.

28. In the **index.cshtml** code window, locate the following code:
```cs
    <script src="~/node_modules/jquery/dist/jquery.min.js"></script>
```

29. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <script src="~/node_modules/@@aspnet/signalr/dist/browser/signalr.min.js"></script>
```

30. In the **SignalRExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **wwwroot**, expand **js**, and then click **square-events.js**.

31. In the **square-events.js** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("squareshub")
        .build();

    connection.on("SwapSquareColor", (x, y) => {
        $('#' + x + y).toggleClass('blue red');
    });
    
    connection.start();
```

32. In the **square-events.js** code window, locate the following code:
```cs
    $(btn).toggleClass('blue red');
```

33. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    connection.invoke("SwapColor", x, y);
```

34. In the **SignalRExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

35. In the **SignalRExample –  Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays 9 blue squares.

36. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

37. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]**, and then press Enter.

38. In **Microsoft Edge**, click on one of the squares.
    >**Note**: In both the **Microsoft Edge** windows, the square that was clicked is red.

39. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

40. In **Microsoft Edge**, in the Address bar, type **http://localhost:[port]**, and then press Enter.
    >**Note**: The browser displays 8 blue squares and 1 red square.

41.  Close all the **Microsoft Edge** windows.

42.  In the **SignalRExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.