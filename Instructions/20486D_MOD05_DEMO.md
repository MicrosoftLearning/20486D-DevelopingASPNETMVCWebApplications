# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane of the **RazorSyntaxExample - Microsoft Visual Studio** window, under **RazorSyntaxExample**, expand **Controllers**,  and then click **ProductController.cs**.

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

4. In the **ProductController.cs** code window, locate the following code.
```cs
    public IActionResult Index()
```

5. Right click on the **Index** method name, and then click **Add View...** .

6. In the **Add MVC View** dialog window  verify that none of the checkboxes are selected, and then click **Add**.
>**Note** : **Index.cshtml** was created under the **Product** folder that is under the **Views** folder.

7. In the **Index.cshtml** code window, in the **BODY** element, press Enter, and type the following code.
```cs
    @foreach (KeyValuePair<string, int> ProductPrices in ViewBag.ProductPrices)
    {  

    }
```

8. In the **@foreach** code block, type the following code.
```cs
    <p>
       
    </p>
```

9. In the **P** element, type the following code, and press Enter.
```cs
    <div>
        Product Name: @ProductPrices.Key
    </div>
```

10. In the **P** element, below the **DIV** element, type the following code.
```cs
    <div>
        Product Price + Tax: @ProductPrices.Value * 1.2
    </div>
```

11. On the **DEBUG** menu of the **RazorSyntaxExample –  Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note** : The following text is displayed in the browser:<br>
    > Product Name: Bread<br>
    > Product Price + Tax: 5 * 1.2<br>
    > Product Name: Rice<br>
    > Product Price + Tax: 3 * 1.2
    
12. In the **Microsoft Edge** window, click **Close**.

13. On the **DEBUG** Menu, click **Stop Debugging**.

14. In the **Index.cshtml** code window, select the following code. 
```cs
    Product Price + Tax: @ProductPrices.Value * 1.2
```

15. Replace the selected code with the following code.
```cs
    Product Price + Tax: @(ProductPrices.Value * 1.2)
```

16. On the **DEBUG** menu of the **RazorSyntaxExample –  Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note** : The following text is displayed in the browser:<br>
    > Product Name: Bread<br>
    > Product Price + Tax: 6<br>
    > Product Name: Rice<br>
    > Product Price + Tax: 3.6
    
17. In the **Microsoft Edge** window, click **Close**.

18. On the **DEBUG** Menu, click **Stop Debugging**.


# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin**, and then double-click **HTMLHelpersExample.sln**.


#### Demonstration Steps

1. In the Solution Explorer pane, under **Views**, expand **Shared**, and then click **_Layout.cshtml.**

2. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Views**, then expand **Home**, and then click **Index.cshtml**.

3. In the **Index.cshtml** code window, locate the following code.
```cs
    <nav>
        <span>
            Photos
        </span>
        <span>
```

4. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    @Html.ActionLink("Employees", "Index", "Person")
```

5. On the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Controllers**, click **PersonController.cs**.

6. In the **PersonController.cs** code window, locate the following code. 
```cs
    public IActionResult Index()
    {
```

7. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    ViewBag.PersonNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

8. In the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Views**, expand **Person**, and then click **Index.cshtml**.

9. In the **Index.cshtml** code window, locate the following code.
```cs
    <p>Please select an employee from the list:</p>
```

10. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    @foreach (string currentName in ViewBag.PersonNames)
    {
    
    }
```

11. Place the mouse cursor within the foreach code block you just created, and then type the following code. 
```cs
    <div>
        @Html.ActionLink(currentName, "Details", new { personName = currentName })
    </div>
```

12. In the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Controllers**, click **PersonController.cs**.

13. In the **PersonController.cs** code window, locate the following code. 
```cs
    public IActionResult Details(string personName)
    {
```

14. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    ViewBag.SelectedPerson = personName;
```

15. In the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Person**, and click **Details.cshtml**.

16. In the **Details.cshtml** code window, locate the following code.
```cs
    </p>
    <br />
```

17. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    <img src="@Url.Action("GetImage", new {personName = ViewBag.SelectedPerson })" width="500" />
```

18. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    <p class="text">@Html.ActionLink("Back to person selection list", "Index")</p>
```

19. In the Solution Explorer pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Controllers**, click **PersonController.cs**.

20. In the **PersonController.cs** code window, in the **GetImage** action, select the following code. 
```cs
    return Content("");
```

21. Replace the selected code with the following code. 
```cs
    return File($@"\images\{personName.ToLower()}.jpg", "image/jpeg"); 
```

22. On the **DEBUG** menu of the **HTMLHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.

23. In the **Microsoft Edge** window, click the **Employees** link.
     > **Note**:  The link leads to the employees page which contains list of links. Each link contains text of a person's name.

24. In the **Microsoft Edge** window, click the **Michael** link.
     > **Note**:  A page that represents **Michael** is shown. The page contains a name and a photo.

25. In the **Microsoft Edge** window, press the **Back to person selection list** link.     
     > **Note**: List of links is shown. In each link there is a person's name.

26. In the **Microsoft Edge** window, press the **Elena** link .
     > **Note**:  A page that represents **Elena** is shown. The page contains a name and a photo.

27. In the **Microsoft Edge** window, click **Close**.

28. On the **DEBUG** Menu, click **Stop Debugging**.


# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use Tag Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\03_TagHelpersExample_begin**, and then double-click **TagHelpersExample.sln**.


#### Demonstration Steps

1. In the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under the **Views**, expand the **Home**, and then click **Index.cshtml**.

2. In the **Index.cshtml** code window, place the mouse cursor at the beginning of the document, and then type the following code. 
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

3. In the **Index.cshtml** code window, select the following code.
```cs
    @Html.ActionLink("Employees", "Index", "Person")
```

4. Replace the selected code with the following code.
```cs
    <a asp-controller="Person" asp-action="Index">Employees</a>
```

5. In the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, expand **Person**, and then click **Index.cshtml**.

6. In the **Index.cshtml** code window, place the mouse cursor at the beginning of the document, and then type the following code. 
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

7. In the **Index.cshtml** code window, select the following code.
```cs
    @Html.ActionLink(currentName, "Details", new { personName = currentName })
```

8. Replace the selected code with the following code.
```cs
    <a asp-action="Details" asp-route-personName="@currentName">@currentName</a>
```

9. On the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Person**, click **Details.cshtml**.

10. In the **Details.cshtml** code window, place the mouse cursor at the beginning of the document, and then type the following code. 
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

11. In the **Details.cshtml** code window, select the following code.
```cs
    @Html.ActionLink("Back to person selection list", "Index")
```

12. Replace the selected code with the following code.
```cs
    <a asp-action="Index">Back to person selection list</a>
```

13. On the **DEBUG** menu of the **HTMLHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.

14. In the **Microsoft Edge** window, click the **Employees** link .
     > **Note**:  The link leads to the employees page which contains list of links. Each link contains a text of a person's name.

15. In the **Microsoft Edge** window, click the **Michael** link .
     > **Note**:  A page that represents **Michael** is shown. The page contains a name and a photo.

16. In the **Microsoft Edge** window, press the **Back to person selection list** link .     
     > **Note**: List of links is shown. In each link there is a person's name.

17. In the **Microsoft Edge** window, press the **Elena** link.
     > **Note**:  A page that represents **Elena** is shown. The page contains a name and a photo.

18. In the **Microsoft Edge** window, click **Close**.

19. On the **Debug** Menu, click **Stop Debugging**.

20. In the Solution Explorer pane of the **TagHelpersExample – Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Item**.

21. In the **Web** category of the **Add New Item – TagHelpersExample** dialog box, click **Razor View Imports**, and then click **Add**.

22. In the **_ViewImports.cshtml** code window, type the following code.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

23. In the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Home**, click **Index.cshtml**.

24. In the **Index.cshtml** code window, delete the following code.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

25. In the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Person**, click **Index.cshtml**.

26. In the **Index.cshtml** code window, delete the following code.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

27. In the Solution Explorer pane, of the **TagHelpersExample - Microsoft Visual Studio** window, in the **Views** folder, in the **Person** folder, click **Details.cshtml**.

28. In the **Details.cshtml** code window, delete the following code.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

29. On the **DEBUG** menu of the **HTMLHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.

30. In the **Microsoft Edge** window, click the **Employees** link.
     > **Note**:  The link leads to the employees page which contains list of links. In each link there is a person's name.

31. In the **Microsoft Edge** window, click the **Michael** link.
     > **Note**:  A page that represents **Michael** is shown. The page contains a name and a photo.

32. In the **Microsoft Edge** window, click the **Back to person selection list** link.     
     > **Note**: List of links is shown. In each link there is a person's name.

33. In the **Microsoft Edge** window, click the **Elena** link.
     > **Note**:  A page that represents **Elena** is shown. The page contains a name and a photo.

34. In the **Microsoft Edge** window, click **Close**.

35. On the **Debug** Menu, click **Stop Debugging**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use Partial Views

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\04_PartialViewExample_begin**, and then double-click **PartialViewExample.sln**.


#### Demonstration Steps

1. In the Solution Explorer pane of the **PartialViewExample - Microsoft Visual Studio** window, expand **Services**, and then click **Person.cs**.

2. In the **Person.cs** code window, place the mouse cursor within the **Person** constructor code block, and then type the following code. 
```cs
    FirstName = firstName;
    LastName = lastName;
    Address = address;
    PhoneNumber = phoneNumber;
```

3. In the Solution Explorer pane of the **PartialViewExample - Microsoft Visual Studio** window, under **Services**, click **PersonProvider.cs**.

4. In the **PersonProvider.cs** code window, place the mouse cursor within the **PersonProvider** constructor code block, and then type the following code. 
```cs
    _personList = PersonInitializer();
```
> **Note**: The list of people is created within the PersonInitializer method. The PersonInitializer  returns the list to the **_personList** class member. The **_personList** class member is retrieved using the classe's indexer.

5. In the Solution Explorer pane of the **PartialViewExample - Microsoft Visual Studio** window, under **Views**, expand **Home**, and then click **Index.cshtml**.

6. In the **Index.cshtml** code window, locate the following code.
```cs
    @for (int rowIndex = 0; rowIndex < ViewBag.Rows; rowIndex++)
        {
            <tr>
                @for (int columnIndex = 0; columnIndex < ViewBag.Columns; columnIndex++)
                {
```

7. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    int cardIndex = columnIndex + (rowIndex * ViewBag.Columns);
```

8. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    @Html.Partial("_CardDesign", cardIndex);
```

9. In the Solution Explorer pane of the **PartialViewExample - Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Folder**.

10. In the Solution Explorer pane, rename **New Folder** as **Shared**, and then press Enter.

11. In the Solution Explorer pane of the **PartialViewExample - Microsoft Visual Studio** window, right-click **Shared**, point to **Add**, and then click **View...**.
    
12. In the **Add MVC View** dialog window, in the **View name** textbox, type: **_CardDesign**.

13. In the **Add MVC View** dialog window, verify that the **Create as a partial view** checkbox is marked, and then click **Add**.

14. In the **_CardDesign.cshtml** code window, delete the following code.
```cs
    @*
        For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    *@
```

15. In the **_CardDesign.cshtml** code window, place the mouse cursor at the beginning of the document, and then type the following code. 
```cs
    @model int
    @inject PartialViewExample.Services.IPersonProvider PersonList
```

16. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    <td>
        <div>First Name: @PersonList[Model].FirstName</div>
        <div>Last Name: @PersonList[Model].LastName</div>
        <div>Residence: @PersonList[Model].Address</div>
        <div>Phone: @PersonList[Model].PhoneNumber</div>
    </td>
```

17. On the **DEBUG** menu of the **HTMLHelpersExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     > **Note**:  A table with cards is show. Each card contains information of a person including: First name, last name, address, and a phone.
     
18. In the **Microsoft Edge** window, click **Close**.

19. On the **Debug** Menu, click **Stop Debugging**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use View Components

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\05_ViewComponentsExample_begin**, and then double-click **ViewComponentExample.sln**.


#### Demonstration Steps

1. In the Solution Explorer pane of the **ViewComponentExample - Microsoft Visual Studio** window, right-click the **ViewComponentExample**, point to **Add**, and then click **New Folder**.

2. In the Solution Explorer pane, rename **New Folder** as **ViewComponents**, and then press Enter.

3.	In the Solution Explorer pane of the **ViewComponentExample - Microsoft Visual Studio** window, right-click **ViewComponents**, point to **Add**, and then click **Class**.

4.	In the **Add New Item - ViewComponentExample** dialog box, in the **Name** text box, type **PersonCardViewComponent**, and then click **Add**.

5. In the **PersonCardViewComponent.cs** code window, locate the following code.
```cs
    using System.Threading.Tasks;
``` 

6. Place the mouse cursor at the end of the located code, press Enter, and then type the following code
```cs
    using Microsoft.AspNetCore.Mvc;
```

7. In the **PersonCardViewComponent.cs** code window, locate the following code.
```cs
    public class PersonCardViewComponent
```

8. Append the following code to the existing line of code.
```cs
    public class PersonCardViewComponent : ViewComponent
```

9.	In the **PersonCardViewComponent.cs** code window, place the mouse cursor within the **PersonCardViewComponent** class code block, and then type the following code. 
```cs
    public IViewComponentResult Invoke(int id)
    {
        return View("CardDesign", id);
    }
```

10. In the Solution Explorer pane of the **ViewComponentExample - Microsoft Visual Studio** window, expand **Views**, right-click **Shared**, point to **Add**, and then click **New Folder**.

11. In the Solution Explorer pane, rename **New Folder** as **Components**, and then press Enter.

12. In the Solution Explorer pane of the **ViewComponentExample - Microsoft Visual Studio** window, right-click the **Components** folder you just created, point to **Add**, and then click **New Folder**.

13. In the Solution Explorer pane, rename **New Folder** as **PersonCard**, and then press Enter.

14. In the Solution Explorer pane of the **ViewComponentExample - Microsoft Visual Studio** window, under **Shared**, right-click **_CardDesign.cshtml** file, and then click **Cut**.

15. Right-click the **PersonCard** folder you just created, and then click **Paste**.

16. Right-click the **_CardDesign.cshtml** view you just pasted, and then click **Rename**.

17. In the Solution Explorer pane, replace **_CardDesign.cshtml** with **CardDesign.cshtml**, and then press Enter.

18. In the Solution Explorer pane, of the **ViewComponentExample - Microsoft Visual Studio** window, under **Views**, expand **Home**, and then click **Index.cshtml**.

19. In the **Index.cshtml** code window, select the following code.
```cs
    @Html.Partial("_CardDesign", cardIndex);
```

20. Replace the selected code the following code.
```cs
    @await Component.InvokeAsync("PersonCard", cardIndex);
```

21. On the **DEBUG** menu of the **ViewComponentExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     > **Note**:  A table with cards is show. Each card contains information of a person including: First name, last name, address, and a phone.
     
22. In the **Microsoft Edge** window, click **Close**.

23. On the **Debug** Menu, click **Stop Debugging**.
