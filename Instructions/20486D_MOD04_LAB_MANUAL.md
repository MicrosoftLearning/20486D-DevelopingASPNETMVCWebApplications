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

3. Create a new controller with the following information:
   - Controller name: **HomeController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

4. Create a new controller for handling the **City** objects with the following information:
   - Controller name: **CityController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

#### Task 2: Add actions to a controller

1. In the **CityController** class, add the **using** statements to the controller for the following namespaces:
   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **WorldJourney.Models**

2. Edit the code in the **Index** action by saving the following  parameter key and value in the **ViewData** dictionary to use it later in the view.
    - Key: **Page**
    - Value: **Search city**

3. Add a method for the **Details** action with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Details**

4. In the **Details** action code block, add code to find a single **City** object from its **ID**.

5. If no city with the right ID is found, return the **HttpNotFound** value.

6. If a city with the right ID is found, pass it to the **Details** view.

7. Add a method for the **GetImage** action with the following information:
       - Scope: **public**
       - Return type: **IActionResult**
       - Name: **GetImage**

8. If the **City** object is not null, return a **File** result constructed from the **city.ImageName** and **city.ImageMimeType** properties, else return the **HttpNotFound** value.

#### Task 3: Change actions to get a parameter

1. Edit the code in the **Details** action with the following information:
    - Parameter: A Nullable integer named **Id**

2. Edit the code in the **GetImage** action with the following information:
    - Parameter: A Nullable integer named **CityId**

#### Task 4: Change an action to redirect to another action in another controller

- In the **HomeController** class, edit the code in the **Index** action, and redirect the user to the **Index** action of the **City** controller.

#### Task 5: Use a service

1. In the **CityController** class, create a new object with the following information:
   - Scope: **private**
   - Class: **IData**
   - Name: **_data** 
   
    Initialize the new object in the **CityController** constructor with the value **IData data**.

2. In the **CityController** class, create a new object with the following information:
   - Scope: **private**
   - Class: **IHostingEnvironment**
   - Name: **_environment** 

    Initialize the new object in the **CityController** constructor with the value **IHostingEnvironment environment** .

3. Edit the code in the **Details** action with the following information:
   - Return class: **View**
   - View name: **Details**
   - Model: **_data.GetCityById(id)**
 
4. Edit the code in the **GetImage** action with the following information:
   - Return class: **View**
   - View name: **GetImage**
   - Model: **_data.GetCityById(id)**
 
5. In the **GetImage** action, initialize the **fullPath** object to refer to the name of the image under the **images** directory.

#### Task 6: Store the result in a ViewBag property

-   In **CityController.cs**, edit the code in the **Index** action by saving the following **Title** parameter value in the **ViewBag** collection to use it later in the view.
    - Value: **city.CityName**

#### Task 7: Run the application

1. Save all the changes.

2. Start debugging the application.

3. On the **Earth** image, click the **London** area. Note the red arrow at the center of the **Earth** image.

4. Stop debugging.

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

1. Create a new controller with the following information:
   - Controller name: **TravelerController**
   - Template: **MVC controller - Empty**
   - Folder: **Controllers**

2. Edit the code in the **Index** action with the following information:
    - Parameter: A string called **name**

3. Edit the code in the **Index** action by saving the **VisiterName** parameter value in the **ViewBag** collection to use it later in the view.
    - Value: **name**

#### Task 2: Run the application

1. Save all the changes.

2. Start debugging the application.

3. In the **Microsoft Edge** window, request the folllowing relative URL.
   - URL: **/Traveler/Index**

4. Stop debugging.

#### Task 3: Register new routes in the routing table

1. In the **Startup.cs** class, replace **app.UseMvcWithDefaultRoute** with custom routes with the following information: 
    - Name: **TravelerRoute**
    - Template: **{controller}/{action}/{name}**
    - Defaults: **controller = "Traveler", action = "Index", name = "Katie Bruce"**

2. In the **Startup.cs** class, add another custom route with the following information: 
    - Name: **defaultRoute**
    - Template: **{controller}/{action}/{id?}**
    - Defaults: **controller = "Home", action = "Index"**

3. In the  **defaultRoute** custom route, add constraints to the **id** parameter. The **id** parameter can be any number between 0 and 9.

#### Task 4: Run the application and verify the new route works

1. Save all the changes.

2. Start debugging the application.

    >**Note:** The browser displays the **Index** action view result inside the **Traveler** controller. The name shown in the title comes from the new registered route in the **TravelerRoute**routing table.

3. Stop debugging.

>**Results** : After completing this exercise, you will be able to register new custom routes in the request pipeline for controllers in the application.

### Exercise 3: Configuring Routes Using Attributes

#### Scenario

In addition to configuring routes by using the routing table, you have been asked to configure routes by using attributes as well, to enable the entry of user-friendly URLs.

The main tasks for this exercise is as follows:

1. Apply custom routes to a controller using attributes.

2. Run the application and verify the new routes work.

#### Task 1: Apply custom routes to a controller using attributes

1. In the **CityController** class, add a custom route by using attribute to the **Index** action method.

2. In the **CityController** class, add a custom route by using attribute to the **Details** action method.

#### Task 2: Run the application and verify the new routes work

1. Save all the changes.

2. Start debugging the application.

3. Using the **Developer Tools**, move your cursor over the **Go Next** button and check the **href** attribute value in the **a** tag.

4. Click **Go Next**.

5. Using the **Developer Tools**, move your cursor over the **Earth** image and check the **href** attribute value in the **area** tag.

6. On the **Earth** image, click the **London** area. Note the red arrow at the center of the **Earth** image.

7. Stop debugging.

>**Results** : After completing this exercise, you will be able to add custom routes by using attributes for the **City** controller in the application.

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

1. Create a new class for the action filter with the following information:
   - Name: **LogActionFilter**
   - Folder: **Filters**

2. Add the **using** statements to the controller for the following namespaces:
   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **Microsoft.AspNetCore.Mvc**
   - **Microsoft.AspNetCore.Mvc.Filters**

3. Ensure that the **LogActionFilter** class inherits from the **ActionFilterAttribute** class.

4. In the **LogActionFilter** class, create a new object with the following information:
   - Scope: **private**
   - Class: **IHostingEnvironment**
   - Name: **_environment** 

    Initialize the new object in the **LogActionFilter** constructor with the **IHostingEnvironment environment** value.

5. In the **LogActionFilter** class, create a new object with the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **contentRootPath** 

    Initialize the new object in the **LogActionFilter** constructor with the **_environment.ContentRootPath** value.

6. In the **LogActionFilter** class, create a new object with the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **logPath** 

    Initialize the new object in the **LogActionFilter** constructor with the **contentRootPath + "\\LogFile\\"** value.

7. In the **LogActionFilter** class, create a new object with the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **fileName** 

    Initialize the new object in the **LogActionFilter** constructor with the **$"log {DateTime.Now.ToString("MM-dd-yyyy-H-mm")}.txt"** value.

8. In the **LogActionFilter** class, create a new object with the following information:
   - Scope: **private**
   - Data type: **string**
   - Name: **fullPath** 

    Initialize the new object in the **LogActionFilter** constructor with the **logPath + fileName** value.   

#### Task 2: Add a handler for the OnActionExecuting event

1. In the **LogActionFilter** action filter, override the **OnActionExecuting** event handler.

2. Delete the **base.OnActionExecuting** code block.

3. In the **OnActionExecuting** event handler, create and write the names of the action and the controller to an external file.

#### Task 3: Add a handler for the OnActionExecuted event

1. In the **LogActionFilter** action filter, override the **OnActionExecuted** event handler.

2. Delete the **base.OnActionExecuted** code block.

3. In the **OnActionExecuting** event handler, write to an external file the names of the action and the controller.

#### Task 4: Add a handler for the OnResultExecuted event

1. In the **LogActionFilter** action filter, override the **OnResultExecuted** event handler.

2. Delete the **base.OnResultExecuted** code block.

3. In the **OnResultExecuted** event handler, write the parameters of action, controller and viewData to an external file.

#### Task 5: Apply the action filter to the controller action

1. Add the **using** statements to the **Startup.cs** class for the following namespaces:
   - **WorldJourney.Filters**

2. In the **Startup.cs** class, add **LogActionFilter** to the **services** container as **Scoped**.

3. Add the **using** statements to the **CityController** class for the following namespaces:
   - **WorldJourney.Filters**

4. In the **CityController** class, add the **LogActionFilter** action filter to the **Index** action method.

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