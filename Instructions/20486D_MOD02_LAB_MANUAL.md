# Module 2: Designing ASP.NET Core MVC Web Applications

# Lab: Designing ASP.NET Core MVC Web Applications

#### Scenario

Your team has chosen ASP.NET Core MVC as the appropriate ASP.NET programming model to create the photo sharing application for the Adventure Works web application. You need to create a detailed project design for the application. You have been given a set of functional and technical requirements with other information to help you get started. You have to plan for:

- An MVC model that you can use to implement the desired functionality.
- One or more controllers and controller actions that respond to users' actions.
- A set of views to implement the user interface.
- The locations for hosting and data storage.

#### Objectives

After completing this lab, you will be able to:

- Design an ASP.NET Core MVC web application that meets a set of functional requirements.
- Record the design in an accurate, precise, and informative manner.

#### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Planning Model Classes

#### Scenario

You have to recommend an MVC model to implement a photo sharing application. You propose the model classes based on the results of an initial investigation into the requirements.

The main tasks for this exercise are:

1. Examine the initial investigation.

2. Plan the photo model class.

3. Plan the comment model class.

#### Task 1: Examine the initial investigation.

1. From, **Allfiles\Mod02\Labfiles\01_DesignProject_begin**, open the **InitialInvestigation** file.

2. Enable the **Navigation Pane** feature.

3. Read the **Introduction** section.

4. Read the **General Description** section.

5. Read the **Use Cases** section, and then examine the **Use Case Summary** diagram.

6. Close the **InitialInvestigation** file.

#### Task 2: Plan the photo model class.

1. From **Allfiles\Mod02\Labfiles\01_DesignProject_begin**, ppen the **DetailedPlanningDocument** file, and locate the **MVC Model** section.

2. After reading the **InitialInvestigation** file, add and describe a model class for photos in **Table 1: MVC Model**.

3. Add properties to the model class you created in **Table 1: MVC Model**. The model class will have many properties.

4. Add data types to the photo properties. Each property will have one, and only one data type.

5. Merge the rows in the **Model Class** and **Description** columns, and save the document.

6. In Visual Studio, create a **WPF Project**.

7. Add a **Class Diagram** template to the project.

8. Add a new **Class** to the class diagram.

9. For each of the properties that you planned for the **photo** class, add attributes to the new **Photo** class diagram.

10. Fix the properties return values in the **Photo** class, to match the property types.

11. Save the created diagram.


#### Task 3: Plan the comment model class.

1. Open the **DetailedPlanningDocument** file, and locate the **MVC Model** section.

2. Based on your reading of the **InitialInvestigation** file, add and describe a model class for photos in **Table 1: MVC Model**.

3. To the model class you created in **Table 1: MVC Model**, add properties.

4. Add data types to the **comment** property.

5. Merge the rows in the **Model Class** and the **Description** columns, and then save the document.

7. Add a new **Class** to the class diagram and name it **Comment**.

8. Add attributes to the new **Comment** class diagram for each of the properties you planned for the comment.

9. Connect the two classes with an association object.

10. The association creates a property  in the **photo** class. Change its return type to **List<Comment>**, and in the class diagram, change the property back to **collection association**.

11. Fix the properties return values in the **Photo** class, to match the property types.

   >**Results** : After completing this exercise, you will be able to create proposals for a model, and configure the properties and data types of the model classes.

### Exercise 2: Planning Controllers

#### Scenario

You have to recommend a set of MVC controllers that are required to implement a photo sharing application. You propose controllers based on the results of an initial investigation into the requirements.

The main tasks for this exercise are:

1. Plan the photo controller.

2. Plan the comment controller.

#### Task 1: Plan the photo controller.

1. Open the **DetailedPlanningDocument** file, and locate the **MVC Controllers** section.

2. Based on your reading of the **InitialInvestigation** document, add a controller for photos in **Table 2: MVC Controllers**.

3. In **Table 2: MVC Controllers**, add actions to the controller for photos.

4. For each of the actions, add descriptions.

5. Merge the rows in the **Controller** column, and save the document.


#### Task 2: Plan the comment controller.

1. Based on your reading of the **InitialInvestigation** document, add the **comments** controller in **Table 2: MVC Controllers**.

2. In **Table 2: MVC Controllers**, add actions to the **comments** controller.

3. For each of the actions, add descriptions.

4. Merge rows in the **Controller** column, and save the document.

   >**Results** : After completing this exercise, you will be able to create proposals for controllers, and configure their properties and data types.

### Exercise 3: Planning Views

#### Scenario

You have to recommend a set of MVC views that are required to implement a photo sharing application. You propose views based on the results of an initial investigation into the requirement.

The main tasks for this exercise are:

1. Define the views.

2. Design the single photo view.

3. Design the gallery view.

#### Task 1: Define the views.

1. Add a controller to the **Table 3: MVC Views** table.

2. To the controllers, add the required views.

3. To the views, add descriptions.

4. Merge rows in the **Controller** column, and save the document.


#### Task 2: Design the single photo view.

1. Create a new **WPF Window** and name it **SinglePhotoView**.

2. For the header, add a label.

3. For the site menu, according the the use cases defined, add a canvas, and place buttons inside it.

4. Design the canvas and buttons so they look good.

5. Below it, add labels to display the photo properties. (Replace **photo name** with  **Title**, **owner name** with **Owner**, **date value** with **Date**, etc.).

6. Add an **Image** object and maximize it. (Use the **Allfiles\Mod02\Labfiles\01_DesignProject_begin\photo.jpg** file as a placeholder, to be shown instead of real photos).

7. For the comments, add a canvas. Fill it with as many labels as required for the comment properties. (Replace **photo name** with  **Title**, **owner name** with **Owner**, **date value** with **Date**, etc.).

8. Add a textblock that supports underline to represent a link, and inside it type **Add Comment**.

#### Task 3: Design the gallery view.

1. Create a new **WPF Window** and name it **PhotoGalleryView**.

2. For the header, add a label.

3. For the site menu, according the the use cases defined, add a canvas, and place buttons inside it.

4. Design the canvas and buttons so they look good.

5. Below the menu, add a canvas. Fill it with the photo and properties that should be shown for a list of photos in the home page.

6. Copy the canvas multiple times for each image, as an image list.

   >**Results** : After completing this exercise, you will create proposals for views and their layouts.

### Exercise 4: Architecting an MVC Web Application

#### Scenario

You have to recommend a web server and database server configuration that is required to implement a photo sharing application. You propose details based on the results of an initial investigation into the requirements.

The main tasks for this exercise are:

1. Hosting options.

2. Choose a data store.

#### Task 1: Hosting options.

1. Based on your reading of the **InitialInvestigation** document, add a description of the web server arrangements that are suited to host the photo sharing application.

#### Task 2: Choose a data store.

2. Based on your reading of the **InitialInvestigation** document, add a description of the database server arrangements that are suited to host the photo sharing application.

   >**Results**: After completing this exercise, you will be able to create proposals for hosting arrangements.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
