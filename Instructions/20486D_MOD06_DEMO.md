# Module 6: Developing Models

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lesson 1: Creating MVC Models

### Demonstration: How to Bind Views to Model Classes

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 

2. Navigate to **[Repository Root]\Allfiles\Mod06\Democode\01_BindViewsExample_begin**, and then open the **BindViewsExample.sln**.

    >**Note**: If a **Security Warning for BindViewsExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **BindViewsExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this demonstration.

5. In Microsoft Edge, click **Close**.

#### Demonstration Steps

1. Go to **[Repository Root]\Allfiles\Mod06\Democode\01_BindViewsExample_begin**, and then double-click **BindViewsExample.sln**.

    >**Note**: If a **Security Warning for BindViewsExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In **Solution Explorer**, right-click **BindViewsExample**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** box, type **Models**, and then press Enter.

4. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Models**, point to **Add**, and then click **Class**.

5. In the **Add New Item – BindViewsExample** dialog box, in the **Name** box, type **Restaurant**, and then click **Add**.

6. In the **Restaurant.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public bool Open { get; set; }
       public string Speciality { get; set; }
       public int Review { get; set; }
```
7. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **BindViewsExample**, expand **Controllers**, and then click **HomeController.cs**.

8. In the **HomeController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```

9. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using BindViewsExample.Models;
```

10. In the **Index** action code block, select the following code:
  ```cs
       return View();
```

11. Replace the selected code with the following code:
  ```cs
       Restaurant restaurant = new Restaurant() {Id = 1, Name = "My Kitchen 1",Address = "New Brunswick, 2657 Webster Street", Speciality = "Hamburgers", Open = true, Review = 4 }; 
       return View(restaurant);
```

12. In the **AnotherWayToDisplay** action code block, select the following code:
  ```cs
       return View();
```

13. Replace the selected code with the following code:
  ```cs
       Restaurant restaurant = new Restaurant() { Id = 2, Name = "My Kitchen 2", Address = "New Brunswick, 4175 Echo Lane Street", Speciality = "Sushi", Open = true, Review = 3 };
       return View(restaurant);
```

14. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

15. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
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

18. In the **BindViewsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, click **AnotherWayToDisplay.cshtml**.

19. In the **AnotherWayToDisplay.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model BindViewsExample.Models.Restaurant
```

20. In the **BODY** element of the **AnotherWayToDisplay.cshtml** code window, type the following code:
  ```cs
       <h1>Restaurant Information</h1>
       <div>
       </div>
       <p id="remark">The second way to pass a model from an action to a view</p>
```
21. In the **DIV** element of the **AnotherWayToDisplay.cshtml** code window, type the following code:
  ```cs
       @Html.EditorForModel()
```

22. In the **BindViewsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

23. On the **DEBUG** menu, click **Start Without Debugging**.

       >**Note**: The browser window displays the **Index.cshtml** view. 

24. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Home/Display**, and then press Enter.

      >**Note**: The browser window displays the **AnotherWayToDisplay.cshtml** view. 

25. Click **Close**.

26. In the **BindViewsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Working with Forms

### Demonstration: How to Use Display and Edit Data Annotations

#### Preparation Steps 

Ensure that you have cloned the 20486D directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 

#### Demonstration Steps

1. Go to **[Repository Root]\Allfiles\Mod06\Democode\02_DataAnnotationsExample_begin**, and then double-click **DataAnnotationsExample.sln**.

    >**Note**: If a **Security Warning for DataAnnotationsExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **User.cs**.

3. In the **User.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```

4. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using System.ComponentModel.DataAnnotations;
```

5. In the **User.cs** code window, place the cursor at the end of the **UserId** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Full Name:")]
```

6. Place the cursor at the end of the **FullName** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Email Address:")]
      [DataType(DataType.EmailAddress)]
```

7. Place the cursor at the end of the **Email** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Birthdate:")]
      [DataType(DataType.Date)]
```

8. Place the cursor at the end of the **Birthdate** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Password:")]
      [DataType(DataType.Password)]
```

9. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**. 

10. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model DataAnnotationsExample.Models.User
```

11. In the **BODY** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <div class="container">
           <h1>Create an account</h1>
       </div>
```

12. In the **DIV** element of the **Index.cshtml** code window, after the **H1** element, type the following code:
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

13. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, click **Details.cshtml**.

14. In the **Details.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model DataAnnotationsExample.Models.User
```

15. In the **BODY** element of the **Details.cshtml** code window, type the following code:

  ```cs
       <div class="container">
           <h1>User Details</h1>
       </div>
```

16. In the **DIV** element of the **Details.cshtml** code window, after the **H1** element, type the following code:
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
>**Note**: This code block generates different HTML markups depending on the data type of the property that is being rendered.

17. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

18. On the **DEBUG** menu, click **Start Without Debugging**.

19. On the **Create an account** page, in the **Full Name** box, type **&lt;A full name of your choice&gt;**.

20. In the **Email Address** box, type **&lt;An email address of your choice&gt;**.

21. In the **Birthdate** box, choose **&lt;A birthdate of your choice&gt;**.

22. In the **Password** box, type **&lt;A password of your choice&gt;**, and then click **Register**.

      >**Note**: Verify the newly registered user details.

23. In Microsoft Edge, click **Close**.

24. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Validating MVC Applications

### Demonstration: How to Validate User Input with Data Annotations

#### Preparation Steps 

Ensure that you have cloned the 20486D directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 


#### Demonstration Steps

1. Go to **[Repository Root]\Allfiles\Mod06\Democode\03_DataAnnotationsValidationExample_begin**, and then double-click **DataAnnotationsExample.sln**.

    >**Note**: If a **Security Warning for DataAnnotationsExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **Person.cs**.

3. In the **Person.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
4. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using System.ComponentModel.DataAnnotations;
```

5. In the **Person.cs** code window, place the cursor at the end of the **PersonId** property code, press Enter two times, and then type the following code:
  ```cs
      [DataType(DataType.Text)]
      [Display(Name = "First Name:")]
      [Required(ErrorMessage = "Please enter your first name.")]
```
6. Place the cursor at the end of the **FirstName** property code, press Enter two times, and then type the following code:
  ```cs
      [DataType(DataType.Text)]
      [Display(Name = "Last Name:")]
      [Required(ErrorMessage = "Please enter your last name.")]
```

7. Place the cursor at the end of the **LastName** property code, press Enter two times, and then type the following code:
  ```cs
      [Range(15, 50)]
      [Display(Name = "Age:")]
```

8. Place the cursor at the end of the **Age** property code, press Enter two times, and then type the following code:
  ```cs
      [StringLength(10)]
      [Display(Name = "Description:")]
```
9. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **HomeController.cs**.

10. In the **HomeController.cs** code window, locate the following code:
  ```cs
      public IActionResult Details(Person person)
      {
```
11. Place the cursor after the **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
      if (!ModelState.IsValid)
      {
          return View("Index", person);
      }
```

12. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**. 

13. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model DataAnnotationsExample.Models.Person
```

14. In the **BODY** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <div class="container">
           <h1>Submit Personal Information</h1>
       </div>
```

15. In the **DIV** element of the **Index.cshtml** code window, after the **H1** element, type the following code:
  ```cs
       <form asp-action="Details">
            <div asp-validation-summary="All"></div>
            <div class="form-field">
                <label asp-for="FirstName"></label>
                <span class="input-span">
                    <input asp-for="FirstName" />
                    <span asp-validation-for="FirstName"></span>
                </span>
            </div>
            <div class="form-field">
                <label asp-for="LastName"></label>
                <span class="input-span">
                    <input asp-for="LastName" />
                    <span asp-validation-for="LastName"></span>
                </span>
            </div>
            <div class="form-field">
                <label asp-for="Age"></label>
                <span class="input-span">
                    <input asp-for="Age" />
                    <span asp-validation-for="Age"></span>
                </span>
            </div>
            <div class="form-field">
                <label asp-for="Description"></label>
                <span class="input-span">
                    <textarea asp-for="Description"></textarea>
                    <span asp-validation-for="Description"></span>
                </span>
            </div>
            <div>
                <input type="submit" value="Submit" />
            </div>
        </form>
```
16. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Home**, examine the **Details.cshtml** file content.

17. On the **FILE** menu, click **Save All**.

18. On the **DEBUG** menu, click **Start Without Debugging**.

19. On the **Submit Personal Information** page, in the **First Name** box, leave the field blank.

20. In the **Last Name** box, leave the field blank.

21. In the **Age** box, type **5**.

22. In the **Description** box, type **&lt;A description of your choice with more than ten characters&gt;**, and then click **Submit**.

      >**Note**: The browser window displays the **Index.cshtml** view with validation messages.

23. On the **Submit Personal Information** page, in the **First Name** box, type **&lt;A first name of your choice with at least one character&gt;**.

24. In the **Last Name** box, type **&lt;A last name of your choice at least one character&gt;**.

25. In the **Age** box, type **20**.

26. In the **Description** box, type **&lt;A description of your choice with less than ten characters&gt;**, and then click **Submit**.

      >**Note**: The browser window displays the **Details.cshtml** view with the newly submitted personal information.

27. In Microsoft Edge, click **Close**.

28. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Validating MVC Applications

### Demonstration: How to Add Custom Validations

#### Preparation Steps 

Ensure that you have cloned the 20486D directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 


#### Demonstration Steps

1. Go to **[Repository Root]\Allfiles\Mod06\Democode\04_DataAnnotationsCustomValidationExample_begin**, and then double-click **DataAnnotationsExample.sln**.

    >**Note**: If a **Security Warning for DataAnnotationsExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **DataAnnotationsExample**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** box, type **Validators**, and then press Enter.

4. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Validators**, point to **Add**, and then click **Class**.

5. In the **Add New Item – DataAnnotationsExample** dialog box, in the **Name** box, type **InUniversityValidationAttribute**, and then click **Add**.

6. In the **InUniversityValidationAttribute.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
7. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using DataAnnotationsExample.Models;
      using System.ComponentModel.DataAnnotations;
```
8. In the **InUniversityValidationAttribute.cs** code window, locate the following code:
  ```cs
      public class InUniversityValidationAttribute
```
9.  Append the following code to the existing line of code.
  ```cs
      : ValidationAttribute
```

10. In the **InUniversityValidationAttribute.cs** code block, press Enter, and then type the following code:
  ```cs
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
      }
```

11. In the **IsValid** method code block, press Enter, and then type the following code:
  ```cs
      Student student = (Student)validationContext.ObjectInstance;
      if (!student.UniversityStudent)
      {
         return new ValidationResult("Sorry you must be a student of the university in order to submit");
      }
      return ValidationResult.Success;
```
>**Note**: This code block validates whether the student is a university student or not.

12. In the **DataAnnotationsExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **Student.cs**.

13. In the **Student.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
14. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using DataAnnotationsExample.Validators;
```

15. In the **Student.cs** code window, place the cursor at the end of the **Birthdate** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Are you a university student?")]
      [InUniversityValidation]
```

16. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

17. On the **DEBUG** menu, click **Start Without Debugging**.

18. On the **Submit Student Information** page, in the **First Name** box, type **&lt;A first name of your choice with at least one character&gt;**.

19. In the **Last Name** box, type **&lt;A last name of your choice with at least one character&gt;**.

20. In the **Birthdate** box, choose **&lt;A birthdate of your choice&gt;**.

21. Ensure that the **Are you a university student?** check box is not selected, and then click **Submit**.

      >**Note**: The browser window displays the **Index.cshtml** view with the custom validation message below the **Are you a university student?** check box.

22. Ensure that the **Are you a university student?** check box is selected, and then click **Submit**. 

      >**Note**: Verify the newly submitted student information.

23. In Microsoft Edge, click **Close**.

24. In the **DataAnnotationsExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.