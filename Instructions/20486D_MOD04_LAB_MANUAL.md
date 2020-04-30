# Module 4: Developing Controllers

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lab: Developing Controllers

#### Scenario

You have been asked to add controllers to a new application.
The controllers should include actions that return a view, also add an action that returns the photo as a .jpg file to show on a webpage, and an action that redirects to another action in another controller.
Additionally, you have been asked to configure routes in a variety of ways.

The members of your development team are new to ASP.NET Core MVC and they find the use of controller actions confusing. Therefore, you need to help them by adding a component that displays action parameters in an external file whenever an action runs. To achieve this, you will add an action filter.

#### Objectives

After completing this lab, you will be able to:

- Add an MVC controller to a web application.
- Write actions in an MVC controller that respond to user operations.
- Add custom routes to a web application. 
- Write action filters that run code for multiple actions.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course.

2. Navigate to **[Repository Root]\Allfiles\Mod04\Democode\01_WorldJourney_begin**, and then open the **WorldJourney.sln**.

    >**Note**: If a **Security Warning for WorldJourney** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **WorldJourney - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this lab.

5. In Microsoft Edge, click **Close**.

### Exercise 1: Adding Controllers and Actions to an MVC Application

#### Scenario

In this exercise, you will create the MVC controller that handles user operations. You will also add the following actions:

- **Index**. This action displays the **Index** view.
- **Display**. This action takes an ID to find a single **City** object. It passes the **City** object to the **Display** view.
- **GetImage**. This action returns the photo image from the service as a .jpg file.

The main tasks for this exercise are as follows:

1. Add controllers to an MVC application

2. Add actions to a controller

3. Change actions to get a parameter

4. Change an action to redirect to another action in another controller

5. Use a service

6. Store the result in a ViewBag property

7. Run the application

#### Task 1: Add controllers to an MVC application

1. From **[Repository Root]\Allfiles\Mod04\Labfiles\01_WorldJourney_begin**, open the **WorldJourney.sln**.

    >**Note**: If a **Security Warning for WorldJourney** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **WorldJourney** project, create a new top-level folder, and name it **Controllers**.

3. Create a new controller with the following information:
   - Controller name: **HomeController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

4. Create a new controller with the following information:
   - Controller name: **CityController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

#### Task 2: Add actions to a controller

1. In the **CityController** class, add the **using** statements for the following namespaces:
   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **WorldJourney.Models**

2. In the **Index** action, save the following key and value in the **ViewData** property:
    - Key: **Page**
    - Value: **Search city**

3. Add a method for the **Details** action with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Details**

4. In the **Details** action code block, save the following key and value in the **ViewData** property:
    - Key: **Page**
    - Value: **Selected city**

5. Add a variable named *city* of type **City** with the value of **null**. 

6. Create an **IF** statement that checks whether the value of the *city* variable is  **null**. If the value is **null**, return the **NotFoundResult** result by using the **NotFound** method.

7. After the **IF** statement, return the **ViewResult** result by using the **View** method. Pass the *city* variable as a parameter to the **View** method.

8. Add a method for the **GetImage** action with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **GetImage**

9. In the **GetImage** action code block, save the following key and value in the **ViewData** property:
    - Key: **Message**
    - Value: **Display Image**

10. Add a variable named *requestedCity* of type **City** with the value of **null**.

11. Create an **IF** statement that checks that the value of the *requestedCity* variable is not null. 

12. Inside the **IF** statement, add a variable named *fullPath* of type **string** with a value of empty string (**""**).

13. Add a variable named *fileOnDisk* of type **FileStream**. 

14. Initialize the *fileOnDisk* variable by using the **FileStream** constructor and pass it the following parameters: **fullPath** and **FileMode.Open**. 

15. Create a variable named *fileBytes* of type **byte[]**.

16. Create a variable named *br* of type **BinaryReader** inside a **USING** statement.

17. Initialize the *br* variable by using the **BinaryReader** constructor and pass it the following parameter: **fileOnDisk**.  

18. Inside the **USING** statement block, assign the **fileBytes** variable the following value: **br.ReadBytes((int)fileOnDisk.Length)**.

19. After the **USING** statement block, return a **FileResult** result by using the **File** method. Pass the following parameters to the **File** method: **fileBytes** and **requestedCity**. 

20. After the end of **IF** statement, add an **ELSE** statement.

21. Inside the **ELSE** statement, return the **NotFoundResult** result by using the **NotFound** method.

#### Task 3: Change actions to get a parameter

1. Change the **Details** action signature to accept the following parameter:
    - Type: **int?** 
    - Name: **Id**

2. Change the **GetImage** action signature to accept the following parameter:
    - Type: **int?** 
    - Name: **CityId**

#### Task 4: Change an action to redirect to another action in another controller

1. In the **HomeController** class, edit the code in the **Index** action, and remove the code that returns the **ViewResult** result by using the **View** method.

2. Return the **RedirectToActionResult** result by using the **RedirectToAction** method. Pass **"Index"** and **"City"** as parameters to the **RedirectToAction** method.


#### Task 5: Use a service

1. In the **CityController** class, create a new field with the following information:
   - Scope: **private**
   - Type: **IData**
   - Name: **_data** 

2. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHostingEnvironment**
   - Name: **_environment** 

3. Add a constructor with the following parameters:
    - Parameter: 
        - Type: **IData** 
        - Name: **data**
    - Parameter: 
        - Type: **IHostingEnvironment**
        - Name: **environment**

4. In the **CityController** constructor, initialize the **_data** field with the value of the **data** parameter.

5. Initialize the **_environment** field with the value of the **environment** parameter.

6. Call the **CityInitializeData** method of the **_data** field. 

7. In the **Details** action, initiate the *city* variable with the value of **_data.GetCityById(id)** instead of **null**.

8. In the **GetImage** action, initiate the *requestedCity* variable with the value of **_data.GetCityById(cityId)** instead of **null**.

9. At the beginning of **IF** statement, add a variable named *webRootpath* of type **string** with the value of **_environment.WebRootPath**. 

10. Add a variable named *folderPath* of type **string** with the value of  **"\\images\\"**.

11. Initiate the value of the **fullPath** variable with the value of  **webRootpath + folderPath + requestedCity.ImageName** instead of a empty string **("")**.


#### Task 6: Store the result in a ViewBag property

1. In the **Details** action code block, above the **return** statement, save the following key and value in the **ViewBag** property:
     - Key: **Title**
     - Value: **city.CityName**

#### Task 7: Run the application

1. Save all the changes.

2. Start the application without debugging.

    >**Note**: The browser displays the **Index** action result inside the **City** controller.

3.  Click the **London** area on the **Earth** image. Note the red arrow at the center of the **Earth** image.

    >**Note**: The browser displays the **Details** action result inside the **City** controller.

4. Close Microsoft Edge.

>**Results**: After completing this exercise, you can create MVC controllers that implement common actions for the **City** model class in the application. 

### Exercise 2: Configuring Routes by Using the Routing Table

#### Scenario

An important design priority for the application is that the visitors should be able to easily and logically locate cities. To implement these priorities, you have been asked to configure routes by using the routing table that enables the entry of user-friendly URLs to access cities.

The main tasks for this exercise are as follows:

1. Add a controller with an action

2. Run the application

3. Register new routes in the routing table

4. Run the application and verify that the new route works

#### Task 1: Add a controller with an action

1. Create a new controller with the following information:
   - Controller name: **TravelerController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

2.  Change the **Index** action signature to accept the following parameter:
    - Type: **string** 
    - Name: **name**

3. At the beginning of the **Index** action code block,  save the following key and value in the **ViewBag** property:
     - Key: **VisiterName**
     - Value: **name**

#### Task 2: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In Microsoft Edge, request the following relative URL.
   - URL: **/Traveler/Index**

    >**Note**: In the next task you will register a new route with the routing table. Then, you will not need to manually enter the **Traveler/Index** relative URL in the address bar.


4. Close Microsoft Edge.

#### Task 3: Register new routes in the routing table

1. In the **Startup** class, replace **app.UseMvcWithDefaultRoute**  with **app.UseMvc**.

2. In the **app.UseMvc** method, use the **MapRoute** method to add a custom route with the following information: 
    - Name: **TravelerRoute**
    - Template: **{controller}/{action}/{name}**
    - Defaults: **controller = "Traveler", action = "Index", name = "Katie Bruce"**
    - Constraints: **name = "[A-Za-z ]+"**

    >**Note**: You can replace the default name **Katie Bruce** with your name.

3. Use the **MapRoute** method to add another custom route with the following information: 
    - Name: **defaultRoute**
    - Template: **{controller}/{action}/{id?}**
    - Defaults: **controller = "Home", action = "Index"**
    - Constraints: **id = "[0-9]+"**

#### Task 4: Run the application and verify the new route works

1. Save all the changes.

2. Start the application without debugging.

    >**Note**:  The name **"Katie Bruce"** shown in the title comes from the new  **"TravelerRoute"** route, registered in the routing table.

3. Close Microsoft Edge.

>**Results**: After completing this exercise, you can register new custom routes in the request pipeline for controllers in the application.

### Exercise 3: Configuring Routes by Using Attributes

#### Scenario

In addition to configuring routes by using the routing table, you have been asked to configure routes by using attributes as well to enable the entry of user-friendly URLs.

The main tasks for this exercise are as follows:

1. Apply custom routes to a controller by using attributes

2. Run the application and verify that the new routes work

#### Task 1: Apply custom routes to a controller by using attributes

1. In the **CityController** class, annotate the **Index** action with the **Route** attribute. Pass **"WorldJourney"** as a parameter to the **Route** constructor.

2. Annotate the **Details** action with the **Route** attribute. Pass **"CityDetails/{id?}"** as a parameter to the **Route** constructor.

#### Task 2: Run the application and verify the new routes work

1. Save all the changes.

2. Start the application without debugging.

3. Using the **Developer Tools**, move your cursor over the **Go Next** button and verify that the **href** attribute value in the **a** tag is **/WorldJourney**.

4. Click **Go Next**.

    >**Note**: Verify that the new route works. As a result of applying a custom route to **CityController** in the **Index** action by using attributes, **http://localhost:[port]/WorldJourney** should appear in the address bar.

5. Using the **Developer Tools**, move your cursor over the **Earth** image and verify that the **href** attribute value in the **area** tag is **/CityDetails/2**.

6. On the **Earth** image, click the **London** area. Note the red arrow at the center of the **Earth** image.

    >**Note**: Verify that the new route works. As a result of applying a custom route to a **CityController** in the **Details** action using attributes, **http://localhost:[port]/CityDetails/2** should appear in the address bar.

7. Close Microsoft Edge.

>**Results**: After completing this exercise, you can add custom routes to the **City** controller by using the **Route** attribute.

### Exercise 4: Adding an Action Filter

#### Scenario

Your development team is new to ASP.NET Core MVC and is having difficulty in passing the right parameters to controllers and actions. You need to implement a component that displays the controller names and action names in an external file to help with this problem. In this exercise, you will create an action filter for this purpose.

The main tasks for this exercise are as follows:

1. Add an action filter class

2. Add a handler for the OnActionExecuting event

3. Add a handler for the OnActionExecuted event

4. Add a handler for the OnResultExecuted event

5. Apply the action filter to the controller action

6. Run the application and verify that the new filter works

#### Task 1: Add an action filter class

1. In the **WorldJourney** project, create a new top-level folder, and name it **Filters**.

2. Create a new class for the action filter with the following information:
   - Name: **LogActionFilterAttribute**
   - Folder: **Filters**

3. Add the **using** statements for the following namespaces:
   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **Microsoft.AspNetCore.Mvc**
   - **Microsoft.AspNetCore.Mvc.Filters**

4. Change the **LogActionFilterAttribute** class to inherit from the **ActionFilterAttribute** class.

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHostingEnvironment**
   - Name: **_environment** 

6. Create a new field with the following information:
   - Scope: **private**
   - Type: **string**
   - Name: **_contentRootPath** 

7. Create a new field with the following information:
   - Scope: **private**
   - Type: **string**
   - Name: **_logPath**

8. Create a new field with the following information:
   - Scope: **private**
   - Type: **string**
   - Name: **_fileName** 

9. Create a new field with the following information:
   - Scope: **private**
   - Type: **string**
   - Name: **_fullPath** 

10. Add a constructor with the following parameter: 
    - Type: **IHostingEnvironment**
    - Name: **environment**

11. In the constructor, initialize the **_environment** field with the value of the **environment** parameter.

12. Initialize the **_contentRootPath** field with the value of **_environment.ContentRootPath**.

13. Initialize the **_logPath** field with the value of **_contentRootPath + "\\LogFile\\"**.

14. Initialize the **_fileName** with the value of **$"log {DateTime.Now.ToString("MM-dd-yyyy-H-mm")}.txt"**.

15. Initialize the **_fullPath** field with the value of **_logPath + _fileName"**.
         
#### Task 2: Add a handler for the OnActionExecuting event

1. In the **LogActionFilterAttribute** class, add an override method with the following information:
    - Scope: **public**
    - Return type: **void**
    - Name: **OnActionExecuting**
      
2. Change the **OnActionExecuting** method signature to accept the following parameter:
    - Type: **ActionExecutingContext** 
    - Name: **filterContext**

3. In the **OnActionExecuting** method code block, call the static **CreateDirectory** method of the **Directory** class, and pass the **_logPath** field as a parameter.

4. Add a variable named *actionName* of type **string** and initialize it with the value of **filterContext.ActionDescriptor.RouteValues["action"]**.

5. Add a variable named *controllerName* of type **string** and initialize it with the value of **filterContext.ActionDescriptor.RouteValues["controller"]**.

6. Create a variable of type **FileStream** named *fs* inside a **USING** statement. 

7. Initialize the *fs* variable by using the **FileStream** constructor, and pass it with the following parameters: **_fullPath**, and **FileMode.Create**.  

8. In the **USING** statement code block, create a nested **USING** statement.

9. In the nested **USING** statement, create a variable of type **StreamWriter** named *sw*.

10. Initialize the *sw* variable by using the **StreamWriter** constructor with *fs*  variable as a parameter.

11. Inside the nested **USING** statement code block, call the **WriteLine** method of the *sw* variable, and pass it the following string **$"The action {actionName} in {controllerName} controller started, event fired: OnActionExecuting"** as a parameter.


#### Task 3: Add a handler for the OnActionExecuted event

1. In the **LogActionFilterAttribute** class, add an override method with the following information:
    - Scope: **public**
    - Return type: **void**
    - Name: **OnActionExecuted**
      
2. Change the **OnActionExecuted** method signature to accept the following parameter:
    - Type: **ActionExecutedContext** 
    - Name: **filterContext**

3. Add a variable named *actionName* of type **string** and initialize it with the value **filterContext.ActionDescriptor.RouteValues["action"]**.

4. Add a variable named *controllerName* of type **string** and initialize it with the value **filterContext.ActionDescriptor.RouteValues["controller"]**.

5. Create a variable of type **FileStream** named *fs* inside a **USING** statement. 

6. Initialize the *fs* variable by using the **FileStream** constructor and pass it with the following parameters: **_fullPath**, **FileMode.Append**.  

7. In the **USING** statement code block, create a nested **USING** statement.

8. In the nested **USING** statement, create a variable of type **StreamWriter** named *sw*.

9. Initialize the *sw* variable by using the **StreamWriter** constructor with the *fs*  variable as a parameter.

10. Inside the nested **USING** statement code block, call the **WriteLine** method of the *sw* variable, and pass it with the following string **$"The action {actionName} in {controllerName} controller finished, event fired: OnActionExecuted"** as a parameter.


#### Task 4: Add a handler for the OnResultExecuted event

1. In the **LogActionFilterAttribute** class, add an override method with the following information:
    - Scope: **public**
    - Return type: **void**
    - Name: **OnResultExecuted**
      
2. Change the **OnResultExecuted** method signature to accept the following parameter:
    - Type: **ResultExecutedContext** 
    - Name: **filterContext**

3. Add a variable named *actionName* of type **string** and initialize it with the value of **filterContext.ActionDescriptor.RouteValues["action"]**.

4. Add a variable named *controllerName* of type **string** and initialize it with the value of **filterContext.ActionDescriptor.RouteValues["controller"]**.

5. Add a variable named *result* of type **ViewResult** and initialize it with the value of **(ViewResult)filterContext.Result**.

6. Create a variable of type **FileStream** named *fs* inside a **USING** statement. 

7. Initialize the *fs* variable by using the **FileStream** constructor, and pass it with the following parameters: **_fullPath**, **FileMode.Append**.  

8. In the **USING** statement code block, create a nested **USING** statement.

9. In the nested **USING** statement, create a variable of type **StreamWriter** named *sw*.

10. Initialize the *sw* variable by using the **StreamWriter** constructor with the *fs*  variable as a parameter.

11. Inside the nested **USING** statement code block, call the **WriteLine** method of the *sw* variable, and pass it with the following string **$"The action {actionName} in {controllerName} controller has the following viewData : {result.ViewData.Values.FirstOrDefault()}, event fired: OnResultExecuted""** as a parameter.

#### Task 5: Apply the action filter to the controller action

1. In the **Startup** class, add a **using** statement for the following namespace:
   - **WorldJourney.Filters**

2. At the end of the **ConfigureServices** method, call the **AddScoped<LogActionFilterAttribute>** method of the **services** parameter.

3. In the **CityController** class, add a **using** statement for the following namespace:
   - **WorldJourney.Filters**

4. In the **CityController** class, annotate the **Index** action with the **ServiceFilter** attribute. Pass **"typeof(LogActionFilterAttribute)"** as a parameter to the **ServiceFilter** constructor.

#### Task 6: Run the application and verify the new filter works

1. Save all the changes.

2. Start the application without debugging.

3. Click **Go Next**. 

4.  Click the **London** area on the **Earth** image. Note the red arrow at the center of the **Earth** image.

5. Click **Go Back**.

6. Close Microsoft Edge.

7. Close **WorldJourney** Microsoft Visual Studio.

8. Navigate to the **[Repository Root]\Allfiles\Mod04\Labfiles\01_WorldJourney_begin\WorldJourney\LogFile**.

    >**Note**: The text file displays the new filter result.

>**Results**: After completing this exercise, you can create an action filter class that logs the details of actions, controllers, and parameters to an external file whenever an action is called.

©2019 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
