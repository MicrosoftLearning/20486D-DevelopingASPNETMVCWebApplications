# Module 9: Client-Side Development

# Lesson 1: Applying Styles

### Demonstration: How to Work with Bootstrap 

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

#### Demonstration Steps

1. Navigate to **Allfiles\Mod09\Democode\01_BootstrapExample_begin**, and then double-click **BootstrapExample.sln**.

2. In the **BootstrapExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Views**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** text box, type **Shared**, and then press Enter.

4. In the **BootstrapExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

5. In the **Add New Item – BootstrapExample** dialog box, click **Web**, and then, in the result pane, click **Razor Layout**, and click **Add**.

6. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```

7. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css">
       <link href="~/css/style.css" rel="stylesheet" />
```

8. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

9. Place the cursor before the **<** (less then) sign of the **&lt;div&gt;** tag, press Enter, press the Up Arrow key, and then type the following code:
  ```cs
       <div>
           <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
           <span class="navbar-brand mb-0 h1">Your Book Library</span>
           <div class="collapse navbar-collapse" id="navbarNavDropdown">
               <ul class="navbar-nav">
               </ul>
            </div>
        </nav>
       </div>
```

10. In the **UL** element of the **_Layout.cshtml** code window, type the following code:
  ```cs
       <li class="nav-item active">
           <a class="nav-link" href="@Url.Action("Index", "Library")">Home <span class="sr-only">(current)</span></a>
       </li>
       <li class="nav-item dropdown">
           <a href="# class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               Genres
           </a>
           <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
               <a class="dropdown-item" href="@Url.Action("GetScienceFictionBooks", "Library")">Science fiction</a>
               <a class="dropdown-item" href="@Url.Action("GetDramaBooks", "Library")">Drama</a>
           </div>
       </li>
```

11. In the **_Layout.cshtml** file, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

12. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code: 
  ```cs
       <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
       <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
       <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
       <script src="~/js/alert-function.js"></script>
```

13. In the **_Layout.cshtml** file, select the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```

14. Replace the selected code with the following code:
  ```cs
       <div class="container">
           @RenderBody()
       </div>
```

15. In the **BootstrapExample - Microsoft Visual Studio** window, in the **Solution Explorer**, expand **Controllers**, and then click **LibraryController.cs**.

16. In the **LibraryController.cs** code window, locate the following code, right-click the code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```

17. In the **Add MVC View** dialog box, ensure that the name in the **View name** box is **Index**.

18. In the **Template** selector, ensure that the template in the **Template** box is **Empty(without model)**.

19. In the **Add MVC View** dialog box, ensure that the **Reference script libraries** check box is not selected.

      >**Note:** In the **Add MVC View** dialog box, the **Reference script libraries** checkbox can be edited by setting the **Template** to **Edit**.

20. In the **Add MVC View** dialog box, ensure that the **Use a layout page** check box is selected, and then click **Add**.

21. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

22. Replace the selected code with the following code:
  ```cs
       <div class="text-center">
           <h1>Welcome to Open Library </h1>
           <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
               Launch modal example
           </button>
       </div>
```

23. In the **Index.cshtml** code window, place the cursor immediately the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter twice, and then type the following code:
  ```cs
       <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
           <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Your Book Library</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Welcome to the book library
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
           </div>
       </div>
```

24. In the **BootstrapExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

25. In the **Add New Item – BootstrapExample** dialog box, click **Web**, and then, in the result pane, click **Razor View**.

26. In the **Name** box of the **Add New Item – BootstrapExample** dialog box, type **_Alert**, and then click **Add**.

27. In the **_Alert.cshtml** code window, select the following code:
  ```cs
       @*
          For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
       *@
       @{
       }
```

28. Replace the selected code with the following code:
  ```cs
       <section>
           <h2 class="m-2">Did you like the book you borrowed? </h2>
           <button type="button" class="btn btn-outline-success">Yes</button>
           <button type="button" class="btn btn-outline-danger">No</button>
           <div id="alert" class="alert alert-success alert-dismissible fade show m-3" role="alert">
           </div>
       </section>
```

29. In the **DIV** element of the **_Alert.cshtml** code window, type the following code:
  ```cs
       <strong>Thank you for the response!</strong>
       We will take this into consideration the next time we recommend you a book.
       <button type="button" class="close" aria-label="Close">
           <span aria-hidden="true">&times;</span>
       </button>
```
30. On the **FILE** menu of the **BootstrapExample - Microsoft Visual Studio** window, click **Save All**.

31. On the **DEBUG** menu of the **BootstrapExample - Microsoft Visual Studio** window, click **Start Debugging**.

32. In the **Home** page, click **Lunch modal example**, and then click **Close**.

33. In the menu bar click **Genres**, and then click **Drama**. 

34. In the **Drama Books** page, click **Yes**, and examine the **alert** that appears.

      >**Note:** In the **Drama Books** page, to close the message press the small X on the side.

35. In the **Microsoft Edge** window, click **Close**.

36. On the **DEBUG** menu of the **BootstrapExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

37. On the **FILE** menu of the **BootstrapExample - Microsoft Visual Studio** window, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.