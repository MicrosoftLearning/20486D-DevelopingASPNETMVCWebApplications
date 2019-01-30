# Module 5: Developing Views

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lab: Developing Views 

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos of this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

## Exercise 1: Adding Views to an MVC Application

###	Task 1: Add a view to show all the cities

1. Navigate to **[Repository Root]\Allfiles\Mod05\Labfiles\01_CitiesWebsite_begin**, and then double-click **CitiesWebsite.sln**.

    >**Note**: If a **Security Warning for CitiesWebsite** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.
    
2. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, expand **Services**, and then click **CityProvider.cs**.

3. In the **CityProvider.cs** code window, locate the following code:
```cs
    public CityProvider()
    {

    }
```

4. Place the cursor within the **CityProvider** constructor code block, and then type the following code:
```cs
    _cities = CityInitializer();
```

5. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, expand **Models**, and then click **City.cs**.

6. In the **City.cs** code window, locate the following code:
```cs
    public City(string country, string cityName, string timeZone, CityPopulation population)
    {

    }
```

7. Place the cursor within the **City** constructor code block, and then type the following code:
```cs
    Country = country;
    Name = cityName;
    TimeZone = timeZone;
    Population = population;
```

8. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Models**, click **CityPopulation.cs**.

9. In the **CityPopulation.cs** code window, locate the following code:
```cs
    public CityPopulation(int year, int city, int urban, int metro)
    {

    }
```

10. Place the cursor within the **CityPopulation** constructor code block, and then type the following code:
```cs
    Year = year;
    City = city;
    Urban = urban;
    Metro = metro;
```

11. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **CityController.cs**.


12. In the **CityController.cs** code window, locate the following code:
```cs
    using Microsoft.AspNetCore.Mvc;
```

13. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using CitiesWebsite.Services;
```

14. In the **CityController.cs** code window, locate the following code:
```cs
    public class CityController : Controller
    {
```

15. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    private ICityProvider _cities;
```

16. In the **CityController.cs** code window, select the following code:
```cs
    public CityController()
    {

    }
```

17. Replace the selected code with the following code:
```cs
    public CityController(ICityProvider cities)
    {
        _cities = cities;
    }
```

18. In the **CityController.cs** code window, locate the following code:
```cs
    public IActionResult ShowCities()
    {
```

19. Place the cursor after the **{** (opening brackets) sign, press Enter, and then type the following code:
```cs
    ViewBag.Cities = _cities;
```

20. In the **CityController.cs** code window, right-click the following code, and then click **Add View**.
```cs
    public IActionResult ShowCities()
```

21. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **ShowCities**.

22. In the **Add MVC View** dialog box, ensure that **Empty (without model)** template is selected.

23. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** and **Use a layout page** check boxes are cleared, and then click **Add**.

24. In the **ShowCities.cshtml** code window, locate the following code:
```cs
    <title>ShowCities</title>
```

25. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <link rel="stylesheet" type="text/css" href="~/css/style.css" />
```

26. In **ShowCities.cshtml** code window, in the **BODY** element, type the following code:
```cs
    <h1>Select City</h1>
    @foreach (var item in ViewBag.Cities)
    {
        <p>@item.Key</p>
    }
```

###	Task 2: Run the application

1. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays a **Select City** title and a list of cities below it: **Madrid**, **London**, and **Paris**.

3. In Microsoft Edge, click **Close**.

###	Task 3: Add a view to show data for a city

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **CityController.cs**.

2. In the **CityController.cs** code window, select the following code:
```cs
    public IActionResult ShowDataForCity()
```

3. Replace the selected code with the following code:
```cs
    public IActionResult ShowDataForCity(string cityName)
```

4. In the **CityController.cs** code window, locate the following code:
```cs
    public IActionResult ShowDataForCity(string cityName)
    {
```

5. Place the cursor after the **{** (opening brackets) sign, press Enter, and then type the following code:
```cs
    ViewBag.City = _cities[cityName];
```

6. In the **CityController.cs** code window, right-click the following code, and then click **Add View**.
```cs
    public IActionResult ShowDataForCity(string cityName)
```

7. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **ShowDataForCity**.

8. In the **Add MVC View** dialog box, ensure that **Empty (without model)** template is selected.

9. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** and **Use a layout page** check boxes are cleared, and then click **Add**.

10. In the **ShowDataForCity.cshtml** code window, locate the following code:
```cs
    <title>ShowDataForCity</title>
```

11. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <link rel="stylesheet" type="text/css" href="~/css/style.css" />
```

12. In the **ShowDataForCity.cshtml** code window, in the **BODY** element, type the following code:
```cs
    <div>
        <h2>@ViewBag.City.Name</h2>
        <p>Country: @ViewBag.City.Country</p>
        <p>Time zone: @ViewBag.City.TimeZone</p>
        <span><img src="@Url.Action("GetImage", new { cityName = ViewBag.City.Name })" /></span>
    </div>
```

13. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **CityController.cs**.

14. In the **CityController.cs** code window, select the following code:
```cs
    return Content(cityName);
```

15. Replace the selected code with the following code:
```cs
    return File($@"images\{cityName}.jpg", "image/jpeg");
```

###	Task 4: Add links to the views by using tag helpers

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – CitiesWebsite** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

3. In the **Add New Item – CitiesWebsite** dialog box, in the result pane, click **Razor View Imports**, and then click **Add**.

4. In the **_ViewImports.cshtml** code window, type the following code:
```cs
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

5. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **City**, and then click **ShowDataForCity.cshtml**.

6. In the **ShowDataForCity.cshtml** code window, locate the following code:
```cs
    <span><img src="@Url.Action("GetImage", new { cityName = ViewBag.City.Name })" /></span>
```

7. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    <a asp-action="ShowCities">Back</a>
```

8. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **City**, click **ShowCities.cshtml**.

9. In the **ShowCities.cshtml** code window, select the following code:
```cs
    <p>@item.Key</p>
```

10. Replace the selected code with the following code:
```cs
    <h2>
        <a asp-action="ShowDataForCity" asp-route-cityname="@item.Key">@item.Key</a>
    </h2>
```

###	Task 5: Run the application

1. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In Microsoft Edge, click **London**.
    >**Note**: The browser displays the city's name, details, mini map, and a **Back** link.

4. In Microsoft Edge, click **Back**.

5. In Microsoft Edge, click **Close**.

>**Result**: At the end of this exercise, you will be able to add views to an MVC application, pass data from a controller to a view using **ViewBag**, and navigate between pages by using helpers.

##	Exercise 2: Adding a Partial View

###	Task 1: Add a partial view

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Shared**, and then press Enter.

3. In Solution Explorer, right-click **Shared**, point to **Add**, and then click **View**.

4. In the **Add MVC View** dialog box, in the **View name** box, type **_CityPopulation**.

5. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

6. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is selected and the **Use a layout page** check box is cleared, and then click **Add**.

7. In the **_CityPopulation.cshtml** code window, delete all the content.

8. In the **_CityPopulation.cshtml** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    @inject CitiesWebsite.Services.ICityFormatter cityFormatter

    @{
        CitiesWebsite.Models.CityPopulation population = ViewBag.City.Population;
    }

    <h3>City Population (@population.Year)</h3>
    <p>City: @cityFormatter.GetFormattedPopulation(@population.City)</p>
    <p>Urban: @cityFormatter.GetFormattedPopulation(@population.Urban)</p>
    <p>Metro: @cityFormatter.GetFormattedPopulation(@population.Metro)</p>
```

###	Task 2: Use the partial view in the ShowDataForCity view

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **City**, click **ShowDataForCity.cshtml**.

2. In the **ShowDataForCity.cshtml** code window, locate the following code:
```cs
    <span><img src="@Url.Action("GetImage", new { cityName = ViewBag.City.Name })" /></span>
```

3. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    @await Html.PartialAsync("_CityPopulation")
```

###	Task 3: Run the application

1. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In Microsoft Edge, click **Madrid**.
    >**Note**: The browser displays the city's name, details, mini map, and a **Back** link.

4. In Microsoft Edge, click **Close**.

>**Result**: At the end of this exercise, you will be able to write and use partial views, and use services inside a view by using the **@Inject** directive.


##	Exercise 3: Adding a View Component

###	Task 1: Add a view component class

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, right-click **CitiesWebsite**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **ViewComponents**, and then press Enter.

3. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, right-click **ViewComponents**, point to **Add**, and then click **Class**.

4. In the **Add New Item – CitiesWebsite** dialog box, in the **Name** box, type **CityViewComponent**, and then click **Add**.

5. In the **CityViewComponent.cs** code window, locate the following code:
```cs
    using System.Threading.Tasks;
```

6. Place the cursor at the end of the located code, press Enter, and then type the following code:
```cs
    using Microsoft.AspNetCore.Mvc;
    using CitiesWebsite.Services;
    using CitiesWebsite.Models;
```

7. In the **CityViewComponent.cs** code window, select the following code:
```cs
    public class CityViewComponent
```

8. Append the following code to the existing line of code.
```cs
     : ViewComponent
```

9.	In the **CityViewComponent.cs** code window, place the cursor within the **CityViewComponent.cs** code block, and then type the following code:
```cs
    private ICityProvider _cities;

    public CityViewComponent(ICityProvider cities)
    {
        _cities = cities;
    }

    public async Task<IViewComponentResult> InvokeAsync(string cityName)
    {
        ViewBag.CurrentCity = await GetCity(cityName);
        return View("SelectCity");
    }

    private Task<City> GetCity(string cityName)
    {
        return Task.FromResult<City>(_cities[cityName]);
    }
```

###	Task 2: Add a view component view

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, right-click **Shared**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Components**, and then press Enter.

3. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, right-click **Components**, point to **Add**, and then click **New Folder**.

4. In the **NewFolder** box, type **City**, and then press Enter.

5. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, right-click the **City** folder you just created, point to **Add**, and then click **View**.
    
6. In the **Add MVC View** dialog box, in the **View name** box, type **SelectCity**.

7. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

8. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is selected and the **Use a layout page** check box is cleared, and then click **Add**.

9. In the **SelectCity.cshtml** code window, delete all the content.

10. In the **SelectCity.cshtml** code window, place the cursor at the beginning of the document, and then type the following code:
```cs
    <div>
        <h2>
            <a asp-action="ShowDataForCity" asp-route-cityname=@ViewBag.CurrentCity.Name>@ViewBag.CurrentCity.Name (Capital of @ViewBag.CurrentCity.Country)</a>
        </h2>
        <img src="@Url.Action("GetImage", new { cityName = ViewBag.CurrentCity.Name })" />
    </div>
```

###	Task 3: Use the view component

1. In the **CitiesWebsite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **City**, click **ShowCities.cshtml**.

2. In the **ShowCities.cshtml** code window, select the following code:
```cs
    <h2>
        <a asp-action="ShowDataForCity" asp-route-cityname="@item.Key">@item.Key</a>
    </h2>
```

3. Replace the selected code with the following code:
```cs
    @await Component.InvokeAsync("City", item.Key)
```

###	Task 4: Run the application

1. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **CitiesWebsite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.
    >**Note**: The browser displays a list of cities. Each has a header link and mini map image of the region.

3. In Microsoft Edge, click **Madrid (Capital of Spain)**.

4. In Microsoft Edge, click **Close**.

5. In the **CitiesWebsite – Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Result**: At the end of this exercise, you will be able to create view components, and embed them in a view.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.