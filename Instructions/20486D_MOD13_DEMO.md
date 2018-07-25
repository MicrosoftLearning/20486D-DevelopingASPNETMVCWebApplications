# Module 13: Implementing Web APIs

# Lesson 1: Introducing Web APIs

### Demonstration: How to Explore a Web API with Microsoft Edge

#### Preparation Steps 

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to **Allfiles\Mod13\Democode\01_WebApiExample_begin**, and then double-click **WebApiExample.sln**.

2. In **Solution Explorer**, right-click **WebApiExample**, point to **Add**, and then click **New Folder**.

3. In the **NewFolder** text box, type **Controllers**, and then press Enter.

4. In the **WebApiExample - Microsoft Visual Studio** window, in **Solution Explorer**, under **Controllers**, right-click **Controllers**, point to **Add**, and then click **Controller**.

5. In the **Add Scaffold** dialog box, click **API Controller - Empty**, and then click **Add**.

6. In the **Add Empty API Controller** dialog box, in the **Controller name** text box, type **PersonController**, and then click **Add**.

7. In the **PersonController.cs** code window, locate the following code:
  ```cs
      using Microsoft.AspNetCore.Mvc;
```
8. Ensure that the cursor is at the end of the  **Microsoft.AspNetCore.Mvc** namespace, press Enter, and then type the following code:
  ```cs
      using WebApiExample.Models;
```

9. In the **PersonController.cs** code window, place the cursor after the second **{** (opening braces) sign, press Enter, and then type the following code:
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
10. Ensure that the cursor is at the end of the **PersonController** method code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet]
       public ActionResult<List<Person>> GetAll()
       {
       }
```
11. In the **GetAll** action code block, type the following code:
  ```cs
       return _people;
```
12. Ensure that the cursor is at the end of the **GetAll** action code block, press Enter twice, and then type the following code:
  ```cs
       [HttpGet("/api/person/{id}")]
       public ActionResult GetLastNameById(int id)
       {
       }
```
13. In the **GetLastNameById** action code block, type the following code:
  ```cs
       var person = _people.FirstOrDefault(p => p.Id == id);

       if (person == null)
       {
            return NotFound();
       }

       return new ObjectResult(person.LastName);
```

14. On the **FILE** menu of the **WebApiExample - Microsoft Visual Studio** window, click **Save All**.

15. On the **DEBUG** menu of the **WebApiExample - Microsoft Visual Studio** window, click **Start Debugging**.

    >**Note:** The browser displays a list of people in **JSON** format.

16. In **Microsoft Edge**, in the address bar, type **http://localhost:[port]/api/person/1**, and then press Enter.

    >**Note:** The browser displays the first person in **JSON** format.

17. In the Microsoft Edge window, click **Close**.

18. On the **DEBUG** menu of the **WebApiExample (Running) - Microsoft Visual Studio** window, click **Stop Debugging**.

19. On the **FILE** menu of the **WebApiExample - Microsoft Visual Studio** window, click **Exit**.

©2018 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.