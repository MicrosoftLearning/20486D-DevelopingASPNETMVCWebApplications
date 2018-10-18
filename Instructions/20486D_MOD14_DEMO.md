# Module 14: Hosting and Deployment

# Lesson 2: Deployment to Microsoft Azure

### Demonstration: How to deploy a web application to Microsoft Azure

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Ensure that you have a **Microsoft Azure** account.

#### Demonstration Steps 

1. Start Microsoft Visual Studio 2017.

2. In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **New**, and then click **Project**.

3. In the **New Project** dialog box, in the navigation pane, expand **Installed**, expand **Visual C#**, and then click **Cloud**.

4. In the **New Project** dialog box, in the result pane, click **ASP.NET Core Web Application**.

5. In the **Name** text box, type **AzureWebAppExample**.

6. In the **Location** text box, type **Allfiles\Mod14\Democode\01_AzureWebAppExample_begin\AzureWebExample\AzureWebExample.sln**, and then click **OK**. 

7. In the **New ASP.NET Core Web Application - AzureWebAppExample** dialog box, in the result pane, click **Web Application (Model-View-Controller)**, ensure that the check boxes are unchecked and then click **OK**.
 
8. In the **AzureWebAppExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**. 
    >**Note:** The browser displays the default home page. 

9. In **Microsoft Edge**, click **Close**.

10.  In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureWebAppExample**, and then click **Publish.**

11. In the **Pick a publish target** dialog box, in the navigation pane, click **App Service**.

12. In the **Pick a publish target** dialog box, in the result pane, click **Create New**, and then click **Publish**.

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
    >**Note:** The browser displays the default home page, and the URL is: **http://azurewebapp{unique name}.azurewebsites.net/**

22. In **Microsoft Edge**, in the address bar, type **http://portal.azure.com**, and then press Enter.
    >**Note:** In case you are already signed-in, you will not see sign-in dialog box.In this case go to step 25.

23. In the **Sign in** dialog box, type azure account **Email/Phone/Skype**, and then click **Next**. 

24. In the **Sign in** dialog box, type **Password**, and then click **Sign in**. 
    >**Note:** The browser displays the dashboard that contains the **App Service** and the **App Service Plan**.

25. In **Microsoft Edge**, click on the **App Service**, **AzureWebApp{unique name}**.
    >**Note:** View the details in the overview window.

26. In **Microsoft Edge**, click **Close**.

27. In **AzureWebAppSample - Microsoft Visual Studio**, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

28. In **Index.cshtml** window, delete all the content.


29. In **Index.cshtml** window, type the following code:
```cs
@{
    ViewData["Title"] = "Home Page";
}

<h2> This is a ASP .NET web application deployed on Azure App Service </h2>

```

30. In the **AzureWebAppExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

31. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureWebAppExample**, and then click **Publish**.


32. In the **Publish** dialog box, ensure that the app service Profile that was created is selected, and then click **Publish**.
    >**Note:** The browser displays:  **This is a ASP .NET web application deployed on Azure App Service**. 

33. In **Microsoft Edge**, click **Close**.

34. In the **AzureWebAppExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Microsoft Azure Fundamentals

### Demonstration: How to Upload an Image to Microsoft Azure Blob Storage

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

2. Ensure that you have a **Microsoft Azure** account.


#### Demonstration Steps 

1.	Open **Microsoft Edge**.

2. In **Microsoft Edge**, in the address bar type **http://portal.azure.com**, and then press Enter.

3.	Sign-in, and then click **Storage accounts**.

4.	In the **Storage accounts** window, in the menu bar, click **Add**.

5.	In the **Create storage account** window , in the **Storage Account Name** text box, type **blobdemo{unique name}**
    >**Note:** The name must be unique. You can add your first name, last name or birthdate to the current name.

6.	In the **Create storage account** window, under **Resource Group**, click **Create new**.

7.  In the pop-up window, in the **Name** field, type **blobdemo**.

8.	In the **Create storage account** window, click **Review + create**.

9.	In the **Create storage account** window, click **Create**.

9.	In the **Storage account Overview** window, click **Go to resource**.

10. In the **blobdemo{unique name}** window, below **Services**, click **Blobs**.

11. In the **blobdemo{unique name} - Blobs** window, in the menu bar, click **Container**.

12.	In the **New container** window, in the **Name** text box, type **myfirstcontainer**, and then click **OK**.

13.	In the **blobdemo{unique name} - Blobs** window, click **myfirstcontainer**.

14.	In the **myfirstcontainer** window, click **Upload**.

15.	In the **Upload blob** window, click **Select a file**. 

16.	In the **File Explorer**, go to **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin\AzureStorageDemo\images**, click **chrysanthemum.jpeg**, and then click **Open**.

17.	In the **Upload blob** window, click **Upload**.

18.	In the **Upload blob** window, click **Close**.

19.	Open **File Explorer**.

20.	 In **File Explorer**, navigate to **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin**, and then double-click  **AzureStorageDemo.sln**.

21. In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureStorageDemo**,  point to **Add**, and then click **Connected Service**.

22.	In the **Connected Service** window, click **Cloud Storage with Azure Storage**.

23.	In the **Azure Storage** window, sign in to your **Microsoft Azure Account**.
    >**Note:** In case you are already signed-in, you will not see the sign-in dialog box. In that case proceed to the next step.

24.	In the **Azure Storage** window, click  **blobdemo{unique name}** , and then click **Add**.
    >**Note:** This causes **Microsoft Edge** window to open with URL pointing to https://docs.microsoft.com/en-us/azure/visual-studio/vs-storage-aspnet-getting-started-blobs. This can be ignored.

25.	In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**,  expand **Controllers**, and then click **BlobController.cs**.

26.	In the **BlobController.cs** window, locate the following code:
```cs
    _connectionString = _configuration.GetConnectionString("{your_storage_account_name}_AzureStorageConnectionString");
```
27. Replace **{your_storage_account_name}** with the name of the storage account you created.

28.	In the **BlobController.cs** window, locate the following code:
```cs
public async Task<ActionResult> Upload(IFormFile photo)
{
            
```

29. Place the cursor at the end of the located code, press **Enter**, and then type the following code:
```cs
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("myimagecontainer");

            if (await container.CreateIfNotExistsAsync())
            {
                await container.SetPermissionsAsync(
                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    }
                    );
            }

            CloudBlockBlob blob = container.GetBlockBlobReference(photo.FileName);
           
            await blob.UploadFromStreamAsync(photo.OpenReadStream());
      
            TempData["ImageURL"] = blob.Uri.ToString();
            
```

30. In the **AzureStorageDemo - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

31. In the **AzureStorageDemo – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

32.	In **Microsoft Edge**, click **Browse**.

33.	In **File Explorer** navigate to **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin\AzureStorageDemo\images**, click **desert.jpeg**, and then click **Open**.

34. In **Microsoft Edge**, click **Submit**. 
    >**Note** The browser displays the uploaded image.

35. In **Microsoft Edge**, open a new tab, type **http://portal.azure.com**, and then press Enter.

36.	In the **Storage accounts** window, click **blobdemo{unique name}**.

37.	In the **blobdemo{unique name}** window, below **Services**, click **Blobs**.

38.	In the **Blobs** window, click **myimagecontainer**, and verify the the presence of uploaded image.

39. Close all **Microsoft Edge** windows.

40. In the **AzureStorageDemo - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not** included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.