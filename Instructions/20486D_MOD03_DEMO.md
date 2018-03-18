# Module 3: Configure Middlewares and Services in ASP.NET Core

# Lesson 1: Configure Middlewares

### Demonstration: How to Create Custom Middlewares

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.


#### Demonstration Steps

1. Start **Visual Studio 2017**.

2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.

3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.

4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**.

5. In the **Name** box, replace **WebApplication1** with **ConfigureMiddlewaresExample**, and then click **OK**.

6. In the result pane of the **New ASP.NET Core Web Application**  dialog box, click **Empty**, and then click **OK**.

7. In the **Solution Explorer** pane, double click on the **Startup.cs** class.

8. Locate the following code:

```cs
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
```

9. On the **DEBUG** menu of the **Configure Middlewares Example –  Microsoft Visual Studio** window, click **Start Debugging**.

10. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/UrlTest1, and press **Enter**.

    >**Note** : The result returns **Hello World!** from the app.Run.

11. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/UrlTest2, and press **Enter**. 

    >**Note** : The result returns **Hello World!** from the app.Run.

12. In the **Microsoft Edge** window, click **Close**.

13. On the **Debug** Menu, click **Stop Debugging**.

14. Locate the following code:
```cs
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
```

15. Place the mouse cursor at the end of the code, press Enter twice, and then type the following code:
```cs
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
    });
```
>**Note** The value of context.Request.Path.Value is part of the url that contains the subfolders and files. For example: http://localhost:[port]/[**context.Request.Path.Value**]

16. On the **DEBUG** menu of the **ConfigureMiddlewaresExample –  Microsoft Visual Studio** window, click **Start Debugging**.

17. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/UrlTest1, and press enter.
     >**Note** : The result is to **Custom MiddleWare, Path = [URL Path]**, and the app.Run is ignored.

18. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/UrlTest2 , and press enter. 
     >**Note** : The result is to **Custom MiddleWare, Path = [URL Path]**, and the app.Run is ignored.

19. In the **Microsoft Edge** window, click **Close**.

20. On the **Debug** Menu, click **Stop Debugging**.

21. Put the cursor at the end of the following code you just typed:
```cs
    await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
```

22.  Press enter and type put the following code:
```cs
    await next.Invoke();
```

23. On the **DEBUG** menu of the **ConfigureMiddlewaresExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     >**Note** : Now, the result is: 
     **Custom MiddleWare, Path = [URL Path]**
     **"Hello World!"**

24. In the **Microsoft Edge** window, click **Close**.

25. On the **Debug** Menu, click **Stop Debugging**.

26. Select the following code:
```cs
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
        await next.Invoke();
    });
```

27. right click, press **Cut**, and remove the empty line that was left.

28. Move the cursor right before the end of the Configure method, before the closing brackets, and press paste.

29. On the **DEBUG** menu of the **ConfigureMiddlewaresExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     >**Note** : Now, the app.Use result is gone, and only the app.Run works !

30. In the **Microsoft Edge** window, click **Close**.

31. On the **Debug** Menu, click **Stop Debugging**.

32. Select the following code:
```cs
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
```

33. right click, press **Cut**, and remove the empty line that was left.

34. Move the cursor right before the end of the Configure method,before the closing brackets,  and press paste.

35. On the Quick Access Toolbar, click **Save**.


### Demonstration: How to Work with Static Files

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

#### Demonstration Steps

1. Start **Visual Studio 2017**.

2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.

3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.

4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**.

5. In the **Name** box, replace **WebApplication1** with **StaticFilesExample**.

7.  In the **Location** textbox, write **Allfiles\Mod03\Democode\02_StaticFilesExample_begin**, and then click **OK**. 

8. In the result pane of the **New ASP.NET Core Web Application**  dialog box, click **Empty**, and then click **OK**.

9. In the **Solution Explorer** see that the **wwwroot** folder is empty.

10. On the **Windows Explorer** copy the **HtmlFile.html** and the **ImageFile.jpg** files from the **Allfiles\Mod03\Democode\02_StaticFilesExample_begin** directory into the **Allfiles\Mod03\Democode\02_StaticFilesExample_begin\StaticFilesExample\StaticFilesExample\wwwroot** directory.

11. In the **Solution Explorer** see that the **wwwroot** folder contains both of the copied files (You might need to click the arrow next to it to see the files in its directory).

12. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.

13. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/HtmlFile.html, and press enter.

     >**Note:** Only the app.Run is executed returns Hello World !

14. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/ImageFile.jpg, and press enter. 

     >**Note:** Only the app.Run is executed returns Hello World !

15. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/NonExistingPath.jpg, and press enter. 

     >**Note:** Only the app.Run is executed returns Hello World !

16. In the **Microsoft Edge** window, click **Close**.

17. On the **Debug** Menu, click **Stop Debugging**.

18. In the **Solution Explorer** pane, double click on the **Startup.cs** class.

19. In the **Startup.cs** code window, locate the following code:

```cs
    app.Run(async (context) =>
```

18. Place the mouse cursor at the end of the code, press Enter, and then type the following code.

```cs
    app.UseStaticFiles();
```

19. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.

20. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/HtmlFile.html, and press enter.

     >**Note:** The html file is shown

21. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/ImageFile.jpg, and press enter. 

     >**Note:** The image file is shown

22. In the **Microsoft Edge**, Change the url path to http://localhost:[port]/NonExistingPath.jpg, and press enter. 

     >**Note:** The nonexisting path leads eventualy to app.Run

23. In the **Microsoft Edge** window, click **Close**.

24. On the **Debug** Menu, click **Stop Debugging**.


# Lesson 2: Configure Services

### Demonstration: How to Use Dependency Injection

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.


#### Demonstration Steps

1. Start **Visual Studio 2017**.

2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.

3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.

4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**.

5. In the **Name** box, replace **WebApplication1** with **ConfigureServiceExample**, and then click **OK**. 

6. In the result pane of the **New ASP.NET Core Web Application**  dialog box, click **Empty**, and then click **OK**.

7. In the Solution Explorer pane of the **ConfigureServiceExample - Microsoft Visual Studio** window,right click on the **ConfigureServiceExample** project file, point to **Add**, and then click **New Folder**.

2.	In the Solution Explorer pane, name the newly created folder as **Services**, and then press Enter.

8. In the **Solution Explorer** pane, right click on the **Services** folder, point to **Add**, and click **Class**.

9. In the **Add New Item** dialog window, inside the **Name** textbox type **Logger**, and press **Add**.

10. In the Logger.cs code window, place the mouse cursor at the end of the **System.Threading.Tasks** namespace code, press Enter, and then type the following code:

```cs
    using System.IO;
 ```

10. Put the cursor between the opening and the closing brackets of the empty class, press enter, and create the following variable:

```cs
    string filename;
```

11. Place the mouse cursor at the end of the code, press Enter twice, and then type the following code:

```cs
    public Logger()
    {
    }
```

12. Place the mouse cursor within the constructor code block you just created, and then type the following code.

```cs
    filename = $"{DateTime.Now.ToString("yyyy-dd-MM--HH-mm-ss")}.log";
```
>**Note:** Each Logger class instance will create a new log file. The log file name will be the logger class instance creation date.

13. Place the cursor at the end of the line of the closing bracket of the constructor, press enter twice, and type the following code:

```cs
    public void Log(string logData)
    {
        File.AppendAllText(filename, $"{DateTime.UtcNow}: {logData}");
    }
```
>**Note:** Calling Log from the same Logger instance will turn to the same file.

15. On the Quick Access Toolbar, click **Save**.

16. Right click on the **Logger** class name,  click **Quick Actions and Refactorings...**, and then click **Extract Interface**.

17. In the **Extract Interface** dialog window leave all the default values as they are, and press **OK**.

18. In the **Solution Explorer** pane, double click the **Startup.cs** file.

19. Place the mouse cursor within the  **ConfigureServices**  method block, press enter, and then type the following code.
```cs
    services.AddSingleton<ILogger, Logger>();
```

20. In the **Startup.cs** code window, locate the following code, and then select the code.

```cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
```

 21. Replace the code you selected with the following code

```cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger log)
```

22. Inside the **Configure** method, locate the following code:

```cs
    app.Run(async (context) =>
    {
```

23. Place the mouse cursor at the end of the code, press Enter, and then type the following code:

```cs
    log.Log("Logged line");
```

24. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.

     >**Note:** The log class instance was created by **Dependency Injection**.

25. In the **Microsoft Edge** window, click **Close**.

26. On the **Debug** Menu, click **Stop Debugging**.

27. In the **Solution Explorer** pane, double click the new created **XXXX-XX-XX--XX-XX-XX.log** file.

28. See the **[DateTime]: Logged Line** text shown inside the file.
     >**Note:** This log line was written by the Log method that is inside the Logger class.
