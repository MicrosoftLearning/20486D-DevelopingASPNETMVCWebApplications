# Module 14: Hosting And Deployment

# Lesson 2: Deployment to Microsoft Azure

### Demonstration: How to deploy a web application to Microsoft Azure

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos.
**(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)**

2. Navigate to **Allfiles/Mod14/Democode/01_AzureWebAppSample**, and then open the **AzureWebAppSample.sln**.

3. In the **AzureWebAppSample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

4. In **Microsoft Edge**, in the address bar, note the port number that appears at the end of the URL "http://localhost:[port]." You will use the port number during this demonstration.

5. In **Microsoft Edge**, click **Close**.

6. Make sure you have a valid Microsoft Azure Account.

#### Demonstration Steps 

1. Start **Visual Studio 2017**.

2. In the **Start Page - Microsoft Visual Studio** window, on the **FILE** menu, point to **New**, and then click **Project**.

3. In the **New Project** dialog box, in the navigation pane, expand **Installed**, and then click **Visual C#** and then click **Cloud**

4. In the **New Project** dialog box, in the result pane, click **ASP.NET Core Web Application**.

5. In the **Name** text box, type **AzureWebAppExample**.

6. In the **Location** text box, enter **Allfiles\Mod14\Democode\01_AzureWebAppExample_begin**, and then click **OK**. 

7. In the **New ASP.NET Core Web Application - AzureWebAppExample** dialog box, in the result pane, click **Web Application (Model-View-Controller)**, ensure that the check boxes are unchecked, the authentication is set to **No Authentication** and then click **OK**.
 
8. You now have a simple application based on a standard template.

9. In the **AzureWebAppExample – Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**. 

10.In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/**, and then press Enter.

**Note:** The browser displays the default home page. 

11.  In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, select **AzureWebAppExample** and right click and choose **Publish..**

12. In the **Pick a Publish Target** dialog box, in the navigation pane, click **App Service** and in the result pane select **Create New** and click on **Publish**

13. In the **Create App Service** dialog box, Click on **Sign in**. 
**Note:** In case you have already signed-in, you will not see this dialog box. In this case, go to step 15.

14. In the **Sign in** dialog box enter your Azure Account user email and click on **Next**. In the next dialog box, enter your password and click on **Sign in**.


15. In the **Create App Service** dialog box, in the **App Name** textbox enter **AzureWebAppExample2018**.
**Note:** The app name should be globally unique , so in case **AzureWebAppExample2018** is not available, please add month and/or day as well e.g. AzureWebAppExample20180618

16. In the **Create App Service** dialog box, Click on **New..** in front of the **Resource Group** text box. In the dialog box that opens enter **AzureWebAppExample**. Click **OK**

17. In the **Create App Service** dialog box, Click on **New..** in front of the **Hosting Plan** text box. 

18. In the **Configure Hosting Plan** dialog box, in the *App Service Plan** text box enter **AzureWebAppExample2018**
**Note:** The app plan name should be globally unique , so in case **AzureWebAppExample2018** is not available, please add month and/or day as well e.g. AzureWebAppExample20180618


19. In the **Configure Hosting Plan** dialog box, in the **Location** drop down box, choose **Central US**, in the **Size** drop down box, choose **S1 (1 core, 1.75 GB RAM) ** and click **OK**.


20. In the **Create App Service** dialog box, Click **Create**.

21. In **Visual Studio 2017**, in the **AzureWebAppExample – Microsoft Visual Studio** window, in **ouput** window, you will see the result of publishing. 


22. In **Microsoft Edge**, in the address bar, type **http://azurewebappexample2018.azurewebsites.net/**, and then press Enter.
**Note:** The browser displays the default home page. 


23. In **Microsoft Edge**, in the address bar, type **http://portal.azure.com/**, and then press Enter.
**Note::** The browser displays the dashboard. In the dashbaord you should see the App Service and the App Service Plan that was created in previous steps.

24. In **Microsoft Edge**, in the azure portal dashboard, click on **AzureWebAppExample2018**.  The browser display the **Overview** page in the result pane with details of the application deployed in App Service. 
**Note:** Go over the various details shown in the overview window.

25. In **Visual Studio 2017**, in **Solution Explorer**, under **AzureWebAppExample2018** , under **Views**, navigate to **Home** and click on **Index.cshtml**

26. In **Index.cshtm** replace the entire content with the following code:
```cs
@{
    ViewData["Title"] = "Home Page";
}

<h2> This is a ASP .NET web application deployed on Azure App Service !! </h2>

```

27. In the **AzureWebAppExample – Microsoft Visual Studio** window, in **Solution Explorer**, select **AzureWebAppExample** and right click and choose **Publish..**


28. In the **Publish** dialog box, ensure that the App Service Profile you created previously is selected. Click on **Publish** button.


29.  In **Visual Studio 2017**, in the **AzureWebAppExample – Microsoft Visual Studio** window, in **ouput** window, you will see the result of publishing. 


30. In **Microsoft Edge**, in the address bar, type **http://azurewebappexample2018.azurewebsites.net/**, and then press Enter.
**Note:** The browser displays - **This is a ASP .NET web application deployed on Azure App Service !!**. 















