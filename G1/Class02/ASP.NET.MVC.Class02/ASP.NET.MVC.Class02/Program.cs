using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// CONVENTIONAL ROUTING
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "allCourses",
    pattern: "courses/allcourses",
    defaults: new {controller = "Courses", action = "GetAllCourses"}
    );

app.MapControllerRoute(
    "course_by_name_with_constraint",
    pattern: "courses/{name}",
    defaults: new { controller = "Courses", action = "GetCourseByName" },
    constraints: new {name = new MinLengthRouteConstraint(5) }
    );

app.MapControllerRoute(
    "course_multiple_params",
    pattern: "courses/{id}/{name}",
    defaults: new { controller = "Courses", action = "GetCourseByIdAndName" },
    constraints: new { id = new IntRouteConstraint() }
    );

app.MapControllerRoute(
    "course_by_id",
    pattern: "courses/getCourseById/{id:int}",
    defaults: new { controller = "Courses", action = "GetCourseById" }
    );
app.Run();
