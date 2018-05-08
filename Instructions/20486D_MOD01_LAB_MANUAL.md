# Module 1: Exploring ASP.NET Core MVC

# Lab: Exploring ASP.NET Core MVC 

#### Scenario

You are working as a junior developer at Adventure Works. You have been asked by a senior developer to investigate the possibility of creating a web-based ASP.NET Core MVC application for your organization's customers, similar to one that the senior developer has seen on the Internet. Such an application will promote a community of cyclists who use Adventure Works equipment, and the community members will be able to share their experiences. This initiative is intended to increase the popularity of Adventure Works Cycles, and thereby to increase sales. You have been asked to begin the planning of the application. You have also been asked to examine programming models available to ASP.NET Core  developers. To do this, you need to create basic web applications written with three different models: Razor Pages , Web API , and MVC. Your manager has asked you to report on the following specific questions for each programming model:

- How does the developer add MVC Services to the Web Application?
- How does the developer add  MVC to the request execution pipeline?
- How does the developer add a new page to the application applying the layout and styles to it?

#### Objectives

After completing this lab, you will be able to:

- Describe and compare the three programming models available in ASP.NET Core.
- Describe the structure of each web application developed in the three programming models —Razor Pages , Web API , and MVC.
- Select an appropriate programming model for a given set of web application requirements.

#### Lab Setup

Estimated Time: **90 minutes**

### Exercise 1: Exploring a Razor Pages Application

#### Scenario

In this exercise, you will create a simple Razor Pages application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Razor Pages application.

2. Explore the application structure.

3. Add simple functionality.

4. Run the application.

#### Task 1: Creating a Razor Pages application.

1. Start Visual Studio 2017, and create a new MVC project with the following information:

    - Name: **ActorsRazorPages**
    - Location: **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin**
    - Solution name: **ActorsRazorPages**
    - Create directory for the solution: **True**
    - Project template: **Web Application**

2. Run the new Razor Pages application in **Microsoft Edge**, and view the **Contact** page.

3. **Stop debugging**.

#### Task 2: Explore the application structure.

1. Open **Startup.cs** and verify that MVC service is added to the service container.

2. In the **Startup.cs**, verify that MVC is added to the request execution pipeline.

3. Verify that **_ViewStart.cshtml** is linked to **_Layout.cshtml**.

4. Verify that **Contact.cshtml** is not linked to .css file.

5. Verify that **_Layout.cshtml** is in the **HEAD** element linked to **site.css** file.

6. Open the **site.css** style sheet.

#### Task 3: Add simple functionality.

1. Add a new Razor Page to the **Pages** folder using the following information:
 
    - Razor Page name: **TestPage.cshtml**

2. Add a **ViewData** to the **TestPage.cshtml** by using the following information: 

    - ViewData Key: **Title**
    - ViewData Value : **"Test Page"**

3. Add an **H1** element to the **TestPage.cshtml** by using the following information:

    - Content: **@ViewData["Title"]**

4. Add an **H2** element to the **TestPage.cshtml** by using the following information:

    - Content: **This is a Test Page**

5. Add a link to the **_Layout.cshtml** by using the following information:

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-page=&quot;/TestPage&quot;**
    - Content: **Test Page**
    - End tag: **&lt;/a&gt;&lt;/li&gt;**

6. Add a new folder to the application at the root level by using the following information:
 
   - Folder name: **Models**
 
7. Add a new model class to the **Models** folder by using the following information:

   - Class name: **Actor**

8. Add an **ID** property to the **Actor** model class by using the following information:

   - Scope: **public**
   - Property name: **Id**
   - Data type: **int**
   - Access: **Read and write**

9. Add a **FirstName** property to the **Actor** model class by using the following information:

   - Scope: **public**
   - Property name: **FirstName**
   - Data type: **string**
   - Access: **Read and write**

10.  Add a **LastName** property to the **Actor** model class by using the following information:

     - Scope: **public**
     - Property name: **LastName**
     - Data type: **string**
     - Access: **Read and write**

11. Add a **KnownFor** property to the **Actor** model class by using the following information:

    - Scope: **public**
    - Property name: **KnownFor**
    - Data type: **string**
    - Access: **Read and write**

12. Add an **OscarWinner** property to the **Actor** model class by using the following information:
 
    - Scope: **public**
    - Property name: **OscarWinner**
    - Data type: **bool**
    - Access: **Read and write**

13. Add an **ImageName** property to the **Actor** model class by using the following information:
 
    - Scope: **public**
    - Property name: **ImageName**
    - Data type: **string**
    - Access: **Read and write**

14. Add a new interface called **IData** to the Models folder in the project.

15. Set **public** scope to the new interface.

16. Add the **ActorsList** property to the **IData** interface by using the following information:
 
    - Type: **List&lt;Actor&gt;**
    - Name: **ActorsList**
    - Access: **Read and write**

17. Add the **ActorsInitializeData** method to the **IData** interface by using the following information:

    - Return type: **List&lt;Actor&gt;**
    - Name: **ActorsInitializeData**

18. Add the **GetActorById** method to the **IData** interface by using the following information:

    - Return type: **Actor**
    - Name: **GetActorById**
    - Parameter: an Nullable integer named **Id**

19. Add **Data.cs** to the **Model** folder from the following location:
 
     - **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin**

20. Add the **images** existing files to the **images** folder inside **wwwroot** folder from the following location:
  
    -  **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin/Images**     

21. Inside  the **Pages** folder Add a new folder using the following information:
  
    - Folder name: **Actors**

22. Add a new Razor Page using the following information:

    - Folder: **Pages/Actors**
    - Name: **Index**
  
23.  In the **Index.cshtml.cs**, create a new private object using the following information:
 
     - Scope: **private**
     - Class: **IData**
     - Name: **_data**
     
     Initialize the new object in the **Index.cshtml.cs** constructor with the value **IData data**.
   
24. Add the **Actors** property to the **Index.cshtml.cs** by using the following information:

    - Scope: **public**
    - Type: **List&lt;Actor&gt;**
    - Name: **Actors**
    - Access: **Read and write**

25. In the **Index.cshtml.cs** class inside **OnGet** method initiate **Actors** property  with **ActorsInitializeData** method from the IData interface.

26. Delete the content in the **Index.cshtml**.

27. Open **Indexcshtml.txt** and copy the all the content into the **Index.cshtml** from the following location:
 
     - **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin/Pages**

28. Add the **Details.cs** and **Details.cshtml** to the **Pages/Actors** folder from the following location:

      - **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin/Pages**   

29.  In the **Startup.cs**, in the **ConfigureServices** method code block, add **IData** to the services container as Singleton.

30. Add a link to the **_Layout.cshtml** by using the following information:
 
    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-page=&quot;/Actors/Index&quot;**
    - Content: **Actors**
    - End tag: **&lt;/a&gt;&lt;/li&gt;**

#### Task 4: Run the application.

1. Save all the changes.

2. **Start debugging** the application.

3. View the **Test Page** and **Actors** pages you added.

4. In the Actors window, click on the **Details** button, and then verify that the **Site.css** file is used to apply style.

5. Close the Microsoft Edge window, and the Visual Studio application.

>**Results**: At the end of this exercise, you will be able to build a simple Razor Pages application in Visual Studio.

### Exercise 2: Exploring a Web API Application

#### Scenario

In this exercise, you will create a simple Web API application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Web API  application.

2. Explore the application structure.

3. Add simple functionality.

4. Run the application.

#### Task 1: Creating a Web API application.

1. Start Visual Studio 2017, and create a new MVC project with the following information:

    - Name: **CakeStoreApi**
    - Location: **Allfiles/Mod01/Labfiles/02_CakeStoreApi_begin**
    - Solution name: **CakeStoreApi**
    - Create directory for the solution: **True**
    - Project template: **API**

#### Task 2: Explore the application structure.

1. Open **Startup.cs** and verify that MVC service is added to the service container.

2. In the **Startup.cs**, verify that MVC is added to the request execution pipeline.

3.  Open the  **ValuesController.cs** inside the **Controller** folder, and verify  that the **Get** method returns **value1** and **value2**.

4. Run the website in Microsoft Edge, and view the content in the browser.

5. **Stop Debugging**.

#### Task 3: Add simple functionality.

1. Add a new folder to the application at the root level by using the following information:

   - Folder name: **Models**
 
2. Add a new model class to the **Models** folder by using the following information:

   - Class name: **CakeStore**

3. Add an **Id** property to the **CakeStore** model class by using the following information:

   - Scope: **public**
   - Property name: **Id**
   - Data type: **int**
   - Access: **Read and write**

4.   Add a **CakeType** property to the **CakeStore** model class by using the following information:
 
     - Scope: **public**
     - Property name: **CakeType**
     - Data type: **string**
     - Access: **Read and write**

5. Add a **Quantity** property to the **CakeStore** model class by using the following information:
 
   - Scope: **public**
   - Property name: **Quantity**
   - Data type: **integer**
   - Access: **Read and write**
 
6. Add a new interface called **IData** to the Models folder in the project.

7. Set **public** scope to the new interface.

8. Add the **CakesList** property to the **IData** interface by using the following information:
 
   - Type: **List&lt;CakeStore&gt;**
   - Name: **CakesList**
   - Access: **Read and write**

9. Add the **CakesInitializeData** method to the **IData** interface by using the following information:
 
   - Return type: **List&lt;CakeStore&gt;**
   - Name: **CakesInitializeData**

10. Add the **GetCakeById** method to the **IData** interface by using the following information:

    - Return type: **CakeStore**
    - Name: **GetCakeById**
    - Parameter: an Nullable integer named **Id**

11. Add the **Data.cs** to the **Model** folder from the following location:
 
     - **Allfiles/Mod01/Labfiles/02_CakeStoreApi_begin**

12. Create a new controller for handling **CakeStore** objects by using the following information:
 
    - Controller name: **CakeStoreApiController**
    - Template: **API Controller - Empty**
 
13. Add **using** statements to the controller for the following namespaces

    - **CakeStoreApi.Models**

14. In the **CakeStoreApiController**, create a new private field by using the following information:
 
    - Scope: **private**
    - Class: **IData**
    - Name: **_data**

    Initialize the new field in the **CakeStoreApiController** constructor with the value **IData data**.
 
15. Add a method for the **GetAll** action by using the following information:
 
     - Scope: **public**
     - Return Type : **IEnumerable&lt;CakeStore&gt;**
     - Name: **GetAll**

16. Within the **GetAll** method, return the following information :

    - **_data.CakesInitializeData()**

>**Note**: The **_data** field is the private object you just Instantiate.

17. Add to **GetAll** action **HttpGet**  attribute with the following information: 

     - template : **"/api/CakeStore"**
 
18. Add a method for the **GetById** action by using the following information:

     - Scope: **public**
     - Return Type: **IActionResult**
     - Name: **GetById**
     - Parameters: One Nullable  integer called **id**

19. Within the **GetById** action code block, add code to find a single **Cake** object from its **Id**.

20. If no Cake with the right Id is found, return NotFoundResult using the **NotFound** method.

21. If a Cake with the right Id is found, return a new object result containing the cake object.

22. Add to **GetById** action **HttpGet**  attribute with the following information : 
     - template : **"/api/CakeStore/{id}"**

23. In the **Startup.cs**, add **using** statements to the controller for the following namespaces

      - **CakeStoreApi.Models**

24. In the **Startup.cs**, in the **ConfigureServices** method code block, add **IData** to the services container as Singleton.

#### Task 4: Run the application.

1. Save all the changes.

2. **Start Debugging** the application.

3. In the **Microsoft Edge** window, request the relative URL.

    - URL: **/api/CakeStore**

4. In the **Microsoft Edge** window, request the relative URL.

    - URL: **/api/CakeStore/1**

5. Close the Microsoft Edge window, and the Visual Studio application.

>**Results**: At the end of this exercise, you will be able to build a simple Web API application in Visual Studio.

### Exercise 3: Exploring an MVC Application

#### Scenario

In this exercise, you will create a simple MVC application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a MVC  application.

2. Explore the application structure.

3. Add simple functionality.

4. Run the application.

#### Task 1: Creating an MVC application.

1. Start Visual Studio 2017, and create a new MVC project with the following information:

    - Name: **AnimalsMvc**
    - Location: **Allfiles/Mod01/Labfiles/03_AnimalMvc_begin**
    - Solution name: **AnimalsMvc**
    - Create directory for the solution: **True**
    - Project template: **Web Application (Model-View-Controller)**

2. Run the new MVC application in **Microsoft Edge** window, and view **Contact** page.

3. **Stop Debugging**.

#### Task 2: Explore the application structure.

1. Open **Startup.cs** and verify that MVC service is added to the service container.

2. In the **Startup.cs**, verify that MVC is added to the request execution pipeline.

3. Verify that **_ViewStart.cshtml** is linked to **_Layout.cshtml**.

4. Verify that **Contact.cshtml** not linked to .css file.

5. Verify that **_Layout.cshtml**, in the **HEAD** element linked to **site.css** file.

6. Open the **site.css** style sheet.

    >**Note:** This is the CSS **style sheet** file that applied in the **Layout.cshtml**.

#### Task 3: Add simple functionality.

1. In the **HomeController** Add a method for the **TestPage** action by using the following information:

   - Scope: **public**
   - Return class: **View**
   - Name: **TestPage**

2.  Add a new view to the **TestPage** action in the **HomeController** by using the following information:

    - Name: **TestPage**
    - Scaffold template: **Empty (without model)**  
    - Use a layout page: **checked**
 
3. Add an **H3** element to the **TestPage.cshtml** by using the following information:

    - Content: **This is a Test Page**

4. In the **Shared** folder  inside **_Layout.cshtml** add a link using the following information:

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-area=&quot;&quot;**
    - Attribute: **asp-controller=&quot;Home&quot;**
    - Attribute: **asp-action=&quot;TestPage&quot;**
    - Content: **Test Page**
    - End tag: **&lt;/a&gt;&lt;/li&gt;**

 
5. Add a new model class to the **Models** folder by using the following information:

   - Class name: **Animal**

6. Add an **ID** property to the **Animal** model class by using the following information:
  
   - Scope: **public**
   - Property name: **Id**
   - Data type: **int**
   - Access: **Read and write**
  
7. Add a **Name** property to the **Animal** model class by using the following information:
  
     - Scope: **public**
     - Property name: **Name**
     - Data type: **string**
     - Access: **Read and write**

8.  Add an **ImageName** property to the **Animal** model class by using the following information:

     - Scope: **public**
     - Property name: **ImageName**
     - Data type: **string**
     - Access: **Read and write**
 
9.  Add an **UniqueInformation** property to the **Animal** model class by using the following information:

      - Scope: **public**
      - Property name: **UniqueInformation**
      - Data type: **string**
      - Access: **Read and write**
   
10. Add a **Category** property to the **Animal** model class by using the following information:
 
       - Scope: **public**
       - Property name: **Category**
       - Data type: **string**
       - Access: **Read and write**

11. Add a new interface called **IData** to the Models folder in the project.

12. Set **public** scope to the new interface.

13. Add the **AnimalsList** property to the **IData** interface by using the following information:

     - Type: **List&lt;Animal&gt;**
     - Name: **AnimalsList**
     - Access: **Read and write**

14. Add the **AnimalsInitializeData** method to the **IData** interface by using the following information:

     - Return type: **List&lt;Animal&gt;**
     - Name: **AnimalsInitializeData**

15. Add the **GetAnimalById** method to the **IData** interface by using the following information:

     - Return type: **Animal**
     - Parameter: an Nullable integer named **Id**
     - Name: **GetAnimalById**

16. Add the **Data.cs** existing file to the **Model** folder from the following location:
 
     - **Allfiles/Mod01/Labfiles/03_AnimalMvc_begin**

17. Add a new model class to the **Models** folder by using the following information:

    - Class name: **IndexViewModel**

18. Add a **Animals** property to the **IndexViewModel** model class by using the following information:
 
    - Scope: **public**
    - Property name: **Animals**
    - Data type: **List&lt;Animal&gt;**
    - Access: **Read and write**

19. Add a new controller to the **AnimalsMvc** project by using the following information:

     - Controller name: **AnimalsController**
     - Template: **MVC Controller - Empty**

20. Add **using** statement to the controller for the **Models** namespaces.

21. In the **AnimalsController**, delete the **Index** method code block.

21. In the **AnimalsController.cs** create a new private field by using the following information:

    - Scope: **private**
    - Class: **IData**
    - Name: **_tempData**

    Initialize the new field in the **AnimalsController** constructor with the value **IData data**.
 
22. Add a method for the **Index** action by using the following information:

     - Scope: **public**
     - Return Type: **IActionResult**
     - Name: **Index**
     - Model: **_tempData.AnimalsInitializeData()**

23. In the **Index** action, initiate the **Animals** property from the **IndexViewModel** with the view **Model**, and return the **animals** list to the **Index** view.

24. Add a method for the **Details** action by using the following information:

    - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Details**
    - Parameters: One nullable integer called **id**

25. Within the **Details** action code block, add code to find a single **Animal** object from its **Id**.

26. If no animal with the right Id is found, return **NotFoundResult** using the **NotFound** method.

27. If an animal with the right Id is found, return the **Animal** object to the **Details** view.

28. Add the **images** existing files to the **images** folder from the following location:

    -  **Allfiles/Mod01/Labfiles/03_AnimalMvc_begin/Images**     

29.  Add a new view to the **Index** action in the **AnimalsController** by using the following information:

     - Name: **Index**
     - Scaffold template: **Empty (without model)**
     - Use a layout page: **Yes**
 
30. Delete the content in the **Index.cshtml**.

31. Open the **Indexcshtml.txt** existing file and copy all the content into the **Index.cshtml** from the following location:

     - **Allfiles/Mod01/Labfiles/03_AnimalMvc_begin/Views**

32.  Add a new view to the **Details** action in the **AnimalsController** by using the following information:

     - Name: **Details**
     - Scaffold template: **Empty (without model)**
     - Use a layout page: **Yes**
 
33. Delete the content in the **Details.cshtml**.

34. Open the **Detailscshtml.txt** existing file and copy the content into the **Details.cshtml** from the following location:
 
     - **Allfiles/Mod01/Labfiles/03_AnimalMvc_begin/Views**

35. In the **Shared** folder  inside **_Layout.cshtml** Add a link using the following information:

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-area=&quot;&quot;**
    - Attribute: **asp-controller=&quot;Animals&quot;**
    - Attribute: **asp-action=&quot;Index&quot;**
    - Content: **Animals**
    - End tag: **&lt;/a&gt;&lt;/li&gt;** 

36. In the **Startup.cs**, in the **ConfigureServices** method code block, add **IData** to the services container as Singleton.

#### Task 4: Run the application.

1. Save all the changes.

2. **Start Debugging** the application.

3. View the **Test Page** and **Animals** pages you added.

4. In the **Animals** window, click on the **Details** button, and verify that the Site.css file is used to apply style.

5. Close the **Microsoft Edge** window and the Visual Studio application.

>**Results**: At the end of this exercise, you will be able to build a simple MVC application in Visual Studio.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
