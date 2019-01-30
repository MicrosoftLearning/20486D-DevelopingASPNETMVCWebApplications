# Module 1: Exploring ASP.NET Core MVC

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lesson 3: Introduction to ASP.NET Core MVC 

### Demonstration: How to Explore an ASP.NET Core MVC Application

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course.
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

2. Navigate to **[Repository Root]\Allfiles\Mod01\Democode\01_PhotoSharingSample**, and then open the **PhotoSharingSample.sln**.

    >**Note**: If a **Security Warning for PhotoSharingSample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **PhotoSharingSample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this demonstration.

5. In Microsoft Edge, click **Close**.

#### Demonstration Steps

1. In the **PhotoSharingSample – Microsoft Visual Studio** window, in **Solution Explorer**, expand **PhotoSharingSample**.

    >**Note**: The PhotoSharingSample application  does not have **default.html**, **default.aspx** or **default.cshtml** to act as a home page.

2. In **Solution Explorer**, under **PhotoSharingSample**, expand **Controllers**, and then click **HomeController.cs**.

3. In the **HomeController.cs** code window, locate the following code:
  ```cs
       public IActionResult Index()
       {
          return View(_dbContext.Photos.ToList());
       }
```

>**Note**: This code block sends a list of photos to the view. 

4. In **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

5. In the **Index.cshtml** code window, locate the following code:
  ```cs
       @model IEnumerable<PhotoSharingSample.Models.Photo>
```

>**Note**: This code block represents how the view accepts the list of photos from the **Index** action.

6. In the **PhotoSharingSample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the default home page. You have reached the **Index** action of the **Home** controller.  
    
7. On the taskbar, click the **Microsoft Visual Studio** icon.

8. In the **PhotoSharingSample – Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

9. In the **Startup.cs** code window, locate the following code:
  ```cs
       app.UseMvcWithDefaultRoute();
```

>**Note**: This code block adds MVC to the request execution pipeline, with a default route which contains the following template: **{controller=Home}/{action=Index}/{id?}**.

10. On the taskbar, click the **Microsoft Edge** icon.

11. In Microsoft Edge, in the address bar, type the URL **http://localhost:[port]/home/index**, and then press Enter.

    >**Note**: The browser window displays the **Home** page of the **PhotoSharingSample** web application.

12. On the taskbar, click the **Microsoft Visual Studio** icon.

13. In the **PhotoSharingSample – Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **Photo.cs**.

14. In the **Photo.cs** code window, locate the following code:
  ```cs
       [Required]
       public string Title { get; set;}
```

>**Note**: This code block represents the **Title** property for a photo stored in the application.

15. In **Solution Explorer**, under **Controllers**, click **HomeController.cs**.

16. In the **HomeController.cs** code window, locate the following code:
  ```cs
       public class HomeController : Controller
```

>**Note**: This code block indicates that the **HomeController** inherits from the **Controller** base class, which is in the **Microsoft.AspNetCore.Mvc** namespace.

17. In the **HomeController.cs** code window, locate the following code:
  ```cs
       Photo requestedPhoto = _dbContext.Photos.FirstOrDefault(p => p.PhotoID == PhotoId);
       if (requestedPhoto != null)
       {
            string webRootpath = _environment.WebRootPath;
            string folderPath = "\\images\\";
            string fullPath = webRootpath + folderPath + requestedPhoto.PhotoFileName;

            FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return File(fileBytes, requestedPhoto.ImageMimeType);
       }
       else
       {
            return NotFound();
       }
```

>**Note**: This code block represents the **GetImage** action of the **HomeController** class.

18. In **Solution Explorer**, under **Views**, under **Home**, click **Index.cshtml**.

19. In the **Index.cshtml** code window, locate the following code:

  ```cs
       <div class="photo-display">
          <img class="photo-display-img" src="@Url.Action("GetImage", "Home", new { PhotoId = item.PhotoID })" />
       </div>
```

>**Note**: The Razor view engine runs this code and renders the **Photo** image.

20. In Microsoft Edge, click **Close**.

21. In the **PhotoSharingSample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
