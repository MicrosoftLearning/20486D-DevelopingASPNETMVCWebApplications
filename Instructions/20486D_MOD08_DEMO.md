# Module 8: Using Layouts, CSS and JavaScript in ASP.NET Core MVC

# Lesson 1: Using Layouts

### Demonstration: How to Create a Layout and Link it to a View

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod08\Democode\01_LayoutExample_begin**, and then double-click **LayoutExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **LayoutExample – Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – LayoutExample** dialog box, click **Web**, and then, in the result pane, click **Razor View Start**, and click **Add**.

3. In the Solution Explorer pane of the **LayoutExample - Microsoft Visual Studio** window, right-click **Views**, and then click **New Folder**.

4. In the **NewFolder** text box, type **Shared**, and then press Enter.

5. In the Solution Explorer pane of the **LayoutExample – Microsoft Visual Studio** window, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

6. In the **Add New Item – LayoutExample** dialog box, click **Web**, and then, in the result pane, click **Razor Layout**, and click **Add**.

7. In the **_Layout.cshtml** file, locate the following code:

  ```cs
       <title>@ViewBag.Title</title>
```
8. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 

  ```cs
       <environment>
           <link type="text/css" rel="stylesheet" href="~/css/style-layout-example.css" />
       </environment>
```
9. In the **_Layout.cshtml** file, locate the following code:

  ```cs
       <div>
           @RenderBody()
       </div>
```

10. Place the cursor before the **<** (less then) sign of the **&lt;div&gt;** tag, press Enter, press the Up Arrow key, and then type the following code:

  ```cs
       <div>
            <h1>Welcome to the University</h1>
       </div>
```

11. In the **_Layout.cshtml** file, locate the following code:

  ```cs
       <div>
           @RenderBody()
       </div>
```

12. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code: 

  ```cs
       <footer>
           @RenderSection("footer", required: false)
       </footer>
```

13. The final content of the **_Layout.cshtml** file should be as shown below:

  ```cs
       <!DOCTYPE html>

       <html>
       <head>
            <meta name="viewport" content="width=device-width" />
            <title>@ViewBag.Title</title>
            <environment>
                 <link type="text/css" rel="stylesheet" href="~/css/style-layout-example.css" />
            </environment>
       </head>
       <body>
            <div>
                <h1>Welcome to the University</h1>
            </div>
            <div>
                @RenderBody()
            </div>
            <footer>
                @RenderSection("footer", required: false)
            </footer>
       </body>
       </html>
```

14. In the Solution Explorer pane, under **LayoutExample**, expand **Controllers**, and then click **StudentController.cs**.

15. In the **StudentController.cs** code window, locate the following code, right-click the code, and then click **Add View**.

  ```cs
       public IActionResult Index()
```
16. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Index**.

17. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

18. In the **Add View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

19. In the **Index.cshtml** code window, locate the following code:

  ```cs
       @{
           ViewData["Title"] = "Index";
       }
```
20. Place the cursor before the **@** (shtrudel) sign, press the Up Arrow key, type the following code, and then press Enter. 

  ```cs
       @model IEnumerable<Student>
```
21. In the **Index.cshtml** code window, select the following code:

  ```cs
       <h2>Index</h2>
```

22. Replace the selected code with the following code: 

  ```cs
       @section footer{
            <div>
                <p>
                    The University, established in 1980.
                </p>
             </div>
       }
```

23. In the **Index.cshtml** code window, locate the following code:

  ```cs
       @section footer{
            <div>
                <p>
                    The University, established in 1980.
                </p>
             </div>
       }
```

24. Place the cursor after the **}** (closing bracket) sign, press Enter twice, and then type the following code: 

  ```cs
       <h2>Students list</h2>
       <div>
            <table class="table">
                <thead>
                    <tr>
                        <th>
                             @Html.DisplayNameFor(model => model.FirstName)
                        </th>
                        <th>
                            @Html.DisplayNameFor(model => model.LastName)
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var item in Model)
                    {
                        <tr>
                            <td>
                                @Html.DisplayFor(modelItem => item.FirstName)
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.LastName)
                            </td>
                            <td>
                                <a asp-action="Details" asp-route-id="@item.StudentId">Details</a>
                            </td>
                        </tr>
                    }
                </tbody>
            </table>
       </div>
```

25. The final content of the **Index.cshtml** file should be as shown below:

  ```cs
       @model IEnumerable<Student>

       @{
           ViewData["Title"] = "Index";
       }

       @section footer{
            <div>
                <p>
                    The University, established in 1980.
                </p>
            </div>
        }

       <h2>Students list</h2>
       <div>
            <table class="table">
                <thead>
                    <tr>
                        <th>
                             @Html.DisplayNameFor(model => model.FirstName)
                        </th>
                        <th>
                            @Html.DisplayNameFor(model => model.LastName)
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var item in Model)
                    {
                        <tr>
                            <td>
                                @Html.DisplayFor(modelItem => item.FirstName)
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.LastName)
                            </td>
                            <td>
                                <a asp-action="Details" asp-route-id="@item.StudentId">Details</a>
                            </td>
                        </tr>
                    }
                </tbody>
            </table>
       </div>
```

26. In the Solution Explorer pane, under **LayoutExample**, under **Controllers**, click **StudentController.cs**.

27. In the **StudentController.cs** code window, locate the following code, right-click the code, and then click **Add View**.

  ```cs
       public IActionResult Details(int? id)
```
28. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Details**.

29. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

30. In the **Add View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

31. In the **Details.cshtml** code window, locate the following code:

  ```cs
       @{
           ViewData["Title"] = "Details";
       }
```
32. Place the cursor before the **@** (shtrudel) sign, press the Up Arrow key, type the following code, and then press Enter. 

  ```cs
       @model Student
```
33. In the **Details.cshtml** code window, select the following code:

  ```cs
       <h2>Details</h2>
```

34. Replace the selected code with the following code: 

  ```cs
       @section footer{
            <div>
                <a asp-action="Index">Back to List</a>
            </div>
       }
```

35. In the **Details.cshtml** code window, locate the following code:

  ```cs
       @section footer{
            <div>
                <a asp-action="Index">Back to List</a>
             </div>
       }
```

36. Place the cursor after the **}** (closing bracket) sign, press Enter twice, and then type the following code: 

  ```cs
       <h2>Student details</h2>

       <div>
            <hr />
            <dl>
                <dt>
                    @Html.DisplayNameFor(model => model.FirstName)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.FirstName)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.LastName)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.LastName)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.Birthdate)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Birthdate)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.City)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.City)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.Address)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Address)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.Course)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Course)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.StartedUniversityDate)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.StartedUniversityDate)
                </dd>
            </dl>
       </div>
```

37. The final content of the **Details.cshtml** file should be as shown below:

  ```cs
       @model Student

       @{
           ViewData["Title"] = "Details";
       }

       @section footer{
            <div>
                <a asp-action="Index">Back to List</a>
            </div>
       }

       <h2>Student details</h2>

       <div>
            <hr />
            <dl>
                <dt>
                    @Html.DisplayNameFor(model => model.FirstName)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.FirstName)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.LastName)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.LastName)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.Birthdate)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Birthdate)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.City)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.City)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.Address)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Address)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.Course)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Course)
                </dd>
                <dt>
                    @Html.DisplayNameFor(model => model.StartedUniversityDate)
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.StartedUniversityDate)
                </dd>
            </dl>
       </div>
```

38. On the **FILE** menu of the **LayoutExample - Microsoft Visual Studio** window, click **Save All**.

39. On the **DEBUG** menu of the **LayoutExample - Microsoft Visual Studio** window, click **Start Debugging**.

      >**Note:** The browser displays the **Index.cshtml** file combined with the **_Layout.cshtml** file.

40. On the **Home** page, select a student of your choice, and then click **Details**.

      >**Note:** The footer content in the **Student details** page changed.

41. On the **Student details** page, examine the student details, and then click **Back to List**.
      
42. In the Microsoft Edge window, click **Close**.

43. On the **DEBUG** menu of the **LayoutExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

44. On the **FILE** menu of the **LayoutExample - Microsoft Visual Studio** window, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.