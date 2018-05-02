# Module 7: Using Entity Framework Core in ASP.NET Core

# Lab: Using Entity Framework Core in ASP.NET Core

#### Scenario

You are planning to create and code an MVC model that implements your plan for cupcakes and bakeries, in the application. The model must store data in a Microsoft SQL database and include properties that describe cupcakes, bakeries, and their content. The model must enable the application to store uploaded cupcakes, edit their properties, view their detailes, and delete them in response to user requests.

#### Objectives

After completing this lab, you will be able to:

- Add new models to the application and add properties to the model.
- Add a class that derives from DbContext.
- Use Repository in the project.
- Use Entity Framework Core to Retrieve and Store Data in the application.
- Use Visual Studio to create a new Microsoft SQL database and connect to the database.
- Use Migrations in the application.

#### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Adding Entity Framework Core 

#### Scenario

In this exercise, you will:

- Add a Cupcake model, and a Bakery model.
- Add a CupcakeContext class.
- Set CupcakeContext as an In Memory database.
- Add a Dbinitializer class, and populate the database.

The main tasks for this exercise are as follows:

1. Create model classes.

2. Create a class that derives from DbContext.

3. Set up Entity Framework to use an In Memory database.

4. Using an initializer to populate the database.

#### Task 1: Create model classes.

1. Open the Cupcakes.sln file from the following location:
**Allfiles\Mod07\Labfiles\01_Cupcakes_begin**.

2. Create a new class for the Cupcake model by using the following information:

    - Name: **Cupcake**
    - Folder: **Models**

3. In the **Cupcake** class, Add **using** statements to the model for the following namespaces:

   - **Microsoft.AspNetCore.Http**
   - **System.ComponentModel.DataAnnotations**
   - **System.ComponentModel.DataAnnotations.Schema**

4. Add a primary key property to the Cupcake model class by using the following information:

   - Scope: **public**
   - Property name: **CupcakeId**
   - Data type: **integer**
   - Access: **Read and write**

5. Add a CupcakeType property to the Cupcake model class by using the following information:

   - Scope: **public**
   - Property name: **CupcakeType**
   - Data type: Nullable **CupcakeType**
   - Access: **Read and write**

6. Add a Description property to the Cupcake model class by using the following information:

   - Scope: **public**
   - Property name: **Description**
   - Data type: **string**
   - Access: **Read and write**

7. Add a GlutenFree property to the Cupcake model class by using the following information:

   - Scope: **public**
   - Property name: **GlutenFree**
   - Data type: **bool**
   - Access: **Read and write**

8. Add a Price property to the Cupcake model class by using the following information:

   - Scope: **public**
   - Property name: **Price**
   - Data type: Nullable **double**
   - Access: **Read and write**

9. Add an image property to the **Cupcake** model class and store the image name by using the following information:

   - Scope: **public**
   - Property names: **PhotoAvatar**, **ImageName**
   - Data type for the image: **IFormFile**
   - Data type for image name: **string**
   - Access: **Read and write**

10. Add another image property to the **Cupcake** model class and store the MIME type of image by using the following information:

       - Scope: **public**
       - Property names: **PhotoFile**, **ImageMimeType**
       - Data type for the image: **byte []**
       - Data type for MIME type: **string**
       - Access: **Read and write**

11. Add a new property to the **Cupcake** model class to retrieve the bakery for a given bakeryId by using the following information: 

       - Scope: **public**
       - Property name: **BakeryId**
       - Property type: Nullable **int**
       - Access: **Read and write**

12. Add a new property to the **Cupcake** model class to retrieve the bakery by using the following information:

       - Scope: **public**
       - Property name: **Bakery**
       - Property type: **Bakery**
       - Access: **Read and write**
       - Include the **virtual** keyword

13. Add a Key attribute to the **Cupcake** model class to ensure that the CupcakeId property is a key property and corresponding column to a PrimaryKey column in the database.

14. Add a validation data annotation to the **Cupcake** model class to ensure that the users complete the CupcakeType field.

15. Add a display data annotation to the **Cupcake** model class to ensure that the CupcakeType property is displayed with the name, **Cupcake Type:** .

16. Add a validation data annotation to the **Cupcake** model class to ensure that the users complete the Description field.

17. Add a display data annotation to the **Cupcake** model class to ensure that the Description  property is displayed with the name, **Description:** .

18. Add a display data annotation to the **Cupcake** model class to ensure that the GlutenFree property is displayed with the name, **Gluten Free:** .

19. Add validation data annotations to the **Cupcake** model class to ensure that the users complete the Price text box and type an int not greater than 15 Digits.

20. Add a validation data annotation to the **Cupcake** model class to ensure that the users complete the Price field.

21. Add a DataType annotation to the **Cupcake** model class to ensure that the Price property is displayed as Currency.

22. Add a display data annotation to the **Cupcake** model class to ensure that the Price property is displayed with the name, **Price:** .

23. Add a data annotation to the **Cupcake** model class to ensure that the PhotoAvatar property wont be created corresponding column in a database table.

24. Add a display data annotation to the **Cupcake** model class to ensure that the PhotoAvatar  property is displayed with the name, **Cupcake Picture:** .

25. Add a validation data annotation to the **Cupcake** model class to ensure that the users complete the BakeryId field.

26. Create a new class for the Bakery model by using the following information:

    - Name: **Bakery**
    - Folder: **Models**

27. In the **Bakery** class, Add **using** statements to the model for the following namespaces:

    - **System.ComponentModel.DataAnnotations**

28. Add a primary key property to the Bakery model class by using the following information:

      - Scope: **public**
      - Property name: **BakeryId**
      - Data type: **integer**
      - Access: **Read and write**

29. Add a BakeryName property to the Bakery model class by using the following information:

       - Scope: **public**
      - Property name: **BakeryName**
       - Data type: **string**
       - Access: **Read and write**

30. Add a Quantity property to the Bakery model class by using the following information:

       - Scope: **public**
      - Property name: **Quantity**
      - Data type: **int**
      - Access: **Read and write**

31. Add a Address property to the Bakery model class by using the following information:

       - Scope: **public**
       - Property name: **Address**
       - Data type: **string**
       - Access: **Read and write**

32. Add a new property to the **Bakery** model class to retrieve cupcakes for a given bakery by using the following information:

       - Scope: **public**
       - Property name: **Cupcakes**
       - Data type: a collection of **Cupcake**
       - Access : **Read and write**
       - Include the **virtual** keyword

33. Add a Key attribute to the **Bakery** model class to ensure that the BakeryId  property is a key property and corresponding column to a PrimaryKey column in the database.

34. Add validation data annotations to the **Bakery** model class to ensure that the users complete the BakeryName text box and type a string with a length shorter than 50 characters.

35. Add validation data annotations to the **Cupcake** model class to ensure that the users complete the Quantity text box and type an int not greater than 40 Digits.

36. Add validation data annotations to the **Bakery** model class to ensure that the users complete the Address text box and type a string with a length shorter than 50 characters.

#### Task 2: Create a class that derives from DbContext.

1. Create a new top-level folder, in the **Cupcakes** project by using the following information:

   - Folder name: **Data**

2. Add a new class named **CupcakeContext** to the **Data** folder and ensure that the new class inherits the **System.Data.Entity.DbContext** class.

2. In the **CupcakeContext** class, Add **using** statements to the model for the following namespaces:

   - **Cupcakes.Models**
   - **Microsoft.EntityFrameworkCore**

3. Initialize the DbContextOptions<CupcakeContext> options, in the **CupcakeContext** constructor, and derive from DbContext base constructor the value **options**.

4. Add public **DbSet** properties, Cupcake and Bakery to enable Entity Framework create database tables called Cupcakes and Bakeries.

#### Task 3: Set up Entity Framework to use an In Memory database.

1. In the **Startup** class, Add **using** statements to the model for the following namespaces:

   - **Microsoft.Extensions.Configuration**
   - **Cupcakes.Data**
   - **Microsoft.EntityFrameworkCore**

2. In the **Startup** class, create a new object using the following information:

   - Scope: **private**
   - Class: **IConfiguration**
   - Name: **_configuration**

    Initialize the new object in the **Startup** constructor with the value **IConfiguration configuration**.

3. In the **ConfigureServices** method, initialize the **CupcakeContext** to use an **in memory database**.

#### Task 4: Using an initializer to populate the database.

1. Add a new static class named **DbInitializer** to the **Data** folder.

2. In the **DbInitializer** class, Add **using** statements to the model for the following namespaces:

   - **Cupcakes.Models**

3. Add static **Initialize** method in the **DbInitializer** class.

4. Edit the code in the **Initialize** method by using the following information:

   - Parameter: a CupcakeContext named **context**

5. Create a new list of **Bakery** objects in the **Initialize** method. The list should contain four Bakery objects with the following properties:

   - BakeryName: _&lt;A bakery name of your choice&gt;_
   - Address: _&lt;An address of your choice&gt;_
   - Quantity:  _&lt;A quantity of your choice&gt;_

5. Add each **Bakery** object in the **Bakeries** list to the Entity Framework context, and then save the changes to the context.

6. Create a new list of Cupcake objects in the **Initialize** method. The list should contain four **Cupcake** objects with the following properties:

   - CupcakeType: _&lt;A cupcake tyoe of your choice&gt;_
   - Description: _&lt;A description of your choice&gt;_
   - GlutenFree: **Choose if the cupcake is gluten-free**
   - Price: _&lt;A price of your choice&gt;_
   - BakeryId: **1**, **2**, **3**, **4**
   - ImageMimeType: **image/jpeg**, **chocolate-cupcake.jpg**, **pink-cupcake.jpg**, **turquoise-cupcake.jpg**
   - ImageName: **birthday-cupcake.jpg** , 

7. Add each **Cupcake** object in the **cupcakes** list to the Entity Framework context, and then save the changes to the context.

8. In the **Program** class, Add **using** statements to the model for the following namespaces:

   - **Cupcakes.Data**
   - **Microsoft.Extensions.DependencyInjection**

9.  In the **Program** class, add code to initialize the **DbInitializer** with test data.

>**Results** : After completing this exercise, you will be able to add Entity Framework Core to the Cupcake Shop application. 

### Exercise 2: Use Entity Framework Core to Retrieve and Store Data

#### Scenario

In this exercise, you will:

- Add a repository to the application.
- Use the repository in the controller.
- Retrieve cupcakes and bakeries data.
- Manipulating cupcakes and bakeries data.

The main tasks for this exercise are as follows:

1. Create a repository.  

2. Update a controller to use a repository.

3. Use Entity Framework to retrieve data.

4. Manipulating data using Entity Framework. 

#### Task 1: Create a repository. 

1. Create a new top-level folder, in the **Cupcakes** project by using the following information:

   - Folder name: **Repositories**

2. Add a new interface named **ICupcakeRepository** to the **Repositories** folder.

3. Set public scope to the new interface.

4. In the **ICupcakeRepository** class, Add **using** statements to the model for the following namespaces:

   - **Cupcakes.Models**

5. Add the **GetCupcakes** method to the **ICupcakeRepository** interface by using the following information:

   - Type: **IEnumerable&lt;Cupcake&gt;**
   - Name: **GetCupcakes**

6. Add the **GetCupcakeById** method to the **ICupcakeRepository** interface by using the following information:

   - Return type: **Cupcake**
   - Parameter: an integer named **Id**
   - Name: **GetCupcakeById**

7. Add the **CreateCupcake** method to the **ICupcakeRepository** interface by using the following information:

   - Return type: **void**
   - Parameter: a **Cupcake** object called **cupcake**.
   - Name: **CreateCupcake**

8.  Add the **DeleteCupcake** method to the **ICupcakeRepository** interface by using the following information:

    - Return type: **void**
    - Parameter: an integer named **Id**
    - Name: **DeleteCupcake**

9. Add the **SaveChanges** method to the **ICupcakeRepository** interface by using the following information:

    - Return type: **void**
    - Name: **SaveChanges**

10. Add the **PopulateBakeriesDropDownList** method to the **ICupcakeRepository** interface by using the following information:

     - Type: **IQueryable&lt;Bakery&gt;**
     - Name: **PopulateBakeriesDropDownList**

11. Add a new class named **CupcakeRepository** to the **Repositories** folder.

12. In the **CupcakeRepository** class, Add **using** statements to the model for the following namespaces:

   - **System.IO**
   - **Cupcakes.Data**  
   - **Cupcakes.Models**
   - **Microsoft.EntityFrameworkCore**

13. Ensure that the **CupcakeRepository** class implements the **ICupcakeRepository** interface.

14. In the **CupcakeRepository** class, create a new object using the following information:

       - Scope: **private**
       - Class: **CupcakeContext**
       - Name: **context**

    Initialize the new object in the **CupcakeRepository** constructor with the value **CupcakeContext _context**.

15. In the **CupcakeRepository** class, implement the **CreateCupcake** method from the **ICupcakeRepository** interface.

16. In the **CupcakeRepository** class, implement the **DeleteCupcake** property from the **ICupcakeRepository** interface.

17. In the **CupcakeRepository** class, implement the **GetCupcakeById** method from the **ICupcakeRepository** interface return the **Cupcake** object with requested **Id**.

18. In the **CupcakeRepository** class, implement the **GetCupcakes** method from the **ICupcakeRepository** interface and return a **Cupcake** collection.

19. In the **CupcakeRepository** class, implement the **PopulateBakeriesDropDownList** method from the **ICupcakeRepository** interface, order by **BakeryName** and return a **Bakery** collection.

20. In the **CupcakeRepository** class, implement the **SaveChanges** method from the **ICupcakeRepository** interface.

21. In the **Startup** class, Add **using** statements to the model for the following namespaces:

       - **Cupcakes.Repositories**

22. In the **Startup** class add **CupcakeRepository** to the services container as **Transient**.

#### Task 2: Update a controller to use a repository.

1. In the **CupcakeController** class, Add **using** statements to the model for the following namespaces:

   - **Microsoft.AspNetCore.Hosting**
   - **Cupcakes.Models**
   - **Cupcakes.Repositories**
   - **Microsoft.AspNetCore.Mvc.Rendering**
   - **Microsoft.EntityFrameworkCore**

2. In the **CupcakeController** class, create a new object using the following information:

   - Scope: **private**
   - Class: **ICupcakeRepository**
   - Name: **_repository**

    Initialize the new object in the **CupcakeController** constructor with the value **ICupcakeRepository repository**.

3. In the **CupcakeController** class, create a new object using the following information:

   - Scope: **private**
   - Class: **IHostingEnvironment**
   - Name: **_environment**

    Initialize the new object in the **CupcakeController** constructor with the value **IHostingEnvironment environment**.

#### Task 3: Use Entity Framework to retrieve data.

1. In the **CupcakeController** class, edit the code in the **Index** action by using the following information:

   - Return class: **View**
   - View name: **Index**
   - Model: **_repository.GetCupcakes()**

2. Add a method for the **Details** action by using the following information:

   - Scope: **public**
   - Return Type: **IActionResult**
   - Name: **Details**
   - Parameters: One integer called **id**

3. Within the **Details** action code block, add code to find a single **Cupcake** object from the accepted **id**.

4. If no **Cupcake** with the right Id is found, return the **NotFound** value.

5. If a **Cupcake** with the right Id is found, pass it to a view called **Details**.

6. Add a method for the **PopulateBakeriesDropDownList** method by using the following information:

   - Scope: **public**
   - Return Type: **void**
   - Name: **PopulateBakeriesDropDownList**
   - Parameter: **int? selectedBakery = null**

7. Within the **PopulateBakeriesDropDownList** method code block, add code to get **IQueryable&lt;Bakery&gt;** using the the following method from the repository **PopulateBakeriesDropDownList**, and store the result in a **ViewBag**.

#### Task 4: Manipulating data using Entity Framework. 

1. In the **CupcakeController** class, Add a method for the **Create** action by using the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**

2. Within the **Create** method, call the **PopulateBakeriesDropDownList** method to send the **ViewBag** object with parameters to the view.

2. In the **CupcakeController** class, Add another method for the **Create** action by using the following information:

      - HTTP verb: **HTTP Post**
      - Scope: **public**
      - Return type: **IActionResult**
      - Name: **Create**
      - Parameters: a **Cupcake** object called **cupcake**.

3.  Within the **Create** method, if the **ModelState.IsValid** is valid, call the **CreateCupcake** from the repository, and redirect to action **Index**.

4. If **ModelState.IsValid** is not valid, pass the **cupcake.BakeryId** to the **PopulateBakeriesDropDownList** method, and the **Cupcake** object to a view called **Create**.

5. In the **CupcakeController** class, Add a method for the **Edit** action by using the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Edit**
   - Parameter: One integer called **id**

6. Within the **Edit** method, call the **GetCupcakeById** from the repository, with the accepted **id**.

7. If no **Cupcake** with the right Id is found, return the **NotFound** value.

8. Otherwise, pass the **cupcake.BakeryId** to the **PopulateBakeriesDropDownList** method, and **Cupcake** object to a view called **Edit**.

9. In the **CupcakeController** class, Add another method for the **Edit** action by using the following information:

       - HTTP verb: **HTTP Post**
       - Scope: **public**
       - Return type: **IActionResult**
       - Name: **EditPost**
       - Parameter: One integer called **Id**

10. Within the **Edit** method, call the **GetCupcakeById** from the repository, with the accepted **id**, and call the **Async** method **TryUpdateModelAsync** with the following information: 

       - First parameter: a **Cupcake** with the accepted **id**
       - Second parameter: **empty string**
       - Lambda  expression: **c =&gt; c.BakeryId** , **c =&gt; c.CupcakeType**, **c =&gt; c.Description**, **c =&gt; c.GlutenFree**,**c =&gt; c.Price** 

11. If the **TryUpdateModelAsync** method returns true, call the **SaveChanges** from the repository, and redirect to action **Index**.

12. Otherwise, pass the **Cupcake** with the accepted **id** with the following parameter **cupcake.BakeryId** to the **PopulateBakeriesDropDownList** method, and **Cupcake** object to a view called **Edit**.

13. In the **CupcakeController** class, Add a method for the **Delete** action by using the following information:

       - HTTP verb: **HTTP Get**
       - Scope: **public**
       - Return type: **IActionResult**
       - Name: **Delete**
       - Parameter: One integer called **id**

14. Within the **Delete** method, call the **GetCupcakeById** from the repository, with the accepted **id**.

15. If no **Cupcake** with the right Id is found, return the **NotFound** value.

16. Otherwise, pass the **cupcake.BakeryId** to the view called **Delete**.

17. In the **CupcakeController** class, Add another method for the **Delete** action by using the following information:

       - HTTP verb: **HTTP Post**
       - Scope: **public**
       - Return type: **IActionResult**
       - Name: **DeleteConfirmed**
       - Parameter: One integer called **Id**

18. Within the **Delete** method, call the **DeleteCupcake** from the repository, with the accepted **id**, and redirect to action **Index**.

#### Task 5: Run the application.

1. Save all the changes.

2. Run the web application in non-debugging mode.

3. Click the **Add Cupcakes** button.

4. On the **Add Cupcake to The Shop** page, Create a new cupcake with the following credentials:

    - Bakery: **_&lt;A bakery of your choice&gt;_**
    - Cupcake Type: **_&lt;A cupcake type of your choice&gt;_**
    - Description: **_&lt;A cupcake description of your choice&gt;_**
    - Gluten Free: **_&lt;Choose if the cupcake is gluten-free&gt;_**
    - Price: **_&lt;A cupcake price of your choice&gt;_**
    - Cupcake Picture: **_&lt;A cupcake picture of your choice&gt;_**

4. Verify the details of the newly added cupcake.

5. Select a cupcake of your choice, click **Details**, verify the cupcake details, and then click **Back to List**.

6. Select a cupcake of your choice, and then click **Edit**.

7. On the **Edit Cupcakes** page, edit a cupcake with the following credential:

    - Price: **_&lt;A cupcake price of your choice&gt;_**

8. On the **Cupcakes Shop** page, select the cupcake you edit, and click **Details**, verify the cupcake details, and then click **Back to List**.

9. On the **Cupcakes Shop** page, select the cupcake you edit, and click **Details**, verify the cupcake deleted.

10. **Stop debugging**.

>**Results** : After completing this exercise, you will be able to use Entity Framework Core to retrieve and store data through a Repository in the **CupcakeController**. 

### Exercise 3: Use Entity Framework Core to Connect to Microsoft SQL Server

#### Scenario

In this exercise, you will:

- Connecting to a Microsoft SQL Server database.
- Use the repository in the controller.
- Retrieve cupcakes and bakeries data.
- Manipulating cupcakes and bakeries data.

The main tasks for this exercise are as follows:

1. Connecting to a Microsoft SQL Server.

2. Create an app Settings File, and specifying a connection string.

3. Use Migrations.

#### Task 1: Connecting to a Microsoft SQL Server.

1. In the **Startup** class, in the **ConfigureServices** method, initialize the **CupcakeContext** to use **Microsoft SQL Server** instead of **In Memory database**.

#### Task 2: Specifying a connection string in a configuration file. 

1. Add a new top-level **App Settings File** to the **Cupcakes** project.

2. In the **App Settings File** json file, edit the **DefaultConnection** to the **Database** name of your choice.

#### Task 3: Use Migrations.

1. In the **Cupcakes.csproj** file, add the **Microsoft.EntityFrameworkCore.Tools.DotNet** package to the DotNetCliToolReference collection using the following information:

      - Include: **Microsoft.EntityFrameworkCore.Tools.DotNet**
      - Version: **2.0.0**

2. Save all the changes.

3. In the Solution Explorer, Open Folder in File Explorer.

4. In the address bar type **cmd**, and press Enter.

5. In the command Line window, verify that the **Entity Framework tools** for the command-line interface provided correctly in Microsoft.EntityFrameworkCore.Tools.DotNet.

6. In the command Line window, verify that the Database name is identical to the name in the **appsettings.json** file.

7. In the command Line window, Enter the command that will create the database from scratch.

>**Note:** Verify the newly added folder **Migrations**.

9. In the command Line window, Enter the command that will apply the migration to the database.

10. In the **SQL Server Object Explorer**, verify the **BakeriesDb** tables.

#### Task 4: Run the application.

1. Save all the changes.

2. Run the web application in non-debugging mode.

3. Click the **Add Cupcakes** button.

4. On the **Add Cupcake to The Shop** page, Create a new cupcake with the following credentials:

    - Bakery: **_&lt;A bakery of your choice&gt;_**
    - Cupcake Type: **_&lt;A cupcake type of your choice&gt;_**
    - Description: **_&lt;A cupcake description of your choice&gt;_**
    - Gluten Free: **_&lt;Choose if the cupcake is gluten-free&gt;_**
    - Price: **_&lt;A cupcake price of your choice&gt;_**
    - Cupcake Picture: **_&lt;A cupcake picture of your choice&gt;_**

4. Verify the details of the newly added cupcake.

5. Select a cupcake of your choice, click **Details**, verify the cupcake details, and then click **Back to List**.

6. Select a cupcake of your choice, and then click **Edit**.

7. On the **Edit Cupcakes** page, edit a cupcake with the following credential:

    - Price: **_&lt;A cupcake price of your choice&gt;_**

8. On the **Cupcakes Shop** page, select the cupcake you edit, and click **Details**, verify the cupcake details, and then click **Back to List**.

9. On the **Cupcakes Shop** page, select the cupcake you edit, and click **Details**, verify the cupcake deleted.

10. **Stop debugging**, and **close** Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created a Cupcakes shop application in which users can submit, edit, delete and View cupcales details.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.