# Module 11: Managing Security

# Lesson 1: Authentication in ASP.NET Core 

### Demonstration: How to use ASP.NET Core Identity

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. In the **File Explorer**, navigate to **Allfiles\Mod11\Democode\01_IdentityExample_begin\IdentityExample**, and then copy the address in the address bar.

2. Go to **Start**, and then type **cmd**.

3. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

4. In the **User Account Control** dialog box, click **Yes**.

5. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note:** If the **{copied folder path}** is different from the disk drive where the **Command Prompt** is located, then you should type **{disk drive}:** before typing the **cd  {copied folder path}** command.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note:** If warning messages are shown in the **Command Prompt** you can ignore them.

7. Close the window.

8. In the **File Explorer**, navigate to **Allfiles\Mod11\Democode\01_IdentityExample_begin**, and then double-click **IdentityExample.sln**.


9. In the **IdentityExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

10. In the **IdentityExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note:** Examine the page.

11. In the **IdentityExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

12. In the **Startup.cs** code window, in the **ConfigureServices** method, place the cursor after the **{** (opening braces) sign, press Enter, and then type the following code:
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
13. In the **Startup.cs** code window, in the **Configure** method, locate the following code:
  ```cs
       app.UseStaticFiles();
```

14. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       app.UseAuthentication();
```
15. In the **IdentityExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **StudentController.cs**.

16. In the **StudentController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
          return View();
       }
```

17. Replace the selected code with the following code:
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

18. 123qwe!@#QWE