# Tasks App

A simple ASP.NET MVC application demonstrating a clean **3-Tier Architecture**, the **Repository Pattern**, **Dependency Injection**, and **Separation of Concerns**.

The goal of this project is not only to build a working ToDo application, but also to demonstrate how a real-world ASP.NET MVC application should be structured. Each layer has a single responsibility, making the application easier to understand, maintain, test, and extend.

---

# Application Architecture

The application follows a layered architecture where every layer has a specific responsibility.

```
Browser
    │
    ▼
Controller
    │
    ▼
Service
    │
    ▼
Repository
    │
    ▼
Database
```

Once the database returns the requested data, it travels back through the same layers until it reaches the user.

```
Database
    │
    ▼
Repository
    │
    ▼
Service
    │
    ▼
Controller
    │
    ▼
View
```

This means every request follows exactly the same path.

---

# Understanding Each Layer

## Controllers

Controllers are the **entry point** of the application.

Whenever a user clicks a button, submits a form, or visits a page, the request reaches a controller first.

Examples:

* Display all tasks
* Create a new task
* Edit an existing task
* Delete a task

A controller should remain as small as possible.

Its responsibilities are:

* Receive HTTP requests
* Validate simple input (when appropriate)
* Call the correct service
* Return a View or redirect to another action

A controller **should not**:

* Access the database
* Contain SQL queries
* Contain business logic
* Decide how data is stored

Example:

```csharp
public IActionResult Index()
{
    var tasks = _taskService.GetAllTasks();
    return View(tasks);
}
```

Notice that the controller simply asks the service for data. It doesn't know where the data comes from.

---

## Services

Services contain the application's **business logic**.

Business logic means the rules that define how the application should behave.

Examples include:

* A task title cannot be empty.
* A completed task should display a different status.
* Duplicate tasks may not be allowed.
* Certain users may have different permissions.

Instead of placing these rules inside controllers, they are placed inside services.

The service acts as the coordinator of the application.

```
Controller
     │
     ▼
 Service
     │
     ▼
Repository
```

The service decides:

* Which repository method should be called.
* Whether additional validation is required.
* Whether data should be transformed before returning it.

---

## Repository

The repository is responsible for **data access**.

It is the **only layer allowed to communicate with the database**.

Typical responsibilities include:

* Reading data
* Saving data
* Updating data
* Deleting data

```
Repository
      │
      ▼
Database
```

No controller should ever access the database directly.

No service should ever execute SQL.

Keeping all database operations inside repositories makes the application much easier to maintain.

Imagine that tomorrow you decide to replace SQL Server with another database.

Instead of changing every controller in the application, you only update the repository layer.

---

# Why We Don't Skip Layers

A common beginner question is:

> "Why can't the controller just call the repository directly?"

Although it may seem simpler for a small application, it quickly becomes difficult to maintain.

Correct flow:

```
Controller
      │
      ▼
Service
      │
      ▼
Repository
      │
      ▼
Database
```

Incorrect flow:

```
Controller
      │
      ▼
Repository
```

If controllers start calling repositories directly:

* Business logic becomes duplicated.
* Different controllers may implement rules differently.
* Testing becomes harder.
* Code becomes tightly coupled.
* The project becomes difficult to extend.

Every layer exists for a reason, so in a 3-tier architecture we should not skip layers.

---

# Domain Models

Domain Models represent the data stored in the database.

Usually, there is one Domain Model for each database table.

Example:

```csharp
public class Task
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsCompleted { get; set; }
}
```

Repositories work directly with Domain Models because they represent the database structure.

---

# Why Controllers Should Not Use Domain Models

Although Domain Models represent database entities, they should **not** be passed directly to Views.

Instead, the Service layer converts them into objects designed specifically for presentation.

This process is called **mapping**.

```
Database

↓

Domain Model

↓

Service (Mapping)

↓

View Model / DTO

↓

Controller

↓

View
```

Keeping Domain Models inside the Service and Repository layers protects the rest of the application from changes in the database structure.

---

# View Models

A View Model contains only the information required by a specific page.

For example, the database may contain many columns:

```
Id
Title
CreatedDate
ModifiedDate
Deleted
CreatedBy
LastModifiedBy
```

The page might only need:

```
Title
Status
```

Instead of sending unnecessary information to the View, the Service creates a View Model containing only the required properties.

Example:

```csharp
public class TaskViewModel
{
    public string Title { get; set; }

    public string Status { get; set; }
}
```

Views become simpler because they only receive the data they need.

---

# DTOs (Data Transfer Objects)

DTO stands for **Data Transfer Object**.

DTOs are used when transferring data between layers.

For example, when creating a task:

```csharp
public class CreateTaskDto
{
    public string Title { get; set; }
}
```

The controller receives the DTO from the user and passes it to the Service.

The Service then converts the DTO into a Domain Model before saving it.

```
User Input

↓

DTO

↓

Service

↓

Domain Model

↓

Repository

↓

Database
```

Using DTOs prevents controllers from depending on database entities.

---

# Views

Views are responsible only for displaying data.

They should never:

* Connect to the database
* Contain business rules
* Decide how data should be stored

A View simply receives a View Model and displays it.

Example:

```cshtml
@foreach(var task in Model)
{
    <p>@task.Title</p>
}
```

The View doesn't know where the data came from.

It only knows how to present it.

---

# Dependency Injection

Instead of creating objects manually using `new`, ASP.NET creates them automatically and injects them where they are needed.

Example:

```csharp
public TaskController(ITaskService taskService)
{
    _taskService = taskService;
}
```

The controller does not create the service itself.

ASP.NET provides it automatically.

This makes classes:

* easier to test
* less dependent on each other
* easier to replace with different implementations

---

# Service Lifetimes

Services and repositories are registered inside `Program.cs`.

In this project we use **AddScoped()**.

```csharp
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
```

## AddScoped

Creates **one instance per HTTP request**.

```
Request #1

Controller
      │
      ▼
Service
      │
      ▼
Repository

(All use the same instance)
```

The next request receives completely new instances.

This is the most common lifetime for web applications because each HTTP request should have its own objects.

---

## AddTransient

Creates a brand new object every time it is requested.

```
Controller

↓

Service A (new)

↓

Service B (another new)
```

Useful for lightweight, stateless services.

---

## AddSingleton

Creates only one instance for the entire lifetime of the application.

```
Application Starts

↓

One Instance

↓

Everyone uses it
```

Useful for configuration, caching, or services that should be shared across all requests.

Since repositories often work with request-specific resources (such as a database context), **Singleton is not appropriate for them**, which is why this project uses **Scoped**.

---

# Request Lifecycle Example

Suppose a user opens the page showing all tasks.

The complete flow is:

```
1. Browser sends a request.

2. Controller receives the request.

3. Controller calls the Service.

4. Service applies business rules.

5. Service asks the Repository for data.

6. Repository communicates with the database.

7. Database returns the data.

8. Repository returns Domain Models.

9. Service maps Domain Models into View Models.

10. Controller receives the View Models.

11. Controller returns the View.

12. The View displays the tasks to the user.
```

Every request in the application follows this same architecture.

---

# Restaurant Analogy

Imagine ordering food at a restaurant.

```
Customer
     │
     ▼
Waiter
     │
     ▼
Chef
     │
     ▼
Pantry
     │
     ▼
Storage Room
```

The responsibilities match our application:

| Restaurant   | ASP.NET MVC |
| ------------ | ----------- |
| Customer     | User        |
| Waiter       | Controller  |
| Chef         | Service     |
| Pantry       | Repository  |
| Storage Room | Database    |

The customer never walks into the storage room to grab ingredients.

Likewise, a Controller should never communicate directly with the database.

Each person has one job, making the entire restaurant run smoothly.

---

# Key Takeaways

* Controllers receive HTTP requests and return responses.
* Services contain all business logic and coordinate the application's workflow.
* Repositories are the only classes that communicate with the database.
* Domain Models represent the database entities.
* Services map Domain Models into DTOs and View Models.
* Controllers and Views should never depend on Domain Models.
* Views are responsible only for displaying data.
* Every request follows the same flow:

```
Controller
    ↓
Service
    ↓
Repository
    ↓
Database
    ↓
Repository
    ↓
Service
    ↓
Controller
    ↓
View
```

* Layers should never be skipped because each layer has a single responsibility.
* Dependency Injection keeps classes loosely coupled.
* This project uses **AddScoped()**, which creates one instance of each service and repository per HTTP request.
