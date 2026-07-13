using Avenga.ASP.NET.CORE.MVC.Database.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace Avenga.ASP.NET.CORE.MVC.Database.DataAccess
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Course> courses = new List<Course>()
            {
                new() { Id = 1, Name = "C# basic", NumberOfClasses = 40 },
                new() { Id = 2, Name = "C# Advanced", NumberOfClasses = 60 },
                new() { Id = 3, Name = "Database development and design", NumberOfClasses = 28 },
                new() { Id = 4, Name = "ASP.NET Mvc", NumberOfClasses = 40 }
            };
            var students = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobski",
                    DateOfBirth = DateTime.Now.AddYears(-27),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jilski",
                    DateOfBirth = DateTime.Now.AddYears(-37),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-45),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-17),
                    ActiveCourseId = 4
                },
            };

            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Student>().HasData(students);
            base.OnModelCreating(modelBuilder);
        }
    }
}
