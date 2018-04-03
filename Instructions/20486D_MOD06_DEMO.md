# Module 6: Developing Models

# Lesson 1: Creating MVC Models

### Demonstration: How to Bind Views to Model Classes

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\01_BindViewsExample_begin**, and then double-click **BindViewsExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane, right-click **BindViewsExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Models**, and then press Enter.

3. In the Solution Explorer pane of the **BindViewsExample - Microsoft Visual Studio** window, right-click **Models** folder, point to Add, and then click **class**.

4. In the **Name** box of the **Add New Item – BindViewsExample** dialog box, type **Restaurant**, and then click Add.

5. In the **Restaurant** class code block, press Enter and then type the following code.


  ```cs
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public bool Open { get; set; }
       public string Speciality { get; set; }
       public int Review { get; set; }
```
6. In the Solution Explorer pane, under BindViewsExample, expand **Controllers**, and then click **HomeController.cs**.

7. In the **HomeController.cs** code window, locate the following code.

  ```cs
       using Microsoft.AspNetCore.Mvc;
```
8. Ensure that the mouse cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code.

  ```cs
       using BindViewsExample.Models;
```

9. In the **Index** action code block, select the following code.

  ```cs
       return View();
```
10. Replace the selected code with the following code.

  ```cs
       Restaurant restaurant = new Restaurant() {Id = 1, Name = "My Kitchen 1",Address = "New Brunswick, 2657 Webster Street", Speciality = "Hamburgers", Open = true, Review = 4 }; 
       return View(restaurant);
```
11. In the **AnotherWayToDisplay** action code block, select the following code.

  ```cs
       return View();
```

12. Replace the selected code with the following code.

  ```cs
       Restaurant restaurant = new Restaurant() { Id = 2, Name = "My Kitchen 2", Address = "New Brunswick, 4175 Echo Lane Street", Speciality = "Sushi", Open = true, Review = 3 };
       return View(restaurant);
```

13. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Index.cshtml**.

14. In the **Index.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
15. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
       @model BindViewsExample.Models.Restaurant
```
16. In the **BODY** element of the Index.cshtml code window, type the following code.

  ```cs
       <h1>Restaurant Information</h1>
       <div>
       </div>
       <p id="remark">The First Way To Pass A Model From An Action To A View</p>
```

17. In the **DIV** element of the Index.cshtml code window, type the following code.

  ```cs
       <p>@Model.Name</p>
       <p>@Model.Address</p>
       <p>@Model.Speciality</p>
       <p>@Model.Open</p>
       <p>@Model.Review</p>
```
   >**Note:** The Razor view engine runs this code and renders the Restaurant properties that you wrote in the model.

18. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **AnotherWayToDisplay.cshtml**.

19. In the **AnotherWayToDisplay.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
20. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
       @model BindViewsExample.Models.Restaurant
```
21. In the **BODY** element of the AnotherWayToDisplay.cshtml code window, type the following code.

  ```cs
       <h1>Restaurant Information</h1>
       <div>
       </div>
       <p id="remark">The Second Way To Pass A Model From An Action To A View</p>
```
21. In the **DIV** element of the AnotherWayToDisplay.cshtml code window, type the following code.

  ```cs
       @Html.EditorForModel()
```
   >**Note:** The Razor view engine runs this code and renders the Restaurant properties that you wrote in the model.

22. On the **FILE** menu of the **BindViewsExample - Microsoft Visual Studio** window, click **Save All**.

23. On the **DEBUG** menu of the **"BindViewsExample - Microsoft Visual Studio"** window, click **Start Debugging**.

       >**Note:** The browser window displays the first way to render the Restaurant properties.

24. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Home/Display** and then press Enter.

      >**Note:** The browser window displays the second way to render the Restaurant properties.

25. In the Microsoft Edge window, click **Close**.

26. In the **"BindViewsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

27. In the **"BindViewsExample - Microsoft Visual Studio"** window, click **Close**.

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
      [Display(Name = "Date birth:")]
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
>**Note:** This code block generates a &lt;form&gt; Html element using FormTagHelper.

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
       <div>
          <span class="display-prop-name">
               @Html.DisplayNameFor(model => model.FullName)
          </span>
          <br />
          <span class="display-prop-value">
               @Html.DisplayFor(model => model.FullName)
           </span>
        </div>
        <div>
          <span class="display-prop-name">
               @Html.DisplayNameFor(model => model.Email)
          </span>
          <br />
          <span class="display-prop-value">
               @Html.DisplayFor(model => model.Email)
          </span>
        </div>
        <div>
          <span class="display-prop-name">
               @Html.DisplayNameFor(model => model.Birthdate)
          </span>
          <br />
          <span class="display-prop-value">
               @Html.DisplayFor(model => model.Birthdate)
          </span>
        </div>
```
>**Note:** This code block generates different HTML markup depending on the data type of the property that is being rendered.

18. On the **FILE** menu of the **DataAnnotationsExample - Microsoft Visual Studio** window, click **Save All**.

19. On the **DEBUG** menu of the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Start Debugging**.

20. On the **Register** page, in the **Full name** box, type _&lt;A full name of your choice&gt;._

21. On the **Register** page, in the **Email Address** box, type _&lt;An email address of your choice&gt;._

22. On the **Register** page, in the **Date birth** box, type _&lt;A birthdate of your choice&gt;._

23. On the **Register** page, in the **Password** box, type _&lt;A password of your choice&gt;_, and then click **Register**.

24. On the **User Details** page, Verify the newly registered user details.

25. In the Microsoft Edge window, click **Close**.

26. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

27. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Close**.

# Lesson 3: Validating MVC Applications

### Demonstration: How to Validate User Input with Data Annotations

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\03_DataAnnotationsValidationExample_begin**, and then double-click **DataAnnotationsExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **DataAnnotationsExample - Microsoft Visual Studio** window, expand **Models**, and then click **Person.cs**.

2. In the **Person** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
3. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using System.ComponentModel.DataAnnotations;
```

4. In the **Person** code window, place the mouse cursor at the end of the **PersonId** property code, press Enter twice, and then type the following code.

  ```cs
      [DataType(DataType.Text)]
      [Display(Name = "First Name:")]
      [Required(ErrorMessage = "Please enter your first name.")]
```
5. Place the mouse cursor at the end of the **FirstName** property code, press Enter twice, and then type the following code.

  ```cs
      [DataType(DataType.Text)]
      [Display(Name = "Last Name:")]
      [Required(ErrorMessage = "Please enter your last name.")]
```

6. Place the mouse cursor at the end of the **LastName** property code, press Enter twice, and then type the following code.

  ```cs
      [Range(15, 50)]
      [Display(Name = "Age:")]
```

7. Place the mouse cursor at the end of the **Age** property code, press Enter twice, and then type the following code.

  ```cs
      [StringLength(10)]
      [Display(Name = "Description:")]
```
8. In the Solution Explorer pane, under DataAnnotationsExample, expand **Controllers**, and then click **HomeController.cs**.

9. In the **Details** action code block, select the following code.

  ```cs
      return View(person);
```
10. Place the mouse cursor before the located code, and type the following code.

  ```cs
      if (!ModelState.IsValid)
      {
          return View("Index", person);
      }
```

11. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Index.cshtml**. 

12. In the **Index.cshtml** code window, locate the following code.

  ```cs
       <!DOCTYPE html>
```
13. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
       @model DataAnnotationsExample.Models.Person
```
14. In the **BODY** element of the Index.cshtml code window, type the following code.

  ```cs
       <h1>Submit Personal Information</h1>
       <div>
       </div>
```

15. In the **DIV** element of the Index.cshtml code window, type the following code.

  ```cs
       <form asp-action="Details">
            <div asp-validation-summary="All"></div>
            <div class="form-field">
                <label asp-for="FirstName"></label>
                <input asp-for="FirstName" />
                <span asp-validation-for="FirstName"></span>
            </div>
            <div class="form-field">
                <label asp-for="LastName"></label>
                <input asp-for="LastName" />
                <span asp-validation-for="LastName"></span>
            </div>
            <div class="form-field">
                <label asp-for="Age"></label>
                <input asp-for="Age" />
                <span asp-validation-for="Age"></span>
            </div>
            <div class="form-field">
                <label asp-for="Description"></label>
                <textarea asp-for="Description"></textarea>
                <span asp-validation-for="Description"></span>
            </div>
            <div class="form-field">
                <input type="submit" value="Submit" />
            </div>
        </form>
```
>**Note:** This code block generates validation messages to a &lt;form&gt; using ValidationMessage and ValidationSummary Tag Helpers.

16. On the **FILE** menu of the **DataAnnotationsExample - Microsoft Visual Studio** window, click **Save All**.

17. On the **DEBUG** menu of the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Start Debugging**.

18. On the **Submit Personal Information** page, in the **First Name** box, Leave the field blank.

19. On the **Submit Personal Information** page, in the **Last Name** box, Leave the field blank.

20. On the **Submit Personal Information** page, in the **Age** box, type 5.

21. On the **Submit Personal Information** page, in the **Description** box, type _&lt;More than ten characters&gt;_, and then click **Submit**.

22. On the **Submit Personal Information** page, Verify the validation messages.

23. On the **Submit Personal Information** correct all the fields with the validation message, and then click **Submit**. 

      >**Note:** Verify the newly submitted personal information.

24. In the Microsoft Edge window, click **Close**.

25. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

26. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Close**.

# Lesson 3: Validating MVC Applications

### Demonstration: How to Add Custom Validations

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\04_DataAnnotationsCustomValidationExample_begin**, and then double-click **DataAnnotationsExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane, right-click **DataAnnotationsExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Validators**, and then press Enter.

3. In the Solution Explorer pane of the **DataAnnotationsExample - Microsoft Visual Studio** window, right-click **Validators** folder, point to Add, and then click **class**.

4. In the **Name** box of the **Add New Item – DataAnnotationsExample** dialog box, type **InUniversityValidationAttribute**, and then click Add.

5. In the **InUniversityValidationAttribute** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
6. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using DataAnnotationsExample.Models;
      using System.ComponentModel.DataAnnotations;
```
7. In the **InUniversityValidationAttribute** class code window, locate the following code.

  ```cs
      public class InUniversityValidationAttribute
```
8.  Append the following code to the existing line of code.

  ```cs
      : ValidationAttribute
```

9. In the **InUniversityValidationAttribute** class code block, press Enter, and type the following code.

  ```cs
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
      }
```

10. In the **IsValid** method code block press enter, and type the following code.

  ```cs
      Student student = (Student)validationContext.ObjectInstance;
      if (!student.UniversityStudent)
      {
         return new ValidationResult("Sorry you should be a student in the university to submit");
      }
      return ValidationResult.Success;
```
>**Note:** This code block Validates whether the student is a university student.

11. In the Solution Explorer pane of the **DataAnnotationsExample - Microsoft Visual Studio** window, expand **Models**, and then click **Student.cs**.

12. In the **Student** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
13. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using DataAnnotationsExample.Validators;
```

14. In the **Student** code window, place the mouse cursor at the end of the **Birthdate** property code, press Enter twice, and then type the following code.

  ```cs
      [Display(Name = "Are you a university student?")]
      [InUniversityValidation]
```

15. On the **FILE** menu of the **DataAnnotationsExample - Microsoft Visual Studio** window, click **Save All**.

16. On the **DEBUG** menu of the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Start Debugging**.

17. On the **Submit Student Information** page, in the **First name** box, type _&lt;A first name of your choice&gt;._

18. On the **Submit Student Information** page, in the **Last name** box, type _&lt;A last name of your choice&gt;._

19. On the **Submit Student Information** page, in the **BirthDate** box, type _&lt;A birthdate of your choice&gt;._

20. On the **Submit Student Information** page, ensure that **Are you a university student?** checkbox is not selected and then click **Submit**.

21. Verify the custom validation message.

22. On the **Submit Student Information**, ensure that **Are you a university student?** checkbox is selected, and then click **Submit**. 

      >**Note:** Verify the newly submitted personal information.

23. In the Microsoft Edge window, click **Close**.

24. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Stop Debugging**.

25. In the **"DataAnnotationsExample - Microsoft Visual Studio"** window, click **Close**.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.