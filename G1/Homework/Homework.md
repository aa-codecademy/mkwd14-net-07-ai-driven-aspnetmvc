# ***__Video Rental Online Store__***

# Homework Overview

In this homework you will build a simple ASP.NET MVC application for renting movies online.

The goal of this homework is to practice:
- ASP.NET MVC structure
- Controllers
- Models
- Views
- Basic application flow
- Routing
- Razor Views
- Working with collections and objects
- Understanding MVC communication

This homework is focused on understanding how MVC applications work.

The goal is NOT to build a perfect production-ready application.

---

# 🤖 AI & GitHub Copilot Usage

You are encouraged to use:
- ChatGPT
- GitHub Copilot

AI tools should help you:
- Understand concepts
- Explain errors
- Organize your project
- Generate small code snippets
- Explain MVC flow
- Refactor your code
- Improve readability

AI should NOT:
- Solve the entire homework for you
- Replace understanding
- Replace debugging
- Replace practicing

Always try to:
1. Understand the problem first
2. Build a small part
3. Test it
4. Improve it

---

# 🤖 Setting Up GitHub Copilot Instructions

To make GitHub Copilot give better and more beginner-friendly suggestions, create this file in your project:

```txt
.github/copilot-instructions.md
```

## 📁 Where to Create the File

Create a folder named:

```txt
.github
```

Inside that folder create:

```txt
copilot-instructions.md
```

Example:

```txt
YourSolution/
│
├── Controllers/
├── Models/
├── Views/
├── .github/
│   └── copilot-instructions.md
└── YourSolution.sln
```

---

# 🤖 What to Put Inside copilot-instructions.md

Copy this content inside the file or use the example copilot instructions given in the separate file:

```md
# GitHub Copilot Instructions

This is a beginner ASP.NET MVC academy homework project.

Prefer:
- Beginner-friendly ASP.NET MVC examples
- Simple and readable code
- Small methods
- Simple controller actions
- Basic Razor syntax
- Clear naming

Avoid:
- Advanced architecture
- Complex design patterns
- Authentication frameworks
- Async programming
- Over-engineered solutions

The application is a Video Rental Online Store.

Main features:
- View movies
- View movie details
- Rent movies
- Return movies

Keep explanations simple and step-by-step.
```

---

# 🤖 What GitHub Copilot Can Help You With

GitHub Copilot is useful for:
- Creating models
- Creating enums
- Creating controller actions
- Writing Razor syntax
- Writing foreach loops
- Creating simple forms
- Writing HTML structure
- Explaining errors
- Refactoring methods
- Improving naming

Examples:
- Generating model properties
- Creating a MovieDetails action
- Generating a foreach loop for movies
- Creating a simple Razor table

---

# 🤖 What You Should Still Do Yourself

You should still:
- Understand the MVC flow
- Understand where files belong
- Understand what each controller action does
- Understand how models are connected
- Test your application manually
- Debug errors yourself first

---

# 🤖 Suggested AI Prompts

## Understanding MVC

```text
Explain MVC using a real-world analogy for beginners.
```

---

## Understanding Controllers

```text
Explain what a controller action does in ASP.NET MVC using simple examples.
```

---

## Understanding Views

```text
Explain what data a View needs in ASP.NET MVC.
```

---

## Understanding Models

```text
Explain how Models are used in ASP.NET MVC applications.
```

---

## Understanding Renting Logic

```text
Explain the movie renting process step by step without solving the whole homework.
```

---

## Debugging Help

```text
Explain this ASP.NET MVC error step by step and help me debug it.
```

---

## Folder Structure Help

```text
Explain where Controllers, Models and Views should be placed in an ASP.NET MVC project.
```

---

# Application Requirements

## Models

### User

This model represents a user in the system.

Properties:
- `Id`
- `FullName`
- `Age`
- `CardNumber`
- `CreatedOn`
- `IsSubscriptionExpired`
- `SubscriptionType`

The `SubscriptionType` indicates the type of subscription the user has.

---

### Movie

This model represents a movie available for rent.

Properties:
- `Id`
- `Title`
- `Genre`
- `Language`
- `IsAvailable`
- `ReleaseDate`
- `Length`
- `AgeRestriction`
- `Quantity`

The `Genre` and `Language` can be implemented as enums.

The `IsAvailable` property indicates whether the movie is currently available for rent.

---

### Cast

This model represents a person involved in the making of a movie.

Properties:
- `Id`
- `Name`
- `MovieId`
- `Part`

The `Part` can be implemented as an enum.

---

### Rental

This model represents a rental transaction.

Properties:
- `Id`
- `MovieId`
- `UserId`
- `RentedOn`
- `ReturnedOn`

---

# Optional Enums

You may use enums for:
- SubscriptionType
- Genre
- Language
- Part

---

# Starter Code

```csharp
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string CardNumber { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsSubscriptionExpired { get; set; }
    public string SubscriptionType { get; set; }
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Language { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ReleaseDate { get; set; }
    public TimeSpan Length { get; set; }
    public int AgeRestriction { get; set; }
    public int Quantity { get; set; }
}

public class Cast
{
    public int Id { get; set; }
    public string MovieId { get; set; }
    public string Name { get; set; }
    public string Part { get; set; }
}

public class Rental
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime ReturnedOn { get; set; }
}
```

---

# Requirements

## User Login

Even though authentication is not required, users still need to be identified.

You can:
- Create a simple login page
- Use `CardNumber`
- Or use `Email`

After login:
- Store the user in Session
- Or use ViewData/ViewBag if needed

---

## View Movies

Create a page that displays:
- List or grid of movies
- Basic movie information
- Availability status

---

## Movie Details

Each movie should:
- Open a details page
- Show all movie information

Examples:
- Title
- Genre
- Language
- ReleaseDate
- Length
- Quantity

---

## Rent Movie

If a movie is available:
- Show a "Rent" button

When clicked:
- Create a Rental object
- Connect it to UserId and MovieId
- Set RentedOn
- Decrease movie quantity

---

## Return Movie

Create a page with:
- Currently rented movies

Each item should:
- Show a "Return" button

When clicked:
- Find the rental
- Set ReturnedOn
- Increase movie quantity

---

# 🤖 Suggested Development Flow

## Step 1
Create:
- Models
- Enums

---

## Step 2
Create:
- Fake in-memory data

---

## Step 3
Create:
- Controllers

---

## Step 4
Create:
- Views

---

## Step 5
Implement:
- Renting logic

---

## Step 6
Implement:
- Returning logic

---

# Bonus Ideas

Optional improvements:
- Search movies
- Filter by genre
- Display unavailable movies differently
- Add simple styling
- Add validation messages

---

# Important Reminder

Focus on:
- Understanding MVC
- Understanding application flow
- Understanding communication between Controllers, Models and Views

Do not focus on perfection.

Small working features are better than large unfinished features.