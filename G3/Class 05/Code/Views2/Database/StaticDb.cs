using Views2.Models.Domain;

namespace Views2.Database
{
    public static class StaticDb
    {
        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }

        static StaticDb()
        {
            LoadCourses();
            LoadStudents();
        }

        public static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new Course() {Id = 1, Name = "C# Basic", NumberOfClasses = 10},
                new Course() {Id = 2, Name = "C# Advanced", NumberOfClasses = 15},
                new Course() {Id = 3, Name = "SQL", NumberOfClasses = 7},
                new Course() {Id = 4, Name = "MVC", NumberOfClasses = 10},
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
                    Lastname = "Petkovski",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    ActiveCourse = Courses[0]
                },
                new Student()
                {
                    Id = 2,
                    Firstname = "Trajko",
                    Lastname = "Trajkovski",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    ActiveCourse = Courses[1]
                },
                new Student()
                {
                    Id = 1,
                    Firstname = "Marko",
                    Lastname = "Markovski",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    ActiveCourse = Courses[2]
                },
                new Student()
                {
                    Id = 1,
                    Firstname = "Stefan",
                    Lastname = "Stefanovski",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    ActiveCourse = Courses[3]
                },
            };
        }
    }
}
