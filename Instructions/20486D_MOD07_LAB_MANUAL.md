# Module 7: Using Entity Framework Core in ASP.NET Core

# Lab: Using Entity Framework Core in ASP.NET Core

#### Scenario

You are planning to create and code an MVC models that implement your plan for cupcakes and bakeries, in the application. To connect the application to a data store, your development team has decided to use Entity Framework. You have been asked to create a class that derives from a DbContext class, and then use the class to retrieve data from the data store and store data in the data store.
The application enables to store uploaded cupcakes, edit their properties, view their details, and delete them in response to user requests.

#### Objectives

After completing this lab, you will be able to:

- Add new models to the application and add properties to the model.
- Add a class that derives from DbContext.
- Use a Repository in the project.
- Use Entity Framework Core to Retrieve and Store Data in the application.
- Use Visual Studio to create a new Microsoft SQL database and connect to the database.
- Use Migrations in the application.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

### Exercise 1: Adding Entity Framework Core 

#### Scenario

In this exercise, you will:

- Add a Cupcake model and a Bakery model.
- Add a CupcakeContext class.
- Set CupcakeContext as an In Memory database.
- Add a OnModelCreating method and populate the database.

The main tasks for this exercise are as follows:

1. Create model classes.

2. Create a class that derives from DbContext.

3. Set up Entity Framework to use an In Memory database.

4. Using OnModelCreating to populate the database.

#### Task 1: Create model classes

1. From **Allfiles\Mod04\Labfiles\01_WorldJourney_begin**, open the **Cupcakes.sln**.

2. Create a new model with the following information:

    - Name: **Cupcake**
    - Folder: **Models**

3. In the **Cupcake** class, add **using** statements for the following namespaces:

   - **Microsoft.AspNetCore.Http**
   - **System.ComponentModel.DataAnnotations**
   - **System.ComponentModel.DataAnnotations.Schema**

4. Add a new property with the following information:

   - Scope:   **public**
   - Name: **CupcakeId**
   - Type: **int**
   - Access: **Read and write**

5. Add a new property with the following information:

   - Scope:   **public**
   - Name: **CupcakeType**
   - Type: **CupcakeType?**
   - Access: **Read and write**

6. Add a new property with the following information:

   - Scope:   **public**
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

16. Above the **CupcakeType** property,  add a **Required** attribute with the following information:

    - Error Message: **Please select a cupcake type**

17. Add a **Display** attribute with the following information:

    - Name: **Cupcake Type:**

18. Above the **Description** property,  add a **Required** attribute with the following information:

    - Error Message: **Please enter a cupcake description**

19. Add a **Display** attribute with the following information:

    - Name: **Description:**

20. Above the **GlutenFree** property,  add a **Display** attribute with the following information:

    - Name: **Gluten Free:**

21. Above the **Price** property,  add a **Range** attribute with the following information:

    - Minimum: **1**
    - Maximum: **15**

22. Add a **Required** attribute with the following information:

    - Error Message: **Please enter a cupcake price**

23. Add a **DataType** attribute with the following information:

    - Data Type: **DataType.Currency**

24. Add a **Price** attribute with the following information:

    - Name: **Price:**

25. Above the **PhotoAvatar** property,  add a **NotMapped** attribute.

26. Add a **Display** attribute with the following information:

    - Name: **Cupcake Picture:**

27. Above the **BakeryId** property,  add a  **Required** attribute with the following information:

    - Error Message: **Please select a bakery**

28.  Create a new model with the following information:

     - Name: **Bakery**
     - Folder: **Models**

29. In the **Bakery** class, add a **using** statement for the following namespace:

    - **System.ComponentModel.DataAnnotations**

30. Add a new property with the following information:

    - Scope:   **public**
    - Name: **BakeryId**
    - Type: **int**
    - Access: **Read and write**

31. Add a new property with the following information:

    - Scope:   **public**
    - Name: **BakeryName**
    - Type: **string**
    - Access: **Read and write**

32. Add a new property with the following information:

    - Scope:   **public**
    - Name: **Quantity**
    - Type: **int**
    - Access: **Read and write**

33. Add a new property with the following information:

     - Scope:   **public**
     - Name: **Address**
     - Type: **string**
     - Access: **Read and write**

34. Add a new property with the following information:

     - Scope:   **public**
     - Name: **Cupcakes**
     - Type: **ICollection&lt;Cupcake&gt;**
     - Access: **Read and write**
     - Modifier: **virtual**

35. Above the **BakeryId** property, add a **Key** attribute.

36. Above the **BakeryName** property,  add a **StringLength** attribute with the following information:

    - Maximum Length: **50**
    - Minimum Length: **4**

37. Above the **Quantity** property,  add a **Range** attribute with the following information:

    - Minimum: **1**
    - Maximum: **40**

38. Above the **Address** property,  add a **StringLength** attribute with the following information:

    - Maximum Length: **50**
    - Minimum Length: **4**


#### Task 2: Create a class that derives from DbContext

1. Create a new folder with the following information:

   - Folder name: **Data**

2. Create a new class with the following information:

    - Name: **CupcakeContext**
    - Folder: **Data**

3. Add **using** statements for the following namespaces:

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

#### Task 3: Set up Entity Framework to use an In Memory database

1. In the **Startup** class, add **using** statements  for the following namespaces:

   - **Microsoft.Extensions.Configuration**
   - **Cupcakes.Data**
   - **Microsoft.EntityFrameworkCore**

2. Create a new field with the following information:

   - Scope: **private**
   - Type: **IConfiguration**
   - Name: **_configuration**

3. Add a constructor with the following parameter:

   - Type: **IConfiguration**
   - Name: **configuration**

4. In the constructor, initialize the  **_configuration** field with the value of the **configuration** parameter.

5. In the beginning of the **ConfigureServices** method, call the **AddDbContext** method of the **services** parameter, with the following information:

   - Type: **CupcakeContext**

6. Pass a **lambda expression** as a parameter to the **AddDbContext** method with the following information:
   - Lambda Expression: **options =>
           options.UseInMemoryDatabase("CupcakesDb")**

7. Change the **Configure** method signature to accept the following parameters:

   - Parameter:
        - Type: **IApplicationBuilder**
        - Name: **app**
   - Parameter:
        - Type: **CupcakeContext**
        - Name: **cupcakeContext**

8. In the beginning of the **Configure** method code block, call the **cupcakeContext.Database.EnsureDeleted** method.

9. In the beginning of the **Configure** method code block, call the **cupcakeContext.Database.EnsureCreated** method.


#### Task 4: Using OnModelCreating to populate the database

1. In the **CupcakeContext** class, add an **override** method with the following information:

   - Scope: **protected**
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
            - BakeryName:  **"Gluteus Free"**
            - Address: **"635 Brighton Circle Road"**
            - Quantity: **8**
        - **New Bakery**:
            - BakeryId: **2**
            - BakeryName:  **"Cupcakes Break"**
            - Address: **"Cupcakes Break"**
            - Quantity: **22**
        - **New Bakery**:
            - BakeryId: **3**
            - BakeryName:  **"Cupcakes Ahead"**
            - Address: **"Cupcakes Break"**
            - Quantity: **18**
        - **New Bakery**:
            - BakeryId: **4**
            - BakeryName:  **"Sugar"**
            - Address: **"1608 Charles Street"**
            - Quantity: **30**

4. Call the **Entity** method of the **modelBuilder** parameter, with the following information:

   - Type: **Cupcake**

3. Call the **HasData** method of the **EntityTypeBuilder&lt;Cupcake&gt;** object returned from the **Entity&lt;Cupcake&gt;** method. Pass the following instances as parameters to the **HasData** method:

    - Parameters:
        - **New Cupcake**:
            - CupcakeId: **1**
            - CupcakeType : **CupcakeType.Birthday**
            - Description:  **"Vanilla cupcake with coconut cream"**
            - GlutenFree: **true**
            - Price: **2.5**
            - BakeryId: **1**
            - ImageMimeType:  **"image/jpeg"**
            - ImageName :  **"birthday-cupcake.jpg"**
        - **New Cupcake**:
            - CupcakeId: **2**
            - CupcakeType : **CupcakeType.Chocolate**
            - Description:  **"Chocolate cupcake with caramel filling and chocolate butter cream"**
            - GlutenFree: **false**
            - Price: **3.2**
            - BakeryId: **2**
            - ImageMimeType:  **"image/jpeg"**
            - ImageName :  **"chocolate-cupcake.jpg"**
        - **New Cupcake**:
            - CupcakeId: **3**
            - CupcakeType : **CupcakeType.Strawberry**
            - Description:  **"Chocolate cupcake with straberry cream filling"**
            - GlutenFree: **false**
            - Price: **4**
            - BakeryId: **3**
            - ImageMimeType:  **"image/jpeg"**
            - ImageName :  **"pink-cupcake.jpg"**
        - **New Cupcake**:
            - CupcakeId: **4**
            - CupcakeType : **CupcakeType.Turquoise**
            - Description:  **"Vanilla cupcake with butter cream"**
            - GlutenFree: **true**
            - Price: **1.5**
            - BakeryId: **4**
            - ImageMimeType:  **"image/jpeg"**
            - ImageName :  **"turquoise-cupcake.jpg"**

>**Results**: After completing this exercise, you will be able to add Entity Framework Core to the Cupcake Shop application. 

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

#### Task 1: Create a repository

1. Create a new folder with the following information:

   - Folder name: **Repositories**

2. Create a new interface with the following information:

     - Folder: **Repositories**
     - Name:  **ICupcakeRepository**
     - Scope: **public**

3. In the **ICupcakeRepository** interface, add a **using** statement for the following namespaces:

   - **Cupcakes.Models**

4. Declare a method with following information:

   - Name: **GetCupcakes**
   - Return type: **IEnumerable&lt;Cupcake&gt;**

5. Declare a method with following information:

   - Name: **GetCupcakeById**
   - Return type: **Cupcake**
   - Parameter:
        - Name: **id**
        - Type : **int**

6. Declare a method with following information:

   - Name: **CreateCupcake**
   - Return type: **void**
   - Parameter:
        - Name: **Cupcake**
        - Type : **cupcake**

7. Declare a method with following information:

   - Name: **DeleteCupcake**
   - Return type: **void**
   - Parameter:
        - Name: **id**
        - Type : **int**

8. Declare a method with following information:

   - Name: **SaveChanges**
   - Return type: **void**


9. Declare a method with following information:

   - Name: **PopulateBakeriesDropDownList**
   - Return type: **IQueryable&lt;Bakery&gt;**

10. Create a new class with the following information:

   - Folder: **Repositories**
   - Name:  **CupcakeRepository**
   - Scope: **public**


11. In the **CupcakeRepository** class, add **using** statements for the following namespaces:

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

       - Type: **CupcakeContext**
       - Name: **context**

15. In the constructor, initialize the **_context** field with the value of the **context** parameter.

16. Add a method with the following information:

       - Scope: **public**
       - Return Type: **void**
       - Name: **CreateCupcake**
       - Parameter:
            - Type: **Cupcake**
            - Name: **cupcake**

17. In the **CreateCupcake** method, create an **IF** statement that checks that the value of **cupcake.PhotoAvatar** is not **NULL** and that **cupcake.PhotoAvatar.Length** is bigger than **0**.

18. In the **IF** statement code block, create a variable named **lastCupcake** of type **Cupcake**. Initialize the **lastCupcake** variable with the value of **_context.Cupcakes.LastOrDefault()**.

19. Assign the **CupcakeId** property of the **cupcake** parameter, the value of **lastCupcake.CupcakeId + 1**.

20. Assign the **ImageMimeType** property of the **cupcake** parameter, the value of **cupcake.PhotoAvatar.ContentType**.

21. Assign the **ImageName** property of the **cupcake** parameter, the value of **Path.GetFileName(cupcake.PhotoAvatar.FileName)**.

22. Create a variable named **memoryStream** of type **MemoryStream** inside a **USING** statement.

23. Initialize the **memoryStream** varaible using the **MemoryStream** constructor.

24. In the **USING** statement block, call the **CopyTo** method, of the **cupcake.PhotoAvatar** property. Pass **memoryStream** as a parameter to the the **CopyTo** method.

25. Assign the **PhotoFile** property of the **cupcake** parameter, the value of **memoryStream.ToArray()**.

26. After the **IF** statement, call the **Add** method of the **_context** field. Pass a new **Cupcake** as a parameter to the **Add** method using the following information:

    - Parameter:
        - **New Cupcake**:
            - CupcakeId: **cupcake.CupcakeId**
            - Bakery : **cupcake.Bakery**
            - BakeryId:  **cupcake.BakeryId**
            - CupcakeType: **cupcake.CupcakeType**
            - Description: **cupcake.Description**
            - GlutenFree: **cupcake.GlutenFree**
            - ImageMimeType:  **cupcake.ImageMimeType**
            - ImageName :  **cupcake.ImageName**
            - PhotoAvatar :  **cupcake.PhotoAvatar**
            - PhotoFile :  **cupcake.PhotoFile**
            - Price :  **cupcake.Price**


27. Call the **SaveChanges** method of the **_context** field.

28. Add a method with the following information:

       - Scope: **public**
       - Return Type: **void**
       - Name: **DeleteCupcake**
       - Parameter:
            - Type: **int**
            - Name: **id**

29. In the **DeleteCupcake** method, create a **cupcake** varible of type **var** and assign it the value of  **_context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id)** .

30. Call the **Remove** method of the **_context.Cupcakes** property. Pass **cupcake** as a parameter to the **Remove** method.

31. Call the **SaveChanges** method of the **_context** field.

32. Add a method with the following information:

    - Scope: **public**
    - Return Type: **Cupcake**
    - Name: **GetCupcakeById**
    - Parameter:
        - Type: **int**
        - Name: **id**

33. In the **GetCupcakeById** method, return the **Cupcake** result using the **_context.Cupcakes.Include(b => b.Bakery).SingleOrDefault(c => c.CupcakeId == id)** method.

34. Add a method with the following information:

    - Scope: **public**
    - Return Type: **IEnumerable&lt;Cupcake&gt;**
    - Name: **GetCupcakes**

35. In the **GetCupcakes** method, return the **IEnumerable&lt;Cupcake&gt;** result using the **_context.Cupcakes.ToList();** method.

36. Add a method with the following information:

    - Scope: **public**
    - Return Type: **IQueryable&lt;Bakery&gt;**
    - Name: **PopulateBakeriesDropDownList**

37. In the **PopulateBakeriesDropDownList** method, create a variable named **BakeriesQuery** of type **var** and assign it the value of the following **LINQ**query:

    - From: **b in _context.Bakeries**
    - Orderby: **BakeryName**
    - Select: **b**

38.  Return the **IQueryable&lt;Bakery&gt;** result using the **BakeriesQuery** variable.

39. Add a method with the following information:

    - Scope: **public**
    - Return Type: **void**
    - Name: **SaveChanges**

40. In the **SaveChanges** method, call the **SaveChanges** method of the **_context** field.

41. In the **Startup** class, add **using** statement for the following namespace:

      - **Cupcakes.Repositories**

42. In the beginning of the **ConfigureServices** method, call the **AddTransient** method of **services** parameter with the following information:

    - Interface: **ICupcakeRepository**
    - Implementation: **CupcakeRepository**


#### Task 2: Update a controller to use a repository

1. In the **CupcakeController** class, add **using** statements for the following namespaces:

      - **Microsoft.AspNetCore.Hosting**
        **Cupcakes.Models**
        **Cupcakes.Repositories**
        **Microsoft.AspNetCore.Mvc.Rendering**
        **Microsoft.EntityFrameworkCore**

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
        - Type: **ICupcakeRepository**
        - Name: **repository**
   - Parameter:
        - Type: **IHostingEnvironment**
        - Name: **environment**

5. In the **CupcakeController** constructor, initialize the **_repository** field with the value of the **repository** parameter.

6. Initialize the **_environment** field with the value of the **environment** parameter.


#### Task 3: Use Entity Framework to retrieve data.

1. Edit the code in the **Index** action to return the **ViewResult** result using the **View** method. Pass **_repository.GetCupcakes()** as a parameter to the **View** method.

2. Add a method for the **Details** action with the following information:

   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Details**
   - Parameter:
        - Type: **int**
        - Name: **id**

3. In the **Details** action, add a varible named **cupcake** of type **var**, with the value of **_repository.GetCupcakeById(id)**.

4. Create an **IF** statement that checks that the value of the **cupcake** varible is **NULL**.

5. Inside the **IF** statement code block, return the **NotFoundResult** result using the **NotFound** method.

6. After the **IF** statement, return the **ViewResult** result using the **View** method. Pass the **cupcake** varible as a parameter to the **View** method.

7. Add a method with the following information:

    - Scope: **private**
    - Return type: **void**
    - Name: **PopulateBakeriesDropDownList**
    - Parameter:
        - Type: **int?**
        - Name: **selectedBakery**
        - Defualt Value: **null**

8. In the **PopulateBakeriesDropDownList** method, add a varible named **bakeries** of type **var**, with the value of **_repository.PopulateBakeriesDropDownList()**.

9. Save the following key and value in the **ViewBag** property:

    - Key: **BakeryID**
    - Value: **new SelectList(bakeries.AsNoTracking(), "BakeryId", "BakeryName", selectedbakery)**

#### Task 4: Manipulating data using Entity Framework. 

1. In the **CupcakeController** class, add a method for the **Create** action with the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**

2. In the **Create** action, call the **PopulateBakeriesDropDownList** method.

3. Return the **ViewResult** result using the **View** method.

4. Add a method for the **Create** action with the following information:

    - HTTP verb: **HTTP Post**
    - Action Name: **"Create"**
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **CreatePost**
    - Parameter:
        - Type: **Cupcake**
        - Name: **cupcake**

5. In the **Create** action with **HTTP POST** verb, create an **IF** statement that checks that the value of the **ModelState.IsValid**  is **true**.

6. Inside the **IF** statement code block, call the **CreateCupcake** method of the **_repository** field. Pass **cupcake** as a parameter to the **CreateCupcake** method.

7. Return the **RedirectToActionResult** result using the **RedirectToAction** method.  Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

8. After the **IF** statement, call the **PopulateBakeriesDropDownList** method. Pass **cupcake.BakeryId** as a parameter to the **PopulateBakeriesDropDownList** method.

9.  Return the **ViewResult** result using the **View** method.  Pass **cupcake** as a parameter to the **View** method.

10. Add a method for the **Edit** action with the following information:

    - HTTP verb: **HTTP Get**
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Edit**
    - Parameter:
        - Type: **int**
        - Name: **id**

11. In the **Edit** action, add a varible named **cupcake** of type **Cupcake**, with the value of **_repository.GetCupcakeById(id)**.

12. Create an **IF** statement that checks that the value of the **cupcake**  is **NULL**.

13. Inside the **IF** statement code block, return the **NotFoundResult** result using the **NotFound** method.

14. After the **IF** statement, call the **PopulateBakeriesDropDownList** method. Pass **cupcake.BakeryId** as a parameter to the **PopulateBakeriesDropDownList** method.

15.  Return the **ViewResult** result using the **View** method.  Pass **cupcake** as a parameter to the **View** method.

16. Add a method for the **Edit** action with the following information:

    - HTTP verb: **HTTP Post**
    - Action Name: **"Edit"**
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **EditPost**
    - Parameter:
        - Type: **int**
        - Name: **id**

17. In the **Edit** action with **HTTP POST** verb, add a varible named **cupcakeToUpdate** of type **var**, with the value of **_repository.GetCupcakeById(id)**.

18. Add a varible named **isUpdated** of type **bool**, with the value of                                   **await TryUpdateModelAsync<Cupcake>(
                                cupcakeToUpdate,
                                "",
                                c => c.BakeryId, 
                                c => c.CupcakeType, 
                                c => c.Description, 
                                c => c.GlutenFree,
                                c => c.Price)**.

19. Create an **IF** statement that checks that the value of the **isUpdated**  is **TRUE**.

20. Inside the **IF** statement code block, call the **SaveChanges** method of the **_repository** field.

21. Return the **RedirectToActionResult** result using the **RedirectToAction** method.  Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

22. After the **IF** statement, call the **PopulateBakeriesDropDownList** method. Pass **cupcakeToUpdate.BakeryId** as a parameter to the **PopulateBakeriesDropDownList** method.

23.  Return the **ViewResult** result using the **View** method.  Pass **cupcakeToUpdate** as a parameter to the **View** method.

24. Add a method for the **Delete** action with the following information:

    - HTTP verb: **HTTP Get**
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **Delete**
    - Parameter:
        - Type: **int**
        - Name: **id**

25. In the **Delete** action, add a varible named **cupcake** of type **Cupcake**, with the value of **_repository.GetCupcakeById(id)**.

26. Create an **IF** statement that checks that the value of the **cupcake**  is **NULL**.

27. Inside the **IF** statement code block, return the **NotFoundResult** result using the **NotFound** method.

28. After the **IF** statement, return the **ViewResult** result using the **View** method.  Pass **cupcake** as a parameter to the **View** method.

29. Add a method for the **Delete** action with the following information:

    - HTTP verb: **HTTP Post**
    - Action Name: **"Delete"**
    - Scope: **public**
    - Return type: **IActionResult**
    - Name: **DeleteConfirmed**
    - Parameter:
        - Type: **int**
        - Name: **id**

30. In the **Delete** action with **HTTP POST** verb, call the **DeleteCupcake** method of the **_repository** field. Pass **id** as a parameter to the  **DeleteCupcake** method.

31. Return the **RedirectToActionResult** result using the **RedirectToAction** method.  Pass **nameof(Index)** as a parameter to the **RedirectToAction** method.

#### Task 5: Run the application.

1. Save all the changes.

2. Start debugging the application..

3. In the **Microsoft Edge** window, click the **Add Cupcakes** button.

4. On the **Add Cupcake to The Shop** page, create a new cupcake with the following credentials:

    - Bakery: **_&lt;A bakery of your choice&gt;_**
    - Cupcake Type: **_&lt;A cupcake type of your choice&gt;_**
    - Description: **_&lt;A cupcake description of your choice&gt;_**
    - Gluten Free: **_&lt;Choose if the cupcake is gluten-free&gt;_**
    - Price: **_&lt;A cupcake price of your choice&gt;_**
    - Cupcake Picture: **_&lt;A cupcake picture of your choice&gt;_**

5. Click on the **Submit** button.

6. On the **Cupcakes Shop** page, verify the newly submitted cupcake details.

7. Select a cupcake of your choice and click on **Details**.

8. Verify the cupcake details and then click **Back to List**.

9. Select a cupcake of your choice, and then click on **Edit**.

10. On the **Edit Cupcakes** page, edit a cupcake with the following credential:

    - Price: **_&lt;A cupcake price of your choice&gt;_**

11. On the **Cupcakes Shop** page, select the cupcake you edited, and click on **Details**.

12. Verify the newly edited cupcake details and then click **Back to List**.

13. On the **Cupcakes Shop** page, select a cupcake of your choice, and click **Delete**.

14. On the **Cupcakes Delete** page, click **Delete**.

15. On the **Cupcakes Shop** page, verify the cupcake was deleted.

16. Close **Microsoft Edge.**

17. **Stop debugging**.

>**Results**: After completing this exercise, you will be able to use Entity Framework Core to retrieve and store data through a Repository in the **CupcakeController**. 

### Exercise 3: Use Entity Framework Core to Connect to Microsoft SQL Server

#### Scenario

In this exercise, you will:

- Connecting to a Microsoft SQL Server database.
- Use the repository in the controller.
- Retrieve cupcakes and bakeries data.
- Manipulating cupcakes and bakeries data.

The main tasks for this exercise are as follows:

1. Connecting to a Microsoft SQL Server.

2. Create an app Settings File and specifying a connection string.

3. Use Migrations.

#### Task 1: Connecting to a Microsoft SQL Server.

1. In the **Startup** class, in the **ConfigureServices** method, replace the lambda expression parameter in the **AddDbContext** method call with:  *options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))**.

2. In the **Configure** method, remove the **cupcakeContext** parameter from the method signature. 

3. Remove the **cupcakeContext.Database.EnsureDeleted** method call. 

4. Remove the **cupcakeContext.Database.EnsureCreated** method call.

5.  In the **CupcakeRepository** class, in the **CreateCupcake** method, remove the **lastCupcake** varible. 

6. Remove the assigment of **lastCupcake.CupcakeId + 1** to the **CupcakeId** property of the **cupcake** parameter.

7. After the **IF** statment code block, remove the call to the **Add** method of the **_context** field.

8. Call the **Add** method of the **_context** field. Pass **cupcake** as a parameter to the **Add** method.


#### Task 2: Specifying a connection string in a configuration file. 

1. Create a new top-level **App Setting** file with the following information:
     - File Name: **appsettings.json**
     - Folder: **/**

2. In the **App Settings** File, change the **Database** property value to **BakeriesDb**

#### Task 3: Use Migrations.

1. In the **Cupcakes.csproj** file, at the end of the **Project** element, add a **ItemGroup** element. 

2. In the **ItemGroup** element, add a **DotNetCliToolReference** element with the following information:
    - Include: **Microsoft.EntityFrameworkCore.Tools.DotNet**
    - Version: **2.0.0**

2. Save all the changes.

3. In the Solution Explorer, click on **Open Folder in File Explorer**.

4. In the address bar type **cmd**, and press Enter.

5. In the **Command Line** window, type the following command: **dotnet ef**.

    >**Note:** Verify that the Entity Framework tools for the command-line interface provided correctly in Microsoft.EntityFrameworkCore.Tools.DotNet.

6. Type the following command: **dotnet ef dbcontext info**.

    >**Note:** Verify that the **Database name** is identical to the name in the appsettings.json file.

7.  Type the following command: **dotnet ef database drop**.

8. Type the following command: **y**.
    >**Note:** Enter y to ensure that there are no database conflicts.

9. Type the following command: **dotnet ef migrations add InitialCreate**.

    >**Note:** Verify in the **Cupcakes - Microsoft Visual Studio** window, the newly added folder **Migrations** contains two cs files.

10. Type the following command: **dotnet ef database update**.

    >**Note:** In the **SQL Server Object Explorer** pane of the **Cupcakes - Microsoft Visual Studio** window, verify the **BakeriesDb **tables..

#### Task 4: Run the application.

1. Save all the changes.

2. Start debugging the application..

3. In the **Microsoft Edge** window, click the **Add Cupcakes** button.

4. On the **Add Cupcake to The Shop** page, create a new cupcake with the following credentials:

    - Bakery: **_&lt;A bakery of your choice&gt;_**
    - Cupcake Type: **_&lt;A cupcake type of your choice&gt;_**
    - Description: **_&lt;A cupcake description of your choice&gt;_**
    - Gluten Free: **_&lt;Choose if the cupcake is gluten-free&gt;_**
    - Price: **_&lt;A cupcake price of your choice&gt;_**
    - Cupcake Picture: **_&lt;A cupcake picture of your choice&gt;_**

5. Click on the **Submit** button.

6. On the **Cupcakes Shop** page, verify the newly submitted cupcake details.

7. Select a cupcake of your choice and click on **Details**.

8. Verify the cupcake details and then click **Back to List**.

9. Select a cupcake of your choice, and then click on **Edit**.

10. On the **Edit Cupcakes** page, edit a cupcake with the following credential:

    - Price: **_&lt;A cupcake price of your choice&gt;_**

11. On the **Cupcakes Shop** page, select the cupcake you edited, and click on **Details**.

12. Verify the newly edited cupcake details and then click **Back to List**.

13. On the **Cupcakes Shop** page, select a cupcake of your choice, and click **Delete**.

14. On the **Cupcakes Delete** page, click **Delete**.

15. On the **Cupcakes Shop** page, verify the cupcake was deleted.

16. Close **Microsoft Edge.**

17. **Stop debugging**, and **close** Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created a Cupcakes shop application in which users can submit, edit, delete and View cupcales details.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
