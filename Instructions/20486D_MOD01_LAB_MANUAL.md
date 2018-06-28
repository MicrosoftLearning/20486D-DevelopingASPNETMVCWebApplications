# Module 1: Exploring ASP.NET Core MVC

# Lab: Exploring ASP.NET Core MVC 

#### Scenario

You are working as a junior developer at Adventure Works. You have been asked by a senior developer to investigate the possibility of creating a web-based ASP.NET Core MVC application for your organization's customers, similar to one that the senior developer has seen on the Internet. Such an application will promote a community of cyclists who use Adventure Works equipment, and the community members will be able to share their experiences. This initiative is intended to increase the popularity of Adventure Works Cycles, and thereby to increase sales. You have been asked to begin the planning of the application. You have also been asked to examine programming models available to ASP.NET Core developers. To do this, you need to create basic web applications written with three different models: Razor Pages , Web API , and MVC. 

#### Objectives

After completing this lab, you will be able to:

- Describe and compare the three programming models —Razor Pages, Web API, and MVC.
- Describe the structure of each web application developed in the three programming models —Razor Pages , Web API , and MVC.
- Select an appropriate programming model for a given set of web application requirements.

#### Lab Setup

Estimated Time: **90 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos.
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Exploring a Razor Pages Application

#### Scenario

In this exercise, you will create a simple Razor Pages application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Razor Pages application.

2. Explore the application structure.

3. Add simple functionality.

4. Run the application.

#### Task 1: Creating a Razor Pages application

1. Open **Visual Studio 2017** and create a new **ASP.NET Core Web Application** with following information:

    - Name: **ActorsRazorPages**
    - Location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin**
    - Solution name: **ActorsRazorPages**
    - Create directory for solution: **True**
    - Project template: **Web Application**
    - Enable docker support: **False**
    - Configure for HTTPS: **False**

2. Start debugging the application.

3. In **Microsoft Edge** window, view the **Contact** page.

4. Close Microsoft Edge.

5. Stop Debugging.

#### Task 2: Explore the application structure

1. In the **_ViewImports** file, note that the value of **Layout** is **"_Layout"**.

2. In the **Contact.cshtml**  page, note that there are no links to **.css** files..

3.  In the **_Layout.cshtml** page, in the **HEAD** element, note that there is a link to **~/css/site.css**.

4. Open the **site.css** file.

#### Task 3: Add simple functionality

1. Create a new **Razor Page** with the following information:
 
    - Name: **TestPage.cshtml**
    - Folder: **Pages**
    - Generate PageModel class: **True**
    - Create as a partial view: **False**
    - Reference script libraries: **True**
    - Use a layout page: **True**

2. Remove the contents of the **TestPage.cshtml** page.

3. In the **TestPage.cshtml** page, save the following key and value in the **ViewData** property: 

    - Key: **Title**
    - Value : **"Test Page"**

4. Add an **H1** element with the following information:
    - Content: **@ViewData["Title"]**

5. Add an **H2** element with the following information:
    - Content: **This is a Test Page**

6. In the **_Layout.cshtml** page, in the **UL** element, add an **LI** element.

7. In the new **LI** element,  add an **A** element with the following information:

    - Content: **Test Page**
    - asp-page: **/TestPage**

8. Create a new folder with the following information:

   - Folder name: **Models**.

9. Create a new model with the following information:

   - Name: **Actor**
   - Folder: **Models**
 
10. In the the **Actor** model class, add a new property with the following information:

    - Scope: **public**
    - Name: **Id**
    - Type: **int**
    - Access:  **Read and write**

11. Add a new property with the following information:

    - Scope: **public**
    - Name: **FirstName**
    - Type: **string**
    - Access:  **Read and write**

12. Add a new property with the following information:

    - Scope: **public**
    - Name: **LastName**
    - Type: **string**
    - Access:  **Read and write**

13. Add a new property with the following information:

    - Scope: **public**
    - Name: **KnownFor**
    - Type: **string**
    - Access:  **Read and write**


14. Add a new property with the following information:

    - Scope: **public**
    - Name: **OscarWinner**
    - Type: **bool**
    - Access:  **Read and write**

15. Add a new property with the following information:

    - Scope: **public**
    - Name: **ImageName**
    - Type: **string**
    - Access:  **Read and write**

16. Create a new interface with the following information:

    - Name: **IData**
    - Folder: **Models**
    - Scope: **public**

17. In **IData** interface, declare a property with following information:

    - Type: **List&lt;Actor&gt;**
    - Name: **ActorsList**

18. Declare a method with following information:

    - Return type: **List<Actor>**
    - Name: **ActorsInitializeData**

19. Declare a method with following information:

    - Return type: **Actor**
    - Name: **GetActorById**
    - Parameter:
        - Name:  **id**
        - Type: **int?**

20. Copy the **Data.cs** file to the **ActorsRazorPages** project, with the following information:

     - Source location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin**
     - Target location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\ActorsRazorPages\Models**

21. Copy the **images** folder to the **ActorsRazorPages** project, with the following information:

     - Source location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin**
     - Target location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\ActorsRazorPages\wwwroot**

22. Create a new folder with the following information:
  
    - Folder name: **Actors**
    - Parent folder: **Pages**

23. Add a new **Razor Page** with the following information:

    - Folder: **Pages/Actors**
    - Name: **Index**

24. In the **Index.cshtml.cs** file, add a **using** statement for the following namespace:

    - **ActorsRazorPages.Models**

25. Create a new field with the following information:
 
     - Scope: **private**
     - Class: **IData**
     - Name: **_data**

26. Add a constructor with the following parameter:

     - Type: **IData**
     - Name: **data**

27. In the constructor, initialize the **_data** field with the value of the **data** parameter.

28.  Add a new property with the following information:

     - Scope: **public**
     - Name: **Actors**
     - Type: **List&lt;Actor&gt;**
     - Access:  **Read and write**

29. In the **OnGet** method, initialize the **Actors** property using the **ActorsInitializeData** method of the **_data.** field.

30. Delete the contents of the **Index.cshtml** page.

31. Copy the content of **Indexcshtml.txt** text file to the **Index.cshtml** page, using the following information:

     - Source location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\Pages**

32. Copy the **Details.cs** and **Details.cshtml** files to the **ActorsRazorPages** project, with the following information:

     - Source location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\Pages**
     - Target location: **Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\ActorsRazorPages\Pages\Actors**

33. In the **Startup** class, add a **using** statement for the following namespace:

    - **ActorsRazorPages.Models**

34. In the **ConfigureServices** method, call the **AddSingleton** method of **services** parameter with the following information:

    - Interface: **IData**
    - Implementation: **data**

35. In the **_Layout.cshtml** page, in the **UL** element, add a **LI** element.

36. In the new **LI** element,  add an **A** element with the following information:

    - Content: **Actors**
    - asp-page: **/Actors/Index**



#### Task 4: Run the application

1. Save all the changes.

2. Start Debugging the application.

3. View the **Test Page** and **Actors** pages you have added.

4. In the Actors window, click on the **Details** link.

5. Verify that the **site.css** file is used to apply style to all the pages.

6. Close the Microsoft Edge window.

7. Stop Debugging and close the Visual Studio application.

>**Results**: At the end of this exercise, you will be able to build a simple Razor Pages application in Visual Studio.

### Exercise 2: Exploring a Web API Application

#### Scenario

In this exercise, you will create a simple Web API application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Web API  application.

2. Explore the application structure.

3. Add simple functionality.

4. Run the application.

#### Task 1: Creating a Web API application

1. Start Visual Studio 2017, and create a new ASP.NET Core Web Application project with the following information:

    - Name: **CakeStoreApi**
    - Location: **Allfiles\Mod01\Labfiles\02_CakeStoreApi_begin**
    - Project template: **API**

#### Task 2: Explore the application structure

1.  Open the  **ValuesController.cs** inside the **Controllers** folder, and verify  that the **Get** method returns **value1** and **value2**.

2. Run the website in Microsoft Edge, and view the content in the browser.

3. Stop Debugging.

#### Task 3: Add simple functionality

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
 
6. Add a new interface called **IData** to the **Models** folder in the project.

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
    - Parameter: an Nullable integer named **id**

11. Add the **Data.cs** to the **Models** folder from the following location:
 
     - **Allfiles\Mod01\Labfiles\02_CakeStoreApi_begin**

12. Create a new controller for handling **CakeStore** objects by using the following information:
 
    - Controller name: **CakeStoreApiController**
    - Template: **API Controller - Empty**
 
13. Add **using** statement to the controller for the following namespace:

    - **CakeStoreApi.Models**

14. In the **CakeStoreApiController**, create a new private field by using the following information:
 
    - Scope: **private**
    - Class: **IData**
    - Name: **_data**

    Initialize the new field in the **CakeStoreApiController** constructor with the value of the **IData** parameter.
 
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

23. In the **Startup.cs**, add **using** statement for the following namespace:

      - **CakeStoreApi.Models**

24. In the **Startup.cs**, in the **ConfigureServices** method code block, add **IData** to the services container as Singleton.

#### Task 4: Run the application

1. Save all the changes.

2. Start Debugging the application, and access the following relative path:

    - Path: **/api/CakeStore**

4. In the **Microsoft Edge** window, access the following relative path:

    - Path: **/api/CakeStore/1**

5. Close the **Microsoft Edge** window, and the Visual Studio application.

>**Results**: At the end of this exercise, you will be able to build a simple Web API application in Visual Studio.

### Exercise 3: Exploring an MVC Application

#### Scenario

In this exercise, you will create a simple MVC application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a MVC  application.

2. Explore the application structure.

3. Add simple functionality.

4. Run the application.

#### Task 1: Creating an MVC application

1. Start Visual Studio 2017, and create a new ASP.NET Core Web Application project with the following information:

    - Name: **AnimalsMvc**
    - Location: **Allfiles\Mod01\Labfiles\03_AnimalMvc_begin**
    - Project template: **Web Application (Model-View-Controller)**

2. Run the new MVC application in **Microsoft Edge** window, and view **Contact** page.

3. Stop Debugging.

#### Task 2: Explore the application structure

1. Verify that **_ViewStart.cshtml** is linked to **_Layout.cshtml**.

2. Verify that **Contact.cshtml** not linked to .css file.

3. Verify that **_Layout.cshtml**, in the **HEAD** element linked to **site.css** file.

4. Open the **site.css** style sheet.

    >**Note:** This is the CSS **style sheet** file that applied in the **_Layout.cshtml**.

#### Task 3: Add simple functionality

1. In the **HomeController** Add a method for the **TestPage** action by using the following information:

   - Scope: **public**
   - Return class: **View**
   - Name: **TestPage**

2.  Add a new view to the **TestPage** action in the **HomeController** by using the following information:

    - Name: **TestPage**
    - Scaffold template: **Empty (without model)**  
    - Use a layout page: **True**

3. In the **TestPage.cshtml** replace the content, in the **H2** element with the following code:

    - Content: **This is a Test Page**

4. Add a link to the **_Layout.cshtml**, in the **UL** element after the last **LI** element, by using the following information:

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
     - Parameter: an Nullable integer named **id**
     - Name: **GetAnimalById**

16. Add the **Data.cs** existing file to the **Model** folder from the following location:
 
     - **Allfiles\Mod01\Labfiles\03_AnimalMvc_begin**

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

20. Add **using** statement to the controller for the following namespace:

      - **AnimalMvc.Models**

21. In the **AnimalsController**, delete the **Index** method code block.

22. In the **AnimalsController.cs** create a new private field by using the following information:

    - Scope: **private**
    - Class: **IData**
    - Name: **_tempData**

    Initialize the new field in the **AnimalsController** constructor with the value of the **IData** parameter.
 
23. Add a method for the **Index** action by using the following information:

     - Scope: **public**
     - Return Type: **IActionResult**
     - Name: **Index**

24. In the **Index** action, create a new instance named **indexViewModel** of type **IndexViewModel**.

25. Initiate the **Animals** property of the **indexViewModel** with the list of animals returned by the **AnimalsInitializeData** method of the **IData** parameter initialized in the constructor.

26. Return **ViewResult** using the **View** method passing it the **indexViewModel** as a parameter. 

27. Add a method for the **Details** action by using the following information:

    - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Details**
    - Parameters: One nullable integer called **id**

28. Within the **Details** action code block, add code to find a single **Animal** object from its **Id**.

29. If no animal with the right Id is found, return **NotFoundResult** using the **NotFound** method.

30. If an animal with the right Id is found, return **ViewResult** using the **View** method passing it the **Animal** object as a parameter.

31. Add the **images** existing files to the **images** folder from the following location:

    -  **Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\Images**     

32.  Add a new view to the **Index** action in the **AnimalsController** by using the following information:

     - Name: **Index**
     - Scaffold template: **Empty (without model)**
     - Use a layout page: **True**
 
33. Delete the content in the **Index.cshtml**.

34. Open the **Indexcshtml.txt** existing file and copy all the content into the **Index.cshtml** from the following location:

     - **Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\Views**

35.  Add a new view to the **Details** action in the **AnimalsController** by using the following information:

     - Name: **Details**
     - Scaffold template: **Empty (without model)**
     - Use a layout page: **True**
 
36. Delete the content in the **Details.cshtml**.

37. Open the **Detailscshtml.txt** existing file and copy the content into the **Details.cshtml** from the following location:
 
     - **Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\Views**

38. Add a link to the **_Layout.cshtml**, in the **UL** element after the last **LI** element, by using the following information

    - Start tag: **&lt;li&gt;<a**
    - Attribute: **asp-area=&quot;&quot;**
    - Attribute: **asp-controller=&quot;Animals&quot;**
    - Attribute: **asp-action=&quot;Index&quot;**
    - Content: **Animals**
    - End tag: **&lt;/a&gt;&lt;/li&gt;** 

39. In the **Startup.cs**, in the **ConfigureServices** method code block, add **IData** to the services container as Singleton.

#### Task 4: Run the application

1. Save all the changes.

2. Start Debugging the application.

3. View the **Test Page** and **Animals** pages you added.

4. In the **Animals** window, click on the **Details** link.

5. Verify that the **site.css** file is used to apply style to all the pages.

6. Close the **Microsoft Edge** window and the Visual Studio application.

>**Results**: At the end of this exercise, you will be able to build a simple MVC application in Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
