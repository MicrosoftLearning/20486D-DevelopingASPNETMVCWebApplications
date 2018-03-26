# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin\RazorSyntaxExample**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **RazorSyntaxExample - Microsoft Visual Studio** window, expand **RazorSyntaxExample** project file, right-click **Controllers**, and then click **ProductController**.

2. In the **ProductController.cs** code window, locate and select the following code. 
```cs
    return View();
```

3. Replace the code you selected with the following code
```cs
    ViewBag.ProductPrices = new Dictionary<string,int>();
    ViewBag.ProductPrices.Add("Bread", 5);
    ViewBag.ProductPrices.Add("Rice", 3);
    return View();
```

4. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
```

5. Right click on the **Index** method name, and click **Add View...**.

6. In the **Add MVC View** dialog window leave all the default values as they are, and press **OK**.
>**Note** : See that the Views and the Products folders were created. Inside them there is new file named Index.cshtml.

7. Inside the **body** element, type the following code.
```cs
    @foreach (KeyValuePair<string, int> ProductPrices in ViewBag.ProductPrices)
    {  

    }
```

8. Inside the **@foreach** code block, type the following code
```cs
    <p>
       
    </p>
```

9. In the **p** element, type the following code.
```cs
    <div>
        Product Name: @ProductPrices.Key
    </div>
```

10. In the **p** element, below the **div** element, type the following code.
```cs
    <div>
        Product Price + Tax: @(ProductPrices.Value * 1.2)
    </div>
```

11. On the **DEBUG** menu of the **RazorSyntaxExample –  Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note** : Displayed results:
    > Product Name: Bread
    > Product Price + Tax: 6
    > Product Name: Rice
    > Product Price + Tax: 3.6
    
12. In the **Microsoft Edge** window, click **Close**.

13. On the **Debug** Menu, click **Stop Debugging**.


# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin\RazorSyntaxExample**, and then double-click **HTMLHelpersExample.sln**.


#### Demonstration Steps

1. On the **Solution Explorer** pane, of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Controllers** folder, and click **MainController.cs**.
2. In the **MainController.cs** code window, locate and select the following code.
```cs
public IActionResult ChangedPathAction()
```
3. Replace the code you selected with the following code
```cs
    [Route("ChangedPathAction")]
    public IActionResult ChangedPathAction()
```
4. On the **Solution Explorer** pane, of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Controllers** folder, and click **ContentController.cs**.
5. In the **ContentController.cs** code window, locate and select the following code.
```cs
    public IActionResult ChangedPathAction()
    {
        return View();
    }
```
6. Replace the code you selected with the following code
```cs
    [Route("ChangedControllerAndPathAction")]
    public IActionResult ChangedPathAction()
    {
        return Content("Changed Controller And Path Action");
    }
```
7. On the **Solution Explorer** pane, of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the the **Home** folder, and click **Index.cshtml**.

8. In the **Index.cshtml** code window, locate the following code.
```cs
    <h2>Index Action, Home Controller</h2>
```

9. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
<p>@Html.ActionLink("Path: " + Url.Action("DifferentControllerAction", "View"), "DifferentControllerAction", "View");</p>
```

10. On the **Solution Explorer** pane, of the **HTMLHelpersExample - Microsoft Visual Studio** window, expand the **Views** folder, then expand the the **View** folder, and click **DifferentControllerAction.cshtml**.

11. In the **DifferentControllerAction.cshtml** code window, locate the following code.
```cs
    <h2>DifferentControllerAction Action, View Controller</h2>
```

12. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
<p>@Html.ActionLink("Path: " + Url.Action("Index"), "Index");</p>
```    

13. On the **Solution Explorer** pane, of the **HTMLHelpersExample - Microsoft Visual Studio** window, under the **Views** folder and the **View** subfolder, click **Index.cshtml**.

14. In the **Index.cs** code window, locate the following code.
```cs
    <h2>Index Action, View Controller</h2>
```

15. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
<p>@Html.ActionLink("Path: " + Url.Action("ChangedPathAction"), "ChangedPathAction");</p>
```   

16. On the **Solution Explorer** pane, of the **HTMLHelpersExample - Microsoft Visual Studio** window, under the **Views** folder and the **View** subfolder, click **ChangedPathAction.cshtml**.

17. In the **ChangedPathAction.cs** code window, locate the following code.
```cs
    <h2>ChangedPathAction Action, View Controller</h2>
```

18. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
<p>@Html.ActionLink("Path: " + Url.Action("ChangedPathAction", "Content"), "ChangedPathAction", "Content");</p>
```     

19. On the **DEBUG** menu of the **HTMLHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     > **Note**: The Home Controller index action url path is: **http://localhost:[port]/**

20. In the **Microsoft Edge**, Index page, press the link that leads to the next controller.
     > **Note**:  The View Controller DifferentControllerAction Action url path is: **http://localhost:[port]/View/DifferentControllerAction**

21. In the **Microsoft Edge**, Index page, press the link that leads to the next action.
     > **Note**:  The View Controller Index Action url path is: **http://localhost:63331/View**

22. In the **Microsoft Edge**, Index page, press the link that leads to the next action.
     > **Note**:  The View Controller ChangedPathAction Action url path is: **http://localhost:[port]/ChangedPathAction**

23. In the **Microsoft Edge**, Index page, press the link that leads to the next controller.
     > **Note**:  The Content Controller ChangedPathAction Action url path is: **http://localhost:[port]/ChangedControllerAndPathAction**
