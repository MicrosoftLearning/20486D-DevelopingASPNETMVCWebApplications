# Module 3: Configure Middlewares and Services in ASP.NET Core

# Lesson 1: Configure Middlewares

### Demonstration: Creating Custom Middleware

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this) course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

#### Demonstration Steps
1. Start **Visual Studio 2017**.
2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.
3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.
4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**, 
5. Click on the **Name** textbox, write  **ConfigureMiddlewaresExample** and then click **OK**.
6. In the result pane of the **New ASP.NET Core Web Application**  dialog box, click **Empty**, and then click **OK**.
7. In the **Solution Explorer** window, double click on the **Startup.cs** class.
8. Locate the following code:
  ```cs
       app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
```
9. On the **DEBUG** menu of the **Configure Middlewares Example –  Microsoft Visual Studio** window, click **Start Debugging**.
10. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/dolev and press **Enter**.
11. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/shapira and press **Enter**. 
12. In the **Microsoft Edge** window, click **Close**.
13. On the **Debug** Menu, click **Stop Debugging**.
    >**Note** : Notice that no matter what is the url under the **localhost:[port]** domain, the result stays **Hello World!**.
14. Put the cursor at the end of the line above the app.Run, press enter and Insert the following code:
```cs
                app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
            });
```
>**Note** The context.Request.Path returns the subpath of the URL after the domain and port as can be seen in the following pattern: [protocol]://[domain]:[port]/[path]
15. On the **DEBUG** menu of the **ConfigureMiddlewaresExample –  Microsoft Visual Studio** window, click **Start Debugging**.
16. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/dolev and press enter.
17. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/shapira and press enter. 
18. In the **Microsoft Edge** window, click **Close**.
19. On the **Debug** Menu, click **Stop Debugging**.
     >**Note** : Notice that no matter what url under the **localhost:[port]** domain, the result is replaced to **Custom MiddleWare, Path = [URL Path]**, and the app.Run is ignored.
20. Put the cursor at the end of the following code you just typed:
```cs
                await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
```
21.  Press enter and type put the following code:
```cs
        await next.Invoke();
```
22. On the **DEBUG** menu of the **ConfigureMiddlewaresExample –  Microsoft Visual Studio** window, click **Start Debugging**.
23. In the **Microsoft Edge** window, click **Close**.
24. On the **Debug** Menu, click **Stop Debugging**.
     >**Note** : Now, the result is always: 
     **Custom MiddleWare, Path = [URL Path]**
     **"Hello World!"**
     Because the app.Run is now executed after the app.Use
25. Select the following code:
```cs
                app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
                await next.Invoke();
            });
```
26. right click and press **Cut**, and remove the empty line that was left.
27. Move the cursor right before the end of the Configure method, before the closing brackets, and press paste.
28. On the **DEBUG** menu of the **ConfigureMiddlewaresExample –  Microsoft Visual Studio** window, click **Start Debugging**.
29. In the **Microsoft Edge** window, click **Close**.
30. On the **Debug** Menu, click **Stop Debugging**.
     >**Note** : Now, the app.Use result is gone and only the app.Run works !
31. Select the following code:
  ```cs
       app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
```
32. right click and press **Cut**, and remove the empty line that was left.
33. Move the cursor right before the end of the Configure method,before the closing brackets,  and press paste.
34. On the Quick Access Toolbar, click **Save**.

### Demonstration: Working with Static Files

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this) course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

#### Demonstration Steps
1. Start **Visual Studio 2017**.
2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.
3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.
4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**, 
5. Click on the **Name** textbox, write  **StaticFilesExample**, click the **Location** textbox, write **Allfiles\Mod03\Democode\02_StaticFilesExample_begin\** and then click **OK**. 
6. In the result pane of the **New ASP.NET Core Web Application**  dialog box, click **Empty**, and then click **OK**.
7. In the **Solution Explorer** see that the **wwwroot** folder is empty.
8. On the **Windows Explorer** copy the **HtmlFile.html** and the **ImageFile.jpg** files from the **Allfiles\Mod03\Democode\02_StaticFilesExample_begin\** directory into the **Allfiles\Mod03\Democode\02_StaticFilesExample_begin\StaticFilesExample\StaticFilesExample\wwwroot** directory.
9. In the **Solution Explorer** see that the **wwwroot** folder contains both of the copied files (You might need to click the arrow next to it to see the files in its directory).
10. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.
11. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/HtmlFile.html and press enter.
12. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/ImageFile.jpg and press enter. 
13. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/NonExistingPath.jpg and press enter. 
 >**Note:** the app.Run is executed as always, and returns Hello World !
14. In the **Microsoft Edge** window, click **Close**.
15. On the **Debug** Menu, click **Stop Debugging**.
16. In the **Solution Explorer** window, double click on the **Startup.cs** class. 
17. Locate the following code:
  ```cs
       app.Run(async (context) =>
```
18. Put the cursor at the end of the line before the code that is shown above and write the following code:
 ```cs
app.UseStaticFiles();
```
19. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.
20. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/HtmlFile.html and press enter.
21. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/ImageFile.jpg and press enter. 
22. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/NonExistingPath.jpg and press enter. 
 >**Note:** Now the existing files are shown, and the nonexisting path leads to app.Run
23. In the **Microsoft Edge** window, click **Close**.
24. On the **Debug** Menu, click **Stop Debugging**.


# Lesson 2: Configure Services

### Demonstration: Using Dependency Injection

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this) course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

#### Demonstration Steps
1. Start **Visual Studio 2017**.
2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.
3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.
4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**, 
5. Click on the **Name** textbox, write  **ConfigureServiceExample** and then click **OK**. 
6. In the result pane of the **New ASP.NET Core Web Application**  dialog box, click **Empty**, and then click **OK**.
7. In the **Solution Explorer**, Right click on the **ConfigureServiceExample** project file, point to **Add**, and click **Class**.
8. In the **Add New Item** dialog window, inside the **Name** textbox type **ComplexCalculator** and press **Add**.
9. Inside the class, type the following code:
```cs
		public string ComplexCalculation()
        {
            return "Complex calculation result";
        }
```
10. On the Quick Access Toolbar, click **Save**.
11. Right click on the **ComplexCalculator** class name,  click **Quick Actions and Refactorings...** and then click **Extract Interface**.
12. In the **Extract Interface** dialog window leave all the default values and press **OK**.
13. In the **Solution Explorer**, double click the **Startup.cs** file.
14. Inside the empty **ConfigureServices** method after the opening brackets, press enter and type **services.AddSingleton<IComplexCalculator, ComplexCalculator>();**
15. Replace the **Configure** method parameter definitions by replacing the following code:
```cs
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
```
With the code below:
```cs
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IComplexCalculator calc)
```
16. Inside the **Configure** method, locate the following code:
```cs
		await context.Response.WriteAsync("Hello World!");
```
Replace it with the code below:
```cs
		await context.Response.WriteAsync(calc.ComplexCalculation());
```
17. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.
 >**Note:** The returned result is the method of the **ComplexCalculator** class we did **not** create. It was generated by the asp.net core framework which gave us the instance from the **Configure** method parameter.
18. In the **Microsoft Edge** window, click **Close**.
19. On the **Debug** Menu, click **Stop Debugging**.





