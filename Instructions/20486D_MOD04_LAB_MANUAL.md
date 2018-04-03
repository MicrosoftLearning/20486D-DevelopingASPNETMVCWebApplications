## Module 4: Developing Controllers

## Lab: Developing Controllers

#### Scenario

You  have been asked to add controllers to a new application.
The controller should include actions that return a view, and that respond when users display a single photo. You should also add an action that returns the photo as a .jpg file to show on a webpage.
Additionally, you are asked to configure routes in a variety of ways.

The members of your development team are new to ASP.NET Core MVC and they find the use of controller actions confusing. Therefore, you need to help them by adding a component that displays action parameters in an external file whenever an action runs. You will add an action filter to achieve this

#### Objectives

After completing this lab, you will be able to:

- Add an MVC controller to a web application.
- Write actions in an MVC controller that respond to user operations.
- Add custom routes to a web application. 
- Write action filters that run code for multiple actions.

#### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Adding controllers and actions to an MVC application

#### Scenario

In this exercise, you will create the MVC controller that handles user operations. You will also add the following actions:

- _Index_. This action displays the Index view.
- _Display_.This action takes an ID to find a single City object. It passes the City object to the Display view.
- _GetImage_. This action returns the photo image from the service as a JPG file.

The main tasks for this exercise are as follows:

1. Create City and Home controllers.

2. Create the Index action in both controllers.

3. Create the Details action in the city controller.

4. Create the GetImage action in the city controller.

5. Change the index action in Home Controller to redirect to index action in the city controller.

6. Use a service in the city controller.

7. Store information in a ViewBag property.

#### Task 1: Add controllers to an MVC application.

1. Open the WorldJourney.sln file from the following location:
**Allfiles\Mod04\Labfiles\01_WorldJourney_begin**

2. Create a new controller using the following information:

   - Controller name: **HomeController**
   - Template: **MVC controller - Empty**

3. Create a new controller for handling **City** objects by using the following information:

   - Controller name: **CityController**
   - Template: **MVC controller - Empty**

#### Task 2: Add an action to a controller.

1. In the **CityController** class, Add **using** statements to the controller for the following namespaces:

   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **WorldJourney.Models**

2. In the **CityController** class, create a new private object using the following information:

   - Scope: **private**
   - Class: **City**
   - Name: **city**

3. In the **CityController** class, create a new private object using the following information:

   - Scope: **private**
   - Class: **City**
   - Name: **requestedCity** 

4. In the **CityController** class, create a new private object using the following information:

   - Scope: **private** 
   - Data type: **string**
   - Name: **fullPath**  

5. Edit the code in the **Index** action by Saving the following  parameter Key and value in the **ViewData** dictionary to use it later in the view.

    - Key: **Page**
    - Value: **Search city**

6. Add a method for the **Details** action by using the following information:

   - Scope: **public**
   - Return Type: **IActionResult**
   - Name: **Details**

7. In the **Details** action code block, add code to find a single **city** object from its **ID**.

8. If no city with the right ID is found, return the **HttpNotFound** value.

9. If a city with the right ID is found, pass it to a view called **Details**.

10. Add a method for the **GetImage** action by using the following information:

     - Scope: **public**
     - Return type: **IActionResult**
     - Name: **GetImage**

11. If the **city** object is not null, return a **File** result constructed from the **city.ImageName** and **city.ImageMimeType** properties, else return the **HttpNotFound** value.

#### Task 3: Change an action to get a parameter.

1. Edit the code in the **Details** action by using the following information:

    - Parameter: a Nullable integer named **Id**

2. Edit the code in the **GetImage** action by using the following information:

    - Parameter: a Nullable integer named **CityId**

#### Task 4: Change an action to redirect to another action in another controller.

1. In the **HomeController** class, Edit the code in the **Index** action, redirect the user to the **Index** action of the **City** controller.

#### Task 5: Use a service.

1. In the **CityController** delete the following private objects:

     -  private **City city**
     -  private **City requestedCity**
     -  private **string fullPath**

2. In the **CityController** class, create a new private object using the following information:

   - Scope: **private**
   - Class: **IData**
   - Name: **_data** 
   
    Instantiate the new object by calling the **CityController** constructor.

3. In the **CityController** class, create a new private object using the following information:

   - Scope: **private**
   - Class: **IHostingEnvironment**
   - Name: **_environment** 

    Instantiate the new object by calling the **CityController** constructor.

4. Edit the code in the **Details** action by using the following information:

   - Return class: **View**
   - View name: **Details**
   - Model: **_data.GetCityById(id)**
 
5. Edit the code in the **GetImage** action by using the following information:

   - Return class: **View**
   - View name: **GetImage**
   - Model: **_data.GetCityById(id)**
 

#### Task 6: Store the result in a ViewBag property.

1. In **CityController.cs**, Edit the code in the **Index** action by Saving the following **Title** parameter value in the **ViewBag** collection to use it later in the view.

    - Value: **city.CityName**

#### Task 7: Run the application.

1. Save all the changes.

2. Start debugging the application and access the following relative path:

    - Path: **/City/index**

3. on the Earth image click the **London** area.

4. Display an image.

5. Stop debugging.

>**Results** : After completing this exercise, you will be able to create MVC controllers that implement common actions for the City model class in the application.

### Exercise 2: Configuring routes by using the routing table

#### Scenario

An important design priority for the application is that the visitors should be able to easily and logically locate cities. To implement these priorities, you have been asked to configure routes using the routing table that enables the entry of user-friendly URLs to access cities.

The main tasks for this exercise are as follows:

1. Create a Traveler controller.

2. Register a new custom route in the request pipeline.

#### Task 1: Add a controller with an action.

1. Create a new controller using the following information:

   - Controller name: **TravelerController**
   - Template: **MVC controller - Empty**

2. Edit the code in the **Index** action by using the following information:

    - Parameter: a string called **name**

3. Edit the code in the **Index** action by Saving the following **VisiterName** parameter value in the **ViewBag** collection to use it later in the view.

    - Value: **name**

#### Task 2: Run the application.

1. Save all the changes.

2. Start debugging the application

    >**Note:** The new **Index** action View result, in the **Traveler** Controller, is not displayed.

3. Stop debugging.

#### Task 3: Register a new route with the routing table.

1. In the **Startup.cs** class, replce the **app.UseMvcWithDefaultRoute** with custom routes with the following information: 

    - name: **TravelerRoute**
    - template: **{controller}/{action}/{name}**
    - defaults: **controller = "Traveler", action = "Index", name = "Katie Bruce"**

2. In the  **TravelerRoute** custom route add defaults to the controller, action, and name parameters.

3. In the **Startup.cs** class, add another custom routes with the following informatin: 

    - name: **defaultRoute**
    - template: **{controller}/{action}/{id?}**

4. In the  **defaultRoute** custom route add defaults to the controller, action, and name parameters.

5. In the  **defaultRoute** custom route add constraints to the **id** parameter.

#### Task 4: Run the application and verify the new route works.

1. Save all the changes.

2. Start debugging the application

    >**Note:** The browser displays the **Index** action view result, in the **Traveler** Controller.

3. Stop debugging.

>**Results** : After completing this exercise, you will be able to Register a new custom route in the request pipeline for the Traveler Controller class in the application.

### Exercise 3: Configuring routes using attributes

#### Scenario

In addition to configuring routes using the routing table, you have been asked to configure routes using attributes as well, to enable the entry of user-friendly URLs.

The main task for this exercise is as follows:

1. Add custom routes to a City controller using attributes.

#### Task 1: Apply custom routes to a controller using attributes.

1. In the **CityController** class, add custom routes using attribute to the **Index** action method.

2. In the **CityController** class, add custom routes using attribute to the **Details** action method.

#### Task 2: Run the application and verify the new routes work.

1. Save all the changes.

2. Start debugging the application

  >**Note:** Verify that the new routes work.

3. Stop debugging.

>**Results** : After completing this exercise, you will be able to add custom routes using attributes for the City Controller in the application.

### Exercise 4: Adding an action filter

#### Scenario

Your development team is new to ASP.NET Core MVC and is having difficulty in passing the right parameters to controllers and actions. You need to implement a component that displays the controller names, and action names, in an external file to help with this problem. In this exercise, you will create an action filter for this purpose.

The main tasks for this exercise are as follows:

1. Add an action filter class.

2. Add a handler for the OnActionExecuting event.

3. Add a handler for the OnActionExecuted event.

4. Add a handler for the OnResultExecuted event.

5. Register the Action Filter with the City Controller.

#### Task 1: Add an action filter class.

1. Create a new class for the action filter by using the following information:

   - Name: **LogActionFilter**
   - Folder: **Filters**

2. Add **using** statements to the controller for the following namespaces:

   - **System.IO**
   - **Microsoft.AspNetCore.Hosting**
   - **Microsoft.AspNetCore.Mvc**
   - **Microsoft.AspNetCore.Mvc.Filters**

3. Ensure that the **LogActionFilter** class inherits from the **ActionFilterAttribute** class.

4. In the **LogActionFilter** class, create a new private object using the following information:

   - Scope: **private**
   - Class: **IHostingEnvironment**
   - Name: **_environment** 

    Instantiate the new object by calling the **LogActionFilter** constructor.

5. In the **LogActionFilter** class, create a new private object using the following information:

   - Scope: **private**
   - Data type: **string**
   - Name: **contentRootPath** 

    Instantiate the new object by calling the **LogActionFilter** constructor.

6. In the **LogActionFilter** class, create a new private object using the following information:

   - Scope: **private**
   - Data type: **string**
   - Name: **logPath** 

    Instantiate the new object by calling the **LogActionFilter** constructor.

7. In the **LogActionFilter** class, create a new private object using the following information:

   - Scope: **private**
   - Data type: **string**
   - Name: **fileName** 

    Instantiate the new object by calling the **LogActionFilter** constructor.

8. In the **LogActionFilter** class, create a new private object using the following information:

   - Scope: **private**
   - Data type: **string**
   - Name: **fullPath** 

    Instantiate the new object by calling the **LogActionFilter** constructor.   

#### Task 2: Add a handler for the OnActionExecuting event.

1. In the **LogActionFilter** action filter, override the **OnActionExecuting** event handler.

2. Delete the **base.OnActionExecuting** code block.

3. In the **OnActionExecuting** event handler, create and write to an external file the **action** name, and the **controller** name.

#### Task 3: Add a handler for the OnActionExecuted event.

1. In the **LogActionFilter** action filter, override the **OnActionExecuted** event handler.

2. Delete the **base.OnActionExecuted** code block.

3. In the **OnActionExecuting** event handler, write to an external file the **action** name, and the **controller** name.

#### Task 4: Add a handler for the OnResultExecuted event.

1. In the **LogActionFilter** action filter, override the **OnResultExecuted** event handler.

2. Delete the **base.OnResultExecuted** code block.

3. In the **OnResultExecuted** event handler, write to an external file the **action** name, the **controller** name and the **viewData** parameters.

#### Task 5: Apply the action filter to the controller action.

1. Add **using** statements to the **Startup.cs** class for the following namespaces:

   - **WorldJourney.Filters**

2. In the **Startup.cs** class add **LogActionFilter** to the services container as **Scoped**.

3. Add **using** statements to the **CityController** class for the following namespaces:

   - **WorldJourney.Filters**

4. In the **CityController** class, and add the **LogActionFilter** action filter to the **Index** action method.

#### Task 6: Run the application and verify the new filter works.

1. Save all the changes.

2. Start debugging the application

3. Navigate to the following location:

    - **Allfiles\Mod04\Labfiles\01_WorldJourney_begin\WorldJourney\Log**

4. Verify the **external file** created and display the new filter result.

5. Stop debugging and close Microsoft Visual Studio.

>**Results** : After completing this exercise, you should have created an action filter class that logs the details of actions, controllers, and parameters to external file whenever an action is called.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.