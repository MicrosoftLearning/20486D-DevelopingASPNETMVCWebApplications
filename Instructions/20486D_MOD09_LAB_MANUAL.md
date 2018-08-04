# Module 9: Client-Side Development

# Lab: Client-Side Development

#### Scenario



#### Objectives

After completing this lab, you will be able to:

- 

#### Lab Setup

Estimated Time: **60 minutes**

#### Preparation Steps
1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. (https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)

### Exercise 1: Adding a Model

#### Scenario

In this exercise, you will:

- 

The main tasks for this exercise are as follows:

1. Use Node to install gulp.

2. Write a task to copy a js file.

3. Run the task.

4. Update the task to bundle and minify js file.

5. Write a task to bundle and minify an existing file js file.

6. Add a watcher task.

7. Run the task.

#### Task 1: Use Node to install gulp

1. In the **Command Prompt**, run the command **cd _<The location of  Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin folder on your machine>_** 

2. Run the command  **npm install** command.

3. Close the  **Command Prompt** window.

4. Open the **IceCreamCompany.sln** file from the following location: **Allfiles\Mod09\Labfiles\01_IceCreamCompany_begin**.

5. In the **Microsoft Visual Studio** window, click on the **Tools** menu, and then click **Options**.

6. In the **Options** dialog box, search for **Web Package Management** and press **Enter**.

7. In the **Locations of external tools** box, move the **$(PATH)** option to the top of the list, and then click **OK**.

8. Open the **package.json** file and view its content.

    > **Note:** In **Solution Explorer**, under **Depenndencies**, a new folder added named **npm** with **gulp**, **gulp-concat**, **gulp-uglify**, **gulp-watch-sass**, **gulp-sass**, **gulp-cssmin**, **jquery**, **bootstrap**, and **popper.js** packages.

#### Task 2: Write a task to copy a js file

1. Add a **JavaScript** file with the following information:

    - Folder: **/**
    - Name: **gulpfile.js**

2. In the **gulpfile.js** file, add a new variable named **gulp** with the value of **require('gulp')**.

3. Add a new variable named **paths** with the value of **{}**.

4. In the **paths** object, add the following properties :

    - webroot: **"./wwwroot/"**
    - nodeModules: **"./node_modules/"**

5. Assign the **jqueryjs** property of the **paths** variable the value of **paths.nodeModules + "jquery/dist/jquery.js"**.

6. Assign the **destinationJsFolder** property of the **paths** variable the value of **paths.webroot + "lib/"**.

7. Call the **task** method of the **gulp** variable. Pass **"copy-js-file"** and an **anonymous function** as parameters to the **task** function.

8. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

9. Chain a **pipe** function call to the **src** function call. Pass **gulp.dest(paths.destinationJsFolder)** as a parameter to the pipe function. 

#### Task 3: Run the task

1. Save all the changes.

2. Open **Task Runner Explorer**.
    >**Note:** In **Task Runner Explorer**, if the **Tasks list** is not updated click **Refresh**.

3. Right-click **copy-js-file**, and then click **Run**.
    >**Note:** In **Solution Explorer**, under **wwwroot**, a new folder has been added named **lib** with js File named **jquery.js**

#### Task 4:  Update the task to bundle and minify js file

1. In the **gulpfile.js**, after the **gulp** variable, add a variable named **concat** with the value of **require('gulp-concat')**.

2. Add a variable named **uglify** with the value of **require('gulp-uglify')**.

3. Before the **gulp.task** method call, assign the **vendorJsFileName** propery of the **path** object the value of **"vendor.min.js"**.

4. Remove the **gulp.task** method call.

5. Call the **task** method of the **gulp** variable. Pass **"min-vendor:js"** and an **anonymous function** as parameters to the **task** function.

6. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

7. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorJsFileName)** as a parameter to the pipe function. 

8. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationJsFolder)** as a parameter to the pipe function. 


#### Task 5: Write a task to bundle and minify an existing file js file

1. Before the **gulp.task** method call, assign the **JsFiles** propery of the **path** object the value of **"./Scripts/*.js"**.

2. Assign the **JsFileName** propery of the **path** object the value of **"script.min.js"**.

3. Assign the **destinationExistingJsFolder** propery of the **path** object the value of **paths.webroot + "script/"**.

4. After the **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"min:js"** and an **anonymous function** as parameters to the **task** function.

5. In the **anonymous function** code block, return the **gulp.src(paths.JsFiles)** function call result. 

6. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.JsFileName)** as a parameter to the pipe function. 

7. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

8. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationExistingJsFolder)** as a parameter to the pipe function. 

#### Task 6: Add a watcher task

1. After the **uglify** variable assigment, add a variable named **watch** with the value of **require('gulp-watch-sass')**.

2. After the last **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"js-watcher"** and an **anonymous function** as parameters to the **task** function.

3. In the **anonymous function** code block, return the **gulp.watch** function call result. Pass **"./Scripts/*.js"** and **["min:js"]** as parameters to the **gulp.watch** function.

4. After the last **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"sass-watcher"** and an **anonymous function** as parameters to the **task** function.

5. In the **anonymous function** code block, return the **gulp.watch** function call result. Pass **"./Styles/*.scss"** and **["min:scss"]** as parameters to the **gulp.watch** function.


#### Task 7: Run the task

1. Save all changes.

2. In the **Task Runner Explorer** window, right-click **min-vendor:js**, and then click **Run**.

3. Right-click **min:js**, and then click **Run**.

4. Right-click **js-watcher**, and then click **Run**.

>**Results** : After completing this exercise, you will be able to use **gulp** to copy, bundle and minify js files, furthermore add watcher tasks.

### Exercise 2: Styling Using SASS

#### Scenario

In this exercise, you will:

- 

The main tasks for this exercise are as follows:

1. Add gulp SASS task to compile bundle and minify.

2. Add a new SASS file to the project.

3. Add SASS variables mixin and functions.

4. Add a SASS nesting styles.

5. Run the task.



#### Task 1: Add gulp SASS task to compile bundle and minify

1. In the **gulpfile.js**, after the **watch** variable assigment, add a variable named **sass** with the value of **require('gulp-sass')**.

2. Add a variable named **cssmin** with the value of **require('gulp-cssmin')**.

3. Before the first **gulp.task** method call, assign the **sassFiles** propery of the **path** object the value of **"./Styles/*.scss"**.

4. Assign the **compiledCssFileName** propery of the **path** object the value of **""main.min.css"**.

5. Assign the **destinationCssFolder** propery of the **path** object the value of **paths.webroot + "css/"**.

6. After the last **gulp.task** method call, call the **task** method of the **gulp** variable. Pass **"min:scss** and an **anonymous function** as parameters to the **task** function.

7. In the **anonymous function** code block, return the **gulp.src** function call result. Pass **paths.sassFiles** as a parameter to the **gulp.src** function.

8. Chain a **pipe** function call to the **src** function call. Pass **sass().on('error', sass.logError)** as a parameter to the **pipe** function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **concat(paths.compiledCssFileName)** as a parameter to the pipe function. 

10. Chain a **pipe** function call to the **pipe** function call. Pass **cssmin()** as a parameter to the pipe function. 

11. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationCssFolder)** as a parameter to the pipe function. 


#### Task 2: Add a new SASS file to the project

1. Create a new folder with the following information:

    - Folder name: **Styles**

2. Add a **SCSS Style Sheet (SASS)** file with the following information:

    - Folder: **Styles**
    - Name: **main.scss**
 

#### Task 3: Add SASS variables mixin and functions

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

#### Task 4: Add a SASS nesting styles

1. After the **normalized-image** mixin definition, add a **div** selector.

2. Inside the **div** selector, add a **h1** nested selector.

3. Inside the **h1** selector, add the **normalized-text** mixin using the **@include** directive. 

4. After the **@include** directive, add the following properties:

    - font-size: **45px**
    - line-height: **50px**
    - font-weight: **400**
    - letter-spacing: **1px**
    - color: **#736454**
    - margin: **60px**
    
5. After the **div** selector, add a **.main-title** selector with the following properties:

    - background-image: **url("/images/banner-1.jpg")**
    - width: **100%**
    - background-size: **cover**
    - background-position: **center center**
    - min-height: **400px**
    - display: **flex**
    - flex-direction: **column**
    - justify-content: **center**
    - align-items: **center**
    
6. Inside the **.main-title** selector, add a nested **h1** selector.

7. Inside the **h1** selector, add the **normalized-text** mixin using the **@include** directive. 

8. After the **@include** directive, add the following properties:

    - color: **$highlights**
    - font-size: **50px**
    - text-shadow: **0px 2px 5px #aba8a8**
    - font-weight: **bolder**
    - text-align: **center**
    
9.  After the **h1** selector, add a **button** selector.

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

17. After the **h3** selector, add a **div** selector.  

18. Inside the **div** selector, add a nested **img** selector. 

19. Inside the **img** selector, add the **normalized-image** mixin using the **@include** directive. 
 
20. After the **div** selector, add a **div** selector.  

21. Inside the **div** selector, add a nested **p** selector. 

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
    
29. After the **img** selector, add a **.navbar-nav > li** selector with the following properties:
    -  float: **left**
    -  position: **relative**

29. After the **.navbar-nav > li** selector, add a **.row** selector with the following properties:
    -  margin: **10px**

30. After the **.row** selector, add a **.imageDisplay** selector.

31. Inside the **imageDisplay** selector, add the **normalized-image** mixin using the **@include** directive.

   
#### Task 5: Run the task

1. Save all changes.

    > **Note**: In **Task Runner Explorer**, if the **Tasks** list is not updated click **Refresh**.

2. In the **Task Runner Explorer** window, right-click **min:scss**, and then click **Run**.

3. Right-click **sass-watcher**, and then click **Run**.

4. Right-click **js-watcher**, and then click **Run**.

    > **Note**: In **Solution Explorer**, under **wwwroot**, under **css**, a new css File has been added named **main.min.css**.

>**Results** : After completing this exercise, you will be able to use gulp SASS task to compile bundle and minify SASS file to css.


### Exercise 3: Using Bootstrap

#### Scenario

In this exercise, you will:

- 

The main tasks for this exercise are as follows:

1. Update js task to include bootstrap.

2. Add a new task to handle the bootstrap css.

3. Run the task.

4. Link the layout to Bootstrap.

5. Style the layout using Bootstrap.

6. Apply the Bootstrap grid system to make the site responsive.

7. Style a form using Bootstrap.

8. Run the application.


#### Task 1: Update js task to include bootstrap.

1. In the **gulpfile.js** file, after the **jqueryjs** property assignment, assign the **popperjs** propery of the **path** object the value of **paths.nodeModules + "popper.js/dist/umd/popper.js"**.

2. Assign the **bootstrapjs** propery of the **path** object the value of **paths.nodeModules + "bootstrap/dist/js/bootstrap.js"**.

3. Assign the **vendorJsFiles** propery of the **path** object the value of **[paths.jqueryjs, paths.popperjs, paths.bootstrapjs]**.

4. In the **gulp.task** method call with the **"min-vendor:js"** parameter, in the **return** statement, replace the **paths.jqueryjs** parameter with **paths.vendorJsFiles** parameter.


#### Task 2: Add a new task to handle the bootstrap css

1. After the **destinationCssFolder** property assignment, assign the **bootstrapCss** propery of the **path** object the value of **paths.nodeModules + "bootstrap/dist/css/bootstrap.css"**.

2. Assign the **vendorCssFileName** propery of the **path** object the value of **"vendor.min.css"**.

3. After the **gulp.task** method call with the **"min:scss"** parameter, call the **task** method of the **gulp** variable. Pass **"min-vendor:css** and an **anonymous function** as parameters to the **task** function.

4. In the **anonymous function** code block, return the **gulp.src** function call result. Pass **paths.bootstrapCss** as a parameter to the **gulp.src** function.

5. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorCssFileName)** as a parameter to the **pipe** function. 

6. Chain a **pipe** function call to the **pipe** function call. Pass **cssmin()** as a parameter to the **pipe** function. 

7. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationCssFolder)** as a parameter to the **pipe** function. 

#### Task 3:  Run the task

1. Save all changes.

    > **Note**: In **Task Runner Explorer**, if the **Tasks** list is not updated click **Refresh**.

2. In the **Task Runner Explorer** window, right-click **min-vendor:css**, and then click **Run**.

     > **Note**: In **Solution Explorer**, under **wwwroot**, under **css**, a new css File has been added named **vendor.min.css**.


#### Task 4: Link the layout to Bootstrap

1. 

#### Task 5: Style the layout using Bootstrap

1. 

#### Task 6: Apply the Bootstrap grid system to make the site responsive

1. 

#### Task 7: Style a form using Bootstrap

1. 

#### Task 8: Run the application

1. 


>**Results**: After completing this exercise, you should have

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
