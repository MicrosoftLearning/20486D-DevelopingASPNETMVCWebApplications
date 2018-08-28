# Module 14: Hosting and Deployment

# Lesson 2: Deployment to Microsoft Azure

### Demonstration: How to deploy a web application to Microsoft Azure

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

2. Ensure that you have a valid **Microsoft Azure** account.

#### Demonstration Steps 

1. Start Microsoft Visual Studio 2017.

2. In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **New**, and then click **Project**.

3. In the **New Project** dialog box, in the navigation pane, expand **Installed**, expland **Visual C#**, and then click **Cloud**.

4. In the **New Project** dialog box, in the result pane, click **ASP.NET Core Web Application**.

5. In the **Name** text box, type **AzureWebAppExample**.

6. In the **Location** text box, type **Allfiles\Mod14\Democode\01_AzureWebAppExample_begin\AzureWebExample\AzureWebExample.sln**, and then click **OK**. 

7. In the **New ASP.NET Core Web Application - AzureWebAppExample** dialog box, in the result pane, click **Web Application (Model-View-Controller)**, ensure that the check boxes are unchecked and then click **OK**.
 
8. In the **AzureWebAppExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**. 
>**Note:** **Microsoft Edge** will open automatically and in the address bar the URL will be:  **http://localhost:[port]/**. The browser displays the default home page. 

9.  In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureWebAppExample**, and then click **Publish.**

10. In the **Pick a Publish Target** dialog box, in the navigation pane, click **App Service**.

11. In the **Pick a Publish Target** dialog box, in the result pane, click **Create New**, and then click **Publish**.

12. In the **Create App Service** dialog box, click **Sign in**. 
>**Note:** In case you have already signed-in, you will not see this dialog box. In this case, go to step 15.

13. In the **Sign in** dialog box type your Azure Account user email, and then click **Next**. 

14. In the **Sign in** dialog box, type your password, and then click **Sign in**.


15. In the **Create App Service** dialog box, in the **App Name** textbox **AzureWebAppExample<yourfirstnameyourlastname>**  
>**Note:** Replace <yourfirstnameyourlastname> with your first name and last name. This is needed as App Names are globally unique names.


16. In the **Create App Service** dialog box, below the **Resource Group** text box, click **New**. 

17. In the **New resource group name** text box, type **AzureWebAppExample**, and then click **OK**.

18. In the **Create App Service** dialog box, below the **Hosting Plan** text box, click **New**. 

19. In the **Configure Hosting Plan** dialog box, in the **App Service Plan** text box type **AzureWebAppExample<yourfirstnameyourlastname>**. 

20. In the **Configure Hosting Plan** dialog box, in the **Location** list, click **Central US**.

21. In the **Configure Hosting Plan** dialog box, in the **Size** list, click **S1 (1 core, 1.75 GB RAM)**, and then click **OK**.

22. In the **Create App Service** dialog box, click **Create**.
>**Note:** **Microsoft Edge** will open automatically and in the address bar the URL will be:  **http://azurewebapp<yourfirstnameyourlastname>.azurewebsites.net/**. The browser displays the default home page. 

23. In **Microsoft Edge**, in the address bar, type **http://portal.azure.com**, and then press Enter.
>**Note::** After signing in, the browser displays the dashboard that contains the App Service and the App Service Plan that was created in previous steps.

24. In **Microsoft Edge**, in the azure portal dashboard, click **AzureWebApp<yourfirstnameyourlastname>**.  The browser display the **Overview** page in the result pane with details of the application deployed in App Service. 
>**Note:** Review the details in the overview window.

25. In **AzureWebAppSample - Microsoft Visual Studio**, in **Solution Explorer**, expand **Views**, expand **Home**, and then click **Index.cshtml**.

26. In **Index.cshtml** window delete all the content.


27. In **Index.cshtml** window , type the following code.
```cs
@{
    ViewData["Title"] = "Home Page";
}

<h2> This is a ASP .NET web application deployed on Azure App Service </h2>

```

28. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right-click **AzureWebAppExample** and then click **Publish**.

29. In the **Publish** dialog box, ensure that the App Service Profile that was created is selected, and then click **Publish** button.
>**Note:** **Microsoft Edge** will open automatically and in the address bar the URL will be:  **http://azurewebapp<yourfirstnameyourlastname>.azurewebsites.net**. The browser displays  **This is a ASP .NET web application deployed on Azure App Service**. 


# Lesson 3: Microsoft Azure Fundamentals

### Demonstration: How to Upload an Image to Microsoft Azure Blob Storage

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

2. Ensure that you have a valid **Microsoft Azure** account.


#### Demonstration Steps 

1.	In **Microsoft Edge** and in the address bar type **http://portal.azure.com**, and then press Enter.

2.	Sign-in, and then click **Storage Accounts**.

3.	In the **Storage accounts** pane, in the menu bar, click **Add**.

4.	In the **Create Storage Account** pane , in the **Name** textbox type **blobdemo<yourfirstnameyourlastname>**
>**Note:** Replace <yourfirstnameyoulastname> with your first name followed by your last name.

5.	In the **Create Storage Account** pane, under **Resource Group** type **blobdemo**.

6.	In the **Create Storage Account** pane, click **Create**.

7.	In the **Storage accounts** pane, click  **Refresh**.

8.	In the **Storage accounts** pane, click **blobdemo<yourfirstnameyourlastname>**.

9.	In the **Storage Account** pane, locate **Blob Service** and click **Blobs** under it.

10.	In the **Storage Account** pane, in the menu bar, click **Container**.

11.	In the **New container** window , in the **Name** text box type **myfirstcontainer**, and then click **OK**.

12.	In the **Storage Account** page, click **myfirstcontainer**.

13.	In the **myfirstcontainer** page, click **Upload**.

14.	In the **Upload blob** page, click **Choose file**. 

15.	In the **File Explorer**, go to **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin\AzureStorageDemo\AzureStorageDemo\images**, click **Chrysanthemum.jpeg**, and then click **Open**.

16.	In the **Upload blob** page click **Upload**.

17.	In the **Upload blob** page , click **close**.

18.	Open Microsoft Visual Studio 2017.

19.	In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **Open**, and then click **Project/Solution**.

20.	In the **Name** text box, type **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin\AzureStorageDemo\AzureStorageDemo.sln**, and then click **OK**. 

21. In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, right click **AzureStorageWebDemo**,  click **Add**, and then click **Connected Service**.

22.	In the **Connected Service** window, click **Cloud Storage with Azure Storage**.

23.	In the **Azure Storage** window, sign in to your **Microsoft Azure Account**.

24.	In the **Azure Storage** window, click  **blobdemo<yourfirstnameyourlastname>** , and then click **Add**.

25.	In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, expand **AzureStorageDemo** , expand **Controllers**, and then click **BlobController.cs**.

26.	In the **BlobController.cs** locate the following code :
```cs
    _connectionString = _configuration.GetConnectionString("{your_storage_account_name}_AzureStorageConnectionString");
```
Replace **{your_storage_account_name}** with the name of the storage account you created.

27.	In the **BlobController.cs** navigate to the **Upload** method and add the following code above the return statement.
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
28. In the **AzureStorageDemo – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

29.	In the **Microsoft Edge** window click **Choose File**.

30.	In **File Explorer** navigate to **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin\AzureStorageDemo\AzureStorageDemo\images** and choose the **Desert.jpeg**.

31. In the **Microsoft Edge**, click **Submit**. 
>**Note** The browser displays the uploaded image.

32. In **Microsoft Edge**, open a new tab, type **http://portal.azure.com**, and then press **Enter**

33.	Sign-in, and then click **Storage Accounts**.

34.	In the **Storage Accounts** pane, click **blobdemo<yourfirstnameyourlastname>**.

35.	In **blobdemo<yourfirstnameyourlastname>** page, below **Blob Service**, click **Blobs**.

36.	In **blobs** page, click **myimagecontainer**.

37. In **Microsoft Edge**, click **Close**.

38. In the **AzureStorageDemo - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

