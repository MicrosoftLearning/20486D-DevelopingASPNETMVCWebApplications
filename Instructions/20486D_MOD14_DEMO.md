# Module 14: Hosting and Deployment

# Lesson 2: Deployment to Microsoft Azure

### Demonstration: How to deploy a web application to Microsoft Azure

#### Preparation Steps 

1. Make sure you have a valid **Microsoft Azure** Account.

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

9.  In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right click **AzureWebAppExample** and click on **Publish.**

10. In the **Pick a Publish Target** dialog box, in the navigation pane, click **App Service** .

11. In the **Pick a Publish Target** dialog box, in the result pane select **Create New** and click on **Publish**

12. In the **Create App Service** dialog box, Click on **Sign in**. 
>**Note:** In case you have already signed-in, you will not see this dialog box. In this case, go to step 15.

13. In the **Sign in** dialog box type your Azure Account user email and click on **Next**. 

14. In the **Sign in** dialog box, type your password and click on **Sign in**.


15. In the **Create App Service** dialog box, in the **App Name** textbox **AzureWebAppExample<yourmobileno>**  
>**Note:** Replace <yourmobileno> with your mobile number. This is needed as App Names are globally unique names.


16. In the **Create App Service** dialog box, click on **New..** below the **Resource Group** text box. 

17. In the **New resource group name** text box, type **AzureWebAppExample**. Click **OK**

18. In the **Create App Service** dialog box, click on **New..** below the **Hosting Plan** text box. 

19. In the **Configure Hosting Plan** dialog box, in the **App Service Plan** text box type **AzureWebAppExample<yourmobileno>**. 

20. In the **Configure Hosting Plan** dialog box, in the **Location** drop down box, choose **Central US**, 

21. In the **Configure Hosting Plan** dialog box, in the **Size** drop down box, choose **S1 (1 core, 1.75 GB RAM) ** and click **OK**.

22. In the **Create App Service** dialog box, click **Create**.
>**Note:** **Microsoft Edge** will open automatically and in the address bar the URL will be:  **http://azurewebapp<yourmobileno>.azurewebsites.net/**. The browser displays the default home page. 

23. In **Microsoft Edge**, in the address bar, type **http://portal.azure.com/**, and then press Enter.
>**Note::** After signing in, the browser displays the dashboard. In the dashbaord you should see the App Service and the App Service Plan that was created in previous steps.

24. In **Microsoft Edge**, in the azure portal dashboard, click on **AzureWebApp<yourmobileno>**.  The browser display the **Overview** page in the result pane with details of the application deployed in App Service. 
>**Note:** Review the details shown in the overview window.

25. In **AzureWebAppSample - Microsoft Visual Studio****, in **Solution Explorer**, expand **Views**, expand **Home** and then click on **Index.cshtml**

26. In **Index.cshtml** replace the entire content with the following code:
```cs
@{
    ViewData["Title"] = "Home Page";
}

<h2> This is a ASP .NET web application deployed on Azure App Service </h2>

```

27. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, right click **AzureWebAppExample** and then click **Publish**

28. In the **Publish** dialog box, ensure that the App Service Profile that was created is selected. Click on **Publish** button.

29. In **Microsoft Edge**, in the address bar, type **http://azurewebapp<yourmobileno>.azurewebsites.net/**, and then press Enter.
>**Note:** The browser displays - **This is a ASP .NET web application deployed on Azure App Service**. 



# Lesson 3: Microsoft Azure Fundamentals

### Demonstration: How to Upload an Image to Microsoft Azure Blob Storage

#### Preparation Steps 

1. Make sure you have a valid **Microsoft Azure** Account.

#### Demonstration Steps 

1.	Open **Microsoft Edge** and in the address bar type **http://portal.azure.com** and press Enter

2.	After sign-in , in the left hand pane locate **Storage Accounts** and click on it.

3.	In the **Storage accounts** section, in the top bar, click on **Add**

4.	In the **Create Storage Account** pane , in the **Name** textbox type **blobdemo<yourmobileno>**

5.	In the **Create Storage Account** pane, under **Resource Group** type **blobdemo**

6.	In the **Create Storage Account** pane locate the **Create** button at the bottom and click on it.

7.	In the **Storage accounts** section click on  **Refresh**
>**Note**: Creation of your account could take a while, so if you do not see the account, click on refresh after a few seconds.

8.	In the **Storage accounts** section click on **blobdemo<yourmobileno>**

9.	In the left hand section of **Storage Accounts > blobdemo<yourmobileno>** page, locate **Blob Service** and click on **Blobs** under it

10.	In the right hand section of **Storage Accounts > blobdemo<yourmobileno> - Blobs ** page, click on **Container**

11.	In the **New container** window , in the **Name** textbox type **myfirstcontainer**. Click on **OK**

12.	In the **Storage Accounts > blobdemo<yourmobileno> - Blobs ** page, click on **myfirstcontainer**

13.	In the **myfirstcontainer** page click on **Upload**

14.	In the **Upload blob** page click on the **Choose file** icon. 

15.	In the file explorer window, navigate to the image to be uploaded and click **Open**.

16.	In the **Upload blob** page click on the **Upload** button.

17.	Click on close in the **Upload blob** pane.

18.	In the navigation pane click on **blobdemo<yourmobileno> - Blobs**

19.	In the **blobdemo<yourmobileno> - Blobs** on the left hand pane click on **Access Keys**

20.	In the **blobdemo<yourmobileno> - Access Keys** page, on the right pane, locate the first instance of **Connection String**. Click on **Click to Copy** besides the **Connection String** text box.

21.	 Close **Microsoft Edge**.

22.	Open **Microsoft Visual Studio 2017** 

23.	In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **Open**, and then click **Project/Solution**.

24.	In the **Filename** text box, type **Allfiles\Mod14\Democode\02_AzureStorageDemo_begin**, and then click **OK**. 

25.	In the **AzureStorageDemo – Microsoft Visual Studio** window, in **Solution Explorer**, expand **AzureStorageDemo** , expand **Controllers** and click on **BlobController.cs**

26.	In the **BlobController.cs** navigate to the method **BlobHandling** and locate the line 
```cs
string connectionString = "CONNECTION_STRING";
```
Replace **"CONNECTION_STRING"** with the connection string copied to the clipboard.

27.	In the **AzureStorageDemo – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

28.	In the **Microsoft Edge** window that opens automatically click on **Choose File** 

29.	In the explorer window navigate to a folder with an image and choose the image.

30. In the **Microsoft Edge** window click on **Submit** 
>**Note** The browser will display the image uploaded.

31. In a new tab in **Microsoft Edge** go to address bar and type **http://portal.azure.com**.

30.	After sign-in, in the left hand pane locate **Storage Accounts** and click on it.

31.	In the **Storage Accounts** pane, locate **blobdemo<yourmobileno>** and click on it.

32.	In the left-hand section of **Storage Accounts > blobdemo<yourmobileno>** page, locate **Blob Service** and click on **Blobs** under it

33.	In the left-hand section of **Storage Accounts > blobdemo<yourmobileno> > blobs** page, locate **myimagecontainer** and click on it.


