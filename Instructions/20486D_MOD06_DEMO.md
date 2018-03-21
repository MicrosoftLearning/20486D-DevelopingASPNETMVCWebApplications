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
       Restaurant restaurant = new Restaurant() { Id = 2, Name = "My Kitchen 2", Address = "New Brunswick, 4175 Echo Lane Street", Speciality = "Sushi", Open = true, Review = 3 };
       return View(restaurant);
```

11. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Index.cshtml**.

12. In the **Index.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
13. Place the mouse cursor before the located code, type the following code, and then press Enter.

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
18. Place the mouse cursor before the located code, type the following code, and then press Enter.

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

       >**Note:** The browser window displays the first way to render the Restaurant properties.

23. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Home/Display** and then press Enter.

      >**Note:** The browser window displays the second way to render the Restaurant properties.

24. In the Windows Microsoft Edge window, click **Close**.

25. In the **"BindViewsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

26. In the **"BindViewsExample - Microsoft Visual Studio"** window, click **Close**.

# Module 6: Developing Models

# Lesson 2: Working with Forms

### Demonstration: How to Use Display and Edit Data Annotations

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\02_DataAnnotationsExample_begin**, and then double-click **DataAnnotationsExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **DataAnnotationsExample - Microsoft Visual Studio** window, expand **Models**, and then click **User.cs**.

2. In the **User** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
3. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using System.ComponentModel.DataAnnotations;
```

4. In the **User** code window, place the mouse cursor at the end of the **UserId** property code, press Enter twice, and then type the following code.

  ```cs
      [Display(Name = "Full Name:")]
```
5. Place the mouse cursor at the end of the **FullName** property code, press Enter twice, and then type the following code.

  ```cs
      [Display(Name = "Email Address:")]
      [DataType(DataType.EmailAddress)]
```

6. Place the mouse cursor at the end of the **Email** property code, press Enter twice, and then type the following code.

  ```cs
      [Display(Name = "Date of birth:")]
      [DataType(DataType.Date)]
```

7. Place the mouse cursor at the end of the **Birthdate** property code, press Enter twice, and then type the following code.

  ```cs
      [Display(Name = "Password:")]
      [DataType(DataType.Password)]
```

8. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Index.cshtml**. 

9. In the **Index.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
10. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
       @model DataAnnotationsExample.Models.User
```
11. In the **BODY** element of the Index.cshtml code window, type the following code.

  ```cs
       <h1>Create an account</h1>
       <div>
       </div>
```

12. In the **DIV** element of the Index.cshtml code window, type the following code.

  ```cs
       <form asp-action="Details" method="post">
            <label asp-for="FullName"></label>
            <input asp-for="FullName" />
            <br />
            <label asp-for="Email"></label>
            <input asp-for="Email" />
            <br />
            <label asp-for="Birthdate"></label>
            <input asp-for="Birthdate" />
            <br />
            <label asp-for="Password"></label>
            <input asp-for="Password" />
            <br />
            <input type="submit" value="Register" />
        </form>
```
>**Note:** This code block generates a &lt;form&gt; Html element using FormTagHelper

13. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Details.cshtml**.

14. In the **Details.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
15. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
       @model DataAnnotationsExample.Models.User
```
16. In the **BODY** element of the Details.cshtml code window, type the following code.

  ```cs
       <h1>User details</h1>
       <div>
       </div>
```
17. In the **DIV** element of the Details.cshtml code window, type the following code.

  ```cs
       <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(model => model.FullName)
            </dt>
            <dd>
                @Html.DisplayFor(model => model.FullName)
            </dd>
            <dt>
                @Html.DisplayNameFor(model => model.Email)
            </dt>
            <dd>
                @Html.DisplayFor(model => model.Email)
            </dd>
            <dt>
                @Html.DisplayNameFor(model => model.Birthdate)
            </dt>
            <dd>
                @Html.DisplayFor(model => model.Birthdate)
            </dd>
        </dl>
        <br />
        <a asp-action="Index">Back to registration</a>
```
>**Note:** This code block generates different HTML markup depending on the data type of the property that is being rendered

18. On the **FILE** menu of the **DataAnnotationsExample - Microsoft Visual Studio** window, click **Save All**.

19. On the **DEBUG** menu of the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Start Debugging**.

20. On the **Register** page, in the **Full name** box, type _&lt;A full name of your choice&gt;._

21. On the **Register** page, in the **Email Address** box, type _&lt;An email address of your choice&gt;._

22. On the **Register** page, in the **Date of birth** box, type _&lt;A birthdate of your choice&gt;._

23. On the **Register** page, in the **Password** box, type _&lt;A__password of your choice&gt;_, and then click **Register**.

24. Verify the newly registered user details.

25. In the Windows Microsoft Edge window, click **Close**.

26. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

27. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Close**.

