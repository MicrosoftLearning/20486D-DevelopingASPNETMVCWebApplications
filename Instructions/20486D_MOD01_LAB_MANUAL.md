# Module 1: Exploring ASP.NET Core MVC

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lab: Exploring ASP.NET Core MVC 

#### Scenario

You are working as a junior developer at Adventure Works. You have been asked by a senior developer to investigate the possibility of creating a web-based ASP.NET Core MVC application for your organization's customers, similar to the one that the senior developer has seen on the internet. Such an application will promote a community of cyclists who use Adventure Works equipment, and the community members will be able to share their experiences. This initiative is intended to increase the popularity of Adventure Works Cycles, and thereby to increase their sales. You have been asked to begin the planning of the application. You have also been asked to examine programming models available to ASP.NET Core developers. To do this, you need to create basic web applications using three different models: Razor Pages, Web API, and MVC. 

#### Objectives

After completing this lab, you will be able to:

- Describe and compare the three programming models — Razor Pages, Web API, and MVC.
- Describe the structure of each web application developed in the three programming models — Razor Pages, Web API, and MVC.
- Select an appropriate programming model for a given set of web application requirements.

#### Lab Setup

Estimated Time: **90 minutes**

### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course.
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Exploring a Razor Pages Application

#### Scenario

In this exercise, you will create a simple Razor Pages application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Razor Pages application

2. Exploring the application structure

3. Adding simple functionality

4. Running the application

#### Task 1: Creating a Razor Pages application

1. Start Visual Studio 2017 and create a new **ASP.NET Core Web Application** with following information:

    - Name: **ActorsRazorPages**
    - Location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin**
    - Solution name: **ActorsRazorPages**
    - Create directory for solution: **True**
    - Project template: **Web Application**
    - Enable docker support: **False**
    - Configure for HTTPS: **False**
    - Set the ASP.NET Core version to **2.1**

2. Start the application without debugging.

3. In the **Microsoft Edge** window, view the **Contact** page.

4. Close Microsoft Edge.

#### Task 2: Explore the application structure

1. In the **_ViewStart.cshtml** file, note that the value of **Layout** is **"_Layout"**.

2. In the **Contact.cshtml**  page, note that there are no links to **.css** files..

3.  In the **_Layout.cshtml** page, in the **HEAD** element, note that there is a link to **~/css/site.css**.

4. Open the **site.css** file.

    >**Note**: This is the CSS stylesheet file that is applied in **_Layout.cshtml**.

#### Task 3: Add simple functionality

1. Create a new **Razor Page** with the following information:
 
    - Name: **TestPage**
    - Folder: **Pages**
    - Generate PageModel class: **True**
    - Create as a partial view: **False**
    - Reference script libraries: **True**
    - Use a layout page: **True**

2. Delete the contents of the **TestPage.cshtml** page.

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

   - Folder name: **Models**

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

17. In the **IData** interface, declare a property with the following information:

    - Type: **List&lt;Actor&gt;**
    - Name: **ActorsList**
    - Access: **Read and write**

18. Declare a method with the following information:

    - Return type: **List&lt;Actor&gt;**
    - Name: **ActorsInitializeData**

19. Declare a method with the following information:

    - Return type: **Actor**
    - Name: **GetActorById**
    - Parameter:
        - Name:  **id**
        - Type: **int?**

20. Copy the **Data.cs** file to the **ActorsRazorPages** project, with the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin**
     - Target location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\ActorsRazorPages\ActorsRazorPages\Models**

21. Copy the **images** folder to the **ActorsRazorPages** project, with the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin**
     - Target location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\ActorsRazorPages\ActorsRazorPages\wwwroot**

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
     - Type: **IList&lt;Actor&gt;**
     - Access:  **Read and write**

29. In the **OnGet** method, initialize the **Actors** property by using the **ActorsInitializeData** method of the **_data.** field.

30. Delete the contents of the **Index.cshtml** page.

31. Copy the content of the **Indexcshtml.txt** text file to the **Index.cshtml** page by using the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\Pages**

32. Copy the **Details.cshtml.cs** and **Details.cshtml** files to the **ActorsRazorPages** project with the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\Pages**
     - Target location: **[Repository Root]\Allfiles\Mod01\Labfiles\01_ActorsRazorPages_begin\ActorsRazorPages\ActorsRazorPages\Pages\Actors**

33. In the **Startup** class, add a **using** statement for the following namespace:

    - **ActorsRazorPages.Models**

34. In the **ConfigureServices** method, call the **AddSingleton** method of the **services** parameter with the following information:

    - Interface: **IData**
    - Implementation: **Data**

35. In the **_Layout.cshtml** page, in the **UL** element, add an **LI** element.

36. In the new **LI** element,  add an **A** element with the following information:

    - Content: **Actors**
    - asp-page: **/Actors/Index**



#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. View the **Test Page** and **Actors** pages you have added.

    >**Note**: The browser window displays the title **Test Page** and the text **&quot;This is a Test Page&quot;**. 

    >**Note**: The browser window displays the **Index.cshtml** page under the **Actors** folder.

4. In the **Actors** window, click the **Details** link.

    >**Note**: The browser window displays the **Details.cshtml** page under the **Actors** folder.

5. Verify that the **site.css** file is used to apply styles to all the pages.

6. Close the **Microsoft Edge** window.

7. Close Microsoft Visual Studio.

>**Results**: At the end of this exercise, you will be able to build a simple Razor Pages application in Visual Studio.

### Exercise 2: Exploring a Web API Application

#### Scenario

In this exercise, you will create a simple Web API application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating a Web API  application

2. Exploring the application structure

3. Adding simple functionality

4. Running the application

#### Task 1: Creating a Web API application

1. Open Visual Studio 2017 and create a new **ASP.NET Core Web Application** with the following information:

    - Name: **CakeStoreApi**
    - Location: **[Repository Root]\Allfiles\Mod01\Labfiles\02_CakeStoreApi_begin**
    - Solution name: **CakeStoreApi**
    - Create directory for solution: **True**
    - Project template: **API**
    - Enable docker support: **False**
    - Configure for HTTPS: **False**

#### Task 2: Explore the application structure

1. In the **ValuesController** class, note that the **Get** method returns **value1** and **value2**.

2. Start the application without debugging.

3. In the **Microsoft Edge** window, view the content in the browser.

4. Close Microsoft Edge.

#### Task 3: Add simple functionality

1. Create a new folder with the following information:

   - Folder name: **Models**.

2. Create a new model with the following information:

   - Name: **CakeStore**
   - Folder: **Models**
 
3. In the the **CakeStore** model class, add a new property with the following information:

    - Scope: **public**
    - Name: **Id**
    - Type: **int**
    - Access:  **Read and write**


4. Add a new property with the following information:
 
     - Scope: **public**
     - Property name: **CakeType**
     - Data type: **string**
     - Access: **Read and write**

5. Add a new property with the following information:
 
   - Scope: **public**
   - Property name: **Quantity**
   - Data type: **int**
   - Access: **Read and write**

6. Create a new interface with the following information:

    - Name: **IData**
    - Folder: **Models**
    - Scope: **public**

7. In the **IData** interface, declare a property with the following information:

    - Type: **List&lt;CakeStore&gt;**
    - Name: **CakesList**
    - Access: **Read and write**

8. Declare a method with the following information:

    - Return type: **List&lt;CakeStore&gt;**
    - Name: **CakesInitializeData**

9. Declare a method with the following information:

    - Return type: **CakeStore**
    - Name: **GetCakeById**
    - Parameter:
        - Name:  **id**
        - Type: **int?**
 
10. Copy the **Data.cs** file to the **CakeStoreApi** project, with the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\02_CakeStoreApi_begin**
     - Target location: **[Repository Root]\Allfiles\Mod01\Labfiles\02_CakeStoreApi_begin\CakeStoreApi\CakeStoreApi\Models**

11. Create a new controller with the following information:
    - Controller name: **CakeStoreApiController**
    - Template: **API Controller - Empty**
    - Folder: **Controllers**

12. In the **CakeStoreApiController** class, add a **using** statement for the following namespace:

    - **CakeStoreApi.Models**

13. Create a new field with the following information:
 
     - Scope: **private**
     - Class: **IData**
     - Name: **_data**

14. Add a constructor with the following parameter:

     - Scope: **public**
     - Class: **CakeStoreApiController**
     - Type: **IData**
     - Name: **data**

15. In the constructor, initialize the **_data** field with the value of the **data** parameter.

16. Add a method for the **GetAll** action with the following information:

     - Scope: **public**
     - Return Type:  **ActionResult&lt;List&lt;CakeStore&gt;&gt;**
     - Name: **GetAll**

17. In the **GetAll** action code block, return the **List&lt;CakeStore&gt;** result by using the **_data.CakesInitializeData** method

    >**Note**: The **_data** field is the private object you just instantiated.

18. Above the **GetAll** action, add a **HttpGet** attribute with the following information:

     - Template : **"/api/CakeStore"**


19. Add a method for the **GetById** action with the following information:

     - Scope: **public**
     - Return Type:  **ActionResult&lt;CakeStore&gt;**
     - Name: **GetById**
     - Parameter: 
        - Type: **int?**
        - Name: **id**

20. In the **GetById** action, add a variable named *item* of type **var**, and initialize it with the value of **_data.GetCakeById(id)**.

21. Add an **IF** statement that checks whether that the value of the *item* variable is **NULL**.

22. In the **IF**  statement code block, return the **NotFoundResult** result by using the **NotFound** method.

23. After the **IF**  statement, return a new **ObjectResult** result by using the **ObjectResult** constructor. Pass the *item* variable as a parameter to the **ObjectResult** constructor.

24. Above the **GetById** action, add a **HttpGet** attribute with the following information:
     - Template: **"/api/CakeStore/{id}"**
     - Name: **GetCake**

25. In the **Startup** class, add a **using** statement for the following namespace:

      - **CakeStoreApi.Models**

26. In the **ConfigureServices** method, call the **AddSingleton** method of the **services** parameter with the following information:

    - Interface: **IData**
    - Implementation: **data**

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging, and access the following relative path:

    - Path: **/api/CakeStore**

    >**Note**: The browser displays a list of cake stores in JSON format.

3. In the **Microsoft Edge** window, access the following relative path:

    - Path: **/api/CakeStore/1**

    >**Note**: The browser displays the first cake store in the JSON format.

4. Close Microsoft Edge.

    >**Results**: At the end of this exercise, you will be able to build a simple Web API application in Visual Studio.

5. Close Microsoft Visual Studio.

### Exercise 3: Exploring an MVC Application

#### Scenario

In this exercise, you will create a simple MVC application, and explore its structure.

The main tasks for this exercise are as follows:

1. Creating an MVC  application

2. Explore the application structure

3. Add simple functionality

4. Run the application

#### Task 1: Creating an MVC application

1. Open Visual Studio 2017 and create a new **ASP.NET Core Web Application** with following information:

    - Name: **AnimalsMvc**
    - Location: **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin**
    - Solution name: **AnimalsMvc**
    - Create directory for solution: **True**
    - Project template: **Web Application (Model-View-Controller)**
    - Enable docker support: **False**
    - Configure for HTTPS: **False**

2. Start the application without debugging.

3. In the **Microsoft Edge** window, view the **Contact** page.

4. Close Microsoft Edge.

#### Task 2: Explore the application structure

1. In the **_ViewStart.cshtml** file, note that the value of **Layout** is **"_Layout"**.

2. In the **Contact.cshtml**  page, note that there are no links to the **.css** files.

3.  In the **_Layout.cshtml** page, in the **HEAD** element, note that there is a link to **~/css/site.css**.

4. Open the **site.css** style sheet.

    >**Note**: This is the CSS **style sheet** file that is applied in the **_Layout.cshtml**.


#### Task 3: Add simple functionality

1. In the **HomeController** class, add a method for the **TestPage** action with the following information:

   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **TestPage**

2. In the **TestPage**  action, return the **ViewResult** result by using the **View** method. 

3. Right-click the **TestPage** action name, and then click **Add View**.

4. Create a new view by using the **Add MVC View** dialog box, with the following information:

    - Name: **TestPage**
    - Scaffold template: **Empty (without model)**  
    - Use a layout page: **True**
    - Create as Partial View: **False**
    - Reference script libraries: **False**

5. In the **TestPage.cshtml** page, change the **H2** element content with the following information:

    - Content: **This is a Test Page**

6. In the **_Layout.cshtml** page, in the **UL** element, add an **LI** element.

7. In the new **LI** element,  add an **A** element with the following information:

    - Content: **Test Page**
    - asp-area: **""**
    - asp-controller: **"Home"**
    - asp-action: **"TestPage"**

8. Create a new model with the following information:

    - Name: **Animal**
    - Folder: **Models**

9. In the **Animal** model class, add a new property with the following information:

    - Scope: **public**
    - Name: **id**
    - Type: **int**
    - Access:  **Read and write**

10. Add a new property with the following information:

    - Scope: **public**
    - Property name: **Name**
    - Data type: **string**
    - Access: **Read and write**

11. Add a new property with the following information:

    - Scope: **public**
    - Property name: **ImageName**
    - Data type: **string**
    - Access: **Read and write**

12. Add a new property with the following information:

    - Scope: **public**
    - Property name: **UniqueInformation**
    - Data type: **string**
    - Access: **Read and write**

13. Add a new property with the following information:

    - Scope: **public**
    - Property name: **Category**
    - Data type: **string**
    - Access: **Read and write**

14. Create a new interface with the following information:

    - Name: **IData**
    - Folder: **Models**
    - Scope: **public**

15. In the **IData** interface, declare a property with the following information:

    - Type: **List&lt;Animal&gt;**
    - Name: **AnimalsList**

16. Declare a method with the following information:

    - Return type: **List&lt;Animal&gt;**
    - Name: **AnimalsInitializeData**

17. Declare a method with the following information:

    - Return type: **Animal**
    - Name: **GetAnimalById**
    - Parameter:
        - Name:  **id**
        - Type: **int?**

18. Copy the **Data.cs** file to the **AnimalMvc** project, with the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin**
     - Target location: **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\AnimalMvc\AnimalMvc\Models**

19. Create a new model with the following information:

     - Name: **IndexViewModel**
     - Folder: **Models**


20. In the **IndexViewModel** model class, add a new property with the following information:

    - Scope: **public**
    - Property name: **Animals**
    - Data type: **List&lt;Animal&gt;**
    - Access: **Read and write**

21. Create a new controller with the following information:
     - Controller name: **AnimalsController**
     - Template: **MVC Controller - Empty**
     - Folder: **Controllers**

22. In the **AnimalsController** class, add a **using** statement for the following namespace:

      - **AnimalsMvc.Models**

23. Create a new field with the following information:

    - Scope: **private**
    - Class: **IData**
    - Name: **_tempData**

24. Add a constructor with the following parameter:

     - Scope: **public**
     - ClassName: **AnimalsController**
     - Type: **IData**
     - Name: **tempData**

25. In the constructor, initialize the **_tempData** field with the value of the **tempData** parameter.

26.  In the **Index** action code block, add a variable named *animals* of type  **List&lt;Animal&gt;**. 

27. Initialize the *animals* variable  with the value of **_tempData.AnimalsInitializeData()**.

28. Add a variable named *indexViewModel* of type **IndexViewModel**.

29. Initialize the  *indexViewModel* variable by using a **IndexViewModel** parameterless constructor.

30. Initialize  the  **Animals** property of the *indexViewModel* variable with the value of *animals* variable.

31. Return the **ViewResult** result by using the **View** method. Pass **indexViewModel** as a parameter to the **View** method.

32. Add a method for the **Details** action with the following information:
    - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Details**
    - Parameter:
        - Type: **int?**
        - Name: **id**

33.  In the **Details** action code block, add a variable named *model* of type  **var**, and initialize it with the value of **_tempData.GetAnimalById(id)**.

34. Add an **IF** statement that checks that the value of the *model* variable is **NULL**.

35. In the **IF**  statement code block, return the **NotFoundResult** result by using the **NotFound** method.

36. After the **IF**  statement, return a new **ViewResult** result by using the **View** method. Pass the *model* variable as a parameter to the **View** method.

37. Copy the **images** folder contents to the **AnimalMvc** project, with the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\Images**
     - Target location: **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\AnimalMvc\AnimalMvc\wwwroot\Images**

38. In the **AnimalsController** class, right-click the **Index** action name, and then click **Add View**.

39. Create a new view by using the **Add MVC View** dialog box, with the following information:

    - Name: **Index**
    - Scaffold template: **Empty (without model)**  
    - Use a layout page: **True**
    - Create as Partial View: **False**
    - Reference script libraries: **False**

40. Delete the contents of the **Index.cshtml** view.

41. Copy the content of the **Indexcshtml.txt** text file to the **Index.cshtml** view  by using the following information:

     - **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\Views**

42. In the **AnimalsController** class, right-click the **Details** action name, and then click **Add View**.

43. Create a new view by using the **Add MVC View** dialog box, with the following information:

    - Name: **Details**
    - Scaffold template: **Empty (without model)**  
    - Use a layout page: **True**
    - Create as Partial View: **False**
    - Reference script libraries: **False**

44. Delete the contents of the **Details.cshtml** view.

45. Copy the contents of the **Detailscshtml.txt** text file to the **Details.cshtml** view by using the following information:

     - Source location: **[Repository Root]\Allfiles\Mod01\Labfiles\03_AnimalMvc_begin\Views**

46. In the **_Layout.cshtml** page, in the **UL** element, add an **LI** element.

47. In the new **LI** element,  add an **A** element with the following information:

    - Content: **Animals**
    - asp-area: **""**
    - asp-controller: **"Animals"**
    - asp-action: **"Index"**

48. In the **Startup** class, add a **using** statement for the following namespace:

      - **AnimalsMvc.Models**

49. In the **ConfigureServices** method, call the **AddSingleton** method of **services** parameter with the following information:

    - Interface: **IData**
    - Implementation: **data**


#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. View the **Test Page** and **Animals** pages you have added.

    >**Note**: The browser window displays the text **&quot;This is a Test Page&quot;**.

    >**Note**: The browser window displays the **Index.cshtml** page, under the **Animals** folder.

4. In the **Animals** window, click the **Details** link.

    >**Note**: The browser window displays the **Details.cshtml** page, under the **Animals** folder.

5. Verify that the **site.css** file is used to apply styles to all the pages.

6. Close the **Microsoft Edge** window.

7. Close Microsoft Visual Studio.

>**Results**: At the end of this exercise, you will be able to build a simple MVC application in Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
