# Module 14: Hosting and Deployment

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Hosting and Deployment

#### Scenario

In this lab, the students will first deploy a web application to Microsoft Azure. The application will manage an aquarium. It will store and display details of various fish, and an image for each fish. The user can add/edit/delete a fish. In the second part of the lab, students will create an Azure storage container. They will then modify the application to store the image of the fish in the Azure storage container instead of storing it locally. 

#### Objectives

After completing this lab, you will be able to:

- Create an App Service in Microsoft Azure.
- Deploy an application to Azure.
- Work with Azure SQL database.
- Create a storage container on Azure.
- Upload images to storage containers from an application.

#### Lab Setup

Estimated Time: **90 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos of this course. (https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)

2. Open Command Prompt by using **Run as administrator**.

    >**Note**: If a **User Account Control** dialog appears, click yes. 

3. In Administrator: Command Prompt, run the following command: **cd [Repository Root]\Allfiles\Mod14\Labfiles\01_Underwater_begin\Underwater**.

4. Run the following command: **npm install**.

5. Close the **Command Prompt** window. 

### Exercise 1: Deploying a Web Application to Microsoft Azure

#### Scenario

In this exercise, you will first build and run a simple web application locally. For this, you will run migrations for your local database. You will then create an Azure App Service and Azure SQL database in Azure and configure your application to use the Azure SQL database. You will populate the database by using Azure Migrate. Finally, you will deploy your application to Azure.

The main tasks for this exercise are:

1. Explore and run the application locally

2. Create a new Web App in Azure

3. Prepare the application for deployment

4. Deploy the application

5. Update the application and deploy in Azure

#### Task 1: Explore and run the application locally

1. Open the **UnderWater.sln** solution from the following location: **[Repository Root]\Allfiles\Mod14\Labfiles\01_Underwater_begin**. 

    >**Note**: If a **Security Warning for Underwater** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. Open the **Package Manager Console** window.

3. In the **Package Manager Console** window, run the following command: **Add-Migration InitialCreate**.

4. Run the following command: **Update-Database**.

5. Start the application without debugging.

6. In the menu bar, click **Add Fish**.

7. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Picture:  **_&lt;go to [Repository Root]\Allfiles\Mod14\Labfiles\Images, and click koi.jpg&gt;_**

8. Click **Add**

9. On the **Dive into Our Fish Species** page, verify the newly submitted details.

10. Select a fish of your choice, and then click **Details**.

    >**Note**: The browser displays the scientific name of the fish. 

11. Verify the fish details, and then click **Back**.

12.  On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

13. On the **Edit Fish** page, in the **Scientic Name** box, type **_&lt;A scientific name of your choice>&gt;_**, and then click **Save**.

14. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

15. Verify the newly edited details, and then click **Back**.

16. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

17. On the **Are you sure you want to delete this?** page, click **Delete**.

18. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

19. Close Microsoft Edge. 

#### Task 2: Create a new Web App in Microsoft Azure

1. Open Microsoft Edge.

2. Go to **http://portal.azure.com**.

3. Sign in, and then click **App Services**.

4. In the **App Services** window, click **Add**.

5. In the **Marketplace** window, click **Web App + SQL**, and then click **Create**.

6. In the **Web App + SQL** window, in the **App Name** box, type **Underwater{unique name}**.

    >**Note**: The name must be unique. You can add your first name, last name, or birthdate to the current name.

7. Under **SQL Database**, click **Configure required settings**.

8. In the **Database** window, click **Create a new database**.

9. In the **SQL Database** page, in the **Name** box, type **UnderwaterDB**.

10. Under **Target server**, click **Configure required settings**.

11. In the **New server** window, select the following:

	-  Server name: **Underwater{unique name}**
    -  Server admin login: **Underwateradmin**
    -  Password: **p@@sw0rd**
    -  Confirm password: **p@@sw0rd**

12. In the **New server** window, click **Select**.

13. In the **SQL Database** window, click **Select**.

14. In the **Web App + SQL** window, click **Create**.

#### Task 3: Prepare the application for deployment

1. In **Underwater - Microsoft Visual Studio** window, in the **Underwater.csproj** file, after the **PropertyGroup** element, add an **ItemGroup** element. 

2. In the new  **PropertyGroup** element, add a **Content** element, with the following information:

	-  Include: *node_modules*
    -  CopyToPublishDirectory: **PreserveNewest**

3. Save all the changes. 

4.  In Solution Explorer, right-click **Underwater**, and then click **Publish**.

5. In the **Pick a publish target** dialog box, in the left pane, click **App Service**.

6. In the result pane, click **Select Existing**.

7. Click the arrow next to **Publish**, and then click **Create Profile**.

8. In the **App Service** dialog box, click **Sign in**.

    >**Note**: In case you have already signed in, you will not see this dialog box. In that case, go to step 13.

9. In the **Sign in to your account** dialog box, enter the email address, phone number, or Skype ID of your Azure account, and then click **Next**.

10. Type **Password**, and then click **Sign in**.

11. In the **App Service** dialog box, expand **Underwater{unique name}**, click **Underwater{unique name}**, and then click **OK**.

12. In the **Publish** window, click **Configure**.

13. Click **Settings**.

14. Expand **Databases**.

15. Under  **Default Connection**, select the **Use this connection string at runtime** check box.

16.  Fill the **Default Connection** box with the following information:

	 -  Default Connection: **Server=tcp:Underwater{unique name}.database.windows.net,1433;Initial Catalog=UnderwaterDB;Persist Security Info=False;User ID=Underwateradmin;Password=p@@sw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;**

17. Expand **Entity Framework Migration**, and then click **Apply this migration on publish**.

18.  Expand **Entity Framework Migration**,  and then fill the **Default Connection** box with the following information:

	 -  Default Connection: **Server=tcp:Underwater{unique name}.database.windows.net,1433;Initial Catalog=UnderwaterDB;Persist Security Info=False;User ID=Underwateradmin;Password=p@@sw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;**

19. Click **Save**.

#### Task 4: Deploy the application

1. In Microsoft Visual Studio, in the **Publish** window, click **Publish**.

2. In Microsoft Edge, in the menu bar, click **Add Fish**.

3. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Picture:  **_&lt;go to [Repository Root]\Allfiles\Mod14\Labfiles\Images, and click salmon.jpg&gt;_**

4. Click **Add**.

5. On the **Dive into Our Fish Species** page, verify the newly submitted details.

6. Select a fish of your choice, and then click **Details**.

    >**Note**: The browser displays the scientific name of the fish. 

7. Verify the fish details, and then click **Back**.

8. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

9. On the **Edit Fish** page, in the **Scientic Name** box, type **_&lt;A scientific name of your choice&gt;_**, and then click **Save**.

10. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

11. Verify the newly edited details, and then click **Back**.

12. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

13. On the **Are you sure you want to delete this?** page, click **Delete**.

14. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

15. Close Microsoft Edge.

#### Task 5: Update the application and deploy in Microsoft Azure

1. In the **Underwater** application, in the **Fish** class, add a new property with the following information:
    - Scope: **public**
    - Name: **FishType**
    - Type: **string**
    - Access: **Read and write**

2. Above the **FishType** property, add a **Display** attribute with the following information:
    - Name: **"Scientific Name:"**

3. Add a new property with the following information:
    - Scope: **public**
    - Name: **CommonName**
    - Type: **string**
    - Access: **Read and write**

4. Above the **CommonName** property, add a **Display** attribute with the following information:
    - Name: **"Common Name:"**

5. In the **Details.cshtml** view, after the **DIV** element with the **Scientific Name** fields, add a **DIV** element. 

6. In the new **DIV** element, add a **P** element with the following information:
    - Class: **display-label**
    - Content: **@Html.DisplayNameFor(model => model.CommonName)**

7. After the new **P** element, add a **P** element with the following information:
    - Class: **display-field**
    - Content: **@Html.DisplayFor(model => model.CommonName)**
  
8. In the **Edit.cshtml** view, after the **DIV** element with the **Scientific Name** label and the **form-group** class, add a **DIV** element with the following information:

     - Class: **form-field row**

9. In the new **DIV** element, add a **LABEL** element with the following information:
    - asp-for: **CommonName**
    - class: **col-sm-6 col-form-label**

10. Add a **DIV** element with the following information:
    - class: **col-sm-6**

11. In the new **DIV** element, add an **INPUT** element with the following information:
    - asp-for: **CommonName**
    - type: **text**
    - class: **form-control**
    - placeholder: **Scientific Name**
    - required: **required**

12. Add a **SPAN** element with the following information:
    - asp-validation-for: **CommonName**

13. In the **Create.cshtml** view, after the **DIV** element with the **ScientificName** label and the **form-group** class, add a **DIV** element with the following information:

     - Class: **form-field row**

14. In the new **DIV** element, add a **LABEL** element with the following information:
    - asp-for: **CommonName**
    - class: **col-sm-6 col-form-label**

15. Add a **DIV** element with the following information:
    - class: **col-sm-6**

16. In the new **DIV** element, add an **INPUT** element with the following information:
    - asp-for: **CommonName**
    - type: **text**
    - class: **form-control**
    - placeholder: **Scientific Name**
    - required: **required**

17. Add a **SPAN** element with the following information:
    - asp-validation-for: **CommonName**

18. In the **Delete.cshtml** view, after the **DIV** element with the **Scientific Name** field, add a **DIV** element. 

19. In the new **DIV** element, add a **P** element with the following information:
    - Class: **display-label**
    - Content: **@Html.DisplayNameFor(model => model.CommonName)**

20. After the new **P** element, add a **P** element with the following information:
    - Class: **display-field**
    - Content: **@Html.DisplayFor(model => model.CommonName)**

21. In the **AquariumController** class, in the **EditPost** method, in the **TryUpdateModelAsync** method call, pass *f => f.CommonName* as an additional parameter. 

22. Open the **Package Manager Console** window.

23. In the **Package Manager Console** window, run the following command: **Add-Migration AddFishCommonName**.

24. Run the following command: **Update-Database**.

    >**Note**: In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Migrations**, a new file is created.

25. In Solution Explorer, right-click **Underwater**, and then click **Publish**.

26. In the **Pick a publish target** dialog box, verify that **Underwater{unique name}** is selected in the drop-down list, and then click **Publish**.

27. In Microsoft Edge, in the menu bar, click **Add Fish**.

28. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Common Name: **_&lt;A common name of your choice&gt;_** 
    -  Picture:  **_&lt;go to [Repository Root]\Allfiles\Mod14\Labfiles\Images, and click salmon.jpg&gt;_**

29. Click **Add**.

30. On the **Dive into Our Fish Species** page, verify the newly submitted details.

31. Select a fish of your choice, and then click **Details**.

    >**Note**: The browser displays the scientific name of the fish. 

32. Verify the fish details, and then click **Back**.

33. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

34. On the **Edit Fish** page, in the **Scientic Name** box, type **_&lt;A scientific name of your choice>&gt;_**, and then click **Save**.

35. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

36. Verify the newly edited details, and then click **Back**.

37. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

38. On the **Are you sure you want to delete this?** page, click **Delete**.

39. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

40. Close Microsoft Edge.

>**Results**: After completing this exercise, you will be able to deploy your application to Azure.

### Exercise 2: Upload an Image to Azure Blob Storage

In this exercise, you will create an Azure storage account in Azure and a container in the storage account. You will then modify the web application you created to start storing the images in Azure Blob storage. The images will also be displayed from the storage by using the URL generated for each image. Also, you will change the code to upload images to the container. Finally, you will deploy your application to Azure.

The main tasks for this exercise are as follows:

1.  Create a blob storage account

2.	Prepare the application for working with Azure Storage

3.	Write the code to upload an image

4.	Deploy and run the application in Azure

#### Task 1: Create a blob storage account

1. Open Microsoft Edge.

2. Go to **http://portal.azure.com**.

3. On the menu, click **Storage Accounts**.

4. In the **Storage accounts** window, in the menu bar, click **Add**.

5. In the **Create storage account** window , in the **Storage account name** box, type **underwater{unique name}**.

    >**Note**: The name must be unique. You can add your first name, last name, or birthdate to the current name.

6.  Under **Resource group**, select **Underwater{unique name}**.

7. Click **Review + create**.

8. Click **Create**.

9. In the **Microsoft.StorageAccount-{unique number}** **- Overview** window, below **RESOURCE**, click **underwater{unique name}**.

10. In the **Underwater{unique name}** window, below **Blob Service**, click **Blobs**.

11. In the **Underwater{unique name}** **- Blobs** window, in the menu bar, click **Container**.

12. In the **New container** window, in the **Name** box, type **aquarium**.

13. In the **New Container** window, in the **Public Access Level** drop-down list, select **Blob(anonymous read access for blobs only)**, and then click **OK**.

#### Task 2:  Prepare the application for working with Azure Storage
 
1. In the **Underwater – Microsoft Visual Studio** window, in Solution Explorer, right-click **Underwater**, point to **Add**, and then click **Connected Service**.

2. In the **Connected Service** window, click **Cloud Storage with Azure Storage**.

3. In the **Azure Storage** window, sign in to your **Microsoft Azure Account**.

    >**Note**: In case you are already signed-in, you will not see the **Sign in** dialog box. In that case, proceed to the next step.

4. In the **Azure Storage** window, click **Underwater{unique name}** , and then click **Add**.

    >**Note**: Microsoft Edge displays the following URL: https://docs.microsoft.com/en-us/azure/visual-studio/vs-storage-aspnet-getting-started-blobs.

5. Close Microsoft Edge.

6. In the **appsettings.json** file, add a new value by using the following information:
    - Property: **"ContainerSettings"**
    - Type: **object**
    - Value: 
        - Property: **"ContainerName"**
        - Type: **aquarium**
    
#### Task 3: Write the code to upload an image

1. In the **Underwater** application, in the **Fish** class, add a new property with the following information:
    - Scope: **public**
    - Name: **ImageURL**
    - Type: **string**
    - Access: **Read and write**

2. In the **Details.cshtml** view, remove the contents of the **IF** statement.   

3. In the **IF** statement code block, add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.

4. In the **IF** statement code block, add a **DIV** element with the following information:
    - Class: **photo-display**

5. In the new **DIV** element, add an **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

6. After the **IF** statement, and an **ELSE** statement. 

7. In the  **ELSE** statement code block,  add a **DIV** element with the following information:
    - Class: **photo-display**

8.  In the new **DIV** element, add an **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**

9. In the **Edit.cshtml** view, remove the **IMG** element and add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.
       
10. In the **IF** statement code block, add an **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

11. After the **IF** statement, and an **ELSE** statement. 

12. In the  **ELSE** statement code block, add an **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**   

13. In the **Index.cshtml** view, remove the contents of the **IF** statement. 

14. In the **IF** statement code block, add an **IF** statement that checks that the value of **item.ImageURL** is **NOT NULL**.
 
15. In the **IF** statement code block, add a **DIV** element with the following information:
    - Class: **photo-display**
 
16. In the new **DIV** element, add an **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@item.ImageURL**

17. After the **IF** statement, add an **ELSE** statement. 

18. In the  **ELSE** statement code block,  add a **DIV** element with the following information:
    - Class: **photo-display**

19.  In the new **DIV** element, add an **IMG** element with the following information:
     - Class: **photo-display-img**
     - Src: **@Url.Action("GetImage", "Aquarium", new { Id = item.FishId })**      

20. In the **Delete.cshtml** view, remove the contents of the **IF** statement. 

21. In the **IF** statement code block, add an **IF** statement that checks that the value of **Model.ImageURL** is **NOT NULL**.
 
22. In the **IF** statement code block, add a **DIV** element with the following information:
    - Class: **photo-display**
 
23. In the new **DIV** element, add an **IMG** element with the following information:
    - Class: **photo-display-img**
    - Src: **@Model.ImageURL**

24. After the **IF** statement, add an **ELSE** statement. 

25. In the  **ELSE** statement code block,  add a **DIV** element. 

26.  In the new **DIV** element, add an **IMG** element with the following information:
     - Class: **photo-display-img**
     - Src: **@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })**      

27. Add a **NuGet Package** with the following information:

    - Package: **WindowsAzure.Storage**
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
    - Type: *IConfiguration*
    - Name: *configuration*

32. In the **UnderwaterRepository** constructor, initialize the **_configuration** field with the value of the *configuration* parameter.

33. Create a variable named *connectionString* of the string type and assign it the **_configuration.GetConnectionString("AzureStorageConnectionString-1")** value.

34. Create a variable named *containerName* of the string type and assign it the **_configuration.GetValue&lt;string&gt;("ContainerSettings:ContainerName")** value.

35. Create a variable named *storageAccount* of the CloudStorageAccount type and assign it the **CloudStorageAccount.Parse(connectionString)** value.

36. Create a variable named *blobClient* of the CloudBlobClient type and assign it the **storageAccount.CreateCloudBlobClient()** value.

37. To the **_container** field assign the **blobClient.GetContainerReference(containerName)** value.

    >**Note**: Make sure the parameter *AzureStorageConnectionString-1* is the same as the name specified in the **appsettings.json** file.

38. Add a method with the following information:
    - Scope: **private**
    - Modifier: **async**
    - Return type: **Task&lt;string&gt;**
    - Name: **UploadImageAsync**
    - Parameter: 
         - Type: **IFormFile**
         - Name: **photo**

39. In the **UploadImageAsync** method, create a variable named *blob* of the CloudBlockBlob type, and assign the **_container.GetBlockBlobReference(Path.GetFileName(photo.FileName))** value.

40. Call the **blob.UploadFromStreamAsync** method by using the **await** keyword. Pass *photo.OpenReadStream()*
    as a parameter to the **blob.UploadFromStreamAsync** method. 

41. Return the **Task&lt;string&gt;** result by using the **blob.Uri.ToString** method.

42. Add a method with the following information:
    - Scope: **private**
    - Modifier: **async**
    - Return type: **Task&lt;bool&gt;**
    - Name: **DeleteImageAsync**
    - Parameter: 
         - Type: **string**
         - Name: **PhotoFileName**

43. In the **DeleteImageAsync** method, create a variable named *blob* of the CloudBlockBlob type, and assign it the **_container.GetBlockBlobReference(PhotoFileName)** value.

44. Call the **blob.DeleteAsync** method by using the **await** keyword.

45. Return **true** as the **Task&lt;bool&gt;** result.

46. In the **AddFish** method, remove the contents of the **IF** statement.

47. In the **IF** statement, create a variable named *imageURL* of the **string** type, and assign it with the **UploadImageAsync(fish.PhotoAvatar).GetAwaiter().GetResult()** value.

48. To the **ImageURL** property of the *fish* parameter, assign the **imageURL** value.

49. To the **ImageMimeType** property of the *fish* parameter, assign the **fish.PhotoAvatar.ContentType** value.

50. To the **ImageName** property of the *fish* parameter, assign the **Path.GetFileName(fish.PhotoAvatar.FileName)** value.

51. Call the **Add** method of the **_context** property. Pass *fish* as a parameter to the **Add** method. 

52. Call the **SaveChanges** method of the **_context** property.

53. Remove the contents of the **RemoveFish** method.

54. In the **RemoveFish** method, create a variable named *fish* of the var type, and assign it with the **_context.fishes.SingleOrDefault(f => f.FishId == id)** value.

55. Create an **IF** statement that checks that the value of **fish.ImageURL** is **NOT NULL**.

56.  In the **IF** statement code block, call the **DeleteImageAsync** method. Pass *fish.ImageName* as a parameter to the **DeleteImageAsync** method. 

57. Chain a **GetAwaiter** method call to the **DeleteImageAsync** function call.

58. Chain a **GetResult** method call to the **GetAwaiter** function call.

59.  Call the **Remove** method of the **_context.fishes** property. Pass *fish* as a parameter to the **Remove** method. 

60. Call the **SaveChanges** method of the **_context** property.

61. Save all the changes.

62. In **Package Manager Console**, run the **Add-Migration AddFishImageURL** command.

63. Run the following command: **Update-Database**.

    >**Note**: In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Migrations**, a new file gets created.

#### Task 4: Deploy and run the application in Azure

1. In Solution Explorer, right-click **Underwater**, and then click **Publish**.

2. In the **Pick a publish target** dialog box, verify that **Underwater{unique name}** is selected in the drop-down list, and then click **Publish**.

3. In Microsoft Edge, in the menu bar, click **Add Fish**.

4. On the **Add a Fish to Aquarium** page, select the following:

	-  Aquarium: **_&lt;A aquarium of your choice&gt;_**
    -  Fish Name: **_&lt;A fish name of your choice&gt;_**
    -  Scientific Name: **_&lt;A scientific name of your choice&gt;_**
    -  Common Name: **_&lt;A common name of your choice&gt;_** 
    -  Picture:  **_&lt;go to [Repository Root]\Allfiles\Mod14\Labfiles\Images, and click clown-trigger.jpg&gt;_**

5. Click **Add**.

6. On the **Dive into Our Fish Species** page, verify the newly submitted details.

7. Close Microsoft Edge.

8. Close Microsoft Visual Studio.

9. In Microsoft Edge, go to **http://portal.azure.com**.

10. On the menu, click **Storage Accounts**.

11. In the **Storage accounts** window, click **Underwater{unique name}**.

12. In the **Underwater{unique name}** window, below **Blob services**, click **Blobs**.

13. In the **Blobs** window, click **aquarium**.
    >**Note**: Verify the presence of uploaded image.

14. Click **clown-trigger.jpg**.

15. Click **Edit blob**.
    >**Note**: The uploaded image is displayed.

16. Close Microsoft Edge.

>**Results**: After completing this exercise, you will be able to develop applications that use Azure Blob storage.

©2019 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.

