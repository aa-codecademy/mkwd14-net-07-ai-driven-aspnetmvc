namespace Avenga.ASP.NET.CORE.MVC.Database.Models.Domains
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ActiveCourseId { get; set; }
        public Course ActiveCourse { get; set; }
    }
}
