# Module 13: Implementing Web APIs

# Lab: Implementing Web APIs

#### Scenario

You have been asked to create a web-based restaurant application for your organization's customers. To do this you need to create a page showing all the restaurant branches, enable to order a reservation for a selected restaurant branch, add wanted ad page, and allow submitting to a selected job.

You will create a server-side Web API application and a client-side ASP.NET Core MVC application. In the client-side application you will call the Web API actions using HttpClient and jQuery.

#### Objectives

After completing this lab, you will be able to:

- Add actions to a Web API application.
- Call Web API actions using HttpClient.
- Call Web API actions using jQuery.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Open the **Command Prompt** window using **Run as administrator**.

3. In **Administrator: Command Prompt**, run the following command:
 **cd &lt;The location of Allfiles\Mod13\Labfiles\01_Restaurant_begin\Client folder on your machine&gt;.**

4. Run the following command: **npm install**.

5. Close the **Command Prompt** window.

### Exercise 1: Adding Actions and Call them using Microsoft Edge

#### Scenario

In this exercise, you will first add a controller and an action to a Web API application. You will then run the application and view the outcome using Microsoft Edge. After that you will add a controller and an action that gets a parameter. You will then run the application and view the outcome using Microsoft Edge. Finally, you will add a post action to the Web API application.

The main tasks for this exercise are as follows:

1.	Add a controller and an action to a Web API application.

2.	Run the application.

3.	Add a controller and an action that gets a parameter.

4.	Run the application.

5.	Add a Post action to a Web API application.

#### Task 1: Add a controller and an action to a Web API application

1. Open the **Restaurant.sln** file from the following location: **Allfiles\Mod13\Labfiles\01_Restaurant_begin**.

2. Create a new controller with the following information:
   - Controller name: **RestaurantBranchesController**
   - Template: **API Controller - Empty**
   - Folder: **Server/Controllers**
   
3. In the **RestaurantBranchesController** class, add **USING** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

5.  Add a constructor with the following parameter:
     - Parameter: 
         - Type: **RestaurantContext** 
         - Name: **context**

6. In the **RestaurantBranchesController** constructor, initialize the **_context** field with the value of the **context** parameter.

7. Add a method with the following information:
    - Scope: **public**
    - Return type: **ActionResult	&lt;List&lt;RestaurantBranch&gt;&gt;**
    - Name: **Get**

8. Above the **Get** method, add a **HttpGet** attribute.

9. In the **Get** method, create a variable named **branches** of type **var**, and assign it the value of the following LINQ query:

    - From: **r in _context.RestaurantBranches**
    - Orderby: **r.City**
    - Select: **r**
   
10. Return the **List&lt;RestaurantBranch&gt;** result using the **branches.ToList** method. 

#### Task 2: Run the application

1. Save all the changes.

2. In **Solution Explorer**, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

    >**Note:** The browser displays a list of branches in **JSON** format.

4. Close **Microsoft Edge**.

#### Task 3: Add a controller and an action that gets a parameter

1.  Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **API Controller - Empty**
   - Folder: **Server/Controllers**
   
2. In the **ReservationController** class, add **USING** statements for the following namespaces:
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

8. In the **GetById** method, create a variable named **order** of type **var** and assign it with the value of **_context.ReservationsTables.FirstOrDefault(p => p.Id == id)**.

9. Create an **IF** statement that checks that the value of the **order** varible is **null**. 

10. Inside the **IF** statement code block, return a **NotFoundResult** result using the **NotFound** method.

11. After the **IF** statement code block, return the **ActionResult&lt;OrderTable&gt;** result using the **order** variable.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In **Microsoft Edge**, navigate to **http://localhost:[port]/api/Reservation/1**.

    >**Note:** The browser displays an order with id=1 in **JSON** format.

4. Close **Microsoft Edge**.

#### Task 5: Add a Post action to a Web API application

1. In the **ReservationController** constructor, add a method with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **Create**
   - Parameter: 
        - Type: **OrderTable** 
        - Name: **orderTable**
        
2. Above the **Create** method, add a **HttpPost** attribute.

5. In the **Create** method, call the **Add** method of the **_context** field. Pass the **orderTable** property as parameter to the **Add** method.

6. Call the **SaveChanges** method of the **_context** field. 

7. Return the **ActionResult&lt;OrderTable&gt** result using the **CreatedAtAction** method. Pass **nameof(GetById)**,  **new { id = orderTable.Id }** and **orderTable** as parameters to the **CreatedAtAction** method.

>**Results**: After completing this exercise, you will be able to add controllers and actions to a Web API application, and call them using Microsoft Edge.

### Exercise 2: Calling a Web API using Server-Side Code

#### Scenario

In this exercise, you will call the Web API you developed in the previous exercise using the HttpClient class. 
To do this, you will first register the IHttpClientFactory service in the Startup.cs file. You will then create MVC controller and use the HttpClient class to call a Get action in the Web API. After that you will create another MVC controller and use the HttpClient class to call a Post action in the Web API. Finally, you will add an action the MVC controller, in which you will use the HttpClient class to call a Get action in the Web API that gets a parameter.

The main tasks for this exercise are as follows:

1. Calling a Web API GET method.

2. Run the Application.

3. Calling a Web API POST method.

4. Calling a Web API GET method that gets a parameter.

5. Run the Application.


#### Task 1: Calling a Web API GET method

1. In the **Startup** class, at the end of the **ConfigureServices** method, call the **AddHttpClient** method of the **services** parameter.

2. Create a new folder with the following information:

   - Project: **Client**
   - Folder name: **Controllers**
   
3. Create a new controller with the following information:
   - Controller name: **RestaurantBranchesController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
4. In the **RestaurantBranchesController** class, add **USING** statements for the following namespaces:
   - **System.Net.Http**
   - **Client.Models**

5. Remove the **Index** action with its content.

6. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClientFactory**

7.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClientFactory**

8. In the **RestaurantBranchesController** constructor, initialize the **_httpClientFactory** field with the value of the **httpClientFactory** parameter.

9. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **Index**

10. In the **Index** method,  add a variable named **httpClient** of type **HttpClient**.

11. Initialize the **httpClient** variable with the value of **_httpClientFactory.CreateClient()**.

12. Add the **BaseAddress** property of the **httpClient** property. Initialize the **httpClient.BaseAddress** variable with the value of **new Uri("http://localhost:54517")**.

13. Add a variable named **response** of type **HttpResponseMessage**. Initialize the **response** variable with the value of **httpClient.GetAsync("http://localhost:54517/api/RestaurantBranches").Result**.

14. Create an **IF** statement that checks if **response.IsSuccessStatusCode** is **TRUE**.

15. Inside the **IF** statement code block, add a variable named **restaurantBranches** of type **IEnumerable<RestaurantBranch>**, and assign the **restaurantBranches** field with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;RestaurantBranch&gt;&gt;()**.
   
16. Return the **ViewResult** result using the **View** method. Pass **restaurantBranches** as parameter to the **View** method.

17. After the new **IF** statement, create an **ELSE** statement. 

18. Inside the **ELSE** statement code block, return the **ViewResult** result using the **View** method. Pass **"Error"** as parameter to the **View** method.

19. View the content of the **Index.cshtml** view, under the **Restaurant** folder.

#### Task 2: Run the Application

1. In the **launchSettings.json** file of the client project, in the **IISExpress** profile change the value of the following property: 
    - Name: **launchBrowser**
    - Value: **False**

2. Save all the changes.

3. In **Solution Explorer**, right-click **Server**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In **Solution Explorer**, right-click **Client**, and then click **Set as StartUp Project**.

6. Start the application without debugging.

    >**Note:** The browser displays the restaurant branches. 
    
7. Close **Microsoft Edge**.

8. Stop Debugging.

#### Task 3: Calling a Web API POST method

1. Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
2. In the **ReservationController** class, add **USING** statements for the following namespaces:
   - **Microsoft.AspNetCore.Mvc.Rendering**
   - **System.Net.Http**
   - **Client.Models**

3. Remove the **Index** action with its content.

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClient**

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **IEnumerable&lt;RestaurantBranch&gt;**
   - Name: **_restaurantBranches**

6.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClient**

7. In the **ReservationController** constructor, initialize the **_httpClient** field with the value of the **httpClient** parameter.

8. Add a method with the following information:
   - Scope: **public**
   - Modifier: **async**
   - Return type: **Task&lt;IActionResult&gt;**
   - Name: **Create**
   
9. Above the **Create** method, add a **HttpGet** attribute.

10. In the **Create** method, call the **PopulateRestaurantBranchesDropDownListAsync** method using the **await** keyword. 
   
11. Return the **Task&lt;IActionResult&gt;** result using the **View** method. 

12. Add a method with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **CreatePostAsync**
    - Parameter:
        - Type: **OrderTable**
        - Name: **orderTable**
   
13. Above the **CreatePostAsync** method, add a **HttpPost** attribute.

14. Above the **CreatePostAsync** action with the **ActionName** attribute. Pass **"Create"** as parameter to the **ActionName** attribute.

15. In the **CreatePostAsync** method, add a variable named **client** of type **var**. Initialize the **client** variable with the value of **_httpClient.CreateClient()**.

16. Add a variable named **response** of type **var**. Initialize the **response** variable with the value of **await client.PostAsJsonAsync("http://localhost:54517/api/Reservation", orderTable)**.

17. Call the **EnsureSuccessStatusCode** method of the **response** variable.
   
18. Return the **Task&lt;IActionResult&gt;** result using the **RedirectToAction** method. Pass **nameof(ThankYou)** as parameter to the **RedirectToAction** method.

19. Add a **PopulateRestaurantBranchesDropDownListAsync** method with the following information:
     - Scope: **private**
     - Modifier: **async**
     - Return type: **Task**
     - Name: **PopulateRestaurantBranchesDropDownListAsync**   
     - Parameter: 
         - Type: **int?** 
         - Name: **selectedBranch**
         - Defualt value: **null**   

20. In the **PopulateRestaurantBranchesDropDownListAsync** method, add a variable named **request** of type **var**. Initialize the **request** variable with the value of **new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantBranches")**.

21. Call the **Add** method of the **request.Headers** property. Pass **"Accept"** and **"application/json"** parameters to the **Add** method.

22. Add a variable named **client** of type **var**. Initialize the **client** variable with the value of **_httpClient.CreateClient()**.

23. Add a variable named **response** of type **var**. Initialize the **response** variable with the value of **await client.SendAsync(request)**.

24. Create an **IF** statement that checks that the value of the **response.IsSuccessStatusCode** varible is **true**. 

25. Inside the **IF** statement code block, assign the **_restaurantBranches** property with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;RestaurantBranch&gt;&gt;()**.

26. Assign the **RestaurantBranchId** property of the **ViewBag** field with the value of **new SelectList(_restaurantBranches, "Id", "City", selectedBranch)**.

27. Add a method with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **ThankYou**
   
28. Return the **IActionResult** result using the **View** method. 

#### Task 4: Run the Application

1. View the content of the **Create.cshtml** view.
    
2. Save all the changes.

3. In **Solution Explorer**, right-click **Client**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    
6. In the first **Microsoft Edge** window, in the menu bar, click **Reservation**.

7. On **Reservation**, create a new reservation with the following credentials:
   
    - Restaurant Branch: **_&lt;A restaurant branch of your choice&gt;_**
    - First Name: **_&lt;A first name of your choice&gt;_**
    - Last Name: **_&lt;A last name of your choice&gt;_**
    - Phone Number: **_&lt;A phone of your choice&gt;_** 
    - Reservation Time: **_&lt;A reservation time of your choice&gt;_** 
    - Dinner Guests: **_&lt;A dinner guests of your choice&gt;_** 
    
8. Click **Make a Reservation**.

9. Close all **Microsoft Edge** windows.

10. Stop Debugging.

>**Results**: After completing this exercise, you will be able to call a Web Api using the HttpClient class.

### Exercise 3: Calling a Web API using jQuery

#### Scenario

In this exercise, you will call a Web API using jQuery. You will first create MVC controller and use jQuery to call a **Get** action in the Web API. After that you will create another MVC controller and use jQuery to call a **Post** action in the Web API. 

The main tasks for this exercise are as follows:

1. Calling a Web API GET method using jQuery.

2. Run the Application.

3. Calling a Web API GET method using HttpClient.

4. Calling a Web API POST method using jQuery.

5. Run the Application.

#### Task 1: Calling a Web API Service GET method

1. Create a new controller with the following information:
   - Controller name: **WantedAdController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
2. Add a **JavaScript** **File** with the following information:

   - Folder: **Client/wwwroot/js**
   - Name: **wanted-ad-get**
   
3. In the **wanted-ad-get.js** file, call the **$** function and pass an **anonymous function** as parameter.

4. Inside the **anonymous function** code block, call the **$.ajax** function. Pass a **JSON** object as parameter to the **$.ajax** function using the following information:

    - Properties: 
      - type: **"GET"**
      - url: **"http://localhost:54517/api/RestaurantWantedAd"**
      - contentType: **"application/json; charset=utf-8"**
      - dataType: **"json"**
      - success: **function(data) { }**      
      - error: **function() {  alert('An error has occurred'); }**

5. Inside the **anonymous function** code block assigned to the **success** property, call the **$.each** method. Pass **data** and **anonymous function** parameters to the **$.each** method.

6. Change the signature of the **anonymous function** passed to the **$.each** method to accept **index** and **item** parameters.

7. Inside the **anonymous function** passed to the **$.each** method, add a variable of type **var** with the name of **html**. 

8. Assign the **html** variable the value of: 
  ```cs
   `<div class="photo-index-card-data">
           <div class="image-wrapper">
                 <img class="photo-display-img" src="~/images/white-plate.jpg" />
           </div>
           <div class="display-picture-data">
                 <h6 class="display-title">Job Title:</h6>
                 <h6>${item.jobTitle}</h6>
                 <h6 class="display-title">Hourly payment:</h6>
                 <h6>$${item.pricePerHour}</h6>
                 <h6 class="display-title">Job Description:</h6>
                 <h6>${item.jobDescription}</h6>
           </div>
     </div>`
```

9. Call the **$** function and pass **'.container'** as parameter.

10. Chain a **append** function call to the $ function call. Pass **html** as parameter to the  **append** function.

11. Call the **$** function and pass **'.photo-display-img'** as parameter.

12. Chain a **attr** function call to the $ function call. Pass **'src'** and '/images/white-plate.jpg' as parameters to the  **attr** function.

13. Inside the **WantedAd/Index.cshtml** view, after the **DIV** element with the **"container"** class, add a **Scripts** section code block.

14. In the **Scripts** section code block, add a **SCRIPT** element with the following information:

    - Src: **~/js/wanted-ad-get.js**

#### Task 2: Run the Application

1. Save all the changes.

2. In **Solution Explorer**, right-click **Client**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

4. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    
5. In the first **Microsoft Edge** window, in the menu bar, click **We are Hiring**.

    >**Note:** The browser displays the **Index.cshtml** file content of the **WantedAdController**.

6. Close all **Microsoft Edge** windows.

7. Stop Debugging.

#### Task 3: Calling a Web API Service POST method

1. Create a new controller with the following information:
   - Controller name: **JobApplicationController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**

2. In the **ReservationController** class, add **USING** statements for the following namespaces:
   - **Microsoft.AspNetCore.Mvc.Rendering**
   - **System.Net.Http**
   - **Client.Models**

3. Remove the **Index** action with its content.

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClient**

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **IEnumerable&lt;EmployeeRequirements&gt;**
   - Name: **_employeeRequirements**

6.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClient**

7. In the **JobApplicationController** constructor, initialize the **_httpClient** field with the value of the **httpClient** parameter.

8. Add a method with the following information:
   - Scope: **public**
   - Modifier: **async**
   - Return type: **Task&lt;IActionResult&gt;**
   - Name: **Create**
   
9. In the **Create** method, call the **PopulateEmployeeRequirementsDropDownListAsync** method using the **await** keyword. 
   
10. Return the **Task&lt;IActionResult&gt;** result using the **View** method. 

11. Add a **PopulateEmployeeRequirementsDropDownListAsync** method with the following information:
     - Scope: **private**
     - Modifier: **async**
     - Return type: **Task**
     - Name: **PopulateEmployeeRequirementsDropDownListAsync**   
     - Parameter: 
         - Type: **int?** 
         - Name: **selectedRequirements**
         - Defualt value: **null**   

12. In the **PopulateRestaurantBranchesDropDownListAsync** method, add a variable named **request** of type **var**. Initialize the **request** variable with the value of **new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantWantedAd")**.

13. Call the **Add** method of the **request.Headers** property. Pass **"Accept"** and **"application/json"** as parameters to the **Add** method.

14. Add a variable named **client** of type **var**. Initialize the **client** variable with the value of **_httpClient.CreateClient()**.

15. Add a variable named **response** of type **var**. Initialize the **response** variable with the value of **await client.SendAsync(request)**.

16. Create an **IF** statement that checks that the value of the **response.IsSuccessStatusCode** varible is **true**. 

17. Inside the **IF** statement code block, assign the **_employeeRequirements** property with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;EmployeeRequirements&gt;&gt;()**.

18. Assign the **EmployeeRequirementsId** property of the **ViewBag** field with the value of **new SelectList(_employeeRequirements, "Id", "JobTitle", selectedRequirements)**.

19. Add a method with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **ThankYou**
   
20. Return the **IActionResult** result using the **View** method. 

21. Add a **JavaScript** **File** with the following information:

   - Folder: **Client/wwwroot/js**
   - Name: **wanted-ad-post**
   
22. In the **wanted-ad-post.js** file, call the **$** function and pass an **anonymous function** as a parameter.

23. Inside the **anonymous function** code block, call the **$** function and pass **'#btn-post'** as a parameter.

24. Chain a **click** function call to the **$** function call. Pass an **anonymous function** as parameter to the  **click** function.

25. Modify the **anonymous function** passed to the **click** function to accept an **e** parameter.

26. In the  **anonymous function** code block, add a variable named **formData** of type **var** with the value of **{}**.

27. Call the **$** function and pass **'#submit-form'** as a parameter.

28. Chain a **serializeArray** function call to the **$** function call. 

29. Chain a **map** function call to the **serializeArray** function call. Pass an **anonymous function** as parameter to the  **click** function.

30. Modify the **anonymous function** passed to the **map** function to accept an **item** parameter.

31. In the **anonymous function** code block, asign the **name** property of the **item** parameter the value of **item.name[0].toLowerCase() + item.name.slice(1)**.

32. Add a **IF** statement that checks that the value of **formData[item.name]** is **TRUE**. 

33. Inside the **IF** statement, add a **IF** statement that checks that the value of **formData[item.name]** is equal to **"string"**. 

34. Inside the **IF** statement, assign the **formData[item.name]** variable the value of **[formData[item.name]]**.

35. After the inner **IF** statement, call the **push** function of the **formData[item.name]** variable. Pass **item.value** as a paramter to the **push** method. 

36. After the outer **IF** statement, add an **ELSE** statement. 

37. Inside the **ELSE** statement, assign the **formData[item.name]** variable the value of **item.value**.

38. After the **map** method call, call the **preventDefault** method of the **e** parameter. 

11. Call the **$.ajax** function. Pass a **JSON** object as parameter to the **$.ajax** function using the following information:

    - Properties: 
      - type: **"POST"**
      - url: **"http://localhost:54517/api/job"**
      - contentType: **"application/json; charset=utf-8"**
      - data: **JSON.stringify(formData)**
      - dataType: **"json"**
      - success: **function() { location.href = 'http://localhost:54508/JobApplication/ThankYou' }**      
      - error: **function(result) { alert('An error has occurred') }**
      

#### Task 4: Run the Application

1. View the content of the **Create.cshtml** view.
    
2. Save all the changes.

3. In **Solution Explorer**, right-click **Client**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    
6. In the first **Microsoft Edge** window, in the menu bar, click **Submit Job Application**.

7. On **Submit Job Application**, submit a form with the following credentials:
   
    - Job Title: **_&lt;A job title of your choice&gt;_**
    - First Name: **_&lt;A first name of your choice&gt;_**
    - Last Name: **_&lt;A last name of your choice&gt;_**
    - Phone Number: **_&lt;A phone of your choice&gt;_** 
    - Email: **_&lt;An email time of your choice&gt;_** 
    - Address: **_&lt;An address of your choice&gt;_** 
    
8. Click **Apply For a Job**.

9. Close all **Microsoft Edge** windows.

10. Stop Debugging.

11. Close **Microsoft Visual Studio**.

>**Results**: After completing this exercise, you have enabled users to see the wanted ads to find a new job, and enabled them to apply for a job. 

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
