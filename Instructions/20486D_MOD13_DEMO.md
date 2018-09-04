# Module 13: Implementing Web APIs

# Lesson 1: Introducing Web APIs

### Demonstration: How to Explore a Web API with Microsoft Edge

#### Preparation Steps 

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\01_WebApiExample_begin**, and then double-click **WebApiExample.sln**.

2. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note:** The browser displays **HTTP 404** error. 

3. In **Microsoft Edge**, click **Close**.

4. In the **WebApiExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Properties** click **lanchSettings.json**.

5. In the **lanchSettings.json** code window, select the following code:
  ```cs
       "launchUrl": "api/values",
```
>**Note:** This snippet of code appears twice in the file.  

6. Replace the selected code with the following code:
  ```cs
       "launchUrl": "api/person",
```

7. In **Solution Explorer**, right-click **WebApiExample**, point to **Add**, and then click **New Folder**.

8. In the **NewFolder** text box, type **Controllers**, and then press Enter.

9. In the **WebApiExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Controllers**, point to **Add**, and then click **Controller**.

10. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

11. In the **Add Empty API Controller** dialog box, in the **Controller name** text box, type **PersonController**, and then click **Add**.

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
       public ActionResult<List<Person>> GetAll()
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
       public ActionResult<Person> GetLastNameById(int id)
       {
       }
```
18. In the **GetLastNameById** action code block, type the following code:
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

    >**Note:** The browser displays a list of people in **JSON** format.

21. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/api/person/1**, and then press Enter.

    >**Note:** The browser displays the first person's last name in **JSON** format.

22. In **Microsoft Edge**, click **Close**.

23. In the **WebApiExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Developing a Web API

### Demonstration: How to Return Data in XML Format

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\02_XmlFormatExample_begin**, and then double-click **XmlFormatExample.sln**.

2. In the **XmlFormatExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **XmlFormatExample**, and then click **Manage NuGet Packages**.

3. In the **NuGet Package Manager: XmlFormatExample** window, click **Browse**.

4. In the **Search** text box, type **Microsoft.AspNetCore.Mvc.Formatters.Xml**, and then press Enter.

5. Click **Microsoft.AspNetCore.Mvc.Formatters.Xml**, select version **2.1.0**, and then click **Install.**

6. If a **Preview Changes** dialog box appears, click **OK**.

7. If a **License Acceptance** dialog box appears, click **I Accept**.

8. Close the **NuGet Package Manager: XmlFormatExample** window.

9. In the **XmlFormatExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

10. In the **Startup.cs** code window, in the **ConfigureServices** method, place the cursor after the **{** (opening braces) sign, press Enter, type the following code, and then press Enter.
  ```cs
      services.AddMvc().AddXmlSerializerFormatters();
```
11. In **Solution Explorer**, right-click **XmlFormatExample**, point to **Add**, and then click **New Folder**.

12. In the **NewFolder** text box, type **Controllers**, and then press Enter.

13. In the **XmlFormatExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Controllers**, point to **Add**, and then click **Controller**.

14. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

15. In the **Add Empty API Controller** dialog box, in the **Controller name** text box, type **AnimalsController**, and then click **Add**.

16. In the **AnimalsController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
17. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using XmlFormatExample.Models;
```

18. In the **AnimalsController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private List<Animal> _animals = new List<Animal>();

       public AnimalsController()
       {
            _animals.Add(new Animal() { Id = 1, Name = "Lion", Family = "Mammal", Facts = "Lions are found especially in parts of Africa, and they are most active at night." });
            _animals.Add(new Animal() { Id = 2, Name = "Elephant", Family = "Mammal", Facts = "Elephants are intelligent animals and have a very good memories, they also display emotions signs." });
            _animals.Add(new Animal() { Id = 3, Name = "Shark", Family = "Fish", Facts = "Sharks live in the ocean, and average shark has 40-45 teeth" });
       }
```
19. Ensure that the cursor is at the end of the **AnimalsController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       [Produces("application/xml")]
       public ActionResult<List<Animal>> GetAll()
       {
       }
```
20. In the **GetAll** action code block, type the following code:
  ```cs
       return _animals;
```
21. In the **XmlFormatExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

22. In the **XmlFormatExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note:** The browser displays a list of animals in **XML** format.

23. In **Microsoft Edge**, click **Close**.

24. In the **XmlFormatExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.


# Lesson 3: Calling a Web API 

### Demonstration: How to Call Web APIs Using jQuery Code

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\03_JQueryExample_begin**, and then double-click **JQueryExample.sln**.

2. In the **JQueryExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click the **Controllers** folder, point to **Add**, and then click **Controller**.

3. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

4. In the **Add Empty API Controller** dialog box, in the **Controller name** text box, type **PizzashopController**, and then click **Add**.

5. In the **PizzashopController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
6. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using JQueryExample.Models;
```

7. In the **PizzashopController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private List<Pizza> _pizzas = new List<Pizza>();

       public PizzashopController()
       {
            _pizzas.Add(new Pizza() { Id = 1, Toppings = "Mushrooms", Price = 10 });
            _pizzas.Add(new Pizza() { Id = 2, Toppings = "Extra cheese", Price = 8 });
            _pizzas.Add(new Pizza() { Id = 3, Toppings = "Black olives", Price = 9 });
            _pizzas.Add(new Pizza() { Id = 4, Toppings = "Pineapple", Price = 12 });
       }
```
8. Ensure that the cursor is at the end of the **PizzashopController** constructor code block, press Enter twice, and then type the following code:
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
       if (!ModelState.IsValid)
       {
            return BadRequest(ModelState);
       }
       _pizzas.Add(pizza);
       return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
```
12. In the **JQueryExample - Microsoft Visual Studio** window, in the **Solution Explorer**, right-click **wwwroot**, point to **Add**, and then click **New Folder**.

13. In the **NewFolder** text box, type **js**, and then press Enter.

14. In the **JQueryExample – Microsoft Visual Studio** window, in the **Solution Explorer**, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

15. In the **Add New Item – JQueryExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

16. In the **Add New Item – JQueryExample** dialog box, in the **Name** text box, type **pizza-get**, and then click **Add**.

17. In the **pizza-get.js** code window, type the following code:
  ```cs
       $(document).ready(function () {
            $(".btn-get").click(function (e) {
                e.preventDefault();
                $.ajax({
                    type: "GET",
                    url: "http://localhost:59216/api/Pizzashop/1",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        $(".result").text('Ajax Result: you ordered pizza with ' + response.toppings + ' for ' + response.price + '$');
                    },
                    error: function (response) {
                        alert('An error has occurred');
                    }
                });
            });
       });
```

18. In the **JQueryExample – Microsoft Visual Studio** window, in the **Solution Explorer**, under **wwwroot**, right-click **js**, point to **Add**, and then click **New Item**.

19. In the **Add New Item – JQueryExample** dialog box, click **Web**, and then, in the result pane, click **JavaScript File**.

20. In the **Add New Item – JQueryExample** dialog box, in the **Name** text box, type **pizza-post**, and then click **Add**.

21. In the **pizza-post.js** code window, type the following code:
  ```cs
       $(document).ready(function () {
            $(".btn-post").click(function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "http://localhost:59216/api/Pizzashop",
                    data: JSON.stringify({
                        id: 6,
                        toppings: "Pineapple",
                        price: 10.99
                    }),
                    contentType: "application/json;charset=utf-8",
                    success: function (result) {
                        $(".result").text('Ajax Result: Pizza object added successfully with the following information id ' + result.id + ', toppings: ' + result.toppings + ', price ' + result.price + '$');
                    },
                    error: function (result) {
                        alert('An error has occurred');
                    }
                });
            });
       });
```

22. In the **JQueryExample – Microsoft Visual Studio** window, in the **Solution Explorer**, under **Views**, under **Home** click **Index.cshtml**.

23. In the **Index.cshtml** file, locate the following code:
  ```cs
       <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
```
24. Place the cursor after the **>** (greater than) sign of the **&lt;/script&gt;** tag, press Enter, and then type the following code: 
  ```cs
       <script src="~/js/pizza-get.js"></script>
       <script src="~/js/pizza-post.js"></script>
```
25. In the **Index.cshtml** file, in the **BODY** element, type the following code:
  ```cs
       <h1>Welcome to Model 13 - Demo 3</h1>
       <button type="button" class="btn-get btn-outline-info">Get Ajax Function</button>
       <button type="button" class="btn-post btn-outline-info">Post Ajax Function</button>
       <div class="result"></div>
```
26. In the **JQueryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

27. In the **JQueryExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

28. On the **Home** page, click **Get Ajax Function**, and examine the outcome.

29. On the **Home** page, click **Post Ajax Function**, and examine the outcome.

30. In **Microsoft Edge**, click **Close**.

31. In the **JQueryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Calling a Web API 

### Demonstration: How to Call Web APIs Using Server-Side Code

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\04_HttpClientExample_begin**, and then double-click **HttpClientExample.sln**.

2. In the **HttpClientExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **ClientSide**, click **Startup.cs**.

3. In the **Startup.cs** code window, locate the following code:
  ```cs
      services.AddMvc();
```
4. Place the cursor after the located code, press Enter, and then type the following code:
  ```cs
      services.AddHttpClient();
```
5. In **Solution Explorer**, right-click **ClientSide**, point to **Add**, and then click **New Folder**.

6. In the **NewFolder** text box, type **Controllers**, and then press Enter.

7. In the **HttpClientExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **ClientSide** right-click the **Controllers** folder, point to **Add**, and then click **Controller**.

8. In the **Add Scaffold** dialog box, click **MVC Controller - Empty**, and then click **Add**.

9. In the **Add Empty MVC Controller** dialog box, in the **Controller name** text box, type **HomeController**, and then click **Add**.

10. In **Solution Explorer**, right-click **ClientSide**, point to **Add**, and then click **Reference**. 

11. In the **Reference Manager - ClientSide** dialog box, click **Projects**, in the result pane, ensure that the **ServerSide** check box is **checked**, and then click **OK**.

12. In the **HomeController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```
13. Ensure that the cursor is at the end of the  **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
      using ServerSide.Models;
      using System.Net.Http;
      using System.Net.Http.Headers;
```

14. In the **HomeController.cs** code window, select the following code, and then press Delete.
  ```cs
       public IActionResult Index()
       {
           return View();
       }
```
15. In the **HomeController.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private IHttpClientFactory _httpClient;
       private GroceryStore grocery;

       public HomeController(IHttpClientFactory httpClient)
       {
           _httpClient = httpClient;
       } 
``` 

16. Ensure that the cursor is at the end of the **HomeController** constructor code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> GetByIdAsync()
       {
       }
```
17. In the **GetByIdAsync** action code block, type the following code:
  ```cs
       var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:64231/api/store/1");
       request.Headers.Add("Accept", "application/json");
       var client = _httpClient.CreateClient();

       var response = await client.SendAsync(request);
       if (response.IsSuccessStatusCode)
       {
           grocery = await response.Content.ReadAsAsync<GroceryStore>();
       }
       return new ObjectResult(grocery);
```

18. Ensure that the cursor is at the end of the **GetByIdAsync** action code block, press Enter twice, and then type the following code:
  ```cs
       public async Task<IActionResult> PostAsync()
       {
       }
```
19. In the **PostAsync** action code block, type the following code:
  ```cs
       var client = _httpClient.CreateClient();
       GroceryStore newGrocery = new GroceryStore { Id = 3, Name = "Martin General Stores", Address = "4160  Oakwood Avenue" };
       var response = await client.PostAsJsonAsync("http://localhost:64231/api/store", newGrocery);
       response.EnsureSuccessStatusCode();
       return new ObjectResult(newGrocery);
```
20. In the **HttpClientExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **ServerSide**, under **Controllers** click **StoreController.cs**.

21. Examine the **StoreController.cs** class content.

22. In the **HttpClientExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

23. In **Solution Explorer**, right-click **ClientSide**, and then click **Set as StartUp Project**. 

24. In the **HttpClientExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

25. In **Solution Explorer**, right-click **ServerSide**, point to **Debug**, and then click **Start new instance**.

    >**Note:** The browser displays a grocery store in **JSON** format.

26. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/home/PostAsync**, and then press Enter.

    >**Note:** The browser displays the new added grocery store in **JSON** format.

27. In **Microsoft Edge**, click **Close**.

28. In the **JQueryExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.