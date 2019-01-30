# Module 8: Using Layouts, CSS and JavaScript in ASP.NET Core MVC

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lesson 1: Using Layouts

### Demonstration: How to Create a Layout and Link it to a View

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod08\Democode\01_LayoutExample_begin**, and then double-click **LayoutExample.sln**.

    >**Note**: If a **Security Warning for LayoutExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **LayoutExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Item**.

3. In the **Add New Item – LayoutExample** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

4. In the **Add New Item – LayoutExample** dialog box, in the result pane, click **Razor View Start**, and then click **Add**.

5. In the **LayoutExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Folder**.

6. In the **NewFolder** box, type **Shared**, and then press Enter.

7. In the **LayoutExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

8. In **Add New Item – LayoutExample** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

9. In the **Add New Item – LayoutExample** dialog box, in the result pane, click **Razor Layout**, and then click **Add**.

10. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

11. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link type="text/css" rel="stylesheet" href="~/css/style-layout-example.css" />
```

12. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

13. Place the cursor before the **<** (less than) sign of the **&lt;div&gt;** tag, press Enter, press the Up Arrow key, and then type the following code:
  ```cs
       <h1>Welcome to the University</h1>
```

14. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

15. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code: 
  ```cs
       @RenderSection("footer", false)
```

16. In Solution Explorer, expand **Controllers**, and then click **StudentController.cs**.

17. In the **StudentController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

18. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.  

19. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

20. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is cleared and the **Use a layout page** check box is selected, and then click **Add**.

21. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model IEnumerable<Student>
```
22. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

23. Replace the selected code with the following code: 
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
24. In Solution Explorer, under **Controllers**, click **StudentController.cs**.

25. In the **StudentController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Details(int? id)
```

26. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Details**.  

27. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

28. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is cleared and the **Use a layout page** check box is selected, and then click **Add**.

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
       @section footer {
            <div>
                <a asp-action="Index">Back to List</a>
            </div>
       }
```

32. In the **Details.cshtml** code window, locate the following code:
  ```cs
       @section footer {
            <div>
                <a asp-action="Index">Back to List</a>
            </div>
       }
```

33. Place the cursor after the **}** (closing brace) sign, press Enter twice, and then type the following code: 
  ```cs
       <h2>Student details</h2>

       <div>
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

34. In the **LayoutExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

35. In the **LayoutExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: The browser displays the **Index.cshtml** file combined with the **_Layout.cshtml** file.

36. On the **Welcome to the University** page, select a student of your choice, and then click **Details**.

37. On the **Student details** page, examine the student details, and then click **Back to List**.
      
38. In Microsoft Edge, click **Close**.

39. In the **LayoutExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using CSS and JavaScript

### Demonstration: How to Use npm to Add a Library

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod08\Democode\02_NpmExample_begin**, and then double-click **NpmExample.sln**.

    >**Note**: If a **Security Warning for NpmExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **NpmExample**, point to **Add**, and then click **New Item**.

3. In the **Add New Item - NpmExample** dialog box, in the search box, type **npm**, and then press Enter.

4. In the **Add New Item - NpmExample** dialog box, click **npm Configuration File**, and then click **Add**.

5. In the **package.json** file, locate the following code:
  ```cs
        "devDependencies": {
        }
```
6. Place the cursor after the **}** (closing brace) sign, and then type the following code:
  ```cs
        ,
        "dependencies": {
            "jquery": "3.3.1"
        }
```

7. In the **NpmExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save package.json**.

8. Wait for the **Microsoft Visual Studio** dialog box to appear, and then click **Yes to All**.

    >**Note**: In Solution Explorer, under **Dependencies**, a new folder named **npm** has been added, which contains the **jquery** package.

9. In the Solution Explorer menu bar, click **Show All Files**.

      >**Note**: In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, a new folder named **node_modules** has been added, which contains the **jquery** package.
      
10. In Solution Explorer, right-click **NpmExample**, point to **Add**, and then click **New Folder**.

11. In the **NewFolder** box, type **Middleware**, and then press Enter.

12. In Solution Explorer, right-click **Middleware**, point to **Add**, and then click **Class**.

13. In the **Add New Item – NpmExample** dialog box, in the **Name** box, type **ApplicationBuilderExtensions**, and then click **Add**.

14. In the **ApplicationBuilderExtensions.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
15. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using System.IO;
       using Microsoft.AspNetCore.Builder;
       using Microsoft.Extensions.FileProviders;
```

16. In the **ApplicationBuilderExtensions.cs** code window, select the following code:
  ```cs
      public class ApplicationBuilderExtensions
```

17.  Replace the selected code with the following code:
  ```cs
      public static class ApplicationBuilderExtensions
```

18. In the **ApplicationBuilderExtensions.cs** code block, place the cursor after the second **{** (opening brace) sign, press Enter, and then type the following code:
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
19. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

20. In the **Startup.cs** code window, locate the following code:
  ```cs
       using Microsoft.Extensions.DependencyInjection;
```
21. Ensure that the cursor is at the end of the **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
       using NpmExample.Middleware;
```

22. In the **Startup.cs** code window, locate the following code: 
  ```cs
       public void Configure(IApplicationBuilder app, IHostingEnvironment env)
       {
```

23. Place the cursor after the located code, press Enter, type the following code, and then press Enter.
  ```cs
       app.UseStaticFiles();

       app.UseNodeModules(env.ContentRootPath);
```

24. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Shared**, and then click **_Layout.cshtml**.

25. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

26. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/node_modules/jquery/dist/jquery.min.js"></script>
       <script src="~/js/jquery-function.js"></script>
```

27. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **HomeController.cs**.

28. In the **HomeController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

29. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.  

30. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

31. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is cleared and the **Use a layout page** check box is selected, and then click **Add**.

32. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

33. Replace the selected code with the following code: 
  ```cs
       <div>
            <h1>Use npm to Add a Library</h1>
            <button id="btn-jquery-func">Run jQuery Function</button>
            <div class="box"></div>
       </div>
```

34. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

35. In the **NewFolder** box, type **css**, and then press Enter.

36. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **css**, point to **Add**, and then click **New Item**.

37. In the **Add New Item – NpmExample** dialog box, click **Web**, and then, in the result pane, click **Style Sheet**.

38. In the **Add New Item – NpmExample** dialog box, in the **Name** box, type **style-example**, and then click **Add**.

39. In the **style-example.css** code window, select the following code: 
  ```cs
       body {
       }
```

40. Replace the selected code with the following code:
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

41. In the **NpmExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Shared**, click **_Layout.cshtml**.

42. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <script src="~/js/jquery-function.js"></script>
```

43. Place the cursor after the **>** (greater than) sign of the **&lt;/script&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link href="~/css/style-example.css" rel="stylesheet" />
```

44. In the **NpmExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

45. In the **NpmExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

46. In Microsoft Edge, click **Run jQuery Function**.
      
47. In Microsoft Edge, click **Close**.

48. In the **NpmExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Using jQuery

### Demonstration: How to Modify HTML Elements by using jQuery

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. In the **File Explorer**, navigate to **[Repository Root]\Allfiles\Mod08\Democode\03_JQueryExample_begin\JQueryExample**, copy the address in the address bar.

2. Go to **Start** type **cmd**, and then press Enter.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd**  *{copied folder path}* command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown at the command prompt you can ignore them.

7. Close the window.

8. In the **File Explorer**, navigate to **[Repository Root]\Allfiles\Mod08\Democode\03_JQueryExample_begin** and then double-click **JQueryExample.sln**.

    >**Note**: If a **Security Warning for JQueryExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **JQueryExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

    >**Note:** In **Solution Explorer**, under **Dependencies**, a new folder named **npm** has been added which contains the **jquery** package as a result of executing the command **npm install**.

10. In the **NewFolder** text box, type **js**, and then press Enter.

11. In the **JQueryExample – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

12. In the **Add New Item – JQueryExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

13. In the **Add New Item – JQueryExample** dialog box, in the **Name** box, type **jquery-functions**, and then click **Add**.

14. In the **jquery-functions.js** code window, type the following code: 
  ```cs
       var passingGrade = 55;
       $(function() {
           $("#jqueryButton").click(function (event) {
                var firstGrade = parseInt($("#studentGrade1").text());
                var secondGrade = parseInt($("#studentGrade2").text());
                var thirdGrade = parseInt($("#studentGrade3").text());

                if (firstGrade > passingGrade) {
                    $("#studentGrade1").addClass("goodGrade");
                } 
                else {
                    $("#studentGrade1").addClass("badGrade");
                }

                if (secondGrade > passingGrade) {
                    $("#studentGrade2").addClass("goodGrade");
                } 
                else {
                    $("#studentGrade2").addClass("badGrade");
                }

                if (thirdGrade > passingGrade) {
                    $("#studentGrade3").addClass("goodGrade");
                } 
                else {
                    $("#studentGrade3").addClass("badGrade");
                }
           });
       });
```

15. In the **JQueryExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Shared**, and then click **_Layout.cshtml**.

16. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <link href="~/css/style-example.css" rel="stylesheet" />
```

17. Place the cursor after the **>** (greater than) sign of the **link** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/js/jquery-functions.js"></script>
```

18. In the **JQueryExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **GradeBookController.cs**.

19. In the **GradeBookController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

20. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.  

21. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

22. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** box is cleared and the **Use a layout page** check box is selected, and then click **Add**.

23. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

24. Replace the selected code with the following code: 
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

25. Place the cursor in the **THEAD** element, press Enter, and then type the following code: 
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

26. Place the cursor in the **TBODY** element, press Enter, and then type the following code: 
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

27. In the **JQueryExample – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

28. In the **JQueryExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

29. In Microsoft Edge, click **Apply JQuery**.
      
30. In Microsoft Edge, click **Close**.

31. In the **JQueryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.