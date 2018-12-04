# Module 12: Performance and Communication

# Lab: Performance and Communication

#### Scenario

You have been asked to create a web-based electric store application for your organization's customers. The application should have a page showing sale of the day, products sorted by category, ability to add products to your shopping list, and a chat page that lets users talk online. The application should contain a cache tag helper to cache content in a view, a memory cache in a controller, and a session state configuration. Finally, you will write a chat room using SignalR.

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

To improve the performance of a web application, caching should be used in the web application. In this exercise, you will first add a cache tag helper to a view. After that you will use the memory cache to store and retrieve items.

The main tasks for this exercise are as follows:

1.	Add a cache tag helper to a view.

2.	Insert data to be cached by the cache tag helper.

3.	Run the application.

4.	Insert items to a memory cache.

5.	Run the application.


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

1. Save all the changes.

2. Start the application without debugging.
    >**Note:** Examine the browser content, the browser displays the **Index.cshtml** file content, rendered in the **_Layout.cshtml**, and the chached content is the meanu bar of the application.

3. In the menu bar, click **Electronics**, and then click **Home Electrical Equipment**.
    >**Note:** Examine the browser content.

4. In the menu bar, click **Electronics**, and then click **Office Electrical Equipment**.

    >**Note:** Examine the browser content.

5. Close the **Microsoft Edge** window.


#### Task 4: Insert items to a memory cache.

1. In the **ProductsController** class, add **USING** statements for the following namespace:

   - **Microsoft.Extensions.Caching.Memory**


2. Create a new field with the following information:

   - Scope: **private**
   - Type: **IMemoryCache**
   - Name: **_memoryCache**

3. Create a new field with the following information:

   - Scope: **private**
   - Type: **string**
   - Name: **PRODUCT_KEY**
   - Modifier: **const**
   - Value: **"Products"**

4. Change the signature of the **ProductsController** constructor to accept the following parameters:

   - Parameter: 
     - Type: **StoreContext**
     - Name: **context**
   - Parameter: 
     - Type: **IHostingEnvironment**
     - Name: **environment**
   - Parameter: 
     - Type: **IMemoryCache**
     - Name: **memoryCache**

5. In the constructor, initialize the  **_memoryCache** field with the value of the **memoryCache** parameter.

6. In the beginning of the  **Index** method,  create a variable named **products** of type **List&#60;Product&#62;**.

7. Add an **IF** statement that checks that value of **_memoryCache.TryGetValue(PRODUCT_KEY, out products)** is false.

8. In the **IF** statement, assign the **products** variable, with the value of **_context.Products.ToList()**.

9. Create a variable named **MemoryCacheEntryOptions** of type **cacheOptions**. Initialize the  **cacheOptions** variable using the  **MemoryCacheEntryOptions** constructor.

10. Call the **SetPriority** method of the  **cacheOptions** variable. Pass **CacheItemPriority.High** as a parameter to the  **SetPriority** method.

11. Call the **SetSlidingExpiration** method of the  **cacheOptions** variable. Pass **TimeSpan.FromSeconds(60)** as a parameter to the  **SetSlidingExpiration** method.

12. Call the **Set** method of the  **_memoryCache** variable. Pass **PRODUCT_KEY**,  **products** and  **cacheOptions** as a parameters to the  **Set** method.


#### Task 5: Retrieve items from a memory cache

1. In the **Products/Index.cshtml** view, after the **H2** element, add a **DIV** element with the following information:

     - Class: **page-container**


2. In the **DIV** element, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **item**
	- Collection: **Model**

3. In the **FOREACH** statement block, add a **DIV** element with the following information:

    - class: **item**

4. In the new **DIV** element, add a **H3** element with the following information:

    - Content: **@Html.DisplayFor(modelItem => item.ProductName)**


5. After the **H3** element, add a **IF** statement that checks that **item.PhotoFileName** is not **NULL**.

6. In the **IF** statement code block, add a **DIV** element.

7. In the new **DIV** element,  add a **IMG** element with the following information:

     - src: **@Url.Action("GetImage", "Products", new { productId = item.Id })**

8. After the **IF** statement code block, add a **DIV** element,

9. In the new **DIV** element, add a **P** element with the following information:

     - Content: **@Html.DisplayFor(model => item.Description)**

10. After the new **P** element, add a **P** element with the following information:

     - Content: **@Html.DisplayFor(model => item.Price)**


#### Task 6: Run the application

1. Save all the changes.

2. Start the application without debugging.

    >**Note:** Examine the browser content, the browser displays the **Index.cshtml** file content, rendered in the **_Layout.cshtml**, and the chached  content is the products that are shown in the **"Sale of The Day"** page content.

3. Close the **Microsoft Edge** window.


>**Results**: After completing this exercise, you will be able to implement caching strategy by adding cache tag helper to a view, and insert items to a memory cache.


### Exercise 2: Managing State

#### Scenario

To retain information across requests, state should be used in the web application. In this exercise you will use session state to manage state in the web application.

The main tasks for this exercise are as follows:

1. Enable working with sessions.

2. Use session to store values.

3. Retrieve values from a session.

4. Run the application and navigate from view to view.


#### Task 1: Enable working with sessions.

1. In the **Startup** class, in the **ConfigureServices** method, after the **services.AddDbContext** method call, call the **AddDistributedMemoryCache** method of the **services** parameter.

2. Call the **AddSession** method of the **services** parameter. Pass the following **options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
            })** lambda expression as a parameter to the **AddSession** method. 

3.  In the **Configure** method, call the **UseSession** method of the **app** parameter.


#### Task 2: Use session to store values.

1. In the **ProductsController** class, add **USING** statements for the following namespaces:

   - **Microsoft.AspNetCore.Http**
   - **Newtonsoft.Json**

2. In the **AddToShoppingListPost** action, after the **SaveChanges** method call and before the **RedirectToAction** method call, add an **IF** statement that check that **string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerName"))** is true and **string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerProducts"))** is true. 

3. In the **IF** statement code block, call the **HttpContext.Session.SetString** method and pass **"CustomerName"** and **customer.FirstName** as parameters.

4. Create a variable named **serialisedDate** of type **var** and assign it with the value of **JsonConvert.SerializeObject(customer.SelectedProductsList)**.

5. Call the **HttpContext.Session.SetString** method and pass **"CustomerProducts"** and **serialisedDate** as parameters.


#### Task 3: Retrieve values from a session.

1.  Create a new controller with the following information:
    - Controller name: **ShoppingCardController**
    - Template: **MVC controller - Empty**
    - Folder: **Controllers**


2. In the **ShoppingCardController** class, add **USING** statements for the following namespaces:

   - **ElectricStore.Data**
   - **ElectricStore.Models**
   - **Microsoft.AspNetCore.Http**
   - **Newtonsoft.Json**

3. Create a new field with the following information:

   - Scope: **private**
   - Type: **StoreContext**
   - Name: **_context**

4. Create a new field with the following information:

   - Scope: **private**
   - Type: **List&lt;Product&gt;**
   - Name: **products**

5. Create a new field with the following information:

   - Scope: **private**
   - Type: **SessionStateViewModel**
   - Name: **sessionModel** 

6. Add a constructor with the following parameter:

   - Type: **StoreContext**
   - Name: **context**

7. In the constructor, initialize the  **_context** field with the value of the **context** parameter.

8. Remove the contents of the **Index** method.

9. In the **Index** method,  add an **IF** statement that check that **string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerName"))** is false and **string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerProducts"))** is false. 

10. In the **IF** statement code block, create a variable named **ProductsListId** of type **int[]** and assign it with the value of **JsonConvert.DeserializeObject&lt;int[]&gt;(HttpContext.Session.GetString("CustomerProducts"))**. 

11. Assign the **products** field with the value of **new List<Product>()**.

12. Create a **FOREACH** statement, with the following information:

    - Variable Type: **var**
    - Variable Name: **item**
    - Collection: **ProductsListId**

13. In the **FOREACH** statement code block, create a **product** variable of type **var** and assign it with the value of **_context.Products.SingleOrDefault(p => p.Id == item)**.

14. Call the **Add** method of the **products** variable. Pass **product** as a parameter to the **Add** method. 

15. After the **FOREACH** code block, assign the **sessionModel** field with the value of **new SessionStateViewModel** object. 

16. Inititialize the **CustomerName** property of the **sessionModel** field with the value of **HttpContext.Session.GetString("CustomerName")**. 

17. Inititialize the **SelectedProducts** property of the  **sessionModel** field with the value of **products**. 


18. Return the **ViewResult** result using the **View** method. Pass **sessionModel** as a parameter to the **View** method. 

#### Task 4: Run the application.

1. Save all the changes.

2. Start the application without debugging.
    >**Note:** Examine the browser content, the browser displays the **Index.cshtml** file content, rendered in the **_Layout.cshtml**, and the chached content is the meanu bar of the application.

3. In the menu bar, click **My Shopping Card**.

    >**Note:** Examine the browser content.

4. In the menu bar, click **Add to Shopping List**.

    >**Note:** Examine the browser content.

5. On the **Add Products to Shopping List** page, select the following:

	-  Products List: **_&lt;Products of your choice&gt;_**
    -  First Name: **_&lt;A first name of your choice&gt;_**
    -  Last  Name: **_&lt;A last  name of your choice&gt;_**
    -  Address:  **_&lt;An address of your choice&gt;_**
    -  Email:  **_&lt;An email of your choice&gt;_**
    -  Phone:  **_&lt;A phone number of your choice&gt;_**

6. In the menu bar, click **My Shopping Card**.
    >**Note:**  Examine the browser content, the browser displays the **ShoppingCard.cshtml** file content, rendered in the **_Layout.cshtml**, and the chached content is the products that where selectd by you in the **"Add Products to Shopping List"** page.

7. Close the **Microsoft Edge** window.


>**Results**: After completing this exercise, you will be able to manage state, by working with sessions.


### Exercise 3: Calling a Web API using jQuery

#### Scenario

In this exercise, you will first add a SignalR Hub class named ChatHub. You will then add a SignalR Hub class named ChatHub, and register the ChatHub in the Startup class. After that you will add a chat view. Finally, you will write the JavaScript code to connect to the server, and run the application and navigate from view to view.

The main tasks for this exercise are as follows:

1. Add a SignalR Hub class named ChatHub.

2. Register the ChatHub in the Startup class.

3. Add a chat view.

4. Write the JavaScript code to connect to the server.

5. Run the application


#### Task 1: Add a SignalR Hub class named ChatHub.


1. Create a new folder with the following information:

    - Folder name: **Hubs**

2. Create a new class with the following information:

    - Name: **ChatHub**
    - Folder: **Hubs**   

3. In the **ChatHub** class, add **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.SignalR**

4. Change the **ChatHub** class to inherit from the **Hub** class.

5. In the **ChatHub** class, declare a method with following information:

   - Name: **SendMessageAll**
   - Return type: **Task**
   - Scope: **public**
   - Modifier: **async**
   - Parameters:
        - Parameter: 
            - Type: **string**
            - Name: **user**
        - Parameter: 
            - Type: **string**
            - Name: **message**

6. Call the **Clients.All.SendAsync** method using the **await** operator. Pass **"NewMessage"**, **user** and **message** as a parameters to the **SendAsync** method.


#### Task 2: Configure SignalR in the Startup class.

1. In the **Startup** class, add a **USING** statement for the following namespace:

   - **ElectricStore.Hubs**

2. In the **ConfigureServices** method, after the **services.AddSession** method call, call the **AddSignalR** method of the **services** parameter.

3. In the **Configure** method, after the call to the **UseStaticFiles** method, call the **UseSignalR** method of the **app** parameter. Pass the following **routes =>
       {
           routes.MapHub&lt;ChatHub&gt;("/chatHub");
       }** lambda expression as a parameter to the **UseSignalR** method. 

4. In the  **package.json** file, add the following key and value in the **dependencies** object:

	- Key: **"@aspnet/signalr"**
	- Value: **"^1.0.0"**


#### Task 3: Add a chat view

1. In the **ShoppingCardController**, declare a method with following information:

   - Name: **Chat**
   - Return type: **IActionResult **
   - Scope: **public**

2. In the **Configure** method, return the **ViewResult** result using the **View** method.

3. Create a new view using the **Add MVC View** dialog box, with the following information:

    - View Name: **Chat**
    - Template: **Empty (without model)**
    - Create as Partial View: **False**
    - Use a layout page: **True**
    - Layout Page: **_Layout.cshtml**

4. In the **Chat.chtml** view, remove the **H2** element. 

5. Add a **H2** element with the following information:

     - Class: **title**

6. In the **H2** element, add a **SPAN** element with the following information:

	 - Content: **Chat with**

7. Add a **SPAN** element with the following information:

	 - Content: **Online Site Visitors**
     - Class: **chat-title**

8. After the  **H2** element, add a **DIV** element with the following information:

     - Class: **chat**

9. In the new **DIV** element, add a **DIV** element with the following information:

	 - Class: **row justify-content-center**

10. In the new **DIV** element, add a **DIV** element with the following information:

	 - Class: **col-2 bcf**

11. In the new **DIV** element, add a **DIV** element with the following information:

    - Content: **Name: &lt;input type="text" id="inputUserName" /&gt;**
	- Class: **col-5**


12. After the **DIV** element with the **col-5** class, add a **DIV** element with the following information:

    - Content: **Message: &lt;input type="text" id="inputMessage" /&gt;**
	- Class: **col-sm-5**


13. After the **DIV** element with the **col-sm-5** class, add a **DIV** element with the following information:

	- Class: **col-sm-3**

14. In the new **DIV** element, add a **INPUT** element with the following information:

    - Type: **type**
	- Class: **btn btn-info**
    - Id: **sendMessageBtn**
    - Value: **Send Message**

15. After the **DIV** element with the **col-2 bcf** class, add a **DIV** element with the following information:

	- Class: **col-2 bcs**

16. In the new **DIV** element, add a **UL** element with the following information:

    - Id: **messagesList**

17. After the **DIV** element with the **chat** class, create a **@section**  with the following information: 
    - Name: **Scripts**

18. In the **Scripts** section, add a **SCRIPT** element with the following information:

    - Src: **~/node_modules/@@aspnet/signalr/dist/browser/signalr.js**

19. In the **Index.cshtml** view under **Views/ShoppingCard**, after the **ELSE** statement code block, add a **BUTTON** element with the following information:

    - Type: **button**
	- Class: **btn btn-success**
    - Id: **btnChat**
    - Onclick: **location.href='@Url.Action("Chat", "ShoppingCard")'**
    - Content: **Chat with Online Visitors**


#### Task 4: Write the JavaScript code to connect to the server

1.  Create a new folder with the following information:

	- Folder name: **js**
	- Parent folder: **wwwroot**

2. Add **chat-hub.js** file to the **ElectricStore** project, with the following information:

	- Source location: **Allfiles\Mod08\Labfiles\ElectricStoreJS**
	- Target location: **Allfiles\Mod08\Labfiles\01_ElectricStore_begin\ElectricStore\wwwroot\js**

3. In the **Chat.chtml** view, in the **Scripts** section, add a **SCRIPT** element with the following information:

    - Src: **~/js/chat-hub.js**

#### Task 5:  Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In the menu bar, click **My Shopping Card**.

4. On the **My Shopping Card** page, click **Chat with Online Visitors**.

5. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

6. In the second **Microsoft Edge**, open **http://localhost:[port]/ShoppingCard/Chat**.

7. In the second **Microsoft Edge**, fill the following:

	-  Name: **_&lt;A name of your choice&gt;_**
    -  Message: **_&lt;A message of your choice&gt;_**

    >**Note:**  In both **Microsoft Edge** windows, the message appear.

8. In the first **Microsoft Edge**, fill the following:
	-  Name: **_&lt;A name of your choice&gt;_**
    -  Message: **_&lt;A message of your choice&gt;_**

    >**Note:**  In both **Microsoft Edge** windows, the message appear.

9. Close all **Microsoft Edge** windows.

10. Close **Microsoft Visual Studio**.

>**Results**: After completing this exercise, you should have created an electric store in which users can view products details, order some as well, and chat with online site visitors.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
