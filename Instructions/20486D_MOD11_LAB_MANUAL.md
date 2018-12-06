# Module 11: Managing Security

# Lab: Managing Security

#### Scenario

You have been asked to create a web-based library application for your organization's customers. The application should have a page showing the most recommended books, login and register pages, and ability to add books to the library for only authorized users. The application should contain Identity configuration, variety of different settings for authorization, and demonstration of cross-site request forgery attack.

#### Objectives

After completing this lab, you will be able to:

- Use Identity.
- Add Authorization.
- Avoid the Cross-Site Request Forgery Attack.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)


### Exercise 1: Use Identity

#### Scenario

In this exercise, you will first add entity framework database context to the **LibraryContext** class. You will then enable using identity in the **startup** class. After that you will add sign in, and register user logic. Finally, you will retrieve data from the identity property in the **LendingBook.cshtml** view.

The main tasks for this exercise are as follows:

1.	Add the Entity Framework database context.

2.	Enable using Identity.

3.	Add sign in logic.

4.	Add Register a user logic.

5.	Retrieve data from the Identity property.

6.	Run the application.


#### Task 1: Add the Entity Framework database context

1. Open the **Command Prompt** window using **Run as administrator**.

2. In Administrator: Command Prompt, run the following command: **cd &lt;The location of Allfiles\Mod11\Labfiles\01_Library_begin\Library folder on your machine&gt;**.

3. Run the following command: **npm install**.

4. Close the **Command Prompt** window.

5. Open the **Library.sln** solution from the following location: **Allfiles\Mod11\Labfiles\01_Library_begin**.

6. In the **User** class, add a **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.Identity**

7. Change the **User** class to inherit from the **IdentityUser** class.

8. In the **LibraryContext** class, add a **USING** statement for the following namespace:

   - **Microsoft.AspNetCore.Identity.EntityFrameworkCore**

9. Change the  **LibraryContext** class to inherit from the **IdentityDbContext&lt;User&gt;** class.

#### Task 2: Enable using Identity

1. In the **Startup** class, add **USING** statements for the following namespaces:

   - **Library.Models**
   - **Microsoft.AspNetCore.Identity**

2. In the beginning of the **ConfigureServices** method, call the **AddIdentity&lt;User, IdentityRole&gt;** method of **services** parameter.

3. Pass a **lambda expression** as a parameter to the **AddIdentity** method with the following information:

   - Lambda Expression: options => { }

4. In the  **lambda expression** code block, assign to the **options.Password.RequireDigit** property the value of **true**.

5. Assign to the **options.Password.RequiredLength** property the value of **7**.

6. Assign to the **options.Password.RequireUppercase** property the value of **true**.

7. Assign to the **options.User.RequireUniqueEmail** property the value of **true**.

8. Chain a **AddEntityFrameworkStores&lt;LibraryContext&gt;** method call to the **AddIdentity** method call.

9.  In the **Configure** method, after the call to the **UseStaticFiles** method, call the **UseAuthentication** method of the **app** parameter.

#### Task 3: Add sign in logic

1. Create a new **controller** with the following information:
   - Controller name: **AccountController**
   - Template: **API Controller - Empty**
   - Folder: **Controllers**

2. In the **AccountController** class, add **USING** statements for the following namespaces:

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
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **LoginPost**
    - Parameter: 
         - Type: **LoginViewModel**
         - Name: **loginModel**

11. Above the **LoginPost** method, add a **HttpPost** attribute.

12. Add a **ActionName** attribute. Pass **"Login"** as a parameter to the **ActionName** attribute.

13. Create an **IF** statement that checks that the value of the **ModelState.IsValid** field is **true**. 

14. In the **IF** statement code block, create a variable named **result** of type **var** and assign it with the value of **await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false)**

15. Create an **IF** statement that checks that the value of the **result.Succeeded** field is **true**.

16. In the nested **IF** statement code block, return the **Task&lt;IActionResult&gt;** result using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.

17. After the first **IF** statement code block, call the **AddModelError** method of the **ModelState** propery.  Pass **""** and **"Faild to Login"** as parameters to the **AddModelError** method.

18.  Return the **Task&lt;IActionResult&gt;** result using the **View** method. 

19. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **Logout**

20. In the **Logout** method, call the **_signInManager.SignOutAsync** method using the **await** keyword. 

21. Return the **Task&lt;IActionResult&gt;** result using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.


#### Task 4: Add Register a user logic

1. In the **AccountController** class, add a method with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Register**


2. In the **Register** method, return the **IActionResult** result using the **View** method. 

3. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **RegisterPost**
    - Parameter: 
         - Type: **RegisterViewModel**
         - Name: **registerModel**


4. Above the **RegisterPost** method, add a **HttpPost** attribute.

5. Add a **ActionName** attribute. Pass **"Register"** as a parameter to the **ActionName** attribute.

6. Create an **IF** statement that checks that the value of the **ModelState.IsValid** field is **true**.

7.  In the **IF** statement code block, create a variable named **user** of type **User** and initialize with the following information:
    - FirstName: **registerModel.FirstName**
    - LastName: **registerModel.LastName**
    - UserName: **registerModel.UserName**
    - PhoneNumber: **registerModel.PhoneNumber**
    - Email: **registerModel.Email**

8. Create a variable named **result** of type **var** and assign it with the value of **await _userManager.CreateAsync(user, registerModel.Password)**

9. Create an **IF** statement that checks that the value of the **result.Succeeded** field is **true**.

10. In the new **IF** statement code block, create a variable named **resultSignIn** of type **var** and assign it with the value of **await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password,registerModel.RememberMe,false)**

11. Create an **IF** statement that checks that the value of the **resultSignIn.Succeeded** field is **true**.

12. In the new **IF** statement code block, result using the **RedirectToAction** method. Pass **"Index"** and **"Library"** as parameters to the **RedirectToAction** method.

13. After the **IF** statement that checks that the value of the **result.Succeeded** field is **true**, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **error**
	- Collection: **result.Errors**

14.  In the **FOREACH** statement block, call the **AddModelError** method of the **ModelState** propery.  Pass **""** and **error.Description** as parameters to the **AddModelError** method.

15. After the **IF** statement that checks that the value of the **ModelState.IsValid** field is **true**, return the **Task&lt;IActionResult&gt;** result using the **View** method. 

16. Add a method with the following information:
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **AccessDenied**

17. In the **AccessDenied** method code block, return the **Task&lt;IActionResult&gt;** result using the **View** method. 


#### Task 5: Retrieve data from the Identity property

1. At the **LendingBook.cshtml** view, before the **DIV** element with the **"page-container"** class, add a **H1** element with the following information:

    - Class: **title**
    - Content: **Hello @User.Identity.Name - Lending Book Information**

2. In the **_Layout.cshtml** file, after the last **LI** element, create an **IF** statement that checks that the value of **User.IsInRole("Administrator")** is **true**. 

3. Inside the **IF** statement, add a **LI** element with the following information:

    - Class: **nav-item**

4. In the new **LI** element, add a **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Index", "Librarian")**
    - Content:  **Workers Portal**

5. After the **IF** statement, create an **IF** statement that checks that the value of **User.Identity.IsAuthenticated** is **true**. 

6.  Inside the new **IF** statement, add a **LI** element with the following information:

    - Class: **nav-item**

7. In the new **LI** element, add a **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Logout", "Account")**
    - Content:  **Logout**

8. After the new **IF** statement, create an **ELSE** statement. 

9.  Inside the **ELSE** statement, add a **LI** element with the following information:

    - Class: **nav-item**

10. In the new **LI** element, add a **A** element with the following information:

    - Class: **nav-link**
    - Href: **@Url.Action("Login", "Account")**
    - Content:  **Login**


#### Task 6: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In the menu bar, click **Our Books**.

4. On the **Login** page, click **Register**.

5. On **Register** page, register with the following credentials:
   
    - First Name: **_&lt;A first name of your choice&gt;_**
    - Last Name: **_&lt;A last name of your choice&gt;_**
    - Phone Number: **_&lt;A phone of your choice&gt;_** 
    - Email: **_&lt;An email time of your choice&gt;_** 
    - User Name: **_&lt;A user name of your choice&gt;_**  
    - Password: **_&lt;123qwe!@#QWE&gt;_** 

6. Click **Register**.

7. In the menu bar, click **Our Books**.
    >**Note:** Examine the page, you have been authorized to enter the **Our Books** page, and your user name data retrieved from the Identity prope

8. Select a book of your choice, and then click **Lend a Book**.

    >**Note:** The book you lended is not available anymore.

9. Close all **Microsoft Edge** windows.


>**Results**: After completing this exercise, you will be able to configure identity in the application, add logic to the sign in and register pages, and retrieve data from identity.



### Exercise 2: Add Authorization

#### Scenario

In this exercise, you will first add **AuthorizeAttribute** to the **LibraryController** class. You will then configure role-based and claim based policy authentication. And, you will add the relevant attribute in the **AccountController** class and in the **LibrarianController** class.

The main tasks for this exercise are as follows:

1. Add the AuthorizeAttribute to an action.

2. Add Role-based Policy Authentication.

3. Add Claim-based Policy Authentication.

4. Run the application.

#### Task 1: Add the AuthorizeAttribute to an action

1. 

#### Task 2: Add Role-based Policy Authentication

1. 

#### Task 3: Add Claim-based Policy Authentication

1. 

#### Task 4: Run the application

1. 

>**Results**: After completing this exercise, you will be able to add authorization in the application, add configuration and the relevant attribute for role-based and claim based policy authentication.


### Exercise 3: Avoid the Cross-Site Request Forgery Attack

#### Scenario

In this exercise, you will first write the cross-site request forgery attack in a separate project. You will then run the application and see the possible attack. Finaly, you will  avoid the cross-site request forgery attack by adding the **ValidateAntiForgeryToken** attribute in the **AccountController** class, run the application and see the attack is not possible.

The main tasks for this exercise are as follows:

1. Write the Cross-Site Request Forgery attack.

2. Run the application – now the attack is possible.

3. Avoid the Cross-Site Request Forgery attack.

4. Run the application – now the attack is not possible.


#### Task 1: Write the Cross-Site Request Forgery attack

1. 

#### Task 2: Run the application – now the attack is possible

1.

#### Task 3: Avoid the Cross-Site Request Forgery attack

1. 

#### Task 4: Run the application – now the attack is not possible

1. 

>**Results**: After completing this exercise, you will be able to avoid cross-site request forgery attack.



©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
