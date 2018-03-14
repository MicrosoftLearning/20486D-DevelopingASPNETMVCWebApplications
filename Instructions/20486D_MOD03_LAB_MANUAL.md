# Module 3: Configure Middlewares and Services in ASP.NET Core

  

# Lab: Configure Middlewares and Services in ASP.NET Core

#### Scenario
The adventure works company wants to develop a web site relating to a ball game.
For this, the company needs to make a survey to know the popularity of different types of ball games.
You are required as their employee to create the ball game survey site to be used by the company.

#### Objectives

After completing  this lab, you will be able to:
•	Use ASP.Net Core Static Files including html files, image files and css files.
•	Create and use custom Middlewares, and use its context information.
•	Create and use services with ASP .Net Core Build in Dependency Injection.
•	Using the MVC pattern with a basic controller.


#### Lab Setup

Estimated Time: **60 minutes**



### Exercise 1: Working with Static Files

#### Scenario

To make the poll, the application needs a designed HTML file. The HTML file must move the post data to the server. To transfer the data to the server we will use a web form.

The main tasks for this exercise are as follows: 
•	Create a static html file with a web form.
•	Connect it with images and a CSS file.
•	Add the UseStaticFiles middleware.
•	Show the html file inside the ASP.Net Core application.


####	Task 1: Create a new project using the ASP.NET Core Empty project template

1. Start Visual Studio 2017 and create a new ASP.Net Core project by using the **ASP.NET Core Web Application** C# template.

####	Task 2: Run the application

1. Run the new ASP.Net Core application in **Microsoft Edge** and review the page's output.
2. Review the **Startup.cs** and find the source for the page output.
3. Close the **Microsoft Edge** window.

####	Task 3: Add html file to the wwwroot folder

1. Copy the **images** folder from the **Allfiles\Mod03\Labfiles\01_PollBall_begin** path to the **wwwroot** project's folder.
2. Create a new subfolder, and copy a css file to the new folder by using the following information:
     -   Parent directory of the new directory: **wwwroot**
     -   New folder name: **style**
     -   css file to be copied: **StyleSheet.css**
     -   Source location of the css file: **Allfiles\Mod03\Labfiles\01_PollBall_begin**
3. Create a new **HTML Page** by using the following information:
     -   File name: **PollQuestions.html**
     -   Parent Directory: **wwwroot**
4. inside the **body** element, Create a **p** Element with a **h1** header element inside it. Fill them with guiding text for the user.
5. Add a **from** Element to the body element with a class named **submitform**:
6. Create a **div** element inside the **from** element with a class named **MainDiv**.
7. Create another **div** element inside the **from** element with a class named **SubmitBatch**.
8. Inside the **SubmitBatch** div element create a button of type **submit**.
9. Open the **Allfiles\Mod03\Labfiles\01_PollBall_begin\Html Text.txt** existing file and copy the content into the **div** with the **MainDiv** class you created.

####	Task 4: Run the application – content of html not displayed

1. Run the new ASP.Net Core application in **Microsoft Edge** and review the page's output.
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Close the **Microsoft Edge** window.

####	Task 5: Enable working with static files

1. Add the UseStaticFiles inside the **Configure** method of the **startup** class.

####	Task 6 : Run the application – content of html is displayed

1. Run the new ASP.Net Core application in **Microsoft Edge** and review the page's output.
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Close the **Microsoft Edge** window.
4. Link the **StyleSheet.css** file to the **PollQuestions.html** file.
5. Run the new ASP.Net Core application in **Microsoft Edge** and review the page's output.
6. Access the following relative URL:
     -   **/PollQuestions.html**
7. Select the basketball game, and press the **Submit Form** button.
8. Close the **Microsoft Edge** window.

####	Task 7: Add html file outside of the wwwroot folder

1. Copy the **Test.html** file from the **Allfiles\Mod03\Labfiles\01_PollBall_begin** path to the project's main directory folder.

####	Task 8: Run the application – content of html outside wwwroot folder not displayed

1. Run the new ASP.Net Core application in **Microsoft Edge**:
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Close the **Microsoft Edge** window.

>**Result**: At the end of this exercise, you will be able to add and work with static files inside an asp.net core project.

### Exercise 2: Creating Custom Middlewares

#### Scenario

The server must receive the clients request and notify the company for the poll submission.

The main tasks for this exercise are as follows: 
•	Create a custom middleware 
•	The custom middleware will display the results of the submitted form from the static HTML we created.
•	If no form was submitted, the custom middleware must not prevent execution of other middlewares.



####	Task 1: Create a middleware

1. Create a custom middleware that checks the value of the **Favorite** parameter that is submitted from the form. Skip the middleware if the **Favorite** parameter is missing.
2. Write to the page output the selected value from the form.

####	Task 2: Run the application

1. Run the new ASP.Net Core application in **Microsoft Edge** and review the page's output.
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Select the basketball game, and press the **Submit Form** button.
4. Close the **Microsoft Edge** window.

####	Task 3: Change the order of middlewares

1. Move the **app.UseStaticFiles** before the custom middleware.
2. Run the new ASP.Net Core application in **Microsoft Edge**.
3. Access the following relative URL:
     -   **/PollQuestions.html**
4. Select the basketball game, and press the **Submit Form** button.
5. Close the **Microsoft Edge** window.
6. Move the **app.UseStaticFiles** between the custom middleware and the app.Run.
7. Comment the **else** line of code that skips the custom middleware if the favorite parameter is not found.
8. Run the new ASP.Net Core application in **Microsoft Edge**.
9. Uncomment the commented code that skips the middleware.
10. Close the **Microsoft Edge** window. 

>**Result**: At the end of this exercise, you will be able to create a custom middleware and receive webform calls to it.

### Exercise 3: Using Dependency Injection

#### Scenario

We need to aggregate the votes, and show them for next use. We use services to manage and keep the data.

The main tasks for this exercise are as follows: 
•	Create a service using the AddSingleton and Dependency Injection.
•	The service must be able to save a poll data vote.
•	The service must return the results of all the votes.
•	The results must be printed to the browser using the custom middleware we created before. 



####	Task 1:  Define an interface for a service

1. Create a folder named **Services** in the main project's directory.
2. In the folder create an enum named **SelectedGame**.
3. Fill the enum with the following values:
```cs
    Basketball,
    Football,
    Soccer,
    Vollyball,
    Billiard,
    AirHockey,
    Golf,
    Tennis
```
4. Create an interface inside the **Services** folder named **lResultsService**.
5. Add a method declaration inside the interface using the following information:
     - Name: **AddVote**
     - Parameter name:  **game**
     - Parameter Type: **SelectedGame**
     - Return type: **Void**
5. Add a method declaration inside the interface using the following information:
     - Name: **GetVoteResult**
     - Return type: **SortedDictionary**<**SelectedGame**,**int**>

####	Task 2: Define an implementation for the service

1. Create a class named **ResultsService** inside the **Services** folder, and inherit the class from the **lResultsService** interface.
2. Create the **AddVote** and the **GetVoteResult** methods, as defined by the interface decleration.
3. Create a dictionary that contains the vote counts per game.
4. Implement the **AddVote** method to increase the counts in the dictionary of a selected game by the **game** parameter value.
5. Implement the **GetVoteResult** method that duplicates the dictionary data to a SortedDictionary.


####	Task 3: Use dependency injection

1. In the **startup** class, in the **ConfigureServices**, add the poll results serivce using the following information:
     - Interace: **lResultsService**
     - Implementation: **ResultsService**
     - Add method: **Singleton**
2. Inject the **lResultsService** interface into the **Configure** method that is inside the **Startup** class using Dependency Injection.
3. Inside the custom middleware, Add a vote to the service by the selected game that is received as parameter from the **Favorite** parameter. 
4. Inside the custom middleware, print to the page output the vote results from the service. 


####	Task 4: Run the application

1. Run the new ASP.Net Core application in **Microsoft Edge**. 
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Select the **Basketball** game, and press the **Submit Form** button.
4. Access the following relative URL:
     -   **/PollQuestions.html**
5. Select the **Football** game, and press the **Submit Form** button.
6. Access the following relative URL:
     -   **/PollQuestions.html**
7. Select the **Basketball** game, and press the **Submit Form** button.
8. Close the **Microsoft Edge** window.

>**Result**: At the end of this exercise, you will be able to create and use a service with **Dependency Injection**.

### Exercise 4: Injecting Services to Controller

#### Scenario

We need to create a page to show results without submitting a vote. In this time we use an MVC controller to show the results.

The main tasks for this exercise are as follows: 
•	Create a simple controller to see how it works.
•	The controller will receive the service data using Dependency Injection.
•	The controller will print the results to the web browser.


####	Task 1: Enable working with MVC

1. In the **ConfigureServices** method of the **Startup** class, add the **AddMVC** method.
2. In the **Configure** method of the **Startup** class, add the **UseMvcWithDefaultRoute** method above the custom middleware.

####	Task 2: Add a controller

1. Create the **Controllers** folder under the project's main directory.
2. Create a new class named **HomeController** and inherit from **Microsoft.AspNetCore.Mvc.Controller**.
3. Create a method named **Index** with return type of **IActionResult** inside the class.

####	Task 3: Run the application

1. Run the new ASP.Net Core application in **Microsoft Edge**.
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Select the **Basketball** game, and press the **Submit Form** button.
4. Close the **Microsoft Edge** window.
5. In the **Startup** class, move the app.Run block **above** the **app.UseMvcWithDefaultRoute();** middleware.
6. Run the new ASP.Net Core application in **Microsoft Edge**.
7. Access the following relative URL:
     -   **/PollQuestions.html**
8. Close the **Microsoft Edge** window.
9. In the **Startup** class, move the app.Run block to be the last code in the **Configure** method.

####	Task 4: Use Dependency Injection in a controller

1. Inject the **IPollResultsService** into the **HomeController's** class constructor, and save it to a global variable.
2. Inside the **index** action of the **HomeController** class, replace its content with the service results, and return the results with the **Content** method.

####	Task 5: Run the application. = See poll results

1. Run the new ASP.Net Core application in **Microsoft Edge**.
2. Access the following relative URL:
     -   **/PollQuestions.html**
3. Select the **Basketball** game, and press the **Submit Form** button.
4. Access the following relative URL:
     -   **/PollQuestions.html**
5. Select the **Football** game, and press the **Submit Form** button.
6. Access the following relative URL:
     -   **/PollQuestions.html**
7. Select the **Basketball** game, and press the **Submit Form** button.
8. Access the following relative URL:
     -   **/**
9. Close the **Microsoft Edge** window.

>**Result**: At the end of this exercise, you will be able to create controller, and inject a service into it with **Dependency Injection**. 
