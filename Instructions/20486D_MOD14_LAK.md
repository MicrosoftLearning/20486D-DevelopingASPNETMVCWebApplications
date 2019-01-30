# Module 14: Hosting and Deployment

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Hosting and Deployment

### Lab Setup

Estimated Time: **90 minutes**

### Preparation Steps

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for the labs and demos of this course. 
(https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles)

2. In File Explorer, browse to **[Repository Root]\Allfiles\Mod14\Labfiles\01_Underwater_begin\Underwater**, and then copy the address in the address bar.

3. Click **Start**, and then type **cmd**.

4. Under **Best match**, right-click **Command Prompt**, and then click **Run as administrator**.

5. In the **User Account Control** dialog box, click **Yes**.

6. In the Administrator: Command Prompt window, type the following command, and then press Enter.
  ```cs
       cd {copied folder path}
```

>**Note**: If the *{copied folder path}* is different from the disk drive where the command prompt is located, then you should type *{disk drive}:* before typing the **cd** *{copied folder path}* command.

7. In the Administrator: Command Prompt window, type the following command, and then press Enter.
  ```cs
       npm install
```
>**Note**: If warning messages are shown in command prompt, you can ignore them.

8. Close the window.

### Exercise 1: Deploying a Web Application to Microsoft Azure

#### Task 1: Explore and run the application locally

1. Browse to **[Repository Root]\Allfiles\Mod14\Labfiles\01_Underwater_begin**, and then double-click **Underwater.sln**.

    >**Note**: If a **Security Warning for Underwater** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click **OK**. 

2. In the **Underwater - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**.

3. In the **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
       Add-Migration InitialCreate
```

4. In the **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
       Update-Database
```
5. In the **Underwater - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

6. In Microsoft Edge, in the menu bar, click **Add Fish**.
 
7. On the **Add a Fish to Aquarium** page, in the **Aquarium** list, select **_&lt;A aquarium of your choice&gt;._**.

8. On the **Add a Fish to Aquarium** page, in the **Fish Name** box, type **_&lt;A fish name of your choice&gt;._**.

9. On the **Add a Fish to Aquarium** page, in the **Scientific Name** box, type **_&lt;A scientific name of your choice&gt;._**.

10. On the **Add a Fish to Aquarium** page, in the **Picture** file chooser, go to **[Repository Root]\Allfiles\Mod14\Labfiles\Images**, click **koi.jpg**, and then click **Open**.

11. On the **Add a Fish to Aquarium** page, click **Add**.

12. On the **Dive into Our Fish Species** page, verify the newly submitted details.

13. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Details**.

14. View the fish details, and then click **Back**.

15. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

16. On the **Edit Fish** page, in the **Scientic Name** box, type **_&lt;A scientific name of your choice&gt;_**, and then click **Save**.

17. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

18. View the fish details, verify the newly edited details, and then click **Back**.

19. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

20. On the **Are you sure you want to delete this?** page, click **Delete**.

21. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

22. In Microsoft Edge, click **Close**.

#### Task 2: Create a new Web App in Microsoft Azure

1. Open Microsoft Edge.

2. In Microsoft Edge, in the address bar, type **http://portal.azure.com**, and then press Enter.

3. Sign in, and then click **App Services**.

4. In the **App Services** window, click **Add**.

5. In the **Marketplace** window, click **Web App + SQL**, and then click **Create**.

6. In the **Web App + SQL** window, in the **App Name** box, type **Underwater{unique name}**.

    >**Note**: The name must be unique. You can add your first name, last name, or birthdate to the current name.

7. In the **Web App + SQL** window, under **SQL Database**, click **Configure required settings**.

8. In the **Database** window, click **Create a new database**.

9. In the **SQL Database** window, in the **Name** box, type **UnderwaterDB**.

10. In the **SQL Database** window, under **Target server**, click **Configure required settings**.

11. In the **New server** window, in the **Server name** box, type **Underwater{unique name}**.
   
12. In the **New server** window, in the **Server admin login** box, type **Underwateradmin**.

13. In the **New server** window, in the **Password** box, type **p@@sw0rd**.

14. In the **New server** window, in the **Confirm password** box, type **p@@sw0rd**.

15. In the **New server** window, click **Select**.

16. In the **SQL Database** window, click **Select**.

17. In the **Web App + SQL** window, click **Create**.

#### Task 3: Prepare the application for deployment

1. In the **Underwater - Microsoft Visual Studio** window, open Solution Explorer, right-click **Underwater**, and then click **Edit Underwater.csproj**.

2. In the **Underwater.csproj** code window, locate the following code:
  ```cs
       <PropertyGroup>
           <TargetFramework>netcoreapp2.1</TargetFramework>
           <TypeScriptToolsVersion>2.8</TypeScriptToolsVersion>
       </PropertyGroup>
```

3. Place the cursor after the **>** (greater than) sign of the **&lt;/PropertyGroup&gt;** tag, press Enter twice, and then type the following code:
  ```cs
       <ItemGroup>
           <Content Include="node_modules\**" CopyToPublishDirectory="PreserveNewest" />
       </ItemGroup>
```

4. In the **Underwater - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

5. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, right-click **Underwater**, and then click **Publish**.

6. In the **Pick a publish target** dialog box, in the navigation pane, click **App Service**.

7. In the **Pick a publish target** dialog box, in the result pane, click **Select Existing**.

8. Click the arrow next to **Publish**, and then click **Create Profile**.

9. In the **App Service** dialog box, click **Sign in**.

    >**Note**: In case you have already signed in, you will not see this dialog box. In that case, go to step 13.

10. In the **Sign in to your account** dialog box, enter the email address, phone number, or Skype ID of your Azure account, and then click **Next**. 

11. In the **Sign in to your account** dialog box, type **Password**, and then click **Sign in**.

12. In the **App Service** dialog box, expand **Underwater{unique name}**, click **Underwater{unique name}**, and then click **OK**.

13. In the **Publish** window, click **Configure**.

14. In the **Publish** window, click **Settings**.

15. In the **Publish** window, expand **Databases**.

16. In the  **Publish** window, under the **Default Connection**, select the **Use this connection string at runtime** check box.

17. In the  **Publish** window, in the box below **Default Connection**, type:
  ```cs
       Server=tcp:Underwater{unique name}.database.windows.net,1433;Initial Catalog=UnderwaterDB;Persist Security Info=False;User ID=Underwateradmin;Password=p@@sw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```
18. In the **Publish** window, expand **Entity Framework Migrations**, and then click **Apply this migration on publish**.

19. In the **Publish** window, expand **Entity Framework Migrations**, and in the box under **Apply this migration on publish**, type:
  ```cs
       Server=tcp:Underwater{unique name}.database.windows.net,1433;Initial Catalog=UnderwaterDB;Persist Security Info=False;User ID=Underwateradmin;Password=p@@sw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

20. In the **Publish** window, click **Save**.

#### Task 4: Deploy the application

1. In the **Underwater - Microsoft Visual Studio** window, in the **Publish** window, click **Publish**.

2. In Microsoft Edge, click **Add Fish**.
 
3. On the **Add a Fish to Aquarium** page, in the **Aquarium** list, select **_&lt;A aquarium of your choice&gt;._**.

4. On the **Add a Fish to Aquarium** page, in the **Fish Name** box, type **_&lt;A fish name of your choice&gt;._**.

5. On the **Add a Fish to Aquarium** page, in the **Scientific Name** box, type **_&lt;A scientific name of your choice&gt;._**.

6. On the **Add a Fish to Aquarium** page, in the **Picture** file chooser, go to **[Repository Root]\Allfiles\Mod14\Labfiles\Images**, click **salmon.jpg**, and then click **Open**.

7. On the **Add a Fish to Aquarium** page, click **Add**.

8. On the **Dive into Our Fish Species** page, verify the newly submitted details.

9. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Details**.

10. View the fish details, and then click **Back**.

11. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

12. On the **Edit Fish** page, in the **Scientic Name** box, type **_&lt;A scientific name of your choice&gt;_** , and then click **Save**.

13. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

14. View the fish details, verify the newly edited fish details, and then click **Back**.

15. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

16. On the **Are you sure you want to delete this?** page, click **Delete**.

17. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

18. In Microsoft Edge, click **Close**.

#### Task 5: Update the application and deploy in Microsoft Azure

1. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, expand **Models**, and then click **Fish.cs**.

2. In the **Fish.cs** code block, locate the following code:
  ```cs
       [Display(Name = "Scientific Name:")]
       public string ScientificName { get; set; }
```

3. Place the cursor after the } (closing curly brace) sign, press Enter,  and then type the following code:
```cs
       [Display(Name = "Common Name:")]
       public string CommonName { get; set; }
```

4. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Aquarium**, and then click **Details.cshtml**.

5. In the **Details.cshtml** code window, locate the following code:
  ```cs
       <div>
            <p class="display-label">
                @Html.DisplayNameFor(model => model.ScientificName)
            </p>
            <br />
            <p class="display-field">
                @Html.DisplayFor(model => model.ScientificName)
            </p>
        </div>
```
6. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
       <div>
            <p class="display-label">
                @Html.DisplayNameFor(model => model.CommonName)
            </p>
            <br />
            <p class="display-field">
                @Html.DisplayFor(model => model.CommonName)
            </p>
       </div>
```

7. In the **Underwater - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Aquarium**, click **Edit.cshtml**.

8. In the **Edit.cshtml** code window, locate the following code:
  ```cs
       <div class="form-group row">
           <label asp-for="ScientificName" class="col-sm-6 col-form-label"></label>
           <div class="col-sm-6">
               <input asp-for="ScientificName" type="text" class="form-control" placeholder="Scientific Name" required>
               <span asp-validation-for="ScientificName"></span>
           </div>
       </div>
```
9. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
       <div class="form-group row">
           <label asp-for="CommonName" class="col-sm-6 col-form-label"></label>
           <div class="col-sm-6">
               <input asp-for="CommonName" type="text" class="form-control" placeholder="Common Name" required>
               <span asp-validation-for="CommonName"></span>
           </div>
       </div>
```
10. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Aquarium**, click **Create.cshtml**.

11. In the **Create.cshtml** code window, locate the following code:
  ```cs
       <div class="form-group row">
           <label asp-for="ScientificName" class="col-sm-6 col-form-label"></label>
           <div class="col-sm-6">
               <input asp-for="ScientificName" type="text" class="form-control" placeholder="Scientific Name" required>
               <span asp-validation-for="ScientificName"></span>
           </div>
       </div>
```
12. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
       <div class="form-group row">
           <label asp-for="CommonName" class="col-sm-6 col-form-label"></label>
           <div class="col-sm-6">
               <input asp-for="CommonName" type="text" class="form-control" placeholder="Common Name" required>
               <span asp-validation-for="CommonName"></span>
           </div>
       </div>
```
13. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Aquarium**, click **Delete.cshtml**.

14. In the **Delete.cshtml** code window, locate the following code:
  ```cs
       <div>
            <p class="display-label">
                @Html.DisplayNameFor(model => model.ScientificName)
            </p>
            <br />
            <p class="display-field">
                @Html.DisplayFor(model => model.ScientificName)
            </p>
        </div>
```
15. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
        <div>
            <p class="display-label">
                @Html.DisplayNameFor(model => model.CommonName)
            </p>
            <br />
            <p class="display-field">
                @Html.DisplayFor(model => model.CommonName)
            </p>
        </div>
```
16. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, expand **Controllers**, and then click **AquariumController.cs**.

17. In the **AquariumController.cs** code block, in the **EditPost** method, select the following code:
  ```cs
        var fishToUpdate = _repository.GetFishById(id);
        bool isUpdated = await TryUpdateModelAsync<Fish>(
                            fishToUpdate,
                            "",
                            f => f.AquariumId,
                            f => f.Name,
                            f => f.ScientificName
                            );
```

18. Replace the selected code with the following code:
```cs
        var fishToUpdate = _repository.GetFishById(id);
        bool isUpdated = await TryUpdateModelAsync<Fish>(
                            fishToUpdate,
                            "",
                            f => f.AquariumId,
                            f => f.Name,
                            f => f.ScientificName,
                            f => f.CommonName
                            );
```

19. In the **Underwater - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**.

20. In **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
      Add-Migration AddFishCommonName
```
21. In **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
      Update-Database
```
>**Note**: In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Migrations**, a new file is created.

22. In the **Underwater - Microsoft Visual Studio** window, open Solution Explorer, right-click **Underwater**, and then click **Publish**.

23. In the **Publish** window, next to the **Publish** button, verify that **Underwater{unique name}** is selected in the drop-down list, and then click **Publish**.

24. In Microsoft Edge, in the menu bar, click **Add Fish**.
 
25. On the **Add a Fish to Aquarium** page, in the **Aquarium** list, select **_&lt;A aquarium of your choice&gt;._**.

26. On the **Add a Fish to Aquarium** page, in the **Fish Name** box, type **_&lt;A fish name of your choice&gt;._**.

27. On the **Add a Fish to Aquarium** page, in the **Scientific Name** box, type **_&lt;A scientific name of your choice&gt;._**.

28. On the **Add a Fish to Aquarium** page, in the **Common Name** box, type **_&lt;A common name of your choice&gt;._**.

29. On the **Add a Fish to Aquarium** page, in the **Picture** file chooser, go to **[Repository Root]\Allfiles\Mod14\Labfiles\Images**, click **tuna.jpg**, and then click **Open**.

30. On the **Add a Fish to Aquarium** page, click **Add**.

31. On the **Dive into Our Fish Species** page, verify the newly submitted details.

32. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Details**.

    >**Note**: The browser displays the common name of the fish.

33. View the fish details, and then click **Back**.

34. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Edit**.

35. On the **Edit Fish** page, in the **Scientic Name** box, type **_&lt;A scientific name of your choice&gt;_**, and then click **Save**.

36. On the **Dive into Our Fish Species** page, select the fish you edited, and then click **Details**.

37. View the fish details, verify the newly edited fish details, and then click **Back**.

38. On the **Dive into Our Fish Species** page, select a fish of your choice, and then click **Delete**.

39. On the **Are you sure you want to delete this?** page, click **Delete**.

40. On the **Dive into Our Fish Species** page, verify that the fish is deleted.

41. In Microsoft Edge, click **Close**.

>**Results**: After completing this exercise, you will be able to deploy your application to Microsoft Azure.

### Exercise 2: Upload an Image to Azure Blob Storage

#### Task 1: Create a blob storage account

1. Open Microsoft Edge.

2. In Microsoft Edge, in the address bar, type **http://portal.azure.com**, and then press Enter.

3.	Sign in, and then click **Storage accounts**.

4.	In the **Storage accounts** window, in the menu bar, click **Add**.

5.	In the **Create storage account** window , in the **Storage account name** box, type **underwater{unique name}**.

    >**Note**: The name must be unique. You can add your first name, last name, or birthdate to the current name.

6. In the **Create storage account** window, under **Resource group**, select **Underwater{unique name}**.

7. In the **Create storage account** window, click **Review + create**.

8.	In the **Create storage account** window, click **Create**.

9. In the **Microsoft.StorageAccount-**{unique number} **- Overview** window, under **RESOURCE**, click **underwater{unique name}**.

10. In the **Underwater{unique name}** window, below **Blob Service**, click **Blobs**.

11. In the **Underwater{unique name}** **- Blobs** window, in the menu bar, click **Container**.

12.	In the **New container** window, in the **Name** box, type **aquarium**.

13. In the **New Container** window, in the **Public Access Level** drop-down list, select **Blob(anonymous read access for blobs only)**, and then click **OK**.

#### Task 2: Prepare the application for working with Azure Storage

1. In the **Underwater – Microsoft Visual Studio** window, in Solution Explorer, right-click **Underwater**,  point to **Add**, and then click **Connected Service**.

2.	In the **Connected Services** window, click **Cloud Storage with Azure Storage**.

3.	In the **Azure Storage** window, sign in to your Azure account.

    >**Note**: In case you are already signed in, you will not see the **Sign in** dialog box. In that case, proceed to the next step.

4.	In the **Azure Storage** window, click  **Underwater{unique name}** , and then click **Add**.

    >Microsoft Edge displays the following URL: https://docs.microsoft.com/en-us/azure/visual-studio/vs-storage-aspnet-getting-started-blobs.

5. In Microsoft Edge, click **Close**.

6. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, click **appsettings.json**.

7.  In **appsettings.json**, locate the following code:
  ```cs
       "ConnectionStrings": {
```

8.  Place the cursor before **"ConnectionStrings"**, press Enter, and then type the following code:
  ```cs
       "ContainerSettings": {
           "ContainerName" :  "aquarium"
       },
```

#### Task 3: Write the code to upload an image

1. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, expand **Models**, and click **Fish.cs**.

2. In the **Fish.cs** code block, locate the following code:
  ```cs
       public string ImageMimeType { get; set; }
```
3. Place the cursor after the **}** (closing curly brace) sign , press Enter, and then type the following code:
  ```cs
       public string ImageURL { get; set; }
```

4. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, expand **Views**, expand **Aquarium**, and then click **Details.cshtml**.

5. In the **Details.cshtml** code window, select the following code:
  ```cs
       @if (Model.ImageName != null)
       {
           <div class="photo-display">
               <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })" />
           </div>
       }
```
6. Replace the selected code with the following code:
  ```cs
       @if (Model.ImageName != null)
       {
           @if (Model.ImageURL != null)
           {
               <div class="photo-display">
                   <img class="photo-display-img" src="@Model.ImageURL" />
               </div>
           }
           else
           {
               <div class="photo-display">
                   <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })" />
               </div>
           }
       }
```

7. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Aquarium**, click **Edit.cshtml**.

8. In the **Edit.cshtml** code window, select the following code:
  ```cs
       <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })" />
```
9. Replace the selected code with the following code:
  ```cs
       @if (Model.ImageURL != null)
       {
           <img class="photo-display-img" src="@Model.ImageURL" />
       }
       else
       {
           <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })" />
       }                  
```
10. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Aquarium**, click **index.cshtml**.

11. In the **index.cshtml** code window, select the following code:
  ```cs
       @if (item.ImageName != null)
       {
           <div>
               <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = item.FishId })" />
           </div>
       }
```
12. Replace the selected code with the following code:
  ```cs
       @if (item.ImageName != null)
       {
           @if (item.ImageURL != null)
           {
               <div class="photo-display">
                   <img class="photo-display-img" src="@item.ImageURL" />
               </div>
           }
           else
           {
               <div class="photo-display">
                   <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = item.FishId })" />
               </div>
           }
       }
```

13. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Views**, under **Aquarium**, click **delete.cshtml**.

14. In the **delete.cshtml** code window, select the following code:
  ```cs
       @if (Model.ImageName != null)
       {
           <div>
               <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })" />
           </div>
       }
```
15. Replace the selected code with the following code:
  ```cs
       @if (Model.ImageName != null)
       {
           @if (Model.ImageURL != null)
           {
                <div>
                    <img class="photo-display-img" src="@Model.ImageURL" />
                </div>
           }
           else
           {
                <div>
                    <img class="photo-display-img" src="@Url.Action("GetImage", "Aquarium", new { Id = Model.FishId })" />
                </div>
           }
       }
```

16. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, right-click **Underwater**, and then click **Manage NuGet Packages**.

17. In the **NuGet Package Manager: Underwater** window, click **Browse**.

18. In the **Search** box, type **WindowsAzure.Storage**, and then press Enter.

19. Click **WindowsAzure.Storage**, select version **9.3.3**, and then click **Install**.

    >**Note**: If you have already installed a previous version of **WindowsAzure.Storage**, the button will display **Update** instead of **Install**.

20. If a **Preview Changes** dialog box appears, click **OK**.

21. If a **License Acceptance** dialog box appears, click **I Accept**.

22. Close the **NuGet Package Manager: Underwater** window.

23. In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Repositories**, click **UnderwaterRepository.cs**.

24. In **UnderwaterRepository.cs**, locate the following code:
  ```cs
       using Underwater.Models;
```

25. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
  ```cs
       using Microsoft.WindowsAzure.Storage;
       using Microsoft.WindowsAzure.Storage.Blob;
       using Microsoft.Extensions.Configuration;
       using Microsoft.AspNetCore.Http;
```

26. In **UnderwaterRepository.cs**, locate the following code:
  ```cs
       private UnderwaterContext _context;
```

27. Ensure that the cursor is at the end of the located code, press Enter, and then type the following code:
  ```cs
       private IConfiguration _configuration;
       private CloudBlobContainer _container;
```

28. In the **UnderwaterRepository.cs** code window, select the following code:
  ```cs
       public UnderwaterRepository(UnderwaterContext context)
       {
           _context = context;
       }
```

29. Replace the selected code with the following code:
  ```cs
       public UnderwaterRepository(UnderwaterContext context, IConfiguration configuration)
       {
           _context = context;
           _configuration = configuration;
           string connectionString = _configuration.GetConnectionString("AzureStorageConnectionString-1");
           string containerName = _configuration.GetValue<string>("ContainerSettings:ContainerName");
           CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
           CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
           _container = blobClient.GetContainerReference(containerName);
       }
```
>**Note**: Make sure the parameter *AzureStorageConnectionString-1* is the same as the name specified in **appsettings.json**. 

30. Ensure that the cursor is at the end of the **PopulateAquariumsDropDownList** method code block, press Enter twice, and then type the following code:
  ```cs
       private async Task<string> UploadImageAsync(IFormFile photo)
       {
           CloudBlockBlob blob = _container.GetBlockBlobReference(Path.GetFileName(photo.FileName));
           await blob.UploadFromStreamAsync(photo.OpenReadStream());
           return blob.Uri.ToString();
       }
```

31. Ensure that the cursor is at the end of the **UploadImageAsync** method code block, press Enter twice, and then type the following code:
  ```cs
       private async Task<bool> DeleteImageAsync(string PhotoFileName)
       {
           CloudBlockBlob blob = _container.GetBlockBlobReference(PhotoFileName);
           await blob.DeleteAsync();
           return true;
       }
```

32. In the **UnderwaterRepository.cs** code window, select the following code:
  ```cs
       public void AddFish(Fish fish)
       {
           if (fish.PhotoAvatar != null && fish.PhotoAvatar.Length > 0)
           {
               fish.ImageMimeType = fish.PhotoAvatar.ContentType;
               fish.ImageName = Path.GetFileName(fish.PhotoAvatar.FileName);
               using (var memoryStream = new MemoryStream())
               {
                   fish.PhotoAvatar.CopyTo(memoryStream);
                   fish.PhotoFile = memoryStream.ToArray();
               }
               _context.Add(fish);
               _context.SaveChanges();
           }
       }
```
33. Replace the selected code with the following code:
  ```cs
       public void AddFish(Fish fish)
       {
           if (fish.PhotoAvatar != null && fish.PhotoAvatar.Length > 0)
           {
               string imageURL = UploadImageAsync(fish.PhotoAvatar).GetAwaiter().GetResult();
               fish.ImageURL = imageURL;
               fish.ImageMimeType = fish.PhotoAvatar.ContentType;
               fish.ImageName = Path.GetFileName(fish.PhotoAvatar.FileName);
               _context.Add(fish);
               _context.SaveChanges();
           }
       }
```

34. In the **UnderwaterRepository.cs** code window, select the following code:
  ```cs
       public void RemoveFish(int id)
       {
           var fish = _context.fishes.SingleOrDefault(f => f.FishId == id);
           _context.fishes.Remove(fish);
           _context.SaveChanges();
       }
```
35. Replace the selected code with the following code:
  ```cs
       public void RemoveFish(int id)
       {
           var fish = _context.fishes.SingleOrDefault(f => f.FishId == id);
           if (fish.ImageURL != null)
           {
               DeleteImageAsync(fish.ImageName).GetAwaiter().GetResult();
           }
           _context.fishes.Remove(fish);
           _context.SaveChanges();
       }
```

36. In the **Underwater - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

37. In the **Underwater - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**.

38. On the **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
       Add-Migration AddFishImageURL
```

39. In **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
       Update-Database
```

>**Note**: In the **Underwater - Microsoft Visual Studio** window, in Solution Explorer, under **Migrations**, a new file is created.

#### Task 4: Deploy and Run the application in Azure

1. In the **UnderWater - Microsoft Visual Studio** window, open Solution Explorer, right-click **Underwater**, and then click **Publish**.

2. In the **Publish** window, next to the **Publish** button, ensure that **Underwater{unique name}** is selected in the drop-down list, and then click **Publish**.

3. In Microsoft Edge, in the menu bar, click **Add Fish**.
 
4. On the **Add a Fish to Aquarium** page, in the **Aquarium** list, select **_&lt;An aquarium of your choice&gt;._**.

5. On the **Add a Fish to Aquarium** page, in the **Fish Name** box, type **_&lt;A fish name of your choice&gt;._**.

6. On the **Add a Fish to Aquarium** page, in the **Scientific Name** box, type **_&lt;A scientific name of your choice&gt;._**.

7. On the **Add a Fish to Aquarium** page, in the **Common Name** box, type **_&lt;A common name of your choice&gt;._**.

8. On the **Add a Fish to Aquarium** page, in the **Picture** file chooser, go to **[Repository Root]\Allfiles\Mod14\Labfiles\Images**, click **clown-trigger.jpg**, and then click **Open**.

9.  On the **Add a Fish to Aquarium** page, click **Add**.

10. On the **Dive into Our Fish Species** page, verify the newly submitted details.

11. Close the **Microsoft Edge** window.

12. In the **UnderWater - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

13. In Microsoft Edge, open a new tab, type **http://portal.azure.com**, and then press Enter.

14. In the portal, on the left-hand side menu, click **Storage Accounts**. 
	
15. In the **Storage accounts** window, click **Underwater{unique name}**.

16.	In the **Underwater{unique name}** window, below **Blob services**, click **Blobs**.

17.	In the **Blobs** window, click **aquarium**.

    >**Note**: Verify the presence of the uploaded image.

18. Click **clown-trigger.jpg**.

19. Click **Edit blob**.

    >**Note**: The uploaded image is displayed.

20. Close Microsoft Edge.

>**Results**: After completing this exercise, you will be able to develop applications that use Azure Blob storage.

©2019 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
