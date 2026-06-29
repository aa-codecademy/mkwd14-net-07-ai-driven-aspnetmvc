# Views

# ASP.NET MVC

Trainer – Danilo Borozan
---

# AGENDA

- What are Views?
- Types of Views
- What is Razor Syntax?
- Why do we use Razor Syntax?
- How can we use Razor Syntax?

---

# WHAT ARE VIEWS?

Views are responsible for presenting the user interface of web applications to the end-users.

They represent the visual components of the application and are used to:
- Display data
- Receive user input
- Interact with the underlying model

Views contain HTML markup combined with server-side code to dynamically generate content based on data passed from the controller.

---

# Views in ASP.NET

Views in ASP.NET are responsible for the application's:
- Data presentation
- User interaction

They are HTML templates with embedded Razor markup.

In ASP.NET Core MVC:
- Views are `.cshtml` files
- They use the C# programming language in Razor markup

Usually, view files are grouped into folders named after the application's controllers.

Example:
```txt
Views/Home
Views/Movies
Views/Products
```

---

# 🤖 AI Prompt

```text
Explain what Views are in ASP.NET MVC for complete beginners.

Explain:
- Why Views exist
- What problem Views solve
- How Views communicate with Controllers
- Why Views are responsible for UI
- What ".cshtml" files are

Use:
- Beginner-friendly language
- A real-world analogy
- One simple ASP.NET MVC example
- One real-world example such as an online shop

At the end:
- Give a short summary
- Give one beginner practice exercise
```

---

# TYPES OF VIEWS

There are three main types of views in ASP.NET:

1. Regular Views
2. Partial Views
3. Layout Views

---

# REGULAR VIEWS

These are the standard views that display the application's user interface.

Examples:
- Home page
- Product details page
- Contact page
- Movie details page

Regular views are usually connected directly to actions.

---

# PARTIAL VIEWS

Partial Views reduce code duplication by managing reusable parts of views.

They allow developers to break down complex views into smaller, manageable components and reuse them across multiple views.

Partial Views can be rendered within:
- Other views
- Layouts

Example:
- Navigation menu
- Product card
- Footer
- User profile card

A partial view is useful for an author biography on a blog website that appears in several views.

---

# LAYOUT VIEWS

Layouts are master templates that define the overall structure and design of web pages.

They typically contain common elements such as:
- Header
- Footer
- Navigation menu
- Placeholders for dynamic content

Layouts provide a consistent layout across multiple pages within the application.

---

# SECTIONS

Sections allow views to define named content regions within a layout template.

They enable views to inject specific content into predefined areas of the layout dynamically.

Sections are useful for customizing layout content on a per-page basis.

---

# ViewStart

`_ViewStart.cshtml` is used to specify common settings or layout directives that should apply to all views within a particular folder or across the entire application.

For example:
- Setting the layout page that all views should use

---

# ViewImports

`_ViewImports.cshtml` is used to:
- Import namespaces
- Add directives globally

This helps reduce redundancy by centralizing common imports and directives.

---

# 🤖 AI Prompt

```text
Explain the difference between:
- Regular Views
- Partial Views
- Layout Views

using beginner-friendly explanations.

For each one explain:
- What it is
- Why it exists
- When it is useful
- What problem it solves

Use:
- Real-world analogies
- Simple ASP.NET MVC examples
- One comparison table

At the end:
- Explain why reusable UI components are important.
```

---

# WHAT IS RAZOR SYNTAX?

Razor syntax is a mixture of:
- HTML
- C#
- VB.NET

that allows developers to seamlessly combine server-side code with client-side markup.

It enables:
- Dynamic content generation
- Execution of server-side logic within views

making it easier to build dynamic web applications.

---

# Razor Engine

The Razor Engine is a key component of ASP.NET Core.

It provides a powerful and efficient way of generating HTML content dynamically.

The Razor Engine also offers a way to embed server-based code into web pages using an HTML-like template syntax.

---

# WHY DO WE USE RAZOR SYNTAX?

## INTEGRATION

Razor seamlessly integrates server-side code with HTML markup.

This allows developers to create dynamic web pages with minimal overhead.

---

## READABILITY

Razor offers a clean and readable way to write code.

This makes applications:
- Easier to understand
- Easier to maintain

---

## PRODUCTIVITY

By reducing the need for cumbersome syntax and boilerplate code, Razor syntax enhances developer productivity and reduces development time.

---

## FLEXIBILITY

Razor supports a wide range of:
- Programming constructs
- Server-side functionalities

This enables developers to implement:
- Complex logic
- Data manipulation
- Dynamic rendering

within views.

---

# 🤖 AI Prompt

```text
Explain Razor Syntax in ASP.NET MVC for beginners.

Explain:
- What Razor Syntax is
- Why Razor exists
- Why Views need Razor
- Why we combine HTML and C#
- What the @ symbol does

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple Razor examples
- One comparison between static HTML and Razor

At the end:
- Give one mini Razor exercise
```

---

# HOW CAN WE USE RAZOR SYNTAX?

Razor syntax can be used within views (`.cshtml` files`) in ASP.NET Core and ASP.NET MVC projects.

It allows developers to:
- Embed server-side code blocks
- Embed expressions
- Use directives directly within HTML markup

By understanding the principles and best practices of Razor syntax, developers can leverage its capabilities to build:
- Clean
- Maintainable
- Efficient

ASP.NET MVC applications.

---

# Razor Syntax Examples

Razor syntax supports C# and uses the `@` symbol to transition from HTML to C#.

---

# Single Statement Block

```csharp
@{
    var myMessage = "Hello World";
}
```

---

# Inline Expression or Variable

```csharp
<p>The value of myMessage is: @myMessage </p>
```

---

# Multi-Statement Block

```csharp
@{
    var greeting = "Welcome to our site!";
    var weekDay = DateTime.Now.DayOfWeek;
    var greetingMessage = greeting + " Here in Huston it is: " + weekDay;
}

<p>The greeting is: @greetingMessage </p>
```

---

# 🤖 AI Prompt

```text
Explain how Razor Syntax works step by step.

Explain:
- What happens when ASP.NET processes Razor
- What the @ symbol does
- How C# code can be embedded into HTML
- The difference between Razor code blocks and inline expressions

Use:
- Simple examples
- Beginner-friendly explanations
- One analogy
- One practice exercise
```

---

# Demo

## Views in ASP.NET ( Only GET )

- What are Views mainly used for
- Returning Views manually
- Redirecting after action is done

---

# Demo

## RAZOR

- What is Razor
- How to write C# and HTML in Razor

---

# Demo

## Types of Views

- Layout View
- ViewBag for titles
- Create Layout ( Demo )
- ViewStart and ViewImports
- Populate ViewStart and ViewImports ( Demo )
- Partial Views
- Create and render Partial Views ( Demo )

---

# 🤖 AI Prompt

```text
Explain how Controllers and Views communicate in ASP.NET MVC.

Explain:
- How Controllers send data to Views
- What happens when return View() is called
- How the browser receives HTML
- Why Views should not contain business logic

Use:
- Beginner-friendly explanations
- A simple ASP.NET MVC example
- A real-world analogy
```

---

# 🤖 AI Prompt

```text
Explain Layout Views and Partial Views using a real-world analogy.

Explain:
- Why reusable UI is important
- What problem Layouts solve
- What problem Partial Views solve
- Why large applications benefit from reusable Views

Use:
- Simple examples
- Beginner-friendly language
- One ASP.NET MVC example
```

---

# 🤖 Copilot Tip

GitHub Copilot can help you with:
- Creating Views
- Writing Razor syntax
- Creating Layout pages
- Creating Partial Views
- Writing foreach loops in Views
- Rendering model data
- Creating simple HTML structures

Before accepting suggestions:
- Make sure the Razor syntax is correct
- Verify that the model names are correct
- Check if the View is inside the correct folder
- Keep Views simple and readable

---

# 🤖 AI Prompt

```text
Review this Razor View and suggest improvements for readability and organization.

Do NOT rewrite the whole View.

Instead:
- Explain what can be improved
- Explain possible Razor mistakes
- Explain readability improvements
- Explain whether business logic should be moved elsewhere
```

---

# Extra Materials 📘

- [Microsoft Learn - Views in ASP.NET Core MVC](^10^)
- [Microsoft Learn - Razor syntax reference for ASP.NET Core](^1^)

TutorialsPoint Articles on Views:
- [Layout](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_layout_views.htm)
- [ViewStart](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_start.htm)
- [ViewImport](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_import.htm)

- [Dot Net Tutorials - Razor View Engine and Razor Syntax in ASP.NET Core](^6^)
- [Microsoft on Partial Views](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-2.1)
- [Quick Reference to Razor Syntax](https://haacked.com/archive/2011/01/06/razor-syntax-quick-reference.aspx/)

---

# QUESTIONS?

You can find me at:

daniloborozan07@gmail.com