# Module 6: Developing Models

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Developing Models

#### Scenario

You are planning to create and code a Model-View-Controller (MVC) model that will be used in the butterflies’ shop application. The model includes properties that describe a butterfly. The model must enable the application to store the uploaded butterflies.



#### Objectives

After completing this lab, you will be able to:

- Add new models to the application, and add properties to the model.
- Add **GET** and **POST** actions that accept the new model information.
- Use display and edit data annotations in the MVC model to assign property attributes to views and controllers.
- Use **Display**, **Editor** and **Form** Helpers inside the views.
- Use validation data annotations in the MVC model to assign property attributes to views and controllers.
- Add custom validation to the application.

#### Lab Setup

Estimated Time: **60 minutes**

#### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos in this course.
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Adding a Model

#### Scenario

In this exercise, you will:

- Add models to the web application and use them in views.
- Add a **_Create (GET)_** action.
- Add a **_Create (POST)_** action.

The main tasks for this exercise are as follows:

1. Create a new model

2. Use the model in a view

3. Pass the model from the controller to a view

4. Run the application

5. Write a GET action

6. Write a POST action that accepts the model

#### Task 1: Create a new model

1. From **[Repository Root]\Allfiles\Mod06\Labfiles\01_ButterfliesShop_begin**, open the **ButterfliesShop.sln**.

    >**Note**: If a **Security Warning for ButterfliesShop** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **Butterfly** class, add a **using** statement for the following namespace:

   - **Microsoft.AspNetCore.Http**

3. In the the **Butterfly** model class, add a new property with the following information:

   - Scope: **public**
   - Name: **Id**
   - Type: **integer**
   - Access: **Read and write**

4. Add a new property with the following information:

   - Scope: **public**
   - Name: **CommonName**
   - Type: **string**
   - Access: **Read and write**

5. Add a new property with the following information:

   - Scope: **public**
   - Name: **ButterflyFamily**
   - Type: **Family?**
   - Access: **Read and write**

6. Add a new property with the following information:

   - Scope: **public**
   - Name: **Quantity**
   - Type: **int?**
   - Access: **Read and write**

7. Add a new property with the following information:

   - Scope: **public**
   - Name: **Characteristics**
   - Type: **string**
   - Access: **Read and write**

8. Add a new property with the following information:

   - Scope: **public**
   - Name: **CreatedDate**
   - Type: **DateTime**
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

13. Create a new model with the following information:

    - Class name: **IndexViewModel**
    - Folder: **Models**

14. In the the **IndexViewModel** class, add a new property with the following information:

     - Scope: **public**
     - Property name: **Butterflies**
     - Type: **List&lt;Butterfly&gt;**
     - Access: **Read and write**

#### Task 2: Use the model in a view

1. At the beginning of the **Index.cshtml** view, add a **@model** directive with the following information:
     - Type: **ButterfliesShop.Models.IndexViewModel**.

2. In the **BODY** element, add a **DIV** element with the following information:

    - Class: **container**

3. In the **DIV** element, add an **H1** element with the following information:

    - Class: **main-title**
    - Content: **Butterflies Shop**

4. Add a **P** element with the following information:

    - Class: **into**
    - Content: **Welcome to our Web Store, Enjoy a Wide Variety of Butterflies**

5. Add a **P** element with the following information:

    - Class: **into**
    - Content: **Our Butterflies in the Shop**

6. Add a **BUTTON** element with the following information:

    - Type: **button**
    - Content: **Add Butterflies**

7. Edit the **BUTTON** tag with the following information:
   - Attribute: **onclick**
   - Value:   **location.href='@Url.Action("Create", "Butterfly")'**

8. After the **BUTTON** element, add a **DIV** element with the following information:

    - Class: **img-container**

9. In the **DIV** element with the **img-container** class, create a **FOREACH** statement block, with the following information: 
    - Variable Type: **var**
    - Variable Name: **item**
    - Collection: **Model.Butterflies**

10. In the **FOREACH** statement block, add a **DIV** element with the following information:

    - Class: **photo-index-card**

11. In the **DIV** element with the **photo-index-card** class, add a **P** element with the following information:
    - Content: **item.CommonName**

12. Add a **P** element with the following information:
    - Content: **item.ButterflyFamily**

13. Add a **P** element with the following information:
    - Content: **item.Quantity**

14. Add a **P** element with the following information:
    - Content: **item.CreatedDate**

#### Task 3: Pass the model from the controller to a view

1. In the **ButterflyController** class, add a **using** statement for the following namespace:

   - **using System.IO**

2. Add a method for the **Index** action with the following information:

    - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Index**

3. In the **Index** action code block,  create a variable named *indexViewModel* of type **IndexViewModel**.

4. Initialize the *indexViewModel* variable by using the **IndexViewModel** constructor.

5. Assign the **Butterflies** property of the *indexViewModel* variable the value of **_data.ButterfliesList**.

6. Return the **ViewResult** result by using the **View** method. Pass the *indexViewModel* variable as a parameter to the **View** method.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. View the page you have added.
    >**Note**: The browser displays the **Index** action result inside the **Butterfly** Controller.

4. Close Microsoft Edge.

#### Task 5: Write a GET action.

1. In the **ButterflyController** class, add a method for the **Create** action with the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**

2. In the **Create** action code block, return the **ViewResult** result using the **View** method.

#### Task 6: Write a POST action that accepts the model

1. In the **ButterflyController** class, add a method for the **Create** action with the following information:

   - HTTP verb: **HTTP Post**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**
   - Parameter:
        - Type: **Butterfly**
        - Name: **butterfly**.

2. In the **Create** action code block annotated with the **HTTP POST** verb, add a variable named *lastButterfly* of type **Butterfly** with the value of **_data.ButterfliesList.LastOrDefault()**.

3. Assign to the **CreatedDate** property of the *butterfly* parameter the value of **DateTime.Today**.

4. Create an **IF** statement that checks that the value of the **butterfly.PhotoAvatar**  is not null, **AND** **butterfly.PhotoAvatar.Length** is bigger than 0.

5. In the **IF** statement block, assign the **ImageMimeType** property of the **butterfly** parameter, the value of **butterfly.PhotoAvatar.ContentType**.

6. Assign to the **ImageName** property of the **butterfly** parameter the value of **Path.GetFileName(butterfly.PhotoAvatar.FileName)**.

7. Assign to the **Id** property of the **butterfly** parameter the value of **lastButterfly.Id + 1**.

8. Call the **AddButterfliesQuantityData** method of the **_butterfliesQuantityService** field, and pass **butterfly** as a parameter.

9. Create a variable named *memoryStream* of type **MemoryStream** inside a **USING** statement.

10. Initialize the *memoryStream* variable by using the **MemoryStream** constructor.

11. In the **USING** statement block, call the **CopyTo** method, of the **butterfly.PhotoAvatar** property, and pass **memoryStream** as a parameter.

12. Assign the **PhotoFile** property of the **butterfly** parameter, the value of **memoryStream.ToArray()**.

13. After the **USING** statement block, call the **AddButterfly** method of the **_data** field, and pass **butterfly** as a parameter.

14. Return the **RedirectToActionResult** result by using the **RedirectToAction** method, and pass **"Index"** as a parameter.

15. After the **IF** statement block,  return the **ViewResult** result by using the **View** method, and pass **butterfly** as a parameter.

>**Results**: After completing this exercise, you will be able to create a model, pass it to the view, and use it to display the data.

### Exercise 2: Working with Forms

#### Scenario

In this exercise, you will:

- Add Display and Edit data annotations to a **Butterfly** model.
- Add **Display** Helpers to **Index.cshtml**.
- Add **Form** Helpers and **Editor** Helpers to **Create.cshtml**.

The main tasks for this exercise are as follows:

1. Add display and edit data annotations to a model

2. Update an action to return FileContentResult

3. Add Display Helpers

4. Add Form Helpers

5. Add Editor Helpers

6. Run the application

#### Task 1: Add display and edit data annotations to a model

1. In the **Butterfly** class, add a **using** statement for the following namespace:

   - **System.ComponentModel.DataAnnotations**

2. Above the **CommonName** property, add a **Display** attribute with the following information:

   - Name: **Common Name:**

3. Above the **ButterflyFamily** property, add a **Display** attribute with the following information:

   - Name: **Butterfly Family:**

4.  Above the **Quantity** property, add a **Display** attribute with the following information:

    - Name: **Butterflies Quantity:**

5. Above the **Characteristics** property, add a **Display** attribute with the following information:

     - Name: **Characteristics:**

6. Above the **CreatedDate** property, add a **Display** attribute with the following information:

   - Name: **Updated on**

7. Add a **DataType** attribute with the following information:

   - Data Type: **DataType.DateTime**

8. Add a **DisplayFormat** attribute with the following information:

   - Display Format: **{0:dd/MM/yy}**

9.  Above the **PhotoAvatar** property, add a **Display** attribute  with the following information:

    - Name: **Butterflies Picture:**

#### Task 2: Update an action to return FileContentResult

1. In the **GetImage** action code block, at the beginning of **IF** statement, remove the **return** statement.

2. Add a variable named *webRootpath* of type **string** with the value of **_environment.WebRootPath**. 

3. Add a variable named *folderPath* of type **string** with the value of  **"\\images\\"**.

4. Add a variable named *fullPath* of type **string** with the value of **webRootpath + folderPath + requestedButterfly.ImageName**.

5. Create an **IF** statement that checks whether the value of **System.IO.File.Exists(fullPath)** is **true**.

6. In the **IF** statement block, add a variable named *fileOnDisk* of type **FileStream**. 

7. Initialize the *fileOnDisk* variable by using the **FileStream** constructor and pass it the following parameters: **fullPath** and **FileMode.Open**. 

8. Create a variable named *fileBytes* of type **byte[]**.

9. Create a variable named *br* of type **BinaryReader** inside a **USING** statement.

10. Initialize the *br* variable by using the **BinaryReader** constructor, and pass it the following parameter: **fileOnDisk**.  

11. In the **USING** statement block, assign the *fileBytes* variable the following value: **br.ReadBytes((int)fileOnDisk.Length)**.

12. After the **USING** statement block, return a **FileResult** result by using the **File** method. Pass the following parameters to the **File** method: **fileBytes** and **requestedButterfly.ImageMimeType**. 

13. After the end of the nested **IF** statement, add an **ELSE** statement.

14. In the new **ELSE** statement block, create a nested  **IF** statement that checks whether the value of **requestedButterfly.PhotoFile.Length**  is bigger than **0**.

15. In the nested **IF** statement block, return a **FileResult** result by using the **File** method. Pass the following parameters to the **File** method: **requestedButterfly.PhotoFile** and **requestedButterfly.ImageMimeType**. 

16. After the end of nested **IF** statement, add an **ELSE** statement.

17. In the **ELSE** statement block, return the **NotFoundResult** result by using the **NotFound** method.

#### Task 3: Add Display Helpers

1. In the **Index.cshtml** view, **remove** the code in the **FOREACH** code block.

2. In the **FOREACH** code block, add an **H3** element with the following information:

    - Class: **display-picture-title**
    - Content: **"@Html.DisplayFor(modelItem => item.CommonName)"**


3. After the **H3** element, add an **IF** statement that checks whether the value of **item.ImageName** is not **null**.

4. In the **IF** statement block, add a **DIV** element by using the following information:

   - Class: **photo-display**

5. In the **DIV** element, add an **IMG** element with the following information:

   - Class: **photo-display-img**

6. Edit the **IMG** element with the following information:
   - Attribute: **src**
   - Value:   **@Url.Action("GetImage", "Butterfly", new { Id = item.Id })**

7. After the **IF** statement, add a **DIV** element.

8. In the new **DIV** element, add a **P** element with the following information:

   - Class: **display-label**
   - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lambda expression: **model => item.ButterflyFamily**

9. Add a **BR** element. 

10. Add a **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lambda expression: **model => item.ButterflyFamily**

11. After the **DIV** element, add a new **DIV** element with the following information:

    - Class: **display-info**

12. In the new **DIV** element, add a **P** element with the following information:

    - Class: **display-label**
    - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lambda expression: **model => item.Characteristics**


13. Add another **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lambda expression: **model => item.Characteristics**

14. After the **DIV** element, add a new **DIV** element.

15. In the new **DIV** element, add a **P** element with the following information:

    - Class: **display-label**
    - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lambda expression: **model => item.Quantity**

16. Add another **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lambda expression: **model => item.Quantity**

17. After the **DIV** element, add a new **DIV** element.

18. Ins the new **DIV** element, add a **P** element with the following information:

    - Class: **display-label**
    - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lambda expression: **model => item.CreatedDate**

19. Add another **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lambda expression: **model => item.CreatedDate**


#### Task 4: Add Form Helpers

1. At the beginning of **Create.cshtml** view,  add a **@using** statement for the following namespace:

   - **ButterfliesShop.Models.Butterfly**

2. Add a **@model** with the following information:
     - Type: **ButterfliesShop.Models.Butterfly**.

3.  In the **BODY** element, add a **DIV** element with the following information:

    - Class: **container**

4. In the **DIV** element, add an **H1** element with the following information:

    - Class: **main-title**
    - Content: **Add Butterflies to the Shop**

5. Add a **FORM** element with the following information:

    - Method: **post**
    - Enctype: **multipart/form-data**
    - asp-action: **Create**
   
#### Task 5: Add Editor Helpers

1. In the **FORM** element , add a **DIV** element with the following information:

   - Class: **form-field**

2. In the **DIV** element, add a **LABEL** element with the following information:

   - asp-for: **CommonName**

3. Add an **INPUT** element with the following information:

   - asp-for: **CommonName**

4. After the **DIV** element with **form-field** class, add a **DIV** element with the following information:

   - Class: **form-field**

5. In the **DIV** element, add a **LABEL** element with the following information:

   - asp-for: **ButterflyFamily**

6. Add a **SELECT** element with the following information:

   - asp-for: **ButterflyFamily**
   - asp-items: **Html.GetEnumSelectList&lt;Family&gt;()**

7. In the **SELECT** element, add an **OPTION** element with the following information: 
    - Selected: **selected**
    - Value: **""**
    - Content: **Select**


8. After the last **DIV** element with **form-field** class, add a **DIV** element with the following information:

   - Class: **form-field**

9. In the **DIV** element, add a **LABEL** element with the following information:

   - asp-for: **Characteristics**


10. Add a **TEXTAREA** element with the following information:

    - asp-for: **Characteristics**

11. After the last **DIV** element with **form-field** class, add a **DIV** element with the following information:

    - Class: **form-field**

12. In the **DIV** element, add a **LABEL** element with the following information:

    - asp-for: **Quantity**

13. Add a **INPUT** element with the following information:

    - asp-for: **Quantity**


14. After the last **DIV** element with **form-field** class, add a **DIV** element with the following information:

    - Class: **form-field**

15. In the **DIV** element, add a **LABEL** element with the following information:

    - asp-for: **PhotoAvatar**

16. Add a **INPUT** element with the following information:

    - Type: **file**
    - asp-for: **PhotoAvatar**


17. After the last **DIV** element with **form-field** class,  add a **DIV** element by using the following information:

    - Class: **form-field**

18. In the **DIV** element, add an  **INPUT** element with the following information:

    - Type: **submit**
    - Value: **Submit**

#### Task 6: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. Click **Add Butterflies**.

4. On the **Add Butterflies to The Shop** page, create a new butterfly with the following credentials:

    - Common Name: **_&lt;A butterfly common name of your choice&gt;_**
    - Butterfly Family: **_&lt;A butterfly family of your choice&gt;_**
    - Characteristics: **_&lt;A butterfly characteristics of your choice&gt;_**
    - Butterflies Quantity: **_&lt;A butterflies quantity of your choice&gt;_**
    - Butterflies Picture: **_&lt;A butterfly picture of your choice from [Repository Root]\AllFiles\Mod06\Labfiles\Images&gt;_**

5. Click **Submit**.

      >**Note**: Verify that the submitted butterfly details are valid and that a new butterfly was added to the homepage.

6. Close Microsoft Edge.

>**Results** : After completing this exercise, you will be able to add data annotations to the Butterfly model class in the application and add tag helpers to views. 

### Exercise 3: Adding Validation

#### Scenario

In this exercise, you will:

- Add validation data annotations to a butterfly model.
- Add validation Helpers to the Create view.
- Add **ModelState.IsValid** property in ButterflyController.
- Add **MaxButterflyQuantityValidation** custom validation.

The main tasks for this exercise are as follows:

1. Add validation data annotations to a model

2. Add validation helpers to a view

3. Using ModelState.IsValid property in a controller

4. Run the application

5. Add custom validation

6. Run the application

#### Task 1: Add validation data annotations to a model

1. In the **Butterfly** class, above the **CommonName** property, add a **Required** attribute with the following information:

     - Error Message: **Please enter the butterfly name**


2. Above the **ButterflyFamily** property, add a **Required** attribute with the following information:

     - Error Message: **Please select the butterfly family**


3. Above the **Quantity** property, add a **Required** attribute with the following information:

     - Error Message: **Please select the butterfly quantity**

4. Above the **Characteristics** property, add a **Required** attribute with the following information:

     - Error Message: **Please type the characteristics**

5. Add a **StringLength** attribute with the following information:

     - Maximum Length: **50**

6. Above the **PhotoAvatar** property, add a **Required** attribute with the following information:

     - Error Message: **Please select the butterflies picture**

#### Task 2: Add validation helpers to a view

1. In the **Create.cshtml** view, at the beginning of the **FORM** element, add a **DIV** element by using the following information:

   - asp-validation-summary: **All**

2. After the **INPUT** element with the **asp-for="CommonName"** helper, add a **SPAN** element with the following information:
   - asp-validation-for: **CommonName**

3. After the **SELECT** element with the **asp-for="ButterflyFamily"** helper, add a **SPAN** element with the following information:
   - asp-validation-for: **ButterflyFamily**

4. After the **TEXTAREA** element with the **asp-for="Characteristics"** helper, add a **SPAN** element with the following information:
   - asp-validation-for: **Characteristics**

5. After the **INPUT** element with the **asp-for="Quantity"** helper, add a **SPAN** element with the following information:
   - asp-validation-for: **Quantity**

6. After the **INPUT** element with **asp-for="PhotoAvatar"** helper, add a **SPAN** element with the following information:
   - asp-validation-for: **PhotoAvatar**


#### Task 3: Using the ModelState.IsValid property in a controller

1. In the **ButterflyController** class, locate the **Create** action code block annotated with the **HTTP POST** verb.

2. At the beginning of the **Create** action, add an **IF** statement that checks that the value of **ModelState.isValid** is true.

3. Close the **IF** statement at the end of the **Create** action code block. 

      >**Note**: The **IF** statement should surround the content of the **Create** action. 

4. After the **IF** statement, add an **ELSE** statement.

5. Inside the **ELSE**  statement, return the **ViewResult** result by using the **View** method. Pass the **butterfly** model as a parameter to the **View** method. 

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

    >**Note**: The browser displays the **Index** action result inside the **Butterfly** Controller.

3. On the **Add Butterflies to The Shop** page, leave all the fields blank, and then click **Submit**.

      >**Note**: The browser window displays the **Create.cshtml** view with validation messages below all the boxes.

4. Correct all the fields that have validation messages, and then click **Submit**.

      >**Note**: Verify that the submitted butterfly details are valid and that a new butterfly was added to the homepage.

6. Close Microsoft Edge.

#### Task 5: Add custom validation

1. In the **ButterfliesShop** project, create a new top-level folder, and name it **Validators**.
  
2. Create a new class for the custom validation with the following information:
   - Name: **MaxButterflyQuantityValidation**
   - Folder: **Validators**

3. Add the **using** statements for the following namespaces:

   - **ButterfliesShop.Models**
   - **ButterfliesShop.Services**
   - **System.ComponentModel.DataAnnotations**

4. Change the **MaxButterflyQuantityValidation** class to inherit from the **ValidationAttribute** class.

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **integer**
   - Name: **_maxAmount** 

6. Add a constructor with the following parameter: 
    - Type: **int**
    - Name: **maxAmount**

7. In the constructor, initialize the **_maxAmount** field with the value of the **maxAmount** parameter.

8. Add an **override** method with the following information:
    - Scope: **protected**
    - Return type: **ValidationResult**
    - Name: **IsValid**
    - Parameters:
        - Parameter: 
            - Type: **object** 
            - Name: **value**
        - Parameter: 
            - Type: **ValidationContext**
            - Name: **validationContext**


9. In the **IsValid** method, add a variable named *service* of type **var** with the value of **(IButterfliesQuantityService)validationContext.GetService(typeof(IButterfliesQuantityService))**. 

10. Add a variable named *butterfly* of type **Butterfly** with the value of **(Butterfly)validationContext.ObjectInstance)**. 

11. Create an **IF** statement that checks whether the value of the **ButterflyFamily** property of the **butterfly** variable is **not null**.

12. Inside the **IF** statement code block, add a variable named *quantity* of type **int?** with the value of **service.GetButterflyFamilyQuantity(butterfly.ButterflyFamily.Value)**. 

13. Add a variable named *quantity* of type **int?** with the value of **quantity + butterfly.Quantity**. 

14. Create a nested **IF** statement that checks whether the value of  **sumQuantity** is bigger than **_maxAmount**.

15.  Inside the nested **IF** statement code block, return a new **ValidationResult** result by using the  **ValidationResult** constructor. 

16. Pass **string.Format("Limit of butterflies from the same family in the store is {0} butterflies. Currently there are {1}", _maxAmount, quantity)** as a parameter to the **ValidationResult** constructor.

17. After the nested **IF** statement, return **ValidationResult** result by using the **ValidationResult.Success** property.

18. After the outer **IF** statement, return **ValidationResult** result by using the **ValidationResult.Success** property.

19. In the **Butterfly** class, add a **using** statement for the following namespace:

    - **ButterfliesShop.Validators**

20. Above the **Quantity** property, add the **MaxButterflyQuantityValidation(50)** custom validation attribute.


#### Task 6: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. Click **Add Butteflies**.

4. On the **Add Butterflies to The Shop** page, create a new butterfly with the following credentials:

    - Common Name: **_&lt;A butterfly common name of your choice&gt;_**
    - Butterfly Family: **_&lt;A butterfly family of your choice&gt;_**
    - Characteristics: **_&lt;A butterfly characteristics of your choice&gt;_**
    - Butterflies Quantity: **type 60**
    - Butterflies Picture: **_&lt;A butterfly picture of your choice from [Repository Root]\AllFiles\Mod06\Labfiles\Images&gt;_**

5. Correct the **Butterflies Quantity** box, type **2**.

6. Add the **Butterflies Picture** once again, and then click **Submit**.

      >**Note**: Verify that the submitted butterfly details are valid and that a new butterfly was added to the homepage.

7. Close Microsoft Edge.

8. Close Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created a ButterfliesShop application in which users can submit to the shop variety of butterflies.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
