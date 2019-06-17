# Module 7: Using Entity Framework Core in ASP.NET Core

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

Wherever a path is mentioned as **/**, it refers to the project root folder. For example, if instructed to add the **appsettings.json** file to the **/** folder in a project named **Example**, you will add it in the base **Example** folder for the project.

# Lab: Using Entity Framework Core in ASP.NET Core

#### Scenario

Your company is planning to write a web application for managing cupcakes and bakeries. To connect the application to a database, your development team has decided to use Entity Framework Core. You have been asked to create a class that derives from a DbContext class, and then use the class to retrieve data from the database and store data in the database. The application will enable users to store uploaded cupcakes, edit their properties, view their details, and delete them in 

#### Objectives

After completing this lab, you will be able to:

- Add new models to the application and add properties to the models.
- Add a class that derives from the DbContext class.
- Use a repository for the application to connect to the database.
- Use Entity Framework Core to retrieve and store data.
- Use Migrations to create a database and to update the schema of the database.


#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

Ensure that you have cloned the 20486D directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 

### Exercise 1: Adding Entity Framework Core 

#### Scenario

In this exercise, you will first add the Cupcake model and the Bakery model to the Cupcake web application. You will then add an Entity Framework context class named CupcakeContext to the web application. After that you will configure the CupcakeContext class to connect to an SQLite database. Finally, you will use data seeding to populate the database with sample data when the database is created.

The main tasks for this exercise are as follows:

1. Create model classes

2. Create a class that derives from DbContext

3. Set up Entity Framework Core to use SQLite

4. Use OnModelCreating to populate the database

#### Task 1: Create model classes

1. Go to **[Repository Root]\Allfiles\Mod07\Labfiles\01_Cupcakes_begin**, and then open **Cupcakes.sln**.

    >**Note**: If a **Security Warning for Cupcakes** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. Create a new class with the following information:

    - Name: **Cupcake**
    - Folder: **Models**

3. In the **Cupcake** class, add the **USING** statements for the following namespaces:

   - **Microsoft.AspNetCore.Http**
   - **System.ComponentModel.DataAnnotations**
   - **System.ComponentModel.DataAnnotations.Schema**

4. Add a new property with the following information:

   - Scope: **public**
   - Name: **CupcakeId**
   - Type: **int**
   - Access: **Read and write**

5. Add a new property with the following information:

   - Scope: **public**
   - Name: **CupcakeType**
   - Type: **CupcakeType?**
   - Access: **Read and write**

6. Add a new property with the following information:

   - Scope: **public**
   - Name: **Description**
   - Type: **string**
   - Access: **Read and write**

7. Add a new property with the following information:

   - Scope: **public**
   - Name: **GlutenFree**
   - Type: **bool**
   - Access: **Read and write**

8. Add a new property with the following information:

   - Scope: **public**
   - Name: **Price**
   - Type: **double?**
   - Access: **Read and write**

9. Add a new property with the following information:

   - Scope: **public**
   - Name: **PhotoAvatar**
   - Type: **IFormFile**
   - Access: **Read and write**

10. Add a new property with the following information:

    - Scope: **public**
    - Name: **ImageName**
    - Type: **string**
    - Access: **Read and write**

11. Add a new property with the following information:

    - Scope: **public**
    - Name: **PhotoFile**
    - Type: **byte[]**
    - Access: **Read and write**

12. Add a new property with the following information:

    - Scope: **public**
    - Name: **ImageMimeType**
    - Type: **string**
    - Access: **Read and write**

13. Add a new property with the following information:

    - Scope: **public**
    - Name: **BakeryId**
    - Type: **int?**
    - Access: **Read and write**

14. Add a new property with the following information:

    - Scope: **public**
    - Name: **Bakery**
    - Type: **Bakery**
    - Access: **Read and write**
    - Modifier: **virtual**

15. Above the **CupcakeId** property, add a **Key** attribute.

16. Above the **CupcakeType** property, add a **Required** attribute with the following information:

    - Error Message: **Please select a cupcake type**

17. Add a **Display** attribute with the following information:

    - Name: **Cupcake Type:**

18. Above the **Description** property, add a **Required** attribute with the following information:

    - Error Message: **Please enter a cupcake description**

19. Add a **Display** attribute with the following information:

    - Name: **Description:**

20. Above the **GlutenFree** property, add a **Display** attribute with the following information:

    - Name: **Gluten Free:**

21. Above the **Price** property, add a **Range** attribute with the following information:

    - Minimum: **1**
    - Maximum: **15**

22. Add a **Required** attribute with the following information:

    - Error Message: **Please enter a cupcake price**

23. Add a **DataType** attribute with the following information:

    - Data Type: **DataType.Currency**

24. Add a **Display** attribute with the following information:

    - Name: **Price:**

25. Above the **PhotoAvatar** property, add a **NotMapped** attribute.

26. Add a **Display** attribute with the following information:

    - Name: **Cupcake Picture:**

27. Above the **BakeryId** property, add a **Required** attribute with the following information:

    - Error Message: **Please select a bakery**

28. Create a new model with the following information:

     - Name: **Bakery**
     - Folder: **Models**

29. In the **Bakery** class, add a **USING** statement for the following namespace:

    - **System.ComponentModel.DataAnnotations**

30. Add a new property with the following information:

    - Scope: **public**
    - Name: **BakeryId**
    - Type: **int**
    - Access: **Read and write**

31. Add a new property with the following information:

    - Scope: **public**
    - Name: **BakeryName**
    - Type: **string**
    - Access: **Read and write**

32. Add a new property with the following information:

    - Scope: **public**
    - Name: **Quantity**
    - Type: **int**
    - Access: **Read and write**

33. Add a new property with the following information:

     - Scope: **public**
     - Name: **Address**
     - Type: **string**
     - Access: **Read and write**

34. Add a new property with the following information:

     - Scope: **public**
     - Name: **Cupcakes**
     - Type: **ICollection&lt;Cupcake&gt;**
     - Access: **Read and write**
     - Modifier: **virtual**

35. Above the **BakeryId** property, add a **Key** attribute.

36. Above the **BakeryName** property, add a **StringLength** attribute with the following information:

    - Maximum Length: **50**
    - Minimum Length: **4**

37. Above the **Quantity** property, add a **Range** attribute with the following information:

    - Minimum: **1**
    - Maximum: **40**

38. Above the **Address** property, add a **StringLength** attribute with the following information:

    - Maximum Length: **50**
    - Minimum Length: **4**


#### Task 2: Create a class that derives from DbContext

1. Create a new folder with the following information:

   - Folder name: **Data**

2. Create a new class with the following information:

    - Name: **CupcakeContext**
    - Folder: **Data**

3. Add the **USING** statements for the following namespaces:

   - **Cupcakes.Models**
   - **Microsoft.EntityFrameworkCore**

4. Change the **CupcakeContext** class to inherit from the **DbContext** class.

5. Add a constructor with the following parameter:

   - Type: **DbContextOptions&lt;CupcakeContext&gt;**
   - Name: **options**

6. In the constructor, pass the **options** as a parameter to the **base** constructor.

7. Add a new property with the following information:

    - Scope: **public**
    - Name: **Cupcakes**
    - Type: **DbSet&lt;Cupcake&gt;**
    - Access: **Read and write**

8. Add a new property with the following information:

    - Scope: **public**
    - Name: **Bakeries**
    - Type: **DbSet&lt;Bakery&gt;**
    - Access: **Read and write**

#### Task 3: Set up Entity Framework Core to use SQLite

1. Add a NuGet Package with the following information:

   - Package: **Microsoft.EntityFrameworkCore.Sqlite** 
   - Version: **2.1.0**

2. In the **Startup** class, add the **USING** statements for the following namespaces:

   - **Microsoft.Extensions.Configuration**
   - **Cupcakes.Data**
   - **Microsoft.EntityFrameworkCore**

3. Create a new field with the following information:

   - Scope: **private**
   - Type: **IConfiguration**
   - Name: **_configuration**

4. Add a constructor with the following parameter:

   - Type: **IConfiguration**
   - Name: **configuration**

5. In the constructor, initialize the **_configuration** field with the value of the **configuration** parameter.

6. At the beginning of the **ConfigureServices** method, call the **AddDbContext** method of the **services** parameter, with the following information:

   - Type: **CupcakeContext**

7. Pass a **lambda expression** as a parameter to the **AddDbContext** method with the following information:
   - Lambda Expression: **options =>
           options.UseSqlite("Data Source=cupcake.db"))**

8. Change the **Configure** method signature to accept the following parameters:

   - Parameter:
        - Type: **IApplicationBuilder**
        - Name: **app**
   - Parameter:
        - Type: **CupcakeContext**
        - Name: **cupcakeContext**

9. At the beginning of the **Configure** method code block, call the **cupcakeContext.Database.EnsureDeleted** method.

10. At the beginning of the **Configure** method code block, call the **cupcakeContext.Database.EnsureCreated** method.

	
#### Task 4: Use OnModelCreating to populate the database

1. In the **CupcakeContext** class, add a method with the following information:

   - Scope: **protected**
   - Modifier: **override**
   - Return type: **void** 
   - Name: **OnModelCreating**
   - Parameter:
       - Type: **ModelBuilder**
       - Name: **modelBuilder**

2. In the **OnModelCreating** method, call the **Entity** method of the **modelBuilder** parameter, with the following information:

   - Type: **Bakery**

3. Call the **HasData** method of the **EntityTypeBuilder&lt;Bakery&gt;** object returned from the **Entity&lt;Bakery&gt;** method. Pass the following instances as parameters to the **HasData** method:

    - Parameters:
        - **New Bakery**:
            - BakeryId: **1**
            - BakeryName: **"Gluteus Free"**
            - Address: **"635 Brighton Circle Road"**
            - Quantity: **8**
        - **New Bakery**:
            - BakeryId: **2**
            - BakeryName: **"Cupcakes Break"**
            - Address: **"4323 Jerome Avenue"**
            - Quantity: **22**
        - **New Bakery**:
            - BakeryId: **3**
            - BakeryName: **"Cupcakes Ahead"**
            - Address: **"2553 Pin Oak Drive"**
            - Quantity: **18**
        - **New Bakery**:
            - BakeryId: **4**
            - BakeryName: **"Sugar"**
            - Address: **"1608 Charles Street"**
            - Quantity: **30**

4. Call the **Entity** method of the **modelBuilder** parameter, with the following information:

   - Type: **Cupcake**

5. Call the **HasData** method of the **EntityTypeBuilder&lt;Cupcake&gt;** object returned from the **Entity&lt;Cupcake&gt;** method. Pass the following instances as parameters to the **HasData** method:

    - Parameters:
        - **New Cupcake**:
            - CupcakeId: **1**
            - CupcakeType: **CupcakeType.Birthday**
            - Description: **"Vanilla cupcake with coconut cream"**
            - GlutenFree: **true**
            - Price: **2.5**
            - BakeryId: **1**
            - ImageMimeType: **"image/jpeg"**
            - ImageName: **"birthday-cupcake.jpg"**
        - **New Cupcake**:
            - CupcakeId: **2**
            - CupcakeType: **CupcakeType.Chocolate**
            - Description: **"Chocolate cupcake with caramel filling and chocolate butter cream"**
            - GlutenFree: **false**
            - Price: **3.2**
            - BakeryId: **2**
            - ImageMimeType: **"image/jpeg"**
            - ImageName: **"chocolate-cupcake.jpg"**
        - **New Cupcake**:
            - CupcakeId: **3**
            - CupcakeType: **CupcakeType.Strawberry**
            - Description: **"Chocolate cupcake with straberry cream filling"**
            - GlutenFree: **false**
            - Price: **4**
            - BakeryId: **3**
            - ImageMimeType: **"image/jpeg"**
            - ImageName: **"pink-cupcake.jpg"**
        - **New Cupcake**:
            - CupcakeId: **4**
            - CupcakeType: **CupcakeType.Turquoise**
            - Description: **"Vanilla cupcake with butter cream"**
            - GlutenFree: **true**
            - Price: **1.5**
            - BakeryId: **4**
            - ImageMimeType: **"image/jpeg"**
            - ImageName: **"turquoise-cupcake.jpg"**

>**Results**: After completing this exercise, you will be able to add Entity Framework Core to the Cupcake Shop application. 

### Exercise 2: Use Entity Framework Core to Retrieve and Store Data

#### Scenario

In this exercise, you will first create a repository for the web application. The repository will access an SQLite database by using Entity Framework Core. You will then use a dependency injection to inject the service to a controller. You will use the repository in the controller to access the database. In the controller, you will retrieve the cupcakes and bakeries data, and then you will manipulate the data. 

The main tasks for this exercise are as follows:

1. Create a repository

2. Update a controller to use a repository

3. Use Entity Framework Core to retrieve data

4. Manipulate data by using Entity Framework Core

5. Run the application

#### Task 1: Create a repository

1. Create a new folder with the following information:

   - Folder name: **Repositories**

2. Create a new interface with the following information:

     - Folder: **Repositories**
     - Name: **ICupcakeRepository**
     - Scope: **public**

3. In the **ICupcakeRepository** interface, add a **USING** statement for the following namespaces:

   - **Cupcakes.Models**

4. Declare a method with the following information:

   - Name: **GetCupcakes**
   - Return type: **IEnumerable&lt;Cupcake&gt;**

5. Declare a method with the following information:

   - Name: **GetCupcakeById**
   - Return type: **Cupcake**
   - Parameter:
        - Name: **id**
        - Type: **int**

6. Declare a method with the following information:

   - Name: **CreateCupcake**
   - Return type: **void**
   - Parameter:
        - Name: **Cupcake**
        - Type: **cupcake**

7. Declare a method with the following information:

   - Name: **DeleteCupcake**
   - Return type: **void**
   - Parameter:
        - Name: **id**
        - Type: **int**

8. Declare a method with the following information:

   - Name: **SaveChanges**
   - Return type: **void**

9. Declare a method with the following information:

   - Name: **PopulateBakeriesDropDownList**
   - Return type: **IQueryable&lt;Bakery&gt;**

10. Create a new class with the following information:

    - Folder: **Repositories**
    - Name: **CupcakeRepository**
    - Scope: **public**

11. In the **CupcakeRepository** class, add the **USING** statements for the following namespaces:

      - **System.IO**
      - **Cupcakes.Data**
      - **Cupcakes.Models**
      - **Microsoft.EntityFrameworkCore**

12. Modify the **CupcakeRepository** class to implement the **ICupcakeRepository** interface.

13. Create a new field with the following information:

       - Scope: **private**
       - Type: **CupcakeContext**
       - Name: **_context**

14. Add a constructor with the following parameter:

       - Scope: **public**
       - Type: **CupcakeContext**
       - Name: **context**

15. In the constructor, initialize the **_context** field with the value of the **context** parameter.

16. Add a method with the following information:

    - Scope: **public**
    - Return Type: **IEnumerable&lt;Cupcake&gt;**
    - Name: **GetCupcakes**

17. In the **GetCupcakes** method, return **IEnumerable&lt;Cupcake&gt;** by using the **_context.Cupcakes.ToList()** method.

18. Add a method with the following information:

    - Scope: **public**
    - Return Type: **Cupcake**
    - Name: **GetCupcakeById**
    - Parameter:
        - Type: **int**
        - Name: **id**

19. In the **GetCupcakeById** method, return **Cupcake** by using the **_context.Cupcakes.Include(b => b.Bakery).SingleOrDefault(c => c.CupcakeId == id)** method.

20. Add a method with the following information:

       - Scope: **public**
       - Return Type: **void**
       - Name: **CreateCupcake**
       - Parameter:
            - Type: **Cupcake**
            - Name: **cupcake**

21. In the **CreateCupcake** method, create an **IF** statement that checks that the value of **cupcake.PhotoAvatar** is not **NULL** and that **cupcake.PhotoAvatar.Length** is bigger than **0**.

22. In the **cupcake** parameter, to the **ImageMimeType** property, assign the value of **cupcake.PhotoAvatar.ContentType**.

23. In the **cupcake** parameter, to the **ImageName** property, assign the value of **Path.GetFileName(cupcake.PhotoAvatar.FileName)**.

24. Create a variable named *memoryStream* of type **var** inside a **USING** statement.

25. Initialize the *memoryStream* variable by using the **MemoryStream** constructor.

26. In the **USING** statement block, call the **CopyTo** method of the **cupcake.PhotoAvatar** property. Pass **memoryStream** as a parameter to the **CopyTo** method.

27. In the **cupcake** parameter, to the **PhotoFile** property, assign the value of **memoryStream.ToArray()**.

28. After the **IF** statement, call the **Add** method of the **_context** field. Pass **cupcake** as a parameter to the **Add** method.

29. Call the **SaveChanges** method of the **_context** field.

30. Add a method with the following information:

       - Scope: **public**
       - Return Type: **void**
       - Name: **DeleteCupcake**
       - Parameter:
            - Type: **int**
            - Name: **id**

31. In the **DeleteCupcake** method, create a *cupcake* variable of type **var**, and then assign it the value of **_context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id)**.

32. Call the **Remove** method of the **_context.Cupcakes** property. Pass **cupcake** as a parameter to the **Remove** method.

33. Call the **SaveChanges** method of the **_context** field.

34. Add a method with the following information:

    - Scope: **public**
    - Return Type: **void**
    - Name: **SaveChanges**

35. In the **SaveChanges** method, call the **SaveChanges** method of the **_context** field.

36. Add a method with the following information:

    - Scope: **public**
    - Return Type: **IQueryable&lt;Bakery&gt;**
    - Name: **PopulateBakeriesDropDownList**

37. In the **PopulateBakeriesDropDownList** method, create a variable named *bakeriesQuery* of type **var**, and then assign it the value of the following **LINQ** query:

    - From: **b in _context.Bakeries**
    - Orderby: **BakeryName**
    - Select: **b**

38. Return **IQueryable&lt;Bakery&gt;** by using the *bakeriesQuery* variable.

39. In the **Startup** class, add a **USING** statement for the following namespace:

      - **Cupcakes.Repositories**

40. At the beginning of the **ConfigureServices** method, call the **AddTransient** method of **services** parameter with the following information:

    - Interface: **ICupcakeRepository**
    - Implementation: **CupcakeRepository**

#### Task 2: Update a controller to use a repository

1. In the **CupcakeController** class, add the **USING** statements for the following namespaces:

      - **Microsoft.AspNetCore.Hosting**
      - **Cupcakes.Models**
      - **Cupcakes.Repositories**
      - **Microsoft.AspNetCore.Mvc.Rendering**
      - **Microsoft.EntityFrameworkCore**

2. In the **CupcakeController** class, create a new field with the following information:

   - Scope: **private**
   - Type: **ICupcakeRepository**
   - Name: **_repository**

3. Create a new field with the following information:

   - Scope: **private**
   - Type: **IHostingEnvironment**
   - Name: **_environment**

4. Add a constructor with the following parameters:

   - Parameter:
        - Scope: **public**
        - Type: **ICupcakeRepository**
        - Name: **repository**
   - Parameter:
        - Type: **IHostingEnvironment**
        - Name: **environment**

5. In the **CupcakeController** constructor, initialize the **_repository** field with the value of the **repository** parameter.

6. Initialize the **_environment** field with the value of the **environment** parameter.

#### Task 3: Use Entity Framework Core to retrieve data

1. Edit the code in the **Index** action to return the **ViewResult** result by using the **View** method. Pass **_repository.GetCupcakes()** as a parameter to the **View** method.

2. Add a method with the following information:

   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Details**
   - Parameter:
        - Type: **int**
        - Name: **id**

3. In the **Details** action, add a variable named *cupcake* of type **var**. Initialize the *cupcake* variable with the value of **_repository.GetCupcakeById(id)**.

4. Create an **IF** statement that checks that the value of the *cupcake* variable is **NULL**.

5. Inside the **IF** statement code block, return the **NotFoundResult** result by using the **NotFound** method.

6. After the **IF** statement, return the **ViewResult** result by using the **View** method. Pass the *cupcake* variable as a parameter to the **View** method.

7. Add a method with the following information:

    - Scope: **private**
    - Return type: **void**
    - Name: **PopulateBakeriesDropDownList**
    - Parameter:
        - Type: **int?**
        - Name: **selectedBakery**
        - Defualt Value: **null**

8. In the **PopulateBakeriesDropDownList** method, add a variable named *bakeries* of type **var**. Initialize the *bakeries* variable with the value of **_repository.PopulateBakeriesDropDownList()**.

9. Save the following key and value in the **ViewBag** property:

    - Key: **BakeryID**
    - Value: **new SelectList(bakeries.AsNoTracking(), "BakeryId", "BakeryName", selectedbakery)**

#### Task 4: Manipulate data by using Entity Framework Core

1. In the **CupcakeController** class, add a method with the following information:

   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**

2. Above the **Create** method, add an **HttpGet** attribute.

3. In the **Create** action, call the **PopulateBakeriesDropDownList** method.

4. Return the **ViewResult** result by using the **View** method.

5. Add a method with the following information:

    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **CreatePost**
    - Parameter:
        - Type: **Cupcake**
        - Name: **cupcake**

6. Above the **CreatePost** method, add an **HttpPost** attribute.

7. Above the **CreatePost** method, add an **ActionName** attribute with the following information:

    - Name: **Create**

8. In the **CreatePost** method, create an **IF** statement that checks that the value of the **ModelState.IsValid** is **true**.

9. Inside the **IF** statement code block, call the **CreateCupcake** method of the **_repository** field. Pass **cupcake** as a parameter to the **CreateCupcake** method.

10. Return the **RedirectToActionResult** result by using the **RedirectToAction** method. Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

11. After the **IF** statement, call the **PopulateBakeriesDropDownList** method. Pass **cupcake.BakeryId** as a parameter to the **PopulateBakeriesDropDownList** method.

12. Return the **ViewResult** result by using the **View** method. Pass **cupcake** as a parameter to the **View** method.

13. Add a method with the following information:

    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Edit**
    - Parameter:
        - Type: **int**
        - Name: **id**

14. Above the **Edit** method, add an **HttpGet** attribute.

15. In the **Edit** action, add a variable named *cupcake* of type **Cupcake**. Initialize the *cupcake* variable with the value of **_repository.GetCupcakeById(id)**.

16. Create an **IF** statement that checks that the value of the **cupcake** is **NULL**.

17. Inside the **IF** statement code block, return the **NotFoundResult** result by using the **NotFound** method.

18. After the **IF** statement, call the **PopulateBakeriesDropDownList** method. Pass **cupcake.BakeryId** as a parameter to the **PopulateBakeriesDropDownList** method.

19. Return the **ViewResult** result by using the **View** method. Pass **cupcake** as a parameter to the **View** method.

20. Add a method with the following information:

    - Scope: **public**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **EditPost**
    - Parameter:
        - Type: **int**
        - Name: **id**

21. Above the **EditPost** method, add an **HttpPost** attribute.

22. Above the **EditPost** method, add an **ActionName** attribute with the following information:

    - Name: **Edit**

23. In the **EditPost** method, add a variable named *cupcakeToUpdate* of type **var**. Initialize the *cupcakeToUpdate* variable with the value of **_repository.GetCupcakeById(id)**.

24. Add a variable named *isUpdated* of type **bool**. Initialize the *isUpdated* variable with the value of **await TryUpdateModelAsync<Cupcake>(
                                cupcakeToUpdate,
                                "",
                                c => c.BakeryId, 
                                c => c.CupcakeType, 
                                c => c.Description, 
                                c => c.GlutenFree,
                                c => c.Price)**.

25. Create an **IF** statement that checks that the value of the *isUpdated* variable is **TRUE**.

26. Inside the **IF** statement code block, call the **SaveChanges** method of the **_repository** field.

27. Return the **RedirectToActionResult** result by using the **RedirectToAction** method. Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

28. After the **IF** statement, call the **PopulateBakeriesDropDownList** method. Pass **cupcakeToUpdate.BakeryId** as a parameter to the **PopulateBakeriesDropDownList** method.

29. Return the **ViewResult** result by using the **View** method. Pass **cupcakeToUpdate** as a parameter to the **View** method.

30. Add a method with the following information:

    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Delete**
    - Parameter:
        - Type: **int**
        - Name: **id**

31. Above the **Delete** method, add an **HttpGet** attribute.

32. In the **Delete** method, add a variable named *cupcake* of type **var**. Initialize the *cupcake* variable with the value of **_repository.GetCupcakeById(id)**.

33. Create an **IF** statement that checks if the value of the **cupcake** is **NULL**.

34. Inside the **IF** statement code block, return the **NotFoundResult** result by using the **NotFound** method.

35. After the **IF** statement, return the **ViewResult** result by using the **View** method. Pass **cupcake** as a parameter to the **View** method.

36. Add a method with the following information:

    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **DeleteConfirmed**
    - Parameter:
        - Type: **int**
        - Name: **id**

37. Above the **DeleteConfirmed** method, add an **HttpPost** attribute.

38. Above the **DeleteConfirmed** method, add an **ActionName** attribute with the following information:

    - Name: **Delete**

39. In the **Delete** action with **HTTP POST** verb, call the **DeleteCupcake** method of the **_repository** field. Pass **id** as a parameter to the  **DeleteCupcake** method.

40. Return **RedirectToActionResult** by using the **RedirectToAction** method. Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

#### Task 5: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In Microsoft Edge, click **Add Cupcake**.

    >**Note**: The browser displays the **Create** action inside the **CupcakesController**.

4. On the **Add a Cupcake to the Shop** page, create a new cupcake with the following credentials:

    - Bakery: **_&lt;A bakery of your choice&gt;_**
    - Cupcake Type: **_&lt;A cupcake type of your choice&gt;_**
    - Description: **_&lt;A cupcake description of your choice&gt;_**
    - Gluten Free: **_&lt;Choose if the cupcake is gluten-free&gt;_**
    - Price: **_&lt;A cupcake price of your choice between 1 and 15&gt;_**
    - Cupcake Picture: **import from [Repository Root]\Allfiles\Mod07\Labfiles\Image a strawberry-cupcake.jpg**

5. Click **Submit**.

6. On the **Welcome to our Cupcakes Shop** page, verify the newly submitted cupcake details.

7. Select a cupcake of your choice, and click **Details**.

8. View the cupcake details, and then click **Back to List**.

9. Select a cupcake of your choice, and then click **Edit**.

10. On the **Edit a Cupcake** page, edit a cupcake with the following information:

    - Price: **_&lt;A cupcake price of your choice between 1 and 15&gt;_**

11. On the **Welcome to our Cupcakes Shop** page, select the cupcake you edited, and then click **Details**.

12. Verify the newly edited cupcake details, and then click **Back to List**.

13. On the **Welcome to our Cupcakes Shop** page, select a cupcake of your choice, and then click **Delete**.

14. On the **Cupcake's Delete** page, click **Delete**.

15. On the **Welcome to our Cupcakes Shop** page, verify that the cupcake is deleted.

16. Close Microsoft Edge.

>**Results**: After completing this exercise, you will be able to use Entity Framework Core to retrieve and store data through a repository in the **CupcakeController**. 

### Exercise 3: Use Entity Framework Core to Connect to Microsoft SQL Server

#### Scenario

In this exercise, you will first configure the Cupcakes Shop web application to connect to an SQL Server database instead of connecting to an SQLite database. You will then store the connection string which is used to connect to the database in a configuration file. After that, you will use Migrations to create the database. Finally, you will add a property to an entity, and use Migrations to update the database schema.

The main tasks for this exercise are as follows:

1. Connect to a Microsoft SQL Server

2. Specify a connection string in a configuration file

3. Use Migrations to create a database

4. Run the application

5. Use Migrations to update the database schema

6. Run the application

#### Task 1: Connect to a Microsoft SQL Server

1. In the **Startup** class, in the **ConfigureServices** method, add a variable named *connectionString* of type **string**. Initialize the *connectionString* variable with the value **"Server=(localdb)\\MSSQLLocalDB;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true"**.

2. Replace the **lambda expression** which is sent as a parameter to the **AddDbContext** method with the following information:

     - Lambda Expression: **options => options.UseSqlServer(connectionString))**.

3. In the **Configure** method, remove the **cupcakeContext** parameter from the method signature. 

4. Remove the **cupcakeContext.Database.EnsureDeleted** method call. 

5. Remove the **cupcakeContext.Database.EnsureCreated** method call.

#### Task 2: Specify a connection string in a configuration file

1. Create a configuration file with the following information
     - File Name: **appsettings.json**
     - Folder: **/**

2. Change the value of the **Database** property to **BakeriesDb**.

3. In the **Startup** class, in the **ConfigureServices** method, delete the declaration of the *connectionString* variable.

4. Replace the **lambda expression** which is sent as a parameter to the **AddDbContext** method with the following information:

     - Lambda Expression: **options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))**

#### Task 3: Use Migrations to create a database

1. Open the **Package Manager Console** window. 

2. Create a migration by using the following information:

     - Command: **Add-Migration**
     - Migration Name: **InitalCreate**

    >**Note**: In **Solution Explorer**, verify if a new folder named **Migrations** is created with multiple files.

3. Create the database by using the following information:

     - Command: **Update-Database**

4. Open **SQL Server Object Explorer**. 

5. In **SQL Server Object Explorer**, view the **BakeriesDb** database tables.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In Microsoft Edge, click **Add Cupcake**.

    >**Note**: The browser displays the **Create** action inside the **CupcakesController**.

4. On the **Add a Cupcake to The Shop** page, create a new cupcake with the following credentials:

    - Bakery: **_&lt;A bakery of your choice&gt;_**
    - Cupcake Type: **_&lt;A cupcake type of your choice&gt;_**
    - Description: **_&lt;A cupcake description of your choice&gt;_**
    - Gluten Free: **_&lt;Choose if the cupcake is gluten-free&gt;_**
    - Price: **_&lt;A cupcake price of your choice between 1 and 15&gt;_**
    - Cupcake Picture: **import from [Repository Root]\Allfiles\Mod07\Labfiles\Image a strawberry-cupcake.jpg**

5. Click **Submit**.

6. On the **Welcome to our Cupcakes Shop** page, verify the newly submitted cupcake details.

7. Select a cupcake of your choice, and click **Details**.

8. View the cupcake details, and then click **Back to List**.

9. Select a cupcake of your choice, and then click **Edit**.

10. On the **Edit Cupcakes** page, edit a cupcake with the following credential:

    - Price: **_&lt;A cupcake price of your choice between 1 and 15&gt;_**

11. On the **Welcome to our Cupcakes Shop** page, select the cupcake you edited, and then click **Details**.

12. Verify the newly edited cupcake details and then click **Back to List**.

13. On the **Welcome to our Cupcakes Shop** page, select a cupcake of your choice, and then click **Delete**.

14. On the **Cupcake's Delete** page, click **Delete**.

15. On the **Welcome to our Cupcakes Shop** page, verify that the cupcake is deleted.

16. Close Microsoft Edge.


#### Task 5: Use Migrations to update the database schema 

1. In the **Cupcake** class, add a new property with the following information:

   - Scope: **public**
   - Name: **CaloricValue**
   - Type: **int**
   - Access: **Read and write**

2. Add a **Display** attribute with the following information:

    - Name: **Caloric Value:**

3. In the **CupcakeContext** class, locate the **cupcake** instance with the following information:

    - Name: **CupcakeId**
    - Value: **1**

4. Add a new parameter with the following information:

    - Name: **CaloricValue**
    - Value: **355**

5. Locate the cupcake instance with the following information:

    - Name: **CupcakeId**
    - Value: **2**

6. Add a new parameter with the following information:

    - Name: **CaloricValue**
    - Value: **195**

7. Locate the cupcake instance with the following information:

    - Name: **CupcakeId**
    - Value: **3**

8. Add a new parameter with the following information:

    - Name: **CaloricValue**
    - Value: **295**

9. Locate the cupcake instance with the following information:

    - Name: **CupcakeId**
    - Value: **4**

10. Add a new parameter with the following information:

    - Name: **CaloricValue**
    - Value: **360**

11. In the **Details.cshtml** file, add a **DIV** element before the **DIV** element with the following information: 

    - Content: **&lt;a asp-action="Index"&gt;Back to List&lt;/a&gt;**

12. In the **DIV** element, add a **P** element with the following information:

	- Class: **display-label**
    - Content: **@Html.DisplayNameFor(model => model.CaloricValue)**

13. After the **P** element, add a **P** element with the following information:

	- Class: **display-field**
    - Content: ***@Html.DisplayFor(model => model.CaloricValue)**

14. In the **Edit.cshtml** file, add a **DIV** element before the **DIV** element with the following information: 

     - asp-for: **Price**

15. Add a **DIV** element with the following information:

     - Class: **form-field**

16. In the **DIV** element, add a **LABEL** element with the following information:

    - asp-for: **CaloricValue**

17. Add an **INPUT** element with the following information:

     - asp-for: **CaloricValue**

18. After the **INPUT** element with **asp-for="CaloricValue"** helper, add a **SPAN** element with the following information:
    - asp-validation-for: **CaloricValue**

19. In the **Create.cshtml** file, add a **DIV** element before the **DIV** element with the following information: 

     - asp-for: **Price**

20. Add a **DIV** element with the following information:

     - Class: **form-field**

21. In the **DIV** element, add a **LABEL** element with the following information:

      - asp-for: **CaloricValue**

22. Add an **INPUT** element with the following information:

      - asp-for: **CaloricValue**

23. After the **INPUT** element with **asp-for="CaloricValue"** helper, add a **SPAN** element with the following information:
      - asp-validation-for: **CaloricValue**


24. Open the **Package Manager Console** window.

25. Create a **migration** by using the following information:

     - Command: **Add-Migration**
     - Migration name: **AddCupcakeCaloricValue**

26. Create the database by using the following information:

     - Command: **Update-Database**

    >**Note**: In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, under **Migrations**, verify that a new file is created.

#### Task 6: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. Select a cupcake of your choice, and click **Details**.

    >**Note**: The browser displays the caloric value of the cupcake. 

4. Verify the cupcake details, and then click **Back to List**.

5. Close Microsoft Edge.

6. Close Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created a Cupcakes Shop application in which users can add a new cupcake, edit a cupcake, delete a cupcake and view a cupcake’s details.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
