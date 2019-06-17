# Module 9: Client-Side Development

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

Wherever a path is mentioned as **/**, it refers to the project root folder. For example, if instructed to add the **appsettings.json** file to the **/** folder in a project named **Example**, you will add it in the base **Example** folder for the project.

# Lab: Client-Side Development

#### Scenario

You have been asked to create a web-based ice cream application for your organization's customers. The application should have a page showing all kinds of ice creams in stock, and a purchase page which will allow customers to purchase ice cream. To style the application, you decided to use Bootstrap and Sass. You have decided to use gulp to compile, minify and bundle files.

#### Objectives

After completing this lab, you will be able to:

- Install gulp by using npm.
- Write tasks by using gulp.
- Style the application by using Sass and Bootstrap.

#### Lab Setup

Estimated Time: **60 minutes**

#### Preparation Steps
Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Using gulp to Run Tasks 

#### Scenario

In this exercise, you will first install gulp by using npm. You will then create a JavaScript file named **gulpfile.js**. After that, you will write tasks in the **gulpfile.js** file to bundle and minify JavaScript files. Finally, you will write a watcher task to track for any changes occurring in files which are located in the **Scripts** folder.

The main tasks for this exercise are as follows:

1. Use npm to install gulp

2. Write a task to copy a JavaScript file

3. Run the task

4. Write a task to minify a JavaScript file

5. Write a task to bundle and minify all JavaScript files in a folder

6. Add a watcher task

7. Run the tasks

#### Task 1: Use npm to install gulp

1. At the command prompt, run the  **cd [Repository Root]\Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin** command.

2. Run the **npm install** command.

3. Close the  **Command Prompt** window.

4. From the following location: **[Repository Root]\Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin**, open the **IceCreamCompany.sln** file.

    >**Note**: If a **Security Warning for IceCreamCompany** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

5. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **TOOLS** menu, click **Options**.

6. In the **Options** dialog box, search for **Web Package Management** and press **Enter**.

7. In the **Locations of external tools** list box, move the **$(PATH)** option to the top of the list, and then click **OK**.

8. Open the **package.json** file and view its content.

      >**Note**: There are dependencies to the **gulp**, **gulp-concat**, **gulp-cssmin**, **gulp-sass**, **gulp-uglify** packages which appear in the **devDependencies** section, and the **bootstrap**, **hoek**, **jquery**, **lodash**, **popper.js** packages appear in the **Dependencies** section.
      
#### Task 2: Write a task to copy a JavaScript file

1. Add a JavaScript file with the following information:

    - Folder: **/**
    - Name: **gulpfile**

2. In the **gulpfile.js** file, add a new variable named *gulp* with the value of **require('gulp')**.

3. Add a new variable named *paths* with the value of **{}**.

4. In the **paths** object, add the following properties:

    - webroot: **"./wwwroot/"**
    - nodeModules: **"./node_modules/"**

5. Assign the **jqueryjs** property of the *paths* variable the value of **paths.nodeModules + "jquery/dist/jquery.js"**.

6. Assign the **destinationjsFolder** property of the *paths* variable the value of **paths.webroot + "scripts/"**.

7. Call the **task** method of the *gulp* variable. 

8. Pass **"copy-js-file"** and an **anonymous function** as parameters to the **task** function.

9. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

10. Chain a **pipe** function call to the **src** function call. 

11. Pass **gulp.dest(paths.destinationjsFolder)** as a parameter to the pipe function. 

#### Task 3: Run the task

1. Save all the changes.

2. Open **Task Runner Explorer**.

    >**Note**: If the **Tasks** list does not contain a task named **copy-js-file**, click **Refresh**.

3. Run the **copy-js-file** task.

    >**Note**: In Solution Explorer, under **wwwroot**, a new folder has been added named **scripts** with a JavaScript file named **jquery.js**

#### Task 4:  Write a task to minify a JavaScript file

1. In **gulpfile.js**, after the *gulp* variable, add a variable named *concat* with the value of **require('gulp-concat')**.

2. Add a variable named *uglify* with the value of **require('gulp-uglify')**.

3. Before the **gulp.task** method call, assign the **vendorjsFileName** property of the **path** object the value of **"vendor.min.js"**.

4. After the **gulp.task** method call, call the **task** method of the *gulp* variable. 

5. Pass **"min-vendor:js"** and an **anonymous function** as parameters to the **task** function.

6. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

7. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorjsFileName)** as a parameter to the pipe function. 

8. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationjsFolder)** as a parameter to the pipe function. 


#### Task 5: Write a task to bundle and minify all JavaScript files in a folder

1. Before the first **gulp.task** method call, assign the **jsFiles** property of the **path** object the value of __"./Scripts/*.js"__.

2. Assign the **jsFileName** property of the **path** object, the value of **"script.min.js"**.

3. After the last **gulp.task** method call, call the **task** method of the *gulp* variable. Pass **"min:js"** and an **anonymous function** as parameters to the **task** function.

4. In the **anonymous function** code block, return the **gulp.src(paths.jsFiles)** function call result. 

5. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.jsFileName)** as a parameter to the pipe function. 

6. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

7. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationjsFolder)** as a parameter to the pipe function. 

#### Task 6: Add a watcher task

1. After the last **gulp.task** method call, call the **task** method of the *gulp* variable. 

2. Pass **"js-watcher"** and an **anonymous function** as parameters to the **task** function.

3. In the **anonymous function** code block, return the **gulp.watch** function call result. Pass __"./Scripts/*.js"__ and **gulp.series("min:js")** as parameters to the **gulp.watch** function.

#### Task 7: Run the tasks

1. Save all changes.

2. In the **Task Runner Explorer** window, run the **min-vendor:js** task.

3. From the **Scripts** folder, open the **payment-calc.js** file.

      >**Note**: In the fourth line there is an error: **form-control-mistake**.

4. Run the **min:js** task.

      >**Note**: In Solution Explorer, under **wwwroot**, under **scripts**, a new file named **script.min.js** has been added.  

5. From the **wwwroot/scripts** folder, open the **script.min.js** file.

      >**Note**: The **script.min.js** file is a minified version of the **payment-calc.js** file. It contains the **form-control-mistake** string.

6. Run the **js-watcher** task.

7. In the **payment-calc.js** file, replace **$('.form-control-mistake')** with **$('.form-control')**.

8. Save the **payment-calc.js** file.

9. In the **Microsoft Visual Studio** dialog box, click **Yes to All**.

10. From the **wwwroot/scripts** folder, open the **script.min.js** file.

      >**Note**: In the **script.min.js** file, the **form-control-mistake** string was replaced with **form-control**.

>**Results**: After completing this exercise, you will be able to use gulp to copy, bundle and minify JavaScript files, and add watcher tasks.

### Exercise 2: Styling by Using Sass

#### Scenario

In this exercise, you will first create a Sass file named **main.scss** and fill its content. After that, you will create a gulp task to compile the Sass file to a CSS file. Then you will create a gulp watcher task so compilation of the Sass file to a CSS file will be done automatically when the Sass file is changed.

The main tasks for this exercise are as follows:

1. Add a new Sass file to the project

2. Add gulp tasks to handle the Sass files

3. Run a task

#### Task 1: Add a new Sass file to the project

1. Create a new folder with the following information:

    - Folder name: **Styles**

2. Add a **SCSS Style Sheet (SASS)** file with the following information:

    - Folder: **Styles**
    - Name: **main**
 
3. Delete the content of the **main.scss** file.

4. In the **main.scss** file, add a new variable named *$highlights* with the value of **#124eab**.

5. Add a new mixin with the name of **normalized-text**.

6. In the **normalized-text** mixin, add the following properties:

    - font-family: **"Playfair Display", Arial, Tahoma, sans-serif**
    - text-align: **center**

7. Add a new mixin with the name of **normalized-image**.

8. In the **normalized-image** mixin, add the following properties:

    - width: **100%**
    - height: **auto**

9. After the **normalized-image** mixin definition, add a **DIV** selector.

10. Inside the **DIV** selector, add a **H1** nested selector.

11. Inside the **H1** selector, add the **normalized-text** mixin by using the **@include** directive. 

12. After the **@include** directive, add the following properties:

    - font-size: **45px**
    - line-height: **50px**
    - font-weight: **400**
    - letter-spacing: **1px**
    - color: **#736454**
    - margin: **60px**
    
13. After the **DIV** selector, add a **.main-title** selector with the following properties:

    - background-image: **url("/images/banner-1.jpg")**
    - width: **100%**
    - background-size: **cover**
    - background-position: **center center**
    - min-height: **400px**
    - display: **flex**
    - flex-direction: **column**
    - justify-content: **center**
    - align-items: **center**
    
14. Inside the **.main-title** selector, add a nested **H1** selector.

15. Inside the **H1** selector, add the **normalized-text** mixin by using the **@include** directive. 

16. After the **@include** directive, add the following properties:

    - color: **$highlights**
    - font-size: **50px**
    - text-shadow: **0px 2px 5px #aba8a8**
    - font-weight: **bolder**
    - text-align: **center**
    
17.  After the **H1** selector, add a **button** selector.

18. Inside the **button** selector, add the **normalized-text** mixin by using the **@include** directive. 

19. After the **@include** directive, add the following properties:

    - transition: **none**
    - color: **lighten(#ffffff,90%)**
    - text-align: **inherit**
    - line-height: **13px**
    - border: **1px solid #d3c0c0**
    - margin: **0px**
    - padding: **12px 24px**
    - letter-spacing: **0px**
    - font-weight: **400**
    - font-size: **16px**
    - font-weight: **bold**
    - background-color: **#736454**    

20. After the **.main-title** selector, add a **.img-container** selector with the following properties:

    - display: **flex**
    - flex-wrap: **wrap**
    - justify-content: **space-around**
    - align-items: **flex-end**  
    
21. Inside the **.img-container** selector, add a nested **.item** selector with the following properties:
    - color: **white**
    - width: **200px**
    - display: **flex**
    - flex-direction: **column**
    - justify-content: **space-between**
   
    
22. Inside the **.item** selector, add a nested **h3** selector.

23. Inside the **h3** selector, add the **normalized-text** mixin by using the **@include** directive. 

24. After the **@include** directive, add the following properties:
    - color: **#736454**
    - font-size: **20px**

25. After the **h3** selector, add a **DIV** selector.  

26. Inside the **DIV** selector, add a nested **img** selector. 

27. Inside the **img** selector, add the **normalized-image** mixin by using the **@include** directive. 
 
28. After the **DIV** selector, add a **DIV** selector.  

29. Inside the **DIV** selector, add a nested **p** selector. 

30. Inside the **p** selector, add the **normalized-text** mixin by using the **@include** directive.

31. After the **@include** directive, add the following properties:
    - color: **#736454**
    - font-size: **20px**
    - margin: **70px**
    
32. After the **.img-container** selector, add a **.container** selector.

33. Inside the **.container** selector, add a nested **.checkout** selector with the following properties:
    - border: **1px solid #ccc**
    - box-shadow: **0 0 5px #ccc**
    - padding: **20px**
    - width: **800px**
    - margin: **0 auto**
    - border-radius: **4px**
    - background-color: **#f9f9f9**
   
34. Inside the **.checkout** selector, add a nested **.row justify-content-center intro-row** selector with the following properties:
    - font-weight: **bold**
    
35. After the **.container** selector, add a **.justify-content-center** selector with the following properties:
    -  justify-content: **center !important**
    -  align-items: **center**

36. After the **.justify-content-center** selector, add a **nav** selector with the following properties:
    -  width: **450px**
    
37. After the **nav** selector, add a **img** selector with the following properties:
    -  height: **35px**
    -  width: **35px**
    
38. After the **img** selector, add a **.navbar-nav &gt; li** selector with the following properties:
    -  float: **left**
    -  position: **relative**

39. After the **.navbar-nav &gt; li** selector, add a **.row** selector with the following properties:
    -  margin: **10px**

40. After the **.row** selector, add a **.imageDisplay** selector.

41. Inside the **imageDisplay** selector, add the **normalized-image** mixin by using the **@include** directive.

#### Task 2: Add gulp tasks to handle Sass files

1. In the **gulpfile.js**, after the *uglify* variable assigment, add a variable named *sass* with the value of **require('gulp-sass')**.

2. Add a variable named *cssmin* with the value of **require('gulp-cssmin')**.

3. Before the first **gulp.task** method call, assign the **sassFiles** property of the **path** object the value of __./Styles/*.scss"__.

4. Assign the **compiledCssFileName** property of the **path** object the value of **"main.min.css"**.

5. Assign the **destinationCssFolder** property of the **path** object the value of **paths.webroot + "css/"**.

6. After the declaration of the **min:js** task, call the **task** method of the *gulp* variable. Pass **"min:scss"** and an **anonymous function** as parameters to the **task** function.

7. In the **anonymous function** code block, return the **gulp.src** function call result. Pass **paths.sassFiles** as a parameter to the **gulp.src** function.

8. Chain a **pipe** function call to the **src** function call. Pass **sass().on('error', sass.logError)** as a parameter to the **pipe** function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **concat(paths.compiledCssFileName)** as a parameter to the pipe function. 

10. Chain a **pipe** function call to the **pipe** function call. Pass **cssmin()** as a parameter to the pipe function. 

11. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationCssFolder)** as a parameter to the pipe function. 

12. After the last **gulp.task** method call, call the **task** method of the *gulp* variable. Pass **"sass-watcher"** and an **anonymous function** as parameters to the **task** function.

13. In the **anonymous function** code block, return the **gulp.watch** function call result. Pass __"./Styles/*.scss"__ and **gulp.series("min:scss")** as parameters to the **gulp.watch** function.

#### Task 3: Run the tasks

1. Save all changes.

2. In the **Task Runner Explorer** window, run the **min:scss** task.

      >**Note**: If the **Tasks** list does not contain the **min:scss** and **sass-watcher** tasks, click **Refresh**.

      >**Note**: In Solution Explorer, under **wwwroot**, under **css**, a new css file has been added named **main.min.css**.

3. Run the **sass-watcher** task.

      >**Note**: From now whenever you change the **main.scss** file, the **main.min.css** file will automatically be changed.

>**Results**: After completing this exercise, you will be able to create Sass files and add gulp tasks to compile, bundle and minify them.

### Exercise 3: Using Bootstrap

#### Scenario

In this exercise, you will first update the **min-vendor:js** task that bundles and minifies JavaScript files to include the JavaScript files of Bootstrap. After that, you will add a task to handle the CSS files of Bootstrap. You will then run the tasks to create the **vendor.min.css** file and to update the **vendor.min.js** file. After that, you will style the layout by using Bootstrap. Finally, you will create a view to buy an ice cream and style it by using Bootstrap.

The main tasks for this exercise are as follows:

1. Update gulpfile.js to handle Bootstrap

2. Run the tasks

3. Style the application by using Bootstrap

4. Run the application


#### Task 1: Update gulpfile.js to handle Bootstrap

1. In the **gulpfile.js** file, after the **jqueryjs** property assignment, assign the **popperjs** property of the **path** object the value of **paths.nodeModules + "popper.js/dist/umd/popper.js"**.

2. Assign the **bootstrapjs** property of the **path** object the value of **paths.nodeModules + "bootstrap/dist/js/bootstrap.js"**.

3. Assign the **vendorjs** property of the **path** object the value of **[paths.jqueryjs, paths.popperjs, paths.bootstrapjs]**.

4. In the **gulp.task** method call with the **"min-vendor:js"** parameter, in the **return** statement, replace the parameter from **paths.jqueryjs** to **paths.vendorjs**.

5. After the **destinationCssFolder** property assignment, assign the **bootstrapCss** property of the **path** object the value of **paths.nodeModules + "bootstrap/dist/css/bootstrap.css"**.

6. Assign the **vendorCssFileName** property of the **path** object the value of **"vendor.min.css"**.

7. After the **gulp.task** method call with the **"min:scss"** parameter, call the **task** method of the **gulp** variable. Pass **"min-vendor:css** and an **anonymous function** as parameters to the **task** function.

8. In the **anonymous function** code block, return the **gulp.src** function call result. Pass **paths.bootstrapCss** as a parameter to the **gulp.src** function.

9. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorCssFileName)** as a parameter to the pipe function. 

10. Chain a **pipe** function call to the **pipe** function call. Pass **cssmin()** as a parameter to the pipe function. 

11. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationCssFolder)** as a parameter to the pipe function. 

#### Task 2: Run the tasks

1. Save all changes.

2. In the **Task Runner Explorer** window, run the **min-vendor:css** task.

     > **Note**: In Solution Explorer, under **wwwroot**, under **css**, a new css file has been added named **vendor.min.css**.

3. Run the **min-vendor:js** task.

4. In the **Microsoft Visual Studio** dialog box, click **Yes**.

     > **Note**: In Solution Explorer, under **wwwroot**, under **scripts**, a file named **vendor.min.js** was updated.


#### Task 3: Style the application by using Bootstrap

1. In the **_Layout.cshtml** file, after the **TITLE** element, add a **SCRIPT** element with the following information:
    - Src: **~/scripts/vendor.min.js**
    
2. After the **SCRIPT** element, add a **SCRIPT** element with the following information:
    - Src: **~/script/script.min.js**
    
3. After the **SCRIPT** element, add a **LINK** element with the following information:
    - Href: **~/css/vendor.min.css**
    - rel: **stylesheet**
    
4. After the **LINK** element, add a **LINK** element with the following information:
    - Href: **~/css/main.min.css**
    - rel: **stylesheet**

5. In the **_Layout.cshtml** file, before the **DIV** element with **@RenderBody()** content, add a **DIV** element.

6. In the new **DIV** element, add a **NAV** element with the following information:
    - Class: **navbar navbar-expand-lg navbar-light bg-light mx-auto**
    
7. In the **NAV** element, add an **A** element with the following information:
    - Class: **navbar-brand**
    - Href: **@Url.Action("Index", "IceCream")**
     Content: **Ice Cream of Dreams**

8. In the **A** element, before its content, add an **IMG** element with the following information:
    - Src: **~/images/brand.jpg**
    - Class: **d-inline-block align-top**
    - Alt: **""**
 
9. After the **A** element, add a **DIV** element with the following information:

    - Class: **collapse navbar-collapse**
    - Id: **nav-content**   
    
10. In the new **DIV** element, add an **UL** element with the following information:

    - Class: **navbar-nav**
    - Id: **nav-content**  
    
11. In the **UL** element, add **LI** element with the following information:

    - Class: **nav-item active**

12. In the **LI** element, add an **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Index", "IceCream")**
    - Content: **Home**

13. In the new **A** element, after its content, add a **SPAN** element with the following information:
    - Class: **sr-only**
    - Content: **(current)**

14. After the last **LI** element, add an **LI** element with the following information:

    - Class: **nav-item**
    
15. In the **LI** element, add a **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Buy", "IceCream")**
    - Content: **Buy Ice Cream**
    
16. After the **DIV** element with the **NAV** element inside, add a **DIV** element with the following information:

    - Class: **main-title**
    
17. In the **DIV** element, add an **H1** element with the following information:

    - Content: **The Best Ice Cream You Will Taste in Your Life**
    
18. After the **H1** element, add a **BUTTON** element with the following information:

    - Type: **button**
    - Onclick: **location.href='@Url.Action("Buy", "IceCream")'**
    - Content: **Buy Ice Cream**
  
19. In the **IceCreamController** class, right-click on the **Buy** action name, and then click **Add View**.

20. Create a new **View** by using the **Add MVC View** dialog box, with the following information:

    - View Name: **Buy**
    - Template: **Empty (without model)**
    - Create as Partial View: **False**
    - Use a layout page: **True**

21. At the beginning of the **Buy.cshtml** view, add a **@model** directive with the following information:

    - Type: **IceCreamCompany.Models.Customer**.
    
22. Remove the **H2** element. 

23. Add a **DIV** element with the following information:

    - Class: **container**
    
24. In the **DIV** element, add an **H1** element with the following information:

    - Content: **Choose Your Flavor**
    
25. After the **H1** element, add a **DIV** element with the following information:

    - Class: **checkout**
    
26. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **row justify-content-center intro-row**
    
27. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-4**
    - Content: **Ice Cream Flavors**

28. After the new **DIV** element, add a **DIV** element with the following information:

    - Class: **col-2**
    - Content: **Buy Bulk(lbs)**

29. After the new **DIV** element, add a **DIV** element with the following information:

    - Class: **col-2**
    - Content: **Total Amount**
    
30. After the new **DIV** element, add a **DIV** element.

31. After the **DIV** element with the **row justify-content-center intro-row** classes, add a **DIV** element with the following information:

    - Class: **row justify-content-center**
    
32. In the new **DIV** element, add a **DIV** element with the following information:

    - Class: **col-4**

33. In the new **DIV** element, add a **SELECT** element with the following information:

    - Class: **form-control**
    - Id: **flavor**

34. In the **SELECT** element, add an **OPTION** element with the following information:

    - Content: **Select**
    
35. Add an **OPTION** element with the following information:

    - Content: **Vanilla Ice Cream with Caramel Ripple and Almonds**

36. Add an **OPTION** element with the following information:

    - Content: **Vanilla Ice Cream with Cherry Dark Chocolate Ice Cream**
    
37. Add an **OPTION** element with the following information:

    - Content: **Vanilla Ice Cream with Pistachio**

38. After the last **DIV** element with the **col-2** class, add the **DIV** element with the following information:

    - Class: **col-2**

39. In the new **DIV** element, add a **SELECT** element with the following information:

    - Class: **form-control**
    - Id: **quantity**
    
40. In the **SELECT** element, add an **OPTION** element with the following information:

    - Content: **1**

41. In the **SELECT** element, add an **OPTION** element with the following information:

    - Content: **1.5**
    
42. Add an **OPTION** element with the following information:

    - Content: **2**

43. Add an **OPTION** element with the following information:

    - Content: **3**
    
44. Add an **OPTION** element with the following information:

    - Content: **4**

45. After the last **DIV** element with the **col-2** class, add a **DIV** element with the following information:

    - Class: **col-2**
    
46. In the new **DIV** element, add a **DIV** element with the following information:

    - Id: **totalAmount**   

47. After the last **DIV** element with the **col-2** class, add a **DIV** element with the following information:

    - Class: **col-2**
    
48. In the new **DIV** element, add a**DIV** element.

49. In the new **DIV** element, add an **IMG** element with the following information:

     - Class: **imageDisplay**
     - Id: **iceCreamImage**
     - Alt: **""**

50. At the bottom of the **Buy.cshtml** view, add a **DIV** element with the following information:

    - Class: **row justify-content-center**
    
51. In the new **DIV** element, add a **DIV** element with the following information:

    - Class: **col-5**

52. In the new **DIV** element, add a **FORM** element with the following information:

    - Method: **post**
    - Enctype: **multipart/form-data**
    - Asp-action: **Buy**

53. In the **FORM** element, add a **DIV** element with the following information:

    - Class: **form-group row**

54. In the new **DIV** element, add a **LABEL** element with the following information:

    - Asp-for: **FirstName**
    - Class: **col-sm-4 col-form-label**

55. After the **LABEL** element, add a **DIV** element with the following information:

    - Class: **col-sm-6**

56. In the new **DIV** element, add an **INPUT** element with the following information:

    - Asp-for: **FirstName**
    - Type: **text**
    - Class: **form-control**
    - Placeholder: **First Name**
    - Required: **required**

57. After the last **DIV** element with the **form-group row** class, add a **DIV** element with the following information:

    - Class: **form-group row**

58. In the new **DIV** element, add a **LABEL** element with the following information:

    - Asp-for: **LastName**
    - Class: **col-sm-4 col-form-label**

59. After the **LABEL** element, add a **DIV** element with the following information:

    - Class: **col-sm-6**

60. In the new **DIV** element, add an **INPUT** element with the following information:

    - Asp-for: **LastName**
    - Type: **text**
    - Class: **form-control**
    - Placeholder: **Last Name**
    - Required: **required**
    
61. After the last **DIV** element with the **form-group row** class, add a **DIV** element with the following information:

    - Class: **form-group row**

62. In the new **DIV** element, add a **LABEL** element with the following information:

    - Asp-for: **Address**
    - Class: **col-sm-4 col-form-label**


63. After the **LABEL** element, add a **DIV** element with the following information:

    - Class: **col-sm-6**

64. In the new **DIV** element, add an **INPUT** element with the following information:

    - Asp-for: **Address**
    - Type: **text**
    - Class: **form-control**
    - Placeholder: **Address**
    - Required: **required**
 
65. After the last **DIV** element with the **form-group row** class, add a **DIV** element with the following information:

    - Class: **form-group row**

66. In the new **DIV** element, add a **LABEL** element with the following information:

    - Asp-for: **Email**
    - Class: **col-sm-4 col-form-label**

67. After the **LABEL** element, add a **DIV** element with the following information:

    - Class: **col-sm-6**

68. In the new **DIV** element, add an **INPUT** element with the following information:

    - Asp-for: **Email**
    - Type: **email**
    - Class: **form-control**
    - Placeholder: **email<span>@</span>example.com**
    - Required: **required**
  
69. After the last **DIV** element with the **form-group row** class, add a **DIV** element with the following information:

    - Class: **form-group row**

70. In the new **DIV** element, add a **LABEL** element with the following information:

    - Asp-for: **PhoneNumber**
    - Class: **col-sm-4 col-form-label**

71. After the **LABEL** element, add a **DIV** element with the following information:

    - Class: **col-sm-6**

72. In the new **DIV** element, add an **INPUT** element with the following information:

    - Asp-for: **PhoneNumber**
    - Type: **number**
    - Class: **form-control**
    - Placeholder: **Phone Number**
    - Required: **required**
    
73. After the last **DIV** element with the **form-group row** class, add a **DIV** element with the following information:

    - Class: **form-group row**

74. In the new **DIV** element, add a **DIV** element with the following information:

    - Class: **col-sm-10**

75. In the new **DIV** element, add a **BUTTON** element with the following information:

    - Id: **formButton**
    - Type: **submit**
    - Class: **btn btn-outline-primary**
    - Content: **Make a Purchase**
  
#### Task 4: Run the application

1. Save all changes.

2. Start the application without debugging. 

3. Click **Buy Ice Cream**.

4. In the **Ice Cream Flavors** list, select _&lt;An ice cream flavor of your choice&gt;_.
    
5. In the **Buy Bulk(lbs)** list, select _&lt;A bulk of your choice&gt;_.

6. In the **First Name** box, select _&lt;A first name of your choice&gt;_.

7. In the **Last Name** box, select _&lt;A last name of your choice&gt;_.
    
8. In the **Address** box, select _&lt;A address of your choice&gt;_.
    
9. In the **Email** box, select _&lt;A email of your choice&gt;_.

10. In the **Phone Number** box, select _&lt;A phone number of your choice&gt;_, and then click **Make a Purchase**.
    
11. On the **Thank you for purchase, hope you will enjoy the ice cream!** page, in the **menu bar** click **Home**, and examine the browser content.

12. Close Microsoft Edge.

13. Close Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created an ice cream company application in which users can view ice cream details, and buy some as well.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
