# Module 2: Designing ASP.NET Core MVC Web Applications

# Lab: Designing ASP.NET Core MVC Web Applications

#### Scenario

Your team has chosen ASP.NET Core MVC as the most appropriate ASP.NET programming model to create the photo sharing application for the Adventure Works web application. You need to create a detailed project design for the application, and have been given a set of functional and technical requirements with other information. You have to plan:

- An MVC model that you can use to implement the desired functionality.
- One or more controllers and controller actions that respond to users actions.
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

You need to recommend an MVC model that is required to implement a photo sharing application. You will propose model classes based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

-   Examine the initial investigation.

-   Plan the photo model class.

-   Plan the comment model class.


#### Task 1: Examine the initial investigation.

1. Open the **InitialInvestigation** document by using the following information:

   - File location: **Allfiles\Mod02\Labfiles\01_DesignProject_begin**

2. Enable the **Navigation Pane** feature.

3. Read the contents of the Introduction section.

4. Read the contents of the General Description section.

5. Read the Use Cases section, and then examine the **Use Case Summary** diagram.

6. Close the **InitialInvestigation** document.

#### Task 2: Plan the photo model class.

1. Open the **DetailedPlanningDocument** document, and locate the MVC Model section.

   - File location: **Allfiles\Mod02\Labfiles\01_DesignProject_begin**

2. Based on your reading of the **InitialInvestigation** document, add and describe a model class for photos in **Table 1: MVC Model**.

3. Add properties to the model class you created in **Table 1: MVC Model**. The model class will have many properties

4. Add data types to the photo properties. Each property will have one, and only one data type.

5. Merge the rows in the **Model Class** and **Description** columns, and save the document.

6. Create a **WPF Project** in visual studio.

7. Add a **Class Diagram** template to the project.

8. Add a new **Class** to the class diagram.

9. Add attributes to the new Class shape for each of the properties you planned for the photos.

10. Save the created diagram.


#### Task 3: Plan the comment model class.

1. Open the **DetailedPlanningDocument** document, and locate the MVC Model section.

2. Based on your reading of the **InitialInvestigation** document, add and describe a model class for photos in **Table 1: MVC Model**.

3. Add properties to the model class you created in **Table 1: MVC Model**.

4. Add data types to the comment properties.

5. Merge the rows in the **Model Class** and the **Description** columns, and then save the document.

7. Add a new **Class** to the class diagram.

8. Add attributes to the new Class shape for each of the properties you planned for comments.

9. Connect the two classes with association object.

10. The association created a property,  in the photo class. Change its return type to List<Comment>, and change the property back to "collection association" in the class diagram.

   >**Results** : After completing this exercise, you will be able to create proposals for a model, and configure the properties and data types of the model classes.

### Exercise 2: Planning Controllers

#### Scenario

You need to recommend a set of MVC controllers that are required to implement a photo sharing application. You will propose controllers based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

1. Plan the photo controller.

2. Plan the comment controller.


#### Task 1: Plan the photo controller.

1. Open the **DetailedPlanningDocument** document, and locate the MVC Controllers section.

2. Based on your reading of the **InitialInvestigation** document, add a controller for photos in **Table 2: MVC Controllers**.

3. Add actions to the controller for photos in **Table 2: MVC Controllers**.

4. Add descriptions for each of the actions you have planned.

5. Merge rows in the **Controller** column, and save the document.


#### Task 2: Plan the comment controller.

1. Based on your reading of the **InitialInvestigation** document, add a controller for photos in **Table 2: MVC Controllers**.

2. Add actions to the controller for comments in **Table 2: MVC Controllers**.

3. Add descriptions for each of the actions you have planned.

4. Merge rows in the **Controller** column, and save the document.

   >**Results** : After completing this exercise, you will be able to create proposals for controllers, and configure their properties and data types.

### Exercise 3: Planning Views

#### Scenario

You need to recommend a set of MVC views that are required to implement a photo sharing application. You will propose views based on the results of an initial investigation into the requirement.

The main tasks for this exercise are as follows:

1. Plan the single photo view.

2. Plan the gallery view.


#### Task 1: Define the views.

1. Add a controller to the **Table 3: MVC Views** table.

2. Add the required views to the Controllers.

3. Add a description to the views.

4. Merge rows in the **Controller** column, and save the document.


#### Task 2: Design the single photo view.

1. Create a new **WPF Window** with the name **SinglePhotoView**.

2. Drag a **label** as header.

3. Drag a **Canvas**, and put inside it **buttons**, as the site menu according the the use cases defined.

4. **Design** the canvas, and buttons so they will look well.

5. Drag below it **labels** that show the photo properties as needed. (Write "Title" instead of the photo name, "Owner" instead of the owner name, "Date", instead of date value etc.)

6. Drag an **Image** object and maximize it. (Use the image as placeholder file **Allfiles\Mod02\Labfiles\01_DesignProject_begin\NoImage.jpg** to be shown instead of real photos).

7. Drag **Canvas** for the comments, and fill it with **Labels** according to the comment properties. (Write "Title" instead of the photo name, "Owner" instead of the owner name, "Date", instead of date value etc.)

8. Add a **TextBlock** which supports underline to represend a link, and fill it with the text **Add Comment**.


#### Task 3: Design the gallery view.

1. Create a new **WPF Window** with the name **PhotoGalleryView**.

2. Drag a **label** as header.

3. Drag a **Canvas**, and put inside it **buttons**, to be used as the site menu according the the use cases defined.

4. **Design** the canvas and buttons so they will look well.

5. Drag a **canvas** below the menu, and fill it with the photo and properties that should be shown for a list of photos in the home page.

6. Copy the canvas multiple times for each image, as an image list.

   >**Results** : After completing this exercise, you will create proposals for views and their layouts.

### Exercise 4: Architecting an MVC Web Application

#### Scenario

You need to recommend a web server and database server configuration that is required to implement a photo sharing application. You will propose details based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

1. Hosting options.

2. Choose a data store.

#### Task 1: Hosting options.

- Based on your reading of the **InitialInvestigation** document, add a description of the web server arrangements that are suited to host the photo sharing application.

#### Task 2: Choose a data store.

- Based on your reading of the **InitialInvestigation** document, add a description of the database server arrangements that are suited to host the photo sharing application.

   >**Results**: After completing this exercise, you will be able to create proposals for hosting arrangements.

©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
