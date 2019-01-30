# Module 11: Managing Security

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lesson 1: Authentication in ASP.NET Core 

### Demonstration: How to use ASP.NET Core Identity

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod11\Democode\01_IdentityExample_begin\IdentityExample**, and then from the address bar, copy the address.

2. Click **Start**, and then type **cmd**.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd** *{copied folder path}* command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown at the command prompt, you can ignore them.

7. Close the window.

8. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod11\Democode\01_IdentityExample_begin**, and then double-click **IdentityExample.sln**.

    >**Note**: If a **Security Warning for IdentityExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **IdentityExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: Examine the page.

10.  In Microsoft Edge, click **Close**.

11. In the **IdentityExample - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

12. In the **Startup.cs** code window, locate the following code:
  ```cs
      using Microsoft.Extensions.DependencyInjection;
```

13. Ensure that the cursor is at the end of the **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
      using IdentityExample.Models;
```

14. In the **Startup.cs** code window, in the **ConfigureServices** method, place the cursor after the **{** (opening braces) sign, press Enter, type the following code, and then press Enter.
  ```cs
       services.AddDefaultIdentity<Student>(options =>
       {
           options.Password.RequireDigit = true;
           options.Password.RequiredLength = 7;
           options.Password.RequireUppercase = true;

           options.User.RequireUniqueEmail = true;
       })
        .AddEntityFrameworkStores<StudentContext>();
```
15. In the **Startup.cs** code window, locate the following code:
  ```cs
       app.UseStaticFiles();
```

16. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       app.UseAuthentication();
```
17. In the **IdentityExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **StudentController.cs**.

18. In the **StudentController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
          return View();
       }
```

19. Replace the selected code with the following code:
  ```cs
       public IActionResult Index()
       {
           if (!this.User.Identity.IsAuthenticated)
           {
               return RedirectToAction("Login", "Account");
           }
           return View();
       }
```

20. In the **IdentityExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Controllers**, point to **Add**, and then click **Controller**.

21. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

22. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **AccountController**, and then click **Add**.

23. In the **AccountController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
24. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using IdentityExample.Models;
       using IdentityExample.ViewModels;
       using Microsoft.AspNetCore.Identity;
```
25. In the **AccountController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
          return View();
       }
```

26. Replace the selected code with the following code:
  ```cs
       private SignInManager<Student> _signInManager;
       private UserManager<Student> _userManager;

       public AccountController(SignInManager<Student> signInManager, UserManager<Student> userManager)
       {
           _signInManager = signInManager;
           _userManager = userManager;
       }
```

27. Ensure that the cursor is at the end of the **AccountController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Login()
       {
           if (this.User.Identity.IsAuthenticated)
           {
               return RedirectToAction("Index", "Student");
           }
           return View();
       }
```

28. In the **AccountController.cs** code window, ensure that the cursor is at the end of the **Login** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpPost]
       public async Task<IActionResult> Login(LoginViewModel loginModel)
       {
           if (ModelState.IsValid)
           {
               var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
               if (result.Succeeded)
               {
                   return RedirectToAction("Index", "Student");
               }
           }
           ModelState.AddModelError("", "Failed to Login");
           return View();
       }
```

29. In the **AccountController.cs** code window, ensure that the cursor is at the end of the **Login** action code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> Logout()
       {
           await _signInManager.SignOutAsync();
           return RedirectToAction("Index", "Student");
       }
```

30. In the **AccountController.cs** code window, ensure that the cursor is at the end of the **Logout** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Register()
       {
           return View();
       }
```

31. In the **AccountController.cs** code window, ensure that the cursor is at the end of the **Register** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpPost]
       public async Task<IActionResult> Register(RegisterViewModel registerModel)
       {
           if (ModelState.IsValid)
           {
               Student student = new Student
               {
                   FirstName = registerModel.FirstName,
                   LastName = registerModel.LastName,
                   UserName = registerModel.UserName,
                   PhoneNumber = registerModel.PhoneNumber,
                   Email = registerModel.Email
               };

               var result = await _userManager.CreateAsync(student, registerModel.Password);
               if (result.Succeeded)
               {
                   return RedirectToAction("Login", "Account");
               }
               foreach (var error in result.Errors)
               {
                   ModelState.AddModelError("", error.Description);
               }
           }
           return View();
       }
```

32. In the **IdentityExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

33. In the **IdentityExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

34. In the menu bar, click **Student Portal**.

      >**Note**: The **Student Portal** page is only for authorized users; therefore, you are redirected to the login page.

35. On the **Login** page, click **Register**.

36. On the **Register** page, in the **First Name** box, type _&lt;A first name of your choice&gt;._

37. On the **Register** page, in the **Last Name** box, type _&lt;A last name of your choice&gt;._

38. On the **Register** page, in the **Phone Number** box, type _&lt;A phone number of your choice&gt;._

39. On the **Register** page, in the **Email** box, type _&lt;An email address of your choice&gt;._

40. On the **Register** page, in the **User Name** box, type _&lt;A user name of your choice&gt;._

41. On the **Register** page, in the **Password** box, type **123qwe!@#QWE**, and then click **Register**.

42. On the **Login** page, in the **User Name** box, type _&lt;The registered user name&gt;._

43. On the **Login** page, in the **Password** box, type **123qwe!@#QWE**, and then click **Login**.

      >**Note**: Examine the page; you have been authorized to enter the **Student Portal** page.

44.  In Microsoft Edge, click **Close**.

45. In the **IdentityExample  - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Authorization in ASP.NET Core

### Demonstration: How to Authorize Access to Controller Actions

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod11\Democode\02_AuthorizeExample_begin\IdentityExample**, and then copy the address in the address bar.

2. Click **Start**, and then type **cmd**.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd** *{copied folder path}* command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown in the command prompt, you can ignore them.

7. Close the window.

8. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod11\Democode\02_AuthorizeExample_begin**, and then double-click **IdentityExample.sln**.

    >**Note**: If a **Security Warning for IdentityExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

9. In the **IdentityExample - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

10. In the **Startup.cs** code window, locate the following code:
  ```cs
      using Microsoft.Extensions.DependencyInjection;
```
11. Ensure that the cursor is at the end of the **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
      using Microsoft.AspNetCore.Identity;
```

12. In the **Startup.cs** code window, select the following code:
  ```cs
       services.AddDefaultIdentity<Student>(options =>
```

13. Replace the selected code with the following code:
  ```cs
       services.AddIdentity<Student, IdentityRole>(options =>
```

14. In the **IdentityExample - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **StudentController.cs**.

15. In the **StudentController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```

16. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
      using Microsoft.AspNetCore.Authorization;
      using IdentityExample.Data;
```

17. In the **StudentController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
           if (!this.User.Identity.IsAuthenticated)
           {
               return RedirectToAction("Login", "Account");
           }
           return View();
       }
```

18. Replace the selected code with the following code:
  ```cs
       private StudentContext _studentContext;

       public StudentController(StudentContext studentContext)
       {
           _studentContext = studentContext;
       }

       [Authorize]
       public IActionResult Index()
       {
           return View();
       }
```

19. In the **StudentController.cs** code window, ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code:
  ```cs
       [AllowAnonymous]
       public IActionResult CourseDetails()
       {
           return View(_studentContext.Courses.ToList());
       }
```

20. In the **IdentityExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

21. In the **IdentityExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

22. In the menu bar, click **Student Portal**.

      >**Note**: The **Student Portal** page is only for authorized users; therefore, you are redirected to the login page.

23. In the menu bar, click **Our Courses**.

      >**Note**: The **Our Courses** page is authorized for all site visitors therefore, you can enter the page without registration.
      
24. In the menu bar, click **Login**.

25. On the **Login** page, click **Register**.

26. On the **Register** page, in the **First Name** box, type _&lt;A first name of your choice&gt;._

27. On the **Register** page, in the **Last Name** box, type _&lt;A last name of your choice&gt;._

28. On the **Register** page, in the **Phone Number** box, type _&lt;A phone number of your choice&gt;._

29. On the **Register** page, in the **Email** box, type _&lt;An email address of your choice&gt;._

30. On the **Register** page, in the **User Name** box, type _&lt;A user name of your choice&gt;._

31. On the **Register** page, in the **Password** box, type **123qwe!@#QWE**, and then click **Register**.

32. On the **Login** page, in the **User Name** box, type _&lt;The registered user name&gt;._

33. On the **Login** page, in the **Password** box, type **123qwe!@#QWE**, and then click **Login**.

      >**Note**: Examine the page; you have been authorized to enter the **Student Portal** page.

34.  In Microsoft Edge, click **Close**.

35. In the **IdentityExample  - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
