# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the **RazorSyntaxExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **RazorSyntaxExample**, expand **Controllers**, and then click **ProductController.cs**.

2. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

3. Place the cursor at the end of the located code, type the following code:
```cs
    ViewBag.ProductPrices = new Dictionary<string, int>();
    ViewBag.ProductPrices.Add("Bread", 5);
    ViewBag.ProductPrices.Add("Rice", 3);
```

4. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
```

5. Right-click on the **Index** method name, and then click **Add View**.

6. In the **Add MVC View** dialog box, ensure that **Create as a partial view** and **Use a layout page** check boxes are cleared, and then click **Add**.
    >**Note**: Ensure that **Index.cshtml** file was created under the **Product** folder that is under the **Views** folder. 
    
7. In the **Index.cshtml** code window, in the **BODY** element, press Enter, and then type the following code:
```cs
    @foreach (KeyValuePair<string, int> productPrices in ViewBag.ProductPrices)
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
        Product name: @productPrices.Key
    </div>
```

10. In the **P** element, below the **DIV** element, type the following code:
```cs
    <div>
        Product price including tax: @productPrices.Value * 1.2
    </div>
```

11. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

12. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.
    >**Note**: The browser displays the following text:<br>
    > "Product name: Bread<br>
    > Product price including tax: 5 * 1.2<br>
    > <br>
    > Product name: Rice<br>
    > Product price including tax: 3 * 1.2"
    
13. In **Microsoft Edge**, click **Close**.

14. In the **RazorSyntaxExample (Running) – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

15. In the **Index.cshtml** code window, select the following code:
```cs
    Product price including tax: @productPrices.Value * 1.2
```

16. Replace the selected code with the following code:
```cs
    Product price including tax: @(productPrices.Value * 1.2)
```

17. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

18. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.
    >**Note**: The browser displays the following text:<br>
    > "Product name: Bread<br>
    > Product price including tax: 6<br>
    > <br>
    > Product name: Rice<br>
    > Product price including tax: 3.6"
    
19. In **Microsoft Edge**, click **Close**.

20. In the **RazorSyntaxExample (Running) – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos.(**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin**, and then double-click **HTMLHelpersExample.sln**.

#### Demonstration Steps

1. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

2. In the **Index.cshtml** code window, locate the following code:
```cs
    <nav>
        <span>
            Photos
        </span>
        <span>
```

3. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @Html.ActionLink("Employees", "Index", "Person")
```

4. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **PersonController.cs**.

5. In the **PersonController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

6. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.PersonNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

7. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Person**, and then click **Index.cshtml**.

8. In the **Index.cshtml** code window, locate the following code:
```cs
    <p>Please select an employee from the list:</p>
```

9. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @foreach (string currentName in ViewBag.PersonNames)
    {
    
    }
```

10. Place the cursor within the foreach code block you just created, and then type the following code:
```cs
    <div>
        @Html.ActionLink(currentName, "Details", new { personName = currentName })
    </div>
```

11. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **PersonController.cs**.

12. In the **PersonController.cs** code window, locate the following code:
```cs
    public IActionResult Details(string personName)
    {
```

13. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.SelectedPerson = personName;
```

14. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Person**, click **Details.cshtml**.

15. In the **Details.cshtml** code window, locate the following code:
```cs
    </p>
```

16. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <img src="@Url.Action("GetImage", new {personName = ViewBag.SelectedPerson })" width="500" />
    <p class="text">@Html.ActionLink("Back to person selection list", "Index")</p>
```

17. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **PersonController.cs**.

18. In the **PersonController.cs** code window, in the **GetImage** action, select the following code:
```cs
    return Content("");
```

19. Replace the selected code with the following code:
```
    return File($@"\images\{personName.ToLower()}.jpg", "image/jpeg");
```

20. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

21. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

22. In **Microsoft Edge**, click **Employees**.
    >**Note**: The browser displays a list of links, each link is a person's name.

23. In **Microsoft Edge**, click **Michael**.
    >**Note**: The browser displays Michael's name and photo.

24. In **Microsoft Edge**, click **Back to person selection list**.

25. In **Microsoft Edge**, click **Elena**.
    >**Note**: The browser displays Elena's name and photo.

26. In **Microsoft Edge**, click **Close**.

27. In the **HTMLHelpersExample (Running) – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use Tag Helpers

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod05\Democode\03_TagHelpersExample_begin**, and then double-click **TagHelpersExample.sln**.

#### Demonstration Steps

1. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

2. In the **Index.cshtml** code window, locate the following code:
```cs
    <!DOCTYPE html>
```

3. Place the cursor before the **<** (less than) sign, press Enter, press the Up Arrow key and then type the following code:
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

6. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Person**, click **Index.cshtml**.

7. In the **Index.cshtml** code window, locate the following code:
```cs
    <!DOCTYPE html>
```

8. Place the cursor before the **<** (less than) sign, press Enter, press the Up Arrow key and then type the following code:
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

11. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Person**, click **Details.cshtml**.

12. In the **Details.cshtml** code window, locate the following code:
```cs
    <!DOCTYPE html>
```

13. Place the cursor before the **<** (less than) sign, press Enter, press the Up Arrow key and then type the following code:
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

16. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

17. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

18. In **Microsoft Edge**, click **Employees**.

19. In **Microsoft Edge**, click **Michael**.

20. In **Microsoft Edge**, click **Back to person selection list**.

21. In **Microsoft Edge**, click **Elena**.

22. In **Microsoft Edge**, click **Close**.

23. In the **TagHelpersExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

24. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Views**, point to **Add**, and then click **New Item**.

25. In the **Add New Item – TagHelpersExample** dialog box, in the navigation pane, expand **Installed**, and then expand **ASP.NET Core**.

26. In the **Add New Item – TagHelpersExample** dialog box, in the navigation pane, under **ASP.NET Core**, click **Web**.

27. In the **Add New Item – TagHelpersExample** dialog box, in the result pane, click **Razor View Imports**, and then click **Add**.

28. In the **_ViewImports.cshtml** code window, type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

29. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, click **Index.cshtml**.

30. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

31. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Person**, click **Index.cshtml**.

32. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

33. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Person**, click **Details.cshtml**.

34. In the **Details.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

35. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

36. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

37. In **Microsoft Edge**, click **Employees**.
    >**Note**: The browser displays a list of links, each link is a person's name.

38. In **Microsoft Edge**, click **Michael**.
    >**Note**: The browser displays Michael's name and photo.

39. In **Microsoft Edge**, click **Back to person selection list**.

40. In **Microsoft Edge**, click **Elena**.
    >**Note**: The browser displays Elena's name and photo.

41. In **Microsoft Edge**, click **Close**.

42. In the **TagHelpersExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use Partial Views

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod05\Democode\04_PartialViewsExample_begin**, and then double-click **PartialViewsExample.sln**.

#### Demonstration Steps

1. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Services**, and then click **Person.cs**.

2. In the **Person.cs** code window, place the cursor within the **Person** constructor code block, and then type the following code: 
```cs
    FirstName = firstName;
    LastName = lastName;
    Address = address;
    PhoneNumber = phoneNumber;
```

3. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Services**, click **PersonProvider.cs**.

4. In the **PersonProvider.cs** code window, place the cursor within the **PersonProvider** constructor code block, and then type the following code:
```cs
    PersonList= PersonInitializer();
```

5. In **Solution Explorer**, under **Controllers**, click **HomeController.cs**.

6. In the **HomeController.cs** code window, locate the following code:
```cs
    ViewBag.Columns = 3;
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.People = _personProvider.PersonList;
```

5. In **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

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

8. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Views**, point to **Add**, and then click **New Folder**.

9. In the **NewFolder** text box, type **Shared**, and then press Enter.

10. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Shared**, point to **Add**, and then click **View**.
    
11. In the **Add MVC View** dialog box, in the **View name** text box, type **_CardDesign**.

12. In the **Add MVC View** dialog box, verify that the **Create as a partial view** check box is marked, and then click **Add**.
    >**Note**: In the **Add MVC View** dialog box, the **Reference script libraries** check box can be unchecked by setting the Template to Edit. Ensure setting back the Template to **Empty (without model)**.<br>

13. In the **_CardDesign.cshtml** code window, delete the following code:
```cs
    @*
        For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    *@
```

14. In the **_CardDesign.cshtml** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    @model int
    <td>
        <div>First Name: @ViewBag.People[Model].FirstName</div>
        <div>Last Name: @ViewBag.People[Model].LastName</div>
        <div>Residence: @ViewBag.People[Model].Address</div>
        <div>Phone: @ViewBag.People[Model].PhoneNumber</div>
    </td>
```

15. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

16. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.
    >**Note**: A table with cards is show. Each card contains information of a person including: First Name, Last Name, Residence, and Phone.
     
17. In **Microsoft Edge**, click **Close**.

18. In the **PartialViewsExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use View Components

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod05\Democode\05_ViewComponentsExample_begin**, and then double-click **ViewComponentExample.sln**.

#### Demonstration Steps

1. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **ViewComponentExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** text box, type **ViewComponents**, and then press Enter.

3. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **ViewComponents**, point to **Add**, and then click **Class**.

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

9.	In the **PersonCardViewComponent.cs** code window, place the cursor within the **PersonCardViewComponent.cs** code block, and then type the following code:
```cs
    public IViewComponentResult Invoke(int id)
    {
        return View("CardDesign", id);
    }
```

10. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, right-click **Shared**, point to **Add**, and then click **New Folder**.

11. In the **NewFolder** text box, type **Components**, and then press Enter.

12. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click the **Components** folder you just created, point to **Add**, and then click **New Folder**.

13. In the **NewFolder** text box, type **PersonCard**, and then press Enter.

14. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Shared**, right-click **_CardDesign.cshtml**, and then click **Cut**.

15. Right-click **PersonCard** you just created, and then click **Paste**.

16. Right-click the **_CardDesign.cshtml** view you just pasted, and then click **Rename**.

17. In the **_CardDesign.cshtml** text box, type **CardDesign.cshtml**, and then press Enter.

18. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Home**, and then click **Index.cshtml**.

19. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.Partial("_CardDesign", cardIndex);
```

20. Replace the selected code the following code:
```cs
    @await Component.InvokeAsync("PersonCard", cardIndex);
```

21. In the **ViewComponentExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

22. In the **ViewComponentExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.
    >**Note**: A table with cards is show. Each card contains information of a person including: First Name, Last Name, Address, and a Phone.
     
23. In **Microsoft Edge**, click **Close**.

24. In the **ViewComponentExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **ViewComponentExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.
