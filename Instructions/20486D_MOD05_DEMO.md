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



