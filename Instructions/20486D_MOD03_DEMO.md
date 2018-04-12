# Module 3: Configure Middleware and Services in ASP.NET Core

# Lesson 1: Configuring Middleware

### Demonstration: How to Create Custom Middleware

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.


#### Demonstration Steps

1. Start **Visual Studio 2017**.

2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.

3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.

4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**.

5. In the **Name** box, replace **WebApplication1** with **ConfigureMiddlewareExample**, and then click **OK**.

6. In the result pane of the **New ASP.NET Core Web Application** dialog box, click **Empty**, and then click **OK**.

7. In the **Solution Explorer** pane, click **Startup.cs**.

8. In the **Startup.cs** code window, locate the following code.

```cs
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
```

9. On the **DEBUG** menu of the **Configure Middleware Example –  Microsoft Visual Studio** window, click **Start Debugging**.

10. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/UrlTest1, and press **Enter**.

    >**Note** : The result returns **Hello World!** from the **app.Run**.

11. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/UrlTest2, and press **Enter**. 

    >**Note** : The result returns **Hello World!** from the **app.Run**.

12. In the **Microsoft Edge** window, click **Close**.

13. On the **DEBUG** Menu, click **Stop Debugging**.

14. In the **Startup.cs** code window, locate the following code.
```cs
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
```

15. Place the mouse cursor at the end of the code, press Enter twice, and then type the following code.
```cs
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
    });
```
>**Note** The value of context.Request.Path.Value is part of the URL that contains the subfolders and files. For example: http://localhost:[port]/[**context.Request.Path.Value**]

16. On the **DEBUG** menu of the **ConfigureMiddlewareExample –  Microsoft Visual Studio** window, click **Start Debugging**.

17. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/UrlTest1, and press Enter.
     >**Note** : The result is **Custom MiddleWare, Path = [URL Path]**, and the **app.Run** is ignored.

18. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/UrlTest2 , and press Enter. 
     >**Note** : The result is **Custom MiddleWare, Path = [URL Path]**, and the **app.Run** is ignored.

19. In the **Microsoft Edge** window, click **Close**.

20. On the **DEBUG** Menu, click **Stop Debugging**.

21. In the **Startup.cs** code window, locate the following code.
```cs
    await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
```

22. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    await next.Invoke();
```

23. On the **DEBUG** menu of the **ConfigureMiddlewareExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     >**Note** : Now, the result is: 
     **Custom MiddleWare, Path = [URL Path]**
     **"Hello World!"**

24. In the **Microsoft Edge** window, click **Close**.

25. On the **DEBUG** Menu, click **Stop Debugging**.

26. In the **Startup.cs** code window, select the following code.
```cs
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
        await next.Invoke();
    });
```

27. Right-click on the selected code, then press **Cut**, and remove any empty lines that were left.

28. In the **Startup.cs** code window, locate the following code.
```cs
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
```

29. Place the mouse cursor at the end of the code, press Enter, right-click the specified location, and click **Paste**.

31. On the **DEBUG** menu of the **ConfigureMiddlewareExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     >**Note** : Now, the **app.Use** result is gone, and only the **app.Run** works !

32. In the **Microsoft Edge** window, click **Close**.

33. On the **DEBUG** Menu, click **Stop Debugging**.

34. Select the following code.
```cs
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
```

35. right-click, press **Cut**, and remove any empty lines that were left.

36. In the **Startup.cs** code window, locate the following code.
```cs
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Custom MiddleWare, Path = " + context.Request.Path.Value + Environment.NewLine);
                await next.Invoke();
    });
```

36. Place the mouse cursor at the end of the code, press Enter, right-click the specified location, and click **Paste**.

37. On the Quick Access Toolbar, click **Save**.


# Lesson 1: Configuring Middleware

### Demonstration: How to Work with Static Files

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.


#### Demonstration Steps

1. Start **Visual Studio 2017**.

2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.

3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.

4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**.

5. In the **Name** box, replace **WebApplication1** with **StaticFilesExample**.

6.  In the **Location** textbox, write **Allfiles\Mod03\Democode\02_StaticFilesExample_begin**, and then click **OK**. 

7. In the result pane of the **New ASP.NET Core Web Application** dialog box, click **Empty**, and then click **OK**.

8. In the **Solution Explorer** see that the **wwwroot** folder is empty.

9.  In the **File Explorer** window, go to **Allfiles\Mod03\Democode\02_StaticFilesExample_begin**.
    
10.  In the **02_StaticFilesExample_begin** window, select the **HtmlFile.html** and the **ImageFile.jpg** files.
 
 11. On the **HtmlFile.html** and **ImageFile.jpg** selected files, press right-click, and then click **Copy**.
    
11.  In the **File Explorer** window, go to **Allfiles\Mod03\Democode\02_StaticFilesExample_begin\StaticFilesExample\StaticFilesExample\wwwroot**.
    
12.  In the **wwwroot** window, right-click an empty space, and then click **Paste**.
      >**Note:** In the **Solution Explorer** see that the **wwwroot** folder contains both of the copied files (You might need to expand the wwwroot directory to see the files).

13. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.

14. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/HtmlFile.html, and press Enter.
     >**Note:** Only the **app.Run** is executed returns **Hello World** !

15. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/ImageFile.jpg, and press Enter. 
     >**Note:** Only the **app.Run** is executed returns **Hello World** !

16. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/NonExistingPath.jpg, and press Enter. 
     >**Note:** Only the **app.Run** is executed returns **Hello World** !

17. In the **Microsoft Edge** window, click **Close**.

18. On the **DEBUG** Menu, click **Stop Debugging**.

19. In the **Solution Explorer** pane, click **Startup.cs**.

20. In the **Startup.cs** code window, locate the following code.
```cs
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

```

21. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    app.UseStaticFiles();
```

22. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.

23. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/HtmlFile.html, and press Enter.
     >**Note:** The HTML file is shown

24. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/ImageFile.jpg, and press Enter. 
     >**Note:** The image file is shown

25. In the **Microsoft Edge**, Change the URL path to http://localhost:[port]/NonExistingPath.jpg, and press Enter. 
     >**Note:** The nonexisting path leads eventualy to **app.Run**.

26. In the **Microsoft Edge** window, click **Close**.

27. On the **DEBUG** Menu, click **Stop Debugging**.


# Lesson 2: Configuring Services

### Demonstration: How to Use Dependency Injection

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.


#### Demonstration Steps

1. Start **Visual Studio 2017**.

2. On the **FILE** menu of the **Start Page - Microsoft Visual Studio** window, point to **New**, and then click **Project**.

3. In the navigation pane of the **New Project** dialog box, expand **Installed**, and then click **Visual C#**.

4. In the result pane of the **New Project** dialog box, click **ASP.NET Core Web Application**.

5. In the **Name** box, replace **WebApplication1** with **ConfigureServiceExample**, and then click **OK**. 

6. In the result pane of the **New ASP.NET Core Web Application** dialog box, click **Empty**, and then click **OK**.

7. In the Solution Explorer pane of the **ConfigureServiceExample - Microsoft Visual Studio** window, right-click on the **ConfigureServiceExample** project file, point to **Add**, and then click **New Folder**.

8.	In the Solution Explorer pane, name the newly created folder as **Services**, and then press Enter.

9. In the Solution Explorer pane, right-click **Services**, point to **Add**, and then click **Class**.

10. In the **Add New Item** dialog window, inside the **Name** textbox type **Logger**, and press **Add**.

11.  In the **Logger.cs** code window, locate the following code.
```cs
    using System.Threading.Tasks;
```

12. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    using System.IO;
    using ConfigureServiceExample.Services; 
 ```

13. Place the mouse cursor within the **Logger** class block, press Enter, and then type the following code.
```cs
    string _filename;
```

14. Place the mouse cursor at the end of the **_filename** variable, press Enter twice, and then type the following code.
```cs
    public Logger()
    {
    }
```

15. Place the mouse cursor within the constructor code block you just created, and then type the following code.
```cs
    _filename = $"{DateTime.Now.ToString("yyyy-dd-MM--HH-mm-ss")}.log";
```
>**Note:** Each Logger class instance will create a new log file. The log file name will be the logger class instance creation date.

16. Place the mouse cursor at the end of the **Logger** constructor, press Enter twice, and then type the following code.
```cs
    public void Log(string logData)
    {
        File.AppendAllText(_filename, $"{DateTime.UtcNow}: {logData}");
    }
```
>**Note:** Calling Log from the same Logger instance will turn to the same file.

17. On the Quick Access Toolbar, click **Save**.

18. In the **Logger.cs** code window, locate the following code.
```cs
public class Logger
```

19. Right-click on the **Logger** class name,  click **Quick Actions and Refactorings...**, and then click **Extract Interface**.

20. In the **Extract Interface** dialog window leave all the default values as they are, and press **OK**.

21. In the **Solution Explorer** pane, double click the **Startup.cs**.

22. Place the mouse cursor within the **ConfigureServices** method block, press Enter, and then type the following code.
```cs
    services.AddSingleton<ILogger, Logger>();
```

23. In the **Startup.cs** code window, select the following code.
```cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
```

24. Replace the code you selected with the following code.
```cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger log)
```

25. Inside the **Configure** method, locate the following code.
```cs
    app.Run(async (context) =>
    {
```

26. Place the mouse cursor at the end of the code, press Enter, and then type the following code.
```cs
    log.Log("Logged line");
```

27. On the **DEBUG** menu of the **StaticFilesExample –  Microsoft Visual Studio** window, click **Start Debugging**.
     >**Note:** The log class instance was created by **Dependency Injection**.

28. In the **Microsoft Edge** window, click **Close**.

29. On the **DEBUG** Menu, click **Stop Debugging**.

30. In the **Solution Explorer** pane, double click the newly created **XXXX-XX-XX--XX-XX-XX.log** file.
     >**Note:** File text: **[DateTime]: Logged Line**. The text was created by the Log method that is inside the Logger class.
     
