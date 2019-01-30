# Module 8: Using Layouts, CSS and JavaScript in ASP.NET Core MVC

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Using Layouts, CSS and JavaScript in ASP.NET Core MVC

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Applying a Layout and Link Views to it 

#### Task 1: Create a layout

1. Navigate to **[Repository Root]\Allfiles\Mod08\Labfiles\01_ZooSite_begin**, and then double-click **ZooSite.sln**.

    >**Note**: If a **Security Warning for ZooSite** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** box, type **Shared**, and then press Enter.

4. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, right-click **Shared**, point to **Add**, and then click **New Item**.

5. In the **Add New Item – ZooSite** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

6. In the **Add New Item – ZooSite** dialog box, in the result pane, click **Razor Layout**, and then click **Add**.

7. In the **_Layout.cshtml** code window, place the cursor after the **>** (greater than) sign of the **&lt;body&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <ul class="nav">
          <li><a href="@Url.Action("Index", "Zoo")">Attractions</a></li>
          <li><a href="@Url.Action("VisitorDetails", "Zoo")">Visitor Info</a></li>
          <li><a href="@Url.Action("BuyTickets", "Zoo")">Tickets</a></li>
       </ul>
```
8. Place the cursor after the **>** (greater  than) sign of the **&lt;/ul&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <div class="header-container">
          <h1 class="content">Welcome to Zoo Center</h1>
          <div class="slider-buttons">
              <img src="~/images/prevArrow.png" class="prev" onclick="prevImage()" />
              <img src="~/images/nextArrow.png" class="next" onclick="nextImage()" />
          </div>
       </div>
```

#### Task 2: Add a view and link it to a layout

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **ZooController.cs**.

2. In the **ZooController.cs** code window, right-click the following code, and then click **Add View**.
  ```cs
       public IActionResult Index()
```
3. In the **Add MVC View** dialog box, ensure that the value in the **View name** box is **Index**.

4. In the **Add MVC View** dialog box, ensure that the **Empty (without model)** template is selected.

5. In the **Add MVC View** dialog box, ensure that the **Create as a partial view** check box is cleared and the **Use a layout page** check box is selected, and then click the  **...** (browse) button.

6. In the **Select a Layout Page** dialog box, under **Project folders**, expand **Views**, and then click **Shared**.

7. In the **Select a Layout Page** dialog box, under **Contents of folder**, click **_Layout.cshtml**, and then click **OK**.

8. In the **Add MVC View** dialog box, click **Add**.

9. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model IEnumerable<ZooSite.Models.Photo>
```

10. In the **Index.cshtml** code window, select the following code:
  ```cs
       <h2>Index</h2>
```

11. Replace the selected code with the following code:
  ```cs
       <h1 class="main-title">Zoo Attractions</h1>
       <div class="container">
       </div>
```

12. In the **Index.cshtml** code window, in the **DIV** element, type the following code:
  ```cs
       @foreach (var item in Model)
       {
       }
```

13. Place the cursor in the **FOREACH** code block, press Enter, and then type the following code:
  ```cs
       <div class="photo-index-card">
            @if (item.PhotoFileName != null)
            {
                <div class="image-wrapper">
                    <img class="photo-display-img" src="@Url.Action("GetImage", "Zoo", new { PhotoId = item.PhotoID })" />
                </div>
            }
            <h3 class="display-picture-title">
                @Html.DisplayFor(modelItem => item.Title)
            </h3>
            <div>
                <span class="display">
                    @Html.DisplayFor(model => item.Description)
                </span>
            </div>
       </div>
```

#### Task 3: Add _ViewStart.cshtml

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **Views**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – ZooSite** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

3. In the **Add New Item – ZooSite** dialog box, in the result pane, click **Razor View Start**, and then click **Add**.

4. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, expand **Zoo**, and then click **Index.cshtml**.

5. In the **Index.cshtml** code window, delete the following code:
  ```cs
       Layout = "~/Views/Shared/_Layout.cshtml";
```
#### Task 4: Add existing views to the web application

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, right-click **Zoo**, point to **Add**, and then click **Existing Item**.

2. In the **Add Existing Item - ZooSite** dialog box, go to **[Repository Root]\Allfiles\Mod08\Labfiles\ZooViews**, select all **.cshtml** files, and then click **Add**.

#### Task 5: Add a section to the layout
1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Shared**, click **_Layout.cshtml**.

2. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <div>
           @RenderBody()
       </div>
```
3. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code: 
  ```cs
       @RenderSection("Scripts", false)
```

#### Task 6: Run the application

1. In the **ZooSite – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ZooSite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the **Index.cshtml** file content, but the HTML content is not designed by a CSS file yet.

3. In the menu bar, click **Visitor Info**.

    >**Note**: Examine the browser content.

4. In the menu bar, click **Tickets**.

    >**Note**: Examine the browser content.

5. In Microsoft Edge, click **Close**.

>**Results**: After completing this exercise, you will be able to add a layout and link views to it. You will also be able to use the **_ViewStart** file in the web application.  

### Exercise 2: Using CSS 

#### Task 1: Add an existing CSS file to the project

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **css**, and then press Enter.

3. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **css**, point to **Add**, and then click **Existing Item**.

4. In the **Add Existing Item - ZooSite** dialog box, go to **[Repository Root]\Allfiles\Mod08\Labfiles\ZooCSS**, click **zoo-style.css**, and then click **Add**.

5. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, under **css**, click **zoo-style.css**.

    >**Note**: Examine the content of the file.

6. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

7. In the **Startup.cs** code window, locate the following code:
  ```cs
       zooContext.Database.EnsureDeleted();
       zooContext.Database.EnsureCreated();
```

8. Place the cursor after the located code, press Enter twice, and then type the following code:
  ```cs
       app.UseStaticFiles();
```

#### Task 2: Link the layout to the CSS file

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Shared**, click **_Layout.cshtml**.

2. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <title>@ViewBag.Title</title>
```
3. Place the cursor after the **>** (greater than) sign of the **&lt;/title&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <link type="text/css" rel="stylesheet" href="~/css/zoo-style.css"/>
```
#### Task 3: Style the menu

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, under **css**, click **zoo-style.css**.

2. In the **zoo-style.css** code window, locate the following code: 
  ```cs
       .slider-buttons img {
          width: 50px;
          height: 50px;
       }
```
3. Place the cursor after the **}** (closing brace) sign, press Enter twice, and then type the following code:
  ```cs
       .nav {
          list-style-type: none;
          margin: 0;
          padding: 0;
          overflow: hidden;
          background-color: #85754e;
          position: fixed;
          top: 0;
          left: 0;
          width: 100%;
       }

       .nav li {
          float: left;
       }
```
4. Place the cursor immediately after the last typed **}** (closing brace) sign, press Enter twice, and then type the following code:
  ```cs
       .nav li a {
          display: block;
          color: white;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
       }

       .nav li a:hover:not(.active) {
          background-color: #016b6b;
       }

       .active {
          background-color: #008484;
          color: #fff;
       }
```
#### Task 4: Style the photos section in Index.cshtml

1. In the **zoo-style.css** code window, locate the following code:
  ```cs
       .active {
          background-color: #008484;
          color: #fff;
       }
```
2. Place the cursor after the **}** (closing brace) sign, press Enter twice, and then type the following code:
  ```cs
       .photo-index-card {
          background-color: #ffffff;
          padding: 0;
          margin: 10px 5px 15px 18px;
          padding-bottom: 25px;
          width: 355px;
          border: 1px solid #d6d4d4;
          border-radius: 10px;
          overflow: hidden;
       }
```
#### Task 5: Style a form in BuyTickets.cshtml

1. In the **zoo-style.css** code window, locate the following code:
  ```cs
       .photo-index-card {
          background-color: #ffffff;
          padding: 0;
          margin: 10px 5px 15px 18px;
          padding-bottom: 25px;
          width: 355px;
          border: 1px solid #d6d4d4;
          border-radius: 10px;
          overflow: hidden;
       }
```

2. Place the cursor after the **}** (closing brace) sign, press Enter twice, and then type the following code:
  ```cs
       .info .form-field {
          text-align:left;
          clear: both;
       }

       .info .form-field div {
          width: 172px;
          text-align: right;
          float: right;
       }

       .info label {
          width: 118px;
          display: inline-block;
          margin-bottom: 10px;
       }

       .info input{
          border-radius: 2px;
          line-height: 20px;
          border: 1px solid #ccc6c6;
          background-color: #f9f6f6;
          width: 100%;
       }
```

3. Place the cursor immediately after the last typed **}** (closing brace) sign, press Enter twice, and then type the following code:
  ```cs
       input.submit-btn {
          width: 100px;
          margin-top: 12px;
          height: 29px;
          background-color: orange;
          font-weight: bold;
          box-shadow: inset 0px 0px 4px #b77006;
          border: 1px solid #a59797;
       }

       input.submit-btn[disabled] {
          opacity: 0.8;
          background-color: whitesmoke;
          box-shadow: none;
       }
```

#### Task 6: Run the application

1. In the  **ZooSite – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ZooSite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the content of the **Index.cshtml** file, with HTML content that is designed by a CSS file.

3. In the **Zoo Attractions** page, in the **Welcome to Zoo Center** header, click the **right arrow**.

    >**Note**: Currently, clicking the button has no effect since no JavaScript code has been added the web application yet.

4. In the menu bar, click **Visitor Info**.

    >**Note**: Examine the browser content.

5. In the menu bar, click **Tickets**.

6. On **Step 1 - Choose Tickets**, in the **Adult** box, select _&lt;as many tickets as you like&gt;,_ in the **Child** box, select _&lt;as many tickets as you like&gt;,_ and then in the **Senior** box, select _&lt;as many tickets as you like&gt;._

    >**Note**: Currently the total cost of the tickets is not shown on the page since no JavaScript code has been added to the web application yet.

7. On **Step 2 - Buy Tickets**, in the **First Name** box, type _&lt;A first name of your choice&gt;._

8. On **Step 2 - Buy Tickets**, in the **Last Name** box, type _&lt;A last name of your choice&gt;._

9. On **Step 2 - Buy Tickets**, in the **Address** box, type _&lt;An address of your choice&gt;._

10. On **Step 2 - Buy Tickets**, in the **Email** box, type **abcd**.

11. On **Step 2 - Buy Tickets**, in the **Phone** box, type _&lt;A phone of your choice&gt;,_ and then click **Buy**.

    >**Note**: Currently you can't buy the tickets and there is no validation since the functionality has not applied yet.

12. In Microsoft Edge, click **Close**.

>**Results**: After completing this exercise, you will be able to add an existing CSS file to a web application, and add a link from a layout to the CSS file. You will also be able to add new CSS selectors to a CSS file.

### Exercise 3: Using JavaScript

#### Task 1: Add a JavaScript file

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **js**, and then press Enter.

3. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

4. In the **Add New Item – ZooSite** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

5. In the **Add New Item – ZooSite** dialog box, in the result pane, click **JavaScript File**.

6. In the **Add New Item – ZooSite** dialog box, in the **Name** box, type **form-functions**, and then click **Add**.

#### Task 2: Link a view to the JavaScript file

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Zoo**, click **BuyTickets.cshtml**.

2. In the **BuyTickets.cshtml** code window, locate the following code:
  ```cs
       @section Scripts {
       }
```
3.  Place the cursor after the **{** (opening brace) sign, press Enter, and then type the following code: 
  ```cs
       <script src="~/js/form-functions.js"></script>
```
#### Task 3: Write the code of the JavaScript file

1. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, under **js**, click **form-functions.js**.

2. In the **form-functions.js** code window, type the following code:
  ```cs
       function calculateSum() {
          var rows = document.querySelectorAll("#totalAmount tr .sum");
          var sum = 0;

          for (var i = 0; i < rows.length; i++) {
              sum = sum + parseFloat(parseFloat(rows[i].innerHTML.substring(1, rows[i].innerHTML.length)).toFixed(2));
          }

          document.getElementById("sum").innerHTML = "Total: $" + sum;
       }
```

>**Results**: After completing this exercise, you will be able to add a JavaScript file and write the JavaScript code. 

### Exercise 4: Using jQuery

#### Task 1: Use npm to add jQuery

1. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **ZooSite**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – ZooSite** dialog box, in the search box, type **npm**, and then press Enter.

3. In the **Add New Item – ZooSite** dialog box, in the result pane, click **npm Configuration File**, and then click **Add**.

4. In the **package.json** code window, locate the following code:
  ```cs
       "devDependencies": {
       }
```
5. Place the cursor after the **}** (closing brace) sign, and then type the following code:

  ```cs
       ,
       "dependencies": {
           "jquery": "3.3.1"
       }
```

6. In the **ZooSite - Microsoft Visual Studio** window, on the **FILE** menu, click **Save package.json**.

7. Wait for the **Microsoft Visual Studio** dialog box to appear, and then click **Yes to All**.

    >**Note**: In Solution Explorer, under **Dependencies**, a new folder named **npm** has been added, which contains the **jquery** package.

8. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, in **Explorer Toolbar Options** click **Show All Files**.

      >**Note**: In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, a new folder named **node_modules** has been added, which contains the **jquery** package.

9. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **ZooSite**, point to **Add**, and then click **New Folder**.

10. In the **NewFolder** box, type **Middleware**, and then press Enter.

11. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, right-click **Middleware**, point to **Add**, and then click **Class**.

12. In the **Add New Item – ZooSite** dialog box, in the **Name** box, type **ApplicationBuilderExtensions**, and then click **Add**.

13. In the **ApplicationBuilderExtensions.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
14. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using System.IO;
       using Microsoft.AspNetCore.Builder;
       using Microsoft.Extensions.FileProviders;
```

15. In the **ApplicationBuilderExtensions.cs** code window, select the following code:
  ```cs
      public class ApplicationBuilderExtensions
```

16. Replace the selected code with the following code:
  ```cs
      public static class ApplicationBuilderExtensions
```

17. In the **ApplicationBuilderExtensions.cs** code block, place the cursor after the second **{** (opening brace) sign, press Enter, and then type the following code:
  ```cs
       public static IApplicationBuilder UseNodeModules(this IApplicationBuilder applicationBuilder, string root)
       {
          var path = Path.Combine(root, "node_modules");
          var fileProvider = new PhysicalFileProvider(path);

          var options = new StaticFileOptions();
          options.RequestPath = "/node_modules";
          options.FileProvider = fileProvider;

          applicationBuilder.UseStaticFiles(options);
          return applicationBuilder;
       }
```

18. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

19. In the **Startup.cs** code window, locate the following code:
  ```cs
       using ZooSite.Data;
```
20. Ensure that the cursor is at the end of the **ZooSite.Data** namespace, press Enter, and then type the following code:
  ```cs
       using ZooSite.Middleware;
```

21. In the **Startup.cs** code window, locate the following code:
  ```cs
       app.UseStaticFiles();
```

22. Place the cursor after the located code, press Enter twice, and then type the following code:
  ```cs
       app.UseNodeModules(env.ContentRootPath);
```

23. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Shared**, click **_Layout.cshtml**.

24. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <link type="text/css" rel="stylesheet" href="~/css/zoo-style.css"/>
```

25. Place the cursor after the **>** (greater than) sign, press Enter, and then type the following code: 
  ```cs
       <script src="~/node_modules/jquery/dist/jquery.min.js"></script>
```

#### Task 2: Use jQuery to add event handlers

1. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, under **js**, click **form-functions.js**.

2. In the **form-functions.js** code window, locate the following code:
  ```cs
          document.getElementById("sum").innerHTML = "Total: $" + sum ;
       }
```
3. Place the cursor after the **}** (closing brace) sign, press Enter, and then type the following code: 
  ```cs
       $(function() {

       });
```
4. In the **form-functions.js** code window, select the following code, and then click **Cut**.
  ```cs
       function calculateSum() {
          var rows = document.querySelectorAll("#totalAmount tr .sum");
          var sum = 0;

          for (var i = 0; i < rows.length; i++) {
              sum = sum + parseFloat(parseFloat(rows[i].innerHTML.substring(1, rows[i].innerHTML.length)).toFixed(2));
          }

          document.getElementById("sum").innerHTML = "Total: $" + sum ;
       }
```

5. In the **form-functions.js** code window, locate the following code:
  ```cs
       $(function() {
```

6. Ensure that the cursor is after the **{** (opening brace) sign, press Enter, and then click **Paste**.

7. In the **form-functions.js** code window, locate the following code:
  ```cs
       $(function() {
```

8. Ensure that the cursor is after the **{** (opening brace) sign, press Enter, and then type the following code:
  ```cs
       $('.pricing select').change(function(event) {
       });
``` 

9. In the **form-functions.js** code window, locate the following code:
  ```cs
       $('.pricing select').change(function(event) {
```

10. Place the cursor after the **{** (opening brace) sign of the typed code, press Enter, and then type the following code: 
  ```cs
       var target = $(event.target);
       var value = parseInt(target.val());
       var container = target.parent();
       var price = container.prev();
       var label = price.prev();
 
       $("#" + label.text()).remove();
```

#### Task 3: Use jQuery to modify elements

1. In the **form-functions.js** code window, locate the following code:
  ```cs
       $("#" + label.text()).remove();
```
2. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       if (value) {
       }
```

3. Place the cursor within the **IF** code block, and then type the following code:
  ```cs
       $("#summery").addClass("display-div").removeClass("hidden-div");

       var correctCost = (price.text().substring(1, price.text().length));
       var calc = parseInt(value * correctCost);

       var msg = label.text() + " ticket - " + value.toString() + "x" + price.text() + " = <span class='sum'>" +'$' + calc + '</span>';
       var row = $("<tr id='" + label.text() +"'>");
       row.append($("<td>").html(msg));
       $("#totalAmount").append(row);
```

4. In the **form-functions.js** code window, locate the following code:
  ```cs
           $("#totalAmount").append(row);
       }
```

5. Place the cursor after the **}** (closing brace) sign, press Enter, and then type the following code: 
  ```cs
       if ($("#totalAmount tr").length === 0) {
           $("#summery").addClass("hidden-div").removeClass("display-div");
           $("#formButtons input").attr('disabled', 'disabled');
           $("#comment").show();
       } 
       else {
           $("#formButtons input").removeAttr('disabled');
           $("#comment").hide();
       }
        
       calculateSum();
```

6. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

7. In the **Add New Item – ZooSite** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

8. In the **Add New Item – ZooSite** dialog box, in the **Name** box, type **menubar-functions**, and then click **Add**.

9. In the **menubar-functions.js** code window, type the following code:
  ```cs
       $(function() {
          var path = window.location.pathname;

          $(".nav li a").each(function (index, value) {
              var href = $(value).attr('href');
              if (path === href) {
                  $(this).closest('li').addClass('active');
              }
          });
       });
```

10. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

11. In the **Add New Item – ZooSite** dialog box, click **Web**, and then in the result pane, click **JavaScript File**.

12. In the **Add New Item – ZooSite** dialog box, in the **Name** box, type **slider-functions**, and then click **Add**.

13. In the **slider-functions.js** code window, type the following code:
  ```cs
      var images = ['/images/header.jpg', '/images/waters.jpg'];
      var current = 0;

      function nextImage() {
          current++;
          if (current === images.length) {
              current = 0;
          }
          $('.header-container').css('background-image', 'url(' + images[current] + ')');
      }

      function prevImage() {
          current--;
          if (current < 0) {
              current = images.length-1;
          }
          $('.header-container').css('background-image', 'url(' + images[current] + ')');
      }
```
14. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Shared**, click **_Layout.cshtml**.

15. In the **_Layout.cshtml** code window, locate the following code:
  ```cs
       <script src="~/node_modules/jquery/dist/jquery.min.js"></script>
```

16. Place the cursor after the **>** (greater than) sign of the **&lt;/script&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/js/menubar-functions.js"></script>
       <script src="~/js/slider-functions.js"></script>
```
#### Task 4: Client-side validation using jQuery

1. In the **ZooSite – Microsoft Visual Studio** window, in Solution Explorer, click **package.json**.

2. In the **package.json** code window, locate the following code:
  ```cs
       "dependencies": {
         "jquery": "3.3.1"
       }
```
3. Replace the selected code with the following code:
  ```cs
       "dependencies": {
         "jquery": "3.3.1",
         "jquery-validation": "1.17.0",
         "jquery-validation-unobtrusive": "3.2.10"
       }
```
4. In the **ZooSite - Microsoft Visual Studio** window, on the **FILE** menu, click **Save package.json**.

5. Wait for the **Microsoft Visual Studio** dialog box to appear, and then click **Yes to All**.

    >**Note**: In Solution Explorer, under **Dependencies**, under **npm**, new packages named **jquery-validation** and **jquery-validation-unobtrusive** have been added.

6. In the **ZooSite - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Zoo**, click **BuyTickets.cshtml**.

7. In the **BuyTickets.cshtml** code window, locate the following code:
  ```cs
       @section Scripts {
           <script src="~/js/form-functions.js"></script>
       }
```
8. Place the cursor after the **{** (opening brace) sign, press Enter, and then type the following code: 
  ```cs
       <script src="~/node_modules/jquery-validation/dist/jquery.validate.min.js"></script>
       <script src="~/node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>
```

#### Task 5: Run the application

1. In the  **ZooSite – Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ZooSite - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In the **Zoo Attractions** page, in the **Welcome to Zoo Center** header, click the **right arrow**, and then click the **left arrow**.

    >**Note**: The browser displays the header with the slider, and the slider functionality is applied by the **slider-functions.js** JavaScript file.

4. In the menu bar, click **Visitor Info**.

    >**Note**: Examine the browser content.

5. In the menu bar, click **Tickets**.

    >**Note**: The **Buy** button is disabled, and there is a message **Please Choose Tickets** under the button.


6. On **Step 1 - Choose Tickets**, in the **Adult** box, select _&lt;as many tickets as you like&gt;,_ in the **Child** box, select _&lt;as many tickets as you like&gt;,_ and then in the **Senior** box, select _&lt;as many tickets as you like&gt;._

    >**Note**: The **Buy** button is enabled, and the message **Please Choose Tickets** has disappeared. In addition, an **Order Summary** section is added which shows the price of the tickets.

7. On **Step 2 - Buy Tickets**, in the **First Name** box, type _&lt;A first name of your choice&gt;._

8. On **Step 2 - Buy Tickets**, in the **Last Name** box, type _&lt;A last name of your choice&gt;._

9. On **Step 2 - Buy Tickets**, in the **Address** box, type _&lt;An address of your choice&gt;._

10. On **Step 2 - Buy Tickets**, in the **Email** box, type **abcd**, and then press Tab.

>**Note**: Client side validation applies.

11. On **Step 2 - Buy Tickets**, in the **Email** box, type _&lt;A valid email of your choice&gt;_, and then press Tab.

>**Note**: The error message in the browser disappears.

12. On **Step 2 - Buy Tickets**, in the **Phone** box, type _&lt;A phone of your choice&gt;,_ and then click **Buy**.

13. In Microsoft Edge, click **Close**.

14. In the **ZooSite - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Results**: After completing this exercise, you will be able to add jQuery to a web application using npm, modify HTML elements by using jQuery, perform client-side validation, and handle JavaScript events. 

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.



