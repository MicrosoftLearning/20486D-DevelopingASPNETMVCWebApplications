# Module 10: Testing and Troubleshooting

# Lesson 1: Testing MVC Applications

### Demonstration: How to Run Unit Tests

#### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Go to **Allfiles\Mod04\Democode\10_UnitTestingExample_begin**, and then double-click **UnitTestingExample.sln**.

#### Demonstration Steps

1. In the **UnitTestingExample - Microsoft Visual Studio** window, In **Solution Explorer**, right-click **Solution 'UnitTestingExample'**, point to **Add**, and then click **New Project**.

2. In the **Add New Project** dialog box, click **MVC Controller - Empty**, and then click **Add**.

3. In the navigation pane of the **Add New Project** dialog box, expand **Installed**, expand **Visual C#**, and then click **.NET Core**.

4. In the result pane of the **Add New Project** dialog box, click **MSTest Test Project (.NET Core)**.

5. In the **Add New Project** dialog box, in the text box, type **ProductsWebsite.Tests**.



2. In the **NewFolder** text box, type **Controllers**, and then press Enter.

3. In the **ControllersExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click the **Controllers** folder, point to **Add**, and then click **Controller**.

4. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

5. In the **Add Empty MVC Controller** dialog box, in the **Controller name** text box, type **HomeController**, and then click **Add**.

6. In the **HomeController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```

7. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using ControllersExample.Models;
```

8. In the **HomeController** class code block, In the **Index** action code block, select the following code:
  ```cs
       return View();
```

9. Replace the selected code with the following code:
  ```cs
       ExampleModel model = new ExampleModel() { Sentence = "Welcome to module 4 demo 1" };
       return View(model);
```

10. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult ParamExample(string id)
       {
       }
```

11. In the **ParamExample** action code block, type the following code:
  ```cs
        return Content("My param is: " + id);
```

12. Place the cursor at the end of the **ParamExample** action code block, press Enter twice, and then type the following code:
  ```cs
        public IActionResult RouteDataExample()
        {
        }
```

13. In the **RouteDataExample** action code block, type the following code:
  ```cs
        string controller = (string)RouteData.Values["Controller"];
        string action = (string)RouteData.Values["action"];
        string id = (string)RouteData.Values["id"];
        return Content($"Action information: the action is in {controller} controller, the action name is {action} and the id value is {id}");
```

14. Place the cursor at the end of the **RouteDataExample** action code block, press Enter twice, and then type the following code:
  ```cs
        public IActionResult ViewBagExample()
        {
        }
```
15. In the **ViewBagExample** action code block, type the following code:
  ```cs
        ViewBag.Message = "ViewBag Example";
        return View();
```

16. Place the cursor at the end of the **ViewBagExample** action code block, press Enter twice, and then type the following code:
  ```cs
        public IActionResult ViewDataExample()
        {
        }
```

17. In the **ViewDataExample** action code block, type the following code:
  ```cs
        ViewData["Message"] = "ViewData Example";
        return View();
```

18. In the **ControllersExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save HomeController.cs**.

19. In the **ControllersExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

      >**Note:** The **Welcome to module 4 demo 1** text is the action result you added to the **Index** action.

20. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/home/ParamExample/2**, and then press Enter.

      >**Note:** The **My param is: 2** text is the content result you added in the **ParamExample** action.

21. In **Microsoft Edge**, the address bar, type **http://localhost:[port]/home/RouteDataExample/4**, and then press Enter.

      >**Note:** The **Action information: The action is in home controller, the action name is RouteDataExample and the id value is 4** text is the content result you added in the **RouteDataExample** action.

22. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/home/ViewBagExample**, and then press Enter.

      >**Note:** The **The Message is: ViewBag Example** text is the action result you added in the **ViewBagExample** action.

23. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/home/ViewDataExample**, and then press Enter.

      >**Note:** The **The Message is: ViewData Example** text is the action result you added in the **ViewDataExample** action.

24. In **Microsoft Edge**, click **Close**.

25. In the **ControllersExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

26. In the **ControllersExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.
