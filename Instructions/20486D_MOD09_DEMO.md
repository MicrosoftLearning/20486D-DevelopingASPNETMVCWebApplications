# Module 9: Client-Side Development

# Lesson 1: Applying Styles

### Demonstration: How to Work with Bootstrap 

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. Navigate to **Allfiles\Mod09\Democode\01_BootstrapExample_begin**, and then double-click **BootstrapExample.sln**.

2. In the **BootstrapExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Views**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** text box, type **Shared**, and then press Enter.

4. In the **BootstrapExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

5. In the **Add New Item – BootstrapExample** dialog box, click **Web**, and then, in the result pane, click **Razor Layout**, and click **Add**.

6. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

7. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css">
       <link href="~/css/style.css" rel="stylesheet" />
```

8. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

9. Place the cursor before the **<** (less then) sign of the **&lt;div&gt;** tag, press Enter, press the Up Arrow key, and then type the following code:
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

10. In the **_Layout.cshtml** code window, in the **UL** element, type the following code:
  ```cs
       <li class="nav-item active">
           <a class="nav-link" href="@Url.Action("Index", "Library")">Home <span class="sr-only">(current)</span></a>
       </li>
       <li class="nav-item dropdown">
           <a href="#" class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               Genres
           </a>
           <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
               <a class="dropdown-item" href="@Url.Action("GetScienceFictionBooks", "Library")">Science fiction</a>
               <a class="dropdown-item" href="@Url.Action("GetDramaBooks", "Library")">Drama</a>
           </div>
       </li>
```

11. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

12. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code: 
  ```cs
       <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
       <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
       <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
       <script src="~/js/alert-function.js"></script>
```

13. In the **_Layout.cshtml** code window, select the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

14. Replace the selected code with the following code:
  ```cs
       <div class="container">
           @RenderBody()
       </div>
```

15. In the **BootstrapExample - Microsoft Visual Studio** window, in the **Solution Explorer**, expand **Controllers**, and then click **LibraryController.cs**.

16. In the **LibraryController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

17. In the **Add MVC View** dialog box, ensure that the name in the **View name** text box is **Index**.

18. In the **Template** selector, ensure that the template in the **Template** text box is **Empty(without model)**.

19. In the **Add MVC View** dialog box, ensure that the **Reference script libraries** check box is not selected.

      >**Note:** In the **Add MVC View** dialog box, the **Reference script libraries** checkbox can be edited by setting the **Template** to **Edit**.

20. In the **Add MVC View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

21. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

22. Replace the selected code with the following code:
  ```cs
       <div class="text-center">
           <h1>Welcome to Open Library </h1>
           <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
               Launch modal example
           </button>
       </div>
``` 

23. In the **Index.cshtml** code window, place the cursor immediately after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code:
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

24. In the **BootstrapExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

25. In the **Add New Item – BootstrapExample** dialog box, click **Web**, and then, in the result pane, click **Razor View**.

26. In the **Name** text box of the **Add New Item – BootstrapExample** dialog box, type **_Alert**, and then click **Add**.

27. In the **_Alert.cshtml** code window, select the following code:
  ```cs
       @*
          For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
       *@
       @{
       }
```

28. Replace the selected code with the following code:
  ```cs
       <section>
           <h2 class="m-2">Did you like the book you borrowed? </h2>
           <button type="button" class="btn btn-outline-success">Yes</button>
           <button type="button" class="btn btn-outline-danger">No</button>
           <div id="alert" class="alert alert-success alert-dismissible fade show m-3" role="alert">
           </div>
       </section>
```

29. In the **DIV** element of the **_Alert.cshtml** code window, type the following code:
  ```cs
       <strong>Thank you for the response!</strong>
       We will take this into consideration the next time we recommend you a book.
       <button type="button" class="close" aria-label="Close">
           <span aria-hidden="true">&times;</span>
       </button>
```
30. In the **BootstrapExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

31. In the **BootstrapExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

32. In the **Home** page, click **Lunch modal example**, and then click **Close**.

33. In the menu bar click **Genres**, and then click **Drama**. 

34. In the **Drama Books** page, click **Yes**, and examine the **alert** that appears.

      >**Note:** Press the **X** close button in order to close the alert

35. In **Microsoft Edge**, click **Close**.

36. In the **BootstrapExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

37. In the **BootstrapExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Using Task Runners

### Demonstration: How to Use gulp to Compile SASS File to CSS

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. Open the **Start bar** and type **visual studio**, under **Apps**, right-click **visual studio 2017**, and then click **Run as administrator**.

2. In the **User Account Control** dialog box, click **Yes**.

3. In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **Open**, and then click **Project/Solution**.

4. Navigate to **Allfiles\Mod09\Democode\02_GulpExample_begin**, and then double-click **GulpExample.sln**.

5. In the **GulpExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

      >**Note:** The browser displays the **Index.cshtml** view without css.

6. In **Microsoft Edge**, click **Close**.

7. In the **GulpExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

8. In the **GulpExample - Microsoft Visual Studio** window, on the **Tools** menu, click **Options**.

9. In the **Options** dialog box, in the **search** text box type **Web Package Management**, and then press Enter.

10. In the **Locations of external tools** box, of the **Options** dialog box, select **$(PATH)**, press the **Ap arrow** button until the selected **$(PATH)** is at the top of the list, and then click **Ok**.

11. In the **GulpExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **GulpExample**, point to **Add**, and then click **New Item**.

12. In the **Add New Item - GulpExample** dialog box, in the **search** text box type **npm**, and then press Enter.

13. In the **Add New Item - GulpExample** dialog box, click **npm Configuration File**, and then click **Add**.

14. In the **package.json** code window, locate the following code:
  ```cs
       "devDependencies": {
       }
```
15. Place the cursor after the **{** (opening bracket) sign, press Enter, and type the following code:
  ```cs
       "gulp": "3.9.1",
       "gulp-sass": "4.0.1"
```
16. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save package.json**.

>**Note:** In the **Solution Explorer** pane, under **Depenndencies**, a new folder has been added named **npm** with **gulp** and **gulp-sass** packages.

17. In the **GulpExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **PhotoBook**, and then click **Index.cshtml**.

18. In the **Index.cshtml** code window, examine the code, and ensure there are no links to **css** files.

19. In the **GulpExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **GulpExample**, point to **Add**, and then click **New Folder**.

20. In the **NewFolder** text box, type **Styles**, and then press Enter.

21. In the **GulpExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Styles**, point to **Add**, and then click **New Item**.

22. In the **Add New Item - GulpExample** dialog box, in the **search** text box type **scss**, and then press Enter.

23. In the **Add New Item - GulpExample** dialog box, click **SCSS Style Sheet (SASS)**.

24. In the **Add New Item – GulpExample** dialog box, in the **Name** text box, type **main**, and then click **Add**. 

25. In the **main.scss** code window, select the following code: 
  ```cs
       body {
       }
```
26. Replace the selected code with the following code:
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
            margin-left: 90px;
       }
```
27. Place the cursor immediately after the last typed **}** (closing bracket) sign, press Enter, and then type the following code:
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
28. In the **GulpExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **GulpExample**, point to **Add**, and then click **New Item**.

29. In the **Add New Item - GulpExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

30. In the **Add New Item - GulpExample** dialog box, in the **Name** text box, type **gulpfile**, and then click **Add**.

31. In the **gulpfile.js** code window, type the following code:
  ```cs
       var gulp = require('gulp');
       var sass = require('gulp-sass');


       gulp.task("sass", function () {
           return gulp.src('Styles/main.scss')
               .pipe(sass())
               .pipe(gulp.dest('wwwroot/css'));
       });
```
32. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

33. In the **GulpExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **gulpfile.js**, and then click **Task Runner Explorer**.

34. In the **Task Runner Explorer** pane, under **Tasks**, right-click **sass**, and then click **Run**.

>**Note:** In the Solution Explorer pane, under **wwwroot**, a new folder has been added named **css** with compiled SASS File to CSS named **main.css**.

35. In the **GulpExample - Microsoft Visual Studio** window, in the **Solution Explorer**, under **Views**, under **PhotoBook**, click **Index.cshtml**.

36. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <title>Index</title>
```
37. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link type="text/css" href="~/css/main.css" rel="stylesheet" />
```
38. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

39. In the **GulpExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

      >**Note:** The browser displays the **Index.cshtml** view with **css** style.

40. In **Microsoft Edge**, click **Close**.

41. In the **GulpExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

42. In the **GulpExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.