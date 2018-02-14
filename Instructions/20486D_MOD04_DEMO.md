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
5. Click on the **Name** textbox, write  **Configure Middlewares Example**, In the **Location** textbox type **Allfiles\Mod03\Democode** and then click **OK**.
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
15. On the **DEBUG** menu of the **Configure Middlewares Example –  Microsoft Visual Studio** window, click **Start Debugging**.
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
22. On the **DEBUG** menu of the **Configure Middlewares Example –  Microsoft Visual Studio** window, click **Start Debugging**.
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
28. On the **DEBUG** menu of the **Configure Middlewares Example –  Microsoft Visual Studio** window, click **Start Debugging**.
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

