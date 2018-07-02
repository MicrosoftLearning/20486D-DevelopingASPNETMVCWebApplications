# Module 7: Using Entity Framework Core in ASP.NET Core

# Lesson 2: Working with Entity Framework Core

### Demonstration: How to Use Entity Framework Core

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

#### Demonstration Steps

1. Navigate to **Allfiles\Mod07\Democode\01_EntityFrameworkExample_begin**, and then double-click **EntityFrameworkExample.sln**.

2. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Data**, and then click **PersonContext.cs**.

3. In the **PersonContext.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```

4. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using EntityFrameworkExample.Models;
      using Microsoft.EntityFrameworkCore; 
```

5. In the **PersonContext.cs** code window, locate the following code:
  ```cs
      public class PersonContext
```

6. Append the following code to the existing line of code:
  ```cs
      : DbContext
```

7. In the **PersonContext.cs** code block, press Enter, and then type the following code:
  ```cs
      public PersonContext(DbContextOptions<PersonContext> options) 
          :base(options)
      {
      }

      public DbSet<Person> People { get; set; }
```
 
8. Place the cursor immediately after the last typed } (closing bracket) sign, press Enter, and then type the following code:
  ```cs
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<Person>().HasData(
            new Person
            {
                PersonId = 1,
                FirstName = "Tara",
                LastName = "Brewer",
                City = "Ocala",
                Address = "317 Long Street"
            },
            new Person
            {
                PersonId = 2,
                FirstName = "Andrew",
                LastName = "Tippett",
                City = "Anaheim",
                Address = "3163 Nickel Road"
            });
      }
```

9. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

10. In the **Startup.cs** code window, locate the following code:
  ```cs
      using Microsoft.Extensions.DependencyInjection;
```

11. Ensure that the cursor is at the end of the  **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
      using Microsoft.EntityFrameworkCore;
      using EntityFrameworkExample.Data;
      using Microsoft.AspNetCore.Builder;
```

12. In the **Startup.cs** code window, place the cursor after the **{** (opening braces) sign of the **ConfigureServices** method, press Enter, and then type the following code:
  ```cs
      services.AddDbContext<PersonContext>(options =>
             options.UseInMemoryDatabase("PersonDB"));
```

13. In the **Startup.cs** code window, locate the following code:
  ```cs
      app.UseStaticFiles();
```

14. Place the cursor before the located code, type the following code, and then press Enter twice.
  ```cs
      personContext.Database.EnsureDeleted();
      personContext.Database.EnsureCreated();
```

15. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **PersonController.cs**.

16. In the **PersonController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```
17. Ensure that the cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
      using EntityFrameworkExample.Data;
      using EntityFrameworkExample.Models;
```

18. In the **PersonController.cs** code window, locate the following code:
  ```cs
      public IActionResult Index()
```

19. Place the cursor before the located code, type the following code, and then press Enter.
  ```cs
      private readonly PersonContext _context;

      public PersonController(PersonContext context)
      {
         _context = context;
      }
```

20. In the **PersonController.cs** code block, in the **Index** action code block, select the following code:
  ```cs
       return View();
```

21. Replace the selected code with the following code:
  ```cs
       return View(_context.People.ToList());
```

22. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Edit(int id)
       {
       }
```

23. In the **Edit** action code block, type the following code:
  ```cs
       var person = _context.People.SingleOrDefault(m => m.PersonId == id);
       person.FirstName = "Brandon";
       _context.Update(person);
       _context.SaveChanges();
       return RedirectToAction(nameof(Index));
```

24. Ensure that the cursor is at the end of the **Edit** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Create()
       {
       }
```

25. In the **Create** action code block, type the following code:
  ```cs
       Person person = _context.People.LastOrDefault();
       int id = person.PersonId + 1;
       _context.Add(new Person() { PersonId = id ,FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
       _context.SaveChanges();
       return RedirectToAction(nameof(Index));
```

26. Ensure that the cursor is at the end of the **Create** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Delete(int id)
       {
       }
```

27. In the **Delete** action code block, type the following code:
  ```cs
      var person = _context.People.SingleOrDefault(m => m.PersonId == id);
      _context.People.Remove(person);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
```

28. In the **EntityFrameworkExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

29. In the **EntityFrameworkExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

      >**Note:** The browser window displays the **Index.cshtml** view.

30. In **Microsoft Edge**, click **Create New Person**.

31. In **Microsoft Edge**, select a person of your choice, and then click **Edit**.

32. In **Microsoft Edge**, select a person of your choice, and then click **Delete**.

33. In **Microsoft Edge**, click **Close**.

34. In the **EntityFrameworkExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

35. In the **EntityFrameworkExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 3: Using Entity Framework Core to Connect to Microsoft SQL Server

### Demonstration: How to Apply the Repository Pattern

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**).

#### Demonstration Steps

1. Navigate to **Allfiles\Mod07\Democode\02_RepositoryExample_begin**, and then double-click **EntityFrameworkExample.sln**.

2. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Repositories**, and then click **IRepository.cs**.

3. In the **IRepository.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```
4. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using EntityFrameworkExample.Models;
```

5. In the **IRepository.cs** code block, press Enter, and then type the following code:
  ```cs
      IEnumerable<Person> GetPeople();
      void CreatePerson();
      void DeletePerson(int id);
      void UpdatePerson(int id);
```

6. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Repositories**, click **MyRepository.cs**.

7. In the **MyRepository.cs** code window, locate the following code:
  ```cs
      using System.Threading.Tasks;
```

8. Ensure that the cursor is at the end of the  **System.Threading.Tasks** namespace, press Enter, and then type the following code:
  ```cs
      using EntityFrameworkExample.Data;
      using EntityFrameworkExample.Models;
```
9. In the **MyRepository.cs** code window, locate the following code:
  ```cs
      public class MyRepository
```
10. Append the following code to the existing line of code:
  ```cs
      : IRepository
```

11. In the **MyRepository.cs** code block, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
      private PersonContext _context;

      public MyRepository(PersonContext context)
      {
            _context = context;
      }
```
12. Ensure that the cursor is at the end of the **MyRepository** method code block, press Enter twice, and then type the following code:
  ```cs
      public void CreatePerson()
      {
           _context.Add(new Person() { FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
           _context.SaveChanges();
      }
```
13. Ensure that the cursor is at the end of the **CreatePerson** method code block, press Enter twice, and then type the following code:
  ```cs
      public void DeletePerson(int id)
      {
          var person = _context.People.SingleOrDefault(m => m.PersonId == id);
          _context.People.Remove(person);
          _context.SaveChanges();
      }
```

14. Ensure that the cursor is at the end of the **DeletePerson** method code block, press Enter twice, and then type the following code:
  ```cs
      public IEnumerable<Person> GetPeople()
      {
           return _context.People.ToList();
      }
```

15. Ensure that the cursor is at the end of the **GetPeople** method code block, press Enter twice, and then type the following code:
  ```cs
      public void UpdatePerson(int id)
      {
           var person = _context.People.SingleOrDefault(m => m.PersonId == id);
           person.FirstName = "Brandon";
           _context.Update(person);
           _context.SaveChanges();
      }
```

16. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

17. In the **Startup.cs** code window, locate the following code:
  ```cs
      using Microsoft.Extensions.DependencyInjection;
```

18. Ensure that the cursor is at the end of the  **Microsoft.Extensions.DependencyInjection** namespace, press Enter, and then type the following code:
  ```cs
      using EntityFrameworkExample.Data;
      using Microsoft.EntityFrameworkCore;
      using EntityFrameworkExample.Repositories;
```

19. In the **Startup.cs** code window, place the cursor after the **{** (opening braces) sign of the **ConfigureServices** method, press Enter, and then type the following code:
  ```cs
      services.AddDbContext<PersonContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<IRepository, MyRepository>();
```

>**Note:** Verify in the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, the appsettings.json that contains the **DefaultConnection** string.

21. In the **Startup.cs** code window, locate the following code:
  ```cs
      app.UseStaticFiles();
```

22. Place the cursor before the located code, type the following code, and then press Enter twice.
  ```cs
      personContext.Database.EnsureDeleted();
      personContext.Database.EnsureCreated();
```

23. In the **EntityFrameworkExample - Microsoft Visual Studio** window, in **Solution Explorer**, expand **Controllers**, and then click **PersonController.cs**.

24. In the **PersonController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```

25. Ensure that the cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
      using EntityFrameworkExample.Repositories;
```

26. In the **PersonController.cs** code window, locate the following code:
  ```cs
      public IActionResult Index()
```

27. Place the cursor before the located code, type the following code, and then press Enter.
  ```cs
      private IRepository _repository;

      public PersonController(IRepository repository)
      {
           _repository = repository;
      }
```

28. In the **PersonController.cs** code block, in the **Index** action code block, select the following code:
  ```cs
       return View();
```
29. Replace the selected code with the following code:
  ```cs
       var list = _repository.GetPeople();
       return View(list);
```

30. Ensure that the cursor is at the end of the **Index** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Edit(int id)
       {
       }
```

31. In the **Edit** action code block, type the following code:
  ```cs
       _repository.UpdatePerson(id);
       return RedirectToAction(nameof(Index));
```

32. Ensure that the cursor is at the end of the **Edit** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Create()
       {
       }
```

33. In the **Create** action code block, type the following code:
  ```cs
       _repository.CreatePerson();
       return RedirectToAction(nameof(Index));
```

34. Ensure that the cursor is at the end of the **Create** action code block, press Enter twice, and then type the following code:
  ```cs
       public IActionResult Delete(int id)
       {
       }
```
35. In the **Delete** action code block, type the following code:
  ```cs
      _repository.DeletePerson(id);
      return RedirectToAction(nameof(Index));
```

36. In the **EntityFrameworkExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

37. In the **EntityFrameworkExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Debugging**.

      >**Note:** The browser window displays the **Index.cshtml** view.

38. In **Microsoft Edge**, click **Create New Person**.

39. In **Microsoft Edge**, select a person of your choice, and then click **Edit**.

40. In **Microsoft Edge**, select a person of your choice, and then click **Delete**.

41. In **Microsoft Edge**, click **Close**.

42. In the **EntityFrameworkExample (Running) - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Stop Debugging**.

43. In the **EntityFrameworkExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.