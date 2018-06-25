# Module 5: Developing Views

# Lab: Developing Views 

#### Scenario
To construct the user interface of the cities details application, your development team decided to add views. You have been asked to create views to render a response to a browser.

#### Objectives

After completing this lab, you will be able to:

- Add a MVC view to a web application.
- Use Razor to differentiate server-side code from HTML.
- Write HTML and tag helpers in a view.
- Add partial views and view components.

#### Lab Setup

Estimated Time: **60 minutes**


### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod05\Labfiles\01_CitiesDetails_begin**, and then double-click **CitiesDetails.sln**.

## Exercise 1: Adding Views to an MVC Application

#### Scenario

In order to create the site, index and detail pages must be created. The index page will show a list of cities, and the details page will show the details on each one of the cities.

The main tasks for this exercise are as follows:

1.	Add a view to show a list of all the cities, as retrieved by the ShowCities action.

2.	Run the application.

3.	Add a view to show data of a city, as returned by the ShowDataForCity action.

4.	Add a back link to the ShowDataForCity view. Pressing the link will redirect to the ShowCities action.

5.	Add a “Show data” link next to each city in the ShowCities view. Pressing the link will trigger a redirect to the ShowDataForCity action.

6.	Run the application.

####	Task 1: Add a view to show a list of all the cities, as retrieved by the ShowCities action.

1. From **Allfiles\Mod05\Labfiles\01_CitiesDetails_begin** open the **CitiesDetails.sln**. 

2. In the **CityProvider** constructor, initialize the **_cities** field using the  **CityInitializer** method.

3. In the **CityDetails** constructor, initialize the **Country** property with the value of the **country** parameter.

4. Initialize the **Name** property with the value of the **cityName** parameter.

5. Initialize the **TimeZone** property with the value of the **timeZone** parameter.

6. Initialize the **CityPopulation** property with the value of the **cityPopulation** parameter.

7. In **CityPopulation** constructor, initialize the **Year** property with the value of the **year** parameter.

8. Initialize the **City** property with the value of the **city** parameter.

9. Initialize the **Urban** property with the value of the **urban** parameter.

10. Initialize the **Metro** property with the value of the **metro** parameter.

11. In the **CityController** class, add **using** statement for the following namespace:
    - **CitiesDetails.Services**

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

16. Right-click on the **ShowCities** action name, and then click **Add View**.

17. Create a new view using the **Add MVC View** dialog box, with the following information:

    - View Name: **ShowCities**
    - Template: **Empty (without model)**
    - Create as Partial View: **False**
    - Use a layout page: **False**
    - Reference script libraries: **False**

    > **Note**: In the Add MVC View dialog box, the "Reference script libraries" check box can be unchecked by setting the template to **Edit** and then setting back the template to **Empty**(without model).

18. At the beggining of **ShowCities** view, add a **USING** statement for the following namespace:

    - **CitiesDetails.Services**

19. After the **TITLE** element, add a **LINK** element with the following information:
    - Type:  **text/css**
    - Rel:  **stylesheet**
    - Href:  **~/css/style.css**

20. In the **BODY** element, add a **H1** element with the following information:
    - Content:  **Select City**  

21. Create a **FOREACH** statement block, with the following information:
    - Variable Type: **var**
    - Variable Name: **item**
    - Collection: **ViewBag.Cities**

22.  In the  **FOREACH** statement block, add a **P** element with the following information:

     - Content:  **@item.Key**  
    
     > **Note**: The key of the  **CityProvider** item contains the city name.


####	Task 2: Run the application.

1. Save all the changes.

2. Start debugging the application.

3. View the page you have added.

     > **Note**: The browser displays a list of city names .

4. Close **Microsoft Edge**.

5. Stop debugging.

####	Task 3: Add a view to show data of a city, as returned by the ShowDataForCity action.

1. In the **CityController** class, change the **ShowDataForCity** action signature to accept the following parameter:
    - Type: **string**
    - Name: **cityName**

2. In the **ShowDataForCity** action code block, above the return statement, save the following key and value in the **ViewBag** property:
    - Key: **City**
    - Value: **_cities[cityName]**

3. Right-click on the **ShowDataForCity** action name, and then click **Add View**.

4. Create a new view using the **Add MVC View** dialog box, with the following information:

   - View Name: **ShowDataForCity**
   - Template: **Empty (without model)**
   - Create as Partial View: **False**
   - Use a layout page: **False**
   - Reference script libraries: **False**

    > **Note**: In the Add MVC View dialog box, the Reference script libraries check box can be unchecked by setting the template to **Edit** and then setting back the template to **Empty**(without model).   


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

11. In the **SPAN** element, add a **IMG** element with the following information:
    - Source:  **@Url.Action("GetImage", new {cityName = ViewBag.City.Name })** 

12. In the **CityController** class, edit the code in the **GetImage** action by removing the code which returns the **ContentResult** result using the **Content** method.

13. Return the **FileResult** result using the **File** method. Pass **"$@"images\{cityName}.jpg"** and **"image/jpeg"** as parameters to the **File** method.

####	Task 4: Add a back link to the ShowDataForCity view. Pressing the link will redirect to the ShowCities action.

1. In the **ShowDataForCity** view, after the **SPAN** add a **BR** element.

2. After the **BR** element, add an **A** element with the following information:
    - asp-action: **ShowCities**
    - Content: **Back**

3. Create a new **_ViewImports.cshtml** file with the following information:

    - Name: **_ViewImports**
    - Folder: **Views**

4. In the  **_ViewImports**  file, add a **@addTagHelper** directive with the following information:

    - Tag Helpers: <strong>*</strong>
    - Assembly:  **Microsoft.AspNetCore.Mvc.TagHelpers**


####	Task 5: Add a “Show data” link next to each city in the ShowCities view. Pressing the link will trigger a redirect to the ShowDataForCity action.

1. In the **ShowCities** view, remove the **P** element with its content.

2. In the  **FOREACH** statement block, add a **H2**.

3. In the  **H2** element, add an **A** with the following information:

    - Content: **@item.Key**
    - asp-action: **ShowDataForCity**
    - asp-route-cityname: **@item.Key**
  
    > **Note**: The key of the  **CityProvider** item contains the city name.


####	Task 6: Run the application.

1. Save all the changes.

2. Start debugging the application.

    > **Note**: The browser displays a list of city names, each name is a link to the city's details page.

3. In the **Microsoft Edge** window, click on the **London** link.

    > **Note**: The browser displays the city's name, details, mini map and a **Back** link.

4. In the **Microsoft Edge** window, click on the **Back** link.
    > **Note**: The browser displays the previous page.

5. Close **Microsoft Edge**.

6. Stop debugging.


##	Exercise 2: Adding a partial view

#### Scenario

The population details of the city are quite big and should be grouped as a subgroup in the details page.

The main tasks for this exercise are as follows:

1.	Add a partial view.

2.	Use the partial view in the **ShowDataForCity** view.

3.	Run the application.

####	Task 1: Add a partial view.

1. Create a new folder with the following information:

    - Folder name: **Shared**
    - Parent folder: **Views**

2. Create a new **partial view** using the **Add MVC View** dialog box, with the following information:

   - Folder: **Shared**
   - View Name: **_CityPopulation**
   - Template: **Empty (without model)**
   - Create as Partial View: **True**
   - Use a layout page: **False**
   - Reference script libraries: **False**

3. In the **_CityPopulation** partial view, delete all the content.

4. Add a **@inject** directive with the following information:
    - Type: **CitiesDetails.Services.ICityFormatter**
    - Name: **cityFormatter**

5. Add a new variable with the following information:
    - Type: **CitiesDetails.Services.CityPopulation**
    - Name: **population**
    - Value: **ViewBag.City.CityPopulation**

6. Add a **P** element.

7. In the **P** element, add a **H3** element with the following information:
    - Content:  **City Population(@population.Year)** .

8. After the **P** element, add another **P** element with the following information:
    - Content:  **City: @cityFormatter.GetFormattedPopulation(@population.City)** .

9. After the last **P** element, add another **P** element with the following information:
    - Content:  **Urban: @cityFormatter.GetFormattedPopulation(@population.Urban)** .

10. After the last **P** element, add another **P** element with the following information:
    - Content:  **Metro: @cityFormatter.GetFormattedPopulation(@population.Metro)** .

####	Task 2: Use the partial view in the ShowDataForCity view.

1. In the **ShowDataForCity** view, after the **SPAN** element, render a **partial view** with the following information:  
    - Helper: **Html.Partial**
    - Partial View Name: **_CityPopulation**   


####	Task 3: Run the application.

1. Save all the changes.

2. Start debugging the application.

    > **Note**: The browser displays a list of city names, each name is a link to the city's details page.

3. In the **Microsoft Edge** window, click on the **Madrid** link.

    > **Note**: The browser displays the city details with its population region.

4. Close **Microsoft Edge**.

5. Stop debugging.


##	Exercise 3: Adding a view component

#### Scenario

The **ShowCities** page shows a simple list of links to the **CityDetails** page. We will use **ViewCoponents** to show more details on each city in the **ShowCities** page.

The main tasks for this exercise are as follows:

1.	Add a view component class.

2.	Add a view component view.

3.	Use the view component.

4.	Run the application.

####	Task 1: Add a view component class.

1. In the  **CitiesDetails** project, create a new top-level folder, and name it **ViewComponents**.

2. Create a new class with the following information:

    - Name: **CityViewComponent**
    - Folder: **ViewComponents**

3. In the **CityViewComponent** class, add **using** statement for the following namespaces:

    - **Microsoft.AspNetCore.Mvc**

4. Change the **CityViewComponent** class to inherit from the **ViewComponent** class.

5. Add a method with the following information:

    - Scope: **public**
    - Return Type: **IViewComponentResult**
    - Name: **Invoke**
    - Parameter:
        - Type: **string**
        - Name: **cityName**

6. In the **Invoke** method code block, save the following key and value in the **ViewBag** property:
    - Key: **CurrentCityName**
    - Value: **cityName**

7. Return the **ViewComponentResult** result using the **View** method. Pass **"SelectCity"** as a parameter to the View method.


####	Task 2: Add a view component view.

1. Create a new folder with the following information:

    - Folder name: **Components**
    - Parent folder: **Shared**

2. Create a new folder with the following information:

    - Folder name: **City**
    - Parent folder: **Components**

3. Create a new **partial view** using the **Add MVC View** dialog box, with the following information:

   - Folder: **City**
   - View Name: **SelectCity**
   - Template: **Empty (without model)**
   - Create as Partial View: **True**
   - Use a layout page: **False**
   - Reference script libraries: **False**

4. In the **SelectCity** partial view, delete all the content.

5. Add a **DIV** element.

6. In the **DIV** element, add a **H2** element 

7. In the **H2** element, add a **A** element with the following information:
    - Content: **@ViewBag.CurrentCityName**
    - asp-action: **ShowDataForCity**
    - asp-route-cityname: **@ViewBag.CurrentCityName**

8. After the **H2** element, add an **IMG** element with the following information:
    - Attribute: **src**
    - Value: **@Url.Action("GetImage", new {cityName = ViewBag.CurrentCityName })**

####	Task 3: Use the view component.

1. In the **ShowCities** view, delete the content of the **FOREACH** statment and add the following: **@await Component.InvokeAsync("City", item.Key)**

    > **Note**: The key of the  **CityProvider** item contains the city name.

####	Task 4: Run the application.

1. Save all the changes.

2. Start debugging the application.

    > **Note**: The browser displays a list of cities, each has a header link and mini map image of the region.

3.  In the **Microsoft Edge** window, click the **Madrid** link.
    > **Note**: The browser displays the city details.

4. Close **Microsoft Edge**.

5. Stop debugging.
