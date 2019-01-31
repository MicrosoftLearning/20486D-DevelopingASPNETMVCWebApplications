# Module 13: Implementing Web APIs

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Implementing Web APIs

#### Scenario

You have been asked to create a web-based restaurant application for your organization's customers. To do this you need to create a page showing all the restaurant branches, enable users to order a reservation for a selected restaurant branch, add a wanted ad page, and allow submitting an application to a selected job.

You will create a server-side Web API application and a client-side ASP.NET Core MVC application. In the client-side application, you will call the Web API actions by using HttpClient and jQuery.

#### Objectives

After completing this lab, you will be able to:

- Add actions to a Web API application.
- Call Web API actions by using HttpClient.
- Call Web API actions by using jQuery.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Open the **Command Prompt** window by using **Run as administrator**.

    >**Note**: If a **User Account Control** dialog appears, click yes.

3. In **Administrator: Command Prompt**, run the following command:
 **cd [Repository Root]\Allfiles\Mod13\Labfiles\01_Restaurant_begin\Client**.

4. Run the following command: **npm install**.

5. Close the **Command Prompt** window.

6. Navigate to **[Repository Root]\Allfiles\Mod13\Labfiles\01_Restaurant_begin**, and then open the **Restaurant.sln**.

    >**Note**: If a **Security Warning for Server** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

7. In the **Server - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

8. In Microsoft Edge, in the address bar, note the port number that appears at the end of the URL **http://localhost:[port]**. You will use the port number during this lab.

9. In Microsoft Edge, click **Close**.


### Exercise 1: Adding Actions and Calling them by using Microsoft Edge

#### Scenario

In this exercise, you will first add a controller and an action to a Web API application. You will then run the application and view the outcome by using Microsoft Edge. After that, you will add a controller and an action that gets a parameter. You will then run the application and view the outcome by using Microsoft Edge. Finally, you will add a Post action to the Web API application.

The main tasks for this exercise are as follows:

1.	Add a controller and an action to a Web API application

2.	Run the application

3.	Add a controller and an action that gets a parameter

4.	Run the application

5.	Add a Post action to a Web API application

#### Task 1: Add a controller and an action to a Web API application

1. From **[Repository Root]\Allfiles\Mod13\Labfiles\01_Restaurant_begin**, open the **Restaurant.sln** file.

    >**Note**: If a **Security Warning for Server** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. Create a new controller with the following information:
   - Controller name: **RestaurantBranchesController**
   - Template: **API Controller - Empty**
   - Folder: **Server/Controllers**
   
3. In the **RestaurantBranchesController** class, add the **USING** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

5.  Add a constructor with the following parameter:
     - Parameter: 
         - Scope: **public**
         - Type: **RestaurantContext** 
         - Name: **context**

6. In the **RestaurantBranchesController** constructor, initialize the **_context** field with the value of the **context** parameter.

7. Add a method with the following information:
    - Scope: **public**
    - Return type: **ActionResult	&lt;List&lt;RestaurantBranch&gt;&gt;**
    - Name: **Get**

8. Above the **Get** method, add a **HttpGet** attribute.

9. In the **Get** method, create a variable named *branches* of type **var**, and assign it the value of the following LINQ query:

    - From: **r in _context.RestaurantBranches**
    - Orderby: **r.City**
    - Select: **r**
   
10. Return the **List&lt;RestaurantBranch&gt;** result by using the **branches.ToList** method. 

#### Task 2: Run the application

1. Save all the changes.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

    >**Note**: The browser displays a list of branches in **JSON** format.

4. Close Microsoft Edge.

#### Task 3: Add a controller and an action that gets a parameter

1.  Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **API Controller - Empty**
   - Folder: **Server/Controllers**
   
2. In the **ReservationController** class, add the **USING** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**
   
3. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

4. Add a constructor with the following parameter:
    - Parameter: 
        - Type: **ReservationController** 
        - Name: **context**

5. In the **ReservationController** constructor, initialize the **_context** field with the value of the **context** parameter.

6. Add a method with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **GetById**
   - Parameter: 
        - Type: **int** 
        - Name: **id**

7. Above the **GetById** method, add a **HttpGet** attribute.

8. In the **GetById** method, create a variable named *order* of type **var** and assign it with the value of **_context.ReservationsTables.FirstOrDefault(p => p.Id == id)**.

9. Create an **IF** statement that checks whether the value of the *order* variable is **null**. 

10. Inside the **IF** statement code block, return a **NotFoundResult** result by using the **NotFound** method.

11. After the **IF** statement code block, return the **ActionResult&lt;OrderTable&gt;** result by using the *order* variable.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In Microsoft Edge, navigate to **http://localhost:[port]/api/Reservation/1**.

    >**Note**: The browser displays an order with id=1 in the JSON format.

4. Close Microsoft Edge.

#### Task 5: Add a Post action to a Web API application

1. In the **ReservationController** constructor, add a method with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **Create**
   - Parameter: 
        - Type: **OrderTable** 
        - Name: **orderTable**
        
2. Above the **Create** method, add a **HttpPost** attribute.

3. In the **Create** method, call the **Add** method of the **_context** field. Pass the **orderTable** property as a parameter to the **Add** method.

4. Call the **SaveChanges** method of the **_context** field. 

5. Return the **ActionResult&lt;OrderTable&gt;** result by using the **CreatedAtAction** method. Pass **nameof(GetById)**,  **new { id = orderTable.Id }** and **orderTable** as parameters to the **CreatedAtAction** method.

>**Results**: After completing this exercise, you will be able to add controllers and actions to a Web API application, and call them by using Microsoft Edge.

### Exercise 2: Calling a Web API by Using Server-Side Code

#### Scenario

In this exercise, you will call the Web API you developed in the previous exercise by using the **HttpClient** class. 
To do this, you will first register the **IHttpClientFactory** service in the **Startup.cs** file. You will then create an MVC controller and use the **HttpClient** class to call a Get action in the Web API. After that, you will create another MVC controller and use the **HttpClient** class to call a Post action in the Web API. Finally, you will add an action to the MVC controller in which you will use the **HttpClient** class to call a Get action in the Web API that gets a parameter.

The main tasks for this exercise are as follows:

1. Calling a Web API Get method

2. Run the application

3. Calling a Web API Post method

4. Calling a Web API Get method that gets a parameter

5. Run the application

#### Task 1: Calling a Web API Get method

1. In the **Startup** class, at the end of the **ConfigureServices** method, call the **AddHttpClient** method of the **services** parameter.

2. Create a new controller with the following information:
   - Controller name: **RestaurantBranchesController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
3. In the **RestaurantBranchesController** class, add the **USING** statements for the following namespaces:
   - **System.Net.Http**
   - **Client.Models**

4. Remove the **Index** action with its content.

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClientFactory**

6.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClientFactory**

7. In the **RestaurantBranchesController** constructor, initialize the **_httpClientFactory** field with the value of the **httpClientFactory** parameter.

8. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **Index**

9. In the **Index** method,  add a variable named *httpClient* of type **HttpClient**.

10. Initialize the *httpClient* variable with the value of **_httpClientFactory.CreateClient()**.

11. Add the **BaseAddress** property of the *httpClient* variable. Initialize the *httpClient.BaseAddress* variable with the value of **new Uri("http://localhost:54517")**.

12. Add a variable named *response* of type **HttpResponseMessage**. Initialize the *response* variable with the value of **await httpClient.GetAsync("api/RestaurantBranches")**.

13. Create an **IF** statement that checks whether **response.IsSuccessStatusCode** is **TRUE**.

14. Inside the **IF** statement code block, add a variable named *restaurantBranches* of type **IEnumerable<RestaurantBranch>** and assign the **restaurantBranches** field with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;RestaurantBranch&gt;&gt;()**.
   
15. Return the **ViewResult** result by using the **View** method. Pass **restaurantBranches** as a parameter to the **View** method.

16. After the new **IF** statement, create an **ELSE** statement. 

17. Inside the **ELSE** statement code block, return the **ViewResult** result by using the **View** method. Pass **"Error"** as a parameter to the **View** method.

18. Under the **RestaurantBranches** folder, view the content of the **Index.cshtml** view.

#### Task 2: Run the application

1. In the **launchSettings.json** file of the client project, in the **IISExpress** profile, change the value of the following property: 
    - Name: **launchBrowser**
    - Value: **False**

2. Save all the changes.

3. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

6. Start the application without debugging.

    >**Note**: The browser displays the restaurant branches. 
    
7. Close Microsoft Edge.

#### Task 3: Calling a Web API Post method

1. Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
2. In the **ReservationController** class, add the **USING** statements for the following namespaces:
   - **Microsoft.AspNetCore.Mvc.Rendering**
   - **System.Net.Http**
   - **Client.Models**

3. Remove the **Index** action with its content.

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClientFactory**

5.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClientFactory**

6. In the **ReservationController** constructor, initialize the **_httpClientFactory** field with the value of the **httpClientFactory** parameter.

7. Add a method with the following information:
   - Scope: **public**
   - Modifier: **async**
   - Return type: **Task&lt;IActionResult&gt;**
   - Name: **Create**
   
8. Above the **Create** method, add a **HttpGet** attribute.

9. In the **Create** method, call the **PopulateRestaurantBranchesDropDownListAsync** method by using the **await** keyword. 
   
10. Return the **Task&lt;IActionResult&gt;** result by using the **View** method. 

11. Under the **Reservation** folder, view the content of the **Create.cshtml** view.

12. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **CreatePostAsync**
    - Parameter:
        - Type: **OrderTable**
        - Name: **orderTable**
   
13. Above the **CreatePostAsync** method, add a **HttpPost** attribute.

14. Above the **CreatePostAsync** action with the **ActionName** attribute, pass **"Create"** as a parameter to the **ActionName** attribute.

15. In the **CreatePostAsync** method, add a variable named *httpclient* of type **HttpClient**. Initialize the *httpClient* variable with the value of **_httpClientFactory.CreateClient()**.

16. Add a variable named *response* of type **HttpResponseMessage**. Initialize the *response* variable with the value of **await client.PostAsJsonAsync("http://localhost:54517/api/Reservation", orderTable)**.

17. Create an **IF** statement that checks whether **response.IsSuccessStatusCode** is **TRUE**.

18. Inside the **IF** statement code block, add a variable named *order* of type **OrderTable** and assign the *order* field with the value of **await response.Content.ReadAsAsync&lt;OrderTable&gt;()**.
   
19. Return the **Task&lt;IActionResult&gt;** result by using the **RedirectToAction** method. Pass **"ThankYouAsync", new { orderId = order.Id}** as parameters to the **RedirectToAction** method.

20. After the new **IF** statement, create an **ELSE** statement. 

21. Inside the **ELSE** statement code block, return the **ViewResult** result by using the **View** method. Pass **"Error"** as a parameter to the **View** method.

22. Add a **PopulateRestaurantBranchesDropDownListAsync** method with the following information:
     - Scope: **private**
     - Modifier: **async**
     - Return type: **Task**
     - Name: **PopulateRestaurantBranchesDropDownListAsync**   


23. In the **PopulateRestaurantBranchesDropDownListAsync** method,  add a variable named *httpClient* of type **HttpClient**.

24. Initialize the *httpClient* variable with the value of **_httpClientFactory.CreateClient()**.

25. Add the **BaseAddress** property of the *httpClient* variable. Initialize the *httpClient.BaseAddress* variable with the value of **new Uri("http://localhost:54517")**.

26. Add a variable named *response* of type **HttpResponseMessage**. Initialize the *response* variable with the value of **await httpClient.GetAsync("api/RestaurantBranches")**.

27. Create an **IF** statement that checks whether **response.IsSuccessStatusCode** is **TRUE**.

28. Inside the **IF** statement code block, add a variable named *restaurantBranches* of type **IEnumerable<RestaurantBranch>** and assign the *restaurantBranches* field with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;RestaurantBranch&gt;&gt;()**.
   
29. Assign the **RestaurantBranches** property of the **ViewBag** field with the value of **new SelectList(restaurantBranches, "Id", "City")**.

#### Task 4: Calling a Web API Get method with parameter

1. Add a method with the following information:
   - Scope: **public**
   - Modifier: **async**
   - Return type: **IActionResult**
   - Name: **ThankYouAsync**
   - Parameter: 
         - Type: **int** 
         - Name: **orderId**
   
2. In the **ThankYouAsync** method, add a variable named *httpclient* of type **HttpClient**. Initialize the *httpClient* variable with the value of **_httpClientFactory.CreateClient()**.

3. Add the **BaseAddress** property of the *httpClient* variable. Initialize the *httpClient.BaseAddress* variable with the value of **new Uri("http://localhost:54517")**.

4. Add a variable named *response* of type **HttpResponseMessage**. Initialize the *response* variable with the value of **await httpClient.GetAsync("api/Reservation/" + orderId)**.

5. Create an **IF** statement that checks whether **response.IsSuccessStatusCode** is **TRUE**.

6. Inside the **IF** statement code block, add a variable named *orderResult* of type **OrderTable**, and assign the *orderResult* field with the value of **await response.Content.ReadAsAsync&lt;OrderTable&gt;()**.

7. Return the **ViewResult** result by using the **View** method. Pass *orderResult* as a parameter to the **View** method.
   
8. Inside the **ELSE** statement code block, return the **ViewResult** result by using the **View** method. Pass **"Error"** as a parameter to the **View** method.

9. Under the **Reservation** folder, view the content of the **Create.cshtml** view.

#### Task 5: Run the application

1. Save all the changes.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

4. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

5. Start the application without debugging.
    
6. In the first **Microsoft Edge** window, in the menu bar, click **Reservation**.

7. On **Reservation**, create a new reservation with the following credentials:
   
    - Restaurant Branch: _&lt;A restaurant branch of your choice&gt;_
    - First Name: _&lt;A first name of your choice&gt;_
    - Last Name: _&lt;A last name of your choice&gt;_
    - Phone Number: _&lt;A phone of your choice&gt;_ 
    - Reservation Time: _&lt;A reservation time of your choice&gt;_ 
    - Dinner Guests: _&lt;A dinner guests of your choice&gt;_
    
8. Click **Make a Reservation**.

9. Close Microsoft Edge.

>**Results**: After completing this exercise, you will be able to call a Web API by using the HttpClient class.

### Exercise 3: Calling a Web API by using jQuery

#### Scenario

In this exercise, you will call a Web API by using jQuery. You will first create an MVC controller and use jQuery to call a **Get** action in the Web API. After that, you will create another MVC controller and use jQuery to call a **Post** action in the Web API. 

The main tasks for this exercise are as follows:

1. Calling a Web API Get method by using jQuery

2. Run the application

3. Calling a Web API Get method by using HttpClient

4. Calling a Web API Post method by using jQuery

5. Run the application

#### Task 1: Calling a Web API Get method by using jQuery
 
1. Add a JavaScript file with the following information:

   - Folder: **Client/wwwroot/js**
   - Name: **wanted-ad-get**
   
2. In the **wanted-ad-get.js** file, call the **$** function and pass an anonymous function as parameter.

3. Inside the **anonymous function** code block, call the **$.ajax** function. Pass a JSON object as a parameter to the **$.ajax** function by using the following information:

    - Properties: 
      - type: **"GET"**
      - url: **"http://localhost:54517/api/RestaurantWantedAd"**
      - contentType: **"application/json; charset=utf-8"**
      - dataType: **"json"**
      - done: **function(data) { }**      
      - fail: **function() {  alert('An error has occurred'); }**

4. Inside the **anonymous function** code block assigned to the **done** property, call the **$.each** method. Pass **data** and **anonymous function** parameters to the **$.each** method.

5. Change the signature of the anonymous function passed to the **$.each** method to accept **index** and **item** parameters.

6. Inside the anonymous function passed to the **$.each** method, add a variable of type **var** with the name of *html*. 

7. Assign the *html* variable the value of: 
  ```cs
   `<div class="photo-index-card-data">
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
     </div>`
```

8. Call the **$** function and pass **'.container'** as parameter.

9. Chain a **append** function call to the $ function call. Pass *html* as a parameter to the  **append** function.

10. Call the **$** function and pass **'.photo-display-img'** as parameter.

11. Chain a **attr** function call to the **$** function call. Pass **'src'** and **'/images/white-plate.jpg'** as parameters to the  **attr** function.

12. Inside the **WantedAd/Index.cshtml** view, after the **DIV** element with the **"container"** class, add a **Scripts** section code block.

13. In the **Scripts** section code block, add a **SCRIPT** element with the following information:

    - Src: **~/js/wanted-ad-get.js**

#### Task 2: Run the application

1. Save all the changes.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

4. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

5. Start the application without debugging.
    
6. In the first **Microsoft Edge** window, in the menu bar, click **We Are Hiring**.

    >**Note**: The browser displays the jobs that required in a restaurant.

7. Close the **Microsoft Edge** windows.

#### Task 3: Calling a Web API Get method by using HttpClient

1. Create a new controller with the following information:
   - Controller name: **JobApplicationController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**

2. In the **ReservationController** class, add the **USING** statements for the following namespaces:
   - **Microsoft.AspNetCore.Mvc.Rendering**
   - **System.Net.Http**
   - **Client.Models**

3. Remove the **Index** action with its content.

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClientFactory**

5.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClientFactory**

6. In the **JobApplicationController** constructor, initialize the **_httpClientFactory** field with the value of the **httpClientFactory** parameter.

7. Add a method with the following information:
   - Scope: **public**
   - Modifier: **async**
   - Return type: **Task&lt;IActionResult&gt;**
   - Name: **Create**
   
8. In the **Create** method, call the **PopulateEmployeeRequirementsDropDownListAsync** method by using the **await** keyword. 
   
9. Return the **Task&lt;IActionResult&gt;** result by using the **View** method. 

10. Under the **JobApplication** folder, view the content of the **Create.cshtml** view.

11. Add a **PopulateEmployeeRequirementsDropDownListAsync** method with the following information:
     - Scope: **private**
     - Modifier: **async**
     - Return type: **Task**
     - Name: **PopulateEmployeeRequirementsDropDownListAsync**   

12. In the **PopulateEmployeeRequirementsDropDownListAsync** method,  add a variable named *httpClient* of type **HttpClient**.

13. Initialize the *httpClient* variable with the value of **_httpClientFactory.CreateClient()**.

14. Add the **BaseAddress** property of the *httpClient* variable. Initialize the *httpClient.BaseAddress* variable with the value of **new Uri("http://localhost:54517")**.

15. Add a variable named *response* of type **HttpResponseMessage**. Initialize the *response* variable with the value of **await httpClient.GetAsync("api/RestaurantWantedAd")**.

16. Create an **IF** statement that checks whether **response.IsSuccessStatusCode** is **TRUE**.

17. Inside the **IF** statement code block, add a variable named *employeeRequirements* of type **IEnumerable<EmployeeRequirements>** and assign the *employeeRequirements* field with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;EmployeeRequirements&gt;&gt;()**.
   
18. Assign the **EmployeeRequirements** property of the **ViewBag** field with the value of **new SelectList(employeeRequirements, "Id", "JobTitle")**.

19. Add a method with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **ThankYou**
   
20. Return the **IActionResult** result by using the **View** method. 

21. Under the **JobApplication** folder, view the content of the **ThankYou.cshtml** view.

#### Task 4: Calling a Web API Post method by using jQuery

1. Add a JavaScript file with the following information:

   - Folder: **Client/wwwroot/js**
   - Name: **wanted-ad-post**
   
2. In the **wanted-ad-post.js** file, call the **$** function and pass an anonymous function as a parameter.

3. Inside the **anonymous function** code block, call the **$** function and pass **'#btn-post'** as a parameter.

4. Chain a **click** function call to the **$** function call. Pass an anonymous function as a parameter to the  **click** function.

5. Modify the anonymous function passed to the **click** function to accept an **e** parameter.

6. Add an **IF** statement that checks whether the value of **$('#submit-form')** is **valid()**.

7. Inside the **IF** statement, add a variable named *formData* of type **var** with the value of **{}**.

8. Call the **$** function and pass **'#submit-form'** as a parameter.

9. Chain a **serializeArray** function call to the **$** function call. 

10. Chain a **map** function call to the **serializeArray** function call. Pass an anonymous function as a parameter to the  **click** function.

11. Modify the anonymous function passed to the **map** function to accept an **item** parameter.

12. In the **anonymous function** code block, asign the **name** property of the **item** parameter the value of **item.name[0].toLowerCase() + item.name.slice(1)**.

13. Add an **IF** statement that checks whether the value of **formData[item.name]** is **TRUE**. 

14. Inside the **IF** statement, add a **IF** statement that checks whether the value of **formData[item.name]** is equal to **"string"**. 

15. Inside the **IF** statement, assign the *formData[item.name]* variable the value of **[formData[item.name]]**.

16. After the inner **IF** statement, call the **push** function of the *formData[item.name]* variable. Pass **item.value** as a paramter to the **push** method. 

17. After the outer **IF** statement, add an **ELSE** statement. 

18. Inside the **ELSE** statement, assign the *formData[item.name]* variable the value of **item.value**.

19. After the **map** method call, call the **preventDefault** method of the **e** parameter. 

20. Call the **$.ajax** function. Pass a JSON object as a parameter to the **$.ajax** function by using the following information:

    - Properties: 
      - type: **"POST"**
      - url: **"http://localhost:54517/api/job"**
      - contentType: **"application/json; charset=utf-8"**
      - data: **JSON.stringify(formData)**
      - dataType: **"json"**
      - done: **function() { location.href = 'http://localhost:54508/JobApplication/ThankYou' }**      
      - fail: **function(result) { alert('An error has occurred') }**

21. Inside the **JobApplication/Create.cshtml** view, after the last **DIV** element with the **"row justify-content-center"** class, add a **Scripts** section code block.

22. In the **Scripts** section code block, add a **SCRIPT** element with the following information:

    - Src: **~/node_modules/jquery-validation/dist/jquery.validate.min.js**
    - Src: **~/node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js**
    - Src: **~/js/wanted-ad-get.js**

#### Task 5: Run the application

1. Save all the changes.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

4. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

5. Start the application without debugging.
    
6. In the first **Microsoft Edge** window, in the menu bar, click **Submit Job Application**.

7. On **Submit Job Application**, submit a form with the following credentials:
   
    - Job title: _&lt;A job title of your choice&gt;_
    - First name: _&lt;A first name of your choice&gt;_
    - Last name: _&lt;A last name of your choice&gt;_
    - Phone number: _&lt;A phone of your choice&gt;_
    - Email: _&lt;An email address of your choice&gt;_
    - Address: _&lt;An address of your choice&gt;_
    
8. Click **Apply For a Job**.

9. Close the **Microsoft Edge** windows.

10. Close Microsoft Visual Studio.

>**Results**: After completing this exercise, you have enabled users to see the wanted ads to find a new job, and enabled them to apply for a job. 

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
