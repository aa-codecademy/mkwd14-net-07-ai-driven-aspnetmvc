# HTML Helpers, Tag Helpers and Data Passing Techniques

# ASP.NET MVC

Trainer - Danilo Borozan
---

# RETROSPECTIVE

- What is the Razor Engine?
- How do we write C# code in our HTML views?
- What is a Layout View?
- Why would we need Partial Views?
- What’s the difference between ViewImports and ViewStart?

---

# AGENDA

- HTML Helpers
- Tag Helpers
- ViewData
- ViewBag
- Strongly Typed Models (ViewModels)
- TempData

---

# WHAT ARE HTML HELPERS?

HTML Helpers are methods provided by ASP.NET Core and ASP.NET MVC frameworks to generate HTML markup programmatically within views.

They encapsulate common HTML elements and attributes, allowing developers to generate HTML dynamically based on data or application logic.

HTML Helpers in ASP.NET MVC are methods that return a string.

They are used to create HTML elements in views.

They provide a way to generate HTML markup programmatically, which can help keep your views:
- Clean
- Organized
- Maintainable

---

# WHY DO WE USE HTML HELPERS?

## ABSTRACTION

HTML Helpers abstract the process of generating HTML markup, reducing repetitive code and improving productivity.

---

## TYPE SAFETY

They provide:
- Type safety
- Compile-time checking

ensuring that generated HTML elements and attributes are valid and well-formed.

---

## CONSISTENCY

HTML Helpers promote consistency in HTML markup generation by adhering to predefined conventions and standards.

---

## ENCAPSULATION

HTML Helpers encapsulate complex HTML structures and attributes, making it easier to manage and maintain code.

---

# HOW DO WE USE HTML HELPERS?

HTML Helpers are invoked within views (`.cshtml` files) using Razor syntax (`@`).

They are typically called with lambda expressions that specify model properties or values to be bound to HTML elements.

---

# HTML Helper Example

```csharp
@using (Html.BeginForm("Action", "Controller", FormMethod.Post))
{
    @Html.LabelFor(model => model.Property)
    @Html.EditorFor(model => model.Property)
    @Html.ValidationMessageFor(model => model.Property)

    <input type="submit" value="Submit" />
}
```

In this example:

- `Html.BeginForm` creates a `<form>` element
- `Html.LabelFor` creates a `<label>`
- `Html.EditorFor` creates an `<input>`
- `Html.ValidationMessageFor` displays validation errors

---

# 🤖 AI Prompt

```text
Explain HTML Helpers in ASP.NET MVC for beginners.

Explain:
- What HTML Helpers are
- Why HTML Helpers exist
- What problem they solve
- Why they are useful in Razor Views
- What "type safety" means in simple language

Explain these helpers:
- Html.BeginForm
- Html.LabelFor
- Html.EditorFor
- Html.ValidationMessageFor

Use:
- Beginner-friendly language
- Real-world analogies
- Simple ASP.NET MVC examples

At the end:
- Compare writing plain HTML vs HTML Helpers
- Give one small practice exercise
```

---

# TAG HELPERS

Tag Helpers are a feature in ASP.NET that enables developers to create custom HTML-like elements that execute server-side code.

They provide a more natural and intuitive way to extend HTML syntax with server-side functionality.

Tag Helpers are similar to HTML Helpers, but they have a more HTML-like syntax, which can make views easier to read.

---

# WHY DO WE USE TAG HELPERS?

## NATURAL SYNTAX

Tag Helpers mimic the syntax of standard HTML elements, making code more readable and intuitive.

---

## SEPARATION OF CONCERNS

Tag Helpers promote separation of concerns by enabling developers to embed server-side logic directly within HTML markup.

---

## CODE REUSABILITY

Tag Helpers encapsulate reusable components and functionalities, enhancing:
- Reusability
- Maintainability

---

## INTELLISENSE SUPPORT

Tag Helpers provide full IntelliSense support within HTML editors, improving developer productivity and reducing errors.

---

# HOW DO WE USE TAG HELPERS?

Tag Helpers are used within views (`.cshtml` files`) by adding custom HTML-like elements prefixed with the `asp-` attribute.

They are defined as C# classes that derive from the `TagHelper` base class and are registered within the application's dependency injection container.

---

# Tag Helper Example

```html
<form asp-action="Action" asp-controller="Controller" method="post">
    <label asp-for="Property"></label>
    <input asp-for="Property" />
    <span asp-validation-for="Property"></span>

    <input type="submit" value="Submit" />
</form>
```

In this example:
- `asp-action`
- `asp-controller`
- `asp-for`
- `asp-validation-for`

are Tag Helpers.

They generate dynamic HTML using ASP.NET MVC functionality.

---

# 🤖 AI Prompt

```text
Explain Tag Helpers in ASP.NET MVC for beginners.

Explain:
- What Tag Helpers are
- Why they exist
- How they differ from HTML Helpers
- Why they look more like normal HTML
- What the asp-* attributes do

Explain:
- asp-action
- asp-controller
- asp-for
- asp-validation-for

Use:
- Beginner-friendly explanations
- Simple examples
- Real-world analogies

At the end:
- Compare HTML Helpers vs Tag Helpers
- Explain when developers might prefer one over the other
```

---

# HTML HELPERS vs TAG HELPERS

Both HTML Helpers and Tag Helpers can be useful in different situations.

HTML Helpers:
- May feel more familiar for traditional ASP.NET MVC developers

Tag Helpers:
- Usually feel more natural for front-end developers
- Look more like standard HTML

Both approaches generate dynamic HTML.

---

# 🤖 AI Prompt

```text
Compare HTML Helpers and Tag Helpers in ASP.NET MVC.

For each one explain:
- Syntax style
- Readability
- Advantages
- Disadvantages
- Typical use cases

Use:
- Simple beginner-friendly examples
- One comparison table
- One recommendation for beginners
```

---

# DATA PASSING TECHNIQUES

In ASP.NET MVC, there are several techniques for passing data between:
- Controllers
- Views
- Action methods

The most common techniques are:
- ViewData
- ViewBag
- Strongly Typed Models (ViewModels)
- TempData

---

# ViewData

`ViewData` is a dictionary-like object provided by ASP.NET MVC for passing data from controllers to views without strongly typing the data.

It is of type:
```csharp
ViewDataDictionary
```

and is available within:
- Controller actions
- Views

It provides a simple mechanism for transferring small amounts of data.

---

# ViewData Example

```csharp
public ActionResult Index()
{
    ViewData["Message"] = "Hello, World!";
    return View();
}
```

View:

```csharp
<p>@ViewData["Message"]</p>
```

---

# Best Practices for ViewData

- Use ViewData for small, simple data
- Avoid passing large or complex structures
- Prefer strongly typed models when possible

---

# ViewBag

`ViewBag` is a dynamic property provided by ASP.NET MVC that allows passing data from controllers to views.

It is a wrapper around `ViewData` and provides a more concise syntax.

---

# ViewBag Example

```csharp
public ActionResult Index()
{
    ViewBag.Message = "Hello, World!";
    return View();
}
```

View:

```csharp
<p>@ViewBag.Message</p>
```

---

# Best Practices for ViewBag

- Use ViewBag for simple, non-complex data
- Avoid using it for large data structures
- Prefer strongly typed models for maintainability

---

# 🤖 AI Prompt

```text
Explain the difference between ViewData and ViewBag in ASP.NET MVC for beginners.

Explain:
- What ViewData is
- What ViewBag is
- Why both exist
- How they pass data from Controllers to Views
- Why they are considered weakly typed

Use:
- Beginner-friendly language
- Real-world analogies
- Simple ASP.NET MVC examples

At the end:
- Compare ViewData vs ViewBag
- Explain why ViewModels are usually preferred
```

---

# Strongly Typed Models (ViewModels)

Strongly Typed Models (ViewModels) are custom classes that encapsulate the data required by a view.

They are:
- Strongly typed
- Structured
- Type-safe

They provide:
- IntelliSense support
- Better maintainability
- Better organization
- Better readability

---

# ViewModel Example

```csharp
public class HomeViewModel
{
    public string Message { get; set; }
}
```

Controller:

```csharp
public ActionResult Index()
{
    var viewModel = new HomeViewModel
    {
        Message = "Hello, World!"
    };

    return View(viewModel);
}
```

View:

```csharp
@model HomeViewModel

<p>@Model.Message</p>
```

---

# Best Practices for ViewModels

- Use ViewModels for complex or composite data
- Keep ViewModels lightweight
- Name ViewModels clearly based on their purpose

---

# 🤖 AI Prompt

```text
Explain strongly typed Views and ViewModels in ASP.NET MVC for beginners.

Explain:
- What a ViewModel is
- Why ViewModels are useful
- What strongly typed means
- Why strongly typed Views are safer
- Why IntelliSense is useful

Use:
- Beginner-friendly explanations
- Simple examples
- One real-world analogy

At the end:
- Compare ViewModels with ViewBag and ViewData
```

---

# TempData

`TempData` is a dictionary-like object provided by ASP.NET MVC for passing data between controller actions and redirects.

Unlike ViewData and ViewBag:
- TempData persists data for the duration of a single HTTP request and subsequent redirect.

It is useful for scenarios where data needs to be passed:
- Between actions
- Across redirects
- Across controllers

---

# TempData Example

```csharp
public ActionResult FirstAction()
{
    TempData["Message"] = "Hello, World!";
    return RedirectToAction("SecondAction");
}

public ActionResult SecondAction()
{
    var message = TempData["Message"];
    return View();
}
```

View:

```csharp
<p>@TempData["Message"]</p>
```

---

# Best Practices for TempData

- Use TempData only when necessary
- TempData survives one additional request
- Avoid storing large or complex data structures

---

# 🤖 AI Prompt

```text
Explain TempData in ASP.NET MVC using beginner-friendly examples.

Explain:
- What TempData is
- Why TempData exists
- How TempData differs from ViewBag and ViewData
- Why TempData survives redirects
- When TempData is useful

Use:
- Real-world analogies
- Simple ASP.NET MVC examples
- Beginner-friendly explanations

At the end:
- Give one practical scenario where TempData is the best choice
```

---

# Demo

## HTML Helpers

- Create forms using HTML Helpers
- Generate labels and inputs
- Display validation messages

---

# Demo

## Tag Helpers

- Create forms using Tag Helpers
- Use asp-for
- Use asp-action
- Use asp-controller

---

# Demo

## Data Passing Techniques

- Pass data with ViewData
- Pass data with ViewBag
- Pass strongly typed ViewModels
- Pass data with TempData after redirect

---

# 🤖 AI Prompt

```text
Explain all ASP.NET MVC data passing techniques step by step.

Explain:
- ViewData
- ViewBag
- ViewModels
- TempData

For each one explain:
- What it is
- When it should be used
- Advantages
- Disadvantages

Use:
- Beginner-friendly explanations
- Real-world analogies
- One ASP.NET MVC example for each
```

---

# 🤖 Copilot Tip

GitHub Copilot can help you with:
- Creating forms
- Generating HTML Helpers
- Generating Tag Helpers
- Creating ViewModels
- Writing strongly typed Views
- Creating ViewData/ViewBag examples
- Creating TempData redirect flows

Before accepting suggestions:
- Check if the ViewModel matches the View
- Verify the property names
- Ensure the form routes correctly
- Keep Views clean and readable
- Avoid putting business logic inside Views

---

# 🤖 AI Prompt

```text
Review this ASP.NET MVC View and suggest improvements.

Do NOT rewrite the entire code.

Instead:
- Explain readability improvements
- Explain possible Razor mistakes
- Explain if the wrong data passing technique is used
- Explain if the View should use a ViewModel instead
```

---

# QUESTIONS?

You can find me at:

daniloborozan07@gmail.com