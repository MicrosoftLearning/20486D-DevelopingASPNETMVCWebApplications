# Module 4: Developing Controllers

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lesson 1: Writing Controllers and Actions

### Demonstration: How to Write Controllers and Actions

#### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course.

2. Navigate to **[Repository Root]\Allfiles\Mod04\Democode\01_ControllersExample_begin**, and then open the **ControllersExample.sln**.

    >**Note**: If a **Security Warning for ControllersExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **ControllersExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this demonstration.

5. In Microsoft Edge, click **Close**.

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod04\Democode\01_ControllersExample_begin** and double-click **ControllersExample.sln**.
    
    >**Note**: If a **Security Warning for ControllersExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In Solution Explorer, right-click **ControllersExample**, point to **Add**, and then select **New Folder**.

3. In the **NewFolder** box, type **Controllers**, and then press Enter.

4. In the **ControllersExample - Microsoft Visual Studio** window, in Solution Explorer, right-click the **Controllers** folder, point to **Add**, and then select **Controller**.

5. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

6. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **HomeController**, and then click **Add**.

7. In the **HomeController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```

8. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using ControllersExample.Models;
```

9. In the **HomeController** class code block, in the **Index** action code block, select the following code:
  ```cs
       return View();
```

10. Replace the selected code with the following code:
  ```cs
       ExampleModel model = new ExampleModel() { Sentence = "Welcome to module 4 demo 1" };
       return View(model);
```

11. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult ParamExample(string id)
       {
       }
```

12. In the **ParamExample** action code block, type the following code:
  ```cs
        return Content("My param is: " + id);
```

13. Place the cursor at the end of the **ParamExample** action code block, press Enter twice, and then type the following code:
  ```cs
        public IActionResult RouteDataExample()
        {
        }
```

14. In the **RouteDataExample** action code block, type the following code:
  ```cs
        string controller = (string)RouteData.Values["Controller"];
        string action = (string)RouteData.Values["action"];
        string id = (string)RouteData.Values["id"];
        return Content($"Action information: the action is in {controller} controller, the action name is {action} and the id value is {id}");
```

15. Place the cursor at the end of the **RouteDataExample** action code block, press Enter twice, and then type the following code:
  ```cs
        public IActionResult ViewBagExample()
        {
        }
```
16. In the **ViewBagExample** action code block, type the following code:
  ```cs
        ViewBag.Message = "ViewBag Example";
        return View();
```

17. Place the cursor at the end of the **ViewBagExample** action code block, press Enter twice, and then type the following code:
  ```cs
        public IActionResult ViewDataExample()
        {
        }
```

18. In the **ViewDataExample** action code block, type the following code:
  ```cs
        ViewData["Message"] = "ViewData Example";
        return View();
```

19. In the **ControllersExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save HomeController.cs**.

20. In the **ControllersExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: The **Welcome to module 4 demo 1** text is the action result you added to the **Index** action.

21. In Microsoft Edge, in the address bar, type **http://localhost:[port]/home/ParamExample/2**, and then press Enter.

      >**Note**: The **My param is: 2** text is the content result you added in the **ParamExample** action.

22. In Microsoft Edge, in the address bar, type **http://localhost:[port]/home/RouteDataExample/4**, and then press Enter.

      >**Note**: The **Action information: The action is in home controller, the action name is RouteDataExample and the id value is 4** text is the content result you added in the **RouteDataExample** action.

23. In Microsoft Edge, in the address bar, type **http://localhost:[port]/home/ViewBagExample**, and then press Enter.

      >**Note**: The **The Message is: ViewBag Example** text is the action result you added in the **ViewBagExample** action.

24. In Microsoft Edge, in the address bar, type **http://localhost:[port]/home/ViewDataExample**, and then press Enter.

      >**Note**: The **The Message is: ViewData Example** text is the action result you added in the **ViewDataExample** action.

25. In Microsoft Edge, click **Close**.

26. In the **ControllersExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Configuring Routes

### Demonstration: How to Add Routes
#### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 

2. Navigate to **[Repository Root]\Allfiles\Mod04\Democode\02_RoutesExample_begin**, and then open the **RoutesExample.sln**.

    >**Note**: If a **Security Warning for RoutesExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **RoutesExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this demonstration.

5. In Microsoft Edge, click **Close**. 

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod04\Democode\02_RoutesExample_begin** and double-click **RoutesExample.sln**.

    >**Note**: If a **Security Warning for RoutesExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In Solution Explorer, right-click **RoutesExample**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** box, type **Controllers**, and then press Enter.

4. In the **RoutesExample - Microsoft Visual Studio** window, in Solution Explorer, right-click the **Controllers** folder, point to **Add**, and then click **Controller**.

5. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

6. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **HomeController**, and then click **Add**.

7. In the **HomeController** class code block, select the following code:
  ```cs
        public IActionResult Index()
        {
            return View();
        }
```

8. Replace the selected code with the following code:
  ```cs
        public IActionResult Index(int id = 50)
        {
            return Content("This is the Home controller with default param: " + id);
        }
```

9. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code:
  ```cs
        [Route("Hello/{firstName}/{lastName}")]
        public IActionResult Greeting(string firstName, string lastName)
        {
        }
```

10. In the **Greeting** action code block, type the following code:
  ```cs
        return Content($"Hello {firstName} {lastName} from module 4 demo 2");
```

11. In the **RoutesExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Controllers** folder, point to **Add**, and then click **Controller**.

12. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

13. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **CalculatorController**, and then click **Add**.

14. In the **CalculatorController** class code block, select the following code:
  ```cs
        public IActionResult Index()
        {
            return View();
        }
```

15. Replace the selected code with the following code:
  ```cs
        public IActionResult MultByTwo(int num)
        {
            int result = num * 2;
            return Content(result.ToString());
        }
```

16. Ensure that the cursor is at the end of the **MultByTwo** action code block, press Enter twice, and then type the following code:
  ```cs
        [Route("Calc/Mult/{num1:int}/{num2:int}")]
        public IActionResult Mult(int num1, int num2)
        {
        }
```

17. In the **Mult** action code block, type the following code:
  ```cs
        int result = num1 * num2;
        return Content(result.ToString());
```

18. Ensure that the cursor is at the end of the **Mult** action code block, press Enter twice, and then type the following code:
  ```cs
        [HttpGet("Divide/{param?}")]
        public IActionResult DivideByTen(int param)
        {
        }
```

19. In the **DivideByTen** action code block, type the following code:
  ```cs
        int result = param / 10;
        return Content(result.ToString());
```

20. In the **RoutesExample - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

21. In the **Configure** method code block, type the following code:
```cs
        app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "firstRoute",
                    template: "{controller}/{action}/{num:int}");

                routes.MapRoute(
                    name: "secondRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
```

22. In the **RoutesExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

23. In the **RoutesExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

      >**Note**: The browser window displays the **This is the Home controller with default param: 50** message. You reached the **Index** action of the **Home** controller because of a convention-based route.

24. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Hello/Gerald/Tesch**, and then press Enter.

      >**Note**: The browser window displays the **Hello Gerald Tesch from module 4 demo 2** message. You reached the **Greeting** action of the **Home** controller because of an attribute-based route.

25. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Calculator/MultByTwo/4**, and then press Enter.

      >**Note**: The browser window displays **8**. You reached the **MultByTwo** action of the **Calculator** controller because of a convention-based route.

26. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Calc/Mult/5/5**, and then press Enter.

      >**Note**: The browser window displays **25**. You reached the **Mult** action of the **Calculator** controller because of an attribute-based route.

27. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Divide/100**, and then press Enter.

      >**Note**: The browser window displays **10**. You reached the **DivideByTen** action of the **Calculator** controller because of an attribute-based route.

28. In Microsoft Edge, in the address bar, type **http://localhost:[port]/Divide**, and then press Enter.

      >**Note**: The browser window displays **0**. Because no value was provided to **param**, it received the value **0**. 

29. In Microsoft Edge, click **Close**.

30. In the **RoutesExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Writing Action Filters

### Demonstration: How to Create and Use Action Filters 

#### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course.

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod04\Democode\03_FiltersExample_begin** and double-click **FiltersExample.sln**.

    >**Note**: If a **Security Warning for FiltersExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In Solution Explorer, right-click **FiltersExample**, point to **Add**, and then click **New Folder**.

3. In **NewFolder** box, type **Filters**, and then press Enter.

4. In the **FiltersExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Filters**, point to **Add**, and then click **Class**.

5. In the **Add New Item – FiltersExample** dialog box, in the **Name** box, type **CustomActionFilter**, and then click **Add**.

6. In the **CustomActionFilter** class code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```

7. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using System.Diagnostics;
      using Microsoft.AspNetCore.Mvc;
      using Microsoft.AspNetCore.Mvc.Filters;
```

8. In the **CustomActionFilter** class code window, locate the following code:
  ```cs
       public class CustomActionFilter
```

9.  Append the following code to the existing line of code:
  ```cs
       : ActionFilterAttribute
```

10. In the **CustomActionFilter** class code block, press Enter, and then type the following code:
  ```cs
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
```

11. In the **OnActionExecuting** action code block, type the following code:
  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        Debug.WriteLine(">>> " + actionName + " started, event fired: OnActionExecuting");
```

12. Ensure that the cursor is at the end of the **OnActionExecuting** action code block, press Enter twice, and then type the following code:
  ```cs
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {            
        }
```

13. In the **OnActionExecuted** action code block, type the following code:
  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        Debug.WriteLine(">>> " + actionName + " finished, event fired: OnActionExecuted");
```

14. Ensure that the cursor is at the end of the **OnActionExecuted** action code block, press Enter twice, and then type the following code:
  ```cs
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {   
        }
```

15. In the **OnResultExecuting** action code block, type the following code:
  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        Debug.WriteLine(">>> " + actionName + " before result, event fired: OnResultExecuting");
```

16. Ensure that the cursor is at the end of the **OnResultExecuting** action code block, press Enter twice, and then type the following code:
  ```cs
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {            
        }
```

17. In the **OnResultExecuted** action code block, type the following code:
  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        ContentResult result = (ContentResult)filterContext.Result;
        Debug.WriteLine(">>> " + actionName + " result is: " + result.Content + " , event fired: OnResultExecuted");
```

18. In the **FiltersExample – Microsoft Visual Studio** window, expand **Controllers**, and then click **HomeController.cs**.

19. In the **HomeController** code window, locate the following code:
  ```cs
        using Microsoft.AspNetCore.Mvc;
```

20. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
        using FiltersExample.Filters;
```

21. In the **HomeController** class code block, select the following code:
  ```cs
        public IActionResult Index()
        {
            return View();
        }
```

22. Replace the selected code with the following code:
  ```cs
        [CustomActionFilter]
        public IActionResult Index()
        {
            return Content("Welcome to module 4 demo 3");
        }
```

23. In the **FiltersExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

24. In the **FiltersExample - Microsoft Visual Studio** window, on the **DEBUG** menu, point to **Windows** and, then click **Output**.

25. In the **FiltersExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

26. On the taskbar, click **FiltersExample - Microsoft Visual Studio**.

27. In the **FiltersExample - Microsoft Visual Studio** window, in the **Output** pane, click the **Output** tab.

28. On the **Output** tab, in the **Show output from** box, click **Debug**.

29. On the **Output** tab, locate the following lines of code:
  ```cs
       >>> Index started, event fired: OnActionExecuting
       >>> Index finished, event fired: OnActionExecuted
       >>> Index before result, event fired: OnResultExecuting
       >>> Index result is: Welcome to module 4 demo 3, event fired: OnResultExecuted
```
   >**Note**: The text above was generated by the calls to the **Debug.WriteLine** method in the **CustomActionFilter** class.

30. In Microsoft Edge, click **Close**.

31. In the **FiltersExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2019 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.