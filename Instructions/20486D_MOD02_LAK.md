# Module 2: Designing ASP.NET Core MVC Web Applications

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**.

# Lab: Designing ASP.NET Core MVC Web Applications

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for the labs and demos in this course. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

### Exercise 1: Planning Model Classes

#### Task 1: Examine the initial investigation

1. Go to **[Repository Root]\Allfiles\Mod02\Labfiles\01_DesignProject_begin** and double-click **InitialInvestigation.docx**.

2. In the **InitialInvestigation - Microsoft Word** window, in the **View** tab, in the **Show** section, ensure that the **Navigation Pane** check box is selected.

3. In the **Navigation** pane, click **Introduction** and read the content.

4. In the **Navigation** pane, click **General Description of the Photo Sharing Web Application** and read the content.

5. In the **Navigation** pane, click **Use Cases** and read the content.

6. In the **InitialInvestigation - Microsoft Word** window, review **Figure 1: Use Case Summary**.

7. In the **InitialInvestigation - Microsoft Word** window, click **Close**.


#### Task 2: Plan the photo model class

1. On the taskbar, click **File Explorer**.

2. In the **[Repository Root]\Allfiles\Mod02\Labfiles\01_DesignProject_begin** window, double-click **DetailedPlanningDocument.docx**.

3. In the **DetailedPlanningDocument - Microsoft Word** window, locate the **MVC Model** section.

4. In the **MVC Model** section, locate **Table 1: MVC Model**.

5. In **Table 1: MVC Model**, in row 1, in the **Model Class** column, type **Photo**.

6. In row 1, in the **Description** column, type **The photo model class represents a photo that authenticated users can upload to the website.**

7. In row 1, in the **Properties** column, type **PhotoID**.

8. In row 1, in the **Data Types** column, type **Integer**.

9. In row 2, in the **Properties** column, type **Title**.

10. In row 2, in the **Data Types** column, type **String**.

11. In row 3, in the **Properties** column, type **PhotoFile**.

12. In row 3, at the **Data Types** column, type **Binary**.

13. In row 4, in the **Properties** column, type **Description**.

14. In row 4, in the **Data Types** column, type **String**.

15. In row 5, in the **Properties** column, type **CreatedDate**.

16. In row 5, in the **Data Types** column, type **DateTime**.

17. In row 6, in the **Properties** column, type **Owner**.

18. In row 6, in the **Data Types** column, type **Integer**.

19. In **Table 1: MVC Model**, in the **Model Class** column, select cells 1 to 6, right-click, and then select **Merge Cells**.

20. In **Table 1: MVC Model**, in the **Description** column, select cells 1 to 6, right-click, and then select **Merge Cells**.

    >**Note**: Keep the **DetailedPlanningDocument - Microsoft Word** window open for future tasks in this lab.

21. Start Microsoft Visual Studio 2017.

22.	In the **Start Page - Microsoft Visual Studio** window, on the **File** menu, point to **New**, and then click **Project**.

23.	In the **New Project** dialog box, in the navigation pane, expand **Installed**, and then click **Visual C#**.

24.	In the **New Project** dialog box, in the result pane, click **WPF App (.NET Framework)**.

25.	In the **Name** box, type **DesignProject**.	

26. In the **Location** box, ensure that the location specified is **[Repository Root]\Allfiles\Mod02\Labfiles**, and then click **OK**.

27. In the **DesignProject - Microsoft Visual Studio** window, in Solution Explorer, right-click **DesignProject**, point to **Add**, and then select **New Item**.

28. In the **Add New Item - DesignProject** dialog box, in the navigation pane, expand **Installed**, expand **Visual C#**, and then click **General**.

29. In the **Add New Item - DesignProject** dialog box, in the **General** category, click **Class Diagram**.

30. In the **Add New Item - DesignProject** dialog box, in the **Name** box, type **ModelDesign**, and then click **Add**.
 
31. If the **Toolbox** window is not open, click **View**, and then click **Toolbox**.

32. In the **Toolbox** window, expand **Class Designer**, and then drag **Class** into the code window.

33. In the **New Class** dialog box, in the **Class name** box, type **Photo**, and then click **OK**.

34. In Solution Explorer, Double-click **ModelDesign.cd**. 

35. Right-click the **Photo** class, select **Add**, select **Property**, and name it **PhotoID**.

36. Right-click the **Photo** class, select **Add**, select **Property**, and name it **Title**.

37. Right-click the **Title** property, and then select **Class Details**.

    >**Note**: Notice that a class details window opens. Also notice that, by default, the **PhotoID** property is set to **int**.

38. On the **Class Details - Photo** tab, under the **properties** header, verify that the **Title** property is selected.

39. Under the **Type** column, locate **int**, and change it to **string**.

40. Right-click the **Photo** class, select **Add**, select **Property**, and name it **PhotoFile**.

41. On the **Class Details - Photo** pane, under the **properties** header, locate the **PhotoFile** property, and then in the **Type** column, select **byte**.

42. Right-click the **Photo** class, click **Add**, click **Property**, and name it **Description**.

43. On the **Class Details - Photo** pane, double-click the **Description** property, and then in the **Type** column, select **string**.

44. Right-click the **Photo** class, select **Add**, select **Property**, and name it **CreatedDate**.

45. On the **Class Details - Photo** pane, locate the **CreatedDate** property, and then in the **Type** column, select **DateTime**.

46. Right-click the **Photo** class, select **Add**, select **Property**, and name it **Owner**.

47. On the **Class Details - Photo** pane, locate the **Owner** property, and then in the **Type** column, select **string**.
    >**Note**: Keep the **DesignProject – Microsoft Visual Studio** window open for future tasks in this lab.

48. In **Solution Explorer**, click **Photo.cs**.

49. In the **Title** property code block, select the following code:
```cs
    get => default(int);
```

50. Replace the selected code with the following code:
```cs
    get => default(string);
```

51. Within the **PhotoFile** property code block, select the following code:
```cs
    get => default(int);
```

52. Replace the selected code with the following code:
```cs
    get => default(byte);
```

53. Within the **Description** property code block, select the following code:
```cs
    get => default(int);
```

54. Replace the selected code with the following code:
```cs
    get => default(string);
```

55. Within the **CreatedDate** property code block, select the following code:
```cs
    get => default(int);
```

56. Replace the selected code with the following code:
```cs
    get => default(System.DateTime);
```

57. Within the **Owner** property code block, select the following code:
```cs
    get => default(int);
```

58. Replace the selected code with the following code:
```cs
    get => default(string);
```

#### Task 3: Plan the comment model class

1. On the taskbar, click **DetailedPlanningDocument - Microsoft Word**.

2. In the **DetailedPlanningDocument - Microsoft Word** window, locate the **MVC Model** section.

3. In the **DetailedPlanningDocument - Microsoft Word** window, locate the **Table 1: MVC Model** table.

4. In **Table 1: MVC Model**, in row 7, in the **Model Class** column, type **Comment**.

5. In row 7, in the **Description** column, type **The comment model class represents a comment that authenticated users can add to photos. This enables users to discuss others’ photos. Each comment is associated with just one photo.**

6. In row 7, in the **Properties** column, type **CommentID**.

7. In row 7, in the **Data Types** column, type **Integer**.

8. In row 8, in the **Properties** column, type **User**.

9. In row 8, in the **Data Types** column, type **String**.

10. In row 9, in the **Properties** column, type **Subject**.

11. In row 9, in the **Data Types** column, type **String**.

12. In row 10, in the **Properties** column, type **Body**.

13. In row 10, in the **Data Types** column, type **String**.

14. In row 11, in the **Properties** column, type **PhotoID**.

15. In row 11, in the **Data Types** column, type **Integer**.

16. In **Table 1: MVC Model**, in the **Model Class** column, select cells 7 to 11, right-click, and then select **Merge Cells**.

17. In **Table 1: MVC Model**, in the **Description** column, select cells 7 to 11, right-click, and then select **Merge Cells**.

19. On the taskbar, click **DesignProject – Microsoft Visual Studio**.

20. On the **FILE** menu of the **DesignProject - Microsoft Visual Studio** window, click **Save All**.

21. From the toolbox, drag another class into the **Class Designer** window.

22. In the new window that opened, click the **Class name** box, type **Comment**, and then click **OK**.

23. In the **Toolbox** window, from the **Class Designer** list, click the **Association** type from the toolbox, click on the **Photo** class, and then click the **Comment** class.

24. Double-click the text box representing the association name that is displayed near the association arrow, change the value to **PhotoComments**, and then press Enter to finish.

25. In **Solution Explorer** pane, click **Photo.cs**.

26. Select the following code:
```cs
    public Comment PhotoComments
```

27. Replace the selected code with the following code: 
```cs
    public List<Comment> PhotoComments
```

28. Select the following code:
```cs
    get => default(Comment);
```

29. Replace the selected code with the following code:
```cs
    get => default(List<Comment>);
```

30. In **Solution Explorer**, Double-click **ModelDesign.cd**.

    >**Note**: Notice there is a **PhotoComments** property under the **Photo** class. There is no association between the **Photo** and **Comment** classes.

31. Right-click the **PhotoComments** property, and then select **Show as collection association**.

    >**Note**: See that the association has two arrowheads instead of one. It is a collection association between the **Photo** class and the **Comment** class. This indicates that the **Photo** class has a **PhotoComments** property that contains a collection of **Comment** objects.

32. In the **Class Designer** window, right-click the **Comment** class, select **Add**, select **Property**, and then name it **CommentID**.

33. In the **Class Designer** window, right-click the **Comment** class, select **Add**, then select **Property**, and then name it **User**.

34. On the **Class Details - Comment** pane of the **Comment** class, find the **User** property, and in the corresponding **Type** box, type **string**.

35. In the **Class Designer** window, right-click the **Comment** class, select **Add**, select **Property**, and then name it **Subject**.

36. On the **Class Details - Comment** pane of the **Comment** class, find the **Subject** property, and then corresponding **Type** box, type **string**.

37. In the **Class Designer** window, right-click the **Comment** class, select **Add**, select **Property**, and then name it **Body**.

38. On the **Class Details - Comment** pane of the **Comment** class, find the **Body** property, and in the corresponding **Type** box, type **string**.

39. In the **Class Designer** window, right-click the **Comment** class, select **Add**, select **Property**, and then name it **PhotoID**.

40. In **Solution Explorer**, click **Comment.cs**.

41. Within the **User** property code block, select the following code:
```cs
    get => default(int);
```

42. Replace the selected code with the following code:
```cs
    get => default(string);
```

43. Within the **Subject** property code block, select the following code:
```cs
    get => default(int);
```

44. Replace the selected code with the following code:
```cs
    get => default(string);
```

45. Within the **Body** property code block, select the following code:
```cs
    get => default(int);
```

46. Replace the selected code with the following code:
```cs
    get => default(string);
```

47. On the **FILE** menu of the **DesignProject - Microsoft Visual Studio** window, click **Save All**.
    

>**Results**: After completing this exercise, you will be able to create proposals for a model and configure the properties and data types of the model classes.

### Exercise 2: Planning Controllers

#### Task 1: Plan the photo controller

1. On the taskbar, click **DetailedPlanningDocument - Microsoft Word**.

2. In the **DetailedPlanningDocument - Microsoft Word** window, locate the **MVC Controllers** section.

3. In the **DetailedPlanning Document - Microsoft Word** window, locate **Table 2: MVC Controllers**.

4. In **Table 2: MVC Controllers**, in row 1, in the **Controller** column, type **PhotoController**.

5. In row 1, in the **Action** column, type **DisplayGallery (GET)**.

6. In row 1, in the **Description** column, type **The action runs when the user requests the Photo Gallery page. The action obtains all the photos from the database and passes them to the DisplayGallery view.**

7. In row 2, in the **Action** column, type **DisplayRecent (GET)**.

8. In row 2, in the **Description** column, type **This action is similar to the DisplayGallery action except that only the most recent photos are obtained from the database. This smaller collection of photos is passed to the DisplayGallery view.**

9. In row 3, in the **Action** column, type **DisplayPhoto (GET)**.

10. In row 3, in the **Description** column, type **This action runs when the user clicks a photo's “Details” link in a gallery. The action obtains full details of a single photo from the database and passes it to the DisplayPhoto view.**

11. In row 4, in the **Action** column, type **AddPhoto (GET)**.

12. In row 4, in the **Description** column, type **This action runs when the user clicks the “Add a Photo” link. The action creates a new instance of the Photo model class and passes it to the AddPhoto view.** 

13. In row 5, in the **Action** column, type **AddPhoto (POST)**.

14. In row 5, in the **Description** column, type **This action runs when the user clicks “Save” in the AddPhoto view. The action saves the file and details of the new photo to the database and redirects the user to the DisplayGallery view.** 

15. In row 6, in the **Action** column, type **DeletePhoto (GET)**.

16. In row 6, in the **Description** column, type **This action runs when the user clicks a “Delete this Photo” link in the DisplayPhoto view. The action displays the DeletePhoto view, which requests confirmation for the deletion.**

17. In row 7, in the **Action** column, type **DeletePhoto (POST)**.

18. In row 7, in the **Description** column, type **This action runs when the user clicks “Delete” in the DeletePhoto view. The action deletes the current photo, with its associated comments from the database and redirects the user to the DisplayGallery view.** 

19. In **Table 2: MVC Controllers**, in the **Controller** column, select cells 1 to 7, right-click, and then select **Merge Cells**.

#### Task 2: Plan the comment controller

1. In the **Table 2: MVC Controllers** table, in the **Controller** column, in row 8, below **PhotoController**, type **CommentController**.

2. In **Table 2: MVC Controllers**, in row 8, in the **Action** column, type **DisplayComments (GET)**.

3. In row 8, in the **Description** column, type **This action runs when the DisplayPhoto view is displayed. The action requires the current PhotoID as a parameter and uses it to get all the comments for the current photo from the database. The action returns the _DisplayComments partial view.**

4. In row 9, in the **Action** column, type **AddComment (GET)**.

5. In row 9, in the **Description** column, type **This action runs when the user clicks the “Add a Comment” link in the DisplayPhoto view. The action creates a new instance of the Comment model class and sets its PhotoID to be the ID of the current photo. It passes this new comment to the AddComment view.**

6. In row 10, in the **Action** column, type **AddComment (POST)**.

7. In row 10, in the **Description** column, type **This action runs when the user clicks “Submit” in the AddComment view. The action saves the details of the new comment in the database and redirects the user to the DisplayPhoto view.**

8. In **Table 2: MVC Controllers**, in the **Controller** column, select cells 8 to 10, right-click, and then select **Merge Cells**.

9. On the **FILE** menu of the **DetailedPlanningDocument - Word** window, click **Save**.

>**Results**: After completing this exercise, you will be able to create proposals for controllers and configure their properties and data types.

### Exercise 3: Planning Views

#### Task 1: Define the views

1. On the taskbar, click **DetailedPlanningDocument - Microsoft Word**.

2. In the **DetailedPlanningDocument - Microsoft Word** window, locate **MVC Views** section, and then locate **Table 3: MVC Views**.

3. In row 1, in the **Controller** column, type **PhotoController**.

4. In row 1, in the **View** column, type **DisplayGallery**.

5. In row 1, in the **Description** column, type **This view displays a collection of photos in the thumbnail size. For each photo the Title, Owner, and Created Date values are displayed.**

6. In row 2, in the **View** column, type **DisplayPhoto**.

7. In row 2, in the **Description** column, type **This view displays a single photo in full size. The Title and Owner values appear above the photo. The Photo Name, Description, and other values appear beneath the photo. Under these details, all the comments for the current photo are listed with an “Add a Comment” link.**.

8. In row 3, in the **View** column, type **AddPhoto**.

9. In row 3, in the **Description** column, type **This view displays a form that the user can use to upload and describe a new photo.**

10. In row 4, in the **View** column, type **DeletePhoto**.

11. In row 4, in the **Description** column, type **This view displays a form that the user can use to confirm the deletion of a photo. The view displays details of the current photo such as its title and description.**

12. In **Table 3: MVC Views**, in the **Controller** column, select cells 1 to 4, right-click, and then select **Merge Cells**.

13. In row 5, in the **Controller** column, type **CommentController**.

14. In row 5, in the **View** column, type **DisplayComments**.

15. In row 5, in the **Description** column, type **This partial view, which is used on the DisplayPhoto form, displays all the comments associated with the current photo.**

16. In row 6, in the **View** column, type **AddComment**.

17. In row 6, in the **Description** column, type **This view displays a form that the user can use to create a new comment for a photo.**

18. In **Table 3: MVC Views**, in the **Controller** column, select cells 5 to 6, right-click, and then select **Merge Cells**.

19. In the **DetailedPlanningDocument - Word** window, in the **FILE** menu, click **Save**.

#### Task 2: Design the single photo view

1. On the taskbar, click **DesignProject – Microsoft Visual Studio**.

2. In the **DesignProject - Microsoft Visual Studio** window, in Solution Explorer, right-click **DesignProject**, point to **Add**, and then select **New Item**.

3. In the **Add New Item – DesignProject** dialog box, click **Window (WPF)**.

4. In the **Add New Item – DesignProject** dialog box, in the **Name** box, type **SinglePhotoView**, and then click **Add**.

5. In the **DesignProject - Microsoft Visual Studio** window, on the **View** menu, click **Properties Window**.

6. In the **DesignProject - Microsoft Visual Studio** window, on the **View** menu, point to **Other Windows**, and then click **Document Outline**.

7. In **Document Outline** window, click the **[Window]** row.

8. In the **Properties** window, below the **Type** box, set **Arrange By** to **Category**.

9. In the **Properties** window, expand the **Layout** category.

10. In the **Width** box, type **500** and in the **Height** box, type **1100**.

11. In the **Properties** window, under the **Appearance** category, change the **WindowStyle** to **None**.

12. From the toolbox, drag a label into the main window below the top left-hand side corner.

13. In the **Properties** window, under the **Common** category,  change the box value near the **Content** box to **Adventure Works Photo Sharing**.

14. In the **Properties** window, under the **Text** category, change the text size to **20 px**.

15. From the toolbox, drag a canvas into the main window below the label. (Align it with the left-hand side of the label).

16. In the **Properties** window, under the **Brush** category, click the **Background** text to select this line.

17. Below the **Background** line, there are five tabs. Place the mouse pointer on a tab to see its name.

18. Click the **Solid color brush** tab. Ensure that the **background** line is still selected.

19. Next to the color picker box, there are four text boxes.

20. In the **R** box, type **150**.

21. In the **G** box, type **175**.

22. In the **B** box, type **207**.

23. Under the **Layout** category, in the **Width** box, type **400**.

24. Under the **Layout** category, in the **Height** box, type **40**.

25. Verify that the canvas is selected, from the toolbox, drag a button to the left-hand side of the canvas.

26. In the **Properties** window, under the **Common** category, change the value in the **Content**box to **Home**.

27. Under the **Brush** category, click the **Background** text to select this line.

28. Below the **Background** line, next to the color picker box, there are four text boxes.

29. In the **R** box, type **31**.

30. In the **G** box, type **71**.

31. In the **B** box, type **125**.

32. Under the **Brush** category, click the **Foreground** text to select this line.

33. Below the **Foreground** line, next to the color picker box, there are four text boxes.

34. In the **R** box, type **255**.

35. In the **G** box, type **255**.

36. In the **B** box, type **255**.

37. Copy the button and paste it. It will appear over the current button. Move it to the right-hand side of the current button.

38. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Gallery**.

39. Copy the button and paste it. It will appear just over the current button. Move it to the right-hand side of the current button.

40. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Add a Photo**.

41. Copy the button and paste it. It will appear just over the current button. Move it to the right-hand side of the current button.

42. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Slideshow**.

43. From the toolbox, drag a label into the top left-hand side corner below the last canvas you pasted.

44. In the **Properties** window, under the **Common** category, change the value of the **Content** box to  **Title**.

45. In the **Properties** window, under the **Text** category, change the value of the text size box to  **20 px**.

46. From the toolbox, drag another label into the main window below the previous label.

47. In the **Properties** window, under the **Common** category, change the value of the **Content** box to  **By: Owner**.

48. In the **DesignProject – Microsoft Visual Studio** window, in Solution Explorer, right-click the **DesignProject** project file, point to **Add**, and then select **Existing item**.
    
49. In the **Add Existing Item – DesignProject** dialog box, in the file type list, select **All Files(_*_.*)**, go to the following path **[Repository Root]\Allfiles\Mod02\Labfiles\01\_DesignProject\_begin**, select the **photo.jpg** file, and then click **Add**.

50. From the toolbox, drag an image into the main window below the previous label.

51. In the **Properties** window, under the **Common** category, change the value of the **Source** box to **photo.jpg**, and then press Enter.

52. Under the **Layout** category, in the **Width** box, type **400**.

53. Under the **Layout** category, in the **Height** box, type **240**.

54. From the toolbox, drag another label into the main window below the left-hand side of the image.

55. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Description**.

56. From the toolbox, drag another label into the main window below the other label you just added.

57. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Photo Description...**.

58. Under the **Layout** category, click the **Width** box, and type **300**.

59. Under the **Layout** category, click the **Height** box, and type **150**.

60. In the **Properties** window, under the **Brush** category, click the **BorderBrush** text to select this line.

61. Below the **BorderBrush** line, there are five tabs. Place the mouse pointer on a tab to see its name.

62. Click the **Solid color brush** tab. Ensure that the **BorderBrush** line is still selected.

63. Next to the color picker, there are four text boxes.

64. In the **R** box, type **150**.

65. In the **G** box, type **175**.

66. In the **B** box, type **207**.

67. In the **Appearance** category, click the arrow pointing down. Near **Border Thickness**, there are four text boxes. Type **2** in each of them.

68. From the toolbox, drag another label into the main window below the left-hand side of the **Photo Description** label.

69. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Comments:**.

70. From the toolbox, drag a canvas into the main window below the last added label.

71. Align the left-hand side of the canvas to left-hand side of the **Photo Description** label.

72. In the **Properties** window, under the **Brush** category, click the **Background** text to select this line.

73. Below the **Background** line, there are five tabs. Place the mouse pointer on a tab see its name.

74. Click the **Solid color brush** tab. Ensure that the **Background** line is still selected.

75. Next to the color picker, there are four text boxes.

76. In the **R** box, type **150**.

77. In the **G** box, type **175**.

78. In the **B** box, type **207**.

79. Under the **Layout** category, click **Width** and type **300**.

80. Under the **Layout** category, click **Height** and type **130**.

81. Verify that the canvas is selected, from the toolbox, drag a label to the top left-hand side of the canvas.

82. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **From:**.

83. Verify that the canvas is selected, from the toolbox, drag a label on to the canvas, and then place the new label below the previous label.

84. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Subject:**.

85. Verify that the canvas is selected, from the toolbox, drag a label on to the canvas, and then place the new label below the previous label.

86. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Body:**.

87. Copy the canvas and paste it below the last copied canvas.

88. From the toolbox, drag a TextBlock into the main window under the last copied canvas.

89. In the **Properties** window, under the **Common** category, change the value of the **Text** box to **Add a Comment**.

90. In the **Properties** window, under the **Brush** category, click the **Foreground** text to select this line.

91. Below the **Foreground** line, there are five tabs. Place the mouse pointer on a tab to see its name.

92. Click the **Solid color brush** tab. Ensure that the **Foreground** line is still selected.

93. Next to the color picker, there are four text boxes.

94. In the **R** box, type **0**.

95. In the **G** box, type **0**.

96. In the **B** box, type **255**.

97. Under the **Text** category, there is a **U** letter button with an underline below it, click this button.

98. In the **DesignProject - Microsoft Visual Studio** window, in the **FILE** menu, click **Save All**. 

#### Task 3: Design the gallery view

1. In the **DesignProject - Microsoft Visual Studio** window, in Solution Explorer, right-click **DesignProject**, point to **Add**, and then select **Window**.

2.	In the **Add New Item – DesignProject** dialog box, click **Window (WPF)**, in the **Name** box, type **PhotoGalleryView**, and then click **Add**.

3. In the **Document Outline** window, click the **[Window]** row.

4. In the **Properties** window, verify that near the **Type** text, the word **Window** is shown.

5. Under the **Layout** category, click **Width**, and type **500**.

6. Under the **Layout** category, click **Height**, and type **600**.

7. In the **Properties** window, under the **Appearance** category, change the **WindowStyle** to **None**.

8. From the toolbox, drag a label to the top left-hand side corner of the **Class Designer** window.

9. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Adventure Works Photo Sharing**.

10. In the **Properties** window, under the **Text** category, change the text size to **20 px**.

11. In Solution Explorer, click **SinglePhotoView.xaml**.

12. In the **Class Designer** window, right-click the top canvas, and then select **Copy**.

13. In Solution Explorer, click **PhotoGalleryView.xaml**. 

14. In the **Class Designer** window, in the designed window, right-click an empty area, and then click **Paste**.

15. From the toolbox window, drag another canvas, and place it below the previous canvas, over the left-hand side of the window. 

16. In the **Properties** window, under the **Brush** category, click in the **Background** text to select this line.

17. Below the **Background** line, there are five tabs. Place the mouse pointer over a tab to see its name.

18. Click the **Solid color brush** tab. Ensure that the **Background** line is still selected.

19. Next to the color picker box, there are four text boxes.

20. In the **R** box, type **150**.

21. In the **G** box, type **175**.

22. In the **B** box, type**207**.

23. Under the **Layout** category, in the **Width** box, type **150**.

24. Under the **Layout** category, in the **Height** box, type **190**.

25. Verify that the last created canvas is selected, from the toolbox, drag a label on to the canvas, and place the new label in the top left-hand corner of the canvas.

26. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Title**.

27. Verify that the last created canvas is selected, from the toolbox, drag a label on to the canvas, and place the new label in the top left-hand corner of the canvas.

28. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **By: Owner**.

29. Verify that the canvas is selected, from the toolbox, drag an image into the canvas and place the image below the labels.

30. In the **Properties** window, under the **Common** category, change the value of the **Source** box to **photo.jpg**, and press Enter.

31. Under the **Layout** category, in the **Width** box, type **100**.

32. Under the **Layout** category, in the **Height** box, type **100**.

33. Verify that the canvas is selected, from the toolbox, drag a label into the canvas and place the new label below the image.

34. In the **Properties** window, under the **Common** category, change the value of the **Content** box to **Created On: Date**.

35. Right-click the last created canvas, and select **Copy**.

36. In the **Class Designer** window, in the designed window, right-click an empty area, and then select **Paste**.    
>**Note**: Notice that the pasted canvas may cover the original canvas.

37. Move the pasted canvas to the right-hand side of the original canvas.

38.  In the **Class Designer** window, in the designed window, right-click an empty area, and then select **Paste**.    
>**Note**: Notice that the pasted canvas may cover the original canvas.

39. Move the pasted canvas below the previously pasted canvas.

40. In the **Class Designer** window, in the designed window, right-click an empty area, and then select **Paste**.    
>**Note**: Notice that the pasted canvas may cover the original canvas.

41. Move the pasted canvas to the left-hand side of the last pasted canvas.

42. In the **DesignProject - Microsoft Visual Studio** window, in the **FILE** menu, click **Save All**.

>**Results**: After completing this exercise, you will create proposals for views and their layouts.

### Exercise 4: Architecting an MVC Web Application

#### Task 1: Hosting option

1. On the taskbar, click the **DetailedPlanningDocument - Microsoft Word** icon.

2. In the **DetailedPlanningDocument - Microsoft Word** window, locate the **Hosting Recommendations** section, and then locate the **Web Server** section.

3. Under **Web Server**, type **The author recommends using Microsoft Azure to host the Photo Sharing application. Microsoft Azure can host any ASP.NET website, including the ASP.NET Core MVC application proposed in this document. Scaling is very simple because Microsoft, not Adventure Works, is responsible for adding server resources at times of high traffic. Costs are minimal: they depend on the amount of data served to visitors but it is not necessary to maintain our own hardware.**

#### Task 2: Choose a data store

1. In the **DetailedPlanningDocument - Microsoft Word** window, in the **Database** section, type **The author recommends using SQL Database, within Microsoft Azure, to host the Photo Sharing application underlying database. As for the web server, this recommendation ensures high-availability hosting for the database with good value for money.  This makes particular sense if the web site is hosted in Microsoft Azure.**

2. In the **DetailedPlanningDocument - Microsoft Word** window, click **Close**. 

3. In **Microsoft word** dialogue box, click **Save** to save the changes.

>**Results**: After completing this exercise, you will be able to create proposals for hosting arrangements.

©2016 Microsoft Corporation. All rights reserved.
The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.
This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.

