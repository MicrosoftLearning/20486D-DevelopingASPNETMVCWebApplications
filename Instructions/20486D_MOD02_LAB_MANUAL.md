# Module 2: Designing ASP.NET Core MVC Web Applications

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lab: Designing ASP.NET Core MVC Web Applications

#### Scenario

Your team has chosen ASP.NET Core MVC as the most appropriate ASP.NET programming model to create the photo sharing application for the Adventure Works web application. You need to create a detailed project design for the application and have been given a set of functional and technical requirements with other information. You have to plan:

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

1. Examine the initial investigation

2. Plan the photo model class

3. Plan the comment model class

#### Task 1: Examine the initial investigation

1. Open the **InitialInvestigation** document by using the following information:

    - File location: **[Repository Root]\Allfiles\Mod02\Labfiles\01_DesignProject_begin**

2. Enable the **Navigation Pane** feature.

3. Read the contents of the **Introduction** section.

4. Read the contents of the **General Description** section.

5. Read the **Use Cases** section, and then examine the **Use Case Summary** diagram.

6. Close the **InitialInvestigation** document.

#### Task 2: Plan the photo model class

1. Open the **DetailedPlanningDocument** document and locate the **MVC Model** section.
    - File location: **[Repository Root]\Allfiles\Mod02\Labfiles\01_DesignProject_begin**

2. Based on your reading of the **InitialInvestigation** document, add and describe a model class for photos in **Table 1: MVC Model** by using the following information:
    - Class name: **Photo**
    - Description: **The photo model class represents a photo that authenticated users can upload to the website**

3. In **Table 1: MVC Model**, add a property by using the following information:
    - Class name: **Photo**
    - Property name: **PhotoID**
    - Data type: **Integer**

4. Add a property by using the following information:
    - Class name: **Photo**
    - Property name: **Title**
    - Data type: **String**

5. Add a property by using the following information:
    - Class name: **Photo**
    - Property name: **PhotoFile**
    - Data type: **Binary**

6. Add a property by using the following information:
    - Class name: **Photo**
    - Property name: **Description**
    - Data type: **String**

7. Add a property by using the following information:
    - Class name: **Photo**
    - Property name: **CreatedDate**
    - Data type: **DateTime**

8. Add a property by using the following information:
    - Class name: **Photo**
    - Property name: **Owner**
    - Data type: **Integer**

9. Merge all the rows in the **Model Class** column that belong to the **Photo** class, and then save the document.

10. Merge all the rows in the **Description** column that belong to the **Photo** class, and then save the document.

    >**Note**: Keep the **DetailedPlanningDocument - Microsoft Word** window open for future tasks in this lab.

11. Open Microsoft Visual Studio 2017 and create a new **WPF App (.NET Framework)** project by using the following information:
    - Name: **DesignProject**
    - Template: **WPF App (.NET Framework)**
    - Location: **[Repository Root]\Allfiles\Mod02\Labfiles**
    - Solution name: **DesignProject**
    - Create directory for solution: **True**

12. In the main project's directory, create a new **Class Diagram** by using the following information:
    - File name: **ModelDesign**
    - Item type: **Class Diagram**

13. Open the **Toolbox** window.

14. In **ModelDesign.cd**, drag a new **Class** object to the class diagram by using the following information:
    - Class name: **Photo**

15. In the **Photo** class diagram, add a property by using the following information:
    - Property name: **PhotoID**
    - Data type: **int**

16. Add a property by using the following information:
    - Property name: **Title**
    - Data type: **string**

17. Add a property by using the following information:
    - Property name: **PhotoFile**
    - Data type: **byte**

18. Add a property by using the following information:
    - Property name: **Description**
    - Data type: **string**

19. Add a property by using the following information:
    - Property name: **CreatedDate**
    - Data type: **DateTime**

20. Add a property by using the following information:
    - Property name: **Owner**
    - Data type: **string**

    >**Note**: Keep the **DesignProject – Microsoft Visual Studio** window open for future tasks in this lab.

21. In **Photo.cs**, in the **Title** property, change the property return type to **string**.

22. In the **PhotoFile** property, change the property return type to **byte**.

23. In the **Description** property, change the property return type to **string**.

24. In the **CreatedDate** property, change the property return type to **DateTime**.

25. In the **Owner** property, change the property return type to **string**.

26. Save the created diagram.

#### Task 3: Plan the comment model class

1. In the **DetailedPlanningDocument**, locate the **MVC Model** section.

2. Based on your reading of the **InitialInvestigation** document, add and describe a model class for comments in **Table 1: MVC Model** by using the following information:
    - Class name: **Comment**
    - Description: **The comment model class represents a comment that authenticated users can add to photos. This enables users to discuss others’ photos. Each comment is associated with just one photo.**

3. In **Table 1: MVC Model**, add a property by using the following information:
    - Class name: **Comment**
    - Property name: **CommentID**
    - Data type: **int**

4. Add a property by using the following information:
    - Class name: **Comment**
    - Property name: **User**
    - Data type: **string**

5. Add a property by using the following information:
    - Class name: **Comment**
    - Property name: **Subject**
    - Data type: **string**

6. Add a property by using the following information:
    - Class name: **Comment**
    - Property name: **Body**
    - Data type: **string**

7. Add a property by using the following information:
    - Class name: **Comment**
    - Property name: **PhotoID**
    - Data type: **int**

8. Merge all the rows in the **Model Class** column that belong to the **Comment** class, and then save the document.

9. Merge all the rows in the **Description** column that belong to the **Comment** class, and then save the document.

10. In **ModelDesign.cd**, drag a new **Class** object to the class diagram by using the following information:
    - Class name: **Comment**

11. In **ModelDesign.cd**, connect the **Photo** class to the **Comment** class by using the association object from the toolbox.

12. Change the association name to **PhotoComments**.

13. In **Photo.cs**, change the **PhotoComments** property type to **List<Comment>**.

14. In **Photo.cs**, change the **PhotoComments** property return type to **List<Comment>**.

15. In **ModelDesign.cd**, change the **PhotoComments** property to **Show as Collection Association**.

    >**Note**: See that the association has two arrowheads instead of one. It is a collection association between the **Photo** class and the **Comment** class. This indicates that the **Photo** class has a **PhotoComments** property that contains a collection of **Comment** objects.


16. In the **Comment** class diagram, add a property by using the following information:
    - Property name: **CommentID**
    - Data type: **int**

17. Add a property by using the following information:
    - Property name: **User**
    - Data type: **string**

18. Add a property by using the following information:
    - Property name: **Subject**
    - Data type: **string**

19. Add a property by using the following information:
    - Property name: **Body**
    - Data type: **string**

20. Add a property by using the following information:
    - Property name: **PhotoID**
    - Data type: **int**

21. In **Comment.cs**, in the **User** property, change the property return type to **string**.

22. In the **Subject** property, change the property return type to **string**.

23. In the **Body** property, change the property return type to **string**.

24. Save the created diagram.


>**Results**: After completing this exercise, you will be able to create proposals for a model and configure the properties and data types of the model classes.

### Exercise 2: Planning Controllers

#### Scenario

You need to recommend a set of MVC controllers that are required to implement a photo sharing application. You will propose controllers based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

1. Plan the photo controller

2. Plan the comment controller

#### Task 1: Plan the photo controller

1. In the **DetailedPlanningDocument**, locate the **MVC Controllers** section.

2. Based on your reading of the **InitialInvestigation** document, add and describe a controller for photos in **Table 2: MVC Controllers** by using the following information:
    - Controller name: **PhotoController**

3. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **PhotoController**
    - Action name: **DisplayGallery (GET)**
    - Action description: **The action runs when the user requests the Photo Gallery page. The action obtains all the photos from the database and passes them to the DisplayGallery view.**

4. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **PhotoController**
    - Action name: **DisplayRecent (GET)**
    - Action description: **This action is similar to the DisplayGallery action except that only the most recent photos are obtained from the database. This smaller collection of photos is passed to the DisplayGallery view.**

5. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **PhotoController**
    - Action name: **DisplayPhoto (GET)**
    - Action description: **This action runs when the user clicks a photo's “Details” link in a gallery. The action obtains full details of a single photo from the database and passes it to the DisplayPhoto view.**

6. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **PhotoController**
    - Action name: **AddPhoto (GET)**
    - Action description: **This action runs when the user clicks an “Add a Photo” link. The action creates a new instance of the Photo model class and passes it to the AddPhoto view.**

7. In **Table 2: MVC Controllers**, add an action by using the following information: 
    - Controller name: **PhotoController**
    - Action name: **AddPhoto (POST)**
    - Action description: **This action runs when the user clicks “Save” in the AddPhoto view. The action saves the file and details of the new photo to the database and redirects the user to the DisplayGallery view.**

8. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **PhotoController**
    - Action name: **DeletePhoto (GET)**
    - Action description: **This action runs when the user clicks a “Delete this Photo” link in the DisplayPhoto view. The action displays the DeletePhoto view, which requests confirmation for the deletion.**

9. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **PhotoController**
    - Action name: **DeletePhoto (POST)**
    - Action description: **This action runs when the user clicks “Delete” in the DeletePhoto view. The action deletes the current photo, with its associated comments from the database and redirects the user to the DisplayGallery view.**

10. In the **Controller** column, merge all the rows that belong to the **PhotoController** controller, and then save the document.

#### Task 2: Plan the comment controller

1. In the **DetailedPlanningDocument**, locate the **MVC Controllers** section.

2. Based on your reading of the **InitialInvestigation** document, add and describe a controller for comments in **Table 2: MVC Controllers** by using the following information:
    - Controller name: **CommentController**

3. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **CommentController**
    - Action name: **DisplayComments (GET)**
    - Action description: **This action runs when the DisplayPhoto view is displayed. The action requires the current PhotoID as a parameter and uses it to get all the comments for the current photo from the database. The action returns the _DisplayComments partial view.**

4. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **CommentController**
    - Action name: **AddComment (GET)**
    - Action description: **This action runs when the user clicks the “Add a Comment” link in the DisplayPhoto view. The action creates a new instance of the Comment model class and sets its PhotoID to be the ID of the current photo. It passes this new comment to the AddComment view.**

5. In **Table 2: MVC Controllers**, add an action by using the following information:
    - Controller name: **CommentController**
    - Action name: **AddComment (POST)**
    - Action description: **This action runs when the user clicks “Submit” in the AddComment view. The action saves the details of the new comment in the database and redirects the user to the DisplayPhoto view.**

6. In the **Controller** column, merge all the rows that belong to the **CommentController** controller, and then save the document.

>**Results**: After completing this exercise, you will be able to create proposals for controllers and configure their properties and data types.

### Exercise 3: Planning Views

#### Scenario

You need to recommend a set of MVC views that are required to implement a photo sharing application. You will propose views based on the results of an initial investigation into the requirement.

The main tasks for this exercise are as follows:

1. Define the views

2. Design the single photo view

3. Design the gallery view

#### Task 1: Define the views

1. Based on your reading of the **InitialInvestigation** document, add views in **Table 3: MVC Views** by using the following information:
    - Controller name: **PhotoController**

2. In **Table 3: MVC Views**, add a view by using the following information:
    - Controller name: **PhotoController**
    - View name: **DisplayGallery**
    - Action description: **This view displays a collection of photos in the thumbnail size. For each photo the Title, Owner, and Created Date values are displayed.**

3. In **Table 3: MVC Views**, add a view by using the following information:
    - Controller name: **PhotoController**
    - View name: **DisplayPhoto**
    - Action description: **This view displays a single photo in full size. The Title and Owner values appear above the photo. The Photo Name, Description, and other values appear beneath the photo. Under these details, all the comments for the current photo are listed with an “Add a Comment” link.**

4. In **Table 3: MVC Views**, add a view by using the following information:
    - Controller name: **PhotoController**
    - View name: **AddPhoto**
    - Action description: **This view displays a form that the user can use to upload and describe a new photo.**

5. In **Table 3: MVC Views**, add a view by using the following information:
    - Controller name: **PhotoController**
    - View name: **DeletePhoto**
    - Action description: **This view displays a form that the user can use to confirm the deletion of a photo. The view displays details of the current photo such as its title and description.**

6. In the **Controller** column, merge all the rows that belong to the **PhotoController** controller, and then save the document.

7. Based on your reading of the **InitialInvestigation** document, add a controller **Table 3: MVC Views** by using the following information:
    - Controller name: **CommentController**

8. In **Table 3: MVC Views**, add a view by using the following information:
    - Controller name: **CommentController**
    - View name: **DisplayComments**
    - Action description: **This partial view, which is used on the DisplayPhoto form, displays all the comments associated with the current photo.**

9. In **Table 3: MVC Views**, add a view by using the following information:
    - Controller name: **CommentController**
    - View name: **AddComment**
    - Action description: **This view displays a form that the user can use to create a new comment for a photo.**

10. In the **Controller** column, merge all the rows that belong to the **CommentController** controller, and then save the document. 

#### Task 2: Design the single photo view

1. In the main project's directory, create a new **Window (WPF)** by using the following information:
    - File name: **SinglePhotoView**

2. Open the **Properties** window.

3. Under **Type**, arrange by **Category**.

4. Open the **Document Outline** window.

5. Modify the main window properties by using the following information:
    - Width: **500**
    - Height: **1100**
    - WindowStyle: **None**

6. From the toolbox, drag a label to the top left-hand side corner of the screen by using the following information:
    - Content: **Adventure Works Photo Sharing**
    - Text size: **20 px**

7. Drag a canvas below the label and set its properties by using the following information:
    - Background style: **Solid color brush**
    - Background R: **150**
    - Background G: **175**
    - Background B: **207**
    - Width: **400**
    - Height: **40**

8. Select the canvas and drag a button on to its left-hand side and set its properties by using the following information:
    - Content: **Home**
    - Background style: **Solid color brush**
    - Background R: **31**
    - Background G: **71**
    - Background B: **125**
    - Foreground style: **Solid color brush**
    - Foreground R: **255**
    - Foreground G: **255**
    - Foreground B: **255**

9. Copy the button and paste it to the right-hand side of the previous button. Change its content to **Gallery**.

10. Paste the button again and place it to the right-hand side of the last pasted button. Change its content to **Add a Photo**.

11. Paste the button again and place it to the right-hand side of the last pasted button. Change its content to **Slideshow**.

12. Drag a label below the left-hand side of the canvas by using the following information:
    - Content: **Title**
    - Text size: **20 px**

13. Drag a label below the last created label by using the following information:
    - Content: **By: Owner**

14. To the current project's main directory, add an existing item by using the following information:
    - File path: **[Repository Root]\Allfiles\Mod02\Labfiles\01_DesignProject_begin**
    - File name: **photo.jpg**

15. Drag an image below the last created label by using the following information:
    - Source: **photo.jpg**
    - Width: **400**
    - Height: **240**

16. Drag a label below the left-hand side of the image by using the following information:
    - Content: **Description**

17. Drag a label below the last created label by using the following information:
    - Content: **Photo Description...**
    - Width: **300**
    - Height: **150**
    - BorderBrush style: **Solid color brush**
    - BorderBrush R: **150**
    - BorderBrush G: **175**
    - BorderBrush B: **207**
    - Border Thickness: **2 (In each one of the 4 boxes)**

18. Drag a label below the left-hand side of the canvas by using the following information:
    - Content: **Comments:**

19. Drag a canvas below the label by using the following information:
    - Width: **300**
    - Height: **130**
    - Background style: **Solid color brush**
    - Background R: **150**
    - Background G: **175**
    - Background B: **207**

20. Select the canvas and drag a label on to the top left-hand corner. Set its properties by using the following information:
    - Content: **From:**

21. Select the canvas and drag a label on to it. Place it below the last created label and set its properties by using the following information:
    - Content: **Subject:**

22. Select the canvas and drag a label on to it. Place it below the last created label and set its properties by using the following information:
    - Content: **Body:**

23. Copy the canvas and paste it below the last copied canvas.

24. Drag a textblock below the left-hand side of the canvas by using the following information:
    - Content: **Add a Comment**
    - Foreground style: **Solid Color Brush**
    - Foreground R: **0**
    - Foreground G: **0**
    - Foreground B: **255**
    - Underline: **True**
  
25. Save all changes.

#### Task 3: Design the gallery view

1. In the main project's directory, create a new **Window (WPF)** by using the following information:
    - File name: **PhotoGalleryView**

2. Modify the main window properties by using the following information:
    - Width: **500**
    - Height: **600**
    - WindowStyle: **None**

3. Drag a label to the top left corner of the screen by using the following information:
    - Content: **Adventure Works Photo Sharing**
    - Text size: **20 px**

4. In the **SinglePhotoView.xaml** file, copy the canvas that contains four buttons.

5. In the **PhotoGalleryView.xaml** file, paste the canvas and place it below the label.

6. Drag a canvas below the last created canvas by using the following information:
    - Width: **150**
    - Height: **190**
    - Background style: **Solid color brush**
    - Background R: **150**
    - Background G: **175**
    - Background B: **207**

7. Select the canvas and drag a label on to it. Place it in the left-hand corner of the canvas and set its properties by using the following information:
    - Content: **Title**

8. Select the canvas, and drag a label on to it. Place it in the canvas below the previous label and set its properties by using the following information:
    - Content: **By: Owner**

9. Select the canvas and drag an image on to it. Place it on the canvas below the previous label and set its properties by using the following information:
    - Source: **photo.jpg**
    - Width: **100**
    - Height: **100**

10. Select the canvas and drag a label on to it. Place it on the canvas below the image and set its properties by using the following information:
    - Content: **Created On: Date**

11. Copy the canvas that contains the image.

12. Paste the canvas on the right-hand side of the copied canvas.

    >**Note**: Notice that the pasted canvas may cover the original canvas.

13. Paste another canvas below the last pasted canvas.

    >**Note**: Notice that the pasted canvas may cover the original canvas.

14. Paste another canvas to the left-hand side of the last pasted canvas.

15. Save all changes.

>**Results**: After completing this exercise, you will create proposals for views and their layouts.

### Exercise 4: Architecting an MVC Web Application

#### Scenario

You need to recommend a web server and database server configuration that is required to implement a photo sharing application. You will propose details based on the results of an initial investigation into the requirements.

The main tasks for this exercise are as follows:

1. Hosting options.

2. Choosing a data store.

#### Task 1: Hosting options

1. Based on your reading of the **DetailedPlanningDocument** document, add a description of the web server arrangements by using the following information:

    - Description: **The author recommends using Microsoft Azure to host the Photo Sharing application. Microsoft Azure can host any ASP.NET website, including the ASP.NET Core MVC application proposed in this document. Scaling is very simple because Microsoft, not Adventure Works, is responsible for adding server resources at times of high traffic. Costs are minimal: they depend on the amount of data served to visitors but it is not necessary to maintain our own hardware.**

#### Task 2: Choosing a data store

1. Based on your reading of the **DetailedPlanningDocument** document, add a description of the database server arrangements by using the following information:

    - Description: **DetailedPlanningDocument(docx) - Microsoft Word** window, type **The author recommends using SQL Database, within Microsoft Azure, to host the Photo Sharing application underlying database. As for the web server, this recommendation ensures high-availability hosting for the database with good value for money. This makes particular sense if the web site is hosted in Microsoft Azure.**

2. Close the **DetailedPlanningDocument** document.

3. In the **Microsoft Word** dialog box, click **Save** to save the changes.


>**Results**: After completing this exercise, you will be able to create proposals for hosting arrangements.

©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
