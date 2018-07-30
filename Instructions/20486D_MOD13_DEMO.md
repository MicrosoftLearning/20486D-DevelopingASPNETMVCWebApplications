# Module 13: Implementing Web APIs

# Lesson 1: Introducing Web APIs

### Demonstration: How to Explore a Web API with Microsoft Edge

#### Preparation Steps 

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\01_WebApiExample_begin**, and then double-click **WebApiExample.sln**.

2. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note:** The browser displays **HTTP 404** error. 

3. In **Microsoft Edge**, click **Close**.

4. In the **WebApiExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Properties** click **lanchSettings.json**.

5. In the **lanchSettings.json** code window, select the following code:
  ```cs
       "launchUrl": "api/values",
```
>**Note:** This snippet of code appears twice in the file.  

6. Replace the selected code with the following code:
  ```cs
       "launchUrl": "api/person",
```

7. In **Solution Explorer**, right-click **WebApiExample**, point to **Add**, and then click **New Folder**.

8. In the **NewFolder** text box, type **Controllers**, and then press Enter.

9. In the **WebApiExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Controllers**, point to **Add**, and then click **Controller**.

10. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

11. In the **Add Empty API Controller** dialog box, in the **Controller name** text box, type **PersonController**, and then click **Add**.

12. In the **PersonController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
13. Ensure that the cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using WebApiExample.Models;
```

14. In the **PersonController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private List<Person> _people = new List<Person>();

       public PersonController()
       {
            _people.Add(new Person() {Id = 1, FirstName = "James", LastName = "Sprayberry" });
            _people.Add(new Person() {Id = 2, FirstName = "Jason", LastName = "Mosley" });
            _people.Add(new Person() {Id = 3, FirstName = "Jennifer", LastName = "Dietz" });
            _people.Add(new Person() {Id = 4, FirstName = "Bessie", LastName = "Duppstadt" });
       }
```
15. Ensure that the cursor is at the end of the **PersonController** method code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       public ActionResult<List<Person>> GetAll()
       {
       }
```
16. In the **GetAll** action code block, type the following code:
  ```cs
       return _people;
```
17. Ensure that the cursor is at the end of the **GetAll** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet("{id}")]
       public ActionResult GetLastNameById(int id)
       {
       }
```
18. In the **GetLastNameById** action code block, type the following code:
  ```cs
       var person = _people.FirstOrDefault(p => p.Id == id);

       if (person == null)
       {
            return NotFound();
       }

       return new ObjectResult(person.LastName);
```

19. In the **WebApiExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

20. In the **WebApiExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note:** The browser displays a list of people in **JSON** format.

21. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/api/person/1**, and then press Enter.

    >**Note:** The browser displays the first person's last name in **JSON** format.

22. In **Microsoft Edge**, click **Close**.

23. In the **WebApiExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

# Lesson 2: Developing a Web API

### Demonstration: How to Return Data in XML Format

#### Preparation Steps 

1. Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\02_XmlFormatExample_begin**, and then double-click **XmlFormatExample.sln**.

2. In the **XmlFormatExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **XmlFormatExample**, and then click **Manage NuGet Packages**.

3. In the **NuGet Package Manager: XmlFormatExample** window, click **Browse**.

4. In the **Search** text box, type **Microsoft.AspNetCore.Mvc.Formatters.Xml**, and then press Enter.

5. Click **Microsoft.AspNetCore.Mvc.Formatters.Xml**, select version **2.1.0**, and then click **Install.**

6. If a **Preview Changes** dialog box appears, click **OK**.

7. If a **License Acceptance** dialog box appears, click **I Accept**.

8. Close the **NuGet Package Manager: XmlFormatExample** window.

9. In the **XmlFormatExample - Microsoft Visual Studio** window, in **Solution Explorer**, click **Startup.cs**.

10. In the **Startup.cs** code window, in the **ConfigureServices** method, place the cursor after the **{** (opening braces) sign, press Enter, type the following code, and then press Enter.
  ```cs
      services.AddMvc().AddXmlSerializerFormatters();
```
11. In **Solution Explorer**, right-click **XmlFormatExample**, point to **Add**, and then click **New Folder**.

12. In the **NewFolder** text box, type **Controllers**, and then press Enter.

13. In the **XmlFormatExample - Microsoft Visual Studio** window, in **Solution Explorer**, right-click **Controllers**, point to **Add**, and then click **Controller**.

14. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

15. In the **Add Empty API Controller** dialog box, in the **Controller name** text box, type **AnimalsController**, and then click **Add**.

16. In the **AnimalsController.cs** code window, locate the following code:
  ```cs
       using Microsoft.AspNetCore.Mvc;
```
17. Ensure that the cursor is at the end of the **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
       using XmlFormatExample.Models;
```

18. In the **AnimalsController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
  ```cs
       private List<Animal> _animals = new List<Animal>();

       public AnimalsController()
       {
            _animals.Add(new Animal() { Id = 1, Name = "Lion", Family = "Mammal", Facts = "Lions are found especially in parts of Africa, and they are most active at night." });
            _animals.Add(new Animal() { Id = 2, Name = "Elephant", Family = "Mammal", Facts = "Elephants are intelligent animals and have a very good memories, they also display emotions signs." });
            _animals.Add(new Animal() { Id = 3, Name = "Shark", Family = "Fish", Facts = "Sharks live in the ocean, and average shark has 40-45 teeth" });
       }
```
19. Ensure that the cursor is at the end of the **AnimalsController** method code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       [Produces("application/xml")]
       public ActionResult<List<Animal>> GetAll()
       {
       }
```
20. In the **GetAll** action code block, type the following code:
  ```cs
       return _animals;
```
21. In the **XmlFormatExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Save All**.

22. In the **XmlFormatExample - Microsoft Visual Studio** window, on the **DEBUG** menu, click **Start Without Debugging**.

    >**Note:** The browser displays a list of animals in **XML** format.

23. In **Microsoft Edge**, click **Close**.

24. In the **XmlFormatExample - Microsoft Visual Studio** window, on the **FILE** menu, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.