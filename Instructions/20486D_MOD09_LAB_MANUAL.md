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

7. Call the **task** method of the **paths** variable. Pass **"copy-js-file"** and an **anonymous function** as parameters to the **task** function.

8. In the **anonymous function** code block, return the **gulp.src(paths.jqueryjs)** function call result. 

9. Chain a **pipe** function call to the **src** function call. Pass **gulp.dest(paths.destinationJsFolder)** as a parameter to the pipe function. 

#### Task 3: Run the task

1. 

#### Task 4:  Update the task to bundle and minify js file

1. 

#### Task 5: Write a task to bundle and minify an existing file js file

1. 

#### Task 6: Add a watcher task

1. 

#### Task 7: Run the task

1. 

>**Results** : After completing this exercise, you will be able to 

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

1.

#### Task 2: Add a new SASS file to the project

1. 

#### Task 3: Add SASS variables mixin and functions

1. 

#### Task 4: Add a SASS nesting styles

1. 
   
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
