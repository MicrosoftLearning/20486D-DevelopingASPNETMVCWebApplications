# Module 7: Using Entity Framework Core in ASP.NET Core

# Lesson 2: Working with Entity Framework Core

### Demonstration: How to Use Entity Framework Core

#### Preparation Steps 

1. Ensure that you have cloned the 20486D directory from GitHub. It contains the code segments for this course's labs and demos. 
 https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles.

2. Go to **Allfiles\Mod07\Democode\01_EntityFrameworkExample_begin**, and then double-click **EntityFrameworkExample.sln**.

#### Demonstration Steps

1. In the Solution Explorer pane, under EntityFrameworkExample, expand **Data**, and then click **PersonContext.cs**.

2. In the **PersonContext** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
3. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using EntityFrameworkExample.Models;
      using Microsoft.EntityFrameworkCore;    
```
4. In the **PersonContext** class code window, locate the following code.

  ```cs
      public class PersonContext
```
5.  Append the following code to the existing line of code.

  ```cs
      : DbContext
```

6. In the **PersonContext** class code block, press Enter and then type the following code.


  ```cs
      public PersonContext(DbContextOptions<PersonContext> options) 
          :base(options)
      {
      }

      public DbSet<Person> People { get; set; }
```
 
7. In the Solution Explorer pane, under EntityFrameworkExample, under **Data**, click **DbInitializer.cs**.

8. In the **DbInitializer** class code window, locate the following code.

  ```cs
      using System.Threading.Tasks;
```
9. Ensure that the mouse cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code.

  ```cs
      using EntityFrameworkExample.Models;   
```
10. In the **DbInitializer** class code block, press Enter and then type the following code.

  ```cs
      public static void Initialize(PersonContext context)
      {
          context.Database.EnsureCreated();
          if (context.People.Any())
          {
                return; 
          }

          var people = new Person[]
          {
          new Person { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" },
          new Person { FirstName = "Andrew", LastName = "Tippett", City = "Anaheim", Address = "3163 Nickel Road" }
          };

          foreach (Person p in people)
          {
             context.People.Add(p);
          }
          context.SaveChanges();
      } 
```

11. In the Solution Explorer pane of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Startup.cs**.

12. In the **Startup** class code window, locate the following code.

  ```cs
      using Microsoft.Extensions.DependencyInjection;
```
13. Ensure that the mouse cursor is at the end of the  **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code.

  ```cs
      using Microsoft.Extensions.Configuration;
      using EntityFrameworkExample.Data;
      using Microsoft.EntityFrameworkCore; 
```

14. In the **Startup** class code window, locate the following code.

  ```cs
      public void ConfigureServices(IServiceCollection services)
```
15. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
      private IConfiguration _configuration;

      public Startup(IConfiguration configuration)
      {
          _configuration = configuration;
      }
```

16. In the **ConfigureServices** method code block, locate the following code.

  ```cs
      services.AddMvc();
```

17. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
      services.AddDbContext<PersonContext>(options =>
             options.UseInMemoryDatabase("PersonDB"));
```
18. In the Solution Explorer pane of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Program.cs**.

19. In the **Program** class code window, locate the following code.

  ```cs
      using Microsoft.Extensions.Logging;
```
20. Ensure that the mouse cursor is at the end of the  **Microsoft.Extensions.Logging** namespace, press Enter, and then type the following code.

  ```cs
      using Microsoft.Extensions.DependencyInjection;
      using EntityFrameworkExample.Data;
```

21. In the **Program** class code block, select the following code.

  ```cs
      BuildWebHost(args).Run();
```

22. Replace the selected code with the following code.

  ```cs
      var host = BuildWebHost(args);
      using (var scope = host.Services.CreateScope())
      {
          var services = scope.ServiceProvider;
          try
          {
              var context = services.GetRequiredService<PersonContext>();
              DbInitializer.Initialize(context);
          }
          catch (Exception ex)
          {
              var logger = services.GetRequiredService<ILogger<Program>>();
              logger.LogError(ex, "An error occurred while seeding the database.");
          }
      }
      host.Run();
```

23. In the Solution Explorer pane, under EntityFrameworkExample, expand **Controllers**, and then click **PersonController.cs**.

24. In the **PersonController** code window, locate the following code.

  ```cs
      using Microsoft.AspNetCore.Mvc;
```
25. Ensure that the mouse cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code.

  ```cs
      using EntityFrameworkExample.Data;
      using EntityFrameworkExample.Models;
```

26. In the **PersonController** code window, locate the following code.

  ```cs
      public IActionResult Index()
```
27. Place the mouse cursor before the located code, type the following code, and then press Enter.

  ```cs
      private readonly PersonContext _context;

      public PersonController(PersonContext context)
      {
         _context = context;
      }

```

28. In the **PersonController** class code block, In the **Index** action code block, select the following code.

  ```cs
       return View();
```
29. Replace the selected code with the following code.

  ```cs
       return View(_context.People.ToList());
```
30. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code.

  ```cs
       public IActionResult Edit(int id)
       {
       }
```
31. In the **Edit** action code block, type the following code.

  ```cs
       var person = _context.People.SingleOrDefault(m => m.PersonId == id);
       person.FirstName = "Brandon";
       _context.Update(person);
       _context.SaveChanges();
       return RedirectToAction(nameof(Index));
```
32. Ensure that the cursor is at the end of the **Edit** action code block, press Enter twice, and then type the following code.

  ```cs
       public IActionResult Create()
       {
       }
```
33. In the **Create** action code block, type the following code.

  ```cs
       _context.Add(new Person() { FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
       _context.SaveChanges();
       return RedirectToAction(nameof(Index));
```

34. Ensure that the cursor is at the end of the **Create** action code block, press Enter twice, and then type the following code.

  ```cs
       public IActionResult Delete(int id)
       {
       }
```
35. In the **Delete** action code block, type the following code.

  ```cs
      var person = _context.People.SingleOrDefault(m => m.PersonId == id);
      _context.People.Remove(person);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
```

36. On the **FILE** menu of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Save All**.

37. On the DEBUG menu of the **EntityFrameworkExample - Microsoft Visual Studio** window, click Start Debugging.

      >**Note:** The browser window displays the Index.cshtml page.

38. In the Microsoft Edge window, click **Create New Person**.

39. In the Microsoft Edge window, select a person of your choice and, click **Edit**.

40. In the Microsoft Edge window, select a person of your choice and, click **Delete**.

41. In the Microsoft Edge window, click **Close**.

42. On the **DEBUG** menu of the **EntityFrameworkExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

43. On the **FILE** menu of the **EntityFrameworkExample - Microsoft Visual Studio** window, click **Exit**.