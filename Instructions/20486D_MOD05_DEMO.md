# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin\RazorSyntaxExample**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **RazorSyntaxExample - Microsoft Visual Studio** window, expand **RazorSyntaxExample** project file, right-click **Controllers**, and then click **ProductController.cs**.

2. In the **ProductController.cs** code window, locate the following code. 
```cs
    return View();
```

3. Place the mouse cursor before the located code, type the following code, and then press Enter.
```cs
    ViewBag.ProductPrices = new Dictionary<string,int>();
    ViewBag.ProductPrices.Add("Bread", 5);
    ViewBag.ProductPrices.Add("Rice", 3);
```

4. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
```

5. Right click on the **Index** method name, and click **Add View...**.

6. In the **Add MVC View** dialog window leave all the default values as they are, and press **OK**.
>**Note** : See that the Index.cshtm file was created inside the new Product subfolder that is inside the new Views folder.

7. In the **Index.cshtml** code window, in the **body** element, press enter, and type the following code.
```cs
    @foreach (KeyValuePair<string, int> ProductPrices in ViewBag.ProductPrices)
    {  

    }
```

8. Inside the **@foreach** code block, type the following code.
```cs
    <p>
       
    </p>
```

9. In the **p** element, type the following code, and press enter.
```cs
    <div>
        Product Name: @ProductPrices.Key
    </div>
```

10. In the **p** element, below the **div** element, type the following code.
```cs
    <div>
        Product Price + Tax: @ProductPrices.Value * 1.2
    </div>
```

11. On the **DEBUG** menu of the **RazorSyntaxExample –  Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note** : The following is displayed in the browser:<br>
    > Product Name: Bread<br>
    > Product Price + Tax: 5 * 1.2<br>
    > Product Name: Rice<br>
    > Product Price + Tax: 3 * 1.2
    
12. In the **Microsoft Edge** window, click **Close**.

13. On the **Debug** Menu, click **Stop Debugging**.

14. In the **Index.cshtml** code window, locate and select the following code. 
```cs
    Product Price + Tax: @ProductPrices.Value * 1.2
```

15. Replace the code you selected with the following code.
```cs
    Product Price + Tax: @(ProductPrices.Value * 1.2)
```

16. On the **DEBUG** menu of the **RazorSyntaxExample –  Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note** : The following is displayed in the browser:<br>
    > Product Name: Bread<br>
    > Product Price + Tax: 6<br>
    > Product Name: Rice<br>
    > Product Price + Tax: 3.6
    
17. In the **Microsoft Edge** window, click **Close**.

18. On the **Debug** Menu, click **Stop Debugging**.


# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin\HTMLHelpersExample**, and then double-click **HTMLHelpersExample.sln**.


#### Demonstration Steps

1. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the **Home** folder, and then click **Index.cshtml**.

2. In the **Index.cshtml** code window, locate the following code.
```cs
    <nav>
        <span>
            Photos
        </span>
        <span>
```

3. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
    @Html.ActionLink("Employees", "Index", "Person")
```

4. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under the **Controllers** folder, click **PersonController.cs**.

5. Inside the **PersonController.cs** code window, in the **Index** action, locate the following code. 
```cs
    return View();
```

6. Place the mouse cursor before the located code, and type the following code.
```cs
    ViewBag.PersonNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

7. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the **Person** folder, and then click **Index.cshtml**.

8. In the **Index.cshtml** code window, locate the following code.
```cs
    <p>Please select an employee from the list:</p>
```

9. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
    @foreach (string currentName in ViewBag.PersonNames)
    {
    
	}
```

10. Place the mouse cursor within the foreach code block you just created, and then type the following code. 
```cs
    <div>
        @Html.ActionLink(currentName, "Details", new { personName = currentName })
    </div>
```

11. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under the **Controllers** folder, click **PersonController.cs**.

12. Inside the **PersonController.cs** code window, in the **Details** action, locate the following code. 
```cs
    return View();
```

13. Place the mouse cursor before the located code, and type the following code.
```cs
    ViewBag.SelectedPerson = personName;
```

14. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the **Person** folder, and then click **Details.cshtml**.

15. In the **Details.cshtml** code window, locate the following code.
```cs
    </p>
    <br />
```

16. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
    <img src="@Url.Action("GetImage", new {personName = ViewBag.SelectedPerson })" width="500" />
```

17. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    <p class="text">@Html.ActionLink("Back to person selection list", "Index")</p>
```

18. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under the **Controllers** folder, click **PersonController.cs**.

19. Inside the **PersonController.cs** code window, in the **GetImage** action, locate and select the following code. 
```cs
    return Content("");
```

20. Replace the code you selected with the following code. 
```cs
    return File($"{personName}.jpg", "image/jpeg");
```

21. On the **DEBUG** menu of the **HTMLHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.

22. In the **Microsoft Edge**, Index page, press the link that contains the text **Employees**.
     > **Note**:  The link leads to the employees page which contains list of links. Each link contains a text of a person's name.

23. In the **Microsoft Edge**, Index page, press the link that mentions **Michael**.
     > **Note**:  A page that represent **Michael** is shown. The page contains a name and a photo.

24. In the **Microsoft Edge**, Details page, press the link that contains the text **Back to person selection list**.     
     > **Note**: List of links is shown. Each link contains a text of a person's name.

25. In the **Microsoft Edge**, Index page, press the link that mentions **Elena**.
     > **Note**:  A page that represent **Elena** is shown. The page contains a name and a photo.

26. In the **Microsoft Edge** window, click **Close**.




### Demonstration: How to Use Tag Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\03_TagHelpersExample_begin\TagHelpersExample**, and then double-click **TagHelpersExample.sln**.


#### Demonstration Steps


1. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the **Home** folder, and click **Index.cshtml**.

2. In the **Index.cshtml** code window, locate the following code.
```cs
    <body>
```

3. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
    <a asp-action="Index" asp-controller="Person">To the person list</a>
```

4. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under the **Controllers** folder, click **PersonController.cs**.

5. Inside the **PersonController.cs** code window, in the **Index** action, locate the following code. 
```cs
    return View();
```

6. Place the mouse cursor before the located code, type the following code, and then press Enter.
```cs
    ViewBag.PersonNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

7. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the **Person** folder, and click **Index.cshtml**.

8. In the **Index.cshtml** code window, locate the following code.
```cs
    <body>
```

9. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
    @foreach (string currentName in ViewBag.PersonNames)
    {
    
	}
```

10. Place the mouse cursor within the foreach code block you just created, and then type the following code. 
```cs
    <div>
        <a asp-action="Details" asp-controller="Person" asp-route-personName="@currentName">@currentName</a>
    </div>
```

11. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under the **Controllers** folder, click **PersonController.cs**.

12. Inside the **PersonController.cs** code window, in the **Details** action, locate the following code. 
```cs
    return View();
```

13. Place the mouse cursor before the located code, type the following code, and then press Enter.
```cs
    ViewBag.SelectedPerson = personName;
```

14. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the **Person** folder, and click **Details.cshtml**.

15. In the **Details.cshtml** code window, locate the following code.
```cs
    <body>
```

16. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
    <img src="@Url.Action("GetImage", new {personName = ViewBag.SelectedPerson })" width="500" />
```

17. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    <p><a asp-action="Index">Back to person selection list</a></p>
```

18. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under the **Controllers** folder, click **PersonController.cs**.

19. Inside the **PersonController.cs** code window, in the **Details** action, locate and select the following code. 
```cs
    return Content("");
```

20. Replace the code you selected with the following code. 
```cs
    return File($"{personName}.jpg", "image/jpeg");
```

21. On the **DEBUG** menu of the **TagHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.

22. In the **Microsoft Edge**, Index page, press the link that contains the text **To the person list**.
     > **Note**:  The link leads to the **Person** controller from the **Home** controller. List of links is shown. Each link contains a text of a person name.

23. In the **Microsoft Edge**, Index page, press the link that mentions **Michael**.
     > **Note**:  An image that represent **Michael** is shown.

24. In the **Microsoft Edge**, Details page, press the link that contains the text **Back to person selection list**.     
     > **Note**: List of links is shown. Each link contains a text of a person name.

25. In the **Microsoft Edge**, Index page, press the link that mentions **Elena**.
     > **Note**:  An image that represent **Elena** is shown.

26. In the **Microsoft Edge** window, click **Close**.

