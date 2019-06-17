# Module 12: Performance and Communication

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Performance and Communication

#### Scenario

You have been asked to create a web-based electric store application for your organization's customers. The application should have a page showing the sale of the day, products sorted by category, the ability to add products to your shopping list, and a chat page that lets users talk online. The application should contain a cache tag helper to cache content in a view, a memory cache in a controller, and a session state configuration. Finally, you will write a chat room app by using SignalR.

#### Objectives

After completing this lab, you will be able to:

- Implement a caching strategy.
- Manage state.
- Add two-way communication.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Open the **Command Prompt** window by using **Run as administrator**.

    >**Note**: If a **User Account Control** dialog appears, click yes.

3. In the **Administrator: Command Prompt** window, run the following command: **cd** *&lt;The location of [Repository Root]\Allfiles\Mod12\Labfiles\01_ElectricStore_begin\ElectricStore folder on your machine&gt;*.

4. Run the following command: **npm install**.

    >**Note**: If warning messages are shown in the command prompt you can ignore them.

5. Close the **Command Prompt** window. 

6. From the following location: **[Repository Root]\Allfiles\Mod12\Labfiles\01_ElectricStore_begin**, open the **ElectricStore.sln** solution.

    >**Note**: If a **Security Warning for ElectricStore** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

7. In the **ElectricStore - Microsoft Visual Studio** window, click **TOOLS** and then click **Options**.

8. In the **Options** dialog box, click **Web Package Management**.

9. In the **Locations of external tools** list, select **$(PATH)**, press the **Up arrow** key until **$(PATH)** is at the top of the list, and then click **OK**.

10. Open the **package.json** file and examine its content.

    >**Note**: There are dependencies to the 
    **jquery, jquery-validation, jquery-validation-unobtrusive, bootstrap** and **popper.js** packages.

11. In the **ElectricStore - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

12. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this lab.

13. In Microsoft Edge, click **Close**.

### Exercise 1: Implementing a Caching Strategy

#### Scenario

To improve the performance of a web application, caching should be used in the web application. In this exercise, you will first add a cache tag helper to a view. After that, you will use the memory cache to store and retrieve items.

The main tasks for this exercise are as follows:

1.	Add a cache tag helper to a view

2.	Insert data to be cached by the cache tag helper

3.	Run the application

4.	Insert items to a memory cache

5.	Run the application


#### Task 1: Add a cache tag helper to a view.

1. In the **_Layout.cshtml** file, in the **UL** element with the **navbar-nav** class, add a **CACHE** element with the following information:

    - vary-by-route: **RefreshCache**

2. In the **CACHE** element, call the **Component.InvokeAsync** method by using the **@await** operator. To the **InvokeAsync** method, pass **"NavbarMenu"** as a parameter.

#### Task 2: Insert data to be cached by the cache tag helper.

1. Create a new folder with the following information:

    - Folder name: **ViewComponents**

2. Create a new class with the following information:

    - Name: **NavbarMenuViewComponent**
    - Folder: **ViewComponents**   

3. In the **NavbarMenuViewComponent** class, add the **USING** statements for the following namespaces:

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

8. Declare a method with the following information:

   - Name: **Invoke**
   - Return type: **IViewComponentResult**
   - Scope: **public**

9.   In the **Invoke** method, create a variable named **categories** of type **var** with the value of **_context.menuCategories.OrderBy(c => c.Name).ToList()**.

10. Return the **IViewComponentResult** result by using the **View** method. Pass **"MenuCategories"** and **categories** as parameters to the **View** method.

11. Create a new folder with the following information:

     - Folder Name: **Components**
     - Location: **Views/Shared**

12. Create a new folder with the following information:

     - Folder Name: **NavbarMenu**
     - Location: **Views/Shared/Components**

13. Create a new **Razor View** with the following information:

     - Name: **MenuCategories**
     - Folder: **NavbarMenu**

14. In the **MenuCategories.cshtml** view, remove all the content.

15. Add a **@model** directive with the following information:
     - Type: **IEnumerable&lt;ElectricStore.Models.MenuCategory&#62;**

16. Add an **LI** element with the following information:

     - Class: **nav-item**

17. In the **LI** element, add an **A** element with the following information:

     - Content: **Home&#60;span class="sr-only"&#62;(current)&#60;/span&#62;**
     - Attributes:
        - class: **nav-link**
        - href: **@Url.Action("Index", "Products")**


18. After the **LI** element, add an **LI** element with the following information:

     - Class: **nav-item dropdown**


19. In the new **LI** element, add an **A** element with the following information:

     - Content: **Electronics**
     - Attributes:
        - class: **nav-link dropdown-toggle**
        - href: **#**
        - id: **navbarDropdownMenuLink**
        - data-toggle: **dropdown**
        - aria-haspopup: **true**
        - aria-expanded: **false**
    

20. After the **A** element, add a **DIV** element with the following information:

     - class: **dropdown-menu**
     - aria-labelledby: **navbarDropdownMenuLink**

21. In the **DIV** element, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **item**
	- Collection: **Model**

22. In the **FOREACH** statement block, add an **A** element with the following information:

	- Content: **@Html.DisplayFor(modelItem => item.Name)**
    - Attributes:
        - class: **dropdown-item**
        - asp-action: **GetByCategory**
        - asp-controller: **Products**
        - asp-route-id: **@item.Id**

23. After the last **LI** element, add an **LI** element with the following information:

     - Class: **nav-item**

24. In the new **LI** element, add an **A** element with the following information:

     - Content: **Add to Shopping List**
     - Attributes:
        - class: **nav-link**
        - href: **@Url.Action("AddToShoppingList", "Products")**


25. After the last **LI** element, add an**LI** element with the following information:

     - Class: **nav-item**

26. In the new **LI** element, add an **A** element with the following information:

     - Content: **My Shopping Cart**
     - Attributes:
        - class: **nav-link**
        - href: **@Url.Action("Index", "ShoppingCart")**

27. After the last **LI** element, add an **LI** element with the following information:

     - Class: **nav-item**

28. In the new **LI** element, add a **DIV** element with the following information:

     - Content: **The content cached Since: @DateTime.Now**
     - Attributes:
        - class: **display-cached-time**

#### Task 3: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

4. In the second **Microsoft Edge** window, navigate to **http://localhost:[port]**.

    >**Note**: The menu bar of the application is cached since the time displayed in the menu bar, the time is the same in both **Microsoft Edge** pages.

5. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

6. In the second **Microsoft Edge** window, navigate to **http://localhost:[port]/products/index/1/RefreshCache**.

    >**Note**: The menu bar of the application is cached since the time displayed in the menu bar, the time is not the same as the other two **Microsoft Edge** pages because the **RefreshCache** in the route triggers a reload of the view component.

7. Close all the **Microsoft Edge** windows.

#### Task 4: Insert items to a memory cache.

1. In the **ProductsController** class, add the **USING** statements for the following namespace:

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

6. In the beginning of the  **Index** method, create a variable named **products** of type **List&#60;Product&#62;**.

7. Add an **IF** statement that checks if the value of **_memoryCache.TryGetValue(PRODUCT_KEY, out products)** is false.

8. In the **IF** statement, assign the **products** variable with the value **_context.Products.ToList()**.

9. Call the **Select** method of the **products** variable, with the following information:

10. Pass a lambda expression as a parameter to the **Select** method with the following information:
   - Lambda expression: **c => { c.LoadedFromDatabase = DateTime.Now; return c; }**

11. To the **Select** function call, chain a **ToList** method call.

12. Create a variable named **MemoryCacheEntryOptions** of type **cacheOptions**. Initialize the  **cacheOptions** variable by using the  **MemoryCacheEntryOptions** constructor.

13. Call the **SetPriority** method of the  **cacheOptions** variable. Pass **CacheItemPriority.High** as a parameter to the  **SetPriority** method.

14. Call the **Set** method of the  **_memoryCache** variable. Pass **PRODUCT_KEY**,  **products**, and  **cacheOptions** as parameters to the  **Set** method.

15. Return the **products** parameter to the view.

16. In the **Views/Products/Index.cshtml** view, after the **H2** element, add a **DIV** element with the following information:

     - Class: **page-container**

17. In the **DIV** element, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **item**
	- Collection: **Model**

18. In the **FOREACH** statement block, add a **DIV** element with the following information:

    - class: **item**

19. In the new **DIV** element, add a **H3** element with the following information:

    - Content: **@Html.DisplayFor(modelItem => item.ProductName)**

20. After the **H3** element, add an **IF** statement that checks that **item.PhotoFileName** is not **NULL**.

21. In the **IF** statement code block, add a **DIV** element.

22. In the new **DIV** element,  add an **IMG** element with the following information:

     - src: **@Url.Action("GetImage", "Products", new { productId = item.Id })**

23. After the **IF** statement code block, add a **DIV** element,

24. In the new **DIV** element, add a **P** element with the following information:

     - Content: **@Html.DisplayFor(model => item.Description)**

25. After the new **P** element, add a **P** element with the following information:

     - Content: **@Html.DisplayFor(model => item.Price)**

26. After the new **DIV** element, add another **DIV** element.

27. In the new **DIV** element, add a **P** element with the following information:

     - Content: **@Html.DisplayNameFor(model => item.LoadedFromDatabase)**

28. After the new **P** element, add a **P** element with the following information:

     - Content: **@Html.DisplayFor(model => item.LoadedFromDatabase)**

#### Task 5: Run the application

1. Save all the changes.

2. Start the application without debugging.

    >**Note**: Examine the product's **Last retrieved on** data.

3. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

4. In the second **Microsoft Edge** window, navigate to **http://localhost:[port]**.

    >**Note**: Examine the browser content, and you can see that products in the **"Sale of The Day"** page content are cached, since the time displayed in the products **Last retrieved on** data is identical in both **Microsoft Edge** pages.

5. Close all the **Microsoft Edge** windows.

>**Results**: After completing this exercise, you will be able to implement a caching strategy by adding a cache tag helper to a view, and insert items into a memory cache.

### Exercise 2: Managing State

#### Scenario

To retain information across requests, the state should be used in the web application. In this exercise, you will use session state to manage the state in the web application.

The main tasks for this exercise are as follows:

1. Enable working with sessions

2. Use session to store values

3. Retrieve values from a session

4. Run the application and navigate from view to view

#### Task 1: Enable working with sessions.

1. In the **Startup** class, in the **ConfigureServices** method, after the **services.AddDbContext** method call, call the **AddSession** method of the **services** parameter.

2. Pass the following **options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
            })** lambda expression as a parameter to the **AddSession** method. 

3.  In the **Configure** method, call the **UseSession** method of the **app** parameter.

#### Task 2: Use session to store values.

1. In the **ProductsController** class, add the **USING** statements for the following namespaces:

   - **Microsoft.AspNetCore.Http**
   - **Newtonsoft.Json**

2. In the **AddToShoppingListPost** action, replace the content in the **IF** statement, call the **HttpContext.Session.SetString** method and pass **"CustomerFirstName"** and **customer.FirstName** as parameters.

3. In the **IF** statement code block, call the **HttpContext.Session.SetString** method and pass **"CustomerLastName"** and **customer.LastName** as parameters.

4. In the **IF** statement code block, call the **HttpContext.Session.SetString** method and pass **"CustomerEmail"** and **customer.Email** as parameters.

5. In the **IF** statement code block, call the **HttpContext.Session.SetString** method and pass **"CustomerAddress"** and **customer.Address** as parameters.

6. In the **IF** statement code block, call the **HttpContext.Session.SetInt32** method and pass **"CustomerPhoneNumber"** and **customer.PhoneNumber** as parameters.

7. In the **IF** statement code block, add another **IF** statement that checks that the value of the **HttpContext.Session.GetString("CustomerProducts")** variable is not null.

8. In the **IF** statement code block, create a variable named **productsListId** of type **List<int>** and assign it with the value of **JsonConvert.DeserializeObject&lt;List<int>&gt;(HttpContext.Session.GetString("CustomerProducts"))**. 

9. Assign the **products** field with the value of **new List<Product>()**.

10. Call the **AddRange** method of the **customer.SelectedProductsList** variable, and pass **productsListId**.

11. After the **IF** statement code block, create a variable named **serialisedDate** of type **var** and assign it with the value of **JsonConvert.SerializeObject(customer.SelectedProductsList)**.

12. Call the **HttpContext.Session.SetString** method, and pass **"CustomerProducts"** and **serialisedDate** as parameters.

13. Return the **RedirectToActionResult** result by using the **RedirectToAction** method.  Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

#### Task 3: Retrieve values from a session.

1. In the **AddToShoppingList** action, before the call to **PopulateProductsList** method, add an **IF** statement that checks that the value of the **HttpContext.Session.GetString("CustomerProducts")** variable is not null.

2. In the **IF** statement code block, create a variable named **sessionCustomer** of type **Customer**.

3. Assign to the **FirstName** property of the **sessionCustomer** parameter the value of **HttpContext.Session.GetString("CustomerFirstName")**.

4. Assign to the **LastName** property of the **sessionCustomer** parameter the value of **HttpContext.Session.GetString("CustomerLastName")**.

5. Assign to the **Email** property of the **sessionCustomer** parameter the value of **HttpContext.Session.GetString("CustomerEmail")**.

6. Assign to the **Address** property of the **sessionCustomer** parameter the value of **HttpContext.Session.GetString("CustomerAddress")**.

7. Assign to the **PhoneNumber** property of the **sessionCustomer** parameter the value of **HttpContext.Session.GetInt32("CustomerPhoneNumber").Value**.

8. After the **sessionCustomer** variable assignment, call the **PopulateProductsList** method.

9. Return the **sessionCustomer** parameter to the view.

10. In the **ShoppingCartController** class, add the **USING** statements for the following namespaces:

   - **ElectricStore.Data**
   - **ElectricStore.Models**
   - **Microsoft.AspNetCore.Http**
   - **Newtonsoft.Json**

11. Create a new field with the following information:

   - Scope: **private**
   - Type: **StoreContext**
   - Name: **_context**

12. Create a new field with the following information:

   - Scope: **private**
   - Type: **List&lt;Product&gt;**
   - Name: **products**

13. Create a new field with the following information:

   - Scope: **private**
   - Type: **SessionStateViewModel**
   - Name: **sessionModel** 

14. Add a constructor with the following parameter:

   - Type: **StoreContext**
   - Name: **context**

15. In the constructor, initialize the  **_context** field with the value of the **context** parameter.

16. Remove the contents of the **Index** method.

17. In the **Index** method,  add an **IF** statement that checks that **string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerFirstName"))** is false and **string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerProducts"))** is false. 

18. In the **IF** statement code block, create a variable named **productsListId** of type **List<int>**, and assign it with the value of **JsonConvert.DeserializeObject&lt;int[]&gt;(HttpContext.Session.GetString("CustomerProducts"))**. 

19. Assign the **products** field with the value of **new List<Product>()**.

20. Create a **FOREACH** statement, with the following information:

    - Variable Type: **var**
    - Variable Name: **item**
    - Collection: **productsListId**

21. In the **FOREACH** statement code block, create a **product** variable of type **var**, and assign it with the value of **_context.Products.SingleOrDefault(p => p.Id == item)**.

22. Call the **Add** method of the **products** variable. Pass **product** as a parameter to the **Add** method. 

23. After the **FOREACH** code block, assign the **sessionModel** field with the value of the **new SessionStateViewModel** object. 

24. Inititialize the **CustomerName** property of the **sessionModel** field with the value of **HttpContext.Session.GetString("CustomerFirstName")**. 

25. Inititialize the **SelectedProducts** property of the  **sessionModel** field with the value of **products**. 


26. Return the **ViewResult** result by using the **View** method. Pass **sessionModel** as a parameter to the **View** method. 

#### Task 4: Run the application.

1. Save all the changes.

2. Start the application without debugging.

3. In the menu bar, click **My Shopping Cart**.

    >**Note**: Examine the browser content.

4. In the menu bar, click **Add to Shopping List**.

5. On the **Add Products to Shopping List** page, select the following:

	-  Products List: _&lt;Products of your choice&gt;_
    -  First Name: _&lt;A first name of your choice&gt;_
    -  Last  Name: _&lt;A last  name of your choice&gt;_
    -  Address:  _&lt;An address of your choice&gt;_
    -  Email:  _&lt;An email of your choice&gt;_
    -  Phone: _&lt;A phone number of your choice&gt;_

6. In the menu bar, click **My Shopping Cart**.

    >**Note**: Examine the browser content; it displays the content of the **ShoppingCart.cshtml** file, rendered by **_Layout.cshtml**, and the cached contents are the products that were selected by you in the **"Add Products to Shopping List"** page.

7. In the menu bar, click **Add to Shopping List**.

    >**Note**: Examine the browser content; it displays your cached personal information.

8. On the **Add Products to Shopping List** page, in the **Products List** list, again select  _&lt;Products of your choice&gt;._

9. In the menu bar, click **My Shopping Cart**.

    >**Note**: Examine the browser content; the product you selected in the second selection is also displayed in the cached list of products you have selected in the past.

10. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

11. In the second **Microsoft Edge** window, navigate to **http://localhost:[port]**.

12. In the menu bar, click **My Shopping Cart**.

    >**Note**: Examine the browser content; the list of products is not displayed because it is empty. The session is saved only in the original browser.

13. Close all **Microsoft Edge** windows.

>**Results**: After completing this exercise, you will be able to manage state by working with sessions.

### Exercise 3: Two-Way Communication 

#### Scenario

In this exercise, you will first add a SignalR Hub class named ChatHub. You will then add a SignalR Hub class named ChatHub, and register the ChatHub in the Startup class. Then, you will add a chat view. Finally, you will write the JavaScript code to connect to the server, and run the application and navigate from view to view.

The main tasks for this exercise are as follows:

1. Add a SignalR Hub class named ChatHub

2. Register the ChatHub in the Startup class

3. Add a chat view

4. Write the JavaScript code to connect to the server

5. Run the application

#### Task 1: Add a SignalR Hub class named ChatHub.

1. Create a new folder with the following information:

    - Folder name: **Hubs**

2. Create a new class with the following information:

    - Name: **ChatHub**
    - Folder: **Hubs**   

3. In the **ChatHub** class, add a **USING** statement for the following namespace:

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

6. Call the **Clients.All.SendAsync** method by using the **await** operator. Pass **"NewMessage"**, **user**, and **message** as parameters to the **SendAsync** method.


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

1. In the **ShoppingCartController**, declare a method with the following information:

   - Name: **Chat**
   - Return type: **IActionResult**
   - Scope: **public**

2. In the **Configure** method, return the **ViewResult** result by using the **View** method.

3. Create a new view by using the **Add MVC View** dialog box, with the following information:

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

8. After the **H2** element, add a **DIV** element with the following information:

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

14. In the new **DIV** element, add an **INPUT** element with the following information:

    - Type: **type**
	- Class: **btn btn-info**
    - Id: **sendMessageBtn**
    - Value: **Send Message**

15. After the **DIV** element with the **col-2 bcf** class, add a **DIV** element with the following information:

	- Class: **col-2 bcs**

16. In the new **DIV** element, add a **UL** element with the following information:

    - Id: **messagesList**

17. After the **DIV** element with the **chat** class, create an **@section**  with the following information: 
    - Name: **Scripts**

18. In the **Scripts** section, add a **SCRIPT** element with the following information:

    - Src: **~/node_modules/@@aspnet/signalr/dist/browser/signalr.js**

19. In the **Index.cshtml** view under **Views/ShoppingCart**, after the **ELSE** statement code block, add a **BUTTON** element with the following information:

    - Type: **button**
	- Class: **btn btn-success**
    - Id: **btnChat**
    - Onclick: **location.href='@Url.Action("Chat", "ShoppingCart")'**
    - Content: **Chat with Online Visitors**


#### Task 4: Write the JavaScript code to connect to the server

1.  Create a new folder with the following information:

	- Folder name: **js**
	- Parent folder: **wwwroot**

2. Add the **chat-hub.js** file to the **ElectricStore** project, with the following information:

	- Source location: **[Repository Root]\Allfiles\Mod12\Labfiles\ElectricStoreJS**
	- Target location: **[Repository Root]\Allfiles\Mod12\Labfiles\01_ElectricStore_begin\ElectricStore\wwwroot\js**

3. In the **Chat.cshtml** view, in the **Scripts** section, add a **SCRIPT** element with the following information:

    - Src: **~/js/chat-hub.js**

#### Task 5:  Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In the menu bar, click **My Shopping Cart**.

4. On the **My Shopping Cart** page, click **Chat with Online Visitors**.

5. On the taskbar, right-click the **Microsoft Edge** icon, and then click **New Window**.

6. In the second **Microsoft Edge** window, open **http://localhost:[port]/ShoppingCart/Chat**.

7. In the second **Microsoft Edge** window, fill the following, and then click **Send message**.

	-  Name: **_&lt;A name of your choice&gt;_**
    -  Message: **_&lt;A message of your choice&gt;_**

    >**Note**:  In both **Microsoft Edge** windows, the message appears.

8. In the first **Microsoft Edge** window, fill the following, and then click **Send message**.

	-  Name: _&lt;A name of your choice&gt;_
    -  Message: _&lt;A message of your choice&gt;_

    >**Note**: In both **Microsoft Edge** windows, the message appears.

9. Close all **Microsoft Edge** windows.

10. Close Microsoft Visual Studio.

>**Results**: After completing this exercise, you would have created an electric store in which users can view product details, order some as well, and chat with online site visitors.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
