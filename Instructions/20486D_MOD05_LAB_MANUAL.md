# Module 5: Developing Views

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lab: Developing Views 

#### Scenario
To construct the user interface of a city's web application, your development team decided to add views. You have been asked to create the views to render a response to a browser.

#### Objectives

After completing this lab, you will be able to:

- Add an MVC view to a web application.
- Use Razor to differentiate server-side code from HTML code.
- Write HTML code and tag helpers in a view.
- Add partial views and view components.

#### Lab Setup

Estimated Time: **60 minutes**


### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

## Exercise 1: Adding Views to an MVC Application

#### Scenario

To construct the user interface of a web application, views should be added to the web application. In this exercise you will add two views to the web application: **Index** and **Details**. The **Index** view will show a list of cities, and the **Details** view will show the details of a city.

The main tasks for this exercise are as follows:

1.	Add a view to show all the cities

2.	Run the application

3.	Add a view to show data for a city

4.	Add a Back link to a view

5.	Add a city name as a link to each city

6.	Run the application

####	Task 1: Add a view to show all the cities

1. From **[Repository Root]\Allfiles\Mod05\Labfiles\01_CitiesWebsite_begin**, open the **CitiesWebsite.sln**. 

    >**Note**: If a **Security Warning for RazorSyntaxExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.
    
2. In the **CityProvider** constructor, initialize the **_cities** field by using the **CityInitializer** method.

3. In the **City** constructor, initialize the **Country** property with the value of the **country** parameter.

4. Initialize the **Name** property with the value of the **cityName** parameter.

5. Initialize the **TimeZone** property with the value of the **timeZone** parameter.

6. Initialize the **Population** property with the value of the **population** parameter.

7. In **CityPopulation** constructor, initialize the **Year** property with the value of the **year** parameter.

8. Initialize the **City** property with the value of the **city** parameter.

9. Initialize the **Urban** property with the value of the **urban** parameter.

10. Initialize the **Metro** property with the value of the **metro** parameter.

11. In the **CityController** class, add a **using** statement for the following namespace:
    - **CitiesWebsite.Services**

12. Create a new field with the following information:
    - Scope: **private**
    - Type: **ICityProvider**
    - Name: **_cities**

13. Change the **CityController** constructor signature to accept the following parameter:
    - Type: **ICityProvider**
    - Name: **cities**

14. In the constructor code block, initialize the **_cities** field with the value of the **cities** parameter.

15. In the **ShowCities** action code block, above the return statement, save the following key and value in the **ViewBag** property:
    - Key: **Cities**
    - Value: **_cities**

16. Right-click the **ShowCities** action name, and then click **Add View**.

17. Create a new **View** by using the **Add MVC View** dialog box, with the following information:

    - View Name: **ShowCities**
    - Template: **Empty (without model)**
    - Create as Partial View: **False**
    - Use a layout page: **False**

18. After the **TITLE** element, add a **LINK** element with the following information:
    - Type:  **text/css**
    - Rel:  **stylesheet**
    - Href:  **~/css/style.css**

19. In the **BODY** element, add a **H1** element with the following information:
    - Content:  **Select City**  

20. Create a **FOREACH** statement block, with the following information:
    - Variable Type: **var**
    - Variable Name: **item**
    - Collection: **ViewBag.Cities**

21.  In the  **FOREACH** statement block, add a **P** element with the following information:

     - Content:  **@item.Key** 


####	Task 2: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. View the page you have added.
    >**Note**: The browser displays a **Select City** title and a list of cities below it: **Madrid**, **London**, and **Paris**.

4. Close **Microsoft Edge**.

####	Task 3: Add a view to show data for a city

1. In the **CityController** class, change the **ShowDataForCity** action signature to accept the following parameter:
    - Type: **string**
    - Name: **cityName**

2. In the **ShowDataForCity** action code block, above the return statement, save the following key and value in the **ViewBag** property:
    - Key: **City**
    - Value: **_cities[cityName]**

3. Right-click the **ShowDataForCity** action name, and then click **Add View**.

4. Create a new view by using the **Add MVC View** dialog box, with the following information:

   - View Name: **ShowDataForCity**
   - Template: **Empty (without model)**
   - Create as Partial View: **False**
   - Use a layout page: **False**

5. In the **ShowDataForCity** view, after the **TITLE** element, add a **LINK** element with the following information:
    - Type:  **text/css**
    - Rel:  **stylesheet**
    - Href:  **~/css/style.css**

6. In the **BODY** element, create a **DIV** element.

7. In the **DIV** element, add a **H2** element with the following information:
    - Content:  **@ViewBag.City.Name** 

8. Add a **P** element with the following information:
    - Content:  **Country:  @ViewBag.City.Country** 

9. Add a **P** element with the following information:
    - Content:  **Time zone: @ViewBag.City.TimeZone** 

10. Add a **SPAN** element.

11. In the **SPAN** element, add an **IMG** element with the following information:
    - src:  **@Url.Action("GetImage", new { cityName = ViewBag.City.Name })** 

12. In the **CityController** class, edit the code in the **GetImage** action by removing the code that returns the **ContentResult** result by using the **Content** method.

13. Return the **FileResult** result by using the **File** method. Pass **"$@"images&bsol;{cityName}.jpg"** and **"image/jpeg"** as parameters to the **File** method.

####	Task 4: Add links to the views using tag helpers

1. Create a new **_ViewImports.cshtml** file with the following information:

    - Name: **_ViewImports**
    - Folder: **Views**

2. In the  **_ViewImports**  file, add a **@addTagHelper** directive with the following information:

    - Tag Helpers: <strong>*</strong>
    - Assembly:  **Microsoft.AspNetCore.Mvc.TagHelpers**

3. In the **ShowDataForCity** view, after the **SPAN** element, add an **A** element with the following information:
    - asp-action: **ShowCities**
    - Content: **Back**

4. In the **ShowCities** view, remove the **P** element with its content.

5. In the  **FOREACH** statement block, add a **H2** element.

6. In the  **H2** element, add an **A** element with the following information:

    - Content: **@item.Key**
    - asp-action: **ShowDataForCity**
    - asp-route-cityname: **@item.Key**


####	Task 5: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In Microsoft Edge window, click **London**.

    > **Note**: The browser displays the city's name, details, mini map, and a **Back** link.

4. In Microsoft Edge, click **Back**.

5. Close Microsoft Edge.

>**Result**: At the end of this exercise, you will be able to add views to an MVC application, pass data from a controller to a view by using **ViewBag**, and navigate between pages by using helpers.

##	Exercise 2: Adding a Partial View

#### Scenario

You have been asked to display the population of each city. To do this, you have been asked to add a partial view. In this exercise, you will create a partial view and embed it in the **ShowDataForCity** view.

The main tasks for this exercise are as follows:

1.	Add a partial view

2.	Use the partial view in the **ShowDataForCity** view

3.	Run the application

####	Task 1: Add a partial view

1. Create a new folder with the following information:

    - Folder name: **Shared**
    - Parent folder: **Views**

2. Create a new **partial view** by using the **Add MVC View** dialog box, with the following information:

   - Folder: **Shared**
   - View Name: **_CityPopulation**
   - Template: **Empty (without model)**
   - Create as Partial View: **True**
   - Use a layout page: **False**

3. In the **_CityPopulation** partial view, delete all the content.

4. Add a **@inject** directive with the following information:
    - Type: **CitiesWebsite.Services.ICityFormatter**
    - Name: **cityFormatter**

5. Add a new variable with the following information:
    - Type: **CitiesWebsite.Models.CityPopulation**
    - Name: **population**
    - Value: **ViewBag.City.Population**

6. Add a **H3** element with the following information:
    - Content:  **City Population (@population.Year)**

7. After the **H3** element, add a **P** element with the following information:
    - Content:  **City: @cityFormatter.GetFormattedPopulation(@population.City)**

8. After the last **P** element, add another **P** element with the following information:
    - Content:  **Urban: @cityFormatter.GetFormattedPopulation(@population.Urban)**

9. After the last **P** element, add another **P** element with the following information:
    - Content:  **Metro: @cityFormatter.GetFormattedPopulation(@population.Metro)**

####	Task 2: Use the partial view in the ShowDataForCity view

In the **ShowDataForCity** view, after the **SPAN** element, render a partial view with the following information:  
    - Helper: **Html.PartialAsync**
    - Partial View Name: **_CityPopulation**

####	Task 3: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In Microsoft Edge, click **Madrid**.

    > **Note**: The browser displays the city's name, details, mini map, and a **Back** link.

4. Close Microsoft Edge.

>**Result**: At the end of this exercise, you will be able to write and use partial views, and use services inside a view by using the **@Inject** directive.

##	Exercise 3: Adding a View Component

#### Scenario

Currently, in the **ShowCities** view, for each city, you show a link with the name of the city. You have been asked to show for each city in the **ShowCities** view, the country to which the city belongs and a mini map of the city. To implement this you have been asked to use a view component. In this exercise, you will create a view component and embed it in the **ShowCities** view.
 
The main tasks for this exercise are as follows:

1.	Add a view component class

2.	Add a view component view

3.	Use the view component

4.	Run the application

####	Task 1: Add a view component class

1. In the  **CitiesWebsite** project, create a new top-level folder, and name it **ViewComponents**.

2. Create a new class with the following information:

    - Name: **CityViewComponent**
    - Folder: **ViewComponents**

3. In the **CityViewComponent** class, add a **USING** statement for the following namespaces:

    - **Microsoft.AspNetCore.Mvc**
    - **CitiesWebsite.Services**
    - **CitiesWebsite.Models**

4. Change the **CityViewComponent** class to inherit from the **ViewComponent** class.

5. Create a new field with the following information:
 
    - Scope: **private**
    - Type: **ICityProvider**
    - Name: **_cities**

6. Add a constructor with the following parameters: 

    - Type: **ICityProvider**
    - Name: **cities**

7. In the constructor, initialize the **_cities** field with the value of the **cities** parameter.

8. Add a method with the following information:

    - Scope: **public**
    - Keyword: **async**
    - Return Type: **Task&lt;IViewComponentResult&gt;**
    - Name: **InvokeAsync**
    - Parameter:
        - Type: **string**
        - Name: **cityName**

9. Add a method with the following information:

    - Scope: **private**
    - Return Type: **Task&lt;City&gt;**
    - Name: **GetCity**
    - Parameter:
        - Type: **string**
        - Name: **cityName**

10. In the **GetCity** method code block, return **Task&lt;City&gt;** by using the  **Task.FromResult&lt;City&gt;** method. Pass **_cities[cityName]** as a parameter to the **Task.FromResult&lt;City&gt;** method.
 
11. In the **InvokeAsync** method code block, save the following key and value in the **ViewBag** property:

    - Key: **CurrentCity**
    - Value: **await GetCity(cityName)**
 
12. Return the **ViewComponentResult** result by using the **View** method. Pass **"SelectCity"** as a parameter to the **View** method.

####	Task 2: Add a view component view

1. Create a new folder with the following information:

    - Folder name: **Components**
    - Parent folder: **Shared**

2. Create a new folder with the following information:

    - Folder name: **City**
    - Parent folder: **Components**

3. Create a new **partial view** by using the **Add MVC View** dialog box, with the following information:

   - Folder: **City**
   - View Name: **SelectCity**
   - Template: **Empty (without model)**
   - Create as Partial View: **True**
   - Use a layout page: **False**

4. In the **SelectCity** partial view, delete all the content.

5. Add a **DIV** element.

6. In the **DIV** element, add an **H2** element.

7. In the **H2** element, add an **A** element with the following information:
    - Content: **@ViewBag.CurrentCity.Name (Capital of @ViewBag.CurrentCity.Country)**
    - asp-action: **ShowDataForCity**
    - asp-route-cityname: **@ViewBag.CurrentCity.Name**

8. After the **H2** element, add an **IMG** element with the following information:
    - Attribute: **src**
    - Value: **@Url.Action("GetImage", new { cityName = ViewBag.CurrentCity.Name })**

####	Task 3: Use the view component

1. In the **ShowCities** view, delete the content of the **FOREACH** statment and add the following: **@await Component.InvokeAsync("City", item.Key)**

####	Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

    > **Note**: The browser displays a list of cities, each with a header link and a mini map image of the region.

3.  In the **Microsoft Edge** window, click the **Madrid (Capital of Spain)** link.

4. Close Microsoft Edge.

5. Close Visual Studio.

>**Result**: At the end of this exercise, you will be able to create view components, and embed them in a view.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
