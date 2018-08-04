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

3. Before the **gulp.task** method call, assign the **vendorJsFileName** propery of the **path** variable the value of **"vendor.min.js"**.

4. Remove the **gulp.task** method call.

5. Call the **task** method of the **gulp** variable. Pass **"min-vendor:js"** and an **anonymous function** as parameters to the **task** function.

6. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

7. Chain a **pipe** function call to the **src** function call. Pass **concat(paths.vendorJsFileName)** as a parameter to the pipe function. 

8. Chain a **pipe** function call to the **pipe** function call. Pass **uglify()** as a parameter to the pipe function. 

9. Chain a **pipe** function call to the **pipe** function call. Pass **gulp.dest(paths.destinationJsFolder)** as a parameter to the pipe function. 


#### Task 5: Write a task to bundle and minify an existing file js file

1. Before the **gulp.task** method call, assign the **JsFiles** propery of the **path** variable the value of **"./Scripts/*.js"**.

2. Assign the **JsFileName** propery of the **path** variable the value of **"script.min.js"**.

3. Assign the **destinationExistingJsFolder** propery of the **path** variable the value of **paths.webroot + "script/"**.

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

3. Before the first **gulp.task** method call, assign the **sassFiles** propery of the **path** variable the value of **"./Styles/*.scss"**.

4. Assign the **compiledCssFileName** propery of the **path** variable the value of **""main.min.css"**.

5. Assign the **destinationCssFolder** propery of the **path** variable the value of **paths.webroot + "css/"**.

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

3. Inside the **h1** selector, include the **normalized-text** mixin with the **@include** directive. 

4. After the **@include** directive, add the following properties:

    - font-size: **45px**
    - line-height: **50px**
    - font-weight: **400**
    - letter-spacing: **1px**
    - color: **#736454**
    - margin: **60px**
   
#### Task 5: Run the task

1. 


>**Results** : After completing this exercise, you will be able to 

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

1. 

#### Task 2: Add a new task to handle the bootstrap css

1. 

#### Task 3:  Run the task

1. 

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
