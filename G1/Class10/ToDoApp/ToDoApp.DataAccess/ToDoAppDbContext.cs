using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess
{
    public class ToDoAppDbContext : DbContext
    {
        //Define database tables

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Category> Category { get; set; }

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base (options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one-to-many relationship between Status and ToDo
            modelBuilder.Entity<ToDo>()
                .HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<ToDo>()
                .Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();
            modelBuilder.Entity<ToDo>()
                .Property(x => x.DueDate)
                .IsRequired();

            // one-to-many relationship between Category and ToDo
            modelBuilder.Entity<ToDo>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            //seed data for Status table
            modelBuilder.Entity<Category>()
               .HasData(
                   new Category { Id = 1, Name = "Work" },
                   new Category { Id = 2, Name = "Home" },
                   new Category { Id = 3, Name = "Exercise" },
                   new Category { Id = 4, Name = "Shopping" },
                   new Category { Id = 5, Name = "Hoby" },
                   new Category { Id = 6, Name = "FreeTime" }
               );

            modelBuilder.Entity<Status>()
                .HasData(
                     new Status { Id = 1, Name = "Open" },
                     new Status { Id = 2, Name = "Closed" }
                 );

            modelBuilder.Entity<ToDo>()
                .HasData(
                new ToDo
                {
                    Id = 1,
                    Description = "Finish project presentation",
                    DueDate = DateTime.Now.AddDays(2),
                    CategoryId = 1, //Work
                    StatusId = 1 //Open
                },
                 new ToDo
                 {
                     Id = 2,
                     Description = "Clean the house",
                     DueDate = DateTime.Now.AddDays(1),
                     CategoryId = 2, //Home
                     StatusId = 1 //Open
                 },
                  new ToDo
                  {
                      Id = 3,
                      Description = "Morning exercise",
                      DueDate = DateTime.Now,
                      CategoryId = 3, //Exercise
                      StatusId = 2 //Closed
                  },
                   new ToDo
                   {
                       Id = 4,
                       Description = "Buy groceries",
                       DueDate = DateTime.Now.AddDays(3),
                       CategoryId = 4, //Shopping
                       StatusId = 1 //Opened
                   },
                   new ToDo
                   {
                       Id = 5,
                       Description = "Watch a movie",
                       DueDate = DateTime.Now,
                       CategoryId = 6, //FreeTime
                       StatusId = 2 //Closed
                   }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
