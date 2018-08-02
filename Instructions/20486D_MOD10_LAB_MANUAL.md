# Module 10: Testing and Troubleshooting

# Lab: Testing and Troubleshooting

#### Scenario

You have been asked to develop a website in a Test Driven Development.
The development process should consist of creating a model or an interface, creating a fake dependency for the test subject, adding a test, and then adding or fixing code while testing.

You have also been asked that when an error occurs the browser would display a detailed exception page on development environment, and a custom error page on production environment.

In addition, You are required to provide Logging in each time an action is called.

#### Objectives

After completing this lab, you will be able to:

- Add a Testing project to an ASP.NET Core MVC application.
- Create a fake dependency for the test subject.
- Add Exception Handling for the different environments. 
- Add Logging to an ASP.NET Core MVC application.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

### Exercise 1: Testing a Model

#### Scenario

You are required to develop an **ASP.NET Core MVC** application in a Test Driven Environment.
In this exercise you will create an **MSTest** Testing project and add it to the solution, add the **ASP.NET Core MVC** website application to its list of dependencies, and then test the **Shirt** model. 

The main tasks for this exercise are as follows:

1.	Add a Testing Project.

2.	Write a test for a model.

3.	Run the unit test – it should fail.

4.	Implement the model class so the test will pass.

5.	Run the unit test – it should pass.


#### Task 1: Write a test for a model

1. From **Allfiles\Mod10\Labfiles\01_ShirtStore_begin**, open the **ShirtStore.sln**.

2. In the **ShirtStore** solution, add a new project with the following information:
    - Project name : **ShirtStoreWebsite.Tests**
    - Project template : **MSTest Test Project (.NET Core)**

3. In the **ShirtStoreWebsite.Tests** project, add a reference of **ShirtStoreWebsite** to its dependencies.

4. Rename the **UnitTest1** class, to **ShirtTest**.

5. In the **ShirtTest** class code block, rename **TestMethod1** to **IsGetFormattedTaxedPriceReturnsCorrectly**.

6. In the **ShirtTest** class, add **using** statements for the following namespaces:
   - **ShirtStoreWebsite.Models**

7. Add a new variable with the following information:
    - Type: **Shirt**
    - Name: **shirt**
    - Value: **new Shirt { Price = 10F }**

8. Add a new variable with the following information:
    - Type: **string**
    - Name: **taxedPrice**
    - Value: **shirt.GetFormattedTaxedPrice(1.2F)**

9. Call the static **AreEqual** method of the **Assert** class, pass **"$12.00"** and the **taxedPrice** variable as parameters to the **AreEqual** method.

10. Save all the changes.

#### Task 2: Run the unit test – it should fail

1. Run all tests.
    >**Note:** The **Test Explorer** displays 1 failed test: **IsGetFormattedTaxedPriceReturnsCorrectly**.

#### Task 3: Implement the model class so the test will pass

1. In the **Shirt** class, replace **GetFormattedTaxedPrice** return value using the following information:
    - Value: **(Price * tax).ToString($"C2", CultureInfo.GetCultureInfo("en-US"))** 

2. Save all the changes.

#### Task 4: Run the unit test – it succeeds

1. Run all tests.
    >**Note:** The **Test Explorer** displays 1 passed test: **IsGetFormattedTaxedPriceReturnsCorrectly**.

>**Results** : After completing this exercise, you will be able to create a Test project and test a model while fixing its code, as in a Test Driven Development environment.

### Exercise 2: Testing a Controller Using a Fake Repository

#### Scenario

After creating a testing project and testing the model, you are now required to test the controller.
In order to do so you will need to create a repository interface as a dependency for the controller to gain access to the data. In order to test the controller, you will create a fake repository as a substitute then provide it to controller via its constructor.

The main tasks for this exercise are as follows:

1.	Create an interface repository.

2.	Implement the interface repository using a fake repository.

3.	Pass the fake repository to the constructor of a controller.

4.	Write a test for a Controller.

5.	Run the unit test – it should fail.

6.	Implement the controller class so the test will pass.


#### Task 1: Create an interface repository

1. Create a new folder with the following information:

    - Folder name: **Services**
    - Parent folder: **ShirtStoreWebsite**

2. Create a new interface with the following information:

     - Folder: **Services**
     - Name:  **IShirtRepository**
     - Scope: **public**

3. In the **IShirtRepository** interface, add **using** statements for the following namespaces:
   - **ShirtStoreWebsite.Models**

4. Declare a method with the following information:
    - Return type: **IEnumerable<Shirt>**
    - Name: **GetShirts**

5. Declare a method with the following information:
    - Return type: **bool**
    - Name: **AddShirt**
    - Parameter: 
        - Type: **Shirt** 
        - Name: **shirt**
    
6. Declare a method with the following information:
    - Return type: **bool**
    - Name: **RemoveShirt**
    - Parameter: 
        - Type: **int** 
        - Name: **id**

#### Task 2: Implement the interface repository using a fake repository

1. Create a new folder with the following information:

    - Folder name: **FakeRepositories**
    - Parent folder: **ShirtStoreWebsite.Tests**

2. Create a new class with the following information:

     - Folder: **FakeRepositories**
     - Name:  **FakeShirtRepository**
     - Scope: **internal**

3. In the **FakeShirtRepository** class, add **using** statements for the following namespaces:
   - **ShirtStoreWebsite.Services**
   - **ShirtStoreWebsite.Models**

4. Modify the **FakeShirtRepository** class to implement the **IShirtRepository** interface.

5. Add a method with the following information:

    - Scope: **public**
    - Return Type: **IEnumerable&lt;Shirt&gt;**
    - Name: **GetShirts**

6. In the **GetShirts** method, return the **IEnumerable&lt;Cupcake&gt;** result using the following information:

    - Value: new List&lt;Shirt&gt;()<br>
    {<br>
            new Shirt { Color = ShirtColor.Black, Size = ShirtSize.S, Price = 11F },<br>
            new Shirt { Color = ShirtColor.Gray, Size = ShirtSize.M, Price = 12F },<br>
            new Shirt { Color = ShirtColor.White, Size = ShirtSize.L, Price = 13F }<br>
    }

7. Add a method with the following information:

    - Scope: **public**
    - Return Type: **bool**
    - Name: **AddShirt**
    - Parameter:
        - Type: **Shirt**
        - Name: **shirt**

8. In the **AddShirt** method, return true.

9. Add a method with the following information:

    - Scope: **public**
    - Return Type: **bool**
    - Name: **RemoveShirt**
    - Parameter:
        - Type: **int**
        - Name: **id**

10. In the **RemoveShirt** method, return true.

#### Task 3: Pass the fake repository to the constructor of a controller

1. In the **ShirtController** class, add **USING** statements for the following namespaces:

      - **ShirtStoreWebsite.Services**

2. In the **ShirtController** class, create a new field with the following information:

   - Scope: **private**
   - Type: **IShirtRepository**
   - Name: **_repository**

3. Add a constructor with the following parameters:

   - Parameter:
        - Type: **IShirtRepository**
        - Name: **repository**

4. In the **ShirtController** constructor, initialize the **_repository** field with the value of the **repository** parameter.

#### Task 4: Write a test for a Controller

1. Open **Package Manager Console**. 

2. In the **Package Manager Console** tab, type the following command: 
    - **Install-Package Microsoft.AspNetCore.Mvc.ViewFeatures -ProjectName ShirtStoreWebsite.Tests**.

3. Create a new class with the following information:

     - Folder: **ShirtStoreWebsite.Tests**
     - Name:  **ShirtControllerTest**
     - Scope: **public**

3. In the **ShirtControllerTest** class, add **using** statements for the following namespaces:
    - **Microsoft.VisualStudio.TestTools.UnitTesting**
    - **Microsoft.AspNetCore.Mvc**
    - **ShirtStoreWebsite.Controllers**
    - **ShirtStoreWebsite.Models**
    - **ShirtStoreWebsite.Services**
    - **ShirtStoreWebsite.Tests.FakeRepositories**

4. Add a **TestClass** attribute to the **ShirtControllerTest** class.

5. Add a method with the following information:

    - Scope: **public**
    - Return Type: **void**
    - Name: **IsIndexReturnsAllShirts**

6. Add a **TestMethod** attribute to the **IsIndexReturnsAllShirts** method.

7. Add a varible named **fakeShirtRepository** of type **IShirtRepository**

9. Initialize the **fakeShirtRepository** variable using the **fakeShirtRepository** constructor.

10. Add a varible named **shirtController** of type **ShirtController**.

11. Initialize the **shirtController** variable using the **shirtController** constructor and pass it the following parameters:
    - **fakeShirtRepository** 

12. Add a varible named **viewResult** of type **ViewResult**.

13. Initialize the **viewResult** variable using the **Index** method of the **shirtController** variable, store the return value as of type **ViewResult** using the **as** operator.

14. Add a varible named **shirts** of type **List&lt;Shirt&gt;**.

15. Initialize the **shirts** variable using the **Model** property of the **viewResult** variable, store the value as of type **List&lt;Shirt&gt;** using the **as** operator.

16. Call the static **AreEqual** method of the **Assert** class, pass the **Count** property of the **shirts** variable and the integer **3**.

17. Save all the changes.

#### Task 4: Run the unit test – it should fail

1. Run all tests.
    >**Note:** The **Test Explorer** displays 1 failed test: **IsIndexReturnsAllShirts**, and 1 passed test: **IsGetFormattedTaxedPriceReturnsCorrectly**.

#### Task 5: Implement the controller class so the test will pass

1. In the **ShirtController** class, in the **Index** action, remove its contents.

2. Add a varible named **shirts** of type **IEnumerable&lt;Shirt&gt;**.

2. Initialize the **shirts** variable using the **GetShirts** method of the **_repository** field. 

3. Return the **ViewResult** result using the **View** method. Pass the **shirts** variable as a parameter to the **View** method.

4. In the **AddShirt** action, at the start of the method's scope, call the **AddShirt** of the **_repository** field. Pass the **shirt** parameter as a parameter to the **AddShirt** method.

5. In the **Delete** action, at the start of the method's scope, call the **RemoveShirt** of the **_repository** field. Pass the **id** parameter as a parameter to the **RemoveShirt** method.

6. Save all the changes.

#### Task 6: Run the unit test – it succeeds

1. Run all tests.
    >**Note:** The **Test Explorer** displays 2 passed tests: **IsIndexReturnsAllShirts** and **IsGetFormattedTaxedPriceReturnsCorrectly**.

>**Results** : After completing this exercise, you will be able to create a test class and test a controller while fixing its code.

### Exercise 3: Implementing a Repository in MVC Project

#### Scenario

#### Task 1: Implement the interface repository in a repository class

#### Task 2: Pass the repository to the controller

#### Task 3: Run the MVC Application

>**Results** : 

### Exercise 4: Adding Exception Handling

#### Scenario

#### Task 1: Add exception handling in Startup.cs

#### Task 2: Run the application in development environment

#### Task 3: Run the application in production environment

>**Results** : 

### Exercise 5: Adding Logging

#### Scenario

#### Task 1: Add logging to the MVC application

#### Task 2: Run the application using IIS Express

>**Results** : 

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.