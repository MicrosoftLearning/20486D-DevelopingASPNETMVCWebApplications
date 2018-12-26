# Module 14: Hosting and Deployment

# Lab: Hosting and Deployment

#### Scenario

You have been asked to create a web-based aquarium management application for your organization's customers, and deploy this application to Microsoft Azure using AppService. The application should consits of a page showing all the different variety of fish in the aquarium, and should allow the user to edit the details of a fish, and delete a fish.

#### Objectives

After completing this lab, you will be able to:

- Create App Service in Microsoft Azure
- Deploy your application to Microsoft Azure
- Work with Azure SQL database.


#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Open the **Command Prompt** window using **Run as administrator**.

3. In Administrator: Command Prompt, run the following command: **cd &lt;The location of  Allfiles\Mod14\Labfiles\01_Underwater_begin\Underwater folder on your machine&gt;**.

4. Run the following command: **npm install**.

5. Close the **Command Prompt** window. 

### Exercise 1: Deploying a Web Application to Microsoft Azure

#### Scenario

In this exercise, you will first build and run a simple web application locally. For this you will run migrations for your local db. You will then create an AppService and SQL database in Microsoft Azure. You will configure your application to use the Azure SQL database. You will populate the database using Migrations. After that you will deploy your application to Microsoft Azure. 

The main tasks for this exercise are as follows:

1.	Explore and run the application locally.

2.	Create a new Web App in Microsoft Azure.

3.	Prepare the application for deployment.

4.	Deploy the application.

5.	Run the application in Microsoft Azure.


#### Task 1: Explore and run the application locally

1. Open the **UnderWater.sln** solution from the following location: **Allfiles\Mod14\Labfiles\01_Underwater_begin**. 

2. Open the **Package Manager Console** window.

3. In the **Package Manager Console**, run the following command: **Add-Migration InitialCreate**.

4. Run the following command: **Update-Database**.

5. Start the application without debugging

6. In the menu bar, click **Add Fish**.

7. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Picture:  **_&lt;go to Allfiles\Mod14\Labfiles\Images, and click koi.jpg&gt;_**


8. Click **Add**

9. On the **Dive into Our Fish Species** page, verify the newly submitted details.

10. Select a fish of your choice, and then click **Details**.

    >**Note:** The browser displays the scientific name of the fish. 

11. Verify the fish details, and then click **Back**.

12.  On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

13. On the **Edit Fish** page, in the **Scientic Name** text box, type **_&lt;A scientific name of your choice>&gt;_**, and then click **Save**.

14. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

15. Verify the newly edited details, and then click **Back**.

16. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

17. On the **Fish Delete** page, click **Delete**.

18. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

19. Close **Microsoft Edge.**. 


#### Task 2: Create a new Web App in Microsoft Azure

1. Open **Microsft Edge**

2. In **Microsoft Edge**, navigate to **http://portal.azure.com**.

3. Sign-in, and then click **App Services**.

4. In the **App Services** window, click **Add**.

5. In the **Web** window, click **Web App + SQL**, and then click **Create**.

6. In the **Web App + SQL** window, in the **App Name** text box, type **Underwater{unique name}**.

    >**Note:** The name must be unique. You can add your first name, last name or birthdate to the current name.

7. Under **SQL Database**, click **Configure required settings**.

8. In the **Database** window, click **Create a new database**.

9. In the **SQL Database** page, in **Name** text box, type **UnderwaterDB**.

10. Under **Target server**, click **Configure required settings**.

11. In the **New server** window, select the following:

	-  Server name: **Underwater{unique name}**
    -  Server admin login: **Underwateradmin**
    -  Password: **p@@sw0rd**
    -  Confirm password: **p@@sw0rd**

12. In the **New server** window, click **Select**

13. In the **SQL Database** window, click **Select**

14. In the **Web App + SQL** window, click **Create**.


#### Task 3: Prepare the application for deployment.

1. In **Underwater - Microsoft Visual Studio** window, in the **Underwater.csproj** file, after the **PropertyGroup** element, add a **ItemGroup** element. 

2. In the new  **PropertyGroup** element, add a **Content** element, with the following information:

	-  Include: **node_modules\****
    -  CopyToPublishDirectory: **PreserveNewest**

3. Save all changes. 

4.  In **Solution Explorer**, right-click **Underwater**, and then click **Publish**.

5. In the **Pick a publish target** dialog box, in the navigation pane, click **App Service**.

6. In the result pane, click **Select Existing**.

7. Click the arrow next to **Publish**, and then click **Create Profile**.

8. In the **App Service** dialog box, click **Sign in**.

    >**Note:** In case you have already signed-in, you will not see this dialog box. In this case, go to step 13.

9. In the **Sign in to your account** dialog box, type azure account **Email/Phone/Skype**, and then click **Next**.

10. Type **Password**, and then click **Sign in**.

11. In the **App Service** dialog box, expand **Underwater{unique name}**, click **Underwater{unique name}**, and then click OK.

12. In the **Publish** window, click **Configure**.

13. Click **Settings**.

14. Expand **Databases**.

15. Under the **Default Connection String**, select the checkbox **Use this connection string at runtime**.

16.  Fill the **Default Connection String** textbox, with the following information:

	 -  Default Connection String: **Server=tcp:Underwater{unique name}.database.windows.net,1433;Initial Catalog=UnderwaterDB;Persist Security Info=False;User ID=Underwateradmin;Password=p@@sw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;**

17. Expand **Entity Framework Migration**, and then click **Apply this migration on publish**.

18.  Expand **Entity Framework Migration**,  and fill the **Default Connection String** textbox, with the following information:

	 -  Default Connection String: **Server=tcp:Underwater{unique name}.database.windows.net,1433;Initial Catalog=UnderwaterDB;Persist Security Info=False;User ID=Underwateradmin;Password=p@@sw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;**

19. Click **Save**.

#### Task 4: Deploy and explore the application.

1. In Microsoft Visual Studio, open **Solutions Explorer**, right click **Underwater** and click **Publish**

2. In **Microsoft Edge**, in the menu bar, click **Add Fish**.

3. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Picture:  **_&lt;go to Allfiles\Mod14\Labfiles\Images, and click salmon.jpg&gt;_**

4. Click **Add**

5. On the **Dive into Our Fish Species** page, verify the newly submitted details.

6. Select a fish of your choice, and then click **Details**.

    >**Note:** The browser displays the scientific name of the fish. 

7. Verify the fish details, and then click **Back**.

8.  On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

9. On the **Edit Fish** page, in the **Scientic Name** text box, type **_&lt;A scientific name of your choice>&gt;_**, and then click **Save**.

10. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

11. Verify the newly edited details, and then click **Back**.

12. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

13. On the **Fish Delete** page, click **Delete**.

14. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

15. Close **Microsoft Edge**


#### Task 5: Update the application and deploy in Microsoft Azure.

1. In the **Underwater** application, in the **Fish** class, add a new property with the following information:
    - Scope: **public**
    - Name: **FishType**
    - Type: **string**
    - Access: **Read and write**

2. Above the **FishType** property, add a **Display** attribute with the following information:
    - Name: **"Scientific Name:"**

3. Add a new property with the following information:
    - Scope: **public**
    - Name: **CommonName**
    - Type: **string**
    - Access: **Read and write**


4. Above the **CommonName** property, add a **Display** attribute with the following information:
    - Name: **"Common Name:"**


5. In the **Details.cshtml** view, after the **DIV** element with **Scientific Name** fields, add a **DIV** element. 

6. In the new **DIV** element, add a **P** element, with the following information:
    - Class: **display-label**
    - Content: **@Html.DisplayNameFor(model => model.CommonName)**

7. After the new **P** element, add a **P** element, with the following information:
    - Class: **display-field**
    - Content: **@Html.DisplayFor(model => model.CommonName)**
  

8. In the **Edit.cshtml** view, after the **DIV** element with **Scientific Name** label and **form-group** class, add a **DIV** element, with the following information:

     - Class: **form-field row**

9. In the new **DIV** element, add a **LABEL** element, with the following information:
    - asp-for: **CommonName**
    - class: **col-sm-6 col-form-label**


10. Add a **DIV** element, with the following information:
    - class: **col-sm-6**

11. In the new **DIV** element, add a **INPUT** element, with the following information:
    - asp-for: **CommonName**
    - type: **text**
    - class: **form-control**
    - placeholder: **Scientific Name**
    - required: **required**

12. Add a **SPAN** element, with the following information:
    - asp-validation-for: **CommonName**

13. In the **Create.cshtml** view, after the **DIV** element with **ScientificName** label and **form-group** class, add a **DIV** element, with the following information:

     - Class: **form-field row**

14. In the new **DIV** element, add a **LABEL** element, with the following information:
    - asp-for: **CommonName**
    - class: **col-sm-6 col-form-label**

15. Add a **DIV** element, with the following information:
    - class: **col-sm-6**

16. In the new **DIV** element, add a **INPUT** element, with the following information:
    - asp-for: **CommonName**
    - type: **text**
    - class: **form-control**
    - placeholder: **Scientific Name**
    - required: **required**

17. Add a **SPAN** element, with the following information:
    - asp-validation-for: **CommonName**

18. In the **Delete.cshtml** view, after the **DIV** element with **Scientific Name** fields, add a **DIV** element. 

19. In the new **DIV** element, add a **P** element, with the following information:
    - Class: **display-label**
    - Content: **@Html.DisplayNameFor(model => model.CommonName)**

20. After the new **P** element, add a **P** element, with the following information:
    - Class: **display-field**
    - Content: **@Html.DisplayFor(model => model.CommonName)**

21. In the **AquariumController** class, in the **EditPost** method, in the **TryUpdateModelAsync** method call, pass **f => f.CommonName** as additional parameter. 

22. Open the **Package Manager Console** window.

23. In the **Package Manager Console**, run the following command: **Add-Migration AddFishCommonName**.

24. Run the following command: **Update-Database**.

    >**Note:** In the **Underwater - Microsoft Visual Studio** window, in **Solution Explorer**, under **Migrations**, a new file is created.

25. In **Solution Explorer**, right-click **Underwater**, and then click **Publish**.

26. In the **Pick a publish target** dialog box, verify that **Underwater {unique name}** is selected in the drop down, and then click **Publish**.


27. In **Microsoft Edge**, in the menu bar, click **Add Fish**.

28. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Common Name: **_&lt;A common name of your choice&gt;_** 
    -  Picture:  **_&lt;go to Allfiles\Mod14\Labfiles\Images, and click salmon.jpg&gt;_**

29. Click **Add**

30. On the **Dive into Our Fish Species** page, verify the newly submitted details.

31. Select a fish of your choice, and then click **Details**.

    >**Note:** The browser displays the scientific name of the fish. 

32. Verify the fish details, and then click **Back**.

33.  On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

34. On the **Edit Fish** page, in the **Scientic Name** text box, type **_&lt;A scientific name of your choice>&gt;_**, and then click **Save**.

35. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

36. Verify the newly edited details, and then click **Back**.

37. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

38. On the **Fish Delete** page, click **Delete**.

39. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

40. Close **Microsoft Edge**



### Exercise 2: Upload the Image to Azure Blob Storage

In this exercise, you will modify the web application you created, to start storing the images in Azure Blob Storage. The images will also be displayed from the storage using the URL generated for each image. The image URL will be stored in the database. For this you will run migrations. You will then create an Azure Storage Account in Microsoft Azure. You will then create a container in the storage account. You will then configure your application to use the Azure Storage Account. You will then change the code to . After that you will deploy your application to Microsoft Azure. 

The main tasks for this exercise are as follows:

1.  Create a blob storage account

2.	Prepare the application for working with Azure Storage.

3.	Write the code to upload an image.

4.	Deploy and Run the application in Microsoft Azure


#### Task 1: Create a blob storage account

1. Open **Microsft Edge**

2. In **Microsoft Edge**, in the address bar type **http://portal.azure.com**, and then press Enter.

3. Sign-in, and then navigate to **Storage Accounts**.

4. In the **Storage accounts** window, in the menu bar, click **Add**.

5. In the **Create storage account** window , in the **Storage account name** text box, type **underwater{unique name}**

    >**Note:** The name must be unique. You can add your first name, last name or birthdate to the current name.

6.  Under **Resource group**, select **Underwater{unique name}**.

7. Click **Review + create**.

8. Click **Create**.

9. In the **Microsoft.StorageAccount-{unique number} - Overview**, below **RESOURCE** click **underwater{unique name}**.

10. In the **Underwater{unique name}** window, below **Blob Service**, click **Blobs**.

11. In the **Underwater{unique name} - Blobs** window, in the menu bar, click **Container**.

12. In the **New container** window, in the **Name** text box, type **aquarium**.

13. In the **New Container** window, in the **Public Access Level** dropdown, select **Blob(anonymous read access for blobs only)**, and then click **OK**.


#### Task 2:  Prepare the application for working with Azure Storage.
 
1. In the **Underwater – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Underwater**, point to Add, and then click **Connected Service**.

2. In the **Connected Service** window, click **Cloud Storage with Azure Storage**.

3. In the **Azure Storage** window, sign in to your **Microsoft Azure Account**.

    >**Note:** In case you are already signed-in, you will not see the sign-in dialog box. In that case proceed to the next step.

4. In the **Azure Storage** window, click **Underwater{unique name}** , and then click **Add**.

    >**Note:** **Microsoft Edge** displays the following URL: **https://docs.microsoft.com/en-us/azure/visual-studio/vs-storage-aspnet-getting-started-blobs**.

5. Close **Microsoft Edge**.

6. In **appsettings.json** file, add new value using the following information:
    - Property: **"ContainerSettings"**
    - Type: **object**
    - Value: 
        - Property: **"ContainerName"**
        - Type: **aquarium**
    

#### Task 3: Write the code to upload an image.

1. In the **Underwater** application, in the **Fish** class, add a new property with the following information
    - Scope: **public**
    - Name: **ImageURL**
    - Type: **string**
    - Access: **Read and write**

2. In the **Details.cshtml** view, remove the contents of the **IF** statement.   

3. In the **IF** statement code block, add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.

4. In the **IF** statement code block, add a **DIV** element with the following information:
    - Class: **photo-display**

 
5. In the new **DIV** element, add a **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

6. After the **IF** statement, and an **ELSE** statement. 

7. In the  **ELSE** statement code block,  add a **DIV** element with the following information:
    - Class: **photo-display**

8.  In the new **DIV** element, add a **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**

9. In the **Edit.cshtml** view, remove the **IMG** element and add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.
       
10. In the **IF** statement code block, add a **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

11. After the **IF** statement, and an **ELSE** statement. 

12. In the  **ELSE** statement code block, add a **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**   

13. In the **Index.cshtml** view, remove the contents of the **IF** statement. 

14. In the **IF** statement code block, add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.
 
15. In the **IF** statement code block, add a **DIV** element with the following information:
    - Class: **photo-display**
 
16. In the new **DIV** element, add a **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

17. After the **IF** statement, and an **ELSE** statement. 

18. In the  **ELSE** statement code block,  add a **DIV** element with the following information:
    - Class: **photo-display**

19.  In the new **DIV** element, add a **IMG** element with the following information:
     - Class: **photo-display-img**
     - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**      

20. In the **Delete.cshtml** view, remove the contents of the **IF** statement. 

21. In the **IF** statement code block, add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.
 
22. In the **IF** statement code block, add a **DIV** element with the following information:
    - Class: **photo-display**
 
23. In the new **DIV** element, add a **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

24. After the **IF** statement, and an **ELSE** statement. 

25. In the  **ELSE** statement code block,  add a **DIV** element with the following information:
    - Class: **photo-display**

26.  In the new **DIV** element, add a **IMG** element with the following information:
     - Class: **photo-display-img**
     - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**      

27. Add a **NuGet Package*8 with the following information:

    - Package: **WindowsAzure.Storage*** 
    - Version: **9.3.3**

28. In the **UnderwaterRepository** class, add **USING** statements for the following namespaces:

    - **Microsoft.WindowsAzure.Storage**
    - **Microsoft.WindowsAzure.Storage.Blob**
    - **Microsoft.Extensions.Configuration**
    - **Microsoft.AspNetCore.Http**

29. Create a new field with the following information:

   - Scope: **private**
   - Type: **IConfiguration**
   - Name: **_configuration**

30. Create a new field with the following information:

   - Scope: **private**
   - Type: **CloudBlobContainer**
   - Name: **_container**

31. Change the **UnderwaterRepository** constructor signature to accept the following parameter:
    - Type: **IConfiguration**
    - Name: **configuration**

32. In the **UnderwaterRepository** constructor, initialize the **_configuration** field with the value of the **configuration** parameter.

32. Create a variable named **connectionString** of type **string** and assign it with the value of **_configuration.GetConnectionString("AzureStorageConnectionString-1")**

33. Create a variable named **containerName** of type **string** and assign it with the value of **_configuration.GetValue&lt;string&gt;("ContainerSettings:ContainerName")**

34. Create a variable named **storageAccount** of type **CloudStorageAccount** and assign it with the value of **CloudStorageAccount.Parse(connectionString)**

35. Create a variable named **blobClient** of type **CloudBlobClient** and assign it with the value of **storageAccount.CreateCloudBlobClient()**

36. Assign the **_container** field, with the value of **blobClient.GetContainerReference(containerName)**.

    >**Note:** Make sure the parameter **AzureStorageConnectionString-1** is the same as the name specified in **appsettings.json**.

37. Add a method with the following information:
    - Scope: **photo**
    - Modifier: **async**
    - Return type: **Task&lt;string&gt;**
    - Name: **UploadImageAsync**
    - Parameter: 
         - Type: **IFormFile**
         - Name: **photo**

38. In the **UploadImageAsync** method, create a variable named **blob** of type **CloudBlockBlob** and assign it with the value of **_container.GetBlockBlobReference(Path.GetFileName(photo.FileName))**

39.  Call the **blob.UploadFromStreamAsync** method using the **await** keyword. Pass **photo.OpenReadStream()**
as a parameter to the **blob.UploadFromStreamAsync** method. 

40. Return the **Task&lt;string&gt;** result using the **blob.Uri.ToString** method.


17. Save all the changes.

18. Run **Add-Migration** for the ImageURL property.


#### Task 4:	Deploy and Run the application in Microsoft Azure

1. In **Solution Explorer**, right-click **Underwater**, and then click **Publish**.

2. In the **Pick a publish target** dialog box, verify that **Underwater {unique name}** is selected in the drop down, and then click **Publish**.

3. In **Microsoft Edge**, in the menu bar, click **Add Fish**.

4. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Common Name: **_&lt;A common name of your choice&gt;_** 
    -  Picture:  **_&lt;go to Allfiles\Mod14\Labfiles\Images, and click clown-trigger.jpg&gt;_**

5. Click **Add**

6. On the **Dive into Our Fish Species** page, verify the newly submitted details.

7. Close **Microsoft Edge**

8. Close **Microsoft Visual Studio**.

9. In **Microsoft Edge**, navigate to **http://portal.azure.com**.

10. In the menu, click **Storage Accounts**

11. In the **Storage accounts** window, click **Underwater{unique name}**.

12. In the **Underwater{unique name}** window, below **Blob services**, click **Blobs**.

13. In the **Blobs** window, click **aquarium**.
    >**Note:** Verify the presence of uploaded image.

14. Click **clownfish.jpg**.

15. Click **Edit blob**.
    >**Note:** The uploaded image is displayed.

16. Close **Microsoft Edge** window.

>**Results:** After completing this exercise, you will be able to develop applications that use Azure Storage Blobs.


©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
