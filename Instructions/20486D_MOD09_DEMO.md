# Module 9: Client-Side Development

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lesson 1: Applying Styles

### Demonstration: How to Work with Bootstrap 

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. In the **File Explorer**, navigate to **[Repository Root]\Allfiles\Mod09\Democode\01_BootstrapExample_begin\BootstrapExample**, and then copy the address in the address bar.

2. Select the **Start** button, and then type **cmd**.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd** *{copied folder path}* command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown in the command prompt you can ignore them.

7. Close the window.

8. In the **File Explorer**, navigate to **[Repository Root]\Allfiles\Mod09\Democode\01_BootstrapExample_begin**, and then double-click **BootstrapExample.sln**.

    >**Note**: If a **Security Warning for BootstrapExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **BootstrapExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Folder**.

10. In the **NewFolder**  box, type **Shared**, and then press Enter.

11. In the **BootstrapExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

12. In the **Add New Item – BootstrapExample** dialog box, click **Web**, in the result pane, click **Razor Layout**, and then click **Add**.

13. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

14. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link href="~/node_modules/bootstrap/dist/css/bootstrap.css" rel="stylesheet" />
       <link href="~/css/style.css" rel="stylesheet" />
```

15. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <body>
             <div>
                @RenderBody()
             </div>
       </body>
```

16. In the **_Layout.cshtml** code window, place the cursor after the **>** (greater than) sign of the **&lt;body&gt;** tag, press Enter, and then type the following code:
  ```cs
       <div>
           <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
           <span class="navbar-brand mb-0 h1">Your Book Library</span>
           <div class="collapse navbar-collapse" id="navbarNavDropdown">
               <ul class="navbar-nav">
               </ul>
            </div>
        </nav>
       </div>
```

17. In the **_Layout.cshtml** code window, in the **UL** element, type the following code:
  ```cs
       <li class="nav-item active">
           <a class="nav-link" href="@Url.Action("Index", "Library")">Home <span class="sr-only">(current)</span></a>
       </li>
       <li class="nav-item dropdown">
           <a href="#" class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               Genres
           </a>
           <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
               <a class="dropdown-item" href="@Url.Action("GetScienceFictionBooks", "Library")">Science Fiction</a>
               <a class="dropdown-item" href="@Url.Action("GetDramaBooks", "Library")">Drama</a>
           </div>
       </li>
```

18. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

19. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code: 
  ```cs
       <script src="~/node_modules/jquery/dist/jquery.js"></script>
       <script src="~/node_modules/popper.js/dist/umd/popper.js"></script>
       <script src="~/node_modules/bootstrap/dist/js/bootstrap.js"></script>
       <script src="~/js/alert-function.js"></script>
```

20. In the **_Layout.cshtml** code window, select the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

21. Replace the selected code with the following code:
  ```cs
       <div class="view-container">
           @RenderBody()
       </div>
```

22. In the **BootstrapExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **LibraryController.cs**.

23. In the **LibraryController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

24. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.

25. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

26. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is cleared and the **Use a layout page** check box is selected, and then click **Add**.

27. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

28. Replace the selected code with the following code:
  ```cs
       <div class="text-center">
           <h1>Welcome to Open Library </h1>
           <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
               Launch Modal Example
           </button>
       </div>
``` 

29. In the **Index.cshtml** code window, place the cursor immediately after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code:
  ```cs
       <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
           <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Your Book Library</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Welcome to the book library
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
           </div>
       </div>
```

30. In the **BootstrapExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

31. In the **Add New Item – BootstrapExample** dialog box, click **Web**, and then, in the result pane, click **Razor View**.

32. In the **Add New Item – BootstrapExample** dialog box, in the **Name** box, type **_Alert**, and then click **Add**. 

33. In the **_Alert.cshtml** code window, select the following code:
  ```cs
       @*
          For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
       *@
       @{
       }
```

34. Replace the selected code with the following code:
  ```cs
       <section>
           <h2 class="m-2">Did you like the book you borrowed? </h2>
           <button type="button" class="btn btn-outline-success">Yes</button>
           <button type="button" class="btn btn-outline-danger">No</button>
           <div id="alert" class="alert alert-success alert-dismissible fade show m-3" role="alert">
           </div>
       </section>
```

35. In the **_Alert.cshtml** code window, in the **DIV** element, type the following code:
  ```cs
       <strong>Thank you for the response!</strong>
       We will take this into consideration the next time we recommend you a book.
       <button type="button" class="close" aria-label="Close">
           <span aria-hidden="true">&times;</span>
       </button>
```

36. In the **BootstrapExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

37. In the **BootstrapExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

38. In the **Home** page, click **Launch Modal Example**, and then click **Close**.

39. In the menu bar, click **Genres**, and then click **Drama**. 

40. In the **Drama Books** page, click **Yes**.

      >**Note**: Examine the alert that appears.
      
41. To close the alert, press the **X** close button.

42. In the menu bar, click **Genres**, and then click **Science Fiction**. 

43. In the **Science Fiction Books** page, click **No**.

      >**Note**: Examine the alert that appears.
      
44. To close the alert, press the **X** close button.

45. In Microsoft Edge, click **Close**.

46. In the **BootstrapExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using Task Runners

### Demonstration: How to Use gulp to Compile Sass to CSS

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. In the **File Explorer**, navigate to **[Repository Root]\Allfiles\Mod09\Democode\02_GulpExample_begin\GulpExample**, and then copy the address in the address bar.

2. Select the **Start** button, and then type **cmd**.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd** *{copied folder path}* command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown in the command prompt you can ignore them.

7. Close the window.

8. Navigate to **[Repository Root]\Allfiles\Mod09\Democode\02_GulpExample_begin**, and then double-click **GulpExample.sln**.

    >**Note**: If a **Security Warning for GulpExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **GulpExample - Microsoft Visual Studio** window, on the **TOOLS** menu, click **Options**.

10. In the **Options** dialog box, in the **Search Options** box, type **Web Package Management**, and then press Enter.

11. In the **Locations of external tools** list box, select **$(PATH)**, press the Up arrow button until **$(PATH)** is at the top of the list, and then click **OK**.

12. In the **GulpExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: The browser displays a page which is not designed by a CSS.

13. In Microsoft Edge, click **Close**.

14. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, click **package.json**.

15. In the **package.json** code window, examine the code.

      >**Note**: The **gulp** and **gulp-sass** packages appear in the **devDependencies** section.

16. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **PhotoBook**, and then click **Index.cshtml**.

17. In the **Index.cshtml** code window, examine the code. 

      >**Note**: Currently there are no links to CSS files.

18. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **GulpExample**, point to **Add**, and then click **New Folder**.

19. In the **NewFolder** box, type **Styles**, and then press Enter.

20. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Styles**, point to **Add**, and then click **New Item**.

21. In the **Add New Item - GulpExample** dialog box, in the search box, type **scss**, and then press Enter.

22. In the **Add New Item - GulpExample** dialog box, click **SCSS Style Sheet (SASS)**.

23. In the **Add New Item – GulpExample** dialog box, in the **Name** box, type **main**, and then click **Add**. 

24. In the **main.scss** code window, select the following code: 
  ```cs
       body {
       }
```
25. Replace the selected code with the following code:
  ```cs
       $highlights: #124eab;
       $main-color: #1395f4;

       @mixin normalized-text() {
            font-family: Arial;
       }

       h1 {
            color: $highlights;
            @include normalized-text();
            font-size: 40px;
            text-shadow: 0px 2px 5px #aba8a8;
            font-weight: bolder;
            text-align: left;
            margin-left: 55px;
       }
```
26. Place the cursor immediately after the last typed **}** (closing bracket) sign, press Enter, and then type the following code:
  ```cs
       div {
            color: darken($main-color, 20%);
            margin: 21px 5px 15px 18px;
            padding-bottom: 95px;
            width: 455px;
            border: 5px solid #d6d4d4;
            border-radius: 10px;
            height: 210px;

            img {
                width: 100%;
            }

            h3 {
                @include normalized-text();
                font-size: 25px;
                position: relative;
                margin-top: -43px;
                background-color: lighten($main-color, 35%);
                text-align:center;
            }
       }
```
27. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **GulpExample**, point to **Add**, and then click **New Item**.

28. In the **Add New Item - GulpExample** dialog box, click **Web**, and then in the result pane, click **JavaScript File**.

29. In the **Add New Item - GulpExample** dialog box, in the **Name** box, type **gulpfile**, and then click **Add**.

30. In the **gulpfile.js** code window, type the following code:
  ```cs
       var gulp = require('gulp');
       var sass = require('gulp-sass');


       gulp.task("sass", function() {
           return gulp.src('Styles/main.scss')
               .pipe(sass())
               .pipe(gulp.dest('wwwroot/css'));
       });
```
31. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

32. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **gulpfile.js**, and then click **Task Runner Explorer**.

      >**Note**: If the **sass** task doesn't appear in the **Tasks** list, click **Refresh**.

33. In the **Task Runner Explorer** pane, under **Tasks**, right-click **sass**, and then click **Run**.

      >**Note**: In Solution Explorer, under **wwwroot**, a new folder has been added named **css** which contains a CSS file named **main.css**.

34. In the **GulpExample - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **PhotoBook**, click **Index.cshtml**.

35. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <title>Index</title>
```
36. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link type="text/css" href="~/css/main.css" rel="stylesheet" />
```
37. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

38. In the **GulpExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: The browser displays a page which is designed by using CSS.

39. In Microsoft Edge, click **Close**.

40. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Responsive Design

### Demonstration: How to Use the Bootstrap Grid System

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. In the **File Explorer**, navigate to **[Repository Root]\Allfiles\Mod09\Democode\03_GridExample_begin\GridExample**, and then copy the address in the address bar.

2. Select the **Start** button, and then type **cmd**.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd** *{copied folder path}* command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown in the command prompt you can ignore them.

7. Close the window.

8. Navigate to **[Repository Root]\Allfiles\Mod09\Democode\03_GridExample_begin**, and then double-click **GridExample.sln**.

    >**Note**: If a **Security Warning for GridExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **GridExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **ChessController.cs**.

10. In the **ChessController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

11. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.

12. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

13. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** and the **Use a layout page** check boxes are cleared, and then click **Add**.

14. In the **Index.cshtml** code window, locate the following code:
  ```cs
       @{
          Layout = null;
       }
```

15. Place the cursor before the **@** (at) sign, press the Up arrow key, type the following code, and then press Enter.
  ```cs
       @model IEnumerable<GridExample.Models.Game>
```

16. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <title>Index</title>
```

17. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link href="~/node_modules/bootstrap/dist/css/bootstrap.css" rel="stylesheet" />
       <link href="~/css/style.css" rel="stylesheet" />
```

18. In the **Index.cshtml** code window,  in the **BODY** element, type the following code:
  ```cs
       <div class="title">
           <h1>Chess League</h1>
           <p>Hey, These are the Results</p>
       </div>    
```

19. Place the cursor immediately after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code:
  ```cs
       <div class="container">
           <div class="row grid-header align-items-center">
                <div class="col-2">
                </div>
                <div class="col-4">
                    Competitors
                </div>
                <div class="col-3">
                    Quantity
                </div>
                <div class="col-3">
                    Results
                </div>
           </div>
           <div class="row align-items-center">
                @foreach (var item in Model)
                {
                }
           </div>
       </div>    
```

20. Place the cursor in the **FOREACH** code block, press Enter, and then type the following code:
  ```cs
       <div class="col-2">
           <div class="row justify-content-center">
                <img src="~/images/@item.FirstCompetitorPhotoFileName" />
           </div>
           <div class="row justify-content-center">
                <img src="~/images/@item.SecondCompetitorPhotoFileName" />
           </div>
       </div>
       <div class="col-4">
           <div class="row">
                @Html.DisplayFor(model => item.FirstCompetitorName)
           </div>
           <div class="row">
                @Html.DisplayFor(model => item.SecondCompetitorName)
           </div>
       </div>
       <div class="col-3">
           @Html.DisplayFor(model => item.GamesQuantity)
       </div>
       <div class="col-3">
           @Html.DisplayFor(model => item.FinalScore)
       </div>  
```

21. Place the cursor before the **<** (less than) sign of the **&lt;/body&gt;** tag, press Enter twice, press the Up arrow key, and then type the following code:
  ```cs
       <script src="~/node_modules/jquery/dist/jquery.js"></script>
       <script src="~/node_modules/popper.js/dist/umd/popper.js"></script>
       <script src="~/node_modules/bootstrap/dist/js/bootstrap.js"></script>
```

22. In the **GridExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

23. In the **GridExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: The browser displays a page which is designed by using the **Bootstrap grid system**.

24. In Microsoft Edge, click **Close**.

25. In the **GridExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.