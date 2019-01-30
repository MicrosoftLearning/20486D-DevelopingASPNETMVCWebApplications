# Module 13: Implementing Web APIs

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lesson 2: Developing a Web API

### Demonstration: How to Develop a Web API

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **[Repository Root]\Allfiles\Mod13\Democode\01_WebApiExample_begin**, and then open the **WebApiExample.sln**.

    >**Note**: If a **Security Warning for WebApiExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this demonstration.

5. In Microsoft Edge, click **Close**.

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod13\Democode\01_WebApiExample_begin**, and then double-click **WebApiExample.sln**.

    >**Note**: If a **Security Warning for WebApiExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **WebApiExample - Microsoft Visual Studio** window, in Solution Explorer, under **Properties**, click **launchSettings.json**.

3. In the **launchSettings.json** code window, select the following code:
  ```cs
       "launchUrl": "",
```
4. Replace the selected code with the following code:
  ```cs
       "launchUrl": "api/person",
```
5. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the **HTTP 404** error. 

6. In Microsoft Edge, click **Close**.

7. In Solution Explorer, right-click **WebApiExample**, point to **Add**, and then click **New Folder**.

8. In the **NewFolder** box, type **Controllers**, and then press Enter.

9. In the **WebApiExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Controllers**, point to **Add**, and then click **Controller**.

10. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

11. In the **Add Empty API Controller** dialog box, in the **Controller name** box, type **PersonController**, and then click **Add**.

12. In the **PersonController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
13. Ensure that the cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using WebApiExample.Models;
```

14. In the **PersonController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private List<Person> _people = new List<Person>();

       public PersonController()
       {
            _people.Add(new Person() {Id = 1, FirstName = "James", LastName = "Sprayberry" });
            _people.Add(new Person() {Id = 2, FirstName = "Jason", LastName = "Mosley" });
            _people.Add(new Person() {Id = 3, FirstName = "Jennifer", LastName = "Dietz" });
            _people.Add(new Person() {Id = 4, FirstName = "Bessie", LastName = "Duppstadt" });
       }
```
15. Ensure that the cursor is at the end of the **PersonController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       public List<Person> GetAll()
       {
       }
```
16. In the **GetAll** action code block, type the following code:
  ```cs
       return _people;
```
17. Ensure that the cursor is at the end of the **GetAll** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet("{id}")]
       public ActionResult<Person> GetPersonById(int id)
       {
       }
```
18. In the **GetPersonById** action code block, type the following code:
  ```cs
       var person = _people.FirstOrDefault(p => p.Id == id);

       if (person == null)
       {
            return NotFound();
       }

       return person;
```

19. In the **WebApiExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

20. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays a list of people in the JSON format.

21. In Microsoft Edge, in the address bar, type **http://localhost:[port]/api/person/1**, and then press Enter.

    >**Note**: The browser displays the person in the JSON format.

22. In Microsoft Edge, click **Close**.

23. In the **WebApiExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **WebApiExample**, and then click **Manage NuGet Packages**.

24. In the **NuGet Package Manager: WebApiExample** window, click **Browse**.

25. In the search box, type **Microsoft.AspNetCore.Mvc.Formatters.Xml**, and then press Enter.

26. Click **Microsoft.AspNetCore.Mvc.Formatters.Xml**, select version **2.1.1**, and then click **Install.**

27. If a **Preview Changes** dialog box appears, click **OK**.

28. If a **License Acceptance** dialog box appears, click **I Accept**.

29. Close the **NuGet Package Manager: WebApiExample** window.

30. In the **WebApiExample - Microsoft Visual Studio** window, in Solution Explorer, click **Startup.cs**.

31. In the **Startup.cs** code window, select the following code:
  ```cs
      services.AddMvc();
```
32. Replace the selected code with the following code:
  ```cs
      services.AddMvc().AddXmlSerializerFormatters();
```
33. In the **WebApiExample - Microsoft Visual Studio** window, in Solution Explorer, under **Controllers**, click **PersonController.cs**.

34. In the **GetAll** action code block, locate the following code:
  ```cs
       [HttpGet]
```
35. Place the cursor after the located code, press Enter, and then type the following code:
  ```cs
       [Produces("application/xml")]
``` 

36. In the **WebApiExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

37. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays a list of people in the XML format.

38. In Microsoft Edge, click **Close**.

39. In the **WebApiExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Calling a Web API 

### Demonstration: How to Call Web APIs by Using jQuery Code

#### Preparation Steps 

Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod13\Democode\02_JQueryExample_begin**, and then double-click **JQueryExample.sln**.

    >**Note**: If a **Security Warning for JQueryExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **JQueryExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **Controllers**, point to **Add**, and then click **Controller**.

3. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

4. In the **Add Empty API Controller** dialog box, in the **Controller name** box, type **PizzaController**, and then click **Add**.

5. In the **PizzaController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
6. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using JQueryExample.Models;
```

7. In the **PizzaController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private List<Pizza> _pizzas = new List<Pizza>();

       public PizzaController()
       {
            _pizzas.Add(new Pizza() { Id = 1, Toppings = "mushrooms", Price = 10 });
            _pizzas.Add(new Pizza() { Id = 2, Toppings = "extra cheese", Price = 8 });
            _pizzas.Add(new Pizza() { Id = 3, Toppings = "black olives", Price = 9 });
            _pizzas.Add(new Pizza() { Id = 4, Toppings = "pineapple", Price = 12 });
       }
```
8. Ensure that the cursor is at the end of the **PizzaController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet("{id}")]
       public ActionResult<Pizza> GetById(int id)
       {
       }
```
9. In the **GetById** action code block, type the following code:
  ```cs
       Pizza pizza = _pizzas.SingleOrDefault(p => p.Id == id);
       if (pizza == null)
       {
            return NotFound();
       }
       return pizza;
```
10. Ensure that the cursor is at the end of the **GetById** method code block, press Enter twice, and then type the following code:
  ```cs
       [HttpPost]
       public ActionResult<Pizza> Post(Pizza pizza)
       {
       }
```
11. In the **Post** action code block, type the following code:
  ```cs
       int pizzaMaxId = _pizzas.Max(i => i.Id);
       pizza.Id = ++pizzaMaxId;
       _pizzas.Add(pizza);
       return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
```
12. In the **JQueryExample - Microsoft Visual Studio** window, in Solution Explorer, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

13. In the **NewFolder** box, type **js**, and then press Enter.

14. In the **JQueryExample – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

15. In the **Add New Item – JQueryExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

16. In the **Add New Item – JQueryExample** dialog box, in the **Name** box, type **pizza-get**, and then click **Add**.

17. In the **pizza-get.js** code window, type the following code:
  ```cs
       $(function() {
            $(".btn-get").click(function (e) {
                e.preventDefault();
                $.ajax({
                    type: "GET",
                    url: "http://localhost:59216/api/Pizza/1",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                    }).done(function (response) {
                        $(".result").text('Information for pizza with id 1: ' + 'has the following toppings ' + response.toppings + ' for the price of ' + response.price + '$');
                    }).fail(function () {
                        alert('An error has occurred');
                });
            });
       });
```

18. In the **JQueryExample – Microsoft Visual Studio** window, in Solution Explorer, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

19. In the **Add New Item – JQueryExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

20. In the **Add New Item – JQueryExample** dialog box, in the **Name** box, type **pizza-post**, and then click **Add**.

21. In the **pizza-post.js** code window, type the following code:
  ```cs
       $(function () {
            $(".btn-post").click(function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "http://localhost:59216/api/Pizza",
                    data: JSON.stringify({
                        toppings: "pineapple",
                        price: 10.99
                    }),
                    contentType: "application/json;charset=utf-8"
                    }).done(function (result) {
                        $(".result").text('Ajax result: pizza object was added successfully with id number ' + result.id + ', and ' + result.toppings + ' topping for the price of ' + result.price + '$');
                    }).fail(function () {
                        alert('An error has occurred');
                });
            });
       });
```

22. In the **JQueryExample – Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Home**, and then click **Index.cshtml**.

23. In the **Index.cshtml** code window, locate the following code:
  ```cs
       <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
```
24. Place the cursor after the **>** (greater than) sign of the **&lt;/script&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/js/pizza-get.js"></script>
       <script src="~/js/pizza-post.js"></script>
```
25. In the **Index.cshtml** code window, in the **BODY** element, type the following code:
  ```cs
       <h1>Welcome to Module 13 - Demo 2</h1>
       <button type="button" class="btn-get btn-outline-info">Get Ajax Function</button>
       <button type="button" class="btn-post btn-outline-info">Post Ajax Function</button>
       <div class="result"></div>
```
26. In the **JQueryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

27. In the **JQueryExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

28. On the **Home** page, click **Get Ajax Function**.

    >**Note**: The browser displays the toppings and price of pizza with id=1.

29. On the **Home** page, click **Post Ajax Function**.

    >**Note**: The browser displays the new pizza information.

30. In Microsoft Edge, click **Close**.

31. In the **JQueryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Calling a Web API 

### Demonstration: How to Call Web APIs by Using Server-Side Code

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Navigate to **[Repository Root]\Allfiles\Mod13\Democode\01_WebApiExample_begin**, and then open the **HttpClientExample.sln**.

    >**Note**: If a **Security Warning for HttpClientExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

3. In the **HttpClientExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this demonstration.

5. In Microsoft Edge, click **Close**.

#### Demonstration Steps

1. Navigate to **[Repository Root]\Allfiles\Mod13\Democode\03_HttpClientExample_begin**, and then double-click **HttpClientExample.sln**.

    >**Note**: If a **Security Warning for HttpClientExample** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **HttpClientExample - Microsoft Visual Studio** window, in Solution Explorer, under **ClientSide**, click **Startup.cs**.

3. In the **Startup.cs** code window, locate the following code:
  ```cs
      services.AddMvc();
```
4. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      services.AddHttpClient();
```
5. In Solution Explorer, right-click **ClientSide**, point to **Add**, and then click **New Folder**.

6. In the **NewFolder** box, type **Controllers**, and then press Enter.

7. In the **HttpClientExample - Microsoft Visual Studio** window, in Solution Explorer, under **ClientSide**, right-click **Controllers**, point to **Add**, and then click **Controller**.

8. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

9. In the **Add Empty MVC Controller** dialog box, in the **Controller name** box, type **HomeController**, and then click **Add**.

10. In the **HomeController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```
11. Ensure that the cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
      using ClientSide.Models;
      using System.Net.Http;
      using System.Net.Http.Headers;
```

12. In the **HomeController.cs** code window, delete the following code:
  ```cs
       public IActionResult Index()
       {
           return View();
       }
```
13. In the **HomeController.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private IHttpClientFactory _httpClientFactory;

       public HomeController(IHttpClientFactory httpClientFactory)
       {
           _httpClientFactory = httpClientFactory;
       } 
``` 

14. Ensure that the cursor is at the end of the **HomeController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> GetByIdAsync()
       {
       }
```
15. In the **GetByIdAsync** action code block, type the following code:
  ```cs
       HttpClient httpClient = _httpClientFactory.CreateClient();
       httpClient.BaseAddress = new Uri("http://localhost:61086");
       HttpResponseMessage response = httpClient.GetAsync("http://localhost:61106/api/store/1").Result;
       if (response.IsSuccessStatusCode)
       {
           GroceryStore grocery = await response.Content.ReadAsAsync<GroceryStore>();
           return new ObjectResult(grocery);
       }
       else
       {
           return Content("An error has occurred");
       }
```

16. Ensure that the cursor is at the end of the **GetByIdAsync** action code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> PostAsync()
       {
       }
```
17. In the **PostAsync** action code block, type the following code:
  ```cs
       HttpClient httpClient = _httpClientFactory.CreateClient();
       httpClient.BaseAddress = new Uri("http://localhost:61086");
       GroceryStore newGrocery = new GroceryStore { Name = "Martin General Stores", Address = "4160  Oakwood Avenue" };
       HttpResponseMessage response = await httpClient.PostAsJsonAsync("http://localhost:61106/api/store", newGrocery);
       if (response.IsSuccessStatusCode)
       {
           GroceryStore grocery = await response.Content.ReadAsAsync<GroceryStore>();
           return new ObjectResult(grocery);
       }
       else
       {
           return Content("An error has occurred");
       }
```
18. In the **HttpClientExample - Microsoft Visual Studio** window, in Solution Explorer, expand **ServerSide**, expand **Controllers**, and then click **StoreController.cs**.

    >**Note**: Examine the **StoreController** class content.

19. In the **HttpClientExample - Microsoft Visual Studio** window, in Solution Explorer, under **ServerSide**, under **Properties**, click **launchSettings.json**.

20. In the **launchSettings.json** code window, select the following code:
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

21. Replace the selected code with the following code:
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

22. In the **HttpClientExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

23. In Solution Explorer, right-click **ServerSide**, and then click **Set as StartUp Project**. 

24. In the **HttpClientExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

25. In Solution Explorer, right-click **ClientSide**, and then click **Set as StartUp Project**. 

26. In the **HttpClientExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the grocery store object with id=1 in the JSON format.

27. In Microsoft Edge, in the address bar, type **http://localhost:[port]/home/PostAsync**, and then press Enter.

    >**Note**: The browser displays the newly added grocery store in the JSON format.

28. In Microsoft Edge, click **Close**.

29. In the **HttpClientExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.