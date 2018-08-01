# Module 8: Using Layouts, CSS and JavaScript in ASP.NET Core MVC

# Lesson 1: Using Layouts

### Demonstration: How to Create a Layout and Link it to a View

#### Preparation Steps 

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod08\Democode\01_LayoutExample_begin**, and then double-click **LayoutExample.sln**.

2. In the Solution Explorer pane of the **LayoutExample – Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Item**.

3. In the **Add New Item – LayoutExample** dialog box, click **Web**, and then, in the result pane, click **Razor View Start**, and click **Add**.

4. In the Solution Explorer pane of the **LayoutExample - Microsoft Visual Studio** window, right-click **Views**, point to **Add**, and then click **New Folder**.

5. In the **NewFolder** text box, type **Shared**, and then press Enter.

6. In the Solution Explorer pane of the **LayoutExample – Microsoft Visual Studio** window, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

7. In the **Add New Item – LayoutExample** dialog box, click **Web**, and then, in the result pane, click **Razor Layout**, and click **Add**.

8. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

9. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link type="text/css" rel="stylesheet" href="~/css/style-layout-example.css" />
```

10. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

11. Place the cursor before the **<** (less then) sign of the **&lt;div&gt;** tag, press Enter, press the Up Arrow key, and then type the following code:
  ```cs
       <div>
            <h1>Welcome to the University</h1>
       </div>
```

12. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

13. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <footer>
           @RenderSection("footer", required: false)
       </footer>
```

14. In the Solution Explorer pane, under **LayoutExample**, expand **Controllers**, and then click **StudentController.cs**.

15. In the **StudentController.cs** code window, locate the following code, right-click the code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

16. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Index**.

17. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

18. In the **Add View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

19. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model IEnumerable<Student>
```
20. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

21. Replace the selected code with the following code: 
  ```cs
       @section footer{
            <div>
                <p>
                    The University, established in 1980.
                </p>
             </div>
       }
```

22. In the **Index.cshtml** code window, locate the following code:
  ```cs
       @section footer{
            <div>
                <p>
                    The University, established in 1980.
                </p>
             </div>
       }
```

23. Place the cursor after the **}** (closing bracket) sign, press Enter twice, and then type the following code: 
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

24. In the Solution Explorer pane, under **LayoutExample**, under **Controllers**, click **StudentController.cs**.

25. In the **StudentController.cs** code window, locate the following code, right-click the code, and then click **Add View**.
  ```cs
       public IActionResult Details(int? id)
```

26. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Details**.

27. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

28. In the **Add View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

29. In the **Details.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model Student
```

30. In the **Details.cshtml** code window, select the following code:
  ```cs
       <h2>Details</h2>
```

31. Replace the selected code with the following code: 
  ```cs
       @section footer{
            <div>
                <a asp-action="Index">Back to List</a>
            </div>
       }
```

32. In the **Details.cshtml** code window, locate the following code:
  ```cs
       @section footer{
            <div>
                <a asp-action="Index">Back to List</a>
             </div>
       }
```

33. Place the cursor after the **}** (closing bracket) sign, press Enter twice, and then type the following code: 
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

34. On the **FILE** menu of the **LayoutExample - Microsoft Visual Studio** window, click **Save All**.

35. On the **DEBUG** menu of the **LayoutExample - Microsoft Visual Studio** window, click **Start Without Debugging**.

      >**Note:** The browser displays the **Index.cshtml** file combined with the **_Layout.cshtml** file.

36. On the **Home** page, select a student of your choice, and then click **Details**.

      >**Note:** The footer content in the **Student details** page changed.

37. On the **Student details** page, examine the student details, and then click **Back to List**.
      
38. In the Microsoft Edge window, click **Close**.

39. On the **FILE** menu of the **LayoutExample - Microsoft Visual Studio** window, click **Exit**.

# Lesson 2: Using CSS and JavaScript

### Demonstration: How to Use NPM to Add a JavaScript Library

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod08\Democode\02_JSLibraryExample_begin**, and then double-click **JSLibraryExample.sln**.

2. In the Solution Explorer pane of the **JSLibraryExample - Microsoft Visual Studio** window, right-click **JSLibraryExample**, point to **Add**, and then click **New Item**.

3. In the navigation pane of the **Add New Item - JSLibraryExample** dialog box, in the search box type **npm**, and then press Enter.

4. In the navigation pane of the **Add New Item - JSLibraryExample** dialog box, click **npm Configuration File**, and then click **Add**.

5. In the **package.json** file, locate the following code:
  ```cs
       "devDependencies": {
       }
```
6. Place the cursor after the **}** (closing bracket) sign, and type the following code:
  ```cs
       ,
       "dependencies": {
       "jquery": "3.3.1"
       }
```

7.  In the **JSLibraryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save package.json**.

>**Note:** In the Solution Explorer pane, under **Depenndencies**, a new folder has been added named **npm** with the **jquery** package.

8. In the Solution Explorer pane of the **JSLibraryExample - Microsoft Visual Studio** window, click **Startup.cs**.

9. In the **Startup.cs** code window, locate the following code: 
  ```cs
       app.UseMvcWithDefaultRoute();
```

10. Place the mouse cursor before the located code, type the following code, and then press Enter twice.
  ```cs
       app.UseStaticFiles();

       app.UseNodeModules(env.ContentRootPath);
```

11. In the Solution Explorer pane, right-click **JSLibraryExample**, point to **Add**, and then click **New Folder**.

12. In the **NewFolder** box, type **Middleware**, and then press Enter.

13. In the Solution Explorer pane of the **JSLibraryExample - Microsoft Visual Studio** window, right-click **Middleware**, point to **Add**, and then click **Class**.

14. In the **Name** box of the **Add New Item – JSLibraryExample** dialog box, type **ApplicationBuilderExtensions**, and then click **Add**.

15. In the **ApplicationBuilderExtensions.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
16. Ensure that the mouse cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using System.IO;
       using Microsoft.Extensions.FileProviders;
```

17. In the **ApplicationBuilderExtensions.cs** code window, select the following code:
  ```cs
      public class ApplicationBuilderExtensions
```

18.  Replace the selected code with the following code:
  ```cs
      public static class ApplicationBuilderExtensions
```
19. In the **ApplicationBuilderExtensions.cs** code window, select the following code:
  ```cs
       namespace JSLibraryExample.Middleware
```

20. Replace the selected code with the following code:
  ```cs
       namespace Microsoft.AspNetCore.Builder
```

21. In the **ApplicationBuilderExtensions.cs** code block, place the mouse cursor after the **{** (opening brackets) sign, press Enter, and then type the following code:
  ```cs
       public static IApplicationBuilder UseNodeModules(this IApplicationBuilder applicationBuilder, string root)
       {
          var path = Path.Combine(root, "node_modules");
          var fileProvider = new PhysicalFileProvider(path);

          var options = new StaticFileOptions();
          options.RequestPath = "/node_modules";
          options.FileProvider = fileProvider;

          applicationBuilder.UseStaticFiles(options);
          return applicationBuilder;
       }
```

>**Note:** This code block represent the **UseStaticFiles** extension, the meaning of this extension is exposing the **node_modules** directory. As a result a request can access the **jquery** package.

22. In the Solution Explorer pane of the **JSLibraryExample – Microsoft Visual Studio** window, expand **Views**, expand **Shared**, and then click **_Layout.cshtml**.

23. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

24. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/node_modules/jquery/dist/jquery.min.js"></script>
       <script src="~/js/jquery-function.js"></script>
```

25. In the Solution Explorer pane of the **JSLibraryExample – Microsoft Visual Studio** window, expand **Controllers**, and then click **HomeController.cs**.

26. In the **HomeController.cs** code window, locate the following code, right-click the code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

27. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Index**.

28. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

29. In the **Add MVC View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

30. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

31. Replace the selected code with the following code: 
  ```cs
       <div>
            <h1> Use NPM to Add a JavaScript Library </h1>
            <button id="btn-jquery-func"> Run JQuery Function </button>
            <div class="box"> jquery animation </div>
       </div>
```

>**Note:** This code block contains **CSS id Selector** and **CSS class Selector**.

32. In the Solution Explorer pane of the **JSLibraryExample - Microsoft Visual Studio** window, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

33. In the **NewFolder** text box, type **css**, and then press Enter.

34. In the Solution Explorer pane of the **JSLibraryExample – Microsoft Visual Studio** window, under **wwwroot**, right-click **css**, point to **Add**, and then click **New Item**.

35. In the **Add New Item – LayoutExample** dialog box, click **Web**, and then, in the result pane, click **Style Sheet**.

36. In the **Name** box of the **Add New Item – JSLibraryExample** dialog box, type **style-js-example**, and then click **Add**.

37. In the **style-js-example** code window, select the following code: 
  ```cs
       body {
       }
```

38. Replace the selected code with the following code:
  ```cs
       body {
          text-align: center;
       }

       h1 {
          color: #1B5E20;
          font-family: "Libre Baskerville", serif;
          font-size: 45px;
          font-weight: bolder;
          text-align: center;
       }

       #btn-jquery-func {
          font-size: 20px;
       }

       .box {
          width: 150px;
          height: 150px;
          background: #81C784;
          margin-top: 30px;
          margin-left: 150px;
          margin-right: auto;
          border-style: solid;
          border-color: #388E3C;
          font-size: x-large;
          font-weight: bold;
       }

```

39. In the Solution Explorer pane of the **JSLibraryExample – Microsoft Visual Studio** window, under **Views**, under **Shared**, and then click **_Layout.cshtml**.

40. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <script src="~/js/jquery-function.js"></script>
```

41. Place the cursor after the **>** (greater than) sign of the **&lt;/script&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link href="~/css/style-js-example.css" rel="stylesheet" />
```

>**Note:** This line of code represents a link between the **Layout** to the **Style Sheet**.

42. On the **FILE** menu of the **JSLibraryExample - Microsoft Visual Studio** window, click **Save All**.

43. On the **DEBUG** menu of the **JSLibraryExample - Microsoft Visual Studio** window, click **Start Without Debugging**.

      >**Note:** In the Microsoft Edge window, click **Run JQuery Function** button to verify that **jQuery** package added correctly using **NPM**.
      
44. In **Microsoft Edge**, click **Close**.

45. On the **FILE** menu of the **JSLibraryExample - Microsoft Visual Studio** window, click **Exit**.

# Lesson 3: Using jQuery

### Demonstration: How to Modify HTML Elements using jQuery

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod08\Democode\03_JQueryExample_begin**, and then double-click **JQueryExample.sln**.

2. In the **JQueryExample - Microsoft Visual Studio** window, in the **Solution Explorer**, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** text box, type **js**, and then press Enter.

4. In the **JQueryExample – Microsoft Visual Studio** window, in the **Solution Explorer**, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

5. In the **Add New Item – JQueryExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

6. In the **Add New Item – JQueryExample** dialog box, in the **Name** text box, type **jquery-functions**, and then click **Add**.

7. In the **jquery-functions** code window, type the following code: 
  ```cs
       var passingGrade = 55;
       $(function () {
           $("#jqueryButton").click(function (event) {
                var firstGrade = parseInt($("#studentGrade1").text());
                var secondGrade = parseInt($("#studentGrade2").text());
                var thirdGrade = parseInt($("#studentGrade3").text());

                if (firstGrade > passingGrade) {
                    $("#studentGrade1").addClass("goodGrade");
                } else {
                    $("#studentGrade1").addClass("badGrade");
                }

                if (secondGrade > passingGrade) {
                    $("#studentGrade2").addClass("goodGrade");
                } else {
                    $("#studentGrade2").addClass("badGrade");
                }

                if (thirdGrade > passingGrade) {
                    $("#studentGrade3").addClass("goodGrade");
                } else {
                    $("#studentGrade3").addClass("badGrade");
                }
           });
       });
```

8. In the **JQueryExample - Microsoft Visual Studio** window, in the **Solution Explorer**, expand **Views**, expand **Shared**, and then click **_Layout.cshtml**.

9. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <link href="~/css/style-jquery-example.css" rel="stylesheet" />
```

10. Place the cursor after the **>** (greater than) sign of the **link** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/js/jquery-functions.js"></script>
```

11. In the **JQueryExample - Microsoft Visual Studio** window, in the **Solution Explorer**, expand **Controllers**, and then click **GradeBookController.cs**.

12. In the **GradeBookController.cs** code window, locate the following code, right-click the code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

13. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Index**.

14. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

15. In the **Add MVC View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

16. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

17. Replace the selected code with the following code: 
  ```cs
       <h1>Students GradeBook</h1>
       <h2>Course Name: Mathematics and Computer Science</h2>

       <div>
          <table>
             <thead>
             </thead>
             <tbody>
             </tbody>
          </table>
       </div>
       <button id="jqueryButton">Apply JQuery</button>
```

18. Place the cursor in the **THEAD** element, press Enter, and then type the following code: 
  ```cs
       <tr>
           <th>
              Student Name
           </th>
           <th>
              Mid-Term
           </th>
           <th>
              Performance
           </th>
           <th>
              Final Grade
           </th>
       </tr>
```

19. Place the cursor in the **TBODY** element, press Enter, and then type the following code: 
  ```cs
       <tr>
           <td>Thomas M. Hacker</td>
           <td>93</td>
           <td>95%</td>
           <td id="studentGrade1">90</td>
       </tr>
       <tr>
           <td>Patrick J. Lazo</td>
           <td>53</td>
           <td>51%</td>
           <td id="studentGrade2">50</td>
       </tr>
       <tr>
           <td>Helen D. Miller</td>
           <td>91</td>
           <td>95%</td>
           <td id="studentGrade3">85</td>
       </tr>
```

20. On the **FILE** menu of the **JQueryExample - Microsoft Visual Studio** window, click **Save All**.

21. On the **DEBUG** menu of the **JQueryExample - Microsoft Visual Studio** window, click **Start Without Debugging**.

      >**Note:** In the Microsoft Edge window, click **Apply JQuery** button to verify that **jQuery** function implemented correctly in the application.
      
22. In **Microsoft Edge**, click **Close**.

23. On the **FILE** menu of the **JQueryExample - Microsoft Visual Studio** window, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.