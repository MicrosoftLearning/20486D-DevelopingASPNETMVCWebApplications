

# Module 1: Exploring ASP.NET Core MVC

# Lesson 3: Introduction to ASP.NET Core MVC 

### Demonstration: How to Explore an MVC Core Application

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Navigate to **Allfiles/Mod01/Democode/PhotoSharingSample**, and then open the **PhotoSharingSample.sln** file.

3. Run the **PhotoSharingSample.sln** application.

4. In the Address bar of the Microsoft Edge window, note the port number that appears after "http://localhost:" You will use the port number during this demonstration.

5. Close the Microsoft Edge window.

#### Demonstration Steps

1. In the Solution Explorer pane of the **PhotoSharingSample – Microsoft Visual Studio** window, expand **PhotoSharingSample**, and then note that the PhotoSharingSample application does not have the default.html, the default.aspx, or the default.cshtml files to act as a home page.

2. In the Solution Explorer pane, under PhotoSharingSample, expand **Controllers**, and then click **HomeController.cs**.

3. In the HomeController.cs code window, locate the following code.

  ```cs
        public IActionResult Index()
        {
            return View(_dbContext.Photos.ToList());
        }
```
>**Note:** This code block sends a list of Photos to the view 

4. In the Solution Explorer pane, expand **Views**, and then expand **Home**.

5. In the Solution Explorer pane, under Photo, click **Index.cshtml**.

6. In the Index.cshtml code window, locate the following code.

  ```cs
        <div>
        <span class="display-label">
            @Html.DisplayNameFor(model => model.Description):
        </span>
        <br />
        <span class="display-field">
             @Html.DisplayFor(model => item.Description)
        </span>
        </div>
```
>**Note:** This code block represents the View that renders the home page.

7. On the toolbar of the **PhotoSharingSample – Microsoft Visual Studio** window, click **Microsoft Edge**.

8. In the **http://localhost:[port]/** window, note that the default home page is displayed.

9. On the taskbar, click the **Microsoft Visual Studio** icon.

10. In the **PhotoSharingSample – Microsoft Visual Studio** window, in the Solution Explorer pane, click **Startup.cs**.

11. In the Startup.cs code window, locate the following code.

  ```cs
        app.UseMvcWithDefaultRoute();
```

>**Note:** This code block represents the default route that forwards requests to the specified controller.

12. On the taskbar, click the **Microsoft Edge** icon.

13. In the Address bar of the Microsoft Edge window, type the URL **http://localhost:[port]/home/index**, and then click **Go to**.

    >**Note:** The browser window displays the Home page of the **http://localhost:[port]/home/index** web application.

14. On the taskbar, click the **Microsoft Visual Studio** icon.

15. In the **PhotoSharingSample – Microsoft Visual Studio** window, in the Solution Explorer pane, expand **Models**, and then click **Photo.cs**.

16. In the Photo.cs code window, locate the following code.
 ```cs
        [Required]
        public string Title { get; set;}
```
   >**Note:** This code block represents the **Title** property for a photo stored in the application.

17. In the Solution Explorer pane, under Controllers, click **HomeController.cs**.

18. In the HomeController.cs code window, locate the following code.

  ```cs
        public class HomeController : Controller
```
   >**Note:** This code block represents that the **HomeController** class inherits the Controller  base  class which is in the namespace Microsoft.AspNetCore.Mvc.

19. In the HomeController.cs code window, locate the following code.

  ```cs
        FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
        byte[] fileBytes;
        using (BinaryReader br = new BinaryReader(fileOnDisk))
        {
              fileBytes = br.ReadBytes((int)fileOnDisk.Length);
        }
        return File(fileBytes, requestedPhoto.ImageMimeType);
```
   >**Note:** This code block represents the **GetImage** action of the PhotoController.

20. In the Solution Explorer pane, expand **Views**, expand **Home**, and then click **Index.cshtml**.

21. In the Index.cshtml code window, locate the following code.

  ```cs
        <div class="photo-display">
        <img class="photo-display-img" src="@Url.Action("GetImage", "Home", new { PhotoId = item.PhotoID })" />
        </div>
```
>**Note:**  The Razor view engine runs this code and renders the Photo Image.

22. On the taskbar, click the **Microsoft Edge** icon.

23. In the Address bar of the Microsoft Edge window, type **http://localhost:[port]**

    >**Note:** All the photos are displayed in the browser window. 

24. In the Microsoft Edge window, click **Close**.

25. In the **PhotoSharingSample (Running) – Microsoft Visual Studio** window, click **Close**.

26. On the **Microsoft Visual Studio** dialog click **Yes** to stop debugging.


