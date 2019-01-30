# Module 6: Developing Models

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Developing Models

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

Ensure that you have cloned the **20486D** directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course.


### Exercise 1: Adding a Model

#### Task 1: Create a new model

1. Go to **[Repository Root]\Allfiles\Mod06\Labfiles\01_ButterfliesShop_begin**, and then double-click **ButterfliesShop.sln**.

    >**Note**: If a **Security Warning for ButterfliesShop** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **Butterfly.cs**.

3. In the **Butterfly.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
4. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using Microsoft.AspNetCore.Http;
```

5. In the **Butterfly.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       public int Id { get; set; }
       public string CommonName { get; set; }
       public Family? ButterflyFamily { get; set; }
       public int? Quantity { get; set; }
       public string Characteristics { get; set; }
       public DateTime CreatedDate { get; set; }
       public IFormFile PhotoAvatar { get; set; }
       public string ImageName { get; set; }
       public byte[] PhotoFile { get; set; }
       public string ImageMimeType { get; set; }
```

6. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Models**, point to **Add**, and then click **Class**.

7. In the **Add New Item – ButterfliesShop** dialog box, in the **Name** box, type **IndexViewModel**, and then click **Add**.

8. In the **IndexViewModel.cs** code block, place the mouse cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       public List<Butterfly> Butterflies { get; set; }
```

#### Task 2: Use the model in a view

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, and then expand **Butterfly**.

2. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Butterfly**, click **Index.cshtml**.

3. In the **Index.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @model ButterfliesShop.Models.IndexViewModel
```

4. In the **BODY** element of the **Index.cshtml** code window, type the following code:
  ```cs
       <div class="container">
           <h1 class="main-title">Butterflies Shop</h1>
           <p class="into">Welcome to our Web Store, Enjoy a Wide Variety of Butterflies</p>
           <p class="into">Our Butterflies in the Shop</p>
           <button type="button" onclick="location.href='@Url.Action("Create", "Butterfly")'">Add Butterflies</button>
       </div>       
```
5. Place the cursor at the end of the **BUTTON** element you just created, press Enter, and then type the following code:
  ```cs
       <div class="img-container">
          @foreach (var item in Model.Butterflies)
          {
          }
       </div>      
```

6. Place the cursor in the **FOREACH** code block, press Enter, and then type the following code:
  ```cs
       <div class="photo-index-card">
            <p>@item.CommonName</p>
            <p>@item.ButterflyFamily</p>
            <p>@item.Quantity</p>
            <p>@item.CreatedDate</p>
       </div>
```

#### Task 3: Pass the model from the controller to a view

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **ButterflyController.cs**.

2. In the **ButterflyController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
3. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using System.IO;
```

4. Place the cursor at the end of the **InitializeButterfliesData** method code block, press Enter two times, and then type the following code:
  ```cs
       public IActionResult Index()
       {
       }
```

5. In the **Index** action code block, type the following code:
  ```cs
       IndexViewModel indexViewModel = new IndexViewModel();
       indexViewModel.Butterflies = _data.ButterfliesList;
       return View(indexViewModel);
```

####  Task 4: Run the application

1. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the **Index** action result inside the **Butterfly** Controller.

3. In Microsoft Edge, click **Close**.

####  Task 5: Write a GET action

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **ButterflyController.cs**.

2. Place the cursor at the end of the **GetImage** action code block, press Enter two times, and then type the following code:
  ```cs
       [HttpGet]
       public IActionResult Create()
       {
       }
``` 
3. In the **Create** action code block, type the following code:
  ```cs
       return View();
```

####  Task 6: Write a POST action that accepts the model

1. In the **ButterflyController.cs** code window, ensure that the cursor is at the end of the **Create** action code block with **HTTP GET** verb, press Enter, and then type the following code:
  ```cs
       [HttpPost]
       public IActionResult Create(Butterfly butterfly)
       {
       }
```

2. In the **Create** action code block created with **HTTP POST** verb, type the following code, and then press Enter.
  ```cs
       Butterfly lastButterfly = _data.ButterfliesList.LastOrDefault();
       butterfly.CreatedDate = DateTime.Today;
       if (butterfly.PhotoAvatar != null && butterfly.PhotoAvatar.Length > 0)
       {
            butterfly.ImageMimeType = butterfly.PhotoAvatar.ContentType;
            butterfly.ImageName = Path.GetFileName(butterfly.PhotoAvatar.FileName);
            butterfly.Id = lastButterfly.Id + 1;
            _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
            using (var memoryStream = new MemoryStream())
            {
                butterfly.PhotoAvatar.CopyTo(memoryStream);
                butterfly.PhotoFile = memoryStream.ToArray();
            }
            _data.AddButterfly(butterfly);
            return RedirectToAction("Index");
       }
```
3. In the **Create** action code block created with **HTTP POST** verb, immediately after the code you just added, press Enter, and then type the following code:
  ```cs
       return View(butterfly);
```

>**Results**: After completing this exercise, you will be able to create a model, pass the model from an action to a view and use the model in the view. 

### Exercise 2: Working with Forms

#### Task 1: Add display and edit data annotations to a model

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Models**, click **Butterfly.cs**.

2. In the **Butterfly.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Http;
```
3. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Http** namespace, press Enter, and then type the following code:
  ```cs
      using System.ComponentModel.DataAnnotations;
```

4. In the **Butterfly.cs** code window, place the cursor at the end of the **Id** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Common Name:")]
```

5. In the **Butterfly.cs** code window, place the cursor at the end of the **CommonName** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Butterfly Family:")]
```

6. In the **Butterfly.cs** code window, place the cursor at the end of the **ButterflyFamily** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Butterflies Quantity:")]
```

7. In the **Butterfly.cs** code window, place the cursor at the end of the **Quantity** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Characteristics:")]
```

8. In the **Butterfly.cs** code window, place the cursor at the end of the **Characteristics** property code, press Enter two times, and then type the following code:
  ```cs
      [DataType(DataType.DateTime)]
      [Display(Name = "Updated on:")]
      [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
```

9. In the **Butterfly.cs** code window, place the cursor at the end of the **CreatedDate** property code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Butterflies Picture:")]
```

#### Task 2: Update an action to return FileContentResult

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **ButterflyController.cs**.

2. In the **GetImage** action code block, locate the following code:
  ```cs
       Butterfly requestedButterfly = _data.GetButterflyById(id);
       if (requestedButterfly != null)
       {
          return null;
       }
       else
       {
          return NotFound();
       }
```

3. In the **IF** statement code block, select the following code:
  ```cs
       return null;
```

4. Replace the selected code with the following code:
  ```cs
       string webRootpath = _environment.WebRootPath;
       string folderPath = "\\images\\";
       string fullPath = webRootpath + folderPath + requestedButterfly.ImageName;
       if (System.IO.File.Exists(fullPath))
       {
            FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return File(fileBytes, requestedButterfly.ImageMimeType);
       }
       else
       {
            if (requestedButterfly.PhotoFile.Length > 0)
            {
                return File(requestedButterfly.PhotoFile, requestedButterfly.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
       }
```

#### Task 3: Add Display Helpers

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Butterfly**, click **Index.cshtml**.

2. In the **Index.cshtml** code window, select the following code:
  ```cs
       <p>@item.CommonName</p>
       <p>@item.ButterflyFamily</p>
       <p>@item.Quantity</p>
       <p>@item.CreatedDate</p>
```

3. Replace the selected code with the following code:
  ```cs
       <h3 class="display-picture-title">
           "@Html.DisplayFor(modelItem => item.CommonName)"
       </h3>
       @if (item.ImageName != null)
       {     
       }
```
4. In the **IF** code block, type the following code:
  ```cs
       <div class="photo-display">
             <img class="photo-display-img" src="@Url.Action("GetImage", "Butterfly", new { Id = item.Id })" />
       </div>
```

5. Place the cursor at the end of the **IF** code block, press Enter, and then type the following code:
  ```cs
       <div>
            <p class="display-label">
                @Html.DisplayNameFor(model => item.ButterflyFamily)
            </p>
            <br />
            <p class="display-field">
                @Html.DisplayFor(model => item.ButterflyFamily)
            </p>
       </div>
       <div class="display-info">
            <p class="display-label">
                @Html.DisplayNameFor(model => item.Characteristics)
            </p>
            <p class="display-field">
                @Html.DisplayFor(model => item.Characteristics)
            </p>
       </div>
       <div>
            <p class="display-label">
                @Html.DisplayNameFor(model => item.Quantity)
            </p>
            <p class="display-field">
                @Html.DisplayFor(model => item.Quantity)
            </p>
       </div>
       <div>
            <p class="display-label">
                 @Html.DisplayNameFor(model => item.CreatedDate)
            </p>
            <p class="display-field">
                @Html.DisplayFor(model => item.CreatedDate)
            </p>
       </div>
```

#### Task 4: Add Form Helpers

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Butterfly**, click **Create.cshtml**.

2. In the **Create.cshtml** code window, place the cursor at the beginning of the document, type the following code, and then press Enter.
  ```cs
       @using ButterfliesShop.Models
       @model ButterfliesShop.Models.Butterfly
```

3. In the **BODY** element of the **Create.cshtml** code window, type the following code:
  ```cs
       <div class="container">
           <h1 class="main-title">Add Butterflies to the Shop</h1>
           <form method="post" enctype="multipart/form-data" asp-action="Create">  
           </form>
       </div> 
```

#### Task 5: Add Editor Helpers

1. In the **FORM** element of the **Create.cshtml** code window, type the following code:
  ```cs
       <div class="form-field">
            <label asp-for="CommonName"></label>
            <input asp-for="CommonName" />
        </div>
        <div class="form-field">
            <label asp-for="ButterflyFamily"></label>
            <select asp-for="ButterflyFamily" asp-items="Html.GetEnumSelectList<Family>()">
                <option selected="selected" value="">Select</option>
            </select>
        </div>
        <div class="form-field">
            <label asp-for="Characteristics"></label>
            <textarea asp-for="Characteristics"></textarea>
        </div>
        <div class="form-field">
            <label asp-for="Quantity"></label>
            <input asp-for="Quantity" />
        </div>
        <div class="form-field">
            <label asp-for="PhotoAvatar"></label>
            <input asp-for="PhotoAvatar" type="file" />
        </div> 
        <div class="form-field">
            <input type="submit" value="Submit" />
        </div>
```

#### Task 6: Run the application

1. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the **Index** action result inside the **Butterfly** Controller.

3. In Microsoft Edge, click **Add Butterflies**.
 
    >**Note**: The browser displays the **Create** action with **HTTP GET** verb result inside the **Butterfly** Controller.

4. On the **Add Butterflies to The Shop** page, in the **Common Name** box, type _&lt;A butterfly common name of your choice&gt;._

5. On the **Add Butterflies to The Shop** page, in the **Butterfly Family** box, select _&lt;A butterfly family of your choice&gt;._

6. On the **Add Butterflies to The Shop** page, in the **Characteristics** box, type _&lt;A butterfly characteristics of your choice&gt;._

7. On the **Add Butterflies to The Shop** page, in the **Butterflies Quantity** box, type _&lt;A butterflies quantity of your choice&gt;._

8. On the **Add Butterflies to The Shop** page, in the **Butterflies Picture** box, select _&lt;A butterfly picture of your choice from [Repository Root]\AllFiles\Mod06\Labfiles\Images&gt;_, and then click **Submit**.

      >**Note**: Verify that the submitted butterfly details are valid and that a new butterfly was added to the homepage.

9. In Microsoft Edge, click **Close**.

>**Results**: After completing this exercise, you will be able to add data annotations to the **Butterfly** model class in the application and add tag helpers to views. 

### Exercise 3: Adding Validation

#### Task 1: Add validation data annotations to a model

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Models**, click **Butterfly.cs**.

2. In the **Butterfly.cs** code window, in the **CommonName** property code, place the cursor at the end of the **Display** data annotation, press Enter, and then type the following code:
  ```cs
      [Required(ErrorMessage = "Please enter the butterfly name")]
```
3. In the **Butterfly.cs** code window, in the **ButterflyFamily** property code, place the cursor at the end of the **Display** data annotation, press Enter, and then type the following code:
  ```cs
      [Required(ErrorMessage = "Please select the butterfly family")]
```

4. In the **Butterfly.cs** code window, in the **Quantity** property code, place the cursor at the end of the **Display** data annotation, press Enter, and then type the following code:
  ```cs
      [Required(ErrorMessage = "Please select the butterfly quantity")]
```

5. In the **Butterfly.cs** code window, in the **Characteristics** property code, place the cursor at the end of the **Display** data annotation, press Enter, and then type the following code:
  ```cs
      [Required(ErrorMessage = "Please type the characteristics")]
      [StringLength(50)]
```

6. In the **Butterfly.cs** code window, place the cursor at the end of the **Characteristics** property code, and then press Enter two times.

7. In the **Butterfly.cs** code window, in the **PhotoAvatar** property code, place the cursor at the end of the **Display** data annotation, press Enter, and then type the following code:
  ```cs
      [Required(ErrorMessage = "Please select the butterflies picture")]
```
8.  In the **Butterfly.cs** code window, place the cursor at the end of the **PhotoAvatar** property code, and then press Enter.

#### Task 2: Add validation helpers to a view

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Butterfly**, click **Create.cshtml**.

2. In the **Create.cshtml** code window, locate the following code:
  ```cs
      <form method="post" enctype="multipart/form-data" asp-action="Create">
```
3. Place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      <div asp-validation-summary="All"></div>
```

4. In the **Create.cshtml** code window, locate the following code:
  ```cs
      <input asp-for="CommonName" />
```
5. In the **Create.cshtml** code window, place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      <span asp-validation-for="CommonName"></span>
```
6. In the **Create.cshtml** code window, locate the following code:
  ```cs
      <select asp-for="ButterflyFamily" asp-items="Html.GetEnumSelectList<Family>()">
        <option selected="selected" value="">Select</option>
      </select>
```
7. In the **Create.cshtml** code window, place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      <span asp-validation-for="ButterflyFamily"></span>
```
8. In the **Create.cshtml** code window, locate the following code:
  ```cs
      <textarea asp-for="Characteristics"></textarea>
```
9. In the **Create.cshtml** code window, place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      <span asp-validation-for="Characteristics"></span>
```
10. In the **Create.cshtml** code window, locate the following code:
  ```cs
       <input asp-for="Quantity" />
```
11. In the **Create.cshtml** code window, place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      <span asp-validation-for="Quantity"></span>
```

12. In the **Create.cshtml** code window, locate the following code:
  ```cs
       <input asp-for="PhotoAvatar" type="file" />
```
13. In the **Create.cshtml** code window, place the cursor at the end of the located code, press Enter, and then type the following code:
  ```cs
      <span asp-validation-for="PhotoAvatar"></span>
```

#### Task 3: Using the ModelState.IsValid property in a controller

1. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, click **ButterflyController.cs**.

2. In the **Create** action code block created with **HTTP POST** verb, locate the following code:
  ```cs
       [HttpPost]
       public IActionResult Create(Butterfly butterfly)
       {
```
3. Place the cursor after the **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       if (ModelState.IsValid)
       {
```
4. In the **Create** action code block created with **HTTP POST** verb, locate the following code:
  ```cs
       return View(butterfly);
```
5. In the **Create** action code block created with **HTTP POST** verb, immediately after the located code, press Enter, and then type the following code:
  ```cs
       }
       return View(butterfly);
```

#### Task 4: Run the application

1. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the **Index** action result inside the **Butterfly** Controller.

3. In Microsoft Edge, click **Add Butterflies**.
 
    >**Note**: The browser displays the **Create** action with **HTTP GET** verb result inside the **Butterfly** Controller.

4. On the **Add Butterflies to The Shop** page, leave all the boxes blank, and then click **Submit**.

      >**Note**: The browser window displays the **Create.cshtml** view with validation messages below all the boxes.

5. On the **Add Butterflies to The Shop** page, in the **Common Name** box, type _&lt;A butterfly common name of your choice&gt;._.

6. On the **Add Butterflies to The Shop** page, in the **Butterfly Family** box, select _&lt;A butterfly family of your choice&gt;._.

7. On the **Add Butterflies to The Shop** page, in the **Characteristics** box, type _&lt;A butterfly characteristics of your choice&gt;._.

8. On the **Add Butterflies to The Shop** page, in the **Butterflies Quantity** box, type **5**.

9. On the **Add Butterflies to The Shop** page, in the **Butterflies Picture** box, select _&lt;A butterfly picture of your choice from [Repository Root]\AllFiles\Mod06\Labfiles\Images&gt;,_ and then click **Submit**.

      >**Note**: Verify that the submitted butterfly details are valid and that a new butterfly was added to the homepage.

10. In Microsoft Edge, click **Close**.

#### Task 5: Add custom validation

1. In **Solution Explorer**, right-click **ButterfliesShop**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Validators**, and then press Enter.

3. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Validators**, point to **Add**, and then click **Class**.

4. In the **Add New Item – ButterfliesShop** dialog box, in the **Name** box, type **MaxButterflyQuantityValidation**, and then click **Add**.

5. In the **MaxButterflyQuantityValidation.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
6. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using ButterfliesShop.Models;
      using ButterfliesShop.Services;
      using System.ComponentModel.DataAnnotations;
```
7. In the **MaxButterflyQuantityValidation.cs** code window, locate the following code:
  ```cs
      public class MaxButterflyQuantityValidation
```
8.  Append the following code to the existing line of code.
  ```cs
      : ValidationAttribute
```
9. In the **MaxButterflyQuantityValidation.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
      private int _maxAmount;
      public MaxButterflyQuantityValidation(int maxAmount)
      {
         _maxAmount = maxAmount;
      }
```

10. Place the cursor at the end of the **constructor** code block, press Enter two times, type the following code, and then press Enter.
  ```cs
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
      }
```

11. In the **IsValid** method code block, press Enter, and then type the following code:
  ```cs
      var service = (IButterfliesQuantityService)validationContext.GetService(typeof(IButterfliesQuantityService));
      Butterfly butterfly = (Butterfly)validationContext.ObjectInstance;
      if (butterfly.ButterflyFamily != null)
      {
            int? quantity = service.GetButterflyFamilyQuantity(butterfly.ButterflyFamily.Value);
            int? sumQuantity = quantity + butterfly.Quantity;
            if (sumQuantity > _maxAmount)
            {
                return new ValidationResult(string.Format("Limit of butterflies from the same family in the store is {0} butterflies. Currently there are {1}", _maxAmount, quantity));
            }
            return ValidationResult.Success;
      }
      return ValidationResult.Success;
```

12. In the **ButterfliesShop - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Models**, and then click **Butterfly.cs**.

13. In the **Butterfly.cs** code window, locate the following code:
  ```cs
       using System.ComponentModel.DataAnnotations;
```
14. Ensure that the cursor is at the end of the **System.ComponentModel.DataAnnotations** namespace, press Enter, and then type the following code:
  ```cs
       using ButterfliesShop.Validators;
```
15. In the **Butterfly.cs** code window, locate the following code:
  ```cs
      [Required(ErrorMessage = "Please select the butterfly quantity")]
```
16.  Place the cursor below the located code, press Enter, and then type the following code:
  ```cs
      [MaxButterflyQuantityValidation(50)]
```

#### Task 6: Run the application

1. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note**: The browser displays the **Index** action result inside the **Butterfly** Controller.

3. In Microsoft Edge, click **Add Butterflies**.
 
    >**Note**: The browser displays the **Create** action with **HTTP GET** verb result inside the **Butterfly** Controller.

4. On the **Add Butterflies to The Shop** page, in the **Common Name** box, type _&lt;A butterfly common name of your choice&gt;._

5. On the **Add Butterflies to The Shop** page, in the **Butterfly Family** box, select _&lt;A butterfly family of your choice&gt;._

6. On the **Add Butterflies to The Shop** page, in the **Characteristics** box, type _&lt;A butterfly characteristics of your choice&gt;._

7. On the **Add Butterflies to The Shop** page, in the **Butterflies Quantity** box, type **60**.

8. On the **Add Butterflies to The Shop** page, in the **Butterflies Picture** box, select _&lt;A butterfly picture of your choice from [Repository Root]\AllFiles\Mod06\Labfiles\Images&gt;,_ and then click **Submit**.

      >**Note**: The browser window displays the **Create.cshtml** view with custom validation message below the **Butterflies Quantity** box.

9. On the **Add Butterflies to The Shop** page, in the **Butterflies Quantity** box, type **2**.

10. On the **Add Butterflies to The Shop** page, in the **Butterflies Picture** box, select _&lt;A butterfly picture of your choice from [Repository Root]\AllFiles\Mod06\Labfiles\Images&gt;,_ and then click **Submit**.

      >**Note**: Verify that the submitted butterfly details are valid and that a new butterfly was added to the homepage.

11. In Microsoft Edge, click **Close**.

12. In the **ButterfliesShop - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Results**: At the end of this exercise, you have created a **ButterfliesShop** application in which users can submit to the shop variety of butterflies.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
