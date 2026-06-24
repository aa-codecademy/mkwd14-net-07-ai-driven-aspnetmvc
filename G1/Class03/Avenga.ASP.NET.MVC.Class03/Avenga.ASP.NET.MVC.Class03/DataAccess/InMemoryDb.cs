using Avenga.ASP.NET.MVC.Class03.Models.Domains;

namespace Avenga.ASP.NET.MVC.Class03.DataAccess
{
    public static class InMemoryDb
    {
        public static List<Student> Students { get; set; } // TABLE STUDENTS
        public static List<Course> Courses { get; set; } // TABLE COURSES

        static InMemoryDb()
        {
            LoadCourses();
            LoadStudents();
        }

        private static void LoadStudents()
        {
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    ActiveCourse = Courses[3]
                },
               new Student()
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-40),
                    ActiveCourse = Courses[1]
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Jill",
                    LastName = "Jillsky",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    ActiveCourse = Courses[2]
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-29),
                    ActiveCourse = Courses[2]
                },
            };
        }

        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new Course()
                {
                    Id = 1,
                    Name = "C#",
                    NumberOfClasses = 10
                },
                new Course()
                {
                    Id = 2,
                    Name = "Javascript",
                    NumberOfClasses = 15
                },
                new Course()
                {
                    Id = 3,
                    Name = "ASP.Net MVC",
                    NumberOfClasses = 10
                }
            };
        }
    }
}
