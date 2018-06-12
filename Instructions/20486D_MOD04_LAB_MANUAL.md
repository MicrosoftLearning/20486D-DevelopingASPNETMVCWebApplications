# Module 4: Developing Controllers

# Lab: Developing Controllers

#### Scenario

You have been asked to add controllers to a new application.
The controllers should include actions that return a view, also add an action that returns the photo as a .jpg file to show on a webpage and an action that redirects to another action in another controller.
Additionally, you are asked to configure routes in a variety of ways.

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

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).


### Exercise 1: Adding Controllers and Actions to an MVC Application

#### Scenario

In this exercise, you will create the MVC controller that handles user operations. You will also add the following actions:

- **Index**. This action displays the **Index** view.
- **Display**. This action takes an ID to find a single **City** object. It passes the **City** object to the **Display** view.
- **GetImage**. This action returns the photo image from the service as a .jpg file.

The main tasks for this exercise are as follows:

1. Add controllers to an MVC application.

2. Add actions to a controller.

3. Change actions to get a parameter.

4. Change an action to redirect to another action in another controller.

5. Use a service.

6. Store the result in a ViewBag property.

7. Run the application.

#### Task 1: Add controllers to an MVC application

1. From **Allfiles\Mod04\Labfiles\01_WorldJourney_begin**, open the **WorldJourney.sln**.

2. In the **WorldJourney** project, create a new top-level folder, and name it **Controllers**.

3. Create a new controller using the following information:
   - Controller name: **HomeController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

4. Create a new controller using the following information:
   - Controller name: **CityController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

#### Task 2: Add actions to a controller

1. In the **CityController** class, add **using** statements for the following namespaces:
   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **WorldJourney.Models**

2. In the **Index** action save the following key and value in the **ViewData** property:
    - Key: **Page**
    - Value: **Search city**

3. Add a method for the **Details** action with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Details**

4. In the **Details** action code block, save the following key and value in the **ViewData** property:
    - Key: **Page**
    - Value: **Selected city**

5. Add a varible named **city** of type **City** with the value of **null**. 

6. Create an **IF** statement that checks that the value of the **city** varible is  **NULL**. If the value is **null**, return the **NotFoundResult** result using the **NotFound** method.

7. After the **IF** statement, return the **ViewResult** result using the **View** method. Pass the **city** varible as a parameter to the **View** method.

8. Add a method for the **GetImage** action with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **GetImage**

9. In the **GetImage** action code block, save the following key and value in the **ViewData** property:
    - Key: **Message**
    - Value: **Display Image**

10. Add a varible named **requestedCity** of type **City** with the value of **null**.

11. Create a **IF** statement that checks that the value of the **requestedCity** varible is not null. 

12. Inside the **IF** statement, add a varible named **fullPath** of type **string** with a value of empty string (**""**).

13. Add a varible named **fileOnDisk** of type **FileStream**. 

14. Initialize the **fileOnDisk** varaible using the **FileStream** constructor and pass it the following parameters: **fullPath** and **FileMode.Open**. 

15. Create a new variable named **fileBytes** of type **byte[]**.

16. Create a new variable named **br** of type **BinaryReader** inside a **USING** statement.

17. Initialize the **br** varaible using the **BinaryReader** constructor and pass it the following parameter: **fileOnDisk**.  
18. Inside the **USING** statement block, assign the **fileBytes** varible the following value: **br.ReadBytes((int)fileOnDisk.Length)**.

19. After the **USING** statement block, return a **FileResult** result using the **File** method. Pass the following parameters to the **File** method: **fileBytes** and **requestedCity**. 

20. After the end of **IF** statment, add an **ELSE** statment.

21. Inside the **ELSE** statment, return the **NotFoundResult** result using the **NotFound** method.

#### Task 3: Change actions to get a parameter

1. Change the **Details** action signature to accept the following parameter:
    - Type: **int?** 
    - Name: **Id**

2. Change the **GetImage** action signature to accept the following parameter:
    - Type: **int?** 
    - Name: **CityId**

#### Task 4: Change an action to redirect to another action in another controller

1. In the **HomeController** class, edit the code in the **Index** action, and remove the code which returns the **ViewResult** result using the **View** method.

2. Return the **RedirectToActionResult** result using the **RedirectToAction** method. Pass **"Index"** and **"City"** as parameters to the **RedirectToAction** method.


#### Task 5: Use a service

1. In the **CityController** class, create a new field using the following information:
   - Scope: **private**
   - Type: **IData**
   - Name: **_data** 

2. Create a new field using the following information:
   - Scope: **private**
   - Type: **IHostingEnvironment**
   - Name: **_environment** 

3. Add a constructor using the following parameters:
    - Parameter: 
        - Type: **IData** 
        - Name: **data**
    - Parameter: 
        - Type: **IHostingEnvironment**
        - Name: **environment**

4. In the **CityController** constructor, initialize the **_data** field with the value of the **data** parameter.

5. Initialize the **_environment** field with the value of the **environment** parameter.

6. Call the **CityInitializeData** method of the **_data** field. 

7. In the **Details** action, initiate the **city** varible with the value of **_data.GetCityById(id)** instead of **null**.

8. In the **GetImage** action, initiate the **requestedCity** varible with the value of **_data.GetCityById(cityId)** instead of **null**.

9. At the beginning of **IF** statment, add a varible named **webRootpath** of type **string** with the value of **_environment.WebRootPath**. 

10. Add a varible named **folderPath** of type **string** with the value of  **"\\images\\"**.

11. Initiate the value of the **fullPath** varible with the value of  **webRootpath + folderPath + requestedCity.ImageName** instead of empty string **("")**..


#### Task 6: Store the result in a ViewBag property

1. In the **Details** action code block, above the **return** statement, save the following key and value in the **ViewBag** property:
     - Key: **Title**
     - Value: **city.CityName**

#### Task 7: Run the application

1. Save all the changes.

2. Start debugging the application.

3.  Click the **London** area on the **Earth** image. Note the red arrow at the center of the **Earth** image.

4. Close **Microsoft Edge**.

5. Stop debugging.

>**Results** : After completing this exercise, you will be able to create MVC controllers that implement common actions for the **City** model class in the application. 

### Exercise 2: Configuring Routes by Using the Routing Table

#### Scenario

An important design priority for the application is that the visitors should be able to easily and logically locate cities. To implement these priorities, you have been asked to configure routes by using the routing table that enables the entry of user-friendly URLs to access cities.

The main tasks for this exercise are as follows:

1. Add a controller with an action.

2. Run the application.

3. Register new routes in the routing table.

4. Run the application and verify the new route works.

#### Task 1: Add a controller with an action

1. Create a new controller using the following information:
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

2. Start debugging the application.

3. In the **Microsoft Edge** window, request the following relative URL.
   - URL: **/Traveler/Index**

4. Close **Microsoft Edge**.

5. Stop debugging.


#### Task 3: Register new routes in the routing table

1. In the **Startup** class, replace **app.UseMvcWithDefaultRoute**  with **app.UseMvc**.

2. In the **app.UseMvc** method, use the **MapRoute** method to add a custom route with the following information: 
    - Name: **TravelerRoute**
    - Template: **{controller}/{action}/{name}**
    - Defaults: **controller = "Traveler", action = "Index", name = "Katie Bruce"**

3. Use the **MapRoute** method, to add another custom route with the following information: 
    - Name: **defaultRoute**
    - Template: **{controller}/{action}/{id?}**
    - Defaults: **controller = "Home", action = "Index"**
    - Constraints: **id = "[0-9]+"**

#### Task 4: Run the application and verify the new route works

1. Save all the changes.

2. Start debugging the application.

3. Close **Microsoft Edge**.

4. Stop debugging.

>**Results** : After completing this exercise, you will be able to register new custom routes in the request pipeline for controllers in the application.

### Exercise 3: Configuring Routes Using Attributes

#### Scenario

In addition to configuring routes by using the routing table, you have been asked to configure routes by using attributes as well, to enable the entry of user-friendly URLs.

The main tasks for this exercise is as follows:

1. Apply custom routes to a controller using attributes.

2. Run the application and verify the new routes work.

#### Task 1: Apply custom routes to a controller using attributes

1. In the **CityController** class, annotate the **Index** action with the **Route** attribute. Pass **"WorldJourney"** as a parameter to the **Route** constructor.

2. Annotate the **Details** action with the **Route** attribute. Pass **"CityDetails/{id?}"** as a parameter to the **Route** constructor.

#### Task 2: Run the application and verify the new routes work

1. Save all the changes.

2. Start debugging the application.

3. Using the **Developer Tools**, move your cursor over the **Go Next** button and verify that the **href** attribute value in the **a** tag is **/WorldJourney**.

4. Click **Go Next**.

5. Using the **Developer Tools**, move your cursor over the **Earth** image and verify that the **href** attribute value in the **area** tag  is **/CityDetails/2**.

6. On the **Earth** image, click the **London** area. Note the red arrow at the center of the **Earth** image.

7. Close **Microsoft Edge**.

8. Stop debugging.

>**Results**: After completing this exercise, you will be able to add custom routes to  the **City** controller by using the **Route** attribute.

### Exercise 4: Adding an Action Filter

#### Scenario

Your development team is new to ASP.NET Core MVC and is having difficulty in passing the right parameters to controllers and actions. You need to implement a component that displays the controller names and action names in an external file to help with this problem. In this exercise, you will create an action filter for this purpose.

The main tasks for this exercise are as follows:

1. Add an action filter class.

2. Add a handler for the **OnActionExecuting** event.

3. Add a handler for the **OnActionExecuted** event.

4. Add a handler for the **OnResultExecuted** event.

5. Apply the action filter to the controller action.

6. Run the application and verify the new filter works.

#### Task 1: Add an action filter class

1. In the **WorldJourney** project, create a new top-level folder, and name it **Filters**.

2. Create a new class for the action filter with the following information:
   - Name: **LogActionFilterAttribute**
   - Folder: **Filters**

3. Add the **using** statements to the controller for the following namespaces:
   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **Microsoft.AspNetCore.Mvc**
   - **Microsoft.AspNetCore.Mvc.Filters**

4. Ensure that the **LogActionFilterAttribute** class inherits from the **ActionFilterAttribute** class.

5. Edit the  **LogActionFilterAttribute** constructor to allow it to accept the following parameters:
    - Parameter: **IData** service named **data**
    - Parameter: **IHostingEnvironment** service named **environment**

5. In the **LogActionFilterAttribute** class, create a new private field usig the following information:
   - Scope: **private**
   - Class: **IHostingEnvironment**
   - Name: **_environment** 

    Initialize the **_environment** field in the **LogActionFilterAttribute** constructor with the value of the **environment** parameter.

6. In the **LogActionFilterAttribute** class, create a new private field using the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **_contentRootPath** 

    Initialize the **_contentRootPath** field in the **LogActionFilterAttribute** constructor with the value of **_environment.ContentRootPath**.

7. In the **LogActionFilterAttribute** class, create a new field using the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **_logPath** 

    Initialize the **_logPath** field in the **LogActionFilterAttribute** constructor using the value of **_contentRootPath + "\\LogFile\\"** .

8. In the **LogActionFilterAttribute** class, create a new field using the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **_fileName** 

    Initialize the **_fileName** field in the **LogActionFilterAttribute** constructor using the value of **$"log {DateTime.Now.ToString("MM-dd-yyyy-H-mm")}.txt"**.

9. In the **LogActionFilterAttribute** class, create a new field using the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **_fullPath** 

    Initialize the **_fullPath** field in the **LogActionFilterAttribute** constructor using the value of **_logPath + _fileName"**.
         
#### Task 2: Add a handler for the OnActionExecuting event

1. In the **LogActionFilterAttribute** action filter, override the **OnActionExecuting** event handler.

2. If the **base.OnActionExecuting** code block was added to the **OnActionExecuting** event handler, delete it.

3.  In the **OnActionExecuting** method code block, call the static **CreateDirectory** method of the **Directory** class and pass the **_logPath** field as a parameter.

4. Add a varible named **actionName** of type **string**  and assign the value of **filterContext.ActionDescriptor.RouteValues["action"]** into it.

5. Add a varible named **controllerName** of type **string**  and assign the value of **filterContext.ActionDescriptor.RouteValues["controller"]** into it.

6. Create an instance of type **FileStream** named **fs** inside a **USING** statement. 

7. Initialize the **fs** variable using the **FileStream** constructor with the following parameters: **_fullPath**, **FileMode.Create**.  

8. Inside the **USING** statement block, create an instance of type **StreamWriter** named **sw** inside a nested **USING** statement.

9. Initialize the **sw** varaible using the **StreamWriter** constructor with **fs**  varible as a parameter.

10. Inside the internal **USING** statement block, use the **WriteLine** method of the **StreamWriter** object to write the following line **$"The action {actionName} in {controllerName} controller started, event fired: OnActionExecuting"** to a file.


#### Task 3: Add a handler for the OnActionExecuted event

1. In the **LogActionFilterAttribute** action filter, override the **OnActionExecuted** event handler.

2. If the **base.OnActionExecuted** code block was added to the **OnActionExecuted** event handler, delete it.

3. Add a varible named **actionName** of type **string**  and assign the value of **filterContext.ActionDescriptor.RouteValues["action"]** into it.

4. Add a varible named **controllerName** of type **string**  and assign the value of **filterContext.ActionDescriptor.RouteValues["controller"]** into it.

5. Create an instance of type **FileStream** named **fs** inside a **USING** statement. 

6. Initialize the **fs** variable using the **FileStream** constructor with the following parameters: **_fullPath**, **FileMode.Append**.  

7. Inside the **USING** statement block, create an instance of type **StreamWriter** named **sw** inside a nested **USING** statement.

8. Initialize the **sw** varaible using the **StreamWriter** constructor with **fs**  varible as a parameter.

9. Inside the internal **USING** statement block, use the **WriteLine** method of the **StreamWriter** object to write the following line **$"The action {actionName} in {controllerName} controller finished, event fired: OnActionExecuted"** to a file.

#### Task 4: Add a handler for the OnResultExecuted event

1. In the **LogActionFilterAttribute** action filter, override the **OnResultExecuted** event handler.

2. If the **base.OnResultExecuted** code block was added to the **OnResultExecuted** event handler, delete it.

3. Add a varible named **actionName** of type **string**  and assign the value of **filterContext.ActionDescriptor.RouteValues["action"]** into it.

4. Add a varible named **controllerName** of type **string**  and assign the value of **filterContext.ActionDescriptor.RouteValues["controller"]** into it.

5. Add a varible named **result** of type **ViewResult**  and assign the value of **(ViewResult)filterContext.Result** into it.

6. Create an instance of type **FileStream** named **fs** inside a **USING** statement. 

7. Initialize the **fs** variable using the **FileStream** constructor with the following parameters: **_fullPath**, **FileMode.Append**.

8. Inside the **USING** statement block, create an instance of type **StreamWriter** named **sw** inside a nested **USING** statement.

9. Initialize the **sw** varaible using the **StreamWriter** constructor with **fs**  varible as a parameter.

10. Inside the internal **USING** statement block, use the **WriteLine** method of the **StreamWriter** object to write the following line **$"The action {actionName} in {controllerName} controller has the following viewData : {result.ViewData.Values.FirstOrDefault()}, event fired: OnResultExecuted""** to a file.

#### Task 5: Apply the action filter to the controller action

1. Add the **using** statements to the **Startup.cs** class for the following namespaces:
   - **WorldJourney.Filters**

2. In the **Startup.cs** class, add **LogActionFilterAttribute** to the **services** container as **Scoped**.

3. Add the **using** statements to the **CityController** class for the following namespaces:
   - **WorldJourney.Filters**

4. In the **CityController** class, add the **LogActionFilterAttribute** action filter to the **Index** action method.

#### Task 6: Run the application and verify the new filter works

1. Save all the changes.

2. Start debugging the application.

3. Click **Go Next**. 

4. On the **Earth** image, click the **London** area. Note the red arrow at the center of the **Earth** image.

5. Click **Go Back**.

6. Stop debugging.

7. Navigate to the **Allfiles\Mod04\Labfiles\01_WorldJourney_begin\WorldJourney\LogFile**.

>**Note:** The text file displays the new filter result.

8. Stop debugging and close Microsoft Visual Studio.

>**Results** : After completing this exercise, you should have created an action filter class that logs the details of actions, controllers, and parameters to external file whenever an action is called.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.