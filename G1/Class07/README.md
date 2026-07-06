# Model Bindings & Data Annotations

# ASP.NET MVC

Trainer - Danilo Borozan

---

# RETROSPECTIVE

- What are HTML Helpers?
- What are TAG Helpers?
- What types of data passing techniques are there?
- What are the differences between ViewData and TempData?

---

# AGENDA

- Model Bindings
- Types of Model Bindings
- Binding Attributes
- Data Annotations

---

# MODEL BINDINGS

Model Binding in ASP.NET is a process that automatically maps data from various sources such as:
- HTTP request parameters
- Route data
- Form values
- JSON data

to:
- Parameters of controller action methods
- Properties of model objects

It abstracts away the tedious task of manually extracting and parsing data from request objects, making it easier to work with incoming data in controller actions.

---

# What is Model Binding?

Model Binding is a mechanism in ASP.NET Core Application that extracts the data from an HTTP request and provides it to:
- Controller action method parameters
- Object properties

The action method parameters can be:
- Simple types
  - int
  - string
  - bool
- Complex types
  - Student
  - Product
  - Order

This is one of the most useful features in ASP.NET MVC because mapping incoming data manually would otherwise require a lot of repetitive code.

---

# 🤖 AI Prompt

```text
Explain Model Binding in ASP.NET MVC for complete beginners.

Explain:
- What Model Binding is
- Why Model Binding exists
- What problem it solves
- How ASP.NET automatically maps incoming data
- What happens when a form is submitted

Explain the difference between:
- Simple types
- Complex types

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple ASP.NET MVC examples

At the end:
- Explain why Model Binding improves developer productivity
- Give one beginner practice exercise
```

---

# TYPES OF MODEL BINDINGS

## Parameter Binding

Parameter Binding maps data from:
- Route data
- Query string parameters
- Form values

to the parameters of controller action methods.

Example:

```csharp
public IActionResult Index(int id)
{
    // code here
}
```

In this example:
```csharp
id
```

is automatically bound from the request.

---

# Model Binding

Model Binding maps data from:
- HTTP request parameters
- Form values
- JSON data

to the properties of model objects.

This feature allows binding data from various sources to parameters or properties in controller action methods.

Example:

```csharp
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
}

public IActionResult Index(Student std)
{
    // code here
}
```

In this example:
```csharp
std
```

is a complex type bound automatically from the request.

---

# 🤖 AI Prompt

```text
Explain the difference between Parameter Binding and Model Binding in ASP.NET MVC.

Explain:
- What Parameter Binding is
- What Model Binding is
- When each one is used
- Why Model Binding is useful for forms
- How ASP.NET matches incoming values to properties

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple controller examples
- Simple form examples

At the end:
- Compare both approaches
- Explain when beginners will most commonly use each one
```

---

# BINDING ATTRIBUTES

ASP.NET offers several binding attributes to control where data comes from.

---

# FromBody

The `[FromBody]` attribute binds data from the request body to a parameter or property.

---

# FromQuery

The `[FromQuery]` attribute binds data from the query string to a parameter or property.

---

# FromRoute

The `[FromRoute]` attribute binds data from route parameters to a parameter or property.

---

# FromForm

The `[FromForm]` attribute binds data from form values to a parameter or property.

---

# FromHeader

The `[FromHeader]` attribute binds data from request headers to a parameter or property.

---

# Example with Binding Attributes

```csharp
public IActionResult Update([FromQuery]int id, [FromForm]Student std)
{
    // code here
}
```

In this example:
- `id` comes from the query string
- `std` comes from form data

---

# 🤖 AI Prompt

```text
Explain ASP.NET MVC Binding Attributes for beginners.

Explain:
- FromBody
- FromQuery
- FromRoute
- FromForm
- FromHeader

For each attribute explain:
- What it does
- Where the data comes from
- When it is commonly used

Use:
- Beginner-friendly explanations
- Real-world analogies
- Simple ASP.NET MVC examples

At the end:
- Compare the attributes
- Explain which ones beginners will use most often
```

---

# Why Model Binding is Useful

## Simplifies Data Handling

Model Binding simplifies the task of handling incoming request data by automating the mapping process.

---

## Reduces Boilerplate Code

Model Binding eliminates the need for manual parsing and extraction of data from request objects.

This reduces repetitive boilerplate code inside controllers.

---

## Improves Productivity

By automating the data mapping process, Model Binding improves developer productivity and reduces the likelihood of errors.

---

# How Model Binding Works

When a request is made to a controller action method, ASP.NET examines the method's parameters.

For parameter binding, ASP.NET looks for values in:
- Route data
- Query string parameters
- Form values
- Request headers

For model binding, ASP.NET binds data from:
- HTTP request parameters
- Form values
- JSON data

to the properties of model objects based on property names.

---

# KEEP IN MIND

## Define ViewModels

Define ViewModels that represent the specific data needed for views.

ViewModels provide a clear contract between:
- View
- Controller

reducing the risk of over-posting vulnerabilities.

---

## Always Validate Input Data

Always validate input data before using it in the application.

Use:
- Data annotations
- Custom validation logic

to ensure:
- Data integrity
- Security

---

## Avoid Over-Posting

Ensure that only the necessary properties are included in the bound model object.

Use:
- ViewModels
- Bind attributes

to control which properties are bound.

---

## Be Mindful of Security

Model Binding can introduce security risks such as over-posting vulnerabilities.

Apply security best practices such as:
- Input validation
- Parameterized queries

to mitigate these risks.

---

# 🤖 AI Prompt

```text
Explain over-posting vulnerabilities in ASP.NET MVC for beginners.

Explain:
- What over-posting means
- Why it can be dangerous
- How Model Binding can accidentally expose data
- Why ViewModels help improve security

Use:
- Beginner-friendly explanations
- Simple examples
- One real-world analogy

At the end:
- Explain best practices beginners should follow
```

---

# DATA ANNOTATIONS

Data Annotation validations in ASP.NET are a set of attributes provided by the:

```csharp
System.ComponentModel.DataAnnotations
```

namespace.

They allow developers to define validation rules directly within model classes.

These attributes provide a declarative way to specify constraints on data input such as:
- Required fields
- String length
- Regular expression patterns
- Range validation
- Email validation

and more.

---

# WHY DO WE NEED DATA ANNOTATION VALIDATIONS?

## Data Integrity

Ensures that the data entered by users adheres to specific criteria, maintaining:
- Data integrity
- Consistency

---

## Improved User Experience

By validating input data on the server-side, Data Annotation Validations help prevent invalid data from being submitted.

---

## Security

Validating user input helps mitigate security risks such as:
- SQL injection
- Cross-site scripting (XSS)

by ensuring that only valid data is processed by the application.

---

# Validation on ViewModels

ViewModels are classes that represent data to be displayed or posted back from a View.

Example:

```csharp
public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
```

---

# Validation on Domain Models

Domain Models represent the data in the application's business domain.

Example:

```csharp
public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Range(0, 999.99)]
    public decimal Price { get; set; }

    [Required]
    public string Category { get; set; }
}
```

---

# Common Validation Attributes

- `[Required]`
- `[StringLength]`
- `[Range]`
- `[Compare]`
- `[EmailAddress]`
- `[RegularExpression]`
- `[DataType]`

---

# 🤖 AI Prompt

```text
Explain Data Annotations in ASP.NET MVC for beginners.

Explain:
- What Data Annotations are
- Why validation is important
- Why applications should validate user input
- How validation improves security and user experience

Explain these attributes:
- Required
- StringLength
- Range
- Compare
- EmailAddress

Use:
- Beginner-friendly explanations
- Simple examples
- Real-world analogies

At the end:
- Explain what happens if applications do not validate user input
```

---

# BEST PRACTICES FOR DATA ANNOTATION VALIDATIONS

## Apply to ViewModel

Data Annotation Validations should be applied to ViewModel classes rather than Domain Model classes to ensure separation of concerns and maintain flexibility.

---

## Use Multiple Attributes

Combine multiple validation attributes to enforce multiple rules on a single property.

Example:
- `Required`
- `StringLength`
- `RegularExpression`

---

## Custom Error Messages

Provide custom error messages to improve user understanding.

---

## Client-Side Validation

Enable client-side validation to provide immediate feedback to users without requiring a full request to the server.

---

## Server-Side Validation

Always perform server-side validation in addition to client-side validation because client-side validation can be bypassed.

---

# Model Validation in Controllers

ASP.NET MVC automatically validates models based on Data Annotations.

Validation results are stored inside:
```csharp
ModelState
```

Example:

```csharp
[HttpPost]
public ActionResult Create(Product product)
{
    if (ModelState.IsValid)
    {
        // Save the product to the database

        return RedirectToAction("Index");
    }

    return View(product);
}
```

---

# Display Validation Errors in Views

```html
@model Product

@using (Html.BeginForm())
{
    @Html.LabelFor(m => m.Name)
    @Html.EditorFor(m => m.Name)
    @Html.ValidationMessageFor(m => m.Name)

    @Html.LabelFor(m => m.Price)
    @Html.EditorFor(m => m.Price)
    @Html.ValidationMessageFor(m => m.Price)

    <input type="submit" value="Create" />
}
```

`Html.ValidationMessageFor` displays validation errors for a specific property.

---

# 🤖 AI Prompt

```text
Explain ModelState and validation flow in ASP.NET MVC for beginners.

Explain:
- What ModelState is
- What ModelState.IsValid means
- How ASP.NET validates models automatically
- How validation errors are displayed in Views

Use:
- Beginner-friendly explanations
- Simple examples
- One real-world analogy

At the end:
- Explain the complete flow from form submission to validation
```

---

# FLUENT VALIDATIONS

Fluent Validation is a popular validation library in .NET that provides a fluent interface for defining validation rules.

Unlike Data Annotation validations:
- Fluent Validation separates validation logic from model classes
- Allows more flexibility and customization

---

# BEST PRACTICES FOR FLUENT VALIDATIONS

## Separate Validator Classes

Define separate validator classes for each model type.

---

## Use Fluent Interface

Leverage the fluent interface provided by Fluent Validation to define validation rules clearly.

---

## Custom Error Messages

Provide meaningful error messages for each validation rule.

---

## Reuse Validation Rules

Reuse common validation rules across multiple model classes.

---

## Test Validation Logic

Write unit tests to ensure validation rules are working correctly.

---

# 🤖 AI Prompt

```text
Explain the difference between Data Annotations and Fluent Validation in ASP.NET MVC.

Explain:
- What Data Annotations are
- What Fluent Validation is
- Why Fluent Validation exists
- Advantages and disadvantages of both approaches

Use:
- Beginner-friendly explanations
- Simple examples
- One comparison table

At the end:
- Explain which approach beginners should start with
```

---

# 🤖 Copilot Tip

GitHub Copilot can help you with:
- Creating ViewModels
- Creating validation attributes
- Writing ModelState validation logic
- Generating forms
- Generating validation messages
- Creating FluentValidation validators

Before accepting suggestions:
- Verify validation rules carefully
- Ensure property names are correct
- Check if validation messages make sense
- Avoid exposing unnecessary properties
- Keep ViewModels focused and simple

---

# 🤖 AI Prompt

```text
Review this ASP.NET MVC ViewModel and validation setup.

Do NOT rewrite the entire code.

Instead:
- Explain possible validation improvements
- Explain possible security risks
- Explain whether the ViewModel contains unnecessary properties
- Explain whether validation rules are missing
```

---

# QUESTIONS?

You can find me at:

daniloborozan07@gmail.com