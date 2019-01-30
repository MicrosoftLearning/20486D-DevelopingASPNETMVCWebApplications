# Module 7: Using Entity Framework Core in ASP.NET Core

Wherever a path to a file starts with *[Repository Root]*, replace it with the absolute path to the folder in which the 20486 repository resides. For example, if you cloned or extracted the 20486 repository to **C:\Users\John Doe\Downloads\20486**, change the path: **[Repository Root]\AllFiles\20486D\Mod01** to **C:\Users\John Doe\Downloads\20486\AllFiles\20486D\Mod01**

# Lab: Using Entity Framework Core in ASP.NET Core

### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

Ensure that you have cloned the 20486D directory from GitHub (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**). It contains the code segments for the labs and demos in this course. 

### Exercise 1: Adding Entity Framework Core 

#### Task 1: Create model classes

1. Go to **[Repository Root]\Allfiles\Mod07\Labfiles\01_Cupcakes_begin**, and then double-click **Cupcakes.sln**.

    >**Note**: If a **Security Warning for Cupcakes** dialog box appears, verify that the **Ask me for every project in this solution** check box is cleared, and then click OK.

2. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Models**, point to **Add**, and then click **Class**.

3. In the **Add New Item – Cupcakes** dialog box, in the **Name** box, type **Cupcake**, and then click **Add**.

4. In the **Cupcake.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
5. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using Microsoft.AspNetCore.Http;
       using System.ComponentModel.DataAnnotations;
       using System.ComponentModel.DataAnnotations.Schema;
```

6. In the **Cupcake.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       [Key]
       public int CupcakeId { get; set; }

       [Required(ErrorMessage = "Please select a cupcake type")]
       [Display(Name = "Cupcake Type:")]
       public CupcakeType? CupcakeType { get; set; }

       [Required(ErrorMessage = "Please enter a cupcake description")]
       [Display(Name = "Description:")]
       public string Description { get; set; }

       [Display(Name = "Gluten Free:")]
       public bool GlutenFree { get; set; }

       [Range(1, 15)]
       [Required(ErrorMessage = "Please enter a cupcake price")]
       [DataType(DataType.Currency)]
       [Display(Name = "Price:")]
       public double? Price { get; set; }

       [NotMapped]
       [Display(Name = "Cupcake Picture:")]
       public IFormFile PhotoAvatar { get; set; }

       public string ImageName { get; set; }

       public byte[] PhotoFile { get; set; }

       public string ImageMimeType { get; set; }

       [Required(ErrorMessage = "Please select a bakery")]
       public int? BakeryId { get; set; }

       public virtual Bakery Bakery { get; set; }
```

7. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Models**, point to **Add**, and then click **Class**.

8. In the **Add New Item – Cupcakes** dialog box, in the **Name** box, type **Bakery**, and then click **Add**.

9. In the **Bakery.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
10. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using System.ComponentModel.DataAnnotations;
```

11. In the **Bakery.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       [Key]
       public int BakeryId { get; set; }

       [StringLength(50, MinimumLength = 4)]
       public string BakeryName { get; set; }

       [Range(1, 40)]
       public int Quantity { get; set; }

       [StringLength(50, MinimumLength = 4)]
       public string Address { get; set; }

       public virtual ICollection<Cupcake> Cupcakes { get; set; }
```

#### Task 2: Create a class that derives from DbContext

1. In **Solution Explorer**, right-click **Cupcakes**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Data**, and then press Enter.

3. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Data**, point to **Add**, and then click **Class**.

4. In the **Add New Item – Cupcakes** dialog box, in the **Name** box, type **CupcakeContext**, and then click **Add**.

5. In the **CupcakeContext.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
6. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using Cupcakes.Models;
      using Microsoft.EntityFrameworkCore;
```

7. In the **CupcakeContext.cs** code window, locate the following code:
  ```cs
      public class CupcakeContext
```

8.  Append the following code to the existing line of code.
  ```cs
      : DbContext
```
9. In the **CupcakeContext.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
      public CupcakeContext(DbContextOptions<CupcakeContext> options) : base(options)
      {
      }

      public DbSet<Cupcake> Cupcakes { get; set; }
      public DbSet<Bakery> Bakeries { get; set; }
```

#### Task 3: Set up Entity Framework Core to use SQLite

1. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Cupcakes**, and then select **Manage NuGet Packages**.

2. In the **NuGet Package Manager: Cupcakes** window, click **Browse**.

3. In the **Search** box, type **Microsoft.EntityFrameworkCore.Sqlite**, and then press Enter.

4. Click **Microsoft.EntityFrameworkCore.Sqlit**, select version **2.1.0**, and then click **Install**.

5. If a **Preview Changes** dialog box appears, click **OK**.

6. If a **License Acceptance** dialog box appears, click **I Accept**.

7. Close the **NuGet Package Manager: Cupcakes** window.

8. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

9. In the **Startup.cs** code window, locate the following code:
  ```cs
      using Microsoft.Extensions.DependencyInjection;
```
10. Ensure that the cursor is at the end of the  **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
      using Microsoft.Extensions.Configuration;
      using Cupcakes.Data;
      using Microsoft.EntityFrameworkCore; 
```

11. In the **Startup.cs** code window, locate the following code:
  ```cs
      public void ConfigureServices(IServiceCollection services)
      
```
12. Place the cursor before the located code, press Enter, press the Up arrow key, type the following code, and then press Enter.
  ```cs
      private IConfiguration _configuration;

      public Startup(IConfiguration configuration)
      {
          _configuration = configuration;
      }
```

13. In the **Startup.cs** code window, in the **ConfigureServices** method, place the cursor after the **{** (opening braces) sign, press Enter, type the following code, and then press Enter.
  ```cs
      services.AddDbContext<CupcakeContext>(options =>
             options.UseSqlite("Data Source=cupcake.db"));
```

14. In the **Startup.cs** code window, select the following code:
  ```cs
       public void Configure(IApplicationBuilder app)
```
15. Replace the selected code with the following code:
  ```cs
       public void Configure(IApplicationBuilder app, CupcakeContext cupcakeContext)
```
   
16. In the **Startup.cs** code window, place the cursor after the first **{** (opening braces) sign of the **Configure** method, press Enter, type the following code, and then press Enter.
  ```cs
      cupcakeContext.Database.EnsureDeleted();
      cupcakeContext.Database.EnsureCreated();
```

#### Task 4: Use OnModelCreating to populate the database

1. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, under **Data**, click **CupcakeContext.cs**.

2. In the **CupcakeContext.cs** code window, locate the following code:
  ```cs
      public DbSet<Cupcake> Cupcakes { get; set; }
      public DbSet<Bakery> Bakeries { get; set; }
```

3. Place the cursor immediately after the last **}** (closing braces) sign, press Enter two times, and then type the following code:
  ```cs
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
      }
```
4. In the **OnModelCreating** method code block, type the following code:
  ```cs
      modelBuilder.Entity<Bakery>().HasData(
          new Bakery
          {
              BakeryId = 1,
              BakeryName = "Gluteus Free",
              Address = "635 Brighton Circle Road",
              Quantity = 8
          },
          new Bakery
          {
              BakeryId = 2,
              BakeryName = "Cupcakes Break",
              Address = "4323 Jerome Avenue",
              Quantity = 22
          },
          new Bakery
          {
              BakeryId = 3,
              BakeryName = "Cupcakes Ahead",
              Address = "2553 Pin Oak Drive",
              Quantity = 18
          },
          new Bakery
          {
              BakeryId = 4,
              BakeryName = "Sugar",
              Address = "1608 Charles Street",
              Quantity = 30
          }
      );
```

5. In the **OnModelCreating** method code block, immediately after the code you just added, press Enter, and then type the following code:
  ```cs
      modelBuilder.Entity<Cupcake>().HasData(
          new Cupcake
          {
              CupcakeId = 1,
              CupcakeType = CupcakeType.Birthday,
              Description = "Vanilla cupcake with coconut cream",
              GlutenFree = true,
              Price = 2.5,
              BakeryId = 1,
              ImageMimeType = "image/jpeg",
              ImageName = "birthday-cupcake.jpg"
          },
          new Cupcake
          {
              CupcakeId = 2,
              CupcakeType = CupcakeType.Chocolate,
              Description = "Chocolate cupcake with caramel filling and chocolate butter cream",
              GlutenFree = false,
              Price = 3.2,
              BakeryId = 2,
              ImageMimeType = "image/jpeg",
              ImageName = "chocolate-cupcake.jpg"
          },
          new Cupcake
          {
              CupcakeId = 3,
              CupcakeType = CupcakeType.Strawberry,
              Description = "Chocolate cupcake with straberry cream filling",
              GlutenFree = false,
              Price = 4,
              BakeryId = 3,
              ImageMimeType = "image/jpeg",
              ImageName = "pink-cupcake.jpg"
          },
          new Cupcake
          {
              CupcakeId = 4,
              CupcakeType = CupcakeType.Turquoise,
              Description = "Vanilla cupcake with butter cream",
              GlutenFree = true,
              Price = 1.5,
              BakeryId = 4,
              ImageMimeType = "image/jpeg",
              ImageName = "turquoise-cupcake.jpg"
          }
      );
```

>**Results**: After completing this exercise, you will be able to add Entity Framework Core to the Cupcake Shop application. 

### Exercise 2: Use Entity Framework Core to Retrieve and Store Data

#### Task 1: Create a repository

1. In **Solution Explorer**, right-click **Cupcakes**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Repositories**, and then press Enter.

3. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Repositories**, point to **Add**, and then click **New Item**.

4. In Navigation, under **ASP.NET Core**, click **Code**, and then, in the result pane, click **Interface**.

5. In the **Name** box, type **ICupcakeRepository**, and then click **Add**.

6. In the **ICupcakeRepository.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
7. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using Cupcakes.Models;
```
8. In the **ICupcakeRepository.cs** code window, select the following code:
  ```cs
    interface ICupcakeRepository
```
9. Replace the selected code with the following code:
  ```cs
    public interface ICupcakeRepository
```
10. In the **ICupcakeRepository.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
      IEnumerable<Cupcake> GetCupcakes();
      Cupcake GetCupcakeById(int id);
      void CreateCupcake(Cupcake cupcake);
      void DeleteCupcake(int id);
      void SaveChanges();
      IQueryable<Bakery> PopulateBakeriesDropDownList();
```

11. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Repositories**, point to **Add**, and then click **Class**.

12. In the **Add New Item – Cupcakes** dialog box, in the **Name** box, type **CupcakeRepository**, and then click **Add**.

13. In the **CupcakeRepository.cs** code window, locate the following code:
  ```cs
       using System.Threading.Tasks;
```
14. Ensure that the cursor is at the end of the **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
       using System.IO;
       using Cupcakes.Data;
       using Cupcakes.Models;
       using Microsoft.EntityFrameworkCore;
```
15. In the **CupcakeRepository.cs** code window, locate the following code:
  ```cs
      public class CupcakeRepository
```
16. Append the following code to the existing line of code:
  ```cs
      : ICupcakeRepository
```

17. In the **CupcakeRepository.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
      private CupcakeContext _context;

      public CupcakeRepository(CupcakeContext context)
      {
          _context = context;
      }
```

18. Ensure that the cursor is at the end of the **constructor** code block, press Enter two times, and then type the following code:
  ```cs
      public IEnumerable<Cupcake> GetCupcakes()
      {
          return _context.Cupcakes.ToList();
      }
```
19. Ensure that the cursor is at the end of the **GetCupcakes** method code block, press Enter two times, and then type the following code:
  ```cs
      public Cupcake GetCupcakeById(int id)
      {
          return _context.Cupcakes.Include(b => b.Bakery)
               .SingleOrDefault(c => c.CupcakeId == id);
      }
```

20. Ensure that the cursor is at the end of the **GetCupcakeById** method code block, press Enter two times, and then type the following code:
  ```cs
      public void CreateCupcake(Cupcake cupcake)
      {
         if (cupcake.PhotoAvatar != null && cupcake.PhotoAvatar.Length > 0)
         {
            cupcake.ImageMimeType = cupcake.PhotoAvatar.ContentType;
            cupcake.ImageName = Path.GetFileName(cupcake.PhotoAvatar.FileName);
            using (var memoryStream = new MemoryStream())
            {
                cupcake.PhotoAvatar.CopyTo(memoryStream);
                cupcake.PhotoFile = memoryStream.ToArray();
            }
             _context.Add(cupcake);
            _context.SaveChanges();
         }
      }
```

21. Ensure that the cursor is at the end of the **CreateCupcake** method code block, press Enter two times, and then type the following code:
  ```cs
      public void DeleteCupcake(int id)
      {
          var cupcake = _context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id);
          _context.Cupcakes.Remove(cupcake);
          _context.SaveChanges();
      }
```

22. Ensure that the cursor is at the end of the **DeleteCupcake** method code block, press Enter two times, and then type the following code:
  ```cs
      public void SaveChanges()
      {  
          _context.SaveChanges();
      }        
```
23. Ensure that the cursor is at the end of the **SaveChanges** method code block, press Enter two times, and then type the following code:
  ```cs
      public IQueryable<Bakery> PopulateBakeriesDropDownList()
      {
          var bakeriesQuery = from b in _context.Bakeries
                                orderby b.BakeryName
                                select b;
          return bakeriesQuery;
      }
```
24. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

25. In the **Startup.cs** code window, locate the following code:
  ```cs
      using Microsoft.EntityFrameworkCore;
```

26. Ensure that the cursor is at the end of the  **Microsoft.EntityFrameworkCore** namespace, press Enter, and then type the following code:
  ```cs
      using Cupcakes.Repositories;
```

27. In the **Startup.cs** code window, in the **ConfigureServices** method, place the cursor after the **{** (opening braces) sign, press Enter, type the following code, and then press Enter.
  ```cs
      services.AddTransient<ICupcakeRepository, CupcakeRepository>();
```

#### Task 2: Update a controller to use a repository

1. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **CupcakeController.cs**.

2. In the **CupcakeController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```
3. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
      using Microsoft.AspNetCore.Hosting;
      using Cupcakes.Models;
      using Cupcakes.Repositories;
      using Microsoft.AspNetCore.Mvc.Rendering;
      using Microsoft.EntityFrameworkCore;
```
4. In the **CupcakeController.cs** code block, locate the following code:
  ```cs
      public IActionResult Index()
      {
           return View();
      }
```

5. Place the cursor before the located code, press Enter, press the Up arrow key, type the following code, and then press Enter.
  ```cs
      private ICupcakeRepository _repository;
      private IHostingEnvironment _environment;

      public CupcakeController(ICupcakeRepository repository, IHostingEnvironment environment)
      {
           _repository = repository;
           _environment = environment;
      }
```

#### Task 3: Use Entity Framework Core to retrieve data

1. In the **CupcakeController.cs** code block, in the **Index** action code block, select the following code:
  ```cs
       return View();
```
2. Replace the selected code with the following code:
  ```cs
       return View(_repository.GetCupcakes());
```

3. Ensure that the cursor is at the end of the **Index** action code block, press Enter two times, and then type the following code:
  ```cs
       public IActionResult Details(int id)
       {
       }
```
4. In the **Details** action code block, type the following code:
  ```cs
       var cupcake = _repository.GetCupcakeById(id);
       if (cupcake == null)
       {
           return NotFound();
       }
       return View(cupcake);
```

5. Ensure that the cursor is at the end of the **Details** action code block, press Enter two times, and then type the following code:
  ```cs
       private void PopulateBakeriesDropDownList(int? selectedBakery = null)
       {
       }
```
6. In the **PopulateBakeriesDropDownList** method code block, type the following code:
  ```cs
       var bakeries = _repository.PopulateBakeriesDropDownList();
       ViewBag.BakeryID = new SelectList(bakeries.AsNoTracking(), "BakeryId", "BakeryName", selectedBakery);
```

#### Task 4: Manipulate data by using Entity Framework Core

1. In the **CupcakeController.cs** code block, locate the following code:
  ```cs
       public IActionResult Details(int id)
       {
            var cupcake = _repository.GetCupcakeById(id);
            if (cupcake == null)
            {
                return NotFound();
            }
            return View(cupcake);
       }
```

2. Place the cursor at the end of the located code, press Enter,  type the following code, and then press Enter two times.
  ```cs
       [HttpGet]
       public IActionResult Create()
       {
       }
```

3. In the **Create** action code block, type the following code:
  ```cs
       PopulateBakeriesDropDownList();
       return View();
```
4. Ensure that the cursor is at the end of the **Create** action code block, press Enter two times, and then type the following code:
  ```cs
       [HttpPost, ActionName("Create")]
       public IActionResult CreatePost(Cupcake cupcake)
       {
       }
```

5. In the **CreatePost** method code block, type the following code:
  ```cs
       if (ModelState.IsValid)
       {
            _repository.CreateCupcake(cupcake);
            return RedirectToAction(nameof(Index));
       }
       PopulateBakeriesDropDownList(cupcake.BakeryId);
       return View(cupcake);
```

6. Ensure that the cursor is at the end of the **CreatePost** method code block, press Enter two times, and then type the following code:
  ```cs
       [HttpGet]
       public IActionResult Edit(int id)
       {
       }
```

7. In the **Edit** action code block, type the following code:
  ```cs
       Cupcake cupcake = _repository.GetCupcakeById(id);
       if (cupcake == null)
       {
            return NotFound();
       }
       PopulateBakeriesDropDownList(cupcake.BakeryId);
       return View(cupcake);
```

8. Ensure that the cursor is at the end of the **Edit** action code block, press Enter two times, and then type the following code:
  ```cs
       [HttpPost, ActionName("Edit")]
       public async Task<IActionResult> EditPost(int id)
       {
       }
```
9. In the **EditPost** method code block, type the following code:
  ```cs
       var cupcakeToUpdate = _repository.GetCupcakeById(id);
       bool isUpdated = await TryUpdateModelAsync<Cupcake>(
                                cupcakeToUpdate,
                                "",
                                c => c.BakeryId, 
                                c => c.CupcakeType, 
                                c => c.Description, 
                                c => c.GlutenFree,
                                c => c.Price);
       if (isUpdated == true)
       {
            _repository.SaveChanges();
            return RedirectToAction(nameof(Index));
       }
       PopulateBakeriesDropDownList(cupcakeToUpdate.BakeryId);
       return View(cupcakeToUpdate);
```

10. Ensure that the cursor is at the end of the **EditPost** action code block, press Enter two times, and then type the following code:
  ```cs
       [HttpGet]
       public IActionResult Delete(int id)
       {
       }
```

11. In the **Delete** method code block, type the following code:
  ```cs
       var cupcake = _repository.GetCupcakeById(id);
       if (cupcake == null)
       {
            return NotFound();
       }
       return View(cupcake);
```

12. Ensure that the cursor is at the end of the **Delete** action code block, press Enter two times, and then type the following code:
  ```cs
       [HttpPost, ActionName("Delete")]
       public IActionResult DeleteConfirmed(int id)
       {
       }
```
13. In the **DeleteConfirmed** method code block, type the following code:
  ```cs
       _repository.DeleteCupcake(id);
       return RedirectToAction(nameof(Index));
```

#### Task 5: Run the application

1. In the **Cupcakes - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. On the **DEBUG** menu, click **Start Without Debugging**.

3. In Microsoft Edge, click **Add Cupcake**.
 
    >**Note**: The browser displays the **Create** action inside the **CupcakesController**.

4. On the **Add a Cupcake to the Shop** page, in the **Bakery** list, select **&lt;A bakery of your choice&gt;**.

5. In the **Cupcake Type** list, select **&lt;A cupcake type of your choice&gt;**.

6. In the **Description** box, type **&lt;A cupcake description of your choice&gt;**.

7. In the **Gluten Free** box, check **&lt;Choose if the cupcake is a gluten-free&gt;**.

8. In the **Price** box, type **&lt;A cupcake price of your choice between 1 and 15&gt;**.

9. In the **Cupcake Picture** box, import an image from **[Repository Root]\Allfiles\Mod07\Labfiles\Image\strawberry-cupcake.jpg**, and then click **Submit**.

10. On the **Welcome to our Cupcakes Shop** page, verify the newly submitted cupcake details.

11. Select a cupcake of your choice, and then click **Details**.

12. View the cupcake details, and then click **Back to List**.

13. On the **Welcome to our Cupcakes Shop** page, select a cupcake of your choice, and then click **Edit**.

14. On the **Edit a Cupcake** page, in the **Price** box, type **&lt;A cupcake price of your choice between 1 and 15&gt;**, and then click **Save**.

15. On the **Welcome to our Cupcakes Shop** page, select the cupcake you edited, and then click **Details**.

16. On the **Cupcake's Details** page, verify the newly edited cupcake details, and then click **Back to List**.

17. On the **Welcome to our Cupcakes Shop** page, select a cupcake of your choice, and then click **Delete**.

18. On the **Are you sure you want to delete?** page, click **Delete**.

19. On the **Welcome to our Cupcakes Shop** page, verify that the cupcake is deleted.

20. In Microsoft Edge, click **Close**.

>**Results**: After completing this exercise, you will be able to use Entity Framework Core to retrieve and store data through a repository in the **CupcakeController**. 

### Exercise 3: Use Entity Framework Core to Connect to Microsoft SQL Server

#### Task 1: Connect to a Microsoft SQL Server

1. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

2. In the **Startup.cs** code window, select the following code:
  ```cs
      services.AddDbContext<CupcakeContext>(options =>
                 options.UseSqlite("Data Source=cupcake.db"));
```
3. Replace the selected code with the following code:
  ```cs
      string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true";
      services.AddDbContext<CupcakeContext>(options =>
                 options.UseSqlServer(connectionString));
```

4. In the **Startup.cs** code window, select the following code:
  ```cs
       public void Configure(IApplicationBuilder app, CupcakeContext cupcakeContext)
```
5. Replace the selected code with the following code:
  ```cs
       public void Configure(IApplicationBuilder app)       
```

6. In the **Startup.cs** code window, delete the following code:
  ```cs
      cupcakeContext.Database.EnsureDeleted();
      cupcakeContext.Database.EnsureCreated();
```

#### Task 2: Specify a connection string in a configuration file

1. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Cupcakes**, point to **Add**, and then click **New Item**.

2. In the **Add New Item - Cupcakes** dialog box, in the navigation pane, under **Installed**, click **ASP.NET Core**. In the result pane, click **App Settings File**, and then click **Add**.

3. In the **appsettings.json** code window, select the following code:
  ```cs
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=_CHANGE_ME;Trusted_Connection=True;MultipleActiveResultSets=true"
```

4. Replace the selected code with the following code:
  ```cs
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
``` 
5. In the **Startup.cs** code window, select the following code:
  ```cs
      string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true";
      services.AddDbContext<CupcakeContext>(options =>
                 options.UseSqlServer(connectionString));
```
6. Replace the selected code with the following code:
  ```cs
      services.AddDbContext<CupcakeContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
```
#### Task 3: Use Migrations to create a database

1. In the **Cupcakes - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**.

2. In **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
      Add-Migration InitialCreate
```
>**Note**: In **Solution Explorer**, verify if a new folder named **Migrations** is created with multiple files.

3. In the **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
      Update-Database
```
4. In the **Cupcakes - Microsoft Visual Studio** window, on the **VIEW** menu, click **SQL Server Object Explorer**.

5. In **SQL Server Object Explorer**, expand **(localdb)\MSSQLLocalDB**, expand **Databases**, and then expand **BakeriesDb**.

>**Note**: View the **BakeriesDb** tables.

#### Task 4: Run the application

1. In the **Cupcakes - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. On the **DEBUG** menu, click **Start Without Debugging**.

3. In Microsoft Edge, click **Add Cupcake**.
 
    >**Note**: The browser displays the **Create** action inside the **CupcakesController**.

4. On the **Add a Cupcake to the Shop** page, in the **Bakery** list, select **&lt;A bakery of your choice&gt;**.

5. In the **Cupcake Type** list, select **&lt;A cupcake type of your choice&gt;**.

6. In the **Description** box, type **&lt;A cupcake description of your choice&gt;**.

7. In the **Gluten Free** box, check **&lt;Choose if the cupcake is a gluten-free&gt;**.

8. In the **Price** box, type **&lt;A cupcake price of your choice between 1 and 15&gt;**.

9. In the **Cupcake Picture** box, import an image from **[Repository Root]\Allfiles\Mod07\Labfiles\Image\strawberry-cupcake.jpg**, and then click **Submit**.

10. On the **Welcome to our Cupcakes Shop** page, verify the newly submitted cupcake details.

11. Select a cupcake of your choice, and then click **Details**.

12. View the cupcake details, and then click **Back to List**.

13. On the **Welcome to our Cupcakes Shop** page, select a cupcake of your choice, and then click **Edit**.

14. On the **Edit a Cupcake** page, in the **Price** box, type **&lt;A cupcake price of your choice between 1 and 15&gt;** , and then click **Save**.

15. On the **Welcome to our Cupcakes Shop** page, select the cupcake you edited, and then click **Details**.

16. On the **Cupcake's Details** page, verify the newly edited cupcake details, and then click **Back to List**.

17. On the **Welcome to our Cupcakes Shop** page, select a cupcake of your choice, and then click **Delete**.

18. On the **Are you sure you want to delete?** page, click **Delete**.

19. On the **Welcome to our Cupcakes Shop** page, verify that the cupcake is deleted.

20. In Microsoft Edge, click **Close**.

#### Task 5: Use Migrations to update the database schema 

1. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, under **Models**, click **Cupcake.cs**.

2. In the **Cupcake.cs** code window, locate the following code:
  ```cs
      [Display(Name = "Gluten Free:")]
      public bool GlutenFree { get; set; }
```
3. Place the cursor at the end of the located code, press Enter two times, and then type the following code:
  ```cs
      [Display(Name = "Caloric Value:")]
      public int CaloricValue { get; set; }
```
4. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, under **Data**, click **CupcakeContext.cs**.

5. In the **CupcakeContext.cs** code window, in the **OnModelCreating** method code block, select the following code:
  ```cs
      ImageName = "birthday-cupcake.jpg"
```
6. Replace the selected code with the following code:
  ```cs
      ImageName = "birthday-cupcake.jpg",
      CaloricValue = 355
```

7. In the **OnModelCreating** method code block, select the following code:
  ```cs
      ImageName = "chocolate-cupcake.jpg"
```

8. Replace the selected code with the following code:
  ```cs
      ImageName = "chocolate-cupcake.jpg",
      CaloricValue = 195
```

9. In the **OnModelCreating** method code block, select the following code:
  ```cs
      ImageName = "pink-cupcake.jpg"
```

10. Replace the selected code with the following code:
  ```cs
      ImageName = "pink-cupcake.jpg",
      CaloricValue = 295
```
11. In the **OnModelCreating** method code block, select the following code:
  ```cs
      ImageName = "turquoise-cupcake.jpg"
```

12. Replace the selected code with the following code:
  ```cs
      ImageName = "turquoise-cupcake.jpg",
      CaloricValue = 360
```

13. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Views**, expand **Cupcake**, and then click **Details.cshtml**.

14. In the **Details.cshtml** code window, locate the following code:
  ```cs
      <div>
          <p class="display-label">
                @Html.DisplayNameFor(model => model.Price)
          </p>
          <p class="display-field">
                @Html.DisplayFor(model => model.Price)
          </p>
      </div>
```
15. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
      <div>
          <p class="display-label">
                @Html.DisplayNameFor(model => model.CaloricValue)
          </p>
          <p class="display-field">
                @Html.DisplayFor(model => model.CaloricValue)
          </p>
      </div>
```
16. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Cupcake**, click **Edit.cshtml**.

17. In the **Edit.cshtml** code window, locate the following code:
  ```cs
      <div class="form-field">
          <label asp-for="Price"></label>
          <input asp-for="Price" />
          <span asp-validation-for="Price"></span>
      </div>
```
18. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
      <div class="form-field">
          <label asp-for="CaloricValue"></label>
          <input asp-for="CaloricValue" />
          <span asp-validation-for="CaloricValue"></span>
      </div>
```
19. In the **Cupcakes - Microsoft Visual Studio** window, in **Solution Explorer**, under **Views**, under **Cupcake**, click **Create.cshtml**.

20. In the **Create.cshtml** code window, locate the following code:
  ```cs
      <div class="form-field">
          <label asp-for="Price"></label>
          <input asp-for="Price" />
          <span asp-validation-for="Price"></span>
      </div>
```
21. Place the cursor after the **>** (greater than) sign of the **&lt;/div&gt;** tag, press Enter, and then type the following code:
  ```cs
      <div class="form-field">
          <label asp-for="CaloricValue"></label>
          <input asp-for="CaloricValue" />
          <span asp-validation-for="CaloricValue"></span>
      </div>
```
22. In the **Cupcakes - Microsoft Visual Studio** window, on the **TOOLS** menu, point to **NuGet Package Manager**, and then click **Package Manager Console**.

23. In the **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
      Add-Migration AddCupcakeCaloricValue
```
>**Note**: In **Solution Explorer**, under **Migrations**, verify if a new file is created.

24. In **Package Manager Console** tab, type the following command, and then press Enter.
  ```cs
      Update-Database
```
#### Task 6: Run the application

1. In the **Cupcakes - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

2. On the **DEBUG** menu, click **Start Without Debugging**.

3. Select a cupcake of your choice, and then click **Details**.

    >**Note**: The browser displays the caloric value of the cupcake. 

4. View the cupcake details, and then click **Back to List**.

5. In Microsoft Edge, click **Close**.

6. In the **Cupcakes - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

>**Results**: After completing this exercise, you should have created a cupcakes shop application in which users can add a new cupcake, edit a cupcake, delete a cupcake and view a cupcake’s details.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.