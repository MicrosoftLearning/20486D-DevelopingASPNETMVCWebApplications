# Module 11: Managing Security

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Managing Security

#### Scenario

You have been asked to create a web-based library application for your organization's customers. The application should have a page showing the most recommended books, login and register pages, and the ability to add books to the library for only authorized users. The application should have Identity configuration, a variety of settings for authorization, and a demonstration of a cross-site request forgery attack.

#### Objectives

After completing this lab, you will be able to:

- Use Identity.
- Add Authorization.
- Avoid the Cross-Site Request Forgery attack.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **[Repository Root]\Allfiles\Mod11\Labfiles\01_Library_begin**, and then open the **Library.sln**.

    >**Note**: If a **Security Warning for Library** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **Library - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this lab.

5. In Microsoft Edge, click **Close**.

### Exercise 1: Use Identity

#### Scenario

In this exercise, you will first add an entity-framework-database context to the **LibraryContext** class. You will then enable using identity in the **startup** class. After that, you will add sign-in, and register user logic. Finally, you will retrieve data from the identity property in the **LendingBook.cshtml** view.

The main tasks for this exercise are as follows:

1.	Add the Entity Framework database context

2.	Enable using Identity

3.	Add sign in logic

4.	Add Register a user logic

5.	Retrieve data from the Identity property

6.	Run the application


#### Task 1: Add the Entity Framework database context

1. Open the **Command Prompt** window by using **Run as administrator**.

2. In the **Administrator: Command Prompt** window, run the following command: **cd [Repository Root]\Allfiles\Mod11\Labfiles\01_Library_begin\Library**.

3. Run the following command: **npm install**.

4. Close the **Command Prompt** window.

5. From the following location: **[Repository Root]\Allfiles\Mod11\Labfiles\01_Library_begin**, open the **Library.sln** solution.

    >**Note**: If a **Security Warning for Library** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

6. In the **User** class, add a **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.Identity**

7. Change the **User** class to inherit from the **IdentityUser** class.

8. In the **LibraryContext** class, add a **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.Identity.EntityFrameworkCore**

9. Change the  **LibraryContext** class to inherit from the **IdentityDbContext&lt;User&gt;** class.

#### Task 2: Enable using Identity

1. In the **Startup** class, add the **USING** statements for the following namespaces:

   - **Library.Models**
   - **Microsoft.AspNetCore.Identity**

2. At the beginning of the **ConfigureServices** method, call the **AddIdentity&lt;User, IdentityRole&gt;** method of **services** parameter.

3. Pass a lambda expression as a parameter to the **AddIdentity** method with the following information:

   - Lambda Expression: options => { }

4. In the  **lambda expression** code block, assign to the **options.Password.RequireDigit** property the value of **true**.

5. Assign to the **options.Password.RequiredLength** property the value of **7**.

6. Assign to the **options.Password.RequireUppercase** property the value of **true**.

7. Assign to the **options.User.RequireUniqueEmail** property the value of **true**.

8. To the **AddIdentity** method call, chain a **AddEntityFrameworkStores&lt;LibraryContext&gt;** method call.

9.  In the **Configure** method, after the call to the **UseStaticFiles** method, call the **UseAuthentication** method of the **app** parameter.

#### Task 3: Add sign in logic

1. Create a new controller with the following information:
   - Controller name: **AccountController**
   - Template: **MVC Controller - Empty**
   - Folder: **Controllers**
   - Project: **Library**

2. In the **AccountController** class, add the **USING** statements for the following namespaces:

   - **Library.Models**
   - **Library.ViewModels**
   - **Microsoft.AspNetCore.Identity**

3. Remove the **Index** action with its content.

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **SignInManager&lt;User&gt;**
   - Name: **_signInManager**

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **UserManager&lt;User&gt;**
   - Name: **_userManager**

6.  Add a constructor with the following parameters:
     - Parameter: 
         - Type: **SignInManager&lt;User&gt;**
         - Name: **signInManager**

7.  Add a constructor with the following parameters:
     - Parameter: 
         - Type: **UserManager&lt;User&gt;**
         - Name: **userManager**

8. In the **AccountController** constructor, initialize the **_signInManager** field with the value of the **signInManager** parameter.

9. Initialize the **_userManager** field with the value of the **userManager** parameter.

10. Add a method with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Login**

11. Create an **IF** statement that checks whether the value of **this.User.Identity.IsAuthenticated** is **true**.

12. In the **IF** statement code block, return the **Task&lt;IActionResult&gt;** result by using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.

13. After the **IF** statement code block, return the **Task&lt;IActionResult&gt;** result by using the **View** method. 

14. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **LoginPost**
    - Parameter: 
         - Type: **LoginViewModel**
         - Name: **loginModel**

15. Above the **LoginPost** method, add a **HttpPost** attribute.

16. Add a **ActionName** attribute. Pass **"Login"** as a parameter to the **ActionName** attribute.

17. Create an **IF** statement that checks whether the value of **ModelState.IsValid** is **true**. 

18. In the **IF** statement code block, create a variable named **result** of type **var** and assign it with the value of **await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false)**.

19. Create an **IF** statement that checks whether the value of **result.Succeeded** is **true**.

20. In the nested **IF** statement code block, return the **Task&lt;IActionResult&gt;** result by using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.

21. After the first **IF** statement code block, call the **AddModelError** method of the **ModelState** propery.  Pass **""** and **"Faild to Login"** as parameters to the **AddModelError** method.

22.  Return the **Task&lt;IActionResult&gt;** result by using the **View** method. 

23. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **Logout**

24. In the **Logout** method, call the **_signInManager.SignOutAsync** method by using the **await** keyword. 

25. Return the **Task&lt;IActionResult&gt;** result by using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.


#### Task 4: Add user registration logic

1. In the **AccountController** class, add a method with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Register**


2. In the **Register** method, return the **IActionResult** result by using the **View** method. 

3. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **RegisterPost**
    - Parameter: 
         - Type: **RegisterViewModel**
         - Name: **registerModel**


4. Above the **RegisterPost** method, add a **HttpPost** attribute.

5. Add an **ActionName** attribute. Pass **"Register"** as a parameter to the **ActionName** attribute.

6. Create an **IF** statement that checks whether the value of **ModelState.IsValid** is **true**.

7.  In the **IF** statement code block, create a variable named **user** of type **User** and initialize it with the following information:
    - FirstName: **registerModel.FirstName**
    - LastName: **registerModel.LastName**
    - UserName: **registerModel.UserName**
    - PhoneNumber: **registerModel.PhoneNumber**
    - Email: **registerModel.Email**

8. Create a new variable named **result** of type **var** and assign it with the value of **await _userManager.CreateAsync(user, registerModel.Password)**.

9. Create an **IF** statement that checks whether the value of **result.Succeeded** is **true**.

10. In the new **IF** statement code block, create a variable named **resultSignIn** of type **var** and assign it with the value of **await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password,registerModel.RememberMe,false)**.

11. Create an **IF** statement that checks whether the value of **resultSignIn.Succeeded** is **true**.

12. In the new **IF** statement code block, result using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.

13. After the **IF** statement that checks that the value of **result.Succeeded** is **true**, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **error**
	- Collection: **result.Errors**

14.  In the **FOREACH** statement block, call the **AddModelError** method of the **ModelState** property.  Pass **""** and **error.Description** as parameters to the **AddModelError** method.

15. After the **IF** statement that checks whether the value of **ModelState.IsValid** is **true**, return the **Task&lt;IActionResult&gt;** result by using the **View** method. 

16. Add a method with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **AccessDenied**

17. In the **AccessDenied** method code block, return the **Task&lt;IActionResult&gt;** result by using the **View** method. 


#### Task 5: Retrieve data from the Identity property

1. At the **LendingBook.cshtml** view, before the **DIV** element with the **"page-container"** class, add an **H1** element with the following information:

    - Class: **title**
    - Content: **Hello @User.Identity.Name - Lending Book Information**

2. In the **_Layout.cshtml** file, after the last **LI** element, create an **IF** statement that checks whether the value of **User.IsInRole("Administrator")** is **true**. 

3. Inside the **IF** statement, add an **LI** element with the following information:

    - Class: **nav-item**

4. In the new **LI** element, add an **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Index", "Librarian")**
    - Content:  **Workers Portal**

5. After the **IF** statement, create an **IF** statement that checks whether the value of **User.Identity.IsAuthenticated** is **true**. 

6.  Inside the new **IF** statement, add an **LI** element with the following information:

    - Class: **nav-item**

7. In the new **LI** element, add an **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Logout", "Account")**
    - Content:  **Logout**

8. After the new **IF** statement, create an **ELSE** statement. 

9.  Inside the **ELSE** statement, add an **LI** element with the following information:

    - Class: **nav-item**

10. In the new **LI** element, add an **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Login", "Account")**
    - Content:  **Login**


#### Task 6: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In the menu bar, click **Our Books**.

4. On the **Login** page, click **Register**.
    >**Note**: The **Our Books** page is only for authorized users; therefore you are redirected to the login page.

5. On the **Register** page, register with the following credentials:
   
    - First Name: _&lt;A first name of your choice&gt;_
    - Last Name: _&lt;A last name of your choice&gt;_
    - Phone Number: _&lt;A phone of your choice&gt;_ 
    - Email: _&lt;An email of your choice&gt;_
    - User Name: _&lt;A user name of your choice&gt;_  
    - Password: **123qwe!@#QWE**

6. Click **Register**.

7. In the menu bar, click **Our Books**.
    >**Note**: Examine the page; you have been authorized to enter the **Our Books** page, and your user name data is retrieved from the Identity property.

8. Select a book of your choice, and then click **Lend a Book**.

    >**Note**: The book you lent is not available anymore.

9. Close all Microsoft Edge windows.


>**Results**: After completing this exercise, you will be able to configure identity in the application, add logic to the sign-in and register pages, and retrieve data from the identity.



### Exercise 2: Add Authorization

#### Scenario

In this exercise, you will first add **AuthorizeAttribute** to the **LibraryController** class. You will then configure role-based and claim-based policy authentication. And, you will add the relevant attribute in the **AccountController** class and in the **LibrarianController** class.

The main tasks for this exercise are as follows:

1. Add the AuthorizeAttribute to an action

2. Add role-based policy authentication

3. Add claim-based policy authentication

4. Run the application.

#### Task 1: Add the AuthorizeAttribute to an action

1. In the **LibraryController** class, add a **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.Authorization**

2. Above the **Index** method, add an **AllowAnonymous** attribute.

3. Above the **GetBooksByGener** method, add an **Authorize** attribute.

4. Remove the content of **GetBooksByGener**.

5. Create a new variable named **booksGenerQuery** of type **var** and assign it the value of the following **LINQ** query:

    - From: **b in _context.Books**
    - Orderby: **b.Genre.Name**
    - Select: **b**

6.  Return the **IActionResult** result by using the **View** method. Pass **booksGenerQuery** as a parameter to the **View** method.

7. Above the **LendingBookPost** method, add an **Authorize** attribute.


#### Task 2: Add Role-based Policy Authentication

1. In the **RegisterViewModel** class, add a property with the following information:
    - Scope: **public**
    - Property name: **RoleName**
    - Data type: **String**

2. Above the **RoleName** property, add a **Display** attribute with the following information:
    - Name: **"Role Name"**

3. Add a **Required** attribute with the following information:
    - ErrorMessage: **"Please select a role"**

4. In the **AccountController** class, create a new field with the following information:

   - Scope: **private**
   - Type: **RoleManager&lt;IdentityRole&gt;**
   - Name: **_roleManager**

5.  Change the **AccountController** constructor signature to accept the following parameter:
    - Type:  **RoleManager&lt;IdentityRole&gt;**
    - Name: **roleManager**

6. In the **AccountController** constructor, initialize the **_roleManager** field with the value of the **roleManager** parameter.

7.  In the **RegisterPost** method, remove the contents of the **IF** statement code block that checks if the value of **result.Succeeded** is true. 

8. In the **IF** statement code block, create a variable named *roleExists* of type **bool** and assign it with the value of **await _roleManager.RoleExistsAsync(registerModel.RoleName)**.

9. Create a nested **IF** statement that checks whether the value of **roleExists** is **false**. 

10. In the nested **IF** statement code block, call the **_roleManager.CreateAsync** method using the **await** keyword. Pass **new IdentityRole(registerModel.RoleName)**
as a parameter to the **CreateAsync** method. 

11. After the nested **IF** statement code block, create an **IF** statement that checks that the value of **await _userManager.IsInRoleAsync(user, registerModel.RoleName)** is **false**. 

12. In the new **IF** statement code block, call the **_userManager.AddToRoleAsync** method by using the **await** keyword, and then pass **user** and **registerModel.RoleName**
as parameters to the **_userManager.AddToRoleAsync** method. 

13. After the new **IF** statement code block, create a variable named *resultSignIn* of type **var** and assign it with the value of **await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password,registerModel.RememberMe,false)**.

14. Create an **IF** statement that checks whether the value of **resultSignIn.Succeeded** is **true**. 

15. In the new **IF** statement code block,  return the **Task&lt;IActionResult&gt;** result by using the **RedirectToAction** method, and then pass **"Index"** and **"Library"** as parameters to **RedirectToAction** .

16. In the **Register.cshtml** view, after the last **DIV** element with the **"form-group"** class, add a **DIV** element with the following information:

    - Class: **form-group row**

17. In the new **DIV** element, add a **LABEL** element with the following information:

    - asp-for: **RoleName**
    - class: **col-sm-4 col-form-label**

18. Add a **DIV** element with the following information:

    - class: **col-sm-6**

19. In the new **DIV** element, add a **SELECT** element with the following information:

    - asp-for: **RoleName**
    - class: **form-control**

20. In the **SELECT** element, add an **OPTION** element with the following information:

    - selected: **selected**
    - Content: **Member**    

21. Add an **OPTION** element with the following information:

    - Content: **Administrator**    

22. In the **LibrarianController** class, add a **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.Authorization**

23. Above the **LibrarianController** class declaration, add an **Authorize** attribute. Pass **Roles="Administrator"** as a parameter to the **Authorize** attribute.


#### Task 3: Add claim-based policy authentication

1. In the **Startup.cs** class, add a **USING** statement for the following namespace:

   - **System.Security.Claims**

2. At the end of the **ConfigureServices** method, call the **AddAuthorization** method of **services** parameter.

3. Pass lambda expression as a parameter to the **AddAuthorization** method, with the following information:

   - Lambda Expression: options => { }

4. In the  **lambda expression** code block, call the **options.AddPolicy** method, and then pass **"RequireEmail"** and **policy => policy.RequireClaim(ClaimTypes.Email)** as parameters to the **options.AddPolicy** method.

5. In the **AccountController** class, add a **USING** statement for the following namespace:

   - **System.Security.Claims**

6.  In the **RegisterPost** method, before the **resultSignIn** variable creation,  create an **IF** statement that checks whether the value of **string.IsNullOrWhiteSpace(user.Email)** is **false**. 

7.  In the **IF** statement code block, create a variable named **claim** of type **Claim**. Initialize the **claim** variable by using the **Claim** constructor, and then pass the following parameters to it: **ClaimTypes.Email** and **user.Email**. 

8. Call the **_userManager.AddClaimAsync** method by using the **await** keyword, and then pass **user** and **claim** as parameters to the **_userManager.AddClaimAsync** method.

9. Above the **LibrarianController** class declaration,  above the **Authorize** attribute, add another **Authorize** attribute, and then pass **Policy="RequireEmail"** as a parameter to the **Authorize** attribute.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In the menu bar, click **Login**.

4. On the **Login** page, click **Register**.

5. On the **Register** page, register with the following credentials:
   
    - First Name: _&lt;A first name of your choice&gt;_
    - Last Name: _&lt;A last name of your choice&gt;_
    - Phone Number: _&lt;A phone of your choice&gt;_
    - Email: _&lt;An email of your choice&gt;_
    - User Name: _&lt;A user name of your choice&gt;_  
    - Password: **123qwe!@#QWE** 
    - Role Name: **Administrator** 

6. Click **Register**.

7. In the menu bar, click **Workers Portal**.
    >**Note**: Examine the page; you have been authorized to enter the **Workers Portal** page, because you are an administrator.

8. On the **Add Book to the Library** page, register with the following credentials:
   
    - Genre: _&lt;A genre of your choice&gt;_
    - Name: _&lt;A name of your choice&gt;_
    - Author: _&lt;A author of your choice&gt;_
    - Date Published: _&lt;A date time of your choice&gt;_

9. On the **Add Book to Library** page, in **Photo box**, import an image from **[Repository Root]\Allfiles\Mod11\Labfiles\Image\book.jpg**, and then click **Add a Book**.

10. Click **Back to Our Books**.
    >**Note**: The book you added is in the library books list.

11. In the menu bar, click **Logout**.   

12. In the menu bar, click **Login**. 

13. On the **Login** page, click **Register**.   

14. On **Register** page, register with the following credentials:
   
    - First Name: _&lt;A first name of your choice&gt;_
    - Last Name: &lt;A last name of your choice&gt;_
    - Phone Number: _&lt;A phone of your choice&gt;_ 
    - Email: _&lt;An email of your choice&gt;_
    - User Name: _&lt;A user name of your choice&gt;_  
    - Password: **123qwe!@#QWE**
    - Role Name: **Member** 

15. In Microsoft Edge, navigate to **http://localhost:[port]/Librarian/Index**.
    >**Note**: You are redirected to the **access denied** page. Only administrators are allowed to view the page. Also, note that the menu bar doesn't have a navigation tab for **Workers Portal**.

16. Close all Microsoft Edge windows.

>**Results**: After completing this exercise, you can add authorization to the application, and add configuration and the relevant attribute for role-based and claims-based policy authentication.


### Exercise 3: Avoid the Cross-Site Request Forgery Attack

#### Scenario

In this exercise, you will first write the Cross-Site Request Forgery attack in a separate project. You will then run the application and see the possible attack. Finally, you will avoid the Cross-Site Request Forgery attack by adding the **ValidateAntiForgeryToken** attribute in the **AccountController** class, run the application, and see that the attack is not possible.

The main tasks for this exercise are as follows:

1. Write the Cross-Site Request Forgery attack

2. Run the application – Now the attack is possible

3. Avoid the Cross-Site Request Forgery attack

4. Run the application – Now the attack is not possible


#### Task 1: Write the Cross-Site Request Forgery attack

1. Create a new folder with the following information:

    - Folder name: **Controllers**
    - Project: **CrossSiteRequestForgeryAttack**

2. Create a new controller with the following information:
   - Controller name: **HomeController**
   - Template: **MVC controller - Empty**
   - Folder: **CrossSiteRequestForgeryAttack/Controllers**

3. In **HomeController**, right-click the **Index** action name, and then click **Add View**.

4. Use the **Add MVC View** dialog box, create a new **View** with the following information:

    - View Name: **Index**
    - Template: **Empty (without model)**
    - Create as Partial View: **False**
    - Use a layout page: **False**

5. In the **Index.cshtml** view, after the **TITLE** element, add a **LINK** element, with the following information: 

    - Href: **~/css/style.css**
    - Rel: **stylesheet**

6. In the **BODY** element, add an **H1** element, with the following information: 

    - Content: **Cross-Site Request Forgery Attack**

7. Add an **H3** element, with the following information: 

    - Content: **Click - Submit to Perform the Attack**

8. Add a **FORM** element, with the following information: 

    - action: **http:<span>/</span>/localhost:[Port]/Account/Register?FirstName=Forgery_Attacker&LastName=Cross_Site&PhoneNumber=123&Email=attack@@.com&UserName=Forgery_Attacker&Password=123qwe!!!QWE123&RoleName=Member**
    - method: **post**

9. Inside the **FORM** element, add an **INPUT** element, with the following properties:

    - type: **Submit**
    - value: **Attack**

#### Task 2: Run the application – now the attack is possible

1. Save all the changes.

2. In Solution Explorer, right-click **Library**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

      >**Note**: The menu bar has a navigation tab for **Login**, meaning you are not logged in.

4. In Solution Explorer, right-click **CrossSiteRequestForgeryAttack**, point to **Debug**, and then click **Start new instance**.

5. On the **Cross-Site Request Forgery Attack** page, click **Attack**.

      >**Note**: The menu bar has a navigation tab for **Logout**, meaning you are logged in.

6. Close all Microsoft Edge windows.

7. In Microsoft Visual Studio, stop debugging.

#### Task 3: Avoid the Cross-Site Request Forgery attack

1. In the **AccountController** class, above the **Register** method, add a **ValidateAntiForgeryToken** attribute.

2. In the **LibrarianController** class, above the **AddBookPost** method, add a **ValidateAntiForgeryToken** attribute.

3. In the **LibraryController** class, above the **LendingBookPost** method, add a **ValidateAntiForgeryToken** attribute.


#### Task 4: Run the application – Now the attack is not possible

1. Save all the changes.

2. In Solution Explorer, right-click **Library**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

      >**Note**: The menu bar has a navigation tab for **Login**, meaning you are not logged in.

4. In Solution Explorer, right-click **CrossSiteRequestForgeryAttack**, point to **Debug**, and then click **Start new instance**.

5. On the **Cross-Site Request Forgery Attack** page, click **Attack**.

      >**Note**: HTTP 400 error was thrown.

6. Close all Microsoft Edge windows.

7. In Microsoft Visual Studio, stop debugging.

8. Close Microsoft Visual Studio.

>**Results**: After completing this exercise, you can avoid cross-site request forgery attacks.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
