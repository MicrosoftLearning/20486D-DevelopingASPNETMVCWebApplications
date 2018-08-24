# Module 14: Hosting and Deployment

# Lesson 2: Deployment to Microsoft Azure

### Demonstration: How to deploy a web application to Microsoft Azure

#### Preparation Steps 

1. Ensure that you have a valid **Microsoft Azure** Account.

2. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

#### Demonstration Steps 

1. Start **Microsoft Visual Studio 2017**.

2. In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **New**, and then click **Project**.

3. In the **New Project** dialog box, in the navigation pane, expand **Installed**, expland **Visual C#** and then click **Cloud**

4. In the **New Project** dialog box, in the result pane, click **ASP.NET Core Web Application**.

5. In the **Name** text box, type **AzureWebAppExample**.

6. In the **Location** text box, type **Allfiles\Mod14\Democode\01_AzureWebAppExample_begin**, and then click **OK**. 

7. In the **New ASP.NET Core Web Application - AzureWebAppExample** dialog box, in the result pane, click **Web Application (Model-View-Controller)**, ensure that the check boxes are unchecked and then click **OK**.
 
8. In the **AzureWebAppExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**. 
>**Note:** **Microsoft Edge** will open automatically and in the address bar the URL will be:  **http://localhost:[port]/**. The browser displays the default home page. 

9.  In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right click **AzureWebAppExample** and click **Publish.**

10. In the **Pick a Publish Target** dialog box, in the navigation pane, click **App Service**.

11. In the **Pick a Publish Target** dialog box, in the result pane, select **Create New** and then click **Publish**.

12. In the **Create App Service** dialog box, click **Sign in**. 
>**Note:** In case you have already signed-in, you will not see this dialog box. In this case, go to step 15.

13. In the **Sign in** dialog box type your Azure Account user email and click **Next**. 

14. In the **Sign in** dialog box, type your password and click **Sign in**.


15. In the **Create App Service** dialog box, in the **App Name** textbox **AzureWebAppExample<yourfirstnameyourlastname>**  
>**Note:** Replace <yourfirstnameyourlastname> with your mobile number. This is needed as App Names are globally unique names.


16. In the **Create App Service** dialog box, click **New..** below the **Resource Group** text box. 

17. In the **New resource group name** text box, type **AzureWebAppExample**. Click **OK**

18. In the **Create App Service** dialog box, click **New..** below the **Hosting Plan** text box. 

19. In the **Configure Hosting Plan** dialog box, in the **App Service Plan** text box type **AzureWebAppExample<yourfirstnameyourlastname>**. 

20. In the **Configure Hosting Plan** dialog box, in the **Location** drop down box, choose **Central US**, 

21. In the **Configure Hosting Plan** dialog box, in the **Size** drop down box, choose **S1 (1 core, 1.75 GB RAM) ** and click **OK**.

22. In the **Create App Service** dialog box, click **Create**.
>**Note:** **Microsoft Edge** will open automatically and in the address bar the URL will be:  **http://azurewebapp<yourfirstnameyourlastname>.azurewebsites.net/**. The browser displays the default home page. 

23. In **Microsoft Edge**, in the address bar, type **http://portal.azure.com/**, and then press Enter.
>**Note::** After signing in, the browser displays the dashboard. In the dashbaord you should see the App Service and the App Service Plan that was created in previous steps.

24. In **Microsoft Edge**, in the azure portal dashboard, click **AzureWebApp<yourfirstnameyourlastname>**.  The browser display the **Overview** page in the result pane with details of the application deployed in App Service. 
>**Note:** Review the details shown in the overview window.

25. In **AzureWebAppSample - Microsoft Visual Studio****, in **Solution Explorer**, expand **Views**, expand **Home** and then click **Index.cshtml**

26. In **Index.cshtml** replace the entire content with the following code:
```cs
@{
    ViewData["Title"] = "Home Page";
}

<h2> This is a ASP .NET web application deployed on Azure App Service </h2>

```

27. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right click **AzureWebAppExample** and then click **Publish**

28. In the **Publish** dialog box, ensure that the App Service Profile that was created is selected. click **Publish** button.

29. In **Microsoft Edge**, in the address bar, type **http://azurewebapp<yourfirstnameyourlastname>.azurewebsites.net/**, and then press Enter.
>**Note:** The browser displays - **This is a ASP .NET web application deployed on Azure App Service**. 



# Lesson 3: Microsoft Azure Fundamentals

### Demonstration: How to Upload an Image to Microsoft Azure Blob Storage

#### Preparation Steps 

1. Ensure that you have a valid **Microsoft Azure** Account.

2. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

3. Ensure that you have an image saved on your desktop.


#### Demonstration Steps 

1.	Open **Microsoft Edge** and in the address bar type **http://portal.azure.com** and press Enter

2.	After sign-in , in the left hand pane locate **Storage Accounts** and click it.

3.	In the **Storage accounts** pane, in the top bar, click **Add**

4.	In the **Create Storage Account** pane , in the **Name** textbox type **blobdemo<yourfirstnameyourlastname>**
>**Note:** The storage account name should be globally unique. In case this name is already used, please add your birthdate to make it unique.

5.	In the **Create Storage Account** pane, under **Resource Group** type **blobdemo<yourfirstnameyourlastname>**

6.	In the **Create Storage Account** pane locate the **Create** button at the bottom and click it.

7.	In the **Storage accounts** pane click  **Refresh**

8.	In the **Storage accounts** pane click **blobdemo<yourfirstnameyourlastname>**

9.	In the left hand section of **Storage Account** pane, locate **Blob Service** and click **Blobs** under it

10.	In the right hand section of **Storage Account** pane, in the menu bar, click **Container**

11.	In the **New container** window , in the **Name** textbox type **myfirstcontainer**, and then click **OK**

12.	In the **Storage Account** page, click **myfirstcontainer**

13.	In the **myfirstcontainer** page click **Upload**

14.	In the **Upload blob** page, click **Choose file** icon. 

15.	In the **File Explorer**, navigate to desktop and choose the image to be uploaded, and then click **Open**.

16.	In the **Upload blob** page click **Upload**.

17.	In the **Upload blob** page , click **close**

18.	Open **Microsoft Visual Studio 2017**

19.	In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **Open**, and then click **Project/Solution**.

20.	In the **Filename** text box, type **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin**, and then click **OK**. 

21. In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, right click **AzureStorageWebDemo**,  click **Add**, and then click **Connected Service**.

22.	In the **Connected Service** window, click **Cloud Storage with Azure Storage**

23.	In the **Azure Storage** window, sign in to your **Microsoft Azure Account**

24.	In the **Azure Storage** window, click  **blobdemo<yourfirstnameyourlastname>** , and then click **Add**

25.	In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, expand **AzureStorageDemo** , expand **Controllers** and click **BlobController.cs**

26.	In the **BlobController.cs** navigate to the **BlobController** constructor and locate the line 
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

29.	In the **Microsoft Edge** window that opens automatically click **Choose File** 

30.	In the explorer window navigate to a folder with an image and choose the image.

31. In the **Microsoft Edge** window click **Submit** 
>**Note** The browser will display the image uploaded.

32. In a new tab in **Microsoft Edge** go to address bar and type **http://portal.azure.com**.

33.	After sign-in, in the left hand pane locate **Storage Accounts** and click it.

34.	In the **Storage Accounts** pane, locate **blobdemo<yourfirstnameyourlastname>** and click it.

35.	In the left-hand section of **blobdemo<yourfirstnameyourlastname>** page, locate **Blob Service** and click **Blobs** under it

36.	In the left-hand section of **blobdemo<yourfirstnameyourlastname> > blobs** page, locate **myimagecontainer** and click it.


