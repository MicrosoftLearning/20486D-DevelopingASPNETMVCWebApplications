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

In this exercise, you will create a test project to the ASP.NET Core MVC application, then you will add a test class to test the **Product** model, find the problem and then fix it.

#### Task 1: Write a test for a model

1. From **Allfiles\Mod10\Labfiles\01_ShirtStore_begin**, open the **ShirtStore.sln**.

2. In the **ShirtStore** solution, add a new project with the following information:
    - Project name : **ShirtStoreWebsite.Tests**
    - Project template : **MSTest Test Project (.NET Core)**

3. In the **ShirtStoreWebsite.Tests** project, add a reference of **ShirtStoreWebsite** to its dependencies.

4. Rename the **UnitTest1** class, to **ShirtTest**.

5. In the **ShirtTest** class code block, rename **TestMethod1** to **IsGetFormattedTaxedPriceReturnsCorrectly**.

6. 

#### Task 2: Run the unit test – it should fail

#### Task 3: Implement the model class so the test will pass

#### Task 4: Run the unit test – it succeeds

>**Results** : 

### Exercise 2: Testing a Controller Using a Fake Repository

#### Scenario

#### Task 1: Create an interface repository

#### Task 2: Implement the interface repository using a fake repository

#### Task 3: Pass the fake repository to the constructor of a controller

#### Task 4: Run the unit test – it should fail

#### Task 5: Implement the controller class so the test will pass

#### Task 6: Run the unit test – it succeeds

>**Results** : 

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