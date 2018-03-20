# Module 6: Developing Models

# Lesson 1: Creating MVC Models

### Demonstration: How to Bind Views to Model Classes

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\01_BindViewsExample_begin**, and then double-click **BindViewsExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **BindViewsExample - Microsoft Visual Studio** window, right-click **Models** folder, point to Add, and then click **class**.

2. In the **Name** box of the **Add New Item – BindViewsExample** dialog box, type **Restaurant**, and then click Add.

3. In the **Restaurant** class code block, press Enter and then type the following code.


  ```cs
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public bool Open { get; set; }
       public string Speciality { get; set; }
       public int Review { get; set; }
```
4. In the Solution Explorer pane, under BindViewsExample, expand **Controllers**, and then click **HomeController.cs**.

5. In the **HomeController.cs** code window, locate the following code.

  ```cs
       using Microsoft.AspNetCore.Mvc;
```
6. Ensure that the mouse cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code.

  ```cs
       using BindViewsExample.Models;
```

7. In the **Index** action code block, select the following code.

  ```cs
       return View();
```
8. Replace the selected code with the following code.

  ```cs
       Restaurant restaurant = new Restaurant() {Id = 1, Name = "My Kitchen 1",Address = "New Brunswick, 2657 Webster Street", Speciality = "Hamburgers", Open = true, Review = 4 }; 
       return View(restaurant);
```
9. In the **AnotherWayToDisplay** action code block, select the following code.

  ```cs
       return View();
```

10. Replace the selected code with the following code.

  ```cs
       Restaurant restaurant = new Restaurant() {Id = 2, Name = "My Kitchen 2",Address = "New Brunswick, 2657 Webster Street", Speciality = "Hamburgers", Open = true, Review = 4 }; 
       return View(restaurant);
```

11. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Index.cshtml**.

12. In the **Index.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
13. Place the mouse cursor before the located code, press Enter, and then type the following code.

  ```cs
       @model BindViewsExample.Models.Restaurant
```
14. In the **BODY** element of the Index.cshtml code window, type the following code.

  ```cs
       <h1>The first way to pass a model from an action to a view</h1>
       <div>
       </div>
```

15. In the **DIV** element of the Index.cshtml code window, type the following code.

  ```cs
       <h4>@Model.Name</h4>
       <h4>@Model.Address</h4>
       <h4>@Model.Speciality</h4>
       <h4>@Model.Open</h4>
       <h4>@Model.Review</h4>
```
   >**Note:** The Razor view engine runs this code and renders the Restaurant properties that you viewed in the model.

16. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **AnotherWayToDisplay.cshtml**.

17. In the **AnotherWayToDisplay.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
18. Place the mouse cursor before the located code, press Enter, and then type the following code.

  ```cs
       @model BindViewsExample.Models.Restaurant
```
19. In the **BODY** element of the AnotherWayToDisplay.cshtml code window, type the following code.

  ```cs
       <h1>The second way to pass a model from an action to a view</h1>
       <div>
       </div>
```
20. In the **DIV** element of the AnotherWayToDisplay.cshtml code window, type the following code.

  ```cs
       @Html.EditorForModel()
```
   >**Note:** The Razor view engine runs this code and renders the Restaurant properties that you viewed in the model.

21. On the **FILE** menu of the **BindViewsExample - Microsoft Visual Studio** window, click **Save All**.

22. On the **DEBUG** menu of the **"BindViewsExample - Microsoft Visual Studio"** window, click **Start Debugging**.

       >**Note:** The first way to display the Restaurant properties in the browser window.

23. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Home/Display** and then press Enter.

      >**Note:** The second way to display the Restaurant properties in the browser window.

24. In the Windows Microsoft Edge window, click **Close**.

25. In the **"BindViewsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

26. In the **"BindViewsExample - Microsoft Visual Studio"** window, click **Close**.
