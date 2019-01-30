# Module 9: Client-Side Development

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Client-Side Development

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Using gulp to Run Tasks 

#### Task 1: Use npm to install gulp

1. In the File Explorer, navigate to **[Repository Root]\Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin\IceCreamCompany**, and then copy the address in the address bar.

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
>**Note**: If warning messages are shown at the command prompt you can ignore them.

7. Close the window.

8. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin**, and then double-click **IceCreamCompany.sln**.

    >**Note**: If a **Security Warning for IceCreamCompany** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **TOOLS** menu, click **Options**.

10. In the **Options** dialog box, in the **Search Options** box, type **Web Package Management**, and then press Enter.

11. In the **Locations of external tools** list box, select **$(PATH)**, press the Up arrow button until **$(PATH)** is at the top of the list, and then click **OK**.

12. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, click **package.json**.

13. Examine the **package.json** code window.

      >**Note**: There are dependencies to the **gulp**, **gulp-concat**, **gulp-cssmin**, **gulp-sass**, **gulp-uglify** packages appear in the **devDependencies** section and **bootstrap**, **hoek**, **jquery**, **lodash**, **popper.js** packages appear in the **Dependencies** section.

#### Task 2: Write a task to copy a JavaScript file

1. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **IceCreamCompany**, point to **Add**, and then click **New Item**.

2. In the **Add New Item - IceCreamCompany** dialog box, click **Web**, and then in the result pane, click **JavaScript File**.

3. In the **Add New Item - IceCreamCompany** dialog box, in the **Name** box, type **gulpfile**, and then click **Add**.

4. In the **gulpfile.js** code window, type the following code:
  ```cs
       var gulp = require('gulp');

       var paths = {
           webroot: "./wwwroot/",
           nodeModules: "./node_modules/"
       };

       paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
       paths.destinationjsFolder = paths.webroot + "scripts/";

       gulp.task("copy-js-file", function() {
           return gulp.src(paths.jqueryjs)
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```

#### Task 3: Run the task

1. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **gulpfile.js**, and then click **Task Runner Explorer**.

      >**Note**: If the **Tasks** list does not contain a task named **copy-js-file**, click **Refresh**.

3. In **Task Runner Explorer**, under **Tasks**, right-click **copy-js-file**, and then click **Run**.

    >**Note**: In Solution Explorer, under **wwwroot**, a new folder has been added named **scripts** with a JavaScript file named **jquery.js**

#### Task 4: Write a task to minify a JavaScript file

1. In the **gulpfile.js** code window, locate the following code:
  ```cs
       var gulp = require('gulp');
```
2. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       var concat = require('gulp-concat');
       var uglify = require('gulp-uglify');
```

3. In the **gulpfile.js** code window, locate the following code: 
  ```cs
       paths.destinationjsFolder = paths.webroot + "scripts/";
```
4. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       paths.vendorjsFileName = "vendor.min.js";
```
5. In the **gulpfile.js** code window, locate the following code: 
  ```cs
       gulp.task("copy-js-file", function() {
           return gulp.src(paths.jqueryjs)
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```
6. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       gulp.task("min-vendor:js", function() {
           return gulp.src(paths.jqueryjs)
                .pipe(concat(paths.vendorjsFileName))
                .pipe(uglify())
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```

#### Task 5: Write a task to bundle and minify all JavaScript files in a folder

1. In the **gulpfile.js** code window, locate the following code:
  ```cs
       paths.vendorjsFileName = "vendor.min.js";
```
2. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       paths.jsFiles = "./Scripts/*.js";
       paths.jsFileName = "script.min.js";
```

3. In the **gulpfile.js** code window, locate the following code:
  ```cs
       gulp.task("min-vendor:js", function() {
           return gulp.src(paths.jqueryjs)
                .pipe(concat(paths.vendorjsFileName))
                .pipe(uglify())
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```
4. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       gulp.task("min:js", function() {
           return gulp.src(paths.jsFiles)
                .pipe(concat(paths.jsFileName))
                .pipe(uglify())
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```

#### Task 6: Add a watcher task

1. In the **gulpfile.js** code window, locate the following code: 
  ```cs
      gulp.task("min:js", function() {
          return gulp.src(paths.jsFiles)
                .pipe(concat(paths.jsFileName))
                .pipe(uglify())
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```
2. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
      gulp.task("js-watcher", function() {
          gulp.watch('./Scripts/*.js', gulp.series("min:js"));
      });
```

#### Task 7: Run the tasks

1. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **gulpfile.js**, and then click **Task Runner Explorer**.

      >**Note**: If the **Tasks** list doesn't contain the **min:js**, **min-vendor:js** and **js-watcher** tasks, click **Refresh**.

3. In **Task Runner Explorer**, under **Tasks**, right-click **min-vendor:js**, and then click **Run**.

      >**Note**: In Solution Explorer, under **wwwroot**, under **scripts**, a new file named **vendor.min.js** has been added. Notice that this file is a minified version of the **jquery.js** file.

4. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, expand **Scripts**, and then click **payment-calc.js**.

      >**Note**: In the fourth line there is an error: **form-control-mistake**.

5. In **Task Runner Explorer**, under **Tasks**, right-click **min:js**, and then click **Run**.

      >**Note**: In Solution Explorer, under **wwwroot**, under **scripts**, a new file named **script.min.js** has been added.  

6. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, under **scripts**, click **script.min.js**.

      >**Note**: The **script.min.js** file is a minified version of the **payment-calc.js** file. It contains the string **form-control-mistake**.

7. In **Task Runner Explorer**, under **Tasks**, right-click **js-watcher**, and then click **Run**.

8. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, under **Scripts**, click **payment-calc.js**.

9. In the **payment-calc.js** code window, select the following code:
  ```cs
       $('.form-control-mistake')
```

10. Replace the selected code with the following code:
  ```cs
       $('.form-control')
```

11. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Save payment-calc.js**.

12. In the **Microsoft Visual Studio** dialog box, click **Yes to All**.

13. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, under **scripts**, click **script.min.js**.

      >**Note**: In the **script.min.js** file, the string **form-control-mistake** was replaced with **form-control**.

>**Results**: In this exercise, you used gulp to copy, bundle and minify JavaScript files, and add watcher tasks.

### Exercise 2: Styling by Using Sass 

#### Task 1: Add a new Sass file to the project

1. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **IceCreamCompany**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Styles**, and then press Enter.

3. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **Styles**, point to **Add**, and then click **New Item**.

4. In the **Add New Item - IceCreamCompany** dialog box, in the search box, type **scss**, and then press Enter.

5. In the **Add New Item - IceCreamCompany** dialog box, click **SCSS Style Sheet (SASS)**.

6. In the **Add New Item – IceCreamCompany** dialog box, in the **Name** box, type **main**, and then click **Add**. 

7. In the **main.scss** code window, select the following code: 
  ```cs
       body {
       }
```
8. Replace the selected code with the following code:
  ```cs
       $highlights: #124eab;

       @mixin normalized-text() {
          font-family: "Playfair Display", Arial, Tahoma, sans-serif;
          text-align: center;
       }

       @mixin normalized-image() {
          width: 100%;
          height: auto;
       }
```

9. In the **main.scss** code window, locate the following code: 
  ```cs
       @mixin normalized-image() {
          width: 100%;
          height: auto;
       }
```
10. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       div {
           h1 {
               @include normalized-text();
               font-size: 45px;
               line-height: 50px;
               font-weight: 400;
               letter-spacing: 1px;
               color: #736454;
               margin: 60px;
           }
       }

       .main-title {
           background-image: url("/images/banner-1.jpg");
           width: 100%;
           background-size: cover;
           background-position: center center;
           min-height: 400px;
           display: flex;
           flex-direction: column;
           justify-content: center;
           align-items: center;

           h1 {
               @include normalized-text();
               color: $highlights;
               font-size: 50px;
               text-shadow: 0px 2px 5px #aba8a8;
               font-weight: bolder;
               text-align: center;
           }

           button {
               @include normalized-text();
               transition: none;
               color: lighten(#ffffff,90%);
               text-align: inherit;
               line-height: 13px;
               border: 1px solid #d3c0c0;
               margin: 0px;
               padding: 12px 24px;
               letter-spacing: 0px;
               font-weight: 400;
               font-size: 16px;
               font-weight: bold;
               background-color: #736454;
           }
       }
```
11. Place the cursor immediately after the last typed **}** (closing bracket) sign, press Enter twice, and then type the following code:
  ```cs
       .img-container {
           display: flex;
           flex-wrap: wrap;
           justify-content: space-around;
           align-items: flex-end;

           .item {
               color: white;
               width: 200px;
               display: flex;
               flex-direction: column;
               justify-content: space-between;

               h3 {
                  @include normalized-text();
                  color: #736454;
                  font-size: 20px;
               }

               div {
                   img {
                        @include normalized-image();
                   }
               }

               div {
                   p {
                        @include normalized-text();
                        color: #736454;
                        font-size: 20px;
                        margin: 70px;
                   }
               }
           }
       }

       .container {
           .checkout {
                border: 1px solid #ccc;
                box-shadow: 0 0 5px #ccc;
                padding: 20px;
                width: 800px;
                margin: 0 auto;
                border-radius: 4px;
                background-color: #f9f9f9;

                .row justify-content-center intro-row {
                    font-weight: bold;
                }
           }
       }
```

12. Place the cursor immediately after the last typed **}** (closing bracket) sign, press Enter twice, and then type the following code:
  ```cs
       .justify-content-center {
           justify-content: center !important;
           align-items: center;
       }

       nav {
           width: 450px;
       }

       img {
           height: 35px;
           width: 35px;
       }

       .navbar-nav > li {
           float: left;
           position: relative;
       }

       .row {
           margin: 10px;
       }

       .imageDisplay {
           @include normalized-image();
       }
```

#### Task 2: Add gulp tasks to handle Sass files 

1. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, click **gulpfile.js**.

2. In the **gulpfile.js** code window, locate the following code:
  ```cs
       var gulp = require('gulp');
       var concat = require('gulp-concat');
       var uglify = require('gulp-uglify');
```
3. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       var sass = require('gulp-sass');
       var cssmin = require('gulp-cssmin');
```

4. In the **gulpfile.js** code window, locate the following code:
  ```cs
       paths.jsFileName = "script.min.js";
```

5. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       paths.sassFiles = "./Styles/*.scss";
       paths.compiledCssFileName = "main.min.css";
       paths.destinationCssFolder = paths.webroot + "css/";
```

6. In the **gulpfile.js** code window, locate the following code: 
  ```cs
       gulp.task("min:js", function() {
           return gulp.src(paths.jsFiles)
                .pipe(concat(paths.jsFileName))
                .pipe(uglify())
                .pipe(gulp.dest(paths.destinationjsFolder));
       });
```
7. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       gulp.task("min:scss", function() {
           return gulp.src(paths.sassFiles)
               .pipe(sass().on('error', sass.logError))
               .pipe(concat(paths.compiledCssFileName))
               .pipe(cssmin())
               .pipe(gulp.dest(paths.destinationCssFolder));
       });
```
8. In the **gulpfile.js** code window, locate the following code: 
  ```cs
       gulp.task("js-watcher", function() {
           gulp.watch('./Scripts/*.js', gulp.series("min:js"));
       });
```
9. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       gulp.task("sass-watcher", function() {
           gulp.watch('./Styles/*.scss', gulp.series("min:scss"));
       });
```

#### Task 3: Run the tasks

1. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **gulpfile.js**, and then click **Task Runner Explorer**.

      >**Note**: If the **Tasks** list does not contain the **min:scss** and **sass-watcher** tasks, click **Refresh**.

3. In **Task Runner Explorer**, under **Tasks**, right-click **min:scss**, and then click **Run**.

      >**Note**: In Solution Explorer, under **wwwroot**, under **css**, a new css file has been added named **main.min.css**.

4. In **Task Runner Explorer**, under **Tasks**, right-click **sass-watcher**, and then click **Run**.

      >**Note**: From now whenever you change the **main.scss** file, the **main.min.css** file will automatically be changed.

>**Results**: In this exercise, you created Sass files and add gulp tasks to compile, bundle and minify them.

### Exercise 3: Using Bootstrap

#### Task 1: Update gulpfile.js to handle Bootstrap 

1. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer,  click **gulpfile.js**.

2. In the **gulpfile.js** code window, locate the following code:
  ```cs
       paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
```
3. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       paths.popperjs = paths.nodeModules + "popper.js/dist/umd/popper.js";
       paths.bootstrapjs = paths.nodeModules + "bootstrap/dist/js/bootstrap.js";
       paths.vendorjs = [paths.jqueryjs, paths.popperjs, paths.bootstrapjs];
```

4. In the **gulpfile.js** code window, select the following code: 
  ```cs
       gulp.task("min-vendor:js", function() {
           return gulp.src(paths.jqueryjs)
```
5. Replace the selected code with the following code:
  ```cs
       gulp.task("min-vendor:js", function() {
           return gulp.src(paths.vendorjs)
```

6. In the **gulpfile.js** code window, locate the following code:
  ```cs
       paths.destinationCssFolder = paths.webroot + "css/";
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
       paths.bootstrapCss = paths.nodeModules + "bootstrap/dist/css/bootstrap.css";
       paths.vendorCssFileName = "vendor.min.css";
```
8. In the **gulpfile.js** code window, locate the following code: 
  ```cs
      gulp.task("min:scss", function() {
           return gulp.src(paths.sassFiles)
                .pipe(sass().on('error', sass.logError))
                .pipe(concat(paths.compiledCssFileName))
                .pipe(cssmin())
                .pipe(gulp.dest(paths.destinationCssFolder));
      });
```
9. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
      gulp.task("min-vendor:css", function() {
           return gulp.src(paths.bootstrapCss)
                .pipe(concat(paths.vendorCssFileName))
                .pipe(cssmin())
                .pipe(gulp.dest(paths.destinationCssFolder));
      });
```

#### Task 2: Run the tasks

1. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, right-click **gulpfile.js**, and then click **Task Runner Explorer**.

      >**Note**: If the **Tasks** list does not contain the **min-vendor:css** task, click **Refresh**.

3. In **Task Runner Explorer**, under **Tasks**, right-click **min-vendor:css**, and then click **Run**.

      >**Note**: In Solution Explorer, under **wwwroot**, under **css**, a new css file has been added named **vendor.min.css**.

4. In **Task Runner Explorer**, under **Tasks**, right-click **min-vendor:js**, and then click **Run**.

5. In the **Microsoft Visual Studio** dialog box, click **Yes**.

      >**Note**: In Solution Explorer, under **wwwroot**, under **scripts**, a file named **vendor.min.js** was updated.

#### Task 3: Style the application by using Bootstrap

1. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Shared**, and then click **_Layout.cshtml**.

2. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```
3. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/scripts/vendor.min.js"></script>
       <script src="~/scripts/script.min.js"></script>
       <link href="~/css/vendor.min.css" rel="stylesheet" />
       <link href="~/css/main.min.css" rel="stylesheet" />
```

4. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

5. Place the cursor before the **<** (less than) sign of the **&lt;div&gt;** tag, press Enter, press the Up arrow key, and then type the following code:
  ```cs
       <div>
          <nav class="navbar navbar-expand-lg navbar-light bg-light mx-auto">
              <a class="navbar-brand" href="@Url.Action("Index", "IceCream")">
                  <img src="~/images/brand.jpg" class="d-inline-block align-top" alt="">
                  Ice Cream of Dreams
              </a>
              <div class="collapse navbar-collapse" id="nav-content">
                  <ul class="navbar-nav" id="nav-content">
                      <li class="nav-item active">
                          <a class="nav-link" href="@Url.Action("Index", "IceCream")">Home <span class="sr-only">(current)</span></a>
                      </li>
                      <li class="nav-item">
                          <a class="nav-link" href="@Url.Action("Buy", "IceCream")">Buy Ice Cream</a>
                      </li>
                  </ul>
              </div>
          </nav>
       </div>
       <div class="main-title">
            <h1>The Best Ice Cream You Will Taste in Your Life</h1>
            <button type="button" onclick="location.href='@Url.Action("Buy", "IceCream")'">Buy Ice Cream</button>
       </div>
```

6. In the **IceCreamCompany - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **IceCreamController.cs**.

7. In the **IceCreamController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       [HttpGet]
       public IActionResult Buy()
```

8. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Buy**.

9. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

10. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is cleared and the **Use a layout page** check box is selected, and then click **Add**.

11. In the **Buy.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model IceCreamCompany.Models.Customer
```

12. In the **Buy.cshtml** code window, select the following code:
  ```cs
       <h2>Buy</h2>
```
13. Replace the selected code with the following code:
  ```cs
       <div class="container">
           <h1>Choose Your Flavor</h1>
           <div class="checkout">
               <div class="row justify-content-center intro-row">
                   <div class="col-4">Ice Cream Flavors</div>
                   <div class="col-2">Buy Bulk(lbs)</div>
                   <div class="col-2">Total Amount</div>
                   <div class="col-2"></div>
               </div>
               <div class="row justify-content-center">
                   <div class="col-4">
                       <select class="form-control" id="flavor">
                           <option>Select</option>
                           <option>Vanilla Ice Cream with Caramel Ripple and Almonds</option>
                           <option>Vanilla Ice Cream with Cherry Dark Chocolate Ice Cream</option>
                           <option>Vanilla Ice Cream with Pistachio</option>
                       </select>
                   </div>
                   <div class="col-2">
                       <select class="form-control" id="quantity">
                           <option>1</option>
                           <option>1.5</option>
                           <option>2</option>
                           <option>3</option>
                           <option>4</option>
                       </select>
                   </div>
                   <div class="col-2">
                       <div id="totalAmount"></div>
                   </div>
                   <div class="col-2">
                       <div>
                           <img class="imageDisplay" id="iceCreamImage" alt="">
                       </div>
                   </div>
               </div>
           </div>
       </div>
``` 
14. In the **Buy.cshtml** code window, place the cursor before the **<** (less then) sign of the last **&lt;/div&gt;** tag, press Enter, press the Up arrow key, and then type the following code:

  ```cs
       <div class="row justify-content-center">
           <div class="col-5">
               <form method="post" enctype="multipart/form-data" asp-action="Buy">
                   <div class="form-group row">
                       <label asp-for="FirstName" class="col-sm-4 col-form-label"></label>
                       <div class="col-sm-6">
                           <input asp-for="FirstName" type="text" class="form-control" placeholder="First Name" required>
                       </div>
                   </div>
                   <div class="form-group row">
                       <label asp-for="LastName" class="col-sm-4 col-form-label"></label>
                       <div class="col-sm-6">
                           <input asp-for="LastName" type="text" class="form-control" placeholder="Last Name" required>
                       </div>
                   </div>
                   <div class="form-group row">
                       <label asp-for="Address" class="col-sm-4 col-form-label"></label>
                       <div class="col-sm-6">
                           <input asp-for="Address" type="text" class="form-control" placeholder="Address" required>
                       </div>
                   </div>
                   <div class="form-group row">
                       <label asp-for="Email" class="col-sm-4 col-form-label"></label>
                       <div class="col-sm-6">
                           <input asp-for="Email" type="email" class="form-control" placeholder="email@example.com" required>
                       </div>
                   </div>
                   <div class="form-group row">
                       <label asp-for="PhoneNumber" class="col-sm-4 col-form-label"></label>
                       <div class="col-sm-6">
                           <input asp-for="PhoneNumber" type="number" class="form-control" placeholder="Phone Number" required>
                       </div>
                   </div>
                   <div class="form-group row">
                       <div class="col-sm-10">
                           <button id="formButton" type="submit" class="btn btn-outline-primary">
                               Make a Purchase
                           </button>
                       </div>
                   </div>
               </form>
           </div>
       </div>
```

#### Task 4: Run the application

1. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In **Microsoft Edge**, click **Buy Ice Cream**.
 
4. On the **Buy Ice Cream** page, in the **Ice Cream Flavors** list, select _&lt;An ice cream flavor of your choice&gt;._

5. On the **Buy Ice Cream** page, in the **Buy Bulk(lbs)** list, select _&lt;A bulk of your choice&gt;._

6. On the **Buy Ice Cream** page, in the **First Name** box, type _&lt;A first name of your choice&gt;._

7. On the **Buy Ice Cream** page, in the **Last Name** box, type _&lt;A last name of your choice&gt;._

8. On the **Buy Ice Cream** page, in the **Address** box, type _&lt;An address of your choice&gt;._

9. On the **Buy Ice Cream** page, in the **Email** box, type _&lt;An email of your choice&gt;._

10. On the **Buy Ice Cream** page, in the **Phone Number** box, type _&lt;A phone number of your choice&gt;,_ and then click **Make a Purchase**.

11. On the **Thank you for purchase,hope you will enjoy the ice cream!** page, on the menu bar, click **Home**, and examine the browser content.

12. In Microsoft Edge, click **Close**.

13. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Results**: In this exercise, you created an ice cream company application in which users can view ice cream details, and buy some as well.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.