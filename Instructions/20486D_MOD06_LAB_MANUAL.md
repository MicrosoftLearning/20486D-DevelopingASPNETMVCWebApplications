# Module 6: Developing Models

# Lab: Developing Models

#### Scenario

You are planning to create and code a MVC model that will be used in the butterflies’ shop application. The model includes properties that describe a butterfly. The model must enable the application to store the uploaded butterflies.



#### Objectives

After completing this lab, you will be able to:

- Add new models to the application, and add properties to the model.
- Add **GET** and **POST** actions that accept the new model information.
- Use display and edit data annotations in the MVC model to assign property attributes to views and controllers.
- Use **Display**, **Editor** and **Form** Helpers inside the views.
- Use validation Data Annotations in the MVC model to assign property attributes to views and controllers.
- Add custom validation to the application.

#### Lab Setup

Estimated Time: **60 minutes**

#### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos.
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

### Exercise 1: Adding a Model

#### Scenario

In this exercise, you will:

- Add models to the web application and use them in views.
- Add a **_Create (GET)_** action.
- Add a **_Create (POST)_** action.

The main tasks for this exercise are as follows:

1. Create a new model.

2. Use the model in a view.

3. Pass the model from the controller to a view.

4. Run the application.

5. Write a **GET** action.

6. Write a **POST** action that accepts the model.

#### Task 1: Create a new model

1. From **Allfiles\Mod06\Labfiles\01_ButterfliesShop_begin** open the **ButterfliesShop.sln**.

2. In the **Butterfly** class, add **using** statement for the following namespace:

   - **Microsoft.AspNetCore.Http**

3. In the the **Butterfly** model class, add a new property with the following information:

   - Scope: **public**
   - Property name: **Id**
   - Type: **integer**
   - Access: **Read and write**

4. Add a new property with the following information:

   - Scope: **public**
   - Property name: **CommonName**
   - Type: **string**
   - Access: **Read and write**

5. Add a new property with the following information:

   - Scope: **public**
   - Property name: **ButterflyFamily**
   - Type: **Family?**
   - Access: **Read and write**

6. Add a new property with the following information:

   - Scope: **public**
   - Property name: **Quantity**
   - Type: **int?**
   - Access: **Read and write**

7. Add a new property with the following information:

   - Scope: **public**
   - Property name: **Characteristics**
   - Type: **string**
   - Access: **Read and write**

8. Add a new property with the following information:

   - Scope: **public**
   - Property name: **CreatedDate**
   - Type: **DateTime**
   - Access: **Read and write**

9. Add a new property with the following information:

   - Scope: **public**
   - Property name: **PhotoAvatar**
   - Type: **IFormFile**
   - Access: **Read and write**

10. Add a new property with the following information:

     - Scope: **public**
     - Property name: **ImageName**
     - Type: **string**
     - Access: **Read and write**

11. Add a new property with the following information:

    - Scope: **public**
    - Property name: **PhotoFile**
    - Type: **byte[]**
    - Access: **Read and write**

12. Add a new property with the following information:

    - Scope: **public**
    - Property name: **ImageMimeType**
    - Type: **string**
    - Access: **Read and write**

13. Create a new model class with the following information:

    - Class name: **IndexViewModel**
    - Folder: **Models**

14. In the the **IndexViewModel** model class, add a new property with the following information:

     - Scope: **public**
     - Property name: **Butterflies**
     - Type: **List&lt;Butterfly&gt;**
     - Access: **Read and write**

#### Task 2: Use the model in a view

1. In the **Index.cshtml** page, add a **@model** with the following information:
     - Type: **ButterfliesShop.Models.IndexViewModel**.

2. Add a **DIV** element with the following information:

    - Class: **container**

3. Inside the **DIV** element, add a **H1** element with the following information:

    - Class: **main-title**
    - Content: **Butterflies Shop**

4. Below the **H1** element, add a **P** element with the following information:

    - Class: **into**
    - Content: **Welcome to our Web Store, Enjoy a Wide Variety of Butterflies**

5. Add a **P** element with the following information:

    - Content: **Our Butterflies in the Shop**
    - Class: **into**

6. Add a **BUTTON** element with the following information:

    - Type: **button**
    - Content: **Add Butterflies**

7. Edit the **BUTTON** tag with the following information:
   - Attribute: **onclick**
   - Value:   **location.href='@Url.Action("Create", "Butterfly")'**

8. Below the **BUTTON** element, add a **DIV** element with the following information:

    - Class: **img-container**

9. Inside the **DIV** element with the **img-container** class, create a **foreach** statment block that loops through the items in the **Model.Butterflies** list. Name the current item varible **item**.

10. Inside the **foreach** statment block, add a **DIV** element with the following information:

    - Class: **photo-index-card**

11. Inside the **DIV** element with the **photo-index-card** class, add a **P** element with the following information:
    - Content: **Model.CommonName**

12. Add a **P** element with the following information:
    - Content: **Model.ButterflyFamily**

13. Add a **P** element with the following information:
    - Content: **Model.Quantity**

14. Add a **P** element with the following information:
    - Content: **Model.CreatedDate**

#### Task 3: Pass the model from the controller to a view

1. In the **ButterflyController** class, add a **using** statement for the following namespace:

   - **using System.IO**

2. Add a method for the **Index** action with the following information:

    - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Index**

3. In the **Index** action code block,  create a variable named **indexViewModel** of type **IndexViewModel**.

4. Initialize the **indexViewModel** varible using the **IndexViewModel** constructor.

5. Assign the **Butterflies** property of the **indexViewModel** varible, the value of **_data.ButterfliesList**.

6. Return the **ViewResult** result using the **View** method. Pass the **indexViewModel** varible as a parameter to the **View** method.

#### Task 4: Run the application

1. Save all the changes.

2. Start debugging the application.

3. View the page you have added.
    >**Note:** The browser displays the **Index** action result inside the **Butterfly** Controller.

4. Close Microsoft Edge.

5. Stop debugging.

#### Task 5: Write a GET action.

1. In the **ButterflyController** class, add a method for the **Create** action with the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**

2. Return the **ViewResult** result using the **View** method.

#### Task 6: Write a POST action that accepts the model

1. In the **ButterflyController** class, add a method for the **Create** action with the following information:

   - HTTP verb: **HTTP Post**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**
   - Parameter:
        - Type: **Butterfly**
        - Name: **butterfly**.

2. In the **Create** action code block with **HTTP POST** verb, add a varible named **lastButterfly** of type **Butterfly** with the value of **_data.ButterfliesList.LastOrDefault()**.

3. Assign the **CreatedDate** property of the **butterfly** parameter, the value of **DateTime.Today**.

4. Create an **IF** statement that checks that the value of the **butterfly.PhotoAvatar**  is not null, and **butterfly.PhotoAvatar.Length** is.bigger then 0.

5. Inside the **IF** statement, assign the **ImageMimeType** property of the **butterfly** parameter, the value of **butterfly.PhotoAvatar.ContentType**.

6. Assign the **ImageName** property of the **butterfly** parameter, the value of **Path.GetFileName(butterfly.PhotoAvatar.FileName)**.

7. Assign the **Id** property of the **butterfly** parameter, the value of **lastButterfly.Id + 1**.

8. Call the **AddButterfliesQuantityData** method  of the **_butterfliesQuantityService** field, and pass **butterfly** as a parameter.

9. Create a variable named **memoryStream** of type **MemoryStream** inside a **USING** statement.

10. Initialize the **memoryStream** varaible using the **MemoryStream** constructor.

11. Inside the **USING** statement block, call the **CopyTo** method, of the **butterfly.PhotoAvatar** property, and pass **memoryStream** as a parameter.

12. Assign the **PhotoFile** property of the **butterfly** parameter, the value of **memoryStream.ToArray()**.

13. After the **USING** statement block, call the **AddButterfly** method  of the **_data** field, and pass **butterfly** as a parameter.

14. Return the **RedirectToActionResult** result using the **RedirectToAction** method, and Pass **"Index"** as a parameter.

15. After the **IF** statment block,  return the **ViewResult** result using the **View** method, and pass **butterfly** as a parameter.

>**Results** : After completing this exercise, you will be able to create a model, pass it to the view, and use it to display the data.

### Exercise 2: Working with Forms

#### Scenario

In this exercise, you will:

- Add Display and Edit data annotations to a **Butterfly** model.
- Add **Display** Helpers to **Index.cshtml**.
- Add **Form** Helpers and **Editor** Helpers to **Create.cshtml**.

The main tasks for this exercise are as follows:

1. Add display and edit data annotations to a model.

2. Update an action to return **FileContentResult**.

3. Add Display Helpers.

4. Add Form Helpers.

5. Add Editor Helpers.

6. Run the application.

#### Task 1: Add display and edit data annotations to a model

1. In the **Butterfly** class, add **using** statement for the following namespace:

   - **System.ComponentModel.DataAnnotations**

2. Add a **Display** data annotation above the **CommonName** property with the following information:

   - Display name: **Common Name:**

3. Add a **Display** data annotation above the **ButterflyFamily** property with the following information:

   - Display name: **Butterfly Family:**

4. Add a **Display** data annotation above the **Quantity** property with the following information:

    - Display name: **Butterflies Quantity:**

5. Add a **Display** data annotation above the **Characteristics** property with the following information:

     - Display name: **Characteristics:**

6. Add a **Display** data annotation above the **CreatedDate** property with the following information:

   - Display name: **Updated on**

7. Add a **DataType** data annotation with the following information:

   - Type: **DateTime**

8. Add a **DisplayFormat** data annotation with the following information:

   - Display format: **{0:dd/MM/yy}**

9.  Add a **Display** data annotation above the **PhotoAvatar** property with the following information:

      - Display name: **Butterflies Picture:**

#### Task 2: Update an action to return FileContentResult

1. In the **GetImage** action code block, at the beginning of **IF** statment, add a varible named **webRootpath** of type **string** with the value of **_environment.WebRootPath**. 

2. Add a varible named **folderPath** of type **string** with the value of  **"\\images\\"**.

3. Add a varible named **fullPath** of type **string** with the value of **webRootpath + folderPath + requestedCity.ImageName**.

4. Create an **IF** statement that checks that the value of **System.IO.File.Exists(fullPath)** is **true**.

5. Inside the **IF** statement, add a varible named **fileOnDisk** of type **FileStream**. 

6. Initialize the **fileOnDisk** varaible using the **FileStream** constructor and pass it the following parameters: **fullPath** and **FileMode.Open**. 

7. Create a variable named **fileBytes** of type **byte[]**.

8. Create a variable named **br** of type **BinaryReader** inside a **USING** statement.

9. Initialize the **br** varaible using the **BinaryReader** constructor, and pass it the following parameter: **fileOnDisk**.  

10. Inside the **USING** statement block, assign the **fileBytes** varible the following value: **br.ReadBytes((int)fileOnDisk.Length)**.

11. After the **USING** statement block, return a **FileResult** result using the **File** method. Pass the following parameters to the **File** method: **fileBytes** and **requestedButterfly.ImageMimeType**. 

12. After the end of **IF** statment, add an **ELSE** statment.

13. Inside the **ELSE** statment, create a nested  **IF** statement that checks that the value of **requestedButterfly.PhotoFile.Length**  is bigger then **0**.

14. Inside the nested **IF** statement, return a **FileResult** result using the **File** method. Pass the following parameters to the **File** method: **requestedButterfly.PhotoFile** and **requestedButterfly.ImageMimeType**. 

15. After the end of nested **IF** statment, add an **ELSE** statment.

16. Inside the **ELSE** statment, return the **NotFoundResult** result using the **NotFound** method.

#### Task 3: Add Display Helpers

1. In the **Index.cshtml** page, **remove** the code in the **foreach** code block.

2. Inside the **foreach** code block, add a **H3** element with the following information:

    - Class: **display-picture-title**
    - Content: **"@Html.DisplayFor(item => item.CommonName)"**


3. After the **H3** element, add a **IF** statment that checks that the value of **item.ImageName** is not **null**.

4. Inside the **IF** statment block, add a **DIV** element using the following information:

   - Class: **photo-display**

5. Inside the **DIV** element, add a **IMG** element with the following information:

   - Class: **photo-display-img**

6. Edit the **IMG** element with the following information:
   - Attribute: **src**
   - Value:   **@Url.Action("GetImage", "Butterfly", new { Id = item.Id })**

7. After the **IF** statment, add a **DIV** element.

8. Inside the new **DIV** element, add a **P** element with the following information:

   - Class: **display-label**
   - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lamda expression: **model => item.ButterflyFamily**

9. Add a **BR** element. 

10. Add a **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lamda expression: **model => item.ButterflyFamily**

11. After the **DIV** element, add a new **DIV** element with the following information:

    - Class: **display-info**

12. Inside the new **DIV** element, add a **P** element with the following information:

    - Class: **display-label**
    - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lamda expression: **model => item.Characteristics**


13. Add another **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lamda expression: **model => item.Characteristics**

14. After the **DIV** element, add a new **DIV** element.

15. Inside the new **DIV** element, add a **P** element with the following information:

    - Class: **display-label**
    - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lamda expression: **model => item.Quantity**

16. Add another **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lamda expression: **model => item.Quantity**

17. After the **DIV** element, add a new **DIV** element.

18. Inside the new **DIV** element, add a **P** element with the following information:

    - Class: **display-label**
    - Content: 
       - Helper: **Html.DisplayNameFor**
       - Lamda expression: **model => item.CreatedDate**

19. Add another **P** element with the following information:

    - Class: **display-field**
    - Content: 
       - Helper: **Html.DisplayFor**
       - Lamda expression: **model => item.CreatedDate**


#### Task 4: Add Form Helpers

1. In the **Create.cshtml** page,  add a **@using** statement for the following namespace:

   - **ButterfliesShop.Models.Butterfly**

2. Add the **@model** with the following information:
     - Type: **ButterfliesShop.Models.Butterfly**.

3. Add a **DIV** element with the following information:

    - Class: **container**

4. Inside the **DIV** element, add a **H1** element with the following information:

    - Class: **main-title**
    - Content: **Add Butterflies to the Shop**

5. Add  a **FORM** element with the following information:

    - method: **post**
    - enctype: **multipart/form-data**
    - asp-action: **Create**
   
#### Task 5: Add Editor Helpers

1. In the **Create.cshtml** page, add a **DIV** element using the following information:

   - Class: **form-field**

2. Within the **DIV** element, add a **LABEL** element for the **CommonName** property of the model with the following information:

   - Helper:
     - **asp-for**

3. Within the **DIV** element, add an  **INPUT** element for the **CommonName** property of the model with the following information:

   - Helper:
     - **asp-for**

4. After the controls for the **CommonName** property, add a **DIV** element using the following information:

   - Class: **form-field**

5. Within the **DIV** element, add a **LABEL** element for the **ButterflyFamily** property of the model with the following information:

   - Helper:
     - **asp-for**

6. Within the **DIV** element, add a **SELECT** element for the **ButterflyFamily** property of the model with the following information:

   - Helper:
     - **asp-items**

7. After the controls for the **ButterflyFamily** property, add a **DIV** element using the following information:

   - Class: **form-field**

8. Within the **DIV** element, add a **LABEL** element  for the **Characteristics** property of the model with the following information:

   - Helper:
     - **asp-for**

9.  Within the **DIV** element, add a **TEXTAREA** element for the **Characteristics** property of the model with the following information:

   - Helper:
     - **asp-for**

10. After the controls for the **Characteristics** property, add a **DIV** element using the following information:

   - Class: **form-field**

11. Within the **DIV** element, add a **LABEL** element for the **Quantity** property of the model with the following information:

   - Helper:
     - **asp-for**

12. Within the **DIV** element, add an  **INPUT** element for the **Quantity** property of the model with the following information:

   - Helper:
     - **asp-for**

13. After the controls for the **Quantity** property, add a **DIV** element using the following information:

   - Class: **form-field**

14. Within the **DIV** element, add a **LABEL** element for the **PhotoAvatar** property of the model with the following information:

   - Helper:
     - **asp-for**

15.  Within the **DIV** element, add an  **INPUT** element for the **PhotoAvatar** property of the model with the following information:

   - Helper: **asp-for**
   - Input type: **file**

16.  After the controls for the **PhotoAvatar** property, add a **DIV** element using the following information:

   - Class: **form-field**

17. Within the **DIV** element, add an  **INPUT** element for the **submit** button with the following information:

   - Type: **submit**
   - Value: **Submit**

#### Task 6: Run the application

1. Save all the changes.

2. Start debugging the application.

3. On the **Add Butterflies to The Shop** page, Create a new butterfly with the following credentials:

    - Common Name: **_&lt;A butterfly common name of your choice&gt;_**
    - Butterfly Family: **_&lt;A butterfly family of your choice&gt;_**
    - Characteristics: **_&lt;A butterfly characteristics of your choice&gt;_**
    - Butterflies Quantity: **_&lt;A butterflies quantity of your choice&gt;_**
    - Butterflies Picture: **_&lt;A butterfly picture of your choice&gt;_**

4. On the **Add Butterflies to The Shop** page, click **Submit**.

      >**Note:** Verify the newly submitted butterfly details.

5. Stop debugging.

>**Results** : After completing this exercise, you will be able to add data annotations for the Butterfly model class in the application, also add tag helpers to views. 

### Exercise 3: Adding Validation

#### Scenario

In this exercise, you will:

- Add validation data annotations to a butterfly model.
- Add validation Helpers to the Create view.
- Add **ModelState.IsValid** property in a ButterflyController.
- Add **MaxButterflyQuantityValidation** custom validation.

The main tasks for this exercise are as follows:

1. Add validation data annotations to a model.

2. Add validation helpers to a view.

3. Using **ModelState.IsValid** property in a controller.

4. Run the application.

5. Add custom validation.

6. Run the application.

#### Task 1: Add validation data annotations to a model

1. Add a validation data annotation to the **Butterfly** model class to ensure that the users complete the **CommonName** field.

2. Add a validation data annotation to the **Butterfly** model class to ensure that the users complete the **ButterflyFamily** field.

3. Add a validation data annotation to the **Butterfly** model class to ensure that the users complete the **Quantity** field.

4. Add validation data annotations to the **Butterfly** model class to ensure that the users complete the **Characteristics** text box, and type a string with a length shorter than 50 characters.

5. Add a validation data annotation to the **Butterfly** model class to ensure that the users complete the **PhotoAvatar** field.

#### Task 2: Add validation helpers to a view

1. In the **Create.cshtml** page, inside the form, use the **asp-validation-summary** helper to render validation messages.

2. Add a **SPAN** element to display validation message for the **CommonName** property of the model with the following information:

   - Helper:
     - **asp-validation-for**

3. Add a **SPAN** element to display validation message for the **ButterflyFamily** property of the model with the following information:

   - Helper:
     - **asp-validation-for**

4. Add a **SPAN** element to display validation message for the **Characteristics** property of the model with the following information:

   - Helper:
     - **asp-validation-for**

5. Add a **SPAN** element to display validation message for the **Quantity** property of the model with the following information:

   - Helper:
     - **asp-validation-for**

6. Add a **SPAN** element to display validation message for the **PhotoAvatar** property of the model with the following information:

   - Helper:
     - **asp-validation-for**

#### Task 3: Using the ModelState.IsValid property in a controller

1. In the **ButterflyController** class, within the **Create** action method code block for the **HTTP POST** verb, check if the **ModelState** is valid at the begging of the method code block.

2. Otherwise if not valid return the accepted butterfly object to the view.

#### Task 4: Run the application

1. Save all the changes.

2. Start debugging the application.

3. On the **Add Butterflies to The Shop** page, leave all the fields blank, and then click **Submit**.

4. Correct all the fields with the validation message, and then click **Submit**.

      >**Note:** Verify the newly submitted butterfly details.

5. Stop debugging.

#### Task 5: Add custom validation

1. Create a new top-level folder, in the **ButterfliesShop** project with the following information:

   - Folder name: **Validators**

2. Create a new class for the custom validation with the following information:

   - Name: **MaxButterflyQuantityValidation**
   - Folder: **Validators**

3. Add **using** statements for the following namespaces:

   - **ButterfliesShop.Models**
   - **ButterfliesShop.Services**
   - **System.ComponentModel.DataAnnotations**

4. Ensure that the **MaxButterflyQuantityValidation** class inherits from the **ValidationAttribute** class.

5. In the **MaxButterflyQuantityValidation** class, create a new private field using the following information:

   - Scope: **private**
   - Type: **integer**
   - Name: **_maxAmount** 

    Create a constructor for the **MaxButterflyQuantityValidation** class that acceptes a **int maxAmount** parameter. Initialize the new **_maxAmount** field with the **maxAmount** paramater.

6. In the **MaxButterflyQuantityValidation** class, override the **IsValid** method with the following Parameters:

   - First parameter: **value** of type **object**
   - Second parameter: **ValidationContext** of type **validationContext**  

7. Within the **IsValid** method create an instance of type **IButterfliesQuantityService** using the **GetService** method of the **ValidationContext** parameter.

8. Within the **IsValid** method create an instance of type **butterfly** using the **ObjectInstance** method of the **ValidationContext** prameter.

9. Create a **If** statment that checks whether the **ButterflyFamily** property of the current butterfly is not null.

10. Get the total quantity using the **GetButterflyFamilyQuantity** method of the **IButterfliesQuantityService** service, and assign the result to a new **quantity** variable of type **int?**.

11. Calculate the sum of the new **quantity** variable and the current buttefly **quantity**.

12. If the total quantity is bigger then the value of the private field **_maxAmount**, return a new **ValidationResult** with a custome validation message. Else return **ValidationResult.Success**.

13. In the **Butterfly** class, add **using** statement for the following namespace:

   - **ButterfliesShop.Validators**

14. Add the **MaxButterflyQuantityValidation(50)**  custom validation data annotations to the **Butterfly** model class to ensure that the users complete the **Quantity** text box, and type the correct butterflies quantity.

#### Task 6: Run the application

1. Save all the changes.

2. Start debugging the application.

3. Click **Add Butteflies**.

4. On the **Add Butterflies to The Shop** page, Create a new butterfly with the following credentials:

    - Common Name: **_&lt;A butterfly common name of your choice&gt;_**
    - Butterfly Family: **_&lt;A butterfly family of your choice&gt;_**
    - Characteristics: **_&lt;A butterfly characteristics of your choice&gt;_**
    - Butterflies Quantity: **type 60**
    - Butterflies Picture: **_&lt;A butterfly picture of your choice&gt;_**

5. Correct the **Butterflies Quantity** box, type 2.

6. Add the **Butterflies Picture** once again, and then click **Submit**.

      >**Note:** Verify the newly submitted butterfly details.

7. Stop debugging and close Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created a ButterfliesShop application in which users can submit to the shop variety of butterflies.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
