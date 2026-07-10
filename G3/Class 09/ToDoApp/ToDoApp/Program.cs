using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess;
using ToDoApp.DataAccess.EFImplementation;
using ToDoApp.DataAccess.Implementation;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Services.Implementation;
using ToDoApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Register Database
//string connectionString = "Server=.\\SQLEXPRESS;Database=TodoAppDbG3;Trusted_Connection=True;Integrated Security=true;Encrypt=False;TrustServerCertificate=True";

//get the connection string from app settings
string connectionString = builder.Configuration.GetConnectionString("TodoAppConnectionString");
builder.Services.AddDbContext<ToDoAppDbContext>(options => options.UseSqlServer(connectionString));
#endregion

//Here we register the dependencies using Dependency Injection
#region Register repositories
//this tells the app that anywhere where an instance of IRepository<ToDo> is requested, the impl that should be called is ToDoRepository impl
//if we later on create a new impl and decide to change it, we only need to come here and change instead of ToDoRepository to use the new impl

//singleton lifetime ; a new instance is created the first time it is requested and that instance is used and shared among the whole app
//builder.Services.AddSingleton<IRepository<ToDo>, ToDoRepository>();

//Transient lifetime: a new instance is created every time it is requested
//builder.Services.AddTransient<IRepository<ToDo>, ToDoRepository>();

//scoped lifetime: a new instance is created once per client request (if in a HTTP req there are multiple requests for this resource, the same instance is used)
builder.Services.AddScoped<IRepository<ToDo>, ToDoRepository>();
//builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Category>, EFCategoryRepository>();
builder.Services.AddScoped<IRepository<Status>, StatusRepository>();
#endregion

#region Register services
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IFilterService, FilterService>();
#endregion


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
