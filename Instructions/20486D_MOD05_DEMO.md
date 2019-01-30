# Module 5: Developing Views

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lesson 1: Creating Views with Razor Syntax

### Demonstration: How to Use the Razor Syntax

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod05\Democode\01_RazorSyntaxExample_begin**, and then double-click **RazorSyntaxExample.sln**.
    >**Note**: If a **Security Warning for RazorSyntaxExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **RazorSyntaxExample - Microsoft Visual Studio** window, in Solution Explorer, under **RazorSyntaxExample**, expand **Controllers**, and then click **ProductController.cs**.

3. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

4. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.ProductPrices = new Dictionary<string, int>();
    ViewBag.ProductPrices.Add("Bread", 5);
    ViewBag.ProductPrices.Add("Rice", 3);
```

5. In the **ProductController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
```

6. Right-click the **Index** method name, and then click **Add View**.

7. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.

8. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** and **Use a layout page** check boxes are clear, and then click **Add**.
    >**Note**: In Solution Explorer, under **Views**, under **Product**, ensure that **Index.cshtml** was created.
    
9. In the **Index.cshtml** code window, in the **BODY** element, press Enter, and then type the following code:
```cs
    @foreach (KeyValuePair<string, int> productPrices in ViewBag.ProductPrices)
    {

    }
```

10. In the **@foreach** code block, type the following code:
```cs
    <p>
       
    </p>
```

11. In the **Index.cshtml** code window, in the **P** element, type the following code, and then press Enter.
```cs
    <div>
        Product name: @productPrices.Key
    </div>
```

12. In the **P** element, below the **DIV** element, type the following code:
```cs
    <div>
        Product price including tax: @productPrices.Value * 1.2
    </div>
```

13. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

14. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays the following text:<br>
    > **Product name: Bread**<br>
    > __Product price including tax: 5 * 1.2__<br>
    > <br>
    > **Product name: Rice**<br>
    > __Product price including tax: 3 * 1.2__"
    
15. In Microsoft Edge, click **Close**.

16. In the **Index.cshtml** code window, select the following code:
```cs
    Product price including tax: @productPrices.Value * 1.2
```

17. Replace the selected code with the following code:
```cs
    Product price including tax: @(productPrices.Value * 1.2)
```

18. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

19. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays the following text:<br>
    > **Product name: Bread**<br>
    > **Product price including tax: 6**<br>
    > <br>
    > **Product name: Rice**<br>
    > **Product price including tax: 3.6**
    
20. In Microsoft Edge, click **Close**.

21. In the **RazorSyntaxExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod05\Democode\02_HTMLHelpersExample_begin**, and then double-click **HTMLHelpersExample.sln**.
    >**Note**: If a **Security Warning for HTMLHelpersExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Home**, and then click **Index.cshtml**.

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
    @Html.ActionLink("Employees", "Index", "Employee")
```

5. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **EmployeeController.cs**.

6. In the **EmployeeController.cs** code window, locate the following code:
```cs
    public IActionResult Index()
    {
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.EmployeeNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
```

8. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, expand **Employee**, and then click **Index.cshtml**.

9. In the **Index.cshtml** code window, locate the following code:
```cs
    <p>Please select an employee from the list:</p>
```

10. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @foreach (string currentName in ViewBag.EmployeeNames)
    {
    
    }
```

11. Place the cursor within the **foreach** code block you just created, and then type the following code:
```cs
    <div>
        @Html.ActionLink(currentName, "Details", new { employeeName = currentName })
    </div>
```

12. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **EmployeeController.cs**.

13. In the **EmployeeController.cs** code window, locate the following code:
```cs
    public IActionResult Details(string employeeName)
    {
```

14. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.SelectedEmployee = employeeName;
```

15. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Employee**, click **Details.cshtml**.

16. In the **Details.cshtml** code window, locate the following code:
```cs
    </p>
```

17. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <img src="@Url.Action("GetImage", new {employeeName = ViewBag.SelectedEmployee })" width="500" />
    <p>@Html.ActionLink("Back to employee selection list", "Index")</p>
```

18. In the **HTMLHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **EmployeeController.cs**.

19. In the **EmployeeController.cs** code window, in the **GetImage** action, select the following code:
```cs
    return Content("");
```

20. Replace the selected code with the following code:
```
    return File($@"\images\{employeeName.ToLower()}.jpg", "image/jpeg");
```

21. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

22. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

23. In Microsoft Edge, click **Employees**.
    >**Note**: The browser displays a list of links, each link is an employee's name.

24. In Microsoft Edge, click **Michael**.
    >**Note**: The browser displays Michael's name and photo.

25. In Microsoft Edge, click **Back to employee selection list**.

26. In Microsoft Edge, click **Elena**.
    >**Note**: The browser displays Elena's name and photo.

27. In Microsoft Edge, click **Close**.

28. In the **HTMLHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using HTML Helpers and Tag Helpers

### Demonstration: How to Use Tag Helpers

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod05\Democode\03_TagHelpersExample_begin**, and then double-click **TagHelpersExample.sln**.
    >**Note**: If a **Security Warning for TagHelpersExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Home**, and then click **Index.cshtml**.

3. In the **Index.cshtml** code window, locate the following code:
```cs
    @{
        Layout = null;
    }
```

4. Place the cursor before the located code, press Enter, press the Up Arrow key, type the following code, and then press Enter.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

5. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.ActionLink("Employees", "Index", "Employee")
```

6. Replace the selected code with the following code:
```cs
    <a asp-controller="Employee" asp-action="Index">Employees</a>
```

7. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, expand **Employee**, and then click **Index.cshtml**.

8. In the **Index.cshtml** code window, locate the following code:
```cs
    @{
        Layout = null;
    }
```

9. Place the cursor before the located code, press Enter, press the Up Arrow key, type the following code, and then press Enter.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

10. In the **Index.cshtml** code window, select the following code:
```cs
    @Html.ActionLink(currentName, "Details", new { employeeName = currentName })
```

11. Replace the selected code with the following code:
```cs
    <a asp-action="Details" asp-route-employeename="@currentName">@currentName</a>
```

12. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Employee**, click **Details.cshtml**.

13. In the **Details.cshtml** code window, locate the following code:
```cs
    @{
        Layout = null;
    }
```

14. Place the cursor before the located code, press Enter, press the Up Arrow key, type the following code, and then press Enter.
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

15. In the **Details.cshtml** code window, select the following code:
```cs
    @Html.ActionLink("Back to employee selection list", "Index")
```

16. Replace the selected code with the following code:
```cs
    <a asp-action="Index">Back to employee selection list</a>
```

17. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

18. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

19. In Microsoft Edge, click **Employees**.

20. In Microsoft Edge, click **Michael**.

21. In Microsoft Edge, click **Back to employee selection list**.

22. In Microsoft Edge, click **Elena**.

23. In Microsoft Edge, click **Close**.

24. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Item**.

25. In the **Add New Item – TagHelpersExample** dialog box, in the navigation pane, expand **Installed**, and then expand **ASP.NET Core**.

26. In the **Add New Item – TagHelpersExample** dialog box, in the navigation pane, under **ASP.NET Core**, click **Web**.

27. In the **Add New Item – TagHelpersExample** dialog box, in the result pane, click **Razor View Imports**, and then click **Add**.

28. In the **_ViewImports.cshtml** code window, type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

29. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Home**, click **Index.cshtml**.

30. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

31. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Employee**, click **Index.cshtml**.

32. In the **Index.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

33. In the **TagHelpersExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Employee**, click **Details.cshtml**.

34. In the **Details.cshtml** code window, delete the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

35. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

36. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

37. In Microsoft Edge, click **Employees**.

38. In Microsoft Edge, click **Michael**.

39. In Microsoft Edge, click **Back to employee selection list**.

40. In Microsoft Edge, click **Elena**.

41. In Microsoft Edge, click **Close**.

42. In the **TagHelpersExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use Partial Views

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod05\Democode\04_PartialViewsExample_begin**, and then double-click **PartialViewsExample.sln**.

    >**Note**: If a **Security Warning for RazorSyntaxExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.
    
2. In the **PartialViewsExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Services**, and then click **Person.cs**.

3. In the **Person.cs** code window, locate the following code:
```cs
    public Person(string firstName, string lastName, string address, string phoneNumber)
    {
```

4. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    FirstName = firstName;
    LastName = lastName;
    Address = address;
    PhoneNumber = phoneNumber;
```

5. In the **PartialViewsExample - Microsoft Visual Studio** window, in Solution Explorer, under **Services**, click **PersonProvider.cs**.

6. In the **PersonProvider.cs** code window, locate the following code:
```cs
    public PersonProvider()
    {
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    PersonList = PersonInitializer();
```

8. In Solution Explorer, expand **Controllers**, and then click **HomeController.cs**.

9. In the **HomeController.cs** code window, locate the following code:
```cs
    ViewBag.Columns = 3;
```

10. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    ViewBag.People = _personProvider.PersonList;
```

11. In Solution Explorer, expand **Views**, expand **Home**, and then click **Index.cshtml**.

12. In the **Index.cshtml** code window, locate the following code:
```cs
    @for (int rowIndex = 0; rowIndex < ViewBag.Rows; rowIndex++)
    {
        <tr>
            @for (int columnIndex = 0; columnIndex < ViewBag.Columns; columnIndex++)
            {
```

13. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    int cardIndex = columnIndex + (rowIndex * ViewBag.Columns);
    @await Html.PartialAsync("_CardDesign", cardIndex);
```

14. In the **PartialViewsExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Folder**.

15. In the **NewFolder** box, type **Shared**, and then press Enter.

16. In the **PartialViewsExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Shared**, point to **Add**, and then click **View**.
    
17. In the **Add MVC View** dialog box, in the **View name** box, type **_CardDesign**.

18. In the **Add MVC View** dialog box, verify that the **Create as a partial view** check box is selected and that the **Use a layout page** check box is cleared, and then click **Add**.

19. In the **_CardDesign.cshtml** code window, delete the following code:
```
    @*
        For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    *@
```

20. In the **_CardDesign.cshtml** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    @model int
    <td>
        <div>First Name: @ViewBag.People[Model].FirstName</div>
        <div>Last Name: @ViewBag.People[Model].LastName</div>
        <div>Residence: @ViewBag.People[Model].Address</div>
        <div>Phone: @ViewBag.People[Model].PhoneNumber</div>
    </td>
```

21. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

22. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays a table with cards. Each card contains information about a person, including: First Name, Last Name, Residence, and Phone.

23. In Microsoft Edge, click **Close**.

24. In the **PartialViewsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Reusing Code in Views

### Demonstration: How to Create and Use View Components

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod05\Democode\05_ViewComponentsExample_begin**, and then double-click **ViewComponentsExample.sln**.

    >**Note**: If a **Security Warning for RazorSyntaxExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **ViewComponentsExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **ViewComponentsExample**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** box, type **ViewComponents**, and then press Enter.

4. In the **ViewComponentsExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **ViewComponents**, point to **Add**, and then click **Class**.

5.	In the **Add New Item - ViewComponentsExample** dialog box, in the **Name** box, type **PersonCardViewComponent**, and then click **Add**.

6. In the **PersonCardViewComponent.cs** code window, locate the following code:
```cs
    using System.Threading.Tasks;
``` 

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.AspNetCore.Mvc;
```

8. In the **PersonCardViewComponent.cs** code window, select the following code:
```cs
    public class PersonCardViewComponent
```

9. Replace the selected code with the following code:
```cs
    public class PersonCardViewComponent : ViewComponent
```

10. In the **PersonCardViewComponent.cs** code window, locate the following code:
```cs
    public class PersonCardViewComponent : ViewComponent
    {
```

11. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    public Task<IViewComponentResult> InvokeAsync(int id)
    {
        return Task.FromResult<IViewComponentResult>(View("CardDesign", id));
    }
```

12. In the **ViewComponentsExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, right-click **Shared**, point to **Add**, and then click **New Folder**.

13. In the **NewFolder** box, type **Components**, and then press Enter.

14. In the **ViewComponentsExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Components**, point to **Add**, and then click **New Folder**.

15. In the **NewFolder** box, type **PersonCard**, and then press Enter.

16. In the **ViewComponentsExample - Microsoft Visual Studio** window, in Solution Explorer, under **Shared**, right-click **_CardDesign.cshtml**, and then click **Cut**.

17. Right-click **PersonCard**, and then click **Paste**.

18. Right-click **_CardDesign.cshtml**, and then click **Rename**.

19. In the **_CardDesign.cshtml** box, type **CardDesign.cshtml**, and then press Enter.

20. In the **ViewComponentsExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, expand **Home**, and then click **Index.cshtml**.

21. In the **Index.cshtml** code window, select the following code:
```cs
    @await Html.PartialAsync("_CardDesign", cardIndex);
```

22. Replace the selected code with the following code:
```cs
    @await Component.InvokeAsync("PersonCard", cardIndex);
```

23. In the **ViewComponentsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

24. In the **ViewComponentsExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays a table with cards. Each card contains information about a person, including: First Name, Last Name, Residance, and a Phone.
     
25. In Microsoft Edge, click **Close**.

26. In the **ViewComponentsExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.