# Module 3: Configuring Middleware and Services in ASP.NET Core

# Lab: Configuring Middleware and Services in ASP.NET Core

#### Scenario
The Adventure Works Company wants to develop a web site about ball games. For this, the company needs to perform a survey to determine the popularity of different ball games. As their employee you are required to create a survey site to be used by the company.

#### Objectives

After completing this lab, you will be able to: 

-	Use ASP.NET Core static files including HTML files, image files and CSS files.
-	Create and use a custom Middleware, and use its context information.
-	Create and use services with ASP.NET Core built-in Dependency Injection.
-	Inject services to an ASP.NET Core MVC controller.

#### Lab Setup

Estimated Time: **75 minutes**

### Exercise 1: Working with Static Files

#### Scenario

To create the poll, the application needs a styled HTML page. The HTML page must then post the poll results to the server. To transfer the results to the server we will use an HTML form.

The main tasks for this exercise are as follows: 

1.	Create a static HTML page with an HTML form.
2.	Add images and a CSS file.
3.	Add the **UseStaticFiles** middleware.
4.	Display an HTML file from within an ASP.NET Core application.

####	Task 1: Create a new project using the ASP.NET Core Empty project template.

1. Start Visual Studio 2017 and create a new ASP.NET Core project by using the **ASP.NET Core Web Application** inside the C# template.

####	Task 2: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.

2. Review the **Startup.cs** and find the source for the page output.
     > **Note**: **Hello Word !** is shown on your browser.

3. Close the **Microsoft Edge** window.

####	Task 3: Add HTML file to the wwwroot folder.

1. Copy the **images** folder from the **Allfiles\Mod03\Labfiles\01_PollBall_begin** path to the  project's **wwwroot** folder.

2. Create a new subfolder, and copy a CSS file to the new folder by using the following information:

     -   Parent directory of the new directory: **wwwroot**
     -   New folder name: **style**
     -   CSS file to be copied: **StyleSheet.css**
     -   Source location of the CSS file: **Allfiles\Mod03\Labfiles\01_PollBall_begin**

3. Create a new **HTML Page** by using the following information:

     -   File name: **PollQuestions.html**
     -   Parent Directory: **wwwroot**

4. Inside the **BODY** element, Create a **P** Element with a **H1** element inside it. Fill them with guiding text for the user. The text should guide the user to select his favorite game from the list in the poll and click the **submit query**.

5. Add a **FORM** element to the **BODY** element with a class named **submit-form**.

6. Create a **DIV** element inside the **FORM** element with a class named **main-div**.

7. Create another **DIV** element inside the **FORM** element with a class named **submit-batch**.

8. Inside the **submit-batch** **DIV** element create a button of type **SUBMIT**.

9. Open the **Allfiles\Mod03\Labfiles\01_PollBall_begin\Html Text.txt** existing file and copy the content into the **DIV** with the **main-div** class you created.

####	Task 4: Run the application – content of HTML not displayed.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.

2. Access the following relative URL:
   
     - **/PollQuestions.html**
     > **Note**: See that **Hello Word !** is still shown, even after we have added an HTML file and set the URL path to it.

3. Close the **Microsoft Edge** window.

####	Task 5: Enable working with static files.

1. Add the UseStaticFiles method inside the **Configure** method of the **startup** class.

####	Task 6 : Run the application – content of HTML is displayed.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.

2. Access the following relative URL:
   
     - **/PollQuestions.html**
     > **Note**: See that the file content is shown with the photos in the subdirectory, but the HTML content is poorly designed.

3. Close the **Microsoft Edge** window.

4. Link the **StyleSheet.css** file to the **PollQuestions.html** file.

5. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.

6. Access the following relative URL:

     - **/PollQuestions.html**
     > **Note**: Now the HTML content is shown with the CSS design.

7. Select the basketball game, and press the **Submit Form** button.

8. Close the **Microsoft Edge** window.

####	Task 7: Add HTML file outside of the wwwroot folder.

1. Copy the **Test.html** file from the **Allfiles\Mod03\Labfiles\01_PollBall_begin** path to the project's main directory folder.

####	Task 8: Run the application – content of HTML outside wwwroot folder not displayed.

1. Run the new ASP.NET Core application in **Microsoft Edge**.

2. Access the following relative URL:

     - **/PollQuestions.html**
     > **Note**: By default, files outside the wwwroot directory are not visible in the browser, so **Hello Word !** from the **app.Run** is shown.

3. Close the **Microsoft Edge** window.

>**Result**: At the end of this exercise, you will be able to add and work with static files inside an ASP.NET Core project.

### Exercise 2: Creating Custom Middleware

#### Scenario

The server must receive the client’s request and notify the company for the poll submission.

The main tasks for this exercise are as follows: 

1. Create a custom middleware
2. The custom middleware will display the results of the submitted form from the static HTML we created
3. If no form was submitted, the custom middleware should not prevent the execution of other middleware

####	Task 1: Create a middleware.

1. Create a custom middleware that checks the value of the **Favorite** parameter that is submitted from the form. Skip the middleware if the **Favorite** parameter is missing.

2. Write to the page output the selected value from the form.

####	Task 2: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.

2. Access the following relative URL:

     - **/PollQuestions.html**

3. Select the **Basketball** game, and press the **Submit Form** button.
     > **Note**: The browser moved to a result page, and the following result is shown: Selected Value is = Basketball.

4. Close the **Microsoft Edge** window.

####	Task 3: Change the order of middleware.

1. Move the **app.UseStaticFiles** before the custom middleware.

2. Run the new ASP.NET Core application in **Microsoft Edge**.

3. Access the following relative URL:

     - **/PollQuestions.html**

4. Select the **Basketball** game, and press the **Submit Form** button.
     > **Note**: Now the **UseStaticFiles** middleware executes instead of the custom middleware, and it transfers back to the PollQuestions.html page.

5. Close the **Microsoft Edge** window.

6. Move the **app.UseStaticFiles** between the custom middleware and the **app.Run**.

7. Comment the **next.Invoke();** line of code that skips the custom middleware if the favorite parameter is not found.

8. Run the new ASP.NET Core application in **Microsoft Edge**.

9. Access the following relative URL:

     - **/PollQuestions.html**
     > **Note**: Now an empty page is shown, and the UseStaticFiles does not handle the call.

10. Close the **Microsoft Edge** window.

11. Uncomment the commented code that skips the middleware.

>**Result**: At the end of this exercise, you will be able to create a custom middleware and receive webform calls to it.

### Exercise 3: Using Dependency Injection

#### Scenario

We need to aggregate the votes and store them for future use. We will use services in order to manage and preserve the data.

The main tasks for this exercise are as follows: 

1.	Configure a service using **AddSingleton** to be used with Dependency Injection
2.	Update our service to be able to store poll result data
3.	Print the result to our browser by using the custom middleware we have created 

####	Task 1:  Define an interface for a service.

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
     - Parameter name: **game**
     - Parameter Type: **SelectedGame**
     - Return type: **Void**

5. Add a method declaration inside the interface using the following information:

     - Name: **GetVoteResult**
     - Return type: **SortedDictionary**<**SelectedGame**,**int**>

####	Task 2: Define an implementation for the service.

1. Create a class named **ResultsService** inside the **Services** folder, and inherit the class from the **lResultsService** interface.

2. Create the **AddVote** and the **GetVoteResult** methods, as defined by the interface decleration.

3. Create a dictionary that will contain the vote counts per game.

4. Implement the **AddVote** method to increase the counts in the dictionary of a selected game by the **game** parameter value.

5. Implement the **GetVoteResult** method that duplicates the dictionary data to a SortedDictionary, and returns it.


####	Task 3: Use dependency injection.

1. In the **startup** class, in the **ConfigureServices**, add the poll results service using the following information:

     - Interface: **lResultsService**
     - Implementation: **ResultsService**
     - Add method: **Singleton**

2. Inject the **lResultsService** interface into the **Configure** method that is inside the **Startup** class using Dependency Injection.

3. Inside the custom middleware, Add a vote to the service by the selected game that is received from the **Favorite** parameter. 

4. Inside the custom middleware, print to the page output the vote results from the service. 


####	Task 4: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge**. 
     > **Note**: Displayed result: **Action was not handled by any middleware. App run is executing. wwwroot folder path:** \[local path to your wwwroot folder\].

2. Access the following relative URL:

     - **/PollQuestions.html**

3. Select the **Basketball** game, and press the **Submit Form** button.
     > **Note**: The browser moved to a result page, and the following result is shown: Game name: Basketball, Votes: 1.

4. Access the following relative URL in a new **Microsoft Edge** window:

     - **/PollQuestions.html**
     > **Note**: See that in the URL, the port number of the new window should be identical to the previous window's port.

5. Select the **Football** game, and press the **Submit Form** button.
     > **Note**: The browser moved to a result page, and the following result is shown: Game name: Basketball, Votes: 1 Game name: Football, Votes: 1.

6. Access the following relative URL in a new **Microsoft Edge** windowL:

     - **/PollQuestions.html**
     > **Note**: See that in the URL, the port number of the new window should be identical to the previous window's port.

7. Select the **Basketball** game, and press the **Submit Form** button.
     > **Note**: The browser moved to a result page, and the following result is shown: Game name: Basketball, Votes: 2 Game name: Football, Votes: 1.

8. Close the **Microsoft Edge** window.

>**Result**: At the end of this exercise, you will be able to create and use a service with **Dependency Injection**.

### Exercise 4: Injecting Services to Controller

#### Scenario

We need to create a page to show results without submitting a vote.
In this case we will use an MVC controller to show the results.

The main tasks for this exercise are as follows: 

1.	Create a simple controller to see how it works
2.	Pass and use a service reference to the controller by using Dependency Injection
3.	The controller will print the results to the web browser


####	Task 1: Enable working with MVC.

1. In the **ConfigureServices** method of the **Startup** class, add the **AddMVC** method.

2. In the **Configure** method of the **Startup** class, add the **UseMvcWithDefaultRoute** method above the custom middleware.

####	Task 2: Add a controller.

1. Create the **Controllers** folder under the project's main directory.

2. Create a new class named **HomeController** and inherit from **Microsoft.AspNetCore.Mvc.Controller**.

3. Create a method named **Index** with return type of **IActionResult** inside the class.

####	Task 3: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge**.
     > **Note**: **Hello from controller** is shown on your browser.

2. Close the **Microsoft Edge** window.

3. In the **Startup** class, move the **app.Run** block **above** the **app.UseMvcWithDefaultRoute();** middleware.

4. Run the new ASP.NET Core application in **Microsoft Edge**.
     > **Note**: The MVC controller is ignored, and the displayed result is: **Action was not handled by any middleware. App run is executing. wwwroot folder path:** \[local path to your wwwroot folder\].

5. Close the **Microsoft Edge** window.

6. In the **Startup** class, move the **app.Run** block to be the last code block in the **Configure** method.


####	Task 4: Use Dependency Injection in a controller.

1. Inject the **IPollResultsService** into the **HomeController's** class constructor, and save it to a global variable.

2. Inside the **index** action of the **HomeController** class, replace its content with the service results, and return the results with the **Content** method.

####	Task 5: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge**.

2. Access the following relative URL:

     - **/PollQuestions.html**

3. Select the **Basketball** game, and press the **Submit Form** button.
     > **Note**: The MVC controller is ignored, and the displayed result is: **Action was not handled by any middleware. App run is executing. wwwroot folder path:** \[local path to your wwwroot folder\].

4. Access the following relative URL in a new **Microsoft Edge** window:

     - **/PollQuestions.html**
     > **Note**: See that in the URL, the port number of the new window should be identical to the previous window's port.

5. Select the **Football** game, and press the **Submit Form** button.
     > **Note**: The controller now returns the result: Game name: Basketball, Votes: 1 Game name: Football, Votes: 1.

6. Access the following relative URL in a new **Microsoft Edge** window:

     - **/PollQuestions.html**
     > **Note**: See that in the URL, the port number of the new window should be identical to the previous window's port.

7. Select the **Basketball** game, and press the **Submit Form** button.
     > **Note**: The controller now returns the result: Game name: Basketball, Votes: 2 Game name: Football, Votes: 1.

8. Access the following relative URL:

     - **/**
     > **Note**: The controller now returns the result: Game name: Basketball, Votes: 2 Game name: Football, Votes: 1.

9. Close the **Microsoft Edge** window.

>**Result**: At the end of this exercise, you will be able to create controller, and inject a service into it with **Dependency Injection**. 
