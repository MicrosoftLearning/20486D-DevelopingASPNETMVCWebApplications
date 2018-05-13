# Module 5: Developing Views

# Lab: Developing Views 

#### Scenario
To construct the user interface of the cities details application, your development team decided to add views. You have been asked to create the views to render a response to a browser.

#### Objectives

After completing this lab, you will be able to:

- Add an MVC view to a web application.
- Use Razor to differentiate server-side code from HTML.
- Write HTML and tag helpers in a view.
- Add partial views and view components.

#### Lab Setup

Estimated Time: **60 minutes**

## Exercise 1: Working with Static Files

#### Scenario

In order to create the site, an index and a detail pages must be created. The index page will show a list of cities, and the details page will show the details on each one of the cities.

The main tasks for this exercise are as follows:

1.	Add a view to show a list of all the cities, as retrieved by the ShowCities action.

2.	Run the application.

3.	Add a view to show data for a city, as returned by the ShowDataForCity action.

4.	Add a Back link to the ShowDataForCity view. Pressing the link will redirect to the ShowCities action.

5.	Add a “Show data” link next to each city in the ShowCities view. Pressing the link will trigger a redirect to the ShowDataForCity action.

6.	Run the application.

####	Task 1: Add a view to show a list of all the cities, as retrieved by the ShowCities action.

1. Open the PhotoSharingApplication.sln from the following location: **Allfiles\Mod05\Labfiles\01_CitiesDetails_begin**.

2. In the **CityProvider** service constructor, initialize the **_cities** variable with the **CityInitializer** method results.

3. In **CityDetails** class, assign the class members of the **CityDetails** class with the values received from the constructor.

4. In **CityPopulation** class, assign the class members of the **CityPopulation** class with the values received from the constructor.

5. Add a new view to the application by using the following information:

    - Parent folder: **/Views/City**
    - View name: **ShowCities**
    
    Clear the **Use a layout or master page** check box.

6. In the **ShowCities** view, Add **using** statements to the model for the following namespaces:

    - **CitiesDetails.Services**

7. To link the new style sheet, add a  **link**  element to the  **ShowCities.cshtml**  file by using the following information:

    - Type:  **text/css**
    - Relation:  **stylesheet**
    - Href:  **~/css/StyleSheet.css**

8. Create a new **foreach** code block that loops through all the cities in the **CitiesProvider** indexer list.
    
9. In the **foreach** code block, add a **P** element to display the city name property from the model.
    > **Note**: The city name is each item's key in the dictionary.

####	Task 2: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.
    > **Note**: The browser displays a list of the city names.

2. Close the **Microsoft Edge** window.

3. Stop debugging.

####	Task 3: Add a view to show data for a city, as returned by the ShowDataForCity action.

1. In the **CityController** class, Add **using** statements to the model for the following namespaces:

    - **CitiesDetails.Services;**

2. Inside the **CityController** class, create a new class member named **_cities**.

3. Inject the **ICityProvider** service into the **CityController** constructor, and save it into the **_cities** class member.

4. Inside the **CityController** class, add a **string** parameter named **city** for the **ShowDataForCity** method. 

5. Use the **city** parameter as index of the **_cities** class member, and save the value to **ViewBag.City**.

6. Add a new view to the application by using the following information:

    - Parent folder: **/Views/City**
    - View name: **ShowDataForCity.cshtml**

    Clear the **Use a layout or master page** check box.

7. Inject the **ICityProvider** into the **ShowDataForCity** view.

8. To link the new style sheet, add a  **link**  element to the  **ShowDataForCity.cshtml**  file by using the following information:

    - Type:  **text/css**
    - Relation:  **stylesheet**
    - Href:  **~/css/StyleSheet.css**

9. In the **BODY** element, Create a **DIV** element.

10. In the **DIV** element, Add a **H2** element to display the **_city** property from the **ViewBag.City**.

11. In the **DIV** element, below the **H2** element, add a **P** element, set its content to title of your choice, followed by the **country** property from the **ViewBag.City**.

12. In the **DIV** element, below the **P** element, add another **P** element, set its content to title of your choice, followed by the **timezone** property from the **ViewBag.City**.

13. In the **DIV** element, below the last **P** element, add a **SPAN** element.

14. Within the **SPAN** element, render an **IMG** tag.

15. In the **IMG** element, add a **SRC** property using the following information:
    - Html helper: Url.Action
    - Target action: **GetImage**
    - Helper parameter: **_city** property from the **ViewBag.City**
     
16. In the **CityController** class, in the **GetImage** action replace the method's return value to **File** using the following information:
    - File path: images\
    - File name: **cityName** parameter value
    - File extension: jpg
    - Content type: image/jpeg

####	Task 4: Add a Back link to the ShowDataForCity view. Pressing the link will redirect to the ShowCities action.

1. In the **ShowDataForCity** view, below the **SPAN** add a **BR** element.

2. Below the **BR** element add an **A** element using the following information:
    - Tag helper: **asp-action**
    - Target page: **ShowCities**

3. Add an **MVC View Imports Page** with the name of **_ViewImports**.

4. In the  **_ViewImports**  file, Add  **addTagHelper**  statements to the file for the following namespaces:

    - **Namespace: Microsoft.AspNetCore.Mvc.TagHelpers**

####	Task 5: Add a “Show data” link next to each city in the ShowCities view. Pressing the link will trigger a redirect to the ShowDataForCity action.

1. In the **ShowCities** view, replace the city name text with an **H2** element.

2.  In the **H2** element, add a **A** element link using the following information:
    - Content:  City name
    - Tag helper:  **asp-action**
    - Target page: **ShowDataForCity**
    - Parameter name: **City**
    - Parameter value: City name
        
    The **@item.Key** contains the city name.

####	Task 6: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.
    > **Note**: The browser displays a list of the city names is shown, each name is a link to its city's details page.

2.  In the **Microsoft Edge** window, click the **London** link.
    > **Note**: The browser displays the city's name, details and mini map and a **Back** link.

3. In the **Microsoft Edge** window, click the **Back** link.
    > **Note**: The browser displays the previous page.

4. Close the **Microsoft Edge** window.

5. Stop debugging.

##	Exercise 2: Adding a partial view

#### Scenario

The population details of the city is quite big and should be grouped as a subgroup in the details page.

The main tasks for this exercise are as follows:

1.	Add a partial view.

2.	Use the partial view in the **ShowDataForCity** view.

3.	Run the application.

####	Task 1: Add a partial view.

1. Create a new folder, in the **CitiesDetails** project by using the following information:

    - Folder name: **Shared**
    - Parent folder: **Views**

2. Add a partial view using the following information:
    - View name: **_CityPopulation**
    - Parent folder: **Shared**

3. In the **_CityPopulation** view, delete the file content.

4.  In the **_CityPopulation** view, define a variable using the following information:
    - Type: CitiesDetails.Services.CityPopulation
    - Name: **population**
    - Initial value: **_cityPopulation** from the **ViewBag.City**

5. In the **_CityPopulation** view, Add a **P** element.

6. In the **P** element add an **H3** element with a headline for a city population.

7. In the headline, include the **_year** property from the **population** variable.
    > **Note**: The **_year** property represents the year that the census was made.

8. In the **_CityPopulation** view, Add a **P** element  and a details in the  **_city** property from the **population** variable.

9. In the **_CityPopulation** view, Add a **P** element, set its inner text to contain its title (City), followed by the  **_city** property from the **population** variable.

10. In the **_CityPopulation** view, Add a **P** element, set its content to title of your choice, followed by the  **_city** property from the **population** variable.

11. In the **_CityPopulation** view, Add a **P** element, set its content to title of your choice, followed by the **_urban** property from the **population** variable.

12. In the **_CityPopulation** view, Add a **P** element, set its content to title of your choice, followed by the **_metro** property from the **population** variable.

####	Task 2: Use the partial view in the ShowDataForCity view.

1. In the **ShowDataForCity** view, below the **SPAN** element, add an **A** element using the following information:  
    - Target page: **_CityPopulation**
    - Tag helper: Html.Partial

####	Task 3: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.
    > **Note**: The browser displays a link for each city in a list.

2.  In the **Microsoft Edge** window, click the **Madrid** link.
    > **Note**: The browser displays the city details with its population region.

3. Close the **Microsoft Edge** window.

4. Stop debugging.

##	Exercise 3: Adding a view component

#### Scenario

The **ShowCities** page shows onle a simple list of links to the **CityDetailsPage**. We will use **ViewCoponents** to show more details on each city in the **ShowCities** page.

The main tasks for this exercise are as follows:

1.	Add a view component class.

2.	Add a view component view.

3.	Use the view component.

4.	Run the application.

####	Task 1: Add a view component class.

1. Create a new top-level folder, in the **CitiesDetails** project by using the following information:

    - Folder name: **ViewComponents**

2. Create a new class by using the following information:

    - Name: **CityViewComponent**
    - Parent folder: **ViewComponents**

3. In the ****CityViewComponent**** class, add **using** statements to the model for the following namespaces:

    - **Microsoft.AspNetCore.Mvc**

4. Ensure that the **CityViewComponent** class inherits from the **ViewComponent** class.

5.	Add a method for the **CityViewComponent** ViewComponent by using the following information:

    - Scope: **public**
    - Return Type: **IViewComponentResult**
    - Name: **Invoke**
    - Parameter Type: **string**
    - Parameter Name: **cityName**

6. In the **Invoke** method code block, insert the city name parameter into the **ViewBag.CurrentCityName**.

7. In the **Invoke** method code block, return the **SelectCity** view.

####	Task 2: Add a view component view.

1. Create a new folder, in the **CitiesDetails** project by using the following information:

    - Folder name: **Components**
    - Parent folder: **Shared**

2. Create a new folder, in the **CitiesDetails** project by using the following information:

    - Folder name: **City**
    - Parent folder: **Components**

3. Create a new partial view using the following information:
    - Name: **SelectCity**
    - Parent folder: **Components**

4. In the **SelectCity** partial view, replace the content with a new **DIV** element.

5. Place an **H2** element inside the **DIV** element.

6. Place an **A** element with a tag helper, inside the **H2** element using the following information:
    - Content: **CurrentCityName** property from the **ViewBag**.
    - Target action: **ShowDataForCity**
    - Tag helper: **asp-action**
    - Parameter name: **city**
    - Parameter value: **CurrentCityName** property from the **ViewBag**.

7. Below the **H2** element, render an **IMG** tag.

8. In the **IMG** element, add a **SRC** property using the following information:
    - Html helper: **Url.Action**
    - Target action: **GetImage**
    - Helper parameter: **CurrentCityName** property from the **ViewBag**.

####	Task 3: Use the view component.

1. In the **ShowCities.cshtml** view, replace the content of the **foreach** loop, with a view component invocation using the following information:
    - Target partial view: **City**
    - Html helper: **Component.InvokeAsync**
    - Parameter Value: city name

    The **@item.Key** contains the city name.

####	Task 4: Run the application.

1. Run the new ASP.NET Core application in **Microsoft Edge** and review the page's output.
    > **Note**: The browser displays a list of cities, each has a header link and mini map image of the region.

2.  In the **Microsoft Edge** window, click the **Madrid** link.
    > **Note**: The browser displays the city details.

3. Close the **Microsoft Edge** window.

4. Stop debugging.
