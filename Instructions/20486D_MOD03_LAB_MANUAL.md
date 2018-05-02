# Module 3: Configuring Middleware and Services in ASP.NET Core

# Lab: Configuring Middleware and Services in ASP.NET Core

#### Scenario
The Adventure Works Company wants to develop a web site about ball games. For this, the company needs to perform a survey to determine the popularity of different ball games. As their employee you are required to create a survey site to be used by the company.

#### Objectives

After completing this lab, you will be able to: 

-	Use ASP.NET Core static files including HTML files, image files and CSS files
-	Create and use a custom Middleware, and use its context information
-	Create and use services with ASP.NET Core built-in Dependency Injection
-	Inject services to an ASP.NET Core MVC controller

#### Lab Setup

Estimated Time: **75 minutes**

### Exercise 1: Working with Static Files

#### Scenario

To create the poll, the application needs a styled HTML page. The HTML page must then post the poll results to the server. To transfer the results to the server we will use an HTML form.

The main tasks for this exercise are as follows: 

1.	Create a new project using the ASP.NET Core Empty project template

2.	Run the application

3.	Add an HTML file to the wwwroot folder

4.	Run the application – content of HTML not displayed

5.	Enable working with static files

6.	Run the application – content of HTML is displayed

7.	Add an HTML file outside of the wwwroot folder

8.	Run the application – content of HTML outside wwwroot folder not displayed

####	Task 1: Create a new project using the ASP.NET Core Empty project template.

1. Open Visual Studio 2017 and create a new ASP.NET Core Web Application by using the following information:

-   Name:  **PollBall**
-   Location:  **Allfiles\Mod03\Labfiles\01_PollBall_begin**
-   Solution name:  **PollBall**
-   Create directory for solution: True
-   Project template:  **Empty**

2. Add a method for the **Startup** class by using the following information:

-   Scope: **public**
-   Return Type: **void**
-   Name: **Configure**
-   Parameter Type: **IApplicationBuilder**
-   Parameter Name: **app**

3. Add an **app.Run** middleware within the **Configure** method that prints the "Hello World!" text into the browser.

####	Task 2: Run the application.

1.  Start the  **PollBall**  project with debugging.
    
2.  Verify that **Hello Word !** is displayed in the browser.

3.  Stop debugging.

####	Task 3: Add an HTML file to the wwwroot folder.

1. Create a new subfolder, and copy a CSS file to the new folder by using the following information:

     -   Parent directory of the new directory: **wwwroot**
     -   New folder name: **css**
     -   CSS file to be copied: **style.css**
     -   Source location of the CSS file: **Allfiles\Mod03\Labfiles\01_PollBall_begin**

2. Copy the **images** folder from the **Allfiles\Mod03\Labfiles\01_PollBall_begin** path to the  project's **wwwroot** folder.

3. Create a new **HTML Page** by using the following information:

     -   File name: **poll-questions.html**
     -   Parent Directory: **wwwroot**

4. Inside the **BODY** element, Create a **P** Element with a **H1** element inside it. Fill them with guiding text for the user. The text should guide the user to select his favorite game from the list in the poll and click the **submit query**.

5. Add a **FORM** element to the **BODY** element with a class named **submit-form**.

6. Create a **DIV** element inside the **FORM** element with a class named **main-div**.

7. Create another **DIV** element inside the **FORM** element with a class named **submit-batch**.

8. Inside the **submit-batch** **DIV** element, add an **input** tag by using the following information:
    - Input type: **submit**
    - Value: **Submit Query**

8. Inside the **submit-batch** **DIV** element create a button of type **SUBMIT**.

9. Open the **Allfiles\Mod03\Labfiles\01_PollBall_begin\html-text.txt** existing file and copy the content into the **DIV** with the **main-div** class you created.

####	Task 4: Run the application – content of HTML not displayed.

1.  Start the  **PollBall**  project with debugging.

2. Access the following relative URL:
   
     - **/poll-questions.html**

2.  Verify that **Hello Word !** is displayed in the browser.

3.  Stop debugging.

####	Task 5: Enable working with static files.

1. In the **Startup** class,  add the **UseStaticFiles** method call in the **Configure** method, just before the app.use call.

####	Task 6 : Run the application – content of HTML is displayed.

1.  Start the  **PollBall**  project with debugging.

2. Access the following relative URL:
   
     - **/poll-questions.html**

3.  Verify that the **poll-questions.html** file content is displayed in the browser.

4.  Stop debugging.

6. To link the new style sheet, add a  **link**  element to the  **poll-questions.html**  file by using the following information:

-   Type:  **text/css**
-   Relation:  **stylesheet**
-   Href:  **~/css/style.css**

7. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.

8.  Start the  **PollBall**  project with debugging.

9. Access the following relative URL: 
   
     - **/poll-questions.html**

10.  Verify that the **poll-questions.html** file content is displayed in the browser with design from the **style.css** file.

11.  Stop debugging. 

####	Task 7: Add an HTML file outside of the wwwroot folder.

1. Copy the **test.html** file from the **Allfiles\Mod03\Labfiles\01_PollBall_begin** path to the project's main directory folder.

####	Task 8: Run the application – content of HTML outside wwwroot folder not displayed.

1.  Start the  **PollBall**  project with debugging.

2. Access the following relative URL:
   
     - **/poll-questions.html**

3.  Verify that the **Hello Word !** text is displayed in the browser.

4.  Stop debugging. 

>**Result**: At the end of this exercise, you will be able to add and work with static files inside an ASP.NET Core project.

### Exercise 2: Creating Custom Middleware

#### Scenario

The server must receive the client’s request and notify the company for the poll submission.

The main tasks for this exercise are as follows: 

1. Create a middleware

2. Run the application

3. Change the order of middleware

####	Task 1: Create a middleware.

1. Create a custom middleware that checks the value of the **favorite** parameter that is submitted from the form. Skip the middleware if the **favorite** parameter is missing.

2. Write to the page output the selected value from the form.

####	Task 2: Run the application.

1.  Start the  **PollBall**  project with debugging.

2. Access the following relative URL:
   
     - **/poll-questions.html**

3. Select the **Basketball**  radio button, and click the **Submit Form** button.

3.  Verify that the **Selected Value is = Basketball** text is displayed in the browser.

4.  Stop debugging. 

####	Task 3: Change the order of middleware.

1. Move the **app.UseStaticFiles** before the custom middleware.

2.  Start the  **PollBall**  project with debugging.

3. Access the following relative URL:
   
     - **/poll-questions.html**

4. Select the **Basketball** radio button, and click the **Submit Form** button.

5.  Verify that the **poll-questions.html** file content is displayed in the browser, and that the browser did not load a different page.

6.  Stop debugging. 

7. Move the **app.UseStaticFiles** between the custom middleware and the **app.Run**.

8. Comment the **next.Invoke();** line of code that skips the custom middleware if the request query does not contains the favorite parameter.

9.  Start the  **PollBall**  project with debugging.

10. Access the following relative URL:
   
     - **/poll-questions.html**

11.  Verify that a blank page is displayed.

12.  Stop debugging. 

13. Uncomment the **next.Invoke();** method call.

>**Result**: At the end of this exercise, you will be able to create a custom middleware and receive HTML form calls to it.

### Exercise 3: Using Dependency Injection

#### Scenario

We need to aggregate the votes and store them for future use. We will use services in order to manage and preserve the data.

The main tasks for this exercise are as follows: 

1. Define an interface for a service

2.	Define an implementation for the service

3.	Use dependency injection

4.	Run the application

####	Task 1:  Define an interface for a service.

1. Create a new top-level folder, in the  **PollBall**  project by using the following information:

-   Folder name:  **Services**

2. Create a new enum by using the following information:

-   Name:  **SelectedGame**
-   Parent folder:  **Services**

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

4. Create a new enum by using the following information:

-   Name:  **lPollResultsService**
-   Parent folder:  **Services**

5. Add a method declaration inside the interface using the following information:

     - Name: **AddVote**
     - Parameter name: **game**
     - Parameter Type: **SelectedGame**
     - Return type: **void**

5. Add a method declaration inside the interface using the following information:

     - Name: **GetVoteResult**
     - Return type: **SortedDictionary**<**SelectedGame**,**int**>

6. Change the inteface scope to **public**.

####	Task 2: Define an implementation for the service.

1. Create a class named **PollResultsService** inside the **Services** folder, and implement the class from the **lPollResultsService** interface.

2. Create the **AddVote** and the **GetVoteResult** methods, as defined by the interface decleration.

3. Create a dictionary that will contain the vote counts per game.

4. Implement the **AddVote** method to increase the counts in the dictionary of a selected game by the **game** parameter value.

5. Implement the **GetVoteResult** method that duplicates the dictionary data to a SortedDictionary, and returns it.


####	Task 3: Use dependency injection.

1. In the **startup** class, in the **ConfigureServices**, add the poll results service using the following information:

     - Interface: **lPollResultsService**
     - Implementation: **PollResultsService**
     - Add method: **Singleton**

2. Inject the **lPollResultsService** interface into the **Configure** method that is inside the **Startup** class using Dependency Injection.

3. Inside the custom middleware, Add a vote to the service by the selected game that is received from the **favorite** parameter. 

4. Inside the custom middleware, print to the page output the vote results from the service. 


####	Task 4: Run the application.

1. Start the  **PollBall**  project with debugging.

2.  Verify that the **This text was generated by the app.Run middleware. wwwroot folder path:** [local path to your wwwroot folder]** text is displayed in the browser.

3. Access the following relative URL:
   
     - **/poll-questions.html**

4. Select the **Basketball**  radio button, and click the **Submit Form** button.

5.  Verify that the following text is displayed in the browser:
**name: Basketball, Votes: 1.**<br>

6. Access the following relative URL:
   
     - **/poll-questions.html**

7. Select the **Football**  radio button, and click the **Submit Form** button.

8.  Verify that the following text is displayed in the browser:
**Game name: Basketball, Votes: 1** <br> 
**Game name: Football, Votes: 1**

9. Access the following relative URL:
   
     - **/poll-questions.html**

10. Select the **Basketball**  radio button, and click the **Submit Form** button.

11.  Verify that the following text is displayed in the browser:
**Game name: Basketball, Votes: 2** <br> 
**Game name: Football, Votes: 1**

12.  Stop debugging.  

>**Result**: At the end of this exercise, you will be able to create and use a service with **Dependency Injection**.

### Exercise 4: Injecting a Service to a Controller

#### Scenario

We need to create a page to show results without submitting a vote.
In this case we will use an MVC controller to show the results.

The main tasks for this exercise are as follows: 

1.	Enable working with MVC

2.	Add a controller

3.	Run the application

4.	Use Dependency Injection in a controller

5.	Run the application


####	Task 1: Enable working with MVC.

1. In the **ConfigureServices** method of the **Startup** class, invoke the **AddMVC** method.

2. In the **Configure** method of the **Startup** class, invoke the **UseMvcWithDefaultRoute** method above the custom middleware.

####	Task 2: Add a controller.

1. Create a new controller using the following information:

-   Controller name:  **HomeController**
-   Template:  **MVC controller - Empty**
-   Folder:  **Controllers**

2. Verify the the index action returns a content with the text **Hello from controller**.

####	Task 3: Run the application.

Start the  **PollBall**  project with debugging.

10. Access the following relative URL:
   
     - **/poll-questions.html**

11.  Verify that the **Hello from controller** text is displayed in the browser.

12.  Stop debugging. 


3. In the **Startup** class, move the **app.Run** block **above** the **app.UseMvcWithDefaultRoute();** middleware.

4. Run the new ASP.NET Core application in **Microsoft Edge**.
     > **Note**: The MVC controller is ignored, and the displayed result is: **Action was not handled by any middleware. App run is executing. wwwroot folder path:** \[local path to your wwwroot folder\].

5. Close the **Microsoft Edge** window.

6. In the **Startup** class, move the **app.Run** block to be the last code block in the **Configure** method.


####	Task 4: Use Dependency Injection in a controller.

1. Inject the **IPollResultsService** into the **HomeController's** class constructor, and save it to a global variable.

2. Inside the **index** action of the **HomeController** class, replace its content with the service results, and return the results with the **Content** method.

####	Task 5: Run the application.

1. Start the  **PollBall**  project with debugging.

2.  Verify that the **This text was generated by the app.Run middleware. wwwroot folder path:** [local path to your wwwroot folder]** text is displayed in the browser.

3. Access the following relative URL:

     - **/poll-questions.html**

4. Select the **Basketball**  radio button, and click the **Submit Form** button.

5.  Verify that the following text is displayed in the browser:
**name: Basketball, Votes: 1.**<br>

6. Access the following relative URL:
   
     - **/poll-questions.html**

7. Select the **Football**  radio button, and click the **Submit Form** button.

8.  Verify that the following text is displayed in the browser:
**Game name: Basketball, Votes: 1** <br> 
**Game name: Football, Votes: 1**

9. Access the following relative URL:
   
     - **/poll-questions.html**

10. Select the **Basketball**  radio button, and click the **Submit Form** button.

11.  Verify that the following text is displayed in the browser:
**Game name: Basketball, Votes: 2** <br> 
**Game name: Football, Votes: 1**

12. Access the following relative URL:

     - **/**

13. Verify that the following text is displayed in the browser:
**Game name: Basketball, Votes: 2** <br> 
**Game name: Football, Votes: 1**

14.  Stop debugging.  

>**Result**: At the end of this exercise, you will be able to create controller, and inject a service into it with **Dependency Injection**. 
