# Module 8: Using Layouts, CSS and JavaScript in ASP.NET Core MVC

# Lab: Using Layouts, CSS and JavaScript in ASP.NET Core

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps
1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. (https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)

### Exercise 1: Applying a Layout and Link Views to it 

#### Task 1: Create a layout
1. From **Allfiles\Mod08\Labfiles\01_Zoo_begin** open the **Zoo.sln**.

2. Create a new folder with the following information:

   - Parent folder: **Views**
   - Folder name: **Shared**

3. Add a new **Razor Layout** by using the following information:

	- Folder: **/Views/Shared**
	- Name: **_Layout**	

4. In the **_Layout.cshtml** file, in the **BODY** element, add a **UL** element with the following information:

	- Class:**nav**

5. In the **UL** element, add a **LI** element.

6. In the **LI** element, add an **A** element with the following information:

	- Href: **@Url.Action("Index", "Zoo")"**
	- Content: **Attractions**

7. After the **LI** element, add a **LI** element.

8. In the last **LI** element, add an **A** element with the following information:

	- Href: **@Url.Action("VisitorDetails", "Zoo")"**
	- Content: **Visitor Info**

9. After the last **LI** element, add a **LI** element.

10. In the last **LI** element, add an **A** element with the following information:

	- Href: **@Url.Action("BuyTickets", "Zoo")"**
	- Content: **Tickets**

11. After the **UL** element, add a **DIV** element with the following information:

	- Class:**header-container**

12. In the **DIV** element, add an **H1** element with the following information:

	- Class:**content**
	- Content: **Welcome to Zoo Center**

13. After the **H1** element, add a **DIV** element with the following information:

	- Class:**slider-buttons**

14. In the **DIV** element, add a **IMG** element with the following information:

	- Class:**prev**
    - Src: **~/images/prevArrow.png**
    - Onclick: **prevImage()**


15. Afteer the **IMG** element, add a **IMG** element with the following information:

	- Class:**next**
    - Src: **~/images/nextArrow.png**
    - Onclick: **nextImage()**


#### Task 2: Add a view and link it to a layout

1. In the **ZooSiteController** class, right-click on the **Index** action name, and then click **Add View**. 

2. Create a new view using the **Add MVC View** dialog box, with the following information:

    - View Name: **Index**
    - Template: **Empty (without model)**
    - Create as Partial View: **False**
    - Use a layout page: **True**
    - Layout Page: **_Layout.cshtml**

3. Delete the contents of the **Index.cshtml** view.

4. Add a **@model** directive with the following information:

   - Type: **IEnumerable&lt;Zoo.Models.Photo&gt;**

5.  Add a **H1** element with the following information:

	- Class:**main-title**
    - Content: **Zoo Attractions**

6.  Add a **DIV** element with the following information:

	- Class:**container**

7. In the **DIV** element, create a **FOREACH** statement, with the following information:

	- Variable Type: **var**
	- Variable Name: **item**
	- Collection: **Model**

8. In the **FOREACH** statement block, create an **IF** statement that checks that the value of **item.PhotoFileName** is not **NULL**.

9. In the **IF** statement, add a **DIV** element with the following information:

	- Class:**image-wrapper**

10. In the **DIV** element, add a **IMG** element with the following information:

	- Class:**photo-display-img**
    - Src: **@Url.Action("GetImage", "Zoo", new { PhotoId = item.PhotoID })**

11. After the **IF** statement, add a **H3** element with the following information:

	- Class:**display-picture-title**
    - Content: **@Html.DisplayFor(modelItem  => item.Title)**

12. Add a **DIV** element.

13. In the **DIV** element, add a **SPAN** element with the following information:

	- Class:**display**
    - Content: **@Html.DisplayFor(model => item.Description)**

#### Task 3: Add _ViewStart.cshtml

1. Create a new **Razor View Start** file, with the following information:

    - Name: **_ViewStart**
    - Folder: **Views**

2. At the beginning of the **Index.cshtml** view, remove the the **Layout** initialization.

#### Task 4: Add existing views to the layout

1. Copy the exiting **Views** to the **Zoo** project, with the following information:

    - Source location: **Allfiles\Mod08\Labfiles\ZooViews**
	- Target location: **Allfiles\Mod08\Labfiles\01_Zoo_begin\Zoo\Views**


#### Task 5: Add sections to layout and views

1. In the **_Layout.cshtml** file, after the **DIV** element with **@RenderBody()** content, call the **RenderSection** method. 

2. Pass **"Scripts"** and **required: false** as parameters to the **RenderSection** method.


#### Task 6: Run the application

1. Save all the changes.

2. Start debugging the application.

3. In the menu bar, click **Visitor Info**.

4. In the menu bar, click **Tickets**.

5. Close the **Microsoft Edge** window.

6. Stop Debugging.

### Exercise 2: Using CSS 

#### Task 1: Add existing CSS file to the project

1. Create a new folder with the following information:

	- Folder name: **css**
	- Parent folder: **wwwroot**

2. Copy the **zoo-style.css*** file to the **Zoo** project, with the following information:

	- Source location: **Allfiles\Mod08\Labfiles\ZooCSS**
	- Target location: **Allfiles\Mod08\Labfiles\01_Zoo_begin\Zoo\wwwroot\css**

#### Task 2: Link the layout to the CSS file

1. In the **_Layout.cshtml** file, in the **HEAD** element, add a **LINK** element with the following information:

	- Type: **text/css**
	- Rel: **stylesheet**
	- Href: **css/zoo-style..css**

2. In the **zoo-style.css** file, after the **.slider-buttons img** selector code block, add a **.nav** selector with the following information:

	- Properties:
		- list-style-type: **text/css**
		- Rel: **stylesheet**
		- Href: **css/zoo-style..css**


#### Task 3: Style the menu

#### Task 4: Style the RenderBody section

#### Task 5: Style the form




### Exercise 3: Using JavaScript

#### Task 1: Add a JavaScript file

#### Task 2: Link a view to the JavaScript file

#### Task 3: Write the code of the JavaScript file

### Exercise 4: Using jQuery

#### Task 1: Use NPM to add jQuery

#### Task 2: Use jQuery to add event handlers

#### Task 3: Use jQuery to modify an element with a particular id

#### Task 4: Use jQuery to change a style

#### Task 5: Client-side validation using jQuery

#### Task 6: Run the application