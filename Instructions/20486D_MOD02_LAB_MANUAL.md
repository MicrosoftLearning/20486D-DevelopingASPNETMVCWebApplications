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

1. Examine the initial investigation.

2. Plan the photo model class.

3. Plan the comment model class.

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

2. Based on your reading of the **InitialInvestigation** document, add and describe a model class for photos in **Table 1: MVC Model** using the following information:
-   Class name:  **Photo**
-   Description:  **The photo model class represents a photo that authenticated users can upload to the website**

3. In **Table 1: MVC Model**, add a property using the following information:
-   Class name:  **Photo**
-   Property name:  **PhotoID**
-   Data type:  **Integer**

4. Add a property using the following information:
-   Class name:  **Photo**
-   Property name:  **Title**
-   Data type:  **String**

5. Add a property using the following information:
-   Class name:  **Photo**
-   Property name:  **PhotoFile**
-   Data type:  **Binary**

6. Add a property using the following information:
-   Class name:  **Photo**
-   Property name:  **Description**
-   Data type:  **String**

7. Add a property using the following information:
-   Class name:  **Photo**
-   Property name:  **CreatedDate**
-   Data type:  **Date**

8. Add a property using the following information:
-   Class name:  **Photo**
-   Property name:  **Owner**
-   Data type:  **Integer**

9. Merge all the rows in the **Model Class** and **Description** columns that belong to the **Photo** class, and save the document.

10. Open Visual Studio 2017 and create a new WPF project by using the following information:
-   Name:  **DesignProject**
-   Template: **WPF App (.NET Framework)**
-   Location:  **Allfiles/20486D/Mod02/Labfiles**
-   Solution name:  **DesignProject**
-   Create directory for solution:  **True**

11. Create a new  **Class Diagram**  in the main project's directory by using the following information:
-   File name:  **ModelDesign**

12. Drag a new **Class** object to the class diagram using the following information:
-   Class name:  **Photo**

13. Add attributes to the new **Photo** class diagram for each of the properties you planned for the photo class. For each attribute define a name and a type.

14. In **Photo.cs**, change the properties return values to match the property types.

15. Save the created diagram.


#### Task 3: Plan the comment model class.

1. Open the **DetailedPlanningDocument** document, and locate the MVC Model section.

2. Based on your reading of the **InitialInvestigation** document, add and describe a model class for comments in **Table 1: MVC Model**.

3. Based on your reading of the **InitialInvestigation** document, add and describe a model class for photos in **Table 1: MVC Model** using the following information:
-   Class name:  **Comment**
-   Description:  **The comment model class represents a comment that authenticated users can add to photos. This enables users to discuss others’ photos. Each comment is associated with just one photo**

4. In **Table 1: MVC Model**, add a property using the following information:
-   Class name:  **Comment**
-   Property name:  **CommentID**
-   Data type:  **Integer**

5. Add a property using the following information:
-   Class name:  **Comment**
-   Property name:  **User**
-   Data type:  **String**

6. Add a property using the following information:
-   Class name:  **Comment**
-   Property name:  **Subject**
-   Data type:  **String**

7. Add a property using the following information:
-   Class name:  **Comment**
-   Property name:  **Body**
-   Data type:  **String**

8. Add a property using the following information:
-   Class name:  **Comment**
-   Property name:  **PhotoID**
-   Data type:  **Integer**

9. Merge all the rows in the **Model Class** and **Description** columns that belong to the **Comment** class, and save the document.

10. In **ModelDesign.cd**, drag a new **Class** object to the class diagram using the following information:
-   Class name:  **Comment**

11. Add attributes to the new **Photo** class diagram for each of the properties you planned for the photo class. For each attribute define a name and a type.

12. In **Comment.cs**, change the properties return values to match the property types.

13. In **ModelDesign.cd**, drag, a new association object, and connect the two classes with it.

14. The association created a property,  in the photo class. In **Comment.cs**, change its return type to List<Comment>.

15.  In **ModelDesign.cd**, change the property back to "collection association".

16. Save the created diagram.

   >**Results** : After completing this exercise, you will be able to create proposals for a model, and configure the properties and data types of the model classes.

### Exercise 2: Planning Controllers

#### Scenario

You need to recommend a set of MVC controllers that are required to implement a photo sharing application. You will propose controllers based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

1. Plan the photo controller.

2. Plan the comment controller.

#### Task 1: Plan the photo controller.

1. Open the **DetailedPlanningDocument** document, and locate the MVC Controllers section.

2. Based on your reading of the **InitialInvestigation** document, add and describe a controller **Table 2: MVC Controllers** using the following information:
-   Controller name:  **PhotoController**

3. In **Table 1: MVC Model**, add a property using the following information:
-   Controller name:  **PhotoController**
-   Action name:  **DisplayGallery (GET)**
-   Action description:  **The action runs when the user requests the photo gallery page. The action obtains all the photos from the database and passes them to the DisplayGallery view**

4. In **Table 1: MVC Model**, add a property using the following information:
-   Controller name:  **PhotoController**
-   Action name:  **DisplayRecent (GET)**
-   Action description:  **This action is similar to the DisplayGallery action except that only the most recent photos are obtained from the database. This smaller collection of photos is passed to the DisplayGallery view**

5. In **Table 1: MVC Model**, add a property using the following information:
-   Controller name:  **PhotoController**
-   Action name:  **DisplayPhoto (GET)**
-   Action description:  **This action runs when the user clicks a “Details” link for a photo in a gallery. The action obtains full details of a single photo from the database and passes it to the DisplayPhoto view**

6. In **Table 1: MVC Model**, add a property using the following information:
-   Controller name:  **PhotoController**
-   Action name:  **AddPhoto (GET)**
-   Action description:  **This action runs when the user clicks a “Add a Photo” link. The action creates a new instance of the Photo model class and passes it to the AddPhoto view**

7. In **Table 1: MVC Model**, add a property using the following information: 
-   Controller name:  **PhotoController**
-   Action name:  **AddPhoto (POST)**
-   Action description:  **This action runs when the user clicks “Save” in the AddPhoto view. The action saves the file and details of the new Photo to the database and redirects the user to the DisplayGallery view**

8. In **Table 1: MVC Model**, add a property using the following information:
-   Controller name:  **PhotoController**
-   Action name:  **DeletePhoto (GET)**
-   Action description:  **This action runs when the user clicks a “Delete this Photo” link in the DisplayPhoto view. The action displays the DeletePhoto view, which requests confirmation for the deletion**

9. In **Table 1: MVC Model**, add a property using the following information:    
-   Controller name:  **PhotoController**
-   Action name:  **DeletePhoto (POST)**
-   Action description:  **This action runs when the user clicks “Delete” in the DeletePhoto view. The action deletes the current Photo, with its associate Comments, from the database and redirects the user to the DisplayGallery view**

10. Merge all the rows in the **Controller** column that belong to the **PhotoController** controller, and save the document.

#### Task 2: Plan the comment controller.

1. Based on your reading of the **InitialInvestigation** document, add and describe a controller **Table 2: MVC Controllers** using the following information:
-   Controller name:  **CommentController**

2. In **Table 2: MVC Controllers**, add a property using the following information:
-   Controller name:  **CommentController**
-   Action name:  **DisplayComments (GET)**
-   Action description:  **This action runs when the user clicks the “Add a Comment” link in the DisplayPhoto view. The action creates a new instance of the Comment model class and sets its PhotoID to be the ID of the current Photo. It passes this new comment to the AddComment view**

3. In **Table 2: MVC Controllers**, add a property using the following information:
-   Controller name:  **CommentController**
-   Action name:  **AddComment (GET)**
-   Action description:  **This action runs when the user clicks “Submit” in the AddComment view. The action saves the details of the new comment in the database and redirects the user to the DisplayPhoto view**

4. In **Table 2: MVC Controllers**, add a property using the following information:
-   Controller name:  **CommentController**
-   Action name:  **AddComment (POST)**
-   Action description:  **This action runs when the user clicks the “Add a Comment” link in the DisplayPhoto view. The action creates a new instance of the Comment model class and sets its PhotoID to be the ID of the current Photo. It passes this new comment to the AddComment view**

5. Merge all the rows in the **Controller** column that belong to the **CommentController** controller, and save the document.


   >**Results** : After completing this exercise, you will be able to create proposals for controllers, and configure their properties and data types.

### Exercise 3: Planning Views

#### Scenario

You need to recommend a set of MVC views that are required to implement a photo sharing application. You will propose views based on the results of an initial investigation into the requirement.

The main tasks for this exercise are as follows:

1. Define the views.

2. Design the single photo view.

3. Design the gallery view.

#### Task 1: Define the views.

1. Based on your reading of the **InitialInvestigation** document, add a controller **Table 3: MVC Views** using the following information:
-   Controller name:  **PhotoController**

2.  In **Table 3: MVC Views**, add a property using the following information:
-   Controller name:  **PhotoController**
-   View name:  **DisplayGallery**
-   Action description:  **This view displays a collection of Photos at thumbnail size. For each photo the Title, Owner, and Created Date values are displayed**

3. In **Table 3: MVC Views**, add a property using the following information:
-   Controller name:  **PhotoController**
-   View name:  **DisplayPhoto**
-   Action description:  **This view displays a single Photo at full size. The Title and Owner are displayed above the photo. The Photo Description, Created Date, and other values are displayed beneath the photo. Under these details, all the Comments for the current Photo are listed, with an “Add a Comment” link**

4. In **Table 3: MVC Views**, add a property using the following information:
-   Controller name:  **PhotoController**
-   View name:  **AddPhoto**
-   Action description:  **This view displays a form with which the user can upload and describe a new Photo**

5. In **Table 3: MVC Views**, add a property using the following information:
-   Controller name:  **PhotoController**
-   View name:  **DeletePhoto**
-   Action description:  **This view displays a form with which the user can confirm a Photo deletion. The view displays details of the current Photo, such as its Title and Description**

6. Merge all the rows in the **Controller** column that belong to the **PhotoController** controller, and save the document.

7. Based on your reading of the **InitialInvestigation** document, add a controller **Table 3: MVC Views** using the following information:
-   Controller name:  **CommentController**

8.  In **Table 3: MVC Views**, add a property using the following information:
-   Controller name:  **CommentController**
-   View name:  **DisplayComments**
-   Action description:  **This partial view, which is used on the DisplayPhoto form, displays all the Comments associated with the current Photo**

9. In **Table 3: MVC Views**, add a property using the following information:
-   Controller name:  **CommentController**
-   View name:  **AddComment**
-   Action description:  **This view displays a form with which the user can create a new comment for a specified Photo**

10. Merge all the rows in the **Controller** column that belong to the **CommentController** controller, and save the document. 

#### Task 2: Design the single photo view.

1. Create a new  **Window (WPF)**  in the main project's directory by using the following information:
-   File name:  **SinglePhotoView**

2. Modify the main window properties using the following information:
-   Width:  **500**
-   Height:  **1100**
-   WindowStyle:  **None**

3. Drag a **Label** to the top left corner of the screen and use following information:
-   Content:  **Adventure Works Photo Sharing**
-   Text size: **20 px**

4. Drag a **Canvas** below the label and use following information:
-   Background style:  **Solid color brush**
-   Background R:  **150**
-   Background G:  **175**
-   Background B:  **207**
-   Width:  **400**
-   Width:  **40**

5. Drag a **Button** into the canvas and use following information:
-   Content:  **Home**
-   Background style:  **Solid color brush**
-   Background R:  **150**
-   Background G:  **175**
-   Background B:  **207**
-   Foreground style:  **Solid color brush**
-   Foreground R:  **150**
-   Foreground G:  **175**
-   Foreground B:  **207**

6. Copy the button and paste it to the right side of the previous button. Change its content to **Gallery**.

7. Paste the button again, and place it to the right side of the last pasted button. Change its content to **Photo**.

8. Paste the button again, and place it to the right side of the last pasted button. Change its content to **Slideshow**.

9. Drag a **Label** below the left side of the canvas and use following information:
-   Content:  **Title**
-   Text size:  **20 px**

10. Drag a **Label** below the last created label and use following information:
-   Content: **By: Owner**

11. Add existing item to the current project main directory using the following information:
 -   File path: **Allfiles\Mod02\Labfiles\01_DesignProject_begin**
 -   File name: **photo.jpg**

12. Drag an **Image** below the last created label and use following information:
-   Source: **photo.jpg**
-   Width: **400**
-   Height: **240**

13. Drag a **Label** below the left side of the image and use following information:
-   Content:  **Description:**

14. Drag a **Label** below the last created label and use following information:
-   Content:  **Photo Description...**
-   Width: **300**
-   Height: **150**
-   BorderBrush style:  **Solid color brush**
-   BorderBrush R:  **0**
-   BorderBrush G:  **0**
-   BorderBrush B:  **0**
-   Border Thickness: **2 (In each one of the 4 boxes)**

15. Drag a **Label** below the left side of the canvas and use following information:
-   Content:  **Comments:**

16. Drag a **Canvas** below the label and use following information:
-   Width: **300**
-   Height: **130**
-   Forground style:  **Solid color brush**
-   Forground R:  **150**
-   Forground G:  **175**
-   Forground B:  **207**

17. Drag a **Label** into the top left corner of the canvas and use following information:
-   Content:  **From:**

18. Drag a **Label** into the canvas, below the last created label and use following information:
-   Content:  **Subject:**

19. Drag a **Label** into the canvas, below the last created label and use following information:
-   Content:  **Body:**

20. Copy the canvas we created and filled with labels.

21. Paste the canvas below the last copied canvas.

22. Drag a **TextBlock** below the left side of the canvas and use following information:
-   Content:  **Add a Comment**
-   Foreground style:  **Solid Color Brush**
-   Foreground R:  **0**
-   Foreground G:  **0**
-   Foreground B:  **255**
-   Underline:  **True**

#### Task 3: Design the gallery view.

1. Create a new  **Window (WPF)**  in the main project's directory by using the following information:
-   File name:  **PhotoGalleryView**

2. Modify the main window properties using the following information:
-   Width:  **500**
-   Height:  **600**
-   WindowStyle:  **None**

3. Drag a **Label** to the top left corner of the screen and use following information:
-   Content:  **Adventure Works Photo Sharing**
-   Text size: **20 px**

4. In the **SinglePhotoView.xaml** copy the canvas that contains 4 buttons.

5. In the **PhotoGalleryView.xaml** paste the canvas below the label.

6. Drag a **Canvas** below the last created canvas and use following information:
-   Width:  **150**
-   Height:  **190**
-   Forground style:  **None**
-   Forground R:  **150**
-   Forground G:  **175**
-   Forground B:  **207**

7. Drag a **Label** into the to left corner of the canvas and use following information:
-   Content:  **Title**

8. Drag a **Label** into the canvas below the label and use following information:
-   Content:  **By: Owner**

9. Drag a **Image** into the canvas below the label and use following information:
-   Source:  **photo.jpg**
-   Width:  **100**
-   Height:  **100**

10. Drag a **Label** below the last created image and use following information:
-   Content:  **Created On: Date**

11. Copy the canvas that contains the image.

12. Paste the canvas to the right side of the copied canvas.

13. Paste another canvas below the last pasted canvas.

12. Paste the canvas to the left of the last pasted canvas.

   >**Results** : After completing this exercise, you will create proposals for views and their layouts.

### Exercise 4: Architecting an MVC Web Application

#### Scenario

You need to recommend a web server and database server configuration that is required to implement a photo sharing application. You will propose details based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

1. Hosting options.

2. Choose a data store.

#### Task 1: Hosting options.

1. Based on your reading of the **InitialInvestigation** document, add a description of the web server arrangements that are suited to host the photo sharing application.

#### Task 2: Choose a data store.

2. Based on your reading of the **InitialInvestigation** document, add a description of the database server arrangements that are suited to host the photo sharing application.

   >**Results**: After completing this exercise, you will be able to create proposals for hosting arrangements.

©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
