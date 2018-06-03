# Module 6: Developing Models

# Lab: Developing Models

#### Scenario

You are planning to create and code an MVC model that implements your plan for butterflies in the butterflies’ shop application. The model includes properties that describe butterfly. The model must enable the application to store the uploaded butterflies.

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

### Exercise 1: Adding a Model

#### Scenario

In this exercise, you will:

- Add model classes to the web application.
- **_Create (GET)_**. This action creates a new **Butterfly** object and passes it to the Create view, which displays a form that the visitor can use to upload a butterfly and describe it.
- **_Create (POST)_**. This action receives a **Butterfly** object from the Create view and saves the details.

The main tasks for this exercise are as follows:

1. Create a new model.

2. Use the model in a view.

3. Pass the model from the controller to a view.

4. Run the application.

5. Write a **GET** action that accepts the new model information.

6. Write a **POST** action that accepts the model.

#### Task 1: Create a new model

1. Open the **ButterfliesShop.sln** file from the following location:
**Allfiles\Mod06\Labfiles\01_ButterfliesShop_begin**.

2. In the **Butterfly** class, add **using** statement for the following namespace:

   - **Microsoft.AspNetCore.Http**

3. Add an **Id** key property to the Butterfly model class by using the following information:

   - Scope: **public**
   - Property name: **Id**
   - Data type: **integer**
   - Access: **Read and write**

4. Add a **CommonName** property to the Butterfly model class by using the following information:

   - Scope: **public**
   - Property name: **CommonName**
   - Data type: **string**
   - Access: **Read and write**

5. Add a **ButterflyFamily** property to the Butterfly model class by using the following information:

   - Scope: **public**
   - Property name: **ButterflyFamily**
   - Data type: Nullable **Family**
   - Access: **Read and write**

6. Add a **Quantity** property to the Butterfly model class by using the following information:

   - Scope: **public**
   - Property name: **Quantity**
   - Data type: Nullable **integer**
   - Access: **Read and write**

7. Add a **Characteristics** property to the Butterfly model class by using the following information:

   - Scope: **public**
   - Property name: **Characteristics**
   - Data type: **string**
   - Access: **Read and write**

8. Add a **CreatedDate** property to the Butterfly model class by using the following information:

   - Scope: **public**
   - Property name: **CreatedDate**
   - Data type: **DateTime**
   - Access: **Read and write**

9. Add an **image** properties to the **Butterfly** model class and store the image name by using the following information:

   - Scope: **public**
   - Property names: **PhotoAvatar**, **ImageName**
   - Data type for the image: **IFormFile**
   - Data type for image name: **string**
   - Access: **Read and write**

10. Add another **image** properties to the **Butterfly** model class and store the MIME type of image by using the following information:

     - Scope: **public**
     - Property names: **PhotoFile**, **ImageMimeType**
     - Data type for the image: **byte []**
     - Data type for MIME type: **string**
     - Access: **Read and write**
   
11. Add a new model class to the **ButterfliesShop** project by using the following information:

    - Class name: **IndexViewModel**

12. Add a **Butterflies** property to the **IndexViewModel** model class by using the following information:

     - Scope: **public**
     - Property name: **Butterflies**
     - Data type: **List&lt;Butterfly&gt;**
     - Access: **Read and write**

#### Task 2: Use the model in a view

1. In the **Index.cshtml** page, set the **@model** for the **Index.cshtml** to **ButterfliesShop.Models.IndexViewModel**.

2. Add an **DIV** element to the **Index.cshtml** page by using the following information:

    - Class: **container**

3. Add an **H1** element to the **Index.cshtml** page within the **DIV** element by using the following information:

    - Content: **Butterflies Shop**
    - Class: **main-title**

4. Add an **P** element to the **Index.cshtml** page within the **DIV** element by using the following information:

    - Content: **Welcome to Our Web Store, Enjoy a Wide Variety of Butterflies**
    - Class: **into**

5. Add an **P** element to the **Index.cshtml** page within the **DIV** element by using the following information:

    - Content: **Our Butterflies in The Shop**
    - Class: **into**

6. Add a **BUTTON** element to the **Index.cshtml** page within the **DIV** element by using the following information:

    - Type: **button**
    - Content: **Add Butterflies**

7. Add the **URL.Action** helper to the **onclick** attribute of the **BUTTON** tag by using the following information:

   - Method: **location.href=Url.Action()**
   - Action name: **Create**
   - Controller name: **Butterfly**

8. Add a **DIV** element to the **Index.cshtml** page within the **DIV** element by using the following information:

    - Class: **img-container**

9. Create a new **foreach** code block that loops through all the butterflies in the **Butterflies** list within the **DIV** element.

10. Add a **DIV** element to the **Index.cshtml** page inside the **foreach** code block by using the following information:

    - Class: **photo-index-card**

11. In the **foreach** code block, add a **P** element to display the **CommonName**  property from the model.

12. In the **foreach** code block, add a **P** element to display the **ButterflyFamily**  property from the model.

13. In the **foreach** code block, add a **P** element to display the **Quantity**  property from the model.

14. In the **foreach** code block, add a **P** element to display the **CreatedDate**  property from the model.

#### Task 3: Pass the model from the controller to a view

1. In the **ButterflyController** class, add **using** statement for the following namespace:

   - **using System.IO**

2. Add a method for the **Index** action by using the following information:

   - Scope: **public**
    - Return Type: **IActionResult**
    - Name: **Index**

3. Within the **Index** action code block, initiate **IndexViewModel** model and it's **Butterflie** property with **ButterfliesList** method from the **IDataService** interface.

4. Pass the **IndexViewModel** object to the view **Index**, and return the view.

#### Task 4: Run the application

1. Save all the changes.

2. Run the website, and view the page you added.

3. Stop debugging.

#### Task 5: Write a GET action that accepts the new model information

1. In the **ButterflyController** class, add a method for the **Create** action by using the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**

#### Task 6: Write a POST action that accepts the model

1. In the **ButterflyController** class, add another method for the **Create** action by using the following information:

   - HTTP verb: **HTTP Post**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**
   - Parameter: a **Butterfly** object called **butterfly**.

2. Add code to the **Create** action that get the last butterflie from the **IDataService** interface ButterfliesList.

3. Add code to the **Create** action that saves the accepted new butterfly parameters and sets its **CreatedDate** property to today&#39;s date.

4. Within the **Create** action code block, add an if statement and check whether the accepted butterfly object **PhotoAvatar** property is not null and the length bigger then 0.

5. Within the **Create** action code block, initiate the following accepted butterfly object properties: 

  - First property: **ImageMimeType**
  - Second property: **ImageName** 
  - Third property: **Id** 

6. Add the accepted butterfly object to the **IButterfliesQuantityService** interface.

7. Use **MemoryStream** to initiate accepted butterfly object **PhotoFile** property with the **PhotoAvatar**.

8. Add the **butterfly** object to the ButterfliesList from the **IDataService** interface, and then redirect to the **Index** action.

>**Results** : After completing this exercise, you will be able to create Models and implement **GET** and **POST** actions for the Butterfly model class in the application. 

### Exercise 2: Working with Forms

#### Scenario

In this exercise, you will:

- Add **Display** and **Edit** data annotations to butterfly model.
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

2. Add a display data annotation to the **Butterfly** model class to ensure that the **CommonName** property is displayed with the name, **Common Name**.

3. Add a display data annotation to the **Butterfly** model class to ensure that the **ButterflyFamily** property is displayed with the name, **Butterfly Family**.

4. Add a display data annotation to the **Butterfly** model class to ensure that the **Quantity** property is displayed with the name, **Butterflies Quantity**.

5. Add a display data annotation to the **Butterfly** model class to ensure that the **Characteristics** property is displayed with the name, **Characteristics**.

6. Add the following data annotations to the **Butterfly** model class to describe the **CreatedDate** property:

   - Data type: **DateTime**
   - Display name: **Updated on**
   - Display format: **{0:dd/MM/yy}**

7. Add a display data annotation to the **Butterfly** model class to ensure that the **PhotoAvatar** property is displayed with the name, **Butterflies Picture**.

#### Task 2: Update an action to return FileContentResult

1. In the **GetImage** action, initialize the **fullPath** object, in order to refer to the name of the image under the images directory.

2. In the **GetImage** action, If the **fullPath** exists, read the image bytes using **BinaryReader**, and then return a **File** result constructed from the **image bytes** and **Butterfly.ImageMimeType** properties.

3. Else if the accepted butterfly object **PhotoFile** property length bigger then 0, return a **File** result constructed from the accepted butterfly object **PhotoFile** and **ImageMimeType** properties, else return the **NotFound** value.

#### Task 3: Add Display Helpers

1. In the **Index.cshtml** page, **replace** the code in the **foreach** code block, add an **H3** element with the **display-picture-title** class to display the **CommonName**  property from the model by using the following information:

   - Helper: **Html.DisplayFor**
   - Lamda expression: **modelItem =&gt; model.CommonName**

2. Add a code that runs if the **Model.ImageName** property is not **null**.

3. Within the **if** code block, add a **DIV** element using the following information:

   - Class: **photo-display**

4. Within the **DIV** code block, render an **&lt;img&gt;** tag. Use the following information:

   - Tag: **&lt;img&gt;**
   - Source: **Blank**

5. In the **src** attribute of the **&lt;img&gt;** tag, add a call to the **Url.Action** helper by using the following information:

   - Controller: **Butterfly**
   - Action: **GetImage**
   - Parameter: **Model.Id**

6. After the **if** code block, add a **DIV** element to the **Index.cshtml**, and then inside the **DIV** element, add **P** elements with the **display-label** and the **display-field** classes to display the **ButterflyFamily** property from the model by using the following information:

   - Helpers:
     - **Html.DisplayNameFor**
     - **HtmlDisplayFor**
   - Lamda expression: **model => item.ButterflyFamily**

7. After the controls for the **ButterflyFamily** property, add a **DIV** element to the **Index.cshtml**, and then inside the **DIV** element, add **P** elements with the **display-label** and the **display-field** classes to display the **Characteristics** property from the model by using the following information:

   - Helpers:
     - **Html.DisplayNameFor**
     - **HtmlDisplayFor**
   - Lamda expression: **model => item.Characteristics**

8. After the controls for the **Characteristics** property, add a **DIV** element to the **Index.cshtml**, and then inside the **DIV** element, add **P** elements with the **display-label** and the **display-field** classes to display the **Quantity** property from the model by using the following information:

   - Helpers:
     - **Html.DisplayNameFor**
     - **HtmlDisplayFor**
   - Lamda expression: **model => item.Quantity**

9. After the controls for the **Quantity** property, add a **DIV** element to the **Index.cshtml**, and then inside the **DIV** element, add **P** elements with the **display-label** and the **display-field** classes to display the **CreatedDate** property from the model by using the following information:

   - Helpers:
     - **Html.DisplayNameFor**
     - **HtmlDisplayFor**
   - Lamda expression: **model => item.CreatedDate**

#### Task 4: Add Form Helpers

1. In the **Create.cshtml** page, set the **@using** for the **Create.cshtml** to **ButterfliesShop.Models**.

2. In the **Create.cshtml** page, set the **@model** for the **Create.cshtml** to **ButterfliesShop.Models.Butterfly**.

3. Add an **DIV** element to the **Create.cshtml** page by using the following information:

    - Class: **container**

4. Add an **H1** element to the **Create.cshtml** page within the **DIV** element by using the following information:

    - Content: **Add Butterflies to The Shop**
    - Class: **main-title**

5. Create a **form** on the page within the **DIV** element by using the following information:

   - Action: **Create**
   - Form method: **FormMethod.Post**
   - Parameter: Pass the **HTML** attribute **enctype = "multipart/form-data"**

#### Task 5: Add Editor Helpers

1. In the **Create.cshtml** page, add a **DIV** element with the **form-field** class, and then inside the **DIV** element add a **LABEL** and an **INPUT** elements to display controls for the **CommonName** property of the model by using the following information:

   - Helper:
     - **asp-for**

2. After the controls for the **CommonName** property, add a **DIV** element with the **form-field** class, and then inside the **DIV** element add a **LABEL** and **SELECT** elements to display controls for the **ButterflyFamily** property of the model by using the following information:

   - Helpers:
     - **asp-for**
     - **asp-items**

3. After the controls for the **ButterflyFamily** property, add a **DIV** element with the **form-field** class, and then inside the **DIV** element add a **LABEL** and a **TEXTAREA** elements to display controls for the **Characteristics** property of the model by using the following information:

   - Helper:
     - **asp-for**

4. After the controls for the **Characteristics** property, add a **DIV** element with the **form-field** class, and then inside the **DIV** element add a **LABEL** and an **INPUT** elements to display controls for the **Quantity** property of the model by using the following information:

   - Helper:
     - **asp-for**

5. After the controls for the **Quantity** property, add a **DIV** element with the **form-field** class, and then inside the **DIV** element add a **LABEL** and an **INPUT** elements to display controls for the **PhotoAvatar** property of the model by using the following information:

   - Helper: **asp-for**
   - Input type: **file**

6. After the controls for the **PhotoAvatar** property, add a **DIV** element with the **form-field** class, and then inside the **DIV** element add an **INPUT** element for the **submit** button by using the following information:

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

3. Using the **ModelState.IsValid** property in a controller.

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

2. Add a **SPAN** element to display validation message for the **CommonName** property of the model by using the following information:

   - Helper:
     - **asp-validation-for**

3. Add a **SPAN** element to display validation message for the **ButterflyFamily** property of the model by using the following information:

   - Helper:
     - **asp-validation-for**

4. Add a **SPAN** element to display validation message for the **Characteristics** property of the model by using the following information:

   - Helper:
     - **asp-validation-for**

5. Add a **SPAN** element to display validation message for the **Quantity** property of the model by using the following information:

   - Helper:
     - **asp-validation-for**

6. Add a **SPAN** element to display validation message for the **PhotoAvatar** property of the model by using the following information:

   - Helper:
     - **asp-validation-for**

#### Task 3: Using the ModelState.IsValid property in a controller

1. In the **ButterflyController** class, within the **Create** action method code block for the **HTTP POST** verb, check if the **ModelState** is valid.

#### Task 4: Run the application

1. Save all the changes.

2. Start debugging the application.

3. On the **Add Butterflies to The Shop** page, leave all the fields blank, and then click **Submit**.

4. Correct all the fields with the validation message, and then click **Submit**.

      >**Note:** Verify the newly submitted butterfly details.

5. Stop debugging.

#### Task 5: Add custom validation

1. Create a new top-level folder, in the **ButterfliesShop** project by using the following information:

   - Folder name: **Validators**

2. Create a new class for the custom validation by using the following information:

   - Name: **MaxButterflyQuantityValidation**
   - Folder: **Validators**

3. Add **using** statements for the following namespaces:

   - **ButterfliesShop.Models**
   - **ButterfliesShop.Services**
   - **System.ComponentModel.DataAnnotations**

4. Ensure that the **MaxButterflyQuantityValidation** class inherits from the **ValidationAttribute** class.

5. In the **MaxButterflyQuantityValidation** class, create a new private object using the following information:

   - Scope: **private**
   - Data type: **integer**
   - Name: **_maxAmount** 

    Initialize the new object in the **MaxButterflyQuantityValidation** constructor with the value **int maxAmount**.

6. In the **MaxButterflyQuantityValidation** class, override the **IsValid** method with the following Parameters:

   - First parameter: an **object** called **value**
   - Second parameter: a **ValidationContext** object called **validationContext**  

7. Within the **IsValid** method get an instance of the **IButterfliesQuantityService** using the **GetService** method of the **ValidationContext** object.

8. Within the **IsValid** method get an instance of the current butterfly using the **ObjectInstance** method of the **ValidationContext** object.

9. If the current butterfly instance **ButterflyFamily** property is not null, then get the total quantity using the **GetButterflyFamilyQuantity** metod of the **IButterfliesQuantityService** service, and the current butterfly instance **Quantity** property.

10. If the total quantity is bigger then the private object **_maxAmount** return new **ValidationResult**. Else return **ValidationResult.Success**.

11. In the **Butterfly** class, add **using** statement for the following namespace:

   - **ButterfliesShop.Validators**

12. Add the custom validation data annotations to the **Butterfly** model class to ensure that the users complete the **Quantity** text box, and type the correct butterflies quantity.

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

5. Correct the **Butterflies Quantity** field, and then add the **Butterflies Picture** once again, and then click **Submit**.

      >**Note:** Verify the newly submitted butterfly details.

6. Stop debugging and close Microsoft Visual Studio.

>**Results**: After completing this exercise, you should have created a ButterfliesShop application in which users can submit to the shop variety of butterflies.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
