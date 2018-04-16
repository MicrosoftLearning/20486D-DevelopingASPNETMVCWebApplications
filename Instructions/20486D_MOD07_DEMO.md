# Module 7: Using Entity Framework Core in ASP.NET Core

# Lesson 2: Working with Entity Framework Core

### Demonstration: How to Use Entity Framework Core

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod07\Democode\01_EntityFrameworkExample_begin**, and then double-click **EntityFrameworkExample.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane, right-click **EntityFrameworkExample**, point to **Add**, and then click **New Folder**.

2. In the **NewFolder** box, type **Data**, and then press Enter.

3. In the Solution Explorer pane of the **EntityFrameworkExample - Microsoft Visual Studio** window, right-click **Data** folder, point to Add, and then click **class**.

4. In the **Name** box of the **Add New Item – EntityFrameworkExample** dialog box, type **PersonContext**, and then click Add.

5. In the **PersonContext** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
6. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using EntityFrameworkExample.Models;
      using Microsoft.EntityFrameworkCore;    
```
7. In the **PersonContext** class code window, locate the following code.

  ```cs
      public class PersonContext
```
8.  Append the following code to the existing line of code.

  ```cs
      : DbContext
```

9. In the **PersonContext** class code block, press Enter and then type the following code.


  ```cs
      public PersonContext(DbContextOptions<PersonContext> options) 
          :base(options)
      {
      }

      public DbSet<Person> People { get; set; }
```

10. In the Solution Explorer pane of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Startup.cs**.

11. In the **Startup** class code window, locate the following code.

  ```cs
      using Microsoft.Extensions.DependencyInjection;
```
12. Ensure that the mouse cursor is at the end of the  **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code.

  ```cs
      using Microsoft.Extensions.Configuration;
      using EntityFrameworkExample.Data;
      using Microsoft.EntityFrameworkCore; 
```

13. In the **Startup** class code window, locate the following code.

  ```cs
      public void ConfigureServices(IServiceCollection services)
```
14. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
      private IConfiguration _configuration;

      public Startup(IConfiguration configuration)
      {
          _configuration = configuration;
      }
```

15. In the **ConfigureServices** method code block, locate the following code.

  ```cs
      services.AddMvc();
```

16. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
      services.AddDbContext<PersonContext>(options =>
             options.UseInMemoryDatabase("PersonDB"));
```

17. In the Solution Explorer pane, under EntityFrameworkExample, expand **Controllers**, and then click **PersonController.cs**.

18. In the **PersonController** code window, locate the following code.

  ```cs
      using Microsoft.AspNetCore.Mvc;
```
19. Ensure that the mouse cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code.

  ```cs
      using EntityFrameworkExample.Data;
      using EntityFrameworkExample.Models;
```

20. In the **PersonController** code window, locate the following code.

  ```cs
      public IActionResult Index()
```
21. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
      private readonly PersonContext _context;

      public PersonController(PersonContext context)
      {
         _context = context;
         Initialize();
      }

      private void Initialize()
      {
         _context.Database.EnsureCreated();
         if (!_context.People.Any())
         {
             _context.Add(new Person() { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" });
             _context.Add(new Person() { FirstName = "Andrew", LastName = "Tippett", City = "Anaheim", Address = "3163 Nickel Road" });
             _context.SaveChanges();
         }
      }
```

>**Note:** This code block represents initialization sample data into the database.

22. In the **PersonController** class code block, In the **Index** action code block, select the following code.

  ```cs
       return View();
```
23. Replace the selected code with the following code.

  ```cs
       return View(_context.People.ToList());
```
24. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code.

  ```cs
       public IActionResult Edit(int id)
       {
       }
```
25. In the **Edit** action code block, type the following code.

  ```cs
       var person = _context.People.SingleOrDefault(m => m.PersonId == id);
       person.FirstName = "Brandon";
       _context.Update(person);
       _context.SaveChanges();
       return RedirectToAction(nameof(Index));
```
26. Ensure that the cursor is at the end of the **Edit** action code block, press Enter twice, and then type the following code.

  ```cs
       public IActionResult Create()
       {
       }
```
27. In the **Create** action code block, type the following code.

  ```cs
       _context.Add(new Person() { FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
       _context.SaveChanges();
       return RedirectToAction(nameof(Index));
```

28. Ensure that the cursor is at the end of the **Create** action code block, press Enter twice, and then type the following code.

  ```cs
       public IActionResult Delete(int id)
       {
       }
```
29. In the **Delete** action code block, type the following code.

  ```cs
      var person = _context.People.SingleOrDefault(m => m.PersonId == id);
      _context.People.Remove(person);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
```

30. On the **FILE** menu of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Save All**.

31. On the DEBUG menu of the **EntityFrameworkExample - Microsoft Visual Studio** window, click Start Debugging.

      >**Note:** The browser window displays the Index.cshtml page.

32. In the Microsoft Edge window, click **Create New Person**.

33. In the Microsoft Edge window, select a person of your choice and, click **Edit**.

34. In the Microsoft Edge window, select a person of your choice and, click **Delete**.

35. In the Microsoft Edge window, click **Close**.

36. On the **DEBUG** menu of the **EntityFrameworkExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

37. On the **FILE** menu of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Exit**.