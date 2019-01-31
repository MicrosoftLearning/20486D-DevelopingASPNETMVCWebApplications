# Module 13: Implementing Web APIs

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Implementing Web APIs

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. 
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

2. In File Explorer, navigate to **[Repository Root]\Allfiles\Mod13\Labfiles\01_Restaurant_begin\Client**, copy the address in the address bar.

3. Select the **Start** button, and then type **cmd**.

4. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

5. In the **User Account Control** dialog box, click **Yes**.

6. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       cd  {copied folder path}
```

>**Note**: If the **{copied folder path}** is different from the disk drive where the **Command Prompt** is located, then you should type **{disk drive}:** before typing the **cd  {copied folder path}** command.

7. In the **Administrator: Command Prompt** window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown at the command prompt, you can ignore them.

8. Close the window.

9. Navigate to **[Repository Root]\Allfiles\Mod13\Labfiles\01_Restaurant_begin**, and then open the **Restaurant.sln**.

    >**Note**: If a **Security Warning for Server** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

10. In the **Server - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

11. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this lab.

12. In Microsoft Edge, click **Close**.

### Exercise 1: Adding Actions and Calling them by using Microsoft Edge

#### Task 1: Add a controller and an action to a Web API application

1. Navigate to **[Repository Root]\Allfiles\Mod13\Labfiles\01_Restaurant_begin**, and then double-click **Restaurant.sln**.

    >**Note**: If a **Security Warning for Server** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Server**, right-click **Controllers**, point to **Add**, and then click **Controller**.

3. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

4. In the **Add Empty API Controller** dialog box, in the **Controller name** box, type **RestaurantBranchesController**, and then click **Add**.

5. In the **RestaurantBranchesController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
6. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using Server.Data;
       using Server.Models;
```
7. In the **RestaurantBranchesController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private RestaurantContext _context;

       public RestaurantBranchesController(RestaurantContext context)
       {
           _context = context;
       }
```
8. Ensure that the cursor is at the end of the **RestaurantBranchesController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       public ActionResult<List<RestaurantBranch>> Get()
       {
       }
```
9. In the **Get** action code block, type the following code:
  ```cs
       var branches = from r in _context.RestaurantBranches
                      orderby r.City
                      select r;
       return branches.ToList();
```

#### Task 2: Run the application

1. In the **Restaurant - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**. 

3. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays a list of branches in the JSON format.

4. In Microsoft Edge, click **Close**.

#### Task 3: Add a controller and an action that gets a parameter

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Server**, right-click **Controllers**, point to **Add**, and then click **Controller**.

2. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

3. In the **Add Empty API Controller** dialog box, in the **Controller name** box, type **ReservationController**, and then click **Add**.

4. In the **ReservationController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
5. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using Server.Data;
       using Server.Models;
```

6. In the **ReservationController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private RestaurantContext _context;

       public ReservationController(RestaurantContext context)
       {
           _context = context;
       }
```
7. Ensure that the cursor is at the end of the **ReservationController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [Route("{id:int}")]
       public ActionResult<OrderTable> GetById(int id)
       {
       }
```
8. In the **GetById** action code block, type the following code:
  ```cs
       var order = _context.ReservationsTables.FirstOrDefault(p => p.Id == id);
       if (order == null)
       {
           return NotFound();
       }

       return order;
```

#### Task 4: Run the application

1. In the **Restaurant - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

3. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/api/Reservation/1**, and then press Enter.

    >**Note**: The browser displays an order with id=1 in the JSON format.

4. In Microsoft Edge, click **Close**.

#### Task 5: Add a Post action to a Web API application

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Server**, expand **Controllers**, and then click **ReservationController**.

2. In the **ReservationController.cs** code window, ensure that the cursor is at the end of the **GetById** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpPost]
       public ActionResult<OrderTable> Create(OrderTable orderTable)
       {
       }
```
3. In the **Create** action code block, type the following code:
  ```cs
       _context.Add(orderTable);
       _context.SaveChanges();
       return CreatedAtAction(nameof(GetById), new { id = orderTable.Id }, orderTable);
```

>**Results**: In this exercise, you added controllers and actions to a Web API application, and called them by using Microsoft Edge.

### Exercise 2: Calling a Web API by using Server-Side Code

#### Task 1: Calling a Web API Get method

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, click **Startup.cs**.

2. In the **Startup.cs** code window, locate the following code:
  ```cs
       services.AddMvc();
```

3. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       services.AddHttpClient();
```

4. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, right-click **Controllers**, point to **Add**, and then click **Controller**.

5. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

6. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **RestaurantBranchesController**, and then click **Add**.

7. In the **RestaurantBranchesController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
8. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using System.Net.Http;
       using Client.Models;
```
9. In the **RestaurantBranchesController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
          return View();
       }
```

10. Replace the selected code with the following code:
  ```cs
       private IHttpClientFactory _httpClientFactory;

       public RestaurantBranchesController(IHttpClientFactory httpClientFactory)
       {
             _httpClientFactory = httpClientFactory;
       }
```
11. Ensure that the cursor is at the end of the **RestaurantBranchesController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> Index()
       {
       }
```
12. In the **Index** action code block, type the following code:
  ```cs
       HttpClient httpClient = _httpClientFactory.CreateClient();
       httpClient.BaseAddress = new Uri("http://localhost:54517");
       HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantBranches");
       if (response.IsSuccessStatusCode)
       {
           IEnumerable<RestaurantBranch> restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
           return View(restaurantBranches);
       }
       else
       {
           return View("Error");
       }
```
13.  In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, expand **Views**, expand **RestaurantBranches**, and then click **Index.cshtml**.

     >**Note**: Examine the file content.

#### Task 2: Run the application

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Server**, under **Properties**, click **launchSettings.json**.

2. In the **launchSettings.json** code window, select the following code:
  ```cs
       "profiles": {
          "IIS Express": {
            "commandName": "IISExpress",
            "launchBrowser": true,
            "environmentVariables": {
              "ASPNETCORE_ENVIRONMENT": "Development"
           }
       },
```

3. Replace the selected code with the following code:
  ```cs
       "profiles": {
          "IIS Express": {
            "commandName": "IISExpress",
            "launchBrowser": false,
            "environmentVariables": {
              "ASPNETCORE_ENVIRONMENT": "Development"
           }
       },
```

4. In the **Restaurant - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

5. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**. 

6. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

7. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**. 

8. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the restaurant branches. 

9. In Microsoft Edge, click **Close**.
    
#### Task 3: Calling a Web API Post method

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, right-click **Controllers**, point to **Add**, and then click **Controller**.

2. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

3. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **ReservationController**, and then click **Add**.

4. In the **ReservationController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
5. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc.Rendering;
       using System.Net.Http;
       using Client.Models;
```
6. In the **ReservationController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
          return View();
       }
```

7. Replace the selected code with the following code:
  ```cs
       private IHttpClientFactory _httpClientFactory;

       public ReservationController(IHttpClientFactory httpClientFactory)
       {
             _httpClientFactory = httpClientFactory;
       }
```
8. Ensure that the cursor is at the end of the **ReservationController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       public async Task<IActionResult> Create()
       {
       }
```
9. In the **Create** action code block, type the following code:
  ```cs
       await PopulateRestaurantBranchesDropDownListAsync();
       return View();
```

10. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Views**, expand **Reservation**, and then click **Create.cshtml**.

    >**Note**: Examine the file content.


11. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers** click **ReservationController.cs**.

12. in the **ReservationController.cs** code window, ensure that the cursor is at the end of the **Create** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpPost, ActionName("Create")]
       public async Task<IActionResult> CreatePostAsync(OrderTable orderTable)
       {
       }
```
13. In the **CreatePostAsync** action code block, type the following code:
  ```cs
       HttpClient httpclient = _httpClientFactory.CreateClient();
       HttpResponseMessage response = await httpclient.PostAsJsonAsync("http://localhost:54517/api/Reservation", orderTable);
       if (response.IsSuccessStatusCode)
       {
           OrderTable order = await response.Content.ReadAsAsync<OrderTable>();
           return RedirectToAction("ThankYouAsync", new { orderId = order.Id});
       }
       else
       {
           return View("Error");
       }
```
14. In the **ReservationController.cs** code window, ensure that the cursor is at the end of the **CreatePostAsync** action code block, press Enter twice, and then type the following code:
  ```cs
       private async Task PopulateRestaurantBranchesDropDownListAsync()
       {
       }
```
15. In the **PopulateRestaurantBranchesDropDownListAsync** action code block, type the following code:
  ```cs
       HttpClient httpClient = _httpClientFactory.CreateClient();
       httpClient.BaseAddress = new Uri("http://localhost:54517");
       HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantBranches");
       if (response.IsSuccessStatusCode)
       {
           IEnumerable<RestaurantBranch> restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
           ViewBag.RestaurantBranches = new SelectList(restaurantBranches, "Id", "City");
       }
```

#### Task 4: Calling a Web API Get method with parameter

1. In the **ReservationController.cs** code window, ensure that the cursor is at the end of the **PopulateRestaurantBranchesDropDownListAsync** action code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> ThankYouAsync(int orderId)
       {
       }
```
2. In the **ThankYou** action code block, type the following code:
  ```cs
       HttpClient httpClient = _httpClientFactory.CreateClient();
       httpClient.BaseAddress = new Uri("http://localhost:54517");
       HttpResponseMessage response = await httpClient.GetAsync("api/Reservation/" + orderId);
       if (response.IsSuccessStatusCode)
       {
           OrderTable orderResult = await response.Content.ReadAsAsync<OrderTable>();
           return View(orderResult);
       }
       else
       {
           return View("Error");
       }
```

3.  In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Views**, under **Reservation**, click **ThankYouAsync.cshtml**.

    >**Note**: Examine the file content.

#### Task 5: Run the application

1. In the **Restaurant - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**. 

3. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**. 

5. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

6. In the first **Microsoft Edge** window, in the menu bar, click **Reservation**.

7. On **Reservation**, in the **Restaurant Branch** box, select _&lt;A restaurant branch of your choice&gt;._

8. On **Reservation**, in the **First Name** box, type _&lt;A first name of your choice&gt;._

9. On **Reservation**, in the **Last Name** box, type _&lt;A last name of your choice&gt;._

10. On **Reservation**, in the **Phone Number** box, type _&lt;A phone of your choice&gt;._

11. On **Reservation**, in the **Reservation Time** box, choose _&lt;A reservation time of your choice&gt;._

12. On **Reservation**, in the **Dinner Guests** box, type _&lt;A dinner guests of your choice&gt;,_, and then click **Make a Reservation**.

13. In Microsoft Edge, click **Close**.

>**Results**: In this exercise, you called a Web API by using the HttpClient class.

### Exercise 3: Calling a Web API by Using jQuery

#### Task 1: Calling a Web API Get method by using jQuery

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, expand **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – Client** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

3. In the **Add New Item – Client** dialog box, in the result pane, click **JavaScript File**.

4. In the **Add New Item – Client** dialog box, in the **Name** box, type **wanted-ad-get**, and then click **Add**.

5. In the **wanted-ad-get.js** code window, type the following code:
  ```cs
       $(function () {
          $.ajax({
              type: "GET",
              url: "http://localhost:54517/api/RestaurantWantedAd",
              contentType: "application/json; charset=utf-8",
              dataType: "json"
              }).done(function (data) {
              }).fail(function () {
                  alert('An error has occurred');
          });
       });
```

6. In the **wanted-ad-get.js** code window, locate the following code:
  ```cs
       }).done(function (data) {
```

7. Ensure that the cursor is after the **{** (opening brace) sign, press Enter, and then type the following code:
  ```cs
        $.each(data, function (index, item) {
              var html = `<div class="photo-index-card-data">
                                <div class="image-wrapper">
                                      <img class="photo-display-img" src="~/images/white-plate.jpg" />
                                </div>
                                <div class="display-picture-data">
                                      <h6 class="display-title">Job title:</h6>
                                      <h6>${item.jobTitle}</h6>
                                      <h6 class="display-title">Hourly payment:</h6>
                                      <h6>$${item.pricePerHour}</h6>
                                      <h6 class="display-title">Job description:</h6>
                                      <h6>${item.jobDescription}</h6>
                                </div>
                          </div>`;
                $('.container').append(html);
        });
        $('.photo-display-img').attr('src', '/images/white-plate.jpg');
```

8. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Views**, expand **WantedAd**, and then click **Index.cshtml**.

9. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <div class="container">
       </div>
```
10. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       @section Scripts {
           <script src="~/js/wanted-ad-get.js"></script>
       }
```

#### Task 2: Run the application

1. In the **Restaurant - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**. 

3. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**. 

5. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

6. In the first **Microsoft Edge** window, in the menu bar, click **We Are Hiring**.

    >**Note**: The browser displays the jobs that required in a restaurant.

7. In Microsoft Edge, click **Close**.

#### Task 3: Calling a Web API Get method by using HttpClient

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, right-click **Controllers**, point to **Add**, and then click **Controller**.

2. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

3. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **JobApplicationController**, and then click **Add**.

4. In the **JobApplicationController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
5. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc.Rendering;
       using System.Net.Http;
       using Client.Models;
```
6. In the **JobApplicationController.cs** code window, select the following code:
  ```cs
       public IActionResult Index()
       {
          return View();
       }
```

7. Replace the selected code with the following code:
  ```cs
       private IHttpClientFactory _httpClientFactory;

       public JobApplicationController(IHttpClientFactory httpClientFactory)
       {
             _httpClientFactory = httpClientFactory;
       }
```
8. Ensure that the cursor is at the end of the **JobApplicationController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       public async Task<IActionResult> Create()
       {
       }
```
9. In the **Create** action code block, type the following code:
  ```cs
       await PopulateEmployeeRequirementsDropDownListAsync();
       return View();
```

10.  In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Views**, expand **JobApplication**, and then click **Create.cshtml**.

     >**Note**: Examine the file content.

11. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Controllers** click **JobApplicationController.cs**.

12. In the **JobApplicationController.cs** code window, ensure that the cursor is at the end of the **Create** action code block, press Enter twice, and then type the following code:
  ```cs
       private async Task PopulateEmployeeRequirementsDropDownListAsync()
       {
       }
```

13. In the **PopulateRestaurantBranchesDropDownListAsync** action code block, type the following code:
  ```cs
       HttpClient httpClient = _httpClientFactory.CreateClient();
       httpClient.BaseAddress = new Uri("http://localhost:54517");
       HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantWantedAd");
       if (response.IsSuccessStatusCode)
       {
           IEnumerable<EmployeeRequirements> employeeRequirements = await response.Content.ReadAsAsync<IEnumerable<EmployeeRequirements>>();
           ViewBag.EmployeeRequirements = new SelectList(employeeRequirements, "Id", "JobTitle");
       }
```

14. In the **JobApplicationController.cs** code window, ensure that the cursor is at the end of the **PopulateEmployeeRequirementsDropDownListAsync** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult ThankYou()
       {
       }
```
15. In the **ThankYou** action code block, type the following code:
  ```cs
       return View();
```

16.  In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Views**, expand **JobApplication**, and then click **ThankYou.cshtml**.

     >**Note**: Examine the file content.

#### Task 4: Calling a Web API Post method by using jQuery

1. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

2. In the **Add New Item – Client** dialog box, in the navigation pane, under **Installed**, expand **ASP.NET Core**, and then click **Web**.

3. In the **Add New Item – Client** dialog box, in the result pane, click **JavaScript File**.

4. In the **Add New Item – Client** dialog box, in the **Name** box, type **wanted-ad-post**, and then click **Add**.

5. In the **wanted-ad-post.js** code window, type the following code:
  ```cs
       $(function() {
             $("#btn-post").click(function (e) {
                 if ($('#submit-form').valid()) {
                     var formData = {};
                     $('#submit-form').serializeArray().map(function (item) {
                         item.name = item.name[0].toLowerCase() + item.name.slice(1);
                         if (formData[item.name]) {
                             if (formData[item.name] === "string") {
                                 formData[item.name] = [formData[item.name]];
                             }
                             formData[item.name].push(item.value);
                         } else {
                             formData[item.name] = item.value;
                         }
                     });
                     e.preventDefault();
                     $.ajax({
                         type: "POST",
                         url: "http://localhost:54517/api/job",
                         data: JSON.stringify(formData),
                         contentType: "application/json;charset=utf-8"
                     }).done(function () {
                         location.href = 'http://localhost:54508/JobApplication/ThankYou';
                     }).fail(function () {
                         alert('An error has occurred');
                 });
              }
          });
       });
```

6. In the **Restaurant - Microsoft Visual Studio** window, in Solution Explorer, under **Client**, under **Views**, under **JobApplication**, click **Create.cshtml**.

7. In the **Create.cshtml** code window, locate the following code:
  ```cs
             </form>
          </div>
       </div>
```
8. Place the cursor at the end of the located code, press Enter twice, and then type the following code:
  ```cs
       @section Scripts{
             <script src="~/node_modules/jquery-validation/dist/jquery.validate.min.js"></script>
             <script src="~/node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>
             <script src="~/js/wanted-ad-post.js"></script>
       }
```

#### Task 5: Run the application

1. In the **Restaurant - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**. 

3. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**. 

5. In the **Restaurant - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

6. In the first **Microsoft Edge** window, in the menu bar, click **Submit Job Application**.

7. On **Submit Job Application**, in the **Job title** box, select _&lt;A job title of your choice&gt;._

8. On **Submit Job Application**, in the **First name** box, type _&lt;A first name of your choice&gt;._

9. On **Submit Job Application**, in the **Last name** box, type _&lt;A last name of your choice&gt;._

10. On **Submit Job Application**, in the **Phone number** box, type _&lt;A phone of your choice&gt;._

11. On **Submit Job Application**, in the **Email** box, type _&lt;An email address of your choice&gt;._

12. On **Submit Job Application**, in the **Address** box, type _&lt;An address of your choice&gt;,_ and then click **Apply For a Job**.

13. In Microsoft Edge, click **Close**.

14. In the **Restaurant  - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Results**: In this exercise, you enabled users to see the wanted ads to find a new job, and enabled them to apply for a job. 

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
