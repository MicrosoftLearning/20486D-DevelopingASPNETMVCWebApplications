# Module 9: Client-Side Development

# Lab: Client-Side Development

#### Scenario

You have been asked to create a web-based Ice Cream application for your organization's customers, you want 
to create a page showing all kinds of ice cream in stock, and a purchase page to the web application 
Which will allow customers to purchase ice cream.

You will style the application using Bootstrap and Sass files which will compile by the task runner named gulp.

#### Objectives

After completing this lab, you will be able to:

- Install gulp using Node.
- write tasks to bundle and minify files.
- Style the application using Saas and Bootstrap.

#### Lab Setup

Estimated Time: **60 minutes**

#### Preparation Steps
1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Using gulp to Run Tasks 

#### Scenario

In this exercise, you will first install gulp using npm. You will then create a JavaScript file named gulpfile.js. After that you will write tasks in the gulpfile.js file to bundle and minify JavaScript files. Finally, you will write a watcher task to track for any changes occurring in files which are located in the **Scripts** folder.

The main tasks for this exercise are as follows:

1. Use npm to install gulp.

2. Write a task to copy a js file.

3. Run the task.

4. Update the task to minify the JavaScript file.

5. Write a task to bundle and minify an existing file js file.

6. Add a watcher task.

7. Run the task.

#### Task 1: Use npm to install gulp

1. In the **Command Prompt**, run the command **cd {The location of  Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin folder on your machine}** 

2. Run **npm install** command.

3. Close the  **Command Prompt** window.

4. Open the **IceCreamCompany.sln** file from the following location: **Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin**.

5. In the **IceCreamCompany - Microsoft Visual Studio** window, on the **TOOLS** menu, click **Options**.

6. In the **Options** dialog box, search for **Web Package Management** and press **Enter**.

7. In the **Locations of external tools** list box, move the **$(PATH)** option to the top of the list, and then click **OK**.

8. Open the **package.json** file and view its content.

      >**Note:** There are dependencies to the **gulp**, **gulp-concat**, **gulp-uglify**, **gulp-sass**, **gulp-cssmin**, **jquery**, **bootstrap**, and **popper.js** packages.

#### Task 2: Write a task to copy a JavaScript file

1. Add a **JavaScript** **File** with the following information:

    - Folder: **/**
    - Name: **gulpfile**

2. In the **gulpfile.js** file, add a new variable named **gulp** with the value of **require('gulp')**.

3. Add a new variable named **paths** with the value of **{}**.

4. In the **paths** object, add the following properties :

    - webroot: **"./wwwroot/"**
    - nodeModules: **"./node_modules/"**

5. Assign the **jqueryjs** property of the **paths** variable the value of **paths.nodeModules + "jquery/dist/jquery.js"**.

6. Assign the **destinationJsFolder** property of the **paths** variable the value of **paths.webroot + "lib/"**.

7. Call the **task** method of the **gulp** variable. 

8. Pass **"copy-js-file"** and an **anonymous function** as parameters to the **task** function.

9. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

10. Chain a **pipe** function call to the **src** function call. 

11. Pass **gulp.dest(paths.destinationJsFolder)** as a parameter to the pipe function. 

#### Task 3: Run the task

1. Save all the changes.

2. Open **Task Runner Explorer**.

    >**Note:** If the **Tasks** list does not contain a task named **copy-js-file**, click **Refresh**.

3. Run the **copy-js-file** task.
    >**Note:** In **Solution Explorer**, under **wwwroot**, a new folder has been added named **lib** with a JavaScript file named **jquery.js**

#### Task 4:  Update the task to minify the JavaScript file

1. In the **gulpfile.js**, after the **gulp** variable, add a variable named **concat** with the value of **require('gulp-concat')**.

2. Add a variable named **uglify** with the value of **require('gulp-uglify')**.

3. Before the **gulp.task** method call, assign the **vendorJsFileName** property of the **path** object the value of **"vendor.min.js"**.

4. Remove the **gulp.task** method call.

5. Call the **task** method of the **gulp** variable. 

6. Pass **"min-vendor:js"** and an **anonymous function** as parameters to the **task** function.

7. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

8. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorJsFileName)** as a parameter to the pipe function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

10. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationJsFolder)** as a parameter to the pipe function. 


#### Task 5: Write a task to bundle and minify an existing JavaScript file

1. Before the **gulp.task** method call, assign the **JsFiles** property of the **path** object the value of **"./Scripts/*.js"**.

2. Assign the **JsFileName** property of the **path** object, the value of **"script.min.js"**.

3. Assign the **destinationExistingJsFolder** property of the **path** object the value of **paths.webroot + "script/"**.

4. After the **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"min:js"** and an **anonymous function** as parameters to the **task** function.

5. In the **anonymous function** code block, return the **gulp.src(paths.JsFiles)** function call result. 

6. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.JsFileName)** as a parameter to the pipe function. 

7. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

8. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationExistingJsFolder)** as a parameter to the pipe function. 

#### Task 6: Add a watcher task

1. After the **uglify** variable assigment, add a variable named **watch**, with the value of **require('gulp-watch-sass')**.

2. After the last **gulp.task** method call, call the **task** method of the **gulp** variable. 

3. Pass **"js-watcher"** and an **anonymous function** as parameters to the **task** function.

4. In the **anonymous function** code block, return the **gulp.watch** function call result. Pass **"./Scripts/*.js"** and **["min:js"]** as parameters to the **gulp.watch** function.

5. After the last **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"sass-watcher"** and an **anonymous function** as parameters to the **task** function.

6. In the **anonymous function** code block, return the **gulp.watch** function call result. Pass **"./Styles/*.scss"** and **["min:scss"]** as parameters to the **gulp.watch** function.

#### Task 7: Run the task

1. Save all changes.

2. In the **Task Runner Explorer** window, run the **min-vendor:js** task.

3. Run the **min:js** task.

4. Run the **js-watcher** task.

>**Results**: After completing this exercise, you will be able to use **gulp** to copy, bundle and minify js files, furthermore add watcher tasks.

### Exercise 2: Styling Using Sass

#### Scenario

In this exercise, you will first add **gulp** task to bundle and minify **Saas** files. You will then create a **Sass** file named **main.scss**. After that you will add **Sass** variables mixin and functions. Finally, you will add a **Sass** nesting styles in the **main.scss** file.

The main tasks for this exercise are as follows:

1. Add gulp Sass task to compile bundle and minify.

2. Add a new Sass file to the project.

3. Add Sass variables mixin and functions.

4. Add a Sass nesting styles.

5. Run the task.

#### Task 1: Add gulp Sass task to compile bundle and minify

1. In the **gulpfile.js**, after the **watch** variable assigment, add a variable named **sass** with the value of **require('gulp-sass')**.

2. Add a variable named **cssmin** with the value of **require('gulp-cssmin')**.

3. Before the first **gulp.task** method call, assign the **sassFiles** property of the **path** object the value of **"./Styles/*.scss"**.

4. Assign the **compiledCssFileName** property of the **path** object the value of **""main.min.css"**.

5. Assign the **destinationCssFolder** property of the **path** object the value of **paths.webroot + "css/"**.

6. After the last **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"min:scss** and an **anonymous function** as parameters to the **task** function.

7. In the **anonymous function** code block, return the **gulp.src** function call result. Pass **paths.sassFiles** as a parameter to the **gulp.src** function.

8. Chain a **pipe** function call to the **src** function call. Pass **sass().on('error', sass.logError)** as a parameter to the **pipe** function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **concat(paths.compiledCssFileName)** as a parameter to the pipe function. 

10. Chain a **pipe** function call to the **pipe** function call. Pass **cssmin()** as a parameter to the pipe function. 

11. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationCssFolder)** as a parameter to the pipe function. 


#### Task 2: Add a new Sass file to the project

1. Create a new folder with the following information:

    - Folder name: **Styles**

2. Add a **SCSS Style Sheet (SASS)** file with the following information:

    - Folder: **Styles**
    - Name: **main.scss**
 

#### Task 3: Add Sass variables mixin and functions

1. Delete the contents of the **main.scss** file.

2. In the **main.scss** file, add a new variable named **$highlights** with the value of **#124eab**.

3. Add a new **mixin** with the name of **normalized-text**.

4. In the **normalized-text** mixin, add the following properties:

    - font-family: **"Playfair Display", Arial, Tahoma, sans-serif**
    - text-align: **center**

5. Add a new **mixin** with the name of **normalized-image**.

6. In the **normalized-image** mixin, add the following properties:

    - width: **100%**
    - height: **auto**

#### Task 4: Add a Sass nesting styles

1. After the **normalized-image** mixin definition, add a **DIV** selector.

2. Inside the **DIV** selector, add a **H1** nested selector.

3. Inside the **H1** selector, add the **normalized-text** mixin using the **@include** directive. 

4. After the **@include** directive, add the following properties:

    - font-size: **45px**
    - line-height: **50px**
    - font-weight: **400**
    - letter-spacing: **1px**
    - color: **#736454**
    - margin: **60px**
    
5. After the **DIV** selector, add a **.main-title** selector with the following properties:

    - background-image: **url("/images/banner-1.jpg")**
    - width: **100%**
    - background-size: **cover**
    - background-position: **center center**
    - min-height: **400px**
    - display: **flex**
    - flex-direction: **column**
    - justify-content: **center**
    - align-items: **center**
    
6. Inside the **.main-title** selector, add a nested **H1** selector.

7. Inside the **H1** selector, add the **normalized-text** mixin using the **@include** directive. 

8. After the **@include** directive, add the following properties:

    - color: **$highlights**
    - font-size: **50px**
    - text-shadow: **0px 2px 5px #aba8a8**
    - font-weight: **bolder**
    - text-align: **center**
    
9.  After the **H1** selector, add a **button** selector.

10. Inside the **button** selector, add the **normalized-text** mixin using the **@include** directive. 

11. After the **@include** directive, add the following properties:

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

12. After the **.main-title** selector, add a **.img-container** selector with the following properties:

    - display: **flex**
    - flex-wrap: **wrap**
    - justify-content: **space-around**
    - align-items: **flex-end**  
    
13. Inside the **.img-container** selector, add a nested **.item** selector with the following properties:
    - color: **white**
    - width: **200px**
    - display: **flex**
    - flex-direction: **column**
    - justify-content: **space-between**
   
    
14. Inside the **.item** selector, add a nested **h3** selector.

15. Inside the **h3** selector, add the **normalized-text** mixin using the **@include** directive. 

16. After the **@include** directive, add the following properties:
    - color: **#736454**
    - font-size: **20px**

17. After the **h3** selector, add a **DIV** selector.  

18. Inside the **DIV** selector, add a nested **img** selector. 

19. Inside the **img** selector, add the **normalized-image** mixin using the **@include** directive. 
 
20. After the **DIV** selector, add a **DIV** selector.  

21. Inside the **DIV** selector, add a nested **p** selector. 

22. Inside the **p** selector, add the **normalized-text** mixin using the **@include** directive.

23. After the **@include** directive, add the following properties:
    - color: **#736454**
    - font-size: **20px**
    - margin: **70px**
    
24. After the **.img-container** selector, add a **.container** selector.

25. Inside the **.container** selector, add a nested **.checkout** selector with the following properties:
    - border: **1px solid #ccc**
    - box-shadow: **0 0 5px #ccc**
    - padding: **20px**
    - width: **800px**
    - margin: **0 auto**
    - border-radius: **4px**
    - background-color: **#f9f9f9**
   
26. Inside the **.checkout** selector, add a nested **.row justify-content-center intro-row** selector with the following properties:
    - font-weight: **bold**
    
27. After the **.container** selector, add a **.justify-content-center** selector with the following properties:
    -  justify-content: **center !important**
    -  align-items: **center**

28. After the **.justify-content-center** selector, add a **nav** selector with the following properties:
    -  width: **450px**
    
28. After the **nav** selector, add a **img** selector with the following properties:
    -  height: **35px**
    -  width: **35px**
    
29. After the **img** selector, add a **.navbar-nav &gt; li** selector with the following properties:
    -  float: **left**
    -  position: **relative**

29. After the **.navbar-nav &gt; li** selector, add a **.row** selector with the following properties:
    -  margin: **10px**

30. After the **.row** selector, add a **.imageDisplay** selector.

31. Inside the **imageDisplay** selector, add the **normalized-image** mixin using the **@include** directive.

#### Task 5: Run the task

1. Save all changes.

    > **Note**: In **Task Runner Explorer**, if the **Tasks** list is not updated click **Refresh**.

2. In the **Task Runner Explorer** window, right-click **min:scss**, and then click **Run**.

3. Right-click **sass-watcher**, and then click **Run**.

4. Right-click **js-watcher**, and then click **Run**.

    > **Note**: In **Solution Explorer**, under **wwwroot**, under **css**, a new css file has been added named **main.min.css**.

>**Results** : After completing this exercise, you will be able to use gulp Sass task to compile bundle and minify Sass file to css.

### Exercise 3: Using Bootstrap

#### Scenario

In this exercise, you will first update a task that bundle and minify js files then update the task to include **Bootstrap** js and then add a new task to handle css files also. You  will then style and link the layout to **Bootstrap**. After that you will apply the **Bootstrap** grid system. Finally, you will style the web application form.

The main tasks for this exercise are as follows:

1. Update js task to include bootstrap.

2. Add a new task to handle the bootstrap css.

3. Run the task.

4. Link the layout to Bootstrap.

5. Style the layout using Bootstrap.

6. Apply the Bootstrap grid system to make the site responsive.

7. Style a form using Bootstrap.

8. Run the application.


#### Task 1: Update js task to include bootstrap

1. In the **gulpfile.js** file, after the **jqueryjs** property assignment, assign the **popperjs** property of the **path** object the value of **paths.nodeModules + "popper.js/dist/umd/popper.js"**.

2. Assign the **bootstrapjs** property of the **path** object the value of **paths.nodeModules + "bootstrap/dist/js/bootstrap.js"**.

3. Assign the **vendorJsFiles** property of the **path** object the value of **[paths.jqueryjs, paths.popperjs, paths.bootstrapjs]**.

4. In the **gulp.task** method call with the **"min-vendor:js"** parameter, in the **return** statement, replace the **paths.jqueryjs** parameter with **paths.vendorJsFiles** parameter.


#### Task 2: Add a new task to handle the bootstrap css

1. After the **destinationCssFolder** property assignment, assign the **bootstrapCss** property of the **path** object the value of **paths.nodeModules + "bootstrap/dist/css/bootstrap.css"**.

2. Assign the **vendorCssFileName** property of the **path** object the value of **"vendor.min.css"**.

3. After the **gulp.task** method call with the **"min:scss"** parameter, call the **task** method of the **gulp** variable. Pass **"min-vendor:css** and an **anonymous function** as parameters to the **task** function.

4. In the **anonymous function** code block, return the **gulp.src** function call result. Pass **paths.bootstrapCss** as a parameter to the **gulp.src** function.

5. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorCssFileName)** as a parameter to the **pipe** function. 

6. Chain a **pipe** function call to the **pipe** function call. Pass **cssmin()** as a parameter to the **pipe** function. 

7. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationCssFolder)** as a parameter to the **pipe** function. 

#### Task 3:  Run the task

1. Save all changes.

    > **Note**: In **Task Runner Explorer**, if the **Tasks** list is not updated click **Refresh**.

2. In the **Task Runner Explorer** window, right-click **min-vendor:css**, and then click **Run**.

     > **Note**: In **Solution Explorer**, under **wwwroot**, under **css**, a new css file has been added named **vendor.min.css**.


#### Task 4: Link the layout to Bootstrap

1. In the **_Layout.cshtml** file, after the **TITLE** element, add a **SCRIPT** with the following information:
    - Src: **~/lib/vendor.min.js**
    
2. After the **SCRIPT** element, add a **SCRIPT** with the following information:
    - Src: **~/script/script.min.js**
    
3. After the **SCRIPT** element, add a **LINK** with the following information:
    - Href: **~/css/main.min.css**
    - rel: **stylesheet**
    
4. After the **LINK** element, add a **LINK** with the following information:
    - Href: **~/css/vendor.min.css**
    - rel: **stylesheet**


#### Task 5: Style the layout using Bootstrap

1. In the **_Layout.cshtml** file, before the **DIV** element with @RenderBody() content, add a **DIV**.

2. In the new **DIV** element, add a **NAV** element with the following information:
    - Class: **navbar navbar-expand-lg navbar-light bg-light mx-auto**
    
3. In the **NAV** element, add a **A** element with the following information:
    - Class: **navbar-brand**
    - Href: **@Url.Action("Index", "IceCream")**
     Content: **Ice Cream of Dreams**

4. In the **A** element, before its content, add a **IMG** element with the following information:
    - Src: **~/images/brand.jpg**
    - Class: **d-inline-block align-top**
    - Alt: **""**
 
5. After the **A** element, add **DIV** element with the following information:

    - Class: **collapse navbar-collapse**
    - Id: **nav-content**   
    
6. In the new **DIV** element, add **UL** element with the following information:

    - Class: **navbar-nav**
    - Id: **nav-content**  
    
7. In the **UL** element, add **LI** element with the following information:

    - Class: **nav-item active**

8. In the **LI** element, add **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Index", "IceCream")**
    - Content: **Home**

9. In the new **A** element, after its content, add a **SPAN** element with the following information:
    - Class: **sr-only**
    - Content: **(current)**

10. After the last **LI** element, add **LI** element with the following information:

    - Class: **nav-item**
    
11. In the **LI** element, add **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Buy", "IceCream")**
    - Content: **Buy Ice Cream**
    
12. After the **DIV** element with the **NAV** element inside, add **DIV** element with the following information:

    - Class: **main-title**
    
13. In the **DIV** element, add **H1** element with the following information:

    - Content: **The Best Ice Cream You Will Taste in Your Life**
    
14. After the **H1** element, add **BUTTON** element with the following information:

    - Type: **button**
    - Onclick: **location.href='@Url.Action("Buy", "IceCream")'**
    - Content: **Buy Ice Cream**

    
#### Task 6: Apply the Bootstrap grid system to make the site responsive

1. In the **IceCreamController** class, right-click on the **Buy** action name, and then click **Add View**.

2. Create a new **View** using the **Add MVC View** dialog box, with the following information:

    - View Name: **Buy**
    - Template: **Empty (without model**
    - Create as Partial View: **False**
    - Use a layout page: **True**

3. At the beginning of the **Buy.cshtml** view, add a **@model** directive with the following information:

    - Type: **IceCreamCompany.Models.Customer**.
    
4. Remove the **H2** element. 

5. Add **DIV** element with the following information:

    - Class: **container**
    
6. In the **DIV** element, add **H1** element with the following information:

    - Content: **Choose Your Flavor**
    
7. After the **H1** element, add **DIV** element with the following information:

    - Class: **checkout**
    
8. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **row justify-content-center intro-row**
    
9. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-4**
    - Content: **Ice Cream Flavors**

10. After the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-2**
    - Content: **Buy Bulk(lbs)**

11. After the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-2**
    - Content: **Total Amount**
    
12. After the new **DIV** element, add **DIV** element.

13. After the **DIV** element with the **row justify-content-center intro-row** classes, add **DIV** element with the following information:

    - Class: **row justify-content-center**
    
14. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-4**

15. In the new **DIV** element, add **SELECT** element with the following information:

    - Class: **form-control**
    - Id: **flavor**

16. In the **SELECT** element, add **OPTION** element with the following information:

    - Content: **Select**
    
17. Add **OPTION** element with the following information:

    - Content: **Vanilla Ice Cream with Caramel Ripple and Almonds**

18. Add **OPTION** element with the following information:

    - Content: **Vanilla Ice Cream with Cherry Dark Chocolate Ice Cream**
    
19. Add **OPTION** element with the following information:

    - Content: **Vanilla Ice Cream with Pistachio**

20. After the last **DIV** element with the **col-2** class, add **DIV** element with the following information:

    - Class: **col-2**

21. In the new **DIV** element, add **SELECT** element with the following information:

    - Class: **form-control**
    - Id: **quantity**
    
22. In the **SELECT** element, add **OPTION** element with the following information:

    - Content: **1**
    
23. Add **OPTION** element with the following information:

    - Content: **2**

24. Add **OPTION** element with the following information:

    - Content: **3**
    
25. Add **OPTION** element with the following information:

    - Content: **4**

26. After the last **DIV** element with the **col-2** class, add **DIV** element with the following information:

    - Class: **col-2**
    
27. In the new **DIV** element, add **DIV** element with the following information:

    - Id: **totalAmount**   

28. After the last **DIV** element with the **col-2** class, add **DIV** element with the following information:

    - Class: **col-2**
    
29.  In the new **DIV** element, add **DIV** element.

30.  In the new **DIV** element, add **IMG** element with the following information:

     - Class: **imageDisplay**
     - Src: **~/images/**
     - Id: **iceCreamImage**
     - Alt: **""**

#### Task 7: Style a form using Bootstrap

1. At the bottom of the **Buy.cshtml** view, add **DIV** element with the following information:

    - Class: **row justify-content-center**
    
2. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-5**

3. In the new **DIV** element, add **FORM** element with the following information:

    - Method: **post**
    - Enctype: **multipart/form-data**
    - Asp-action: **Buy**

4. In the **FORM** element, add **DIV** element with the following information:

    - Class: **form-group row**

5. In the new **DIV** element, add **LABEL** element with the following information:

    - Asp-for: **FirstName**
    - Class: **col-sm-4 col-form-label**

6. After the **LABEL** element, add **DIV** element with the following information:

    - Class: **col-sm-6**

7. In the new **DIV** element, add **INPUT** element with the following information:

    - Asp-for: **FirstName**
    - Type: **text**
    - Class: **form-control**
    - Placeholder: **First Name**
    - Required: **required**

8. After the last **DIV** element with the **form-group row** class, add **DIV** element with the following information:

    - Class: **form-group row**

9. In the new **DIV** element, add **LABEL** element with the following information:

    - Asp-for: **LastName**
    - Class: **col-sm-4 col-form-label**

10. After the **LABEL** element, add **DIV** element with the following information:

    - Class: **col-sm-6**

11. In the new **DIV** element, add **INPUT** element with the following information:

    - Asp-for: **LastName**
    - Type: **text**
    - Class: **form-control**
    - Placeholder: **Last Name**
    - Required: **required**
    
12. After the last **DIV** element with the **form-group row** class, add **DIV** element with the following information:

    - Class: **form-group row**

13. In the new **DIV** element, add **LABEL** element with the following information:

    - Asp-for: **Address**
    - Class: **col-sm-4 col-form-label**


14. After the **LABEL** element, add **DIV** element with the following information:

    - Class: **col-sm-6**

15. In the new **DIV** element, add **INPUT** element with the following information:

    - Asp-for: **Address**
    - Type: **text**
    - Class: **form-control**
    - Placeholder: **Address**
    - Required: **required**
 
16. After the last **DIV** element with the **form-group row** class, add **DIV** element with the following information:

    - Class: **form-group row**

17. In the new **DIV** element, add **LABEL** element with the following information:

    - Asp-for: **Email**
    - Class: **col-sm-4 col-form-label**

18. After the **LABEL** element, add **DIV** element with the following information:

    - Class: **col-sm-6**

19. In the new **DIV** element, add **INPUT** element with the following information:

    - Asp-for: **Email**
    - Type: **email**
    - Class: **form-control**
    - Placeholder: **email@example.com**
    - Required: **required**
  
20. After the last **DIV** element with the **form-group row** class, add **DIV** element with the following information:

    - Class: **form-group row**

21. In the new **DIV** element, add **LABEL** element with the following information:

    - Asp-for: **PhoneNumber**
    - Class: **col-sm-4 col-form-label**

22. After the **LABEL** element, add **DIV** element with the following information:

    - Class: **col-sm-6**

23. In the new **DIV** element, add **INPUT** element with the following information:

    - Asp-for: **PhoneNumber**
    - Type: **number**
    - Class: **form-control**
    - Placeholder: **Phone Number**
    - Required: **required**
    
24. After the last **DIV** element with the **form-group row** class, add **DIV** element with the following information:

    - Class: **form-group row**

25. In the new **DIV** element, add **DIV** element with the following information:

    - Class: **col-sm-10**

19. In the new **DIV** element, add **BUTTON** element with the following information:

    - Id: **formButton**
    - Type: **submit**
    - Class: **btn btn-outline-primary**
 
 
#### Task 8: Run the application

1. Save all changes.

2. Start the application without debugging. 

3. Click **Buy Ice Cream**.

4. In the **Ice Cream Flavors** list, select _&lt;An ice cream flavor of your choice&gt;_.
    
5. In the **Buy Bulk(lbs)** list, select _&lt;A bulk of your choice&gt;_.

6. In the **First Name** text box, select _&lt;A first name of your choice&gt;_.

7. In the **Last Name** text box,, select _&lt;A last  name of your choice&gt;_.
    
8. In the **Address** text box, select _&lt;A address of your choice&gt;_.
    
9. In the **Email** text box, select _&lt;A email of your choice&gt;_.

10. In the **Phone Number** text box, select _&lt;A phone number of your choice&gt;_, and then click **Make a Purchase**.
    
11. On the **Thank you** page, in the **menu bar** click **Home**, and examine the browser content.

12. Close **Microsoft Edge**.

13. Close **Microsoft Visual Studio**.

>**Results** : After completing this exercise, you should have created a ice cream company application in which users can view ice cream details, and buy some as well.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
