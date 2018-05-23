# Module 6: Developing Models

# Lesson 1: Creating MVC Models

### Demonstration: How to Bind Views to Model Classes

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)

2. Go to **Allfiles\Mod06\Democode\01_BindViewsExample_begin**, and then double-click **BindViewsExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer**, right-click **BindViewsExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** text box, type **Models**, and then press Enter.

3. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Models**, point to Add, and then click **Class**.

4. In the **Add New Item – BindViewsExample** dialog box, in the **Name** text box, type **Restaurant**, and then click **Add**.

5. In the **Restaurant.cs** code block, place the cursor after the second **{** (opening brackets) sign, press Enter, and then type the following code:
  ```cs
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public bool Open { get; set; }
       public string Speciality { get; set; }
       public int Review { get; set; }
```
6. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **BindViewsExample**, expand **Controllers**, and then click **HomeController.cs**.

7. In the **HomeController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
8. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using BindViewsExample.Models;
```

9. In the **Index** action code block, select the following code:
  ```cs
       return View();
```
10. Replace the selected code with the following code:
  ```cs
       Restaurant restaurant = new Restaurant() {Id = 1, Name = "My Kitchen 1",Address = "New Brunswick, 2657 Webster Street", Speciality = "Hamburgers", Open = true, Review = 4 }; 
       return View(restaurant);
```
11. In the **AnotherWayToDisplay** action code block, select the following code:
  ```cs
       return View();
```

12. Replace the selected code with the following code:
  ```cs
       Restaurant restaurant = new Restaurant() { Id = 2, Name = "My Kitchen 2", Address = "New Brunswick, 4175 Echo Lane Street", Speciality = "Sushi", Open = true, Review = 3 };
       return View(restaurant);
```

13. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

14. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <!DOCTYPE html>
```
15. Place the cursor before the < (less than) sign, press Enter, press the Up Arrow Key, and then type the following code:
  ```cs
       @model BindViewsExample.Models.Restaurant
```

16. In the **BODY** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <h1>Restaurant Information</h1>
       <div>
       </div>
       <p id="remark">The first way to pass a model from an action to a view</p>
```

17. In the **DIV** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <p><b>Name</b>: @Model.Name</p>
       <hr />
       <p><b>Address</b>: @Model.Address</p>
       <hr />
       <p><b>Speciality</b>: @Model.Speciality</p>
       <hr />
       <p><b>Is Open</b>: @Model.Open</p>
       <hr />
       <p><b>Rating</b>: @Model.Review</p>
```

18. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, and then click **AnotherWayToDisplay.cshtml**.

19. In the **AnotherWayToDisplay.cshtml** code window, locate the following code:
  ```cs
       <!DOCTYPE html>
```
20. Place the cursor before the < (less than) sign, press Enter, press the Up Arrow Key, and then type the following code:
  ```cs
       @model BindViewsExample.Models.Restaurant
```

21. In the **BODY** element of the **AnotherWayToDisplay.cshtml** code window, type the following code:
  ```cs
       <h1>Restaurant Information</h1>
       <div>
       </div>
       <p id="remark">The second way to pass a model from an action to a view</p>
```
22. In the **DIV** element of the **AnotherWayToDisplay.cshtml** code window, type the following code:
  ```cs
       @Html.EditorForModel()
```

23. On the **FILE** menu of the **BindViewsExample - Microsoft Visual Studio** window, click **Save All**.

24. On the **DEBUG** menu of the **BindViewsExample - Microsoft Visual Studio** window, click **Start Debugging**.

       >**Note:** The browser window displays the **Index.cshtml** view. 

25. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Home/Display**, and then press Enter.

      >**Note:** The browser window displays the **AnotherWayToDisplay.cshtml** view. 

26. In the **Microsoft Edge** window, click **Close**.

27. In the **BindViewsExample - Microsoft Visual Studio** window, click **Stop Debugging**.

28. In the **BindViewsExample - Microsoft Visual Studio** window, click **Close**.

# Lesson 2: Working with Forms

### Demonstration: How to Use Display and Edit Data Annotations

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\02_DataAnnotationsExample_begin**, and then double-click **DataAnnotationsExample.sln**.

#### Demonstration Steps

1. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **User.cs**.

2. In the **User.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
3. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using System.ComponentModel.DataAnnotations;
```

4. In the **User.cs** code window, place the cursor at the end of the **UserId** property code, press Enter twice, and then type the following code:
  ```cs
      [Display(Name = "Full Name:")]
```
5. Place the cursor at the end of the **FullName** property code, press Enter twice, and then type the following code:
  ```cs
      [Display(Name = "Email Address:")]
      [DataType(DataType.EmailAddress)]
```

6. Place the cursor at the end of the **Email** property code, press Enter twice, and then type the following code:
  ```cs
      [Display(Name = "Birthdate:")]
      [DataType(DataType.Date)]
```

7. Place the cursor at the end of the **Birthdate** property code, press Enter twice, and then type the following code:
  ```cs
      [Display(Name = "Password:")]
      [DataType(DataType.Password)]
```

8. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**. 

9. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <!DOCTYPE html>
```
10. Place the cursor before the < (less than) sign, press Enter, press the Up Arrow Key, and then type the following code:
  ```cs
       @model DataAnnotationsExample.Models.User
```

11. In the **BODY** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <h1>Create an account</h1>
       <div>
       </div>
```

12. In the **DIV** element of the **Index.cshtml** code window, type the following code:
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

13. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, and then click **Details.cshtml**.

14. In the **Details.cshtml** code window, locate the following code:
  ```cs
       <!DOCTYPE html>
```
15. Place the cursor before the < (less than) sign, press Enter, press the Up Arrow Key, and then type the following code:

  ```cs
       @model DataAnnotationsExample.Models.User
```

16. In the **BODY** element of the **Details.cshtml** code window, type the following code:

  ```cs
       <h1>User Details</h1>
       <div>
       </div>
```
17. In the **DIV** element of the **Details.cshtml** code window, type the following code:
  ```cs
       <span class="display-prop-name">
           @Html.DisplayNameFor(model => model.FullName)
       </span>
       <br />
       <span class="display-prop-value">
           @Html.DisplayFor(model => model.FullName)
       </span>
       <span class="display-prop-name">
           @Html.DisplayNameFor(model => model.Email)
       </span>
       <br />
       <span class="display-prop-value">
           @Html.DisplayFor(model => model.Email)
       </span>
       <span class="display-prop-name">
           @Html.DisplayNameFor(model => model.Birthdate)
       </span>
       <br />
       <span class="display-prop-value">
           @Html.DisplayFor(model => model.Birthdate)
       </span>
```
>**Note:** This code block generates different HTML markup depending on the data type of the property that is being rendered.

18. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

19. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

20. On the **Register** page, in the **Full Name** text box, type _&lt;A full name of your choice&gt;._

21. On the **Register** page, in the **Email Address** text box, type _&lt;An email address of your choice&gt;._

22. On the **Register** page, in the **Birthdate** text box, choose _&lt;A birthdate of your choice&gt;._

23. On the **Register** page, in the **Password** text box, type _&lt;A password of your choice&gt;_, and then click **Register**.

      >**Note:** Verify the newly registered user details.

24. In the **Microsoft Edge**, click **Close**.

25. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

26. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Validating MVC Applications

### Demonstration: How to Validate User Input with Data Annotations

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\03_DataAnnotationsValidationExample_begin**, and then double-click **DataAnnotationsExample.sln**.

#### Demonstration Steps

1. In the **DataAnnotationsExample - Microsoft Visual Studio** window, **Solution Explorer**, expand **Models**, and then click **Person.cs**.

2. In the **Person.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
3. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using System.ComponentModel.DataAnnotations;
```

4. In the **Person.cs** code window, place the cursor at the end of the **PersonId** property code, press Enter twice, and then type the following code:
  ```cs
      [DataType(DataType.Text)]
      [Display(Name = "First Name:")]
      [Required(ErrorMessage = "Please enter your first name.")]
```
5. Place the cursor at the end of the **FirstName** property code, press Enter twice, and then type the following code:
  ```cs
      [DataType(DataType.Text)]
      [Display(Name = "Last Name:")]
      [Required(ErrorMessage = "Please enter your last name.")]
```

6. Place the cursor at the end of the **LastName** property code, press Enter twice, and then type the following code:
  ```cs
      [Range(15, 50)]
      [Display(Name = "Age:")]
```

7. Place the cursor at the end of the **Age** property code, press Enter twice, and then type the following code:
  ```cs
      [StringLength(10)]
      [Display(Name = "Description:")]
```
8. In the **DataAnnotationsExample - Microsoft Visual Studio** window, **Solution Explorer**, expand **Controllers**, and then click **HomeController.cs**.

9. In the **HomeController** code window, locate the following code:
  ```cs
      public IActionResult Details(Person person)
      {
```
10. Place the mouse cursor after the **{** (opening brackets) sign, press Enter, and then type the following code:
  ```cs
      if (!ModelState.IsValid)
      {
          return View("Index", person);
      }
```

11. In the **DataAnnotationsExample - Microsoft Visual Studio** window, **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**. 

12. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <!DOCTYPE html>
```
13. Place the cursor before the < (less than), press Enter, press the Up Arrow Key, and then type the following code:
  ```cs
       @model DataAnnotationsExample.Models.Person
```

14. In the **BODY** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <h1>Submit Personal Information</h1>
       <div>
       </div>
```

15. In the **DIV** element of the **Index.cshtml** code window, type the following code:
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
16. In the **DataAnnotationsExample - Microsoft Visual Studio** window, **Solution Explorer**, under **Views**, under **Home**, examine the **Details.cshtml** file content.

17. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

18. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

19. On the **Submit Personal Information** page, in the **First Name** text box, leave the field blank.

20. On the **Submit Personal Information** page, in the **Last Name** text box, leave the field blank.

21. On the **Submit Personal Information** page, in the **Age** text box, type 5.

22. On the **Submit Personal Information** page, in the **Description** text box, type _&lt;More than ten characters&gt;_, and then click the **Submit** button.

      >**Note:** The browser window displays the **Index.cshtml** view with validation messages.

23. On the **Submit Personal Information** page, in the **First Name** text box, type _&lt;A first name of your choice&gt;._

24. On the **Submit Personal Information** page, in the **Last Name** text box, type _&lt;A last name of your choice&gt;._

25. On the **Submit Personal Information** page, in the **Age** text box, type 20.

26. On the **Submit Personal Information** page, in the **Description** text box, type _&lt;Less than ten characters&gt;_, and then click the **Submit** button.

      >**Note:** The browser window displays the **Details.cshtml** view with the newly submitted personal information.

27. In the **Microsoft Edge**, click **Close**.

28. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

29. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Validating MVC Applications

### Demonstration: How to Add Custom Validations

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod06\Democode\04_DataAnnotationsCustomValidationExample_begin**, and then double-click **DataAnnotationsExample.sln**.

#### Demonstration Steps

1. In the **DataAnnotationsExample - Microsoft Visual Studio** window, **Solution Explorer**, right-click **DataAnnotationsExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** text box, type **Validators**, and then press Enter.

3. In the **DataAnnotationsExample - Microsoft Visual Studio** window, **Solution Explorer**, right-click **Validators**, point to Add, and then click **Class**.

4. In the **Add New Item – DataAnnotationsExample** dialog box, in the **Name** text box, type **InUniversityValidationAttribute**, and then click **Add**.

5. In the **InUniversityValidationAttribute.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
6. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using DataAnnotationsExample.Models;
      using System.ComponentModel.DataAnnotations;
```
7. In the **InUniversityValidationAttribute.cs** code window, locate the following code:
  ```cs
      public class InUniversityValidationAttribute
```
8.  Append the following code to the existing line of code.
  ```cs
      : ValidationAttribute
```

9. In the **InUniversityValidationAttribute.cs** code block, press Enter, and type the following code:
  ```cs
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
      }
```

10. In the **IsValid** method code block, press Enter, and type the following code:
  ```cs
      Student student = (Student)validationContext.ObjectInstance;
      if (!student.UniversityStudent)
      {
         return new ValidationResult("Sorry you must be a student of the university in order to submit");
      }
      return ValidationResult.Success;
```
>**Note:** This code block validates whether the student is a university student or not.

11. In the Solution Explorer pane of the **DataAnnotationsExample - Microsoft Visual Studio** window, expand **Models**, and then click **Student.cs**.

12. In the **Student.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
13. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using DataAnnotationsExample.Validators;
```

14. In the **Student.cs** code window, place the cursor at the end of the **Birthdate** property code, press Enter twice, and then type the following code:
  ```cs
      [Display(Name = "Are you a university student?")]
      [InUniversityValidation]
```

15. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

16. In the **DataAnnotationsExample - Microsoft Visual Studio** window, 0n the **DEBUG** menu, click **Start Debugging**.

17. On the **Submit Student Information** page, in the **First Name** text box, type _&lt;A first name of your choice&gt;._

18. On the **Submit Student Information** page, in the **Last Name** text box, type _&lt;A last name of your choice&gt;._

19. On the **Submit Student Information** page, in the **Birthdate** text box, choose _&lt;A birthdate of your choice&gt;._

20. On the **Submit Student Information** page, ensure that **Are you a university student?** checkbox is not selected, and then click the **Submit** button.

      >**Note:** The browser window displays the **Index.cshtml** view with custom validation message beside the **Are you a university student?** checkbox.

21. On the **Submit Student Information**, ensure that **Are you a university student?** checkbox is selected, and then click the **Submit** button. 

      >**Note:** Verify the newly submitted student information.

22. In the **Microsoft Edge** window, click **Close**.

23. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

24. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.