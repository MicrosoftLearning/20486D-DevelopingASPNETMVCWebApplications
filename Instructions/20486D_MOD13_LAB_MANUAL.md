# Module 13: Implementing Web APIs

# Lab: Implementing Web APIs

#### Scenario



#### Objectives

After completing this lab, you will be able to:


#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

### Exercise 1: Adding Actions and Call them using Microsoft Edge

#### Scenario

You are required to...

The main tasks for this exercise are as follows:

1.	Add an action to a Web API application

2.	Run the application

3.	Add an action that gets a parameter to a Web API application

4.	Run the application

5.	Add a Post action to a Web API application


#### Task 1: Add an action to a Web API application

1. Open the **Command Prompt** window using **Run as administrator**.

2. In the **Administrator: Command Prompt**, run the command **cd <The location of Allfiles\Mod13\Labfiles\01_Restaurant_begin\Client folder on your machine>**

3. Run the command **npm install**.

4. Close the **Command Prompt** window.

5. Open the **Restaurant.sln** file from the following location: **Allfiles\Mod13\Labfiles\01_Restaurant_begin**.

6. Create a new folder with the following information:

   - Project: **Server**
   - Folder name: **Controllers**
   
7. Create a new controller with the following information:
   - Controller name: **RestaurantBranchesController**
   - Template: **API Controller - Empty**
   - Folder: **Controllers**
   
8. In the **RestaurantBranchesController** class, add **using** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**

9. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

10.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **RestaurantContext** 
        - Name: **context**

11. In the **RestaurantBranchesController** constructor, initialize the **_context** field with the value of the **context** parameter.

12. Add a method for the **Get** action with the following information:
   - Scope: **public**
   - Return type: **ActionResult	&lt;List&lt;RestaurantBranch&gt;&gt;**
   - Name: **Get**

13. Annotate the **Get** action with the **HttpGet** attribute.

14. In the **Get** method, create a variable named **branches** of type **var** and assign it the value of the following LINQquery:

   - From: **r in _context.RestaurantBranches**
   - Orderby: **r.City**
   - Select: **r**
   
15. Return the **List&lt;RestaurantBranch&gt;** result using the **branches.ToList** method. 


#### Task 2: Run the application

1. Save all the changes.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.
    >**Note:**  The browser displays the first restaurant in **JSON** format.

4. Close **Microsoft Edge**.

#### Task 3: Add an action that gets a parameter to a Web API application

1.  Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **API Controller - Empty**
   - Folder: **Controllers**
   
2. In the **ReservationController** class, add **using** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**
   
3. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

4.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **ReservationController** 
        - Name: **context**

5. In the **ReservationController** constructor, initialize the **_context** field with the value of the **context** parameter.

6. Add a method for the **GetById** action with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **GetById**
   - Parameter: 
        - Type: **int** 
        - Name: **id**

7. Annotate the **GetById** action with the **HttpGet** attribute.

8. In the **GetById** method, create a variable named **order ** of type **var** and assign it the value of **_context.ReservationsTables.FirstOrDefault(p => p.Id == id)**.

9. Create an **IF** statement that checks that the value of the **order** varible is **null**. 

10. Inside the **IF** statement code block, return a **NotFoundResult** result using the **NotFound** method.

11. After the **IF** statement code block, return the **ActionResult&lt;OrderTable&gt;** result usig the **order** variable.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In **Microsoft Edge**, navigate to **http://localhost:[port]/api/Reservation/1**.
    >**Note:**  The browser displays the first restaurant in **JSON** format.

4. Close **Microsoft Edge**.


#### Task 5: Add a Post action to a Web API application

1. In the **ReservationController** constructor, add a method for the **Create** action with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **Create**
   - Parameter: 
        - Type: **OrderTable** 
        - Name: **orderTable**
        
2. Annotate the **Post** action with the **HttpPost** attribute.

3. Annotate the **Post** action with the **ProducesResponseType** attribute. Pass **201** and **Type = typeof(OrderTable)** as parameters to the **ProducesResponseType** attribute.

4. Annotate the **Post** action with the **ProducesResponseType** attribute. Pass **400** as a parameter to the **ProducesResponseType** attribute.

5. Create an **IF** statement that checks that the value of the **ModelState.IsValid** varible is **false**. 

6. Inside the **IF** statement code block, return a **BadRequestResult** result using the **BadRequest** method. Pass the **ModelState** property as a parameter to the **BadRequest** method.

7. After the **IF** statement code block, call the **Add** method of the **_context** field. Pass the **orderTable** property as a parameter to the **Add** method.

8. Call the **SaveChanges** method of the **_context** field. 

9. Return the **ActionResult&lt;OrderTable&gt** result usig the **CreatedAtAction** method. Pass **nameof(GetById)**,  **new { id = orderTable.Id }** and orderTable asparameters to the **CreatedAtAction** method.

>**Results** : After completing this exercise, you will be able to

### Exercise 2: 

#### Scenario

After...

The main tasks for this exercise are as follows:

1.	Calling a Web API Service GET method

2.	Run the Application

3.	Calling a Web API Service POST method

4. Run the Application


#### Task 1: Calling a Web API Service GET method

1. In the **Startup** class, at the end of the **ConfigureServices** method, call the **AddHttpClient** method of the **services** parameter.

2. Create a new folder with the following information:

   - Project: **Client**
   - Folder name: **Controllers**
   
3. Create a new controller with the following information:
   - Controller name: **RestaurantController**
   - Template: **MVC Controller - Empty**
   - Folder: **Controllers**
   
4. In the **RestaurantController** class, add **using** statements for the following namespaces:
   - **System.Net.Http**
   - **Server.Models**

5. Remove the **Index** action with its content.

6. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClient**

7. Create a new field with the following information:
   - Scope: **private**
   - Type: **IEnumerable&lt;RestaurantBranch&gt;**
   - Name: **_restaurantBranches**

8.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClient**

9. In the **RestaurantController** constructor, initialize the **_httpClient** field with the value of the **httpClient** parameter.

10. Add an **async** method for the **Index** action with the following information:
   - Scope: **public**
   - Return type: **Task&lt;IActionResult&gt;**
   - Name: **Index**

11. In the **Index** method,  add a variable named **request** of type var. Initialize the **request** variable with the value of **new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantBranches")**.

12. Call the **Add** method of the **request.Header** property. Pass **"Accept"** and **"application/json"** as parameters to the **Add** method .

13. Add a variable named **client** of type var. Initialize the **request** variable with the value of **_httpClient.CreateClient()**.

14. Add a variable named **response** of type var. Initialize the **response** variable with the value of **await client.SendAsync(request)**.

15. Create an **IF** statement that checks that the value of the **response.IsSuccessStatusCode** is **TRUE**.

16. Inside the **IF** statement code block, assign the **_restaurantBranches** field the value of **await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>()**.
   
17. Return the **ViewResult** result using the **View** method. Pass **_restaurantBranches** as a parameter to the **View** method.

#### Task 2: Run the Application

1. 

#### Task 3: Calling a Web API Service POST method

1. 

#### Task 4: Run the Application

1. 

#### Task 5: 
1. 

#### Task 6: 
1. 

#### Task 7: 

1. 

### Exercise 3: 

#### Scenario

After..

The main tasks for this exercise are as follows:

1.	

2.

3.	

#### Task 1: 

1. 

#### Task 2: 


#### Task 3: 


>**Results** : After completing this exercise, alongside testing, you have developed a functional MVC Application.

>**Results** :  At the end of this exercise, you will be able to add logging in different logging levels in different environments, displaying errors or information by writing into a log file or a console output in a desired format, and creating a mock substitute using a mocking framework.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
