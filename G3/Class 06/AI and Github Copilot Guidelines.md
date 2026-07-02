# 🤖 AI & GitHub Copilot Guidelines

# ASP.NET MVC Todo Application

This project is meant to help you practice:
- ASP.NET MVC
- Controllers
- Views
- Models
- Razor
- Entity Framework
- CRUD operations
- Model Binding
- Validation
- Routing

AI tools such as:
- ChatGPT
- GitHub Copilot

can help you learn faster, but they should support your understanding — not replace it.

---

# ✅ What AI Can Help You With

You CAN use AI for:
- Understanding ASP.NET MVC concepts
- Explaining errors
- Explaining Entity Framework
- Generating small code snippets
- Creating simple models
- Creating controller actions
- Generating Razor syntax
- Explaining validation
- Explaining LINQ queries
- Refactoring existing code
- Understanding relationships between models

---

# ❌ What AI Should NOT Do

Do NOT:
- Generate the entire application without understanding it
- Copy-paste code without reading it
- Skip debugging
- Ignore compiler errors
- Submit code you cannot explain

---

# 🤖 Suggested Workflow With AI

## Step 1 — Understand the feature

Before writing code ask AI:

```text
Explain this Todo feature step by step for beginners.
```

---

## Step 2 — Understand the MVC flow

```text
Explain which:
- Model
- Controller
- View

I need for this Todo functionality.
```

---

## Step 3 — Build small pieces

Instead of asking:
```text
Build the entire Todo application
```

ask:
```text
Help me create the Add Todo action step by step.
Do not solve the entire application.
```

---

# 🤖 Good AI Prompts

## Understanding Models

```text
Explain how the Todo, Category and Status models are connected.
```

---

## Understanding Relationships

```text
Explain one-to-many relationships in Entity Framework using the Todo application example.
```

---

## Creating Controllers

```text
Explain what actions I need in a TodoController for:
- Listing todos
- Adding todos
- Completing todos
- Deleting completed todos
```

---

## Understanding ViewModels

```text
Explain whether this Todo application needs ViewModels and why.
```

---

## Creating Add Todo Logic

```text
Explain step by step how to create an Add Todo feature in ASP.NET MVC using Entity Framework.
```

---

## Understanding DbContext

```text
Explain what DbContext and DbSet would look like for this Todo application.
```

---

## Understanding LINQ

```text
Explain how LINQ queries work using Todo items and Categories examples.
```

---

## Understanding Validation

```text
Explain what validation attributes I should add to the Todo model and why.
```

---

## Understanding Filtering

```text
Explain step by step how filtering Todos by Category or Status works in ASP.NET MVC.
```

---

## Understanding Complete Todo Logic

```text
Explain step by step how marking a Todo as complete should work in ASP.NET MVC.
```

---

## Understanding Delete Completed Logic

```text
Explain how bulk deleting completed Todos works in ASP.NET MVC and Entity Framework.
```

---

# 🤖 Good GitHub Copilot Prompts

## Creating Models

```text
Create a beginner-friendly Todo model for ASP.NET MVC using Entity Framework.
```

---

## Creating DbContext

```text
Create a TodoDbContext with DbSets for Todo, Category and Status.
```

---

## Creating CRUD Actions

```text
Create beginner-friendly ASP.NET MVC controller actions for Todo CRUD operations.
```

---

## Creating Razor Views

```text
Generate a simple Razor View for displaying Todo items in a table.
```

---

## Creating Forms

```text
Generate a simple ASP.NET MVC form for adding a Todo item using Tag Helpers.
```

---

## Creating LINQ Queries

```text
Generate a LINQ query for filtering Todo items by CategoryId and StatusId.
```

---

## Creating Validation

```text
Generate beginner-friendly Data Annotation validations for the Todo model.
```

---

## Creating ViewModels

```text
Generate a ViewModel for displaying Todo items with Category and Status names.
```

---

# 🤖 Good Debugging Prompts

## Entity Framework Errors

```text
Explain this Entity Framework error step by step and help me debug it.
```

---

## Razor Errors

```text
Explain this Razor View error and possible reasons why it happens.
```

---

## Model Binding Errors

```text
Explain why this ASP.NET MVC form is not binding correctly.
```

---

## Routing Errors

```text
Explain why this ASP.NET MVC route returns 404.
```

---

# 🤖 Good Refactoring Prompts

```text
Review this ASP.NET MVC controller and suggest beginner-friendly improvements.
Do NOT rewrite the entire code.
```

---

```text
Review this Razor View and suggest readability improvements.
```

---

```text
Review this Entity Framework query and explain whether it can be simplified.
```

---

# 🤖 Important Reminder

Always try to:
1. Understand the code
2. Build small features
3. Test frequently
4. Debug carefully
5. Ask AI for explanations, not only solutions

The goal is to learn how ASP.NET MVC applications work.