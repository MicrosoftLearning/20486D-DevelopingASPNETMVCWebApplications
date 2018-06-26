# Module 5: Developing Views

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin**, and then double-click **RazorSyntaxExample.sln**.

#### Demonstration Steps

1. In the **RazorSyntaxExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **RazorSyntaxExample**, expand **Controllers**, and then click **ProductController.cs**.

2. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

3. Place the cursor at the end of the located code, press Enter, and then type the following code:
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
    >**Note**: Ensure that the View name is **Index**

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

2. Navigate to **Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin**, and then double-click **HTMLHelpersExample.sln**.

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
    @Html.ActionLink("Employees", "Index", "Employee")
```

4. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **EmployeeController.cs**.

5. In the **EmployeeController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

6. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.EmployeeNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

7. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Employee**, and then click **Index.cshtml**.

8. In the **Index.cshtml** code window, locate the following code:
```cs
    <p>Please select an employee from the list:</p>
```

9. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @foreach (string currentName in ViewBag.EmployeeNames)
    {
    
    }
```

10. Place the cursor within the foreach code block you just created, and then type the following code:
```cs
    <div>
        @Html.ActionLink(currentName, "Details", new { employeeName = currentName })
    </div>
```

11. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **EmployeeController.cs**.

12. In the **EmployeeController.cs** code window, locate the following code:
```cs
    public IActionResult Details(string employeeName)
    {
```

13. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.SelectedEmployee = employeeName;
```

14. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Employee**, click **Details.cshtml**.

15. In the **Details.cshtml** code window, locate the following code:
```cs
    </p>
```

16. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <img src="@Url.Action("GetImage", new {employeeName = ViewBag.SelectedEmployee })" width="500" />
    <p class="text">@Html.ActionLink("Back to employee selection list", "Index")</p>
```

17. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **EmployeeController.cs**.

18. In the **EmployeeController.cs** code window, in the **GetImage** action, select the following code:
```cs
    return Content("");
```

19. Replace the selected code with the following code:
```
    return File($@"\images\{employeeName.ToLower()}.jpg", "image/jpeg");
```

20. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

21. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

22. In **Microsoft Edge**, click **Employees**.
    >**Note**: The browser displays a list of links, each link is a employee's name.

23. In **Microsoft Edge**, click **Michael**.
    >**Note**: The browser displays Michael's name and photo.

24. In **Microsoft Edge**, click **Back to employee selection list**.

25. In **Microsoft Edge**, click **Elena**.
    >**Note**: The browser displays Elena's name and photo.

26. In **Microsoft Edge**, click **Close**.

27. In the **HTMLHelpersExample (Running) – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use Tag Helpers

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **Allfiles\Mod05\Democode\03_TagHelpersExample_begin**, and then double-click **TagHelpersExample.sln**.

#### Demonstration Steps

1. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

2. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

3. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.ActionLink("Employees", "Index", "Employee")
```

4. Replace the selected code with the following code:
```cs
    <a asp-controller="Employee" asp-action="Index">Employees</a>
```

5. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Employee**, and then click **Index.cshtml**.

6. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

7. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.ActionLink(currentName, "Details", new { employeeName = currentName })
```

8. Replace the selected code with the following code:
```cs
    <a asp-action="Details" asp-route-employeeName="@currentName">@currentName</a>
```

9. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Employee**, click **Details.cshtml**.

10. In the **Details.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

11. In the **Details.cshtml** code window, select the following code:
```cs
    @Html.ActionLink("Back to employee selection list", "Index")
```

12. Replace the selected code with the following code:
```cs
    <a asp-action="Index">Back to employee selection list</a>
```

13. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

14. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

15. In **Microsoft Edge**, click **Employees**.

16. In **Microsoft Edge**, click **Michael**.

17. In **Microsoft Edge**, click **Back to employee selection list**.

18. In **Microsoft Edge**, click **Elena**.

19. In **Microsoft Edge**, click **Close**.

20. In the **TagHelpersExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

21. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Views**, point to **Add**, and then click **New Item**.

22. In the **Add New Item – TagHelpersExample** dialog box, in the navigation pane, expand **Installed**, and then expand **ASP.NET Core**.

23. In the **Add New Item – TagHelpersExample** dialog box, in the navigation pane, under **ASP.NET Core**, click **Web**.

24. In the **Add New Item – TagHelpersExample** dialog box, in the result pane, click **Razor View Imports**, and then click **Add**.

25. In the **_ViewImports.cshtml** code window, type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

26. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, click **Index.cshtml**.

37. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

38. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Employee**, click **Index.cshtml**.

39. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

40. In the **TagHelpersExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Employee**, click **Details.cshtml**.

41. In the **Details.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

42. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

43. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

44. In **Microsoft Edge**, click **Employees**.

45. In **Microsoft Edge**, click **Michael**.

46. In **Microsoft Edge**, click **Back to employee selection list**.

47. In **Microsoft Edge**, click **Elena**.

48. In **Microsoft Edge**, click **Close**.

49. In the **TagHelpersExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

50. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use Partial Views

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **Allfiles\Mod05\Democode\04_PartialViewsExample_begin**, and then double-click **PartialViewsExample.sln**.

#### Demonstration Steps

1. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Services**, and then click **Person.cs**.

2. In the **Person.cs** code window, locate the following code:
```cs
    public Person(string firstName, string lastName, string address, string phoneNumber)
    {
```

3. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    FirstName = firstName;
    LastName = lastName;
    Address = address;
    PhoneNumber = phoneNumber;
```

4. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Services**, click **PersonProvider.cs**.

5. In the **PersonProvider.cs** code window, locate the following code:
```cs
    public PersonProvider()
    {
```

6. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    PersonList= PersonInitializer();
```

7. In **Solution Explorer**, expand **Controllers**, and then click **HomeController.cs**.

8. In the **HomeController.cs** code window, locate the following code:
```cs
    ViewBag.Columns = 3;
```

9. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.People = _personProvider.PersonList;
```

10. In **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

11. In the **Index.cshtml** code window, locate the following code:
```cs
    @for (int rowIndex = 0; rowIndex < ViewBag.Rows; rowIndex++)
        {
            <tr>
                @for (int columnIndex = 0; columnIndex < ViewBag.Columns; columnIndex++)
                {
```

12. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    int cardIndex = columnIndex + (rowIndex * ViewBag.Columns);
    @Html.Partial("_CardDesign", cardIndex);
```

13. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Views**, point to **Add**, and then click **New Folder**.

14. In the **NewFolder** text box, type **Shared**, and then press Enter.

15. In the **PartialViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Shared**, point to **Add**, and then click **View**.
    
16. In the **Add MVC View** dialog box, in the **View name** text box, type **_CardDesign**.

17. In the **Add MVC View** dialog box, verify that **Create as a partial view** check box is marked and that **Use a layout page** check box is cleared, and then click **Add**.

18. In the **_CardDesign.cshtml** code window, delete the following code:
```
    @*
        For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    *@
```

19. In the **_CardDesign.cshtml** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    @model int
    <td>
        <div>First Name: @ViewBag.People[Model].FirstName</div>
        <div>Last Name: @ViewBag.People[Model].LastName</div>
        <div>Residence: @ViewBag.People[Model].Address</div>
        <div>Phone: @ViewBag.People[Model].PhoneNumber</div>
    </td>
```

20. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

21. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.
    >**Note**: The browser displays a table with cards. Each card contains information of a person including: First Name, Last Name, Residence, and Phone.

22. In **Microsoft Edge**, click **Close**.

23. In the **PartialViewsExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

24. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use View Components

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **Allfiles\Mod05\Democode\05_ViewComponentsExample_begin**, and then double-click **ViewComponentExample.sln**.

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

8. Replace the selected code with the following code:
```cs
    public class PersonCardViewComponent : ViewComponent
```

9. In the **PersonCardViewComponent.cs** code window, locate the following code:
```cs
    public class PersonCardViewComponent : ViewComponent
    {
```

10. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    public IViewComponentResult Invoke(int id)
    {
        return View("CardDesign", id);
    }
```

11. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, right-click **Shared**, point to **Add**, and then click **New Folder**.

12. In the **NewFolder** text box, type **Components**, and then press Enter.

13. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Components**, point to **Add**, and then click **New Folder**.

14. In the **NewFolder** text box, type **PersonCard**, and then press Enter.

15. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Shared**, right-click **_CardDesign.cshtml**, and then click **Cut**.

16. Right-click **PersonCard**, and then click **Paste**.

17. Right-click **_CardDesign.cshtml**, and then click **Rename**.

18. In the **_CardDesign.cshtml** text box, type **CardDesign.cshtml**, and then press Enter.

19. In the **ViewComponentExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, expand **Home**, and then click **Index.cshtml**.

20. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.Partial("_CardDesign", cardIndex);
```

21. Replace the selected code with the following code:
```cs
    @await Component.InvokeAsync("PersonCard", cardIndex);
```

22. In the **ViewComponentExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

23. In the **ViewComponentExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.
    >**Note**: The browser displays a table with cards. Each card contains information of a person including: First Name, Last Name, Address, and a Phone.
     
24. In **Microsoft Edge**, click **Close**.

25. In the **ViewComponentExample (Running)  – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

26. In the **ViewComponentExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.
