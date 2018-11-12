# Module 12: Performance and Communication

# Lab: Performance and Communication

#### Scenario
TODO: Add scenario


#### Objectives

After completing this lab, you will be able to:

- Implement a caching strategy.
- Manage state.
- Add a two-way communication.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

### Exercise 1: Implementing a Caching Strategy

#### Scenario

TODO: Add scenario

The main tasks for this exercise are as follows:

1.	Add a cache tag helper to a view.

2.	Insert data to be cached by the cache tag helper.

3.	Run the application.

4.	Insert items to a memory cache.

5.	Retrieve items from a memory cache.

6.	Run the application.


#### Task 1: Add a cache tag helper to a view.

1. Open the **Command Prompt** window using **Run as administrator**.

2. In Administrator: Command Prompt, run the following command: **cd <The location of Allfiles\Mod12\Labfiles\01_ElectricStore_begin\ElectricStore folder on your machine>**.

3. Run the following command: **npm install**.

4. Close the **Command Prompt** window.

5. Open the **ElectricStore.sln** solution from the following location: **Allfiles\Mod12\Labfiles\01_ElectricStore_begin**.

6. In the **ElectricStore - Microsoft Visual Studio** window, click **TOOLS** and then click **Options**.

7. In the **Options** dialog box, click **Web Package Management**.

8. In the **Locations of external tools** list box, select **$(PATH)**. Press the **Up** arrow button until **$(PATH)** is at the top of the list, and then click **OK**.

9. Open the **package.json** file and examine its content.

    >**Note:** There are dependencies to the 
    **jquery, jquery-validation, jquery-validation-unobtrusive, bootstrap** and **popper.js** packages.

10. In the **_Layout.cshtml** file, in the **UL** element with the **navbar-nav** class, add a **CACHE** element with the following information:

    - vary-by-user: **true**

11. In the **CACHE** element, call the **Component.InvokeAsync** method using the **@await** operator. Pass **"NavbarMenu"** as a parameter to the **InvokeAsync** method.

#### Task 2: Insert data to be cached by the cache tag helper.

1. Create a new folder with the following information:

    - Folder name: **ViewComponents**

2. Create a new class with the following information:

    - Name: **NavbarMenuViewComponent**
    - Folder: **ViewComponents**   

3. In the **NavbarMenuViewComponent** class, add **USING** statements for the following namespaces:

   - **ElectricStore.Data**
   - **Microsoft.AspNetCore.Mvc**

4. Change the **NavbarMenuViewComponent** class to inherit from the **ViewComponent** class.

5. Create a new field with the following information:

   - Scope: **private**
   - Type: **StoreContext**
   - Name: **_context**

6. Add a constructor with the following parameter:

   - Type: **StoreContext**
   - Name: **context**

7. In the constructor, initialize the  **_context** field with the value of the **context** parameter.

8. Declare a method with following information:

   - Name: **Invoke**
   - Return type: **IViewComponentResult**
   - Scope: **public**

9.   In the **Invoke** method, create a variable named **categories** of type **var** with the value of **_context.menuCategories.OrderBy(c => c.Name).ToList()**.

10. Return the **IViewComponentResult** result using the **View** method. Pass the **"MenuCategories"** and **categories** as a parameters to the **View** method.

11. Create a new folder with the following information:

     - Folder Name: **Components**
     - Location: **Views/Shared**

12. Create a new folder with the following information:

     - Folder Name: **NavbarMenu**
     - Location: **Views/Shared/Components**

13. Create a new **Razor View** with the following information:

     - Name: **MenuCategories**
     - Folder: **MenuCategories**


14. In the **MenuCategories.cshtml** view, remove all the content.

15. Add a **@model** directive with the following information:
     - Type: **IEnumerable&lt;ElectricStore.Models.MenuCategory&#62;**

16. Add a **LI** element with the following information:

     - Class: **nav-item**

17. In the  **LI** element, add a **A** element with the following information:

     - Content: **Home&#60;span class="sr-only"&#62;(current)&#60;/span&#62;**
     - Attributes:
        - class: **nav-link**
        - href: **@Url.Action("Index", "Products")**


18. After the **LI** element, add a **LI** element with the following information:

     - Class: **nav-item dropdown**


18. In the new **LI** element, add a **A** element with the following information:

     - Content: **Electronics**
     - Attributes:
        - class: **nav-link dropdown-toggle**
        - href: **#**
        - id: **navbarDropdownMenuLink**
        - data-toggle: **dropdown**
        - aria-haspopup: **true**
        - aria-expanded: **false**
    


19. After the **A** element, add a **DIV** element with the following information:

     - class: **dropdown-menu**
     - aria-labelledby: **navbarDropdownMenuLink**

20. In the **DIV** element, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **item**
	- Collection: **Model**

21. In the **FOREACH** statement block, Add a **A** element with the following information:

	- Content: **@Html.DisplayFor(modelItem => item.Name)**
    - Attributes:
        - class: **dropdown-item**
        - asp-action: **GetByCategory**
        - asp-controller: **Products**
        - asp-route-id: **@item.Id**

22. After the last **LI** element, add a **LI** element with the following information:

     - Class: **nav-item**

23. In the new **LI** element, add a **A** element with the following information:

     - Content: **Add to Shopping List**
     - Attributes:
        - class: **nav-link**
        - href: **@Url.Action("AddToShoppingList", "Products")**


24. After the last **LI** element, add a **LI** element with the following information:

     - Class: **nav-item**

25. In the new **LI** element, add a **A** element with the following information:

     - Content: **My Shopping Card**
     - Attributes:
        - class: **nav-link**
        - href: **@Url.Action("Index", "ShoppingCard")**


#### Task 3: Run the application

1. 

#### Task 4: Insert items to a memory cache.

1. 

#### Task 5: Retrieve items from a memory cache

1. 

#### Task 6: Run the application
1. 



>**Results**: TODO: Add Results


### Exercise 2: Managing State

#### Scenario

TODO: Add Scenario


The main tasks for this exercise are as follows:

1. Enable working with sessions.

2. Write an action in the first controller.

3. Write the content of the second controller.

4. Run the application and navigate from view to view.


#### Task 1: Enable working with sessions.

1. 

#### Task 2: Write an action in the first controller.

1. 

#### Task 3: Write the content of the second controller.

1. 

#### Task 4: Run the application and navigate from view to view.

1. 

>**Results**: TODO: Add Results


### Exercise 3: Calling a Web API using jQuery

#### Scenario

TODO: Add Scenario


The main tasks for this exercise are as follows:

1. Add a SignalR Hub class named ChatHub.

2. Register the ChatHub in the Startup class.

3. Add a chat view.

4. Write the JavaScript code to connect to the server.

5. Run the application

#### Task 1: Add a SignalR Hub class named ChatHub.

1. 


#### Task 2: Register the ChatHub in the Startup class.

1. 

#### Task 3: Add a chat view.

1. 

#### Task 4: Write the JavaScript code to connect to the server.

1. 

#### Task 5:  Run the application

>**Results**: TODO: Add Results

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
