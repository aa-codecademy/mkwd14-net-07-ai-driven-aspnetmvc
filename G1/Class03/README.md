# Models

# ASP.NET MVC

Trainer - Danilo Borozan

---

# RETROSPECTIVE

- What do we need to inherit from to make a Controller?
- What is an action?
- How can you return a result from an action?
- What is a router?
- What is a route parameter?

---

# AGENDA

- What are Models?
- Types of Models
- When and where do we use Models?

---

# WHAT ARE MODELS?

Dynamic applications work by changing the data in the view constantly.

The packages in which the data is stored are called models.

In ASP.NET MVC, a Model represents:
- The data
- The business logic
- The behavior of an application

It encapsulates:
- The application's data structure
- Validation rules
- Behavior

They are basically objects of classes that contain some business logic.

Models are responsible for:
- Interacting with the underlying data store
- Performing CRUD operations
- Providing data to the views for rendering

---

# What is a Model?

In software development, a model is a fundamental concept that represents the application's:
- Data
- Business logic
- Behavior

It encapsulates the structure, state, and operations of the data entities within the application's domain.

Models play a crucial role in MVC (Model-View-Controller) architecture and other software design patterns, providing a structured way to organize and manage the application's data.

A model can be thought of as a blueprint or template for representing real-world entities or concepts within a software application.

It defines:
- Attributes
- Properties
- Behaviors
- Relationships between entities

Models abstract away the complexities of data management and manipulation, providing a clean and organized representation of the application's domain.

---

# 🤖 AI Prompt

```text
Explain what a Model is in ASP.NET MVC as if you are teaching a complete beginner.

Explain:
- Why Models exist
- What problem they solve
- How Models are connected to Controllers and Views
- Why Models represent application data
- What "business logic" means in simple language

Use:
- A real-world analogy
- Simple beginner-friendly explanations
- One ASP.NET MVC example
- One real-life example like an online shop or library system

At the end:
- Give a short summary
- Give one beginner exercise
```

---

# Characteristics of Models

## 1. Data Representation

Models define:
- Structure
- Attributes
- Relationships
- Constraints

of the data entities within the application.

They encapsulate the state of entities.

Examples:
- Users
- Products
- Orders
- Movies

---

## 2. Business Logic

Models encapsulate:
- Business rules
- Validation logic
- Behavior

They:
- Enforce data integrity
- Perform calculations
- Perform transformations
- Handle validations

---

## 3. Data Access

Models may interact with:
- Databases
- Files
- External services

They abstract away the details of data access.

---

# 🤖 AI Prompt

```text
Explain the difference between:
- Data Representation
- Business Logic
- Data Access

using simple beginner-friendly examples.

Use a real-world analogy such as:
- A library
- A restaurant
- An online store

Explain what responsibility each part has.
```

---

# Usage of Models

Models are used across various layers and components of a software application.

---

# Domain Layer

In the domain layer, models represent the core entities and concepts within the application's domain.

They define:
- Data structures
- Business rules
- Application behavior

---

# Data Access Layer

In the data access layer, models are often used to map database tables to object-oriented representations.

They provide a way to interact with the database through ORM frameworks.

---

# Application Logic

Models are used to implement:
- Data validation
- Calculations
- Business rules

They encapsulate the behavior and state of the application's data entities.

---

# User Interface

In user interface components, models are used to bind data to:
- Forms
- Controls
- Views

They help display and manipulate data within the user interface.

---

# WHEN & WHERE DO WE USE MODELS?

## Data representation

Models are used to represent data entities, such as:
- Users
- Products
- Orders
- Movies

within the application.

---

## Business logic

Models encapsulate business logic and validation rules, ensuring:
- Data integrity
- Consistency

---

## Data access

Models interact with the data access layer to perform CRUD operations, abstracting away the underlying data store implementation details.

---

## View rendering

View models provide structured data to views for rendering user interfaces, enabling the presentation layer to access and display data effectively.

---

# 🤖 AI Prompt

```text
Explain where Models are used inside an ASP.NET MVC application.

Explain:
- How Controllers use Models
- How Views use Models
- Why applications need Models
- What would happen if we did not use Models

Use:
- Beginner-friendly explanations
- One small MVC example
- One real-world analogy
```

---

# Types of Models

Depending on the architecture of the application there can be different types of models.

Every type of model is specialized for transferring data from one part of the application to another.

There are 3 main types of models:
- Domain Models
- View Models
- Data Transfer Objects (DTOs)

---

# DOMAIN MODELS

Domain models:
- Represent the core entities and business objects within the application domain
- Encapsulate essential data and behavior relevant to the domain
- Often reflect real-world concepts

Domain models typically correspond to:
- Database tables
- Document collections
- Stored application data

---

# Example — Domain Model

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

---

# VIEW MODELS

View models are specialized models designed to fulfill the specific data requirements of views.

They:
- Act as intermediaries between Controllers and Views
- Provide structured data for the UI
- Tailor data presentation for specific screens or pages

View models help improve:
- Separation of concerns
- Maintainability
- Readability

---

# Example — View Model

```csharp
public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

---

# DATA TRANSFER OBJECTS (DTOs)

DTOs are lightweight, serializable objects used for transferring data between:
- Different layers of an application
- External systems
- APIs
- Services

DTOs:
- Usually contain only data
- Usually do not contain behavior or business logic

They help:
- Reduce coupling
- Improve performance
- Control what data is exposed

---

# Example — DTO

```csharp
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

---

# ViewModels in MVVM

ViewModels act as an intermediary between the View and the Model.

They:
- Expose properties
- Prepare data for display
- Handle presentation logic

---

# Example — MVVM ViewModel

```csharp
public class ProductDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FormattedPrice => Price.ToString("C");

    public decimal Price { get; set; }
}
```

---

# 🤖 AI Prompt

```text
Explain the difference between:
- Domain Models
- View Models
- DTOs

using beginner-friendly explanations.

For each one explain:
- What it is
- Why it exists
- Where it is used
- What problem it solves

Use:
- Simple ASP.NET MVC examples
- Real-world analogies
- One comparison table

At the end:
- Explain why using one single model for everything can become problematic.
```

---

# 🤖 AI Prompt

```text
Explain why ViewModels are useful in ASP.NET MVC.

Explain:
- Why we do not always send Domain Models directly to Views
- What problems ViewModels solve
- How ViewModels help organize data for the UI

Use:
- Beginner-friendly language
- One practical example
- One real-world analogy
```

---

# 🤖 AI Prompt

```text
Explain DTOs in ASP.NET MVC and APIs for beginners.

Explain:
- Why DTOs exist
- Why DTOs usually contain only data
- Why we do not always expose Domain Models directly
- How DTOs help with security and organization

Use:
- Simple examples
- Real-world analogies
- Beginner-friendly explanations
```

---

# Demo

## Creating and connecting models to a view ( Demo )

- Create a simple model
- Add properties
- Create sample data
- Pass the model from Controller to View
- Display model data in the View

---

# Demo

## Building and mapping ViewModels ( Demo )

- Create a Domain Model
- Create a ViewModel
- Map data from Domain Model to ViewModel
- Pass the ViewModel to the View
- Display the formatted data

---

# 🤖 Copilot Tip

GitHub Copilot can help you with:
- Creating model classes
- Generating properties
- Creating ViewModels
- Creating DTOs
- Generating constructors
- Generating sample objects
- Mapping data between models

Before accepting suggestions:
- Make sure property names are meaningful
- Check if the model matches the business requirements
- Verify if the correct model type is being used
- Keep models simple and readable

---

# 🤖 AI Prompt

```text
Review this ASP.NET MVC model and suggest improvements for readability and organization.

Do NOT rewrite the whole code.

Instead:
- Explain what can be improved
- Explain naming suggestions
- Explain possible missing properties
- Explain whether this should be a Domain Model, ViewModel or DTO
```

---

# Extra Materials 📘

- [Model and ViewModel](https://www.tektutorialshub.com/asp-net-core/asp-net-core-model-and-viewmodel/)

---

# QUESTIONS?

You can find me at:

daniloborozan07@gmail.com