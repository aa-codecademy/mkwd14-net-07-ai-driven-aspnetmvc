using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess
{
    //Defines and configures the db context for our entities
    public class ToDoAppDbContext : DbContext
    {
        //Define db tables
        //DbSet<T> is a collection of entities of type T that can be queried
        //it corresponds to a table in db, where the properties are columns
        //here we are telling the db context that out of all our classes (.cs), only these should be added as tables in the db
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many -> each ToDo has one status, each status can have many ToDos
            modelBuilder.Entity<ToDo>() //the entity toDo
                .HasOne(x => x.Status)  //has only one status (the todo item can be either New or Done or InProgress)
                .WithMany() //the status can have many toDos (we can have 10 or more todo items that are in status New)
                .HasForeignKey(x => x.StatusId); // the way that this relationship is formed is by using the foreign key StatusId

            modelBuilder.Entity<ToDo>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            //seeding - add initial data in the db
            modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Home" },
                new Category { Id = 3, Name = "Exercise" },
                new Category { Id = 4, Name = "Shopping" },
                new Category { Id = 5, Name = "Coding" },
                new Category { Id = 6, Name = "FreeTime" }
                );

            modelBuilder.Entity<Status>()
            .HasData(
                new Status { Id = 1, Name = "New" },
                new Status { Id = 2, Name = "Done" }
            );

            modelBuilder.Entity<ToDo>()
            .HasData(
                new ToDo()
                {
                    Id = 1,
                    Description = "Finish project presentation",
                    DueDate = DateTime.Now.AddDays(1),
                    CategoryId = 5, //Coding
                    StatusId = 1, //New
                },

                new ToDo()
                {
                    Id = 2,
                    Description = "Clean the house",
                    DueDate = DateTime.Now.AddDays(2),
                    CategoryId = 2,
                    StatusId = 1,
                },

                 new ToDo()
                 {
                     Id = 3,
                     Description = "Morning exercise",
                     DueDate = DateTime.Now,
                     CategoryId = 3,
                     StatusId = 2,
                 },

                   new ToDo()
                   {
                       Id = 4,
                       Description = "Buy groceries",
                       DueDate = DateTime.Now.AddDays(-3),
                       CategoryId = 4,
                       StatusId = 1,
                   },

                    new ToDo()
                    {
                        Id = 5,
                        Description = "Watch a movie",
                        DueDate = DateTime.Now,
                        CategoryId = 6,
                        StatusId = 2,
                    }
);

            //we want to use the logic for this method that is written in the parent (the DbContext class), we just want to add our own logic to this method as well
            base.OnModelCreating(modelBuilder);
        }
    }
}
