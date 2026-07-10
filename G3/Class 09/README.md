# Entity Framework 6 and the Basics

# ASP.NET MVC

Trainer - Tijana Stojanovska

---

# AGENDA

- Entity Framework 6
- Database First vs Code First
- DbContext
- DbSet
- CRUD Operations
- Migrations

---

# ENTITY FRAMEWORK 6

Entity Framework (EF) is an Object-Relational Mapping (ORM) framework that enables developers to work with databases using .NET objects.

EF 6 is a version of Entity Framework that provides a variety of features for data access in .NET applications.

Instead of writing raw SQL queries all the time, Entity Framework allows developers to work with:
- C# classes
- Objects
- LINQ queries

while EF handles communication with the database.

---

# WHAT IS AN ORM?

ORM stands for:
```txt
Object Relational Mapper
```

An ORM acts as a bridge between:
- The application
- The database

It maps:
- Database tables → C# classes
- Database rows → C# objects

This allows developers to work with objects instead of manually writing SQL for every operation.

---

# 🤖 AI Prompt

```text
Explain Entity Framework and ORM concepts for complete beginners.

Explain:
- What Entity Framework is
- What ORM means
- Why ORMs exist
- What problem ORMs solve
- Why developers use EF instead of raw SQL all the time

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple ASP.NET examples

At the end:
- Compare working with SQL manually vs using Entity Framework
- Give one beginner practice exercise
```

---

# INSTALLATION

To use Entity Framework 6 in your project, install it using NuGet Package Manager.

```bash
Install-Package EntityFramework
```

---

# DATABASE FIRST vs CODE FIRST

Entity Framework supports two primary development approaches:

- Database First
- Code First

---

# DATABASE FIRST

In the Database First approach:
- The database already exists
- EF generates classes based on the database structure

Developers first design:
- Tables
- Relationships
- Database schema

Then Entity Framework generates:
- Models
- Context classes

from the database.

---

# CODE FIRST

In the Code First approach:
- Developers first create C# classes
- Entity Framework generates the database schema

based on the classes.

This approach is very popular in modern ASP.NET applications.

---

# 🤖 AI Prompt

```text
Explain the difference between Database First and Code First in Entity Framework.

Explain:
- What Database First means
- What Code First means
- Advantages and disadvantages of both approaches
- When developers might choose each approach

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple examples

At the end:
- Explain which approach beginners should start with
```

---

# WHAT IS THE DbContext CLASS?

The `DbContext` class is one of the most important parts of Entity Framework.

It represents:
- A session with the database
- A bridge between application classes and database tables

It handles:
- Database connections
- Querying
- Saving changes
- Change tracking

---

# Key Concepts of DbContext

## SESSION WITH THE DATABASE

An instance of `DbContext` represents a session with the database.

It:
- Maintains the database connection
- Tracks entity changes
- Coordinates database operations

---

## ENTITY SETS (DbSets)

`DbContext` contains properties of type:
```csharp
DbSet<T>
```

Each `DbSet` usually represents:
- A database table
- A collection of entities

---

## CHANGE TRACKING

`DbContext` tracks changes made to entities.

It knows:
- Which entities were added
- Which entities were updated
- Which entities were deleted

before saving changes to the database.

---

# Creating a DbContext

```csharp
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
```

In this example:
- `MyDbContext` represents the database session
- `Customers` represents the Customers table
- `Orders` represents the Orders table

---

# 🤖 AI Prompt

```text
Explain DbContext in Entity Framework for beginners.

Explain:
- What DbContext is
- Why DbContext exists
- What "session with the database" means
- What DbSet properties represent
- What change tracking means

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple Entity Framework examples

At the end:
- Explain the relationship between DbContext and DbSet
```

---

# CONFIGURING CONNECTION STRING

The `DbContext` constructor usually receives connection configuration information.

Example:

```csharp
public MyDbContext(DbContextOptions options) : base(options) { }
```

This allows Entity Framework to connect to the correct database.

---

# QUERYING DATA

Entity Framework allows querying data using:
```txt
LINQ
```

LINQ stands for:
```txt
Language Integrated Query
```

EF automatically converts LINQ queries into SQL queries.

Example:

```csharp
using (var context = new MyDbContext())
{
    var customers = context.Customers
        .Where(c => c.City == "London")
        .ToList();
}
```

This retrieves all customers whose city is:
```txt
London
```

---

# 🤖 AI Prompt

```text
Explain how LINQ queries work with Entity Framework.

Explain:
- What LINQ is
- Why LINQ is useful
- How EF converts LINQ into SQL
- Why developers prefer LINQ

Use:
- Beginner-friendly explanations
- Simple examples
- Real-world analogies

At the end:
- Compare LINQ queries vs raw SQL queries
```

---

# SAVING CHANGES

To persist changes to the database, use:

```csharp
SaveChanges()
```

Example:

```csharp
using (var context = new MyDbContext())
{
    var newCustomer = new Customer
    {
        Name = "John Doe",
        City = "New York"
    };

    context.Customers.Add(newCustomer);

    context.SaveChanges();
}
```

This:
- Adds a new customer
- Saves the customer to the database

---

# WHAT IS DbSet?

The `DbSet` class represents a collection of entities of a specific type inside the database context.

It acts as a gateway for:
- Querying
- Inserting
- Updating
- Deleting

entities.

---

# DbSet and Database Tables

Each `DbSet` usually maps to:
- A database table

Example:

```csharp
public DbSet<Customer> Customers { get; set; }
```

This typically maps to:
```txt
Customers
```

table in the database.

---

# Creating DbSet Properties

```csharp
public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
```

---

# 🤖 AI Prompt

```text
Explain DbSet in Entity Framework for beginners.

Explain:
- What DbSet is
- Why DbSet exists
- How DbSet maps to database tables
- Why DbSet behaves like a collection

Explain:
- Add
- Remove
- Find
- LINQ queries

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple Entity Framework examples

At the end:
- Explain how DbSet and DbContext work together
```

---

# QUERYING DATA WITH DbSet

```csharp
using (var context = new MyDbContext())
{
    var customersInLondon =
        context.Customers
        .Where(c => c.City == "London")
        .ToList();
}
```

Entity Framework translates this LINQ query into SQL automatically.

---

# ADDING DATA

```csharp
var newCustomer = new Customer
{
    Name = "John Doe",
    City = "New York"
};

context.Customers.Add(newCustomer);

context.SaveChanges();
```

---

# UPDATING DATA

```csharp
var customer = context.Customers.Find(1);

customer.City = "Los Angeles";

context.SaveChanges();
```

---

# DELETING DATA

```csharp
var customer = context.Customers.Find(1);

context.Customers.Remove(customer);

context.SaveChanges();
```

---

# CRUD OPERATIONS

CRUD stands for:

- Create
- Read
- Update
- Delete

These are the basic database operations used in most applications.

---

# 🤖 AI Prompt

```text
Explain CRUD operations in Entity Framework for beginners.

Explain:
- Create
- Read
- Update
- Delete

For each operation explain:
- What it does
- Why it is important
- How Entity Framework performs it

Use:
- Beginner-friendly explanations
- Simple examples
- One real-world analogy such as an online shop or library system

At the end:
- Explain how SaveChanges works
```

---

# WHAT ARE MIGRATIONS?

Migrations in Entity Framework help manage database schema changes over time.

Instead of manually updating the database every time classes change, migrations allow developers to:
- Define changes in code
- Apply them automatically

---

# Key Concepts of Migrations

## MIGRATION FILES

Each migration is represented by a migration file.

Migration files contain:
- Database schema changes
- Instructions for updating the database

---

## MIGRATION HISTORY

Entity Framework stores migration history inside:
```txt
__MigrationHistory
```

table.

This helps EF track:
- Which migrations were applied
- The order of applied migrations

---

## MIGRATION OPERATIONS

Migration files can:
- Create tables
- Modify columns
- Add indexes
- Remove columns

and more.

---

# INSTALLING MIGRATION TOOLS

To work with migrations install:

```bash
dotnet tool install --global dotnet-ef
```

---

# CREATING MIGRATIONS

Whenever entity classes change, create a migration.

```bash
dotnet ef migrations add <MigrationName>
```

Example:

```bash
dotnet ef migrations add InitialCreate
```

---

# REVIEWING MIGRATION CODE

Migration files contain:
- `Up`
- `Down`

methods.

---

## Up Method

Applies changes to the database.

---

## Down Method

Reverts changes if rollback is needed.

---

# APPLYING MIGRATIONS

To apply migrations:

```bash
dotnet ef database update
```

This:
- Executes pending migrations
- Updates the database schema

---

# ROLLING BACK MIGRATIONS

To rollback:

```bash
dotnet ef database update -TargetMigration <MigrationName>
```

This executes the `Down` methods to revert schema changes.

---

# 🤖 AI Prompt

```text
Explain Entity Framework Migrations for beginners.

Explain:
- What migrations are
- Why migrations exist
- What problem migrations solve
- What migration files contain
- What Up and Down methods do

Explain:
- dotnet ef migrations add
- dotnet ef database update

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple examples

At the end:
- Explain why migrations are important for team development
```

---

# KEEP IN MIND

## KEEP DbContext LIGHTWEIGHT

Avoid placing business logic inside `DbContext`.

---

## USE SEPARATION OF CONCERNS

Keep:
- Database logic
- Business logic
- UI logic

separated.

---

## ALWAYS REVIEW MIGRATIONS

Always inspect generated migration files before applying them.

---

## BE CAREFUL WITH DELETE OPERATIONS

Deleting entities can permanently remove data.

---

## TEST MIGRATIONS

Always test migrations before applying them to production databases.

---

# 🤖 AI Prompt

```text
Explain best practices for using Entity Framework in ASP.NET applications.

Explain:
- Why DbContext should stay lightweight
- Why migrations should be reviewed carefully
- Why separation of concerns is important
- Why developers should avoid putting business logic inside DbContext

Use:
- Beginner-friendly explanations
- Real-world analogies
- Practical examples

At the end:
- Explain common beginner mistakes when using Entity Framework
```

---

# Demo

## Entity Framework Setup

- Install Entity Framework
- Create DbContext
- Create DbSet properties
- Configure connection string

---

# Demo

## CRUD Operations

- Add data
- Read data
- Update data
- Delete data
- SaveChanges

---

# Demo

## Migrations

- Create first migration
- Apply migrations
- Update database
- Rollback migration

---

# 🤖 Copilot Tip

GitHub Copilot can help you with:
- Creating DbContext classes
- Creating DbSet properties
- Writing LINQ queries
- Creating migrations
- Writing CRUD operations
- Creating entity classes

Before accepting suggestions:
- Verify entity relationships carefully
- Check if property names make sense
- Ensure migrations are correct
- Avoid placing business logic inside DbContext
- Keep entity classes clean and readable

---

# 🤖 AI Prompt

```text
Review this Entity Framework setup and suggest improvements.

Do NOT rewrite the entire code.

Instead:
- Explain possible DbContext improvements
- Explain possible entity design improvements
- Explain possible migration issues
- Explain possible LINQ query improvements
- Explain possible separation of concerns problems
```

---

# QUESTIONS?

You can find me at:

stojanovska_tijana@outlook.com