# Module 14: Hosting and Deployment

# Lesson 2: Deployment to Microsoft Azure

### Demonstration: How to Deploy a Web Application to Microsoft Azure

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Ensure that you have a **Microsoft Azure** account.

#### Demonstration Steps 

1. Start Microsoft Visual Studio 2017.

2. In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **New**, and then click **Project**.

3. In the **New Project** dialog box, in the navigation pane, expand **Installed**, expand **Visual C#**, and then click **Cloud**.

4. In the **New Project** dialog box, in the result pane, click **ASP.NET Core Web Application**.

5. In the **Name** text box, type **AzureWebAppExample**.

6. In the **Location** text box, type **Allfiles\Mod14\Democode\01_AzureWebAppExample_Begin\**, and then click **OK**.

7. In the **New ASP.NET Core Web Application - AzureWebAppExample** dialog box, in the result pane, click **Web Application (Model-View-Controller)**, ensure that the check boxes are unchecked and then click **OK**.

8. In the **AzureWebAppExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**. 

    >**Note:** The browser displays the default home page.

9. In **Microsoft Edge**, click **Close**.

10. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureWebAppExample**, and then click **Publish.**

11. In the **Pick a publish target** dialog box, in the navigation pane, click **App Service**.

12. In the **Pick a publish target** dialog box, in the result pane, click **Create New**, and then click **Create Profile**.

13. In the **Create App Service** dialog box, click **Sign in**.

    >**Note:** In case you have already signed-in, you will not see this dialog box. In this case, go to step 16.

14. In the **Sign in to your account** dialog box, type azure account **Email/Phone/Skype**, and then click **Next**. 

15. In the **Sign in to your account** dialog box, type **Password**, and then click **Sign in**.

16. In the **Create App Service** dialog box, in the **App Name** text box, type  **AzureWebAppExample{unique name}**.  

    >**Note:** The name must be unique. You can add your first name, last name or birthdate to the current name.

17. In the **Create App Service** dialog box, below the **Resource Group** text box, click **New**. 

18. In the **New resource group name** text box, type **AzureWebAppExample**, and then click **OK**.

19. In the **Create App Service** dialog box, below the **Hosting Plan** text box, click **New**. 

20. In the **Configure Hosting Plan** dialog box, in the **App Service Plan** text box, type **AzureWebAppExample{unique name}**, and then click **OK**. 

21. In the **Create App Service** dialog box, click **Create**.

22. In the **Publish** window, click **Publish**.

    >**Note:** The browser displays home page, and the URL is: **http://azurewebapp{unique name}.azurewebsites.net/**

23. In **Microsoft Edge**, in the address bar, type **http://portal.azure.com**, and then press Enter.
    >**Note:** In case you are already signed-in, you will not see sign-in dialog box. In this case go to step 26.

24. In the **Sign in** dialog box, type azure account **Email/Phone/Skype**, and then click **Next**. 

25. In the **Sign in** dialog box, type **Password**, and then click **Sign in**. 

    >**Note:** The browser displays the dashboard that contains the **App Service** and the **App Service Plan**.

26. In **Microsoft Edge**, click on the **AzureWebApp{unique name}** app service.

    >**Note:** View the details in the overview window.

27. In **Microsoft Edge**, click **Close**.

28. In **AzureWebAppSample - Microsoft Visual Studio**, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

29. In **Index.cshtml** window, delete all the content.

30. In **Index.cshtml** window, type the following code:
```cs
@{
    ViewData["Title"] = "Home Page";
}

<h2> This is a ASP .NET web application deployed on Azure App Service </h2>
```
31. In the **AzureWebAppExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

32. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureWebAppExample**, and then click **Publish**.

33. In the **Publish** window, click **Publish**.

    >**Note:** The browser displays:  **This is a ASP .NET web application deployed on Azure App Service**. 

34. In **Microsoft Edge**, click **Close**.

35. In the **AzureWebAppExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Microsoft Azure Fundamentals

### Demonstration: How to Upload an Image to Microsoft Azure Blob Storage

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Ensure that you have a **Microsoft Azure** account.

#### Demonstration Steps 

1. Open **Microsoft Edge**.

2. In **Microsoft Edge**, in the address bar type **http://portal.azure.com**, and then press Enter.

3.	Sign-in, and then click **Storage accounts**.

4.	In the **Storage accounts** window, in the menu bar, click **Add**.

5.	In the **Create storage account** window, in the **Storage account name** text box, type **blobdemo{unique name}**.

    >**Note:** The name must be unique. You can add your first name, last name or birthdate to the current name.

6.	In the **Create storage account** window, under **Resource group**, click **Create new**.

7.  In the pop-up window, in the **Name** text box, type **blobdemo{unique name}**, and then click **OK**.

    >**Note:** The name must be unique. You can add your first name, last name or birthdate to the current name.

8.	In the **Create storage account** window, click **Review + create**.

9.	In the **Create storage account** window, click **Create**.

10.	In the **Microsoft.StorageAccount - Overview** window, click **Go to resource**.

11. In the **blobdemo{unique name}** window, below **Blob services**, click **Blobs**.

12. In the **blobdemo{unique name} - Blobs** window, in the menu bar, click **Container**.

13.	In the **New container** window, in the **Name** text box, type **myfirstcontainer**.

14. In the **New container** window, in the **Public access level** list, click **Blob(anonymous read access for blobs only)**, and then click **OK**.

15.	In the **blobdemo{unique name} - Blobs** window, click **myfirstcontainer**.

16.	In the **myfirstcontainer** window, click **Upload**.

17.	In the **Upload blob** window, click **Select a file**. 

18.	In the **File Explorer**, go to **Allfiles\Mod14\Democode\02_AzureStorageDemo_Images**, click **blackberries.jpg**, and then click **Open**.

19.	In the **Upload blob** window, click **Upload**.

20.	Close the **Upload blob** window.

21.	Open **File Explorer**.

22.	 In **File Explorer**, navigate to **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin**, and then double-click  **AzureStorageDemo.sln**.

23. In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureStorageDemo**,  point to **Add**, and then click **Connected Service**.

24.	In the **Connected Service** window, click **Cloud Storage with Azure Storage**.

25.	In the **Azure Storage** window, sign in to **Microsoft Azure Account**.

    >**Note:** In case you are already signed-in, you will not see the sign-in dialog box. In that case proceed to the next step.

26.	In the **Azure Storage** window, click  **blobdemo{unique name}** , and then click **Add**.

    >**Note:** **Microsoft Edge** displays the following URL: **https://docs.microsoft.com/en-us/azure/visual-studio/vs-storage-aspnet-getting-started-blobs**.

27. In **Microsoft Edge**, click **Close**.

28.	In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, click **appsettings.json**.

29.	In the **appsettings.json** window, right-click the following code, and then click **Copy**.
```cs
      AzureStorageConnectionString-1
```
30.	In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**,  expand **Controllers**, and then click **BlobController.cs**.

31.	In the **BlobController.cs** window, locate the following code:
```cs
       _connectionString = _configuration.GetConnectionString("{your_connection_string_name}");
```
32. Replace **{your_connection_string_name}** with the connection string name copied in step 28.

33. In the **AzureStorageDemo - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureStorageDemo**, and then click **Manage NuGet Packages**.

34. In the **NuGet Package Manager: AzureStorageDemo** window, click **Browse**.

35. In the **Search** text box, type **WindowsAzure.Storage**, and then press Enter.

36. Click **WindowsAzure.Storage**, select version **9.3.3**, and then click **Install.**

37. If a **Preview Changes** dialog box appears, click **OK**.

38. If a **License Acceptance** dialog box appears, click **I Accept**.

39. Close the **NuGet Package Manager: AzureStorageDemo** window.

40. In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, click **BlobController.cs**.

41. In the **BlobController.cs** code window, locate the following code:
  ```cs
       using AzureStorageDemo.Data;
```
42. Ensure that the cursor is at the end of the **AzureStorageDemo.Data** namespace, press Enter, and then type the following code:
  ```cs
       using Microsoft.WindowsAzure.Storage;
       using Microsoft.WindowsAzure.Storage.Blob;
```

43. Ensure that the cursor is at the end of the **CreateImageAsync** code block, press Enter twice, and then type the following code:
  ```cs
       public async Task UploadAsync(IFormFile photo)
       {
           CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
           CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
           CloudBlobContainer container = blobClient.GetContainerReference("myimagecontainer");

           if (await container.CreateIfNotExistsAsync())
           {
               await container.SetPermissionsAsync(
               new BlobContainerPermissions
              {
                  PublicAccess = BlobContainerPublicAccessType.Blob
              });
           }
           CloudBlockBlob blob = container.GetBlockBlobReference(Path.GetFileName(photo.FileName));
           await blob.UploadFromStreamAsync(photo.OpenReadStream());
       }
```

44. In the **BlobController.cs** code block, locate following code:
  ```cs
       using (var memoryStream = new MemoryStream())
       {
           photo.PhotoAvatar.CopyTo(memoryStream);
           photo.PhotoFile = memoryStream.ToArray();
       }
```

45. Place the cursor at the end of the located code, press Enter, type the following code, and then press Enter twice.
  ```cs
       await UploadAsync(photo.PhotoAvatar);
```

46. In the **AzureStorageDemo - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

47. In the **AzureStorageDemo – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

48.	In **Microsoft Edge**, click **Upload New Image**.

49. On the **Add Photo to Album** page, in the **Title** text box, type _&lt;A photo title of your choice&gt;._

50. On the **Add Photo to Album** page, in the **Description** text box, type _&lt;A photo description of your choice&gt;._

51. In **Microsoft Edge**, click **Choose File**.

52.	In **File Explorer**, navigate to **Allfiles\Mod14\Democode\02_AzureStorageDemo_Images**, click **fungi.jpg**, and then click **Open**.

53. In **Microsoft Edge**, click **Submit Photo to Azure**. 

54. In **Microsoft Edge**, open a new tab, type **http://portal.azure.com**, and then press Enter.

55. In the portal, in the menu on left-hand side, click **Storage Accounts**. 
	
56. In the **Storage accounts** window, click **blobdemo{unique name}**.

57.	In the **blobdemo{unique name}** window, below **Blob services**, click **Blobs**.

58.	In the **Blobs** window, click **myimagecontainer**.

    >**Note:** Verify the presence of uploaded image.

59. Click **fungi.jpg**.

60. Click **Edit blob**.

    >**Note:** The uploaded image is displayed.

61. Close all **Microsoft Edge** windows.

62. In the **AzureStorageDemo - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.