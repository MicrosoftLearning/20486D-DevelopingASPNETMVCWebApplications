# Module 4: Developing Controllers

# Lesson 1: Writing Controllers and Actions

### Demonstration: How to Write Controllers and Actions

#### Preparation Steps

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod04\Democode\01_ControllersExample_begin**, and then double-click **ControllersExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **ControllersExample - Microsoft Visual Studio** window, right-click **Controllers** folder, point to  **Add**, and then click **Controller**.

2. In the **Add Scaffold** dialog box, click **MVC controller - Empty**, and then click **Add**.

3. In the **Controller Name** text box of the **Add Empty MVC Controller** dialog box, type **HomeController**, and then click **Add**.

4. In the **HomeController.cs** code window, locate the following code.

  ```cs
       using Microsoft.AspNetCore.Mvc;
```
5. Ensure that the mouse cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code.

  ```cs
       using ControllersExample.Models;
```
6. In the **HomeController** class code block, In the **Index** action code block, select the following code.

  ```cs
       return View();
```
7. Replace the selected code with the following code.

  ```cs
       ExampleModel model = new ExampleModel() { Sentence = "Welcome to module 4 demo 1" };
       return View(model);
```
8. Ensure that the cursor is at the end of the **Index** action code block, press Enter, and then type the following code.

  ```cs
       public IActionResult ParamExample(string id)
       {
       }
```
9. In the **ParamExample** action code block, type the following code.

  ```cs
        return Content("My param is: " + id);
```

10. Place the mouse cursor at the end of the **ParamExample** action code block, press Enter twice, and then type the following code.

  ```cs
        public IActionResult RouteDataExample()
        {
        }
```
11. In the **RouteDataExample** action code block, type the following code.

  ```cs
        string controller = (string)RouteData.Values["Controller"];
        string action = (string)RouteData.Values["action"];
        string id = (string)RouteData.Values["id"];
        return Content($"Action information: the action is in {controller} controller, the action name is {action} and the id value is {id}");
```

12. Place the mouse cursor at the end of the **RouteDataExample** action code block, press Enter twice, and then type the following code.

  ```cs
        public IActionResult ViewBagExample()
        {
        }
```
13. In the **ViewBagExample** action code block, type the following code.

  ```cs
        ViewBag.Message = "View Bag Example";
        return View();
```

14. Place the mouse cursor at the end of the **ViewBagExample** action code block, press Enter twice, and then type the following code.

  ```cs
        public IActionResult ViewDataExample()
        {
        }
```
15. In the **ViewDataExample** action code block, type the following code.

  ```cs
        ViewData["Message"] = "View Data Example";
        return View();
```
16. On the **FILE** menu of the **ControllersExample - Microsoft Visual Studio** window, click **Save Controllers\HomeController.cs**.

17. On the DEBUG menu of the **ControllersExample - Microsoft Visual Studio** window, click Start Debugging.

      >**Note:** The text **Welcome to module 4 demo 1** is the action result you added to the **Index** action.

19. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/home/ParamExample/2** and then press Enter, note the text **My param is: 2** is the content result you added in the **ParamExample** action.

20. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/home/RouteDataExample/4** and then press Enter, note the text **Action information: the action is in home controller, the action name is RouteDataExample and the id value is 4** is the content result you added in the **RouteDataExample** action.

21. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/home/ViewBagExample** and then press Enter, note the text **The Message is: View Bag Example** 
is the action result you added in the **ViewBagExample** action.

22. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/home/ViewDataExample** and then press Enter, note the text **The Message is: View Data Example** 
is the action result you added in the **ViewDataExample** action.

23. In the Microsoft Edge window, click **Close**.

24. On the **DEBUG** menu of the **ControllersExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

25. On the **FILE** menu of the **ControllersExample - Microsoft Visual Studio** window, click **Exit**.

# Lesson 2: Configuring Routes

### Demonstration: How to Add Routes
#### Preparation Steps

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod04\Democode\02_RoutesExample_begin**, and then double-click **RoutesExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane of the **RoutesExample - Microsoft Visual Studio** window, right-click **Controllers** folder, point to  **Add**, and then click **Controller**.

2. In the **Add Scaffold** dialog box, click **MVC controller - Empty**, and then click **Add**.

3. In the **Controller Name** text box of the **Add Empty MVC Controller** dialog box, type **HomeController**, and then click **Add**.

4. In the **HomeController** class code block, select the following code.

  ```cs
        public IActionResult Index()
        {
            return View();
        }
```
5. Replace the selected code with the following code.

  ```cs
        public IActionResult Index(int id = 50)
        {
            return Content("This is the Home controller with default param: " + id);
        }
```
6. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code.

  ```cs
        [Route("Hello/{name}/{lastName}")]
        public IActionResult Greeting(string name, string lastName)
        {
        }
```
7. In the **Greeting** action code block, type the following code.

  ```cs
        return Content($"Hello {name}-{lastName} from module 4 demo 2");
```
8. In the Solution Explorer pane of the **RoutesExample - Microsoft Visual Studio** window, right-click **Controllers** folder, point to  **Add**, and then click **Controller**.

9. In the **Add Scaffold** dialog box, click **MVC controller - Empty**, and then click **Add**.

10. In the **Controller Name** text box of the **Add Empty MVC Controller** dialog box, type **CalculatorController**, and then click **Add**.

11. In the **CalculatorController** class code block, select the following code.

  ```cs
        public IActionResult Index()
        {
            return View();
        }
```
12. Replace the selected code with the following code.

  ```cs
        public IActionResult MultByTwo(int num)
        {
            int result = num * 2;
            return Content(result.ToString());
        }
```
13. Ensure that the cursor is at the end of the **MultByTwo** action code block, press Enter twice, and then type the following code.

  ```cs
        [Route("Calc/Mult/{num1:int}/{num2:int}")]
        public IActionResult Mult(int num1, int num2)
        {
        }
```
14. In the **Mult** action code block, type the following code.

  ```cs
        int result = num1 * num2;
        return Content(result.ToString());
```

15. Ensure that the cursor is at the end of the **Mult** action code block, press Enter twice, and then type the following code.

  ```cs
        [HttpGet("Divide/{param?}")]
        public IActionResult DivideByTen(int param)
        {
        }
```
16. In the **DivideByTen** action code block, type the following code.

  ```cs
        int result = param / 10;
        return Content(result.ToString());
```
17. In the Solution Explorer pane of the **RoutesExample - Microsoft Visual Studio** window, click **Startup.cs**.

18. In the **Configure** method code block, type the following code. 

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
>**Note:** This code block represents a custom routes.

19. On the **FILE** menu of the **RoutesExample - Microsoft Visual Studio** window, click **Save All**.

20. On the DEBUG menu of the **RoutesExample - Microsoft Visual Studio** window, click Start Debugging.

      >**Note:**  The text **This is the Home controller with default param: 50** is the action result you added in the **Home** controller in the **Index** action.

22. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/hello/Gerald/Tesch** and then press Enter, note the text **Hello Gerald-Tesch from module 4 demo 2** is the action result you added in the **Home** controller in the **Greeting** action.

23. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Calculator/MultByTwo/4** and then press Enter, note the result **8** is the action result you added in the **Calculator** controller in the **MultByTwo** action.

24. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Calc/Mult/5/5** and then press Enter, note the result **25** is the action result you added in the **Calculator** controller in the **Mult** action.

25. In the Address bar of the **Microsoft Edge** window, type **http://localhost:[port]/Divide/100** and then press Enter, note the result **10** is the action result you added in the **Calculator** controller in the **DivideByTen** action.

26. In the Microsoft Edge window, click **Close**.

27. On the **DEBUG** menu of the **RoutesExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

28. On the **FILE** menu of the **RoutesExample - Microsoft Visual Studio** window, click **Exit**.

# Lesson 3: Writing Action Filters

### Demonstration: How to Create and Use Action Filters 

#### Preparation Steps

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod04\Democode\03_FiltersExample_begin**, and then double-click **FiltersExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane, right-click **FiltersExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Filters**, and then press Enter.

3. In the **Solution Explorer** pane of the **FiltersExample - Microsoft Visual Studio** window, right-click **Filters**, point to **Add**, and then click **Class**.

4. In the **Name** box of the **Add New Item – FiltersExample** dialog box, type **CustomActionFilter**, and then click Add.

5. In the **CustomActionFilter** class code window, locate the following code.

  ```cs
       using System.Threading.Tasks;
```
6. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using System.Diagnostics;
      using Microsoft.AspNetCore.Mvc;
      using Microsoft.AspNetCore.Mvc.Filters;
```
7. In the **CustomActionFilter** class code window, locate the following code.

  ```cs
       public class CustomActionFilter
```
8.  Append the following code to the existing line of code.

  ```cs
       : ActionFilterAttribute
```
9. In the **CustomActionFilter** class code block, press Enter and then type the following code.


  ```cs
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
```
10. In the **OnActionExecuting** action code block, type the following code.

  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        Debug.WriteLine(">>> "+actionName +" started, event fired: OnActionExecuting");
```

11. Ensure that the cursor is at the end of the **OnActionExecuting** action code block, press Enter twice, and then type the following code.

  ```cs
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {            
        }
```
12. In the **OnActionExecuted** action code block, type the following code.

  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        Debug.WriteLine(">>> "+actionName +" finished, event fired: OnActionExecuted");
```
13. Ensure that the cursor is at the end of the **OnActionExecuted** action code block, press Enter twice, and then type the following code.

  ```cs
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {   
        }
```
14. In the **OnResultExecuting** action code block, type the following code.

  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        Debug.WriteLine(">>> "+actionName + " before result, event fired: OnResultExecuting");
```

15. Ensure that the cursor is at the end of the **OnResultExecuting** action code block, press Enter twice, and then type the following code.

  ```cs
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {            
        }
```
16. In the **OnResultExecuted** action code block, type the following code.

  ```cs
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        ContentResult result = (ContentResult)filterContext.Result;
        Debug.WriteLine(">>> " + actionName + " result is: "+ result.Content + " ,event fired: OnResultExecuted");
```
17. In the **FiltersExample – Microsoft Visual Studio** window, In the Solution Explorer pane, double-click **HomeController.cs**.

18. In the **HomeController** code window, locate the following code.

  ```cs
        using Microsoft.AspNetCore.Mvc;
```
19. Ensure that the mouse cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code.

  ```cs
        using FiltersExample.Filters;
```
20. In the **HomeController** class code block, select the following code.

  ```cs
        public IActionResult Index()
        {
            return View();
        }
```
21. Replace the selected code with the following code.

  ```cs
        [CustomActionFilter]
        public IActionResult Index()
        {
            return Content("Welcome to module 4 demo 3");
        }
```
22. On the **FILE** menu of the **FiltersExample - Microsoft Visual Studio** window, click **Save All**.

23. On the DEBUG menu of the **FiltersExample - Microsoft Visual Studio** window, click Start Debugging.

24. On the taskbar, click the **FiltersExample - Microsoft Visual Studio** icon.

25. In the Output pane of the **FiltersExample (Running) - Microsoft Visual Studio** window, click the **Output** tab.

26. On the **Output** tab, locate the following line of code.

  ```cs
       >>> Index started, event fired: OnActionExecuting
       >>> Index finished, event fired: OnActionExecuted
       >>> Indexbefore result, event fired: OnResultExecuting
       >>> Index result is: Welcome to module 4 demo 3,event fired: OnResultExecuted
```
   >**Note:** In the above output lines, note that this is the CustomActionFilter class methods result. 

27. In the Microsoft Edge window, click **Close**.

28. On the **DEBUG** menu of the **FiltersExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

29. On the **FILE** menu of the **FiltersExample - Microsoft Visual Studio** window, click **Exit**.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.