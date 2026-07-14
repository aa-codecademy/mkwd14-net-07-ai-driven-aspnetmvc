namespace Avenga.ASP.NET.CORE.MVC.Database.Models.Domains
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfClasses { get; set; }
        public bool IsActiveCourse { get; set; }
    }
}
