# Module 6: Developing Models

# Lab: Developing Models

#### Scenario

You are planning to create and code an MVC model that implements your plan for butterflies in the butterflies’ shop application. The model includes properties that describe butterfly. The model must enable the application to store uploaded butterflies.



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

- Add model classes to the web application and use them in views.
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
     - Data type for the image: **byte[]**
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

    - Content: **Welcome to our Web Store, Enjoy a Wide Variety of Butterflies**
    - Class: **into**

5. Add an **P** element to the **Index.cshtml** page within the **DIV** element by using the following information:

    - Content: **Our Butterflies in the Shop**
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

9. Create a new **foreach** code block that loop that loops through the **var** items in **Model.Butterflies** list within the **DIV** element.

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

3. Within the **Index** action code block, create a new instance of **IndexViewModel** model, and initiate it&#39;s **Butterflies** property with **ButterfliesList** method from the **IDataService** interface.

4. Pass the **IndexViewModel** object to the view **Index**, and return the view.

#### Task 4: Run the application

1. Save all the changes.

2. Run the website, and view the page you added.

3. Stop debugging.

#### Task 5: Write a GET action.

1. In the **ButterflyController** class, add a method for the **Create** action by using the following information:

   - HTTP verb: **HTTP Get**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**
   - Return the view: **Create**

#### Task 6: Write a POST action that accepts the model

1. In the **ButterflyController** class, add another method for the **Create** action by using the following information:

   - HTTP verb: **HTTP Post**
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **Create**
   - Parameter: a **Butterfly** object called **butterfly**.

2. Add code to the **Create** action that gets the last butterfly from the **IDataService** interface ButterfliesList.

3. Add code to the **Create** that sets its **CreatedDate** property to today&#39;s date.

4. Within the **Create** action code block, add an if statement and check whether the accepted butterfly object **PhotoAvatar** property is not null and the length bigger then 0.

5. Within the **IF** statement, initiate the following accepted butterfly object properties: 

    - First property: **ImageMimeType**
    - Second property: **ImageName** 
    - Third property: **Id** 

6. Add the accepted butterfly object to the **IButterfliesQuantityService** interface using the **AddButterfliesQuantityData** method.

7. Add **using** statment that initializes a **MemoryStream** object.

8. Within the **using** statment call the **copyTo** method of the PhotoAvatar property which acceptes the **MemoryStream** object as a parameter.

9. Within the **using** statment call the **ToArray** method of the **MemoryStream** object and assign the result to PhotoFile property of the accepted butterfly.

10. Add the **butterfly** object to the ButterfliesList from the **IDataService** interface, and then redirect to the **Index** action.

11. Else return a view with the accepted butterfly.

>**Results** : After completing this exercise, you will be able to create **Models** and implement **GET** and **POST** actions for the Butterfly model class in the application. 

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

2. Add a display data annotation to the **Butterfly** model class to ensure that the **CommonName** property:

   - Display name: **Common Name:**

3. Add a display data annotation to the **Butterfly** model class to ensure that the **ButterflyFamily** property:

   - Display name: **Butterfly Family:**

4. Add a display data annotation to the **Butterfly** model class to ensure that the **Quantity** property:

    - Display name: **Butterflies Quantity:**

5. Add a display data annotation to the **Butterfly** model class to ensure that the **Characteristics** property:

     - Display name: **Characteristics:**

6. Add the following data annotations to the **Butterfly** model class to describe the **CreatedDate** property:

   - Data type: **DateTime**
   - Display name: **Updated on**
   - Display format: **{0:dd/MM/yy}**

7. Add a display data annotation to the **Butterfly** model class to ensure that the **PhotoAvatar** property:

      - Display name: **Butterflies Picture:**

#### Task 2: Update an action to return FileContentResult

1. In the **GetImage** action, in the **IF** statment create a variable named **fullPath** of type string and initialize the variable, in order to refer to the name of the image under the images directory.

2. In the **GetImage** action, If the **fullPath** exists, initialize a new FileStream, and declare a byte array.

3. Within the **GetImage** action, add a using statment, and in the using statment add initialize a  BinaryReader object, and  assign binary reader length to the byte array. 

4. In the end of the **IF** statment return a **File** result constructed from the **image bytes** and **Butterfly.ImageMimeType** properties.

5. Otherwise, if the accepted butterfly object **PhotoFile** property length bigger then 0, return a **File** result constructed from the accepted butterfly object **PhotoFile** and **ImageMimeType** properties.

6. If not, return the **NotFound** value.

#### Task 3: Add Display Helpers

1. In the **Index.cshtml** page, **replace** the code in the **foreach** code block, add an **H3** element with the **display-picture-title** class to display the **CommonName**  property from the model by using the following information:

   - Helper: **Html.DisplayFor**
   - Lamda expression: **modelItem =&gt; model.CommonName**

2. Add a code that runs if the **Model.ImageName** property is not **null**.

3. Within the **if** code block, add a **DIV** element using the following information:

   - Class: **photo-display**

4. Within the **DIV** code block, render an **&lt;img&gt;** tag. Use the following information:

   - Tag: **&lt;img&gt;**
   - Class: **photo-display-img**

5. In the **src** attribute of the **&lt;img&gt;** tag, add a call to the **Url.Action** helper by using the following information:

   - Controller: **Butterfly**
   - Action: **GetImage**
   - Parameter: **Model.Id**

6. After the **if** code block, add a **DIV** element to the **Index.cshtml**, and then inside the **DIV** element, add **P** elements with the **display-label** and the **display-field** classes to display the **ButterflyFamily** property from the model by using the following information:

   - Helpers:
     - **Html.DisplayNameFor**
     - **HtmlDisplayFor**
   - Lamda expression: **model => item.ButterflyFamily**

7. After the controls for the **ButterflyFamily** property, add a **DIV** element to the **Index.cshtml** with the **display-info** class, and then inside the **DIV** element, add **P** elements with the **display-label** and the **display-field** classes to display the **Characteristics** property from the model by using the following information:

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

    - Content: **Add Butterflies to the Shop**
    - Class: **main-title**

5. Create a **form** on the page below the **H1** element by using the following information:

    - method: **post**
    - enctype: **multipart/form-data**
    - asp-action: **Create**
   
#### Task 5: Add Editor Helpers

1. In the **Create.cshtml** page, add a **DIV** element using the following information:

   - Class: **form-field**

2. Within the **DIV** element, add a **LABEL** element for the **CommonName** property of the model by using the following information:

   - Helper:
     - **asp-for**

3. Within the **DIV** element, add an  **INPUT** element for the **CommonName** property of the model by using the following information:

   - Helper:
     - **asp-for**

4. After the controls for the **CommonName** property, add a **DIV** element using the following information:

   - Class: **form-field**

5. Within the **DIV** element, add a **LABEL** element for the **ButterflyFamily** property of the model by using the following information:

   - Helper:
     - **asp-for**

6. Within the **DIV** element, add a **SELECT** element for the **ButterflyFamily** property of the model by using the following information:

   - Helper:
     - **asp-items**

7. After the controls for the **ButterflyFamily** property, add a **DIV** element using the following information:

   - Class: **form-field**

8. Within the **DIV** element, add a **LABEL** element  for the **Characteristics** property of the model by using the following information:

   - Helper:
     - **asp-for**

9.  Within the **DIV** element, add a **TEXTAREA** element for the **Characteristics** property of the model by using the following information:

   - Helper:
     - **asp-for**

10. After the controls for the **Characteristics** property, add a **DIV** element using the following information:

   - Class: **form-field**

11. Within the **DIV** element, add a **LABEL** element for the **Quantity** property of the model by using the following information:

   - Helper:
     - **asp-for**

12. Within the **DIV** element, add an  **INPUT** element for the **Quantity** property of the model by using the following information:

   - Helper:
     - **asp-for**

13. After the controls for the **Quantity** property, add a **DIV** element using the following information:

   - Class: **form-field**

14. Within the **DIV** element, add a **LABEL** element for the **PhotoAvatar** property of the model by using the following information:

   - Helper:
     - **asp-for**

15.  Within the **DIV** element, add an  **INPUT** element for the **PhotoAvatar** property of the model by using the following information:

   - Helper: **asp-for**
   - Input type: **file**

16.  After the controls for the **PhotoAvatar** property, add a **DIV** element using the following information:

   - Class: **form-field**

17. Within the **DIV** element, add an  **INPUT** element for the **submit** button by using the following information:

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

5. In the **MaxButterflyQuantityValidation** class, create a new private field using the following information:

   - Scope: **private**
   - Data type: **integer**
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
