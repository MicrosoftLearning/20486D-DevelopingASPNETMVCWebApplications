# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane of the **RazorSyntaxExample - Microsoft Visual Studio** window, under **RazorSyntaxExample**, expand **Controllers**, and then click **ProductController.cs**.

2. In the **ProductController.cs** code window, locate the following code:
```cs
    return View();
```

3. Place the cursor before the located code, type the following code, and then press Enter.
```cs
    ViewBag.ProductPrices = new Dictionary<string,int>();
    ViewBag.ProductPrices.Add("Bread", 5);
    ViewBag.ProductPrices.Add("Rice", 3);
```

4. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
```

5. Right click on the **Index** method name, and then click **Add View**.

6. In the **Add MVC View** dialog window verify that none of the checkboxes are selected, and then click **Add**.
    >**Note**: **Index.cshtml** was created under **Product** folder that is under **Views** folder.

7. In the **Index.cshtml** code window, in the **BODY** element, press Enter, and then type the following code:
```cs
    @foreach (KeyValuePair<string, int> ProductPrices in ViewBag.ProductPrices)
    {

    }
```

8. In the **@foreach** code block, type the following code:
```cs
    <p>
       
    </p>
```

9. In the **P** element of the **Index.cshtml** code window, type the following code, and then press Enter.
```cs
    <div>
        Product Name: @ProductPrices.Key
    </div>
```

10. In the **P** element, below the **DIV** element, type the following code:
```cs
    <div>
        Product Price + Tax: @ProductPrices.Value * 1.2
    </div>
```

11. On the **FILE** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Save All**.

12. On the **DEBUG** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note**: The browser displays the following text:<br>
    > Product Name: Bread<br>
    > Product Price + Tax: 5 * 1.2<br>
    > <br>
    > Product Name: Rice<br>
    > Product Price + Tax: 3 * 1.2
    
13. In the **Microsoft Edge** window, click **Close**.

14. On the **DEBUG** menu of the **RazorSyntaxExample (Running) – Microsoft Visual Studio** window, click **Stop Debugging**.

15. In the **Index.cshtml** code window, select the following code:
```cs
    Product Price + Tax: @ProductPrices.Value * 1.2
```

16. Replace the selected code with the following code:
```cs
    Product Price + Tax: @(ProductPrices.Value * 1.2)
```

17. On the **FILE** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Save All**.

18. On the **DEBUG** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note**: The browser displays the following text:<br>
    > Product Name: Bread<br>
    > Product Price + Tax: 6<br>
    > <br>
    > Product Name: Rice<br>
    > Product Price + Tax: 3.6
    
19. In the **Microsoft Edge** window, click **Close**.

20. On the **DEBUG** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Stop Debugging**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin**, and then double-click **HTMLHelpersExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane, under **Views**, expand **Shared**, and then click **_Layout.cshtml.**

2. On the **Solution Explorer** pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Views**, expand **Home**, and then click **Index.cshtml**.

3. In the **Index.cshtml** code window, locate the following code:
```cs
    <nav>
        <span>
            Photos
        </span>
        <span>
```

4. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @Html.ActionLink("Employees", "Index", "Person")
```

5. In the **Solution Explorer** pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Controllers**, click **PersonController.cs**.

6. In the **PersonController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.PersonNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

8. In the **Solution Explorer** pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Views**, expand **Person**, and then click **Index.cshtml**.

9. In the **Index.cshtml** code window, locate the following code:
```cs
    <p>Please select an employee from the list:</p>
```

10. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @foreach (string currentName in ViewBag.PersonNames)
    {
    
    }
```

11. Place the cursor within the foreach code block you just created, and then type the following code:
```cs
    <div>
        @Html.ActionLink(currentName, "Details", new { personName = currentName })
    </div>
```

12. In the **Solution Explorer** pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Controllers**, click **PersonController.cs**.

13. In the **PersonController.cs** code window, locate the following code:
```cs
    public IActionResult Details(string personName)
    {
```

14. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.SelectedPerson = personName;
```

15. In the **Solution Explorer** pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Person**, and then click **Details.cshtml**.

16. In the **Details.cshtml** code window, locate the following code:
```cs
    </p>
    <br />
```

17. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <img src="@Url.Action("GetImage", new {personName = ViewBag.SelectedPerson })" width="500" />
    <p class="text">@Html.ActionLink("Back to person selection list", "Index")</p>
```

18. In the **Solution Explorer** pane of the **HTMLHelpersExample - Microsoft Visual Studio** window, under **Controllers**, click **PersonController.cs**.

19. In the **PersonController.cs** code window, in the **GetImage** action, select the following code:
```cs
    return Content("");
```

20. Replace the selected code with the following code:
```
    return File($@"\images\{personName.ToLower()}.jpg", "image/jpeg");
```

21. On the **FILE** menu of the **HTMLHelpersExample – Microsoft Visual Studio** window, click **Save All**.

22. On the **DEBUG** menu of the **HTMLHelpersExample – Microsoft Visual Studio** window, click **Start Debugging**.

23. In the **Microsoft Edge** window, click the **Employees** link.
    >**Note**: The browser displays a list of links, each link is a person's name.

24. In the **Microsoft Edge** window, click the **Michael** link.
    >**Note**: The browser displays **Michael**'s name and photo.

25. In the **Microsoft Edge** window, click the **Back to person selection list** link.

26. In the **Microsoft Edge** window, click the **Elena** link .
    >**Note**: The browser displays **Elena**'s name and photo.

27. In the **Microsoft Edge** window, click **Close**.

28. On the **DEBUG** menu of the **HTMLHelpersExample – Microsoft Visual Studio** window, click **Stop Debugging**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use Tag Helpers

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\03_TagHelpersExample_begin**, and then double-click **TagHelpersExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, expand **Home**, and then click **Index.cshtml**.

2. In the **Index.cshtml** code window, locate the following code:
```cs
    <!DOCTYPE html>
```

3. Place the cursor before the < (less than), press Enter, press the Up Arrow key and then type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

4. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.ActionLink("Employees", "Index", "Person")
```

5. Replace the selected code with the following code:
```cs
    <a asp-controller="Person" asp-action="Index">Employees</a>
```

6. In the **Solution Explorer** pane of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, expand **Person**, and then click **Index.cshtml**.

7. In the **Index.cshtml** code window, locate the following code:
```cs
    <!DOCTYPE html>
```

8. Place the cursor before the < (less than), press Enter, press the Up Arrow key and then type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

9. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.ActionLink(currentName, "Details", new { personName = currentName })
```

10. Replace the selected code with the following code:
```cs
    <a asp-action="Details" asp-route-personName="@currentName">@currentName</a>
```

11. On the **Solution Explorer** pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Person**, click **Details.cshtml**.

12. In the **Details.cshtml** code window, locate the following code:
```cs
    <!DOCTYPE html>
```

13. Place the cursor before the < (less than), press Enter, press the Up Arrow key and then type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

14. In the **Details.cshtml** code window, select the following code:
```cs
    @Html.ActionLink("Back to person selection list", "Index")
```

15. Replace the selected code with the following code:
```cs
    <a asp-action="Index">Back to person selection list</a>
```

16. On the **FILE** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Save All**.

17. On the **DEBUG** menu of the **TagHelpersExample – Microsoft Visual Studio** window, click **Start Debugging**.

18. In the **Microsoft Edge** window, click the **Employees** link.
    >**Note**: The browser displays a list of links, each link is a person's name.

19. In the **Microsoft Edge** window, click the **Michael** link.
    >**Note**: The browser displays **Michael**'s name and photo.

20. In the **Microsoft Edge** window, click the **Back to person selection list** link.

21. In the **Microsoft Edge** window, click the **Elena** link.
    >**Note**: The browser displays **Elena**'s name and photo.

22. In the **Microsoft Edge** window, click **Close**.

23. On the **DEBUG** menu of the **TagHelpersExample (Running) – Microsoft Visual Studio** window, click **Stop Debugging**.

24. In the **Solution Explorer** pane of the **TagHelpersExample – Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Item**.

25. In the navigation pane of the **Add New Item – TagHelpersExample** dialog box, expand **Installed**, and then expand **ASP.NET Core**.

26. In the navigation pane of the **Add New Item – TagHelpersExample** dialog box, under **ASP.NET Core**, click **Web**.

27. In the result pane of the **Add New Item – TagHelpersExample** dialog box, click **Razor View Imports**, and then click **Add**.

28. In the **_ViewImports.cshtml** code window, type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

29. In the **Solution Explorer** pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Home**, click **Index.cshtml**.

30. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

31. In the **Solution Explorer** pane, of the **TagHelpersExample - Microsoft Visual Studio** window, under **Views**, under **Person**, click **Index.cshtml**.

32. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

33. In the **Solution Explorer** pane, of the **TagHelpersExample - Microsoft Visual Studio** window, in the **Views** folder, in the **Person** folder, click **Details.cshtml**.

34. In the **Details.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

35. On the **FILE** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Save All**.

36. On the **DEBUG** menu of the **TagHelpersExample – Microsoft Visual Studio** window, click **Start Debugging**.

37. In the **Microsoft Edge** window, click the **Employees** link.
    >**Note**: The browser displays a list of links, each link is a person's name.

38. In the **Microsoft Edge** window, click the **Michael** link.
    >**Note**: The browser displays **Michael**'s name and photo.

39. In the **Microsoft Edge** window, click the **Back to person selection list** link.

40. In the **Microsoft Edge** window, click the **Elena** link.
    >**Note**: The browser displays **Elena**'s name and photo.

41. In the **Microsoft Edge** window, click **Close**.

42. On the **DEBUG** menu of the **TagHelpersExample (Running) – Microsoft Visual Studio** window, click **Stop Debugging**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use Partial Views

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\04_PartialViewExample_begin**, and then double-click **PartialViewExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane of the **PartialViewExample - Microsoft Visual Studio** window, expand **Services**, and then click **Person.cs**.

2. In the **Person.cs** code window, place the cursor within the **Person** constructor code block, and then type the following code: 
```cs
    FirstName = firstName;
    LastName = lastName;
    Address = address;
    PhoneNumber = phoneNumber;
```

3. In the **Solution Explorer** pane of the **PartialViewExample - Microsoft Visual Studio** window, under **Services**, click **PersonProvider.cs**.

4. In the **PersonProvider.cs** code window, place the cursor within the **PersonProvider** constructor code block, and then type the following code:
```cs
    _personList = PersonInitializer();
```
>**Note**: The **PersonInitializer** creates and populates a list of people, and then returns the list into the **_personList** class member. You can access the list through the class indexer.

5. In the **Solution Explorer** pane of the **PartialViewExample - Microsoft Visual Studio** window, under **Views**, expand **Home**, and then click **Index.cshtml**.

6. In the **Index.cshtml** code window, locate the following code:
```cs
    @for (int rowIndex = 0; rowIndex < ViewBag.Rows; rowIndex++)
        {
            <tr>
                @for (int columnIndex = 0; columnIndex < ViewBag.Columns; columnIndex++)
                {
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    int cardIndex = columnIndex + (rowIndex * ViewBag.Columns);
    @Html.Partial("_CardDesign", cardIndex);
```

8. In the **Solution Explorer** pane of the **PartialViewExample - Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Folder**.

9. In the **Solution Explorer** pane, rename **New Folder** as **Shared**, and then press Enter.

10. In the **Solution Explorer** pane of the **PartialViewExample - Microsoft Visual Studio** window, right-click **Shared**, point to **Add**, and then click **View**.
    
11. In the **Add MVC View** dialog window, in the **View name** textbox, type: **_CardDesign**.

12. In the **Add MVC View** dialog window, verify that the **Create as a partial view** checkbox is marked, and then click **Add**.

13. In the **_CardDesign.cshtml** code window, delete the following code:
```cs
    @*
        For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    *@
```

14. In the **_CardDesign.cshtml** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    @model int
    @inject PartialViewExample.Services.IPersonProvider PersonList

    <td>
        <div>First Name: @PersonList[Model].FirstName</div>
        <div>Last Name: @PersonList[Model].LastName</div>
        <div>Residence: @PersonList[Model].Address</div>
        <div>Phone: @PersonList[Model].PhoneNumber</div>
    </td>
```

15. On the **FILE** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Save All**.

16. On the **DEBUG** menu of the **PartialViewExample – Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note**: A table with cards is show. Each card contains information of a person including: First Name, Last Name, Residence, and Phone.
     
17. In the **Microsoft Edge** window, click **Close**.

18. On the **DEBUG** menu of the **PartialViewExample (Running) – Microsoft Visual Studio** window, click **Stop Debugging**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use View Components

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod05\Democode\05_ViewComponentsExample_begin**, and then double-click **ViewComponentExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane of the **ViewComponentExample - Microsoft Visual Studio** window, right-click **ViewComponentExample**, point to **Add**, and then click **New Folder**.

2. In the **Solution Explorer** pane, rename **New Folder** as **ViewComponents**, and then press Enter.

3.	In the **Solution Explorer** pane of the **ViewComponentExample - Microsoft Visual Studio** window, right-click **ViewComponents**, point to **Add**, and then click **Class**.

4.	In the **Add New Item - ViewComponentExample** dialog box, in the **Name** text box, type **PersonCardViewComponent**, and then click **Add**.

5. In the **PersonCardViewComponent.cs** code window, locate the following code:
```cs
    using System.Threading.Tasks;
``` 

6. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.AspNetCore.Mvc;
```

7. In the **PersonCardViewComponent.cs** code window, select the following code:
```cs
    public class PersonCardViewComponent
```

8. Replace the selected code the following code:
```cs
    public class PersonCardViewComponent : ViewComponent
```

9.	In the **PersonCardViewComponent.cs** code window, place the cursor within the **PersonCardViewComponent** class code block, and then type the following code:
```cs
    public IViewComponentResult Invoke(int id)
    {
        return View("CardDesign", id);
    }
```

10. In the **Solution Explorer** pane of the **ViewComponentExample - Microsoft Visual Studio** window, expand **Views**, right-click **Shared**, point to **Add**, and then click **New Folder**.

11. In the **Solution Explorer** pane, rename **New Folder** as **Components**, and then press Enter.

12. In the **Solution Explorer** pane of the **ViewComponentExample - Microsoft Visual Studio** window, right-click the **Components** folder you just created, point to **Add**, and then click **New Folder**.

13. In the **Solution Explorer** pane, rename **New Folder** as **PersonCard**, and then press Enter.

14. In the **Solution Explorer** pane of the **ViewComponentExample - Microsoft Visual Studio** window, under **Shared**, right-click **_CardDesign.cshtml**, and then click **Cut**.

15. Right-click **PersonCard** you just created, and then click **Paste**.

16. Right-click the **_CardDesign.cshtml** view you just pasted, and then click **Rename**.

17. In the **Solution Explorer** pane, rename **_CardDesign.cshtml** as **CardDesign.cshtml**, and then press Enter.

18. In the **Solution Explorer** pane, of the **ViewComponentExample - Microsoft Visual Studio** window, under **Views**, expand **Home**, and then click **Index.cshtml**.

19. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.Partial("_CardDesign", cardIndex);
```

20. Replace the selected code the following code:01
```cs
    @await Component.InvokeAsync("PersonCard", cardIndex);
```

21. On the **FILE** menu of the **RazorSyntaxExample – Microsoft Visual Studio** window, click **Save All**.

22. On the **DEBUG** menu of the **ViewComponentExample – Microsoft Visual Studio** window, click **Start Debugging**.
    >**Note**: A table with cards is show. Each card contains information of a person including: First name, Last name, Address, and a Phone.
     
23. In the **Microsoft Edge** window, click **Close**.

24. On the **DEBUG** menu of the **ViewComponentExample (Running) – Microsoft Visual Studio** window, click **Stop Debugging**.
