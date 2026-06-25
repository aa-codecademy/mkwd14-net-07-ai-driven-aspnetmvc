using Models.Models.Domain;

namespace Models.Database
{
    public static class StaticDb
    {
        static StaticDb()
        {
            LoadCourses();
            LoadStudents();
        }

        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }

        //static methods for retrieving data

        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new Course() { Id = 1, Name = "C# Basic", NumberOfClasses = 10 },
                new Course() { Id = 2, Name = "C# Advanced", NumberOfClasses = 15 },
                new Course() { Id = 3, Name = "SQL", NumberOfClasses = 7 },
                new Course() { Id = 4, Name = "MVC", NumberOfClasses = 10 }
            };
        }

        private static void LoadStudents()
        {
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Firstname = "Petko",
                    Lastname= "Petkovski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[0]
                },
                 new Student()
                {
                    Id = 2,
                    Firstname = "Marko",
                    Lastname= "Markovski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[1]
                },

                  new Student()
                {
                    Id = 3,
                    Firstname = "Trajko",
                    Lastname= "Trajkovski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[2]
                },

                    new Student()
                {
                    Id = 4,
                    Firstname = "Stefan",
                    Lastname= "Stefanovski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[3]
                },
            };
        }
    }
}
