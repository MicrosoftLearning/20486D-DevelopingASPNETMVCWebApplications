# Module 12: Performance and Communication

# Lab: Performance and Communication

#### Scenario
TODO: Add scenario


#### Objectives

After completing this lab, you will be able to:

- Implement a caching strategy.
- Manage state.
- Add a two-way communication.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

### Exercise 1: Implementing a Caching Strategy

#### Scenario

TODO: Add scenario

The main tasks for this exercise are as follows:

1.	Add a cache tag helper to a view.

2.	Insert data to be cached by the cache tag helper.

3.	Run the application.

4.	Insert items to a memory cache.

5.	Retrieve items from a memory cache.

6.	Run the application.


#### Task 1: Add a cache tag helper to a view.

1. Open the **Command Prompt** window using **Run as administrator**.

2. In Administrator: Command Prompt, run the following command: **cd <The location of Allfiles\Mod12\Labfiles\01_ElectricStore_begin\ElectricStore folder on your machine>**.

3. Run the following command: **npm install**.

4. Close the **Command Prompt** window.

5. Open the **ElectricStore.sln** solution from the following location: **Allfiles\Mod12\Labfiles\01_ElectricStore_begin**.

6. In the **ElectricStore - Microsoft Visual Studio** window, click **TOOLS** and then click **Options**.

7. In the **Options** dialog box, click **Web Package Management**.

8. In the **Locations of external** tools list box, select **$(PATH)**. Press the **Up** arrow button until **$(PATH)** is at the top of the list, and then click **OK**.

9. Open the **package.json** file and examine its content.

    >**Note:** There are dependencies to the 
    **jquery, jquery-validation, jquery-validation-unobtrusive, bootstrap** and **popper.js** packages.

10. In the **_Layout.cshtml** file, in the **UL** element with the **navbar-nav** class, add a **CACHE** element with the following information:

    - vary-by-user: **true**

11. In the **CACHE** element, call the **Component.InvokeAsync** method using the **@await** operator. Pass **"NavbarMenu"** as a parameter to the **InvokeAsync** method.

#### Task 2: Insert data to be cached by the cache tag helper.

1. 

#### Task 3: Run the application

1. 

#### Task 4: Insert items to a memory cache.

1. 

#### Task 5: Retrieve items from a memory cache

1. 

#### Task 6: Run the application
1. 



>**Results**: TODO: Add Results


### Exercise 2: Managing State

#### Scenario

TODO: Add Scenario


The main tasks for this exercise are as follows:

1. Enable working with sessions.

2. Write an action in the first controller.

3. Write the content of the second controller.

4. Run the application and navigate from view to view.


#### Task 1: Enable working with sessions.

1. 

#### Task 2: Write an action in the first controller.

1. 

#### Task 3: Write the content of the second controller.

1. 

#### Task 4: Run the application and navigate from view to view.

1. 

>**Results**: TODO: Add Results


### Exercise 3: Calling a Web API using jQuery

#### Scenario

TODO: Add Scenario


The main tasks for this exercise are as follows:

1. Add a SignalR Hub class named ChatHub.

2. Register the ChatHub in the Startup class.

3. Add a chat view.

4. Write the JavaScript code to connect to the server.

5. Run the application

#### Task 1: Add a SignalR Hub class named ChatHub.

1. 


#### Task 2: Register the ChatHub in the Startup class.

1. 

#### Task 3: Add a chat view.

1. 

#### Task 4: Write the JavaScript code to connect to the server.

1. 

#### Task 5:  Run the application

>**Results**: TODO: Add Results

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
