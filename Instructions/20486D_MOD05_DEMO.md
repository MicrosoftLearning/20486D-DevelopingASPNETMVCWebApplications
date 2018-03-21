# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin\RazorSyntaxExample**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the  **RazorSyntaxExample - Microsoft Visual Studio**  window, expand **RazorSyntaxExample** project file, right-click  **Controllers**, and then click  **ProductController**.

2. In the **ProductController.cs** code window, locate the following code:
```cs
string rice = "Rice";
```

3. Place the mouse cursor at the end of the code, press Enter, and then type the following code:
```cs
ViewBag.ProductNames = new List<string>();
ViewBag.ProductNames.Add(bread);
ViewBag.ProductNames.Add(rice);
```

4. In the **ProductController.cs** code window, locate the following code:
```cs
public IActionResult Index()
```

5. Right click on the **Index** method name,  click **Add View...**.

6. In the **Add MVC View** dialog window leave all the default values as they are, and press **OK**.

7. In the Solution Explorer pane of the  **RazorSyntaxExample - Microsoft Visual Studio**  window, expand the **Views** folder, and then expand the **Product** folder.

8. In the Solution Explorer pane of the  **RazorSyntaxExample - Microsoft Visual Studio**  window, click on the **Index.cshtml** file.

9. Inside the  **BODY**  element, type the following code.
```cs
@foreach (string productName in ViewBag.ProductNames)
{

}
```

10. Inside the  **@foreach**  code block, type the following code.
```cs
<p>
    <span>
        Product Name: @productName
    </span>
</p>
```

11. On the **DEBUG** menu of the **RazorSyntaxExample –  Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note** : Displayed results:
    > Product Name: Bread
    > Product Name: Rice
    
12. In the **Microsoft Edge** window, click **Close**.

13. On the **Debug** Menu, click **Stop Debugging**.


