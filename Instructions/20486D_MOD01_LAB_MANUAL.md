## Module 1: Exploring ASP.NET Core MVC

## Lab: Explore ASP.NET Core MVC 

#### Scenario

You are working as a junior developer at Adventure Works. You have been asked by a senior developer to investigate the possibility of creating a web-based ASP.NET Core MVC application for your organization's customers, similar to one that the senior developer has seen on the Internet. Such an application will promote a community of cyclists who use Adventure Works equipment, and the community members will be able to share their experiences. This initiative is intended to increase the popularity of Adventure Works Cycles, and thereby to increase sales. You have been asked to begin the planning of the application. You have also been asked to examine programming models available to ASP.NET Core  developers. To do this, you need to create basic web applications written with three different models: Razor Pages , Web API , and MVC. Your manager has asked you to report on the following specific questions for each programming model:

- How does the developer add Mvc Services to the Web Application?
- How does the developer add  Mvc to the request execution pipeline?
- How does the developer add a new page to the application and apply the layout and styles to it?

#### Objectives

After completing this lab, you will be able to:

- Describe and compare the three programming models available in ASP.NET Core.
- Describe the structure of each web application developed in the three programming models —Razor Pages , Web API , and MVC.
- Select an appropriate programming model for a given set of web application requirements.

#### Lab Setup

Estimated Time: **90 minutes**

### Exercise 1: Exploring a Razor Pages Application

#### Scenario

In this exercise, you will create a simple Razor Pages application and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Razor Pages application.

2. Explore the application structure.

3. Add simple functionality.


#### Task 1: Creating a Razor Pages application
1. Start Visual Studio 2017 and create a new Razor Pages project with the following name **ActorsRazorPages** by using the **Web Application** C# template.

2. Run the new Razor Pages application in Microsoft Edge and review the **Contact** page.

3. Stop debugging by closing Microsoft Edge.

#### Task 2: Explore the application structure.

1. Open the **Startup.cs** class and verify that mvc service is added to the request execution pipeline.

2. Verify that the **Index.cshtml** page and the **Contact.cshtml** page are linked to the same layout.

3. Verify that the **Site.css** file is used to apply styles to all pages on the site. Note that the **_Layout.cshtml** page is linked to the style sheet.

#### Task 3: Add simple functionality.

1. Add a new Razor Page to the **Pages** folder using the following information:
 
    - Razor Page name: **TestPage.cshtml**
    - Use a layout page: **checked** 

2. Add a **ViewData**  

    - ViewData Key: **Title**
    - ViewData Value : **"Test Page"**

3. Add an **H1** element to the TestPage.cshtml page by using the following information:

    - Content: **This is a Test Page**

4. Add a link to the **_Layout.cshtml** page by using the following information:

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-page=&quot;/TestPage&quot;**
    - Content: **Test Page**
    - End tag: **&lt;/a&gt;&lt;/li&gt;**

5. Add a new folder to the application at the root level by using the following information:
 
   - Folder name: **Models**
 
6. Add a new model class to the **Models** folder by using the following information:

   - Class name: **Actor**

7. Add a primary key property to the **Actor** model class by using the following information:

   - Scope: **public**
   - Property name: **Id**
   - Data type: **integer**
   - Access: **Read and write**

8. Add a **FirstName** property to the **Actor** model class by using the following information:

   - Scope: **public**
   - Property name: **FirstName**
   - Data type: **string**
   - Access: **Read and write**

9.  Add a **LastName** property to the **Actor** model class by using the following information:

    - Scope: **public**
    - Property name: **LastName**
    - Data type: **string**
    - Access: **Read and write**

10. Add a **KnownFor** property to the **Actor** model class by using the following information:

    - Scope: **public**
    - Property name: **KnownFor**
    - Data type: **string**
    - Access: **Read and write**

11. Add an **OscarWinner** property to the **Actor** model class by using the following information:
 
    - Scope: **public**
    - Property name: **OscarWinner**
    - Data type: **bool**
    - Access: **Read and write**

12. Add an **ImageName** property to the **Actor** model class by using the following information:
 
    - Scope: **public**
    - Property name: **ImageName**
    - Data type: **string**
    - Access: **Read and write**

13. Add a new interface called **IData** to the Models folder in the project.

14. Set **public** scope to the new interface.

15. Add the **ActorsList** property to the **IData** interface by using the following information:
 
    - Type: **List&lt;Actor&gt;**
    - Name: **ActorsList**
    - Access: **Read and write**

16. Add the **ActorsInitializeData** method to the **IData** interface by using the following information:

    - Return type: **List&lt;Actor&gt;**
    - Name: **ActorsInitializeData**

17. Add the **GetActorById** method to the **IData** interface by using the following information:

    - Return type: **Actor**
    - Name: **GetActorById**
    - Parameter: an Nullable integer named **Id**

18. Add the **Data.cs** existing file to the **Model** folder from the following location:
 
     - **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin**

19. Add the **images** existing files to the **images** folder inside **wwwroot** folder from the following location:
  
    -  **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin/Images**     

20. Inside  the **Pages** folder Add a new folder using the following information:
  
    - Folder name: **Actors**

21. Add a new Razor Page using the following information:

    - Folder: **Pages/Actors**
    - Name: **Index**
    - Use a layout page: **checked**
  
22.  In the **Index.cshtml.cs** class, create a new private object using the following information:
 
     - Scope: **private**
     - Class: **IData**
     - Name: **_data**

   Instantiate the new object by calling the **IData**  in the constructor.
   
23. Add the **Actors** property to the **Index.cshtml.cs** class by using the following information:

    - Type: **List&lt;Actor&gt;**
    - Name: **Actors**
    - Access: **Read and write**

24. In  the  **Index.cshtml.cs** class  inside **OnGet** method  initiate **Actors** property  with **ActorsInitializeData** method from the IData interface.

25.  Open the **Indexcshtml.txt** existing file and copy the content into the **Index.cshtml**  file from the following location:
 
     - **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin/Pages**

26. Add the **Details.cs** and **Details.cshtml** existing files to the **Pages/Actors** folder from the following location:

      - **Allfiles/Mod01/Labfiles/01_ActorsRazorPages_begin/Pages**   

>**Note:**  That the namespace project name identical to your project name in both files. 

27.  In the **Startup.cs**  class add **IData** to the services container as Singleton.

28. Add a link to the **_Layout.cshtml** page by using the following information:
 
    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-page=&quot;/Actors/Index&quot;**
    - Content: **Actors**
    - End tag: **&lt;/a&gt;&lt;/li&gt;**

#### Task 4: Run the application.

1. Save all the changes.

2. Run the website, and view the **Test Page** and **Actors** pages you added.

3. Stop debugging by closing Microsoft Edge.

>**Results**: At the end of this exercise, you will be able to build a simple Razor Pages application in Visual Studio.
>

### 	Exercise 2: Exploring a Web API Application

#### Scenario

In this exercise, you will create a simple Web API application and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Web API  application.

2. Explore the application structure.

3. Add simple functionality.


#### Task 1: Creating a Web API application.

1. Start Visual Studio 2017 and create a new Web API project with the following name **CakeStoreApi** by using the **Web API** C# template.

2. Run the new Web API application in Microsoft Edge and review the **Content** displayed.

3. Stop debugging by closing Microsoft Edge.

#### Task 2: Explore the application structure.

1. Open the **Startup.cs** class and verify that mvc service is added to the request execution pipeline.

2.  Open the  **ValuesController.cs** class inside the **Controller** folder and verify  that the **Get** method return type is Array of String.

#### Task 3: Add simple functionality.

1. Add a new folder to the application at the root level by using the following information:

   - Folder name: **Models**
 
2. Add a new model class to the **Models** folder by using the following information:

   - Class name: **CakeStore**

3. Add a primary key property to the **CakeStore** model class by using the following information:

   - Scope: **public**
   - Property name: **Id**
   - Data type: **integer**
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

11. Add the **Data.cs** existing file to the **Model** folder from the following location:
 
     - **Allfiles/Mod01/Labfiles/02_CakeStoreApi_begin**

12. Create a new controller for handling **CakeStore** objects by using the following information:
 
    - Controller name: **CakeStoreApiController**
    - Template: **API Controller - Empty**
 
13. In the **CakeStoreApiController** class, create a new private object by using the following information:
 
    - Scope: **private**
    - Class: **IData**
    - Name: **_data**

    Instantiate the new object by calling the **IData**  in the constructor.
 
14. Add a method for the **GetAll** action by using the following information:
 
     - Scope: **public**
     - Return Type : **IEnumerable&lt;CakeStore&gt;**
     - View name: **GetAll**
     - Model:  **_data.CakesInitializeData();**

>**Note**: The **_data** parameter is the private object you just Instantiate.
>

15. Add to **GetAll** action **HttpGet**  attribute with the following information : 

     - template : **"/api/CakeStore"**
 
16. Add a method for the **GetById** action by using the following information:

     - Scope: **public**
     - Return Type: **IActionResult**
     - Name: **GetById**
     - Parameters: One Nullable  integer called **id**

17. Within the **GetById** action code block, add code to find a single **Cake** object from its **Id**.

18. If no Cake with the right Id is found, return the **NotFound** value.

19. If a Cake with the right Id is found, pass it to a new ObjectResult.

20. Add to **GetById** action **HttpGet**  attribute with the following information : 
     - template : **"/api/CakeStore/{id}"**

21. In the **Startup.cs**  class add **IData** to the services container as Singleton.

#### Task 4: Run the application.

1. Save all the changes.

2. Run the website, and view the content you added.

3. Stop debugging by closing Microsoft Edge.

>**Results**: At the end of this exercise, you will be able to build a simple Web API application in Visual Studio.
>

### 	Exercise 3: Exploring an MVC Application

#### Scenario

In this exercise, you will create a simple MVC application and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a MVC  application.

2. Explore the application structure.

3. Add simple functionality.

#### Task 1: Creating an MVC application
1. Start Visual Studio 2017 and create a new Mvc project with the following name **AnimalsMvc** by using the **Web Application (Model-View-Controller)** C# template.

2. Run the new MVC application in Microsoft Edge and review the **Contact** page.

3. Stop debugging by closing Microsoft Edge.

#### Task 2: Explore the application structure.

1. Open the **Startup.cs** class and verify that mvc service is added to the request execution pipeline.

2. Verify that the **Index.cshtml** page and the **Contact.cshtml** page are linked to the same layout.

3. Verify that the Site.css file is used to apply styles to all pages on the site. Note that the **_Layout.cshtml** page is linked to the style sheet.

#### Task 3: Add simple functionality.
1. In the **HomeController** class, Add a method for the **TestPage** action by using the following information:

   - Scope: **public**
   - Return Class: **IActionResult**
   - Name: **TestPage**

2.  The  **TestPage** action returns empty View method.

3.  Add a new view to the **TestPage** action in the **HomeController** by using the following information:

    - Name: **TestPage**
    - Scaffold template: **Empty (without model)**  
    - Use a layout page: **checked**
 
4. Add an **H1** element to the **TestPage.cshtml** page by using the following information:

    - Content: **This is a Test Page**

5. In the **Shared** folder  inside **_Layout.cshtml** page Add a link using the following information:

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-area=&quot;&quot;**
    - Attribute: **asp-controller=&quot;Home&quot;**
    - Attribute: **asp-action=&quot;TestPage&quot;**
    - Content: **Test Page**
    - End tag: **&lt;/a&gt;&lt;/li&gt;**

 
6. Add a new model class to the **Models** folder by using the following information:

   - Class name: **Animal**

7. Add a primary key property to the **Animal** model class by using the following information:
  
   - Scope: **public**
   - Property name: **Id**
   - Data type: **integer**
   - Access: **Read and write**
  
8. Add a **Name** property to the **Animal** model class by using the following information:
  
     - Scope: **public**
     - Property name: **Name**
     - Data type: **string**
     - Access: **Read and write**

9.  Add an **ImageName** property to the **Animal** model class by using the following information:

     - Scope: **public**
     - Property name: **ImageName**
     - Data type: **string**
     - Access: **Read and write**
 
10.  Add an **UniqueInformation** property to the **Animal** model class by using the following information:

      - Scope: **public**
      - Property name: **UniqueInformation**
      - Data type: **string**
      - Access: **Read and write**
   
11. Add a **Category** property to the **Animal** model class by using the following information:
 
       - Scope: **public**
       - Property name: **Category**
       - Data type: **string**
       - Access: **Read and write**

12. Add a new interface called **IData** to the Models folder in the project.

13. Set **public** scope to the new interface.

14. Add the **AnimalsList** property to the **IData** interface by using the following information:

     - Type: **List&lt;Animal&gt;**
     - Name: **AnimalsList**
     - Access: **Read and write**

15. Add the **AnimalsInitializeData** method to the **IData** interface by using the following information:

     - Return type: **List&lt;Animal&gt;**
     - Name: **AnimalsInitializeData**

16. Add the **GetAnimalById** method to the **IData** interface by using the following information:

     - Return type: **Animal**
     - Parameter: an Nullable integer named **Id**
     - Name: **GetAnimalById**

17. Add the **Data.cs** existing file to the **Model** folder from the following location:
 
     - **Allfiles/Mod01/Labfiles/03_AnimalsMvc_begin**


18. Add a new model class to the **Models** folder by using the following information:

    - Class name: **IndexViewModel**

19. Add a **Animals** property to the **IndexViewModel** model class by using the following information:
 
    - Scope: **public**
    - Property name: **Animals**
    - Data type: **List&lt;Animal&gt;**
    - Access: **Read and write**

20.  Create a new controller for handling **Animal** objects by using the following information:

     - Controller name: **AnimalsController**
     - Template: **MVC Controller - Empty**

21.   Add **using** statement to the controller for the **Models** namespaces.

22. In the **AnimalsController** class, create a new private object by using the following information:

    - Scope: **private**
    - Class: **IData**
    - Name: **_tempData**

    Instantiate the new object by calling the **IData**  in the constructor.
 
23. Edit the code in the **Index** action by using the following information:

     - Return class: **View**
     - View name: **Index**
     - Model: **indexViewModel**

24. Initiate  **indexViewModel** Animals List  property  with **AnimalsInitializeData** method from the IData interface.

25. Add a method for the **Details** action by using the following information:

    - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Details**
    - Parameters: One nullable integer called **id**

26. Within the **Details** action code block, add code to find a single **Animal** object from its **Id**.

27. If no animal with the right Id is found, return the **NotFound** value.

28. If an animal with the right Id is found, pass it to a view called **Details**.

29. Add the **images** existing files to the **images** folder from the following location:

    -  **Allfiles/Mod01/Labfiles/03_AnimalsMvc_begin/Images**     

30.  Add a new view to the **Index** action in the **AnimalsController** by using the following information:

     - Name: **Index**
     - Scaffold template: **Empty (without model)***
     - Use a layout page: **Yes**
 
>**Note**: Make sure that you have **IndexViewModel** model namespace in the view. 
>

31. Open the **Indexcshtml.txt** existing file and copy the content into the **Index.cshtml**  file from the following location:

     - **Allfiles/Mod01/Labfiles/03_AnimalsMvc_begin/Views**

32.  Add a new view to the **Details** action in the **AnimalsController** by using the following information:

     - Name: **Details**
     - Scaffold template: **Empty (without model)***
     - Use a layout page: **Yes**
 
>**Note**: Make sure that you have **Animal** model namespace in the view.

 
33. Open the **Detailscshtml.txt** existing file and copy the content into the **Details.cshtml**  file from the following location:
 
     - **Allfiles/Mod01/Labfiles/03_AnimalsMvc_begin/Views**

34. In the **Shared** folder  inside **_Layout.cshtml** page Add a link using the following information:

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-area=&quot;&quot;**
    - Attribute: **asp-controller=&quot;Animals&quot;**
    - Attribute: **asp-action=&quot;Index&quot;**
    - Content: **Animals**
    - End tag: **&lt;/a&gt;&lt;/li&gt;** 

35. In the **Startup.cs**  class add **IData** to the services container as Singleton.

36. Save all the changes.

37. Run the website, and view the page you added.

38. Stop debugging by closing Microsoft Edge.

#### Task 4: Run the application.

1. Save all the changes.

2. Run the website, and view the **Test Page** and **Animals** pages you added.

3. Stop debugging by closing Microsoft Edge.

>**Results**: At the end of this exercise, you will be able to build a simple Mvc application in Visual Studio.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
