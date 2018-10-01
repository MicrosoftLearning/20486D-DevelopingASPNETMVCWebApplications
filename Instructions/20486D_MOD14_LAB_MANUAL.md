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

1. Open the **UnderWater.sln** file from the following location: **Allfiles\Mod14\Labfiles\01_Underwater_begin**.

2. Run migrations to create the database locally.

4. Start the application without debugging

5. Select a fish of your choice, and click on **Details**.

    >**Note:** The browser displays the scientific name of the fish. 

4. Verify the fish details, and then click **Back to List**.

5. Close **Microsoft Edge.**. 

#### Task 2: Create a new Web App in Microsoft Azure.

1. Open **Microsft Edge**

2. In **Microsoft Edge**, in the address bar type **http://portal.azure.com**, and then press Enter.

3. Sign-in, and then navigate to **App Services**.

4. Create a Web App in **App Services** by providing all the necessary details.

5. Navigate to **SQL Databases**.

6. Create a new **SQl Server** and **SQL Database** by providing all the necessary details.


#### Task 3: Prepare the application for deployment.

1. In Microsoft Visual Studio 2017, open **Solutions Explorer**, right click **Underwater** and click **Edit Underwater.csproj**

2. In **Underwate.csproj**, add the following code under <PropertyGroup>
```cs 

  <ItemGroup>
         <Content Include="node_modules\**" CopyToPublishDirectory="PreserveNewest" />
  </ItemGroup>

```
#### Task 4: Deploy and explore the application.

1. In Microsoft Visual Studio 2017, open **Solutions Explorer**, right click **Underwater** and click **Publish**

2. Sign in and select the Web App you created.

3. Click **Configure**

4. In the **Publish** window, click **Settings**

5. In the **Publish** window, expand **Databases** and edit  **Default Connection String** to point to SQL Database created in Azure.

6. In the **Publish** window, expand **Entity Framework Migration** and edit **Apply this migration on publish** to point to SQL Database in Azure.

7. In the **Publish** window, Click **Save**.

8. In Microsoft Visual Studio 2017, **publish** window, click **Publish**.


#### Task 5: Update the application and deploy in Microsoft Azure.

1. In the **Underwater** application, in the **Fish** class, add a new property with the following information
    - Scope: **public**
    - Name: **FishType**
    - Type: **string**
    - Access: **Read and write**

2. In the **Underwater** application, in the **Create.cshtml**, after the **INPUT** element of **Scientific Name**, Add an **INPUT** element with the following information:

     - asp-for: **FishType**

3. In the **Underwater** application, in the **Edit.cshtml**, after the **div** element of **Scientific Name**, add a **DIV** with the following information: 

     - asp-for: **Price**


4. Add a **DIV** element with the following information:

     - Class: **form-field**

5. In the **DIV** element, add a **LABEL** element with the following information:

    - asp-for: **FishType**

6. Add an **INPUT** element with the following information:

     - asp-for: **FishType**

7. After the **INPUT** element with **asp-for="FishType"** helper, add a **SPAN** element with the following information:
    - asp-validation-for: **FishType**

8. In the **Details.cshtml** file, add a **DIV** element after the **DIV** element for **Scientific Name**, with the following information: 

 	- Class: **display-label**
    - Content: **@Html.DisplayNameFor(model => model.FishType)**

9. After the **P** element, add a **P** element with the following information:

	- Class: **display-field**
    - Content: ***@Html.DisplayFor(model => model.FishType)**

10. Save all the changes.

11. Run **Add-Migration** for the FishType property.

12. Open **Solutions Explorer**, right click **Underwater** and click **Publish**.




©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
