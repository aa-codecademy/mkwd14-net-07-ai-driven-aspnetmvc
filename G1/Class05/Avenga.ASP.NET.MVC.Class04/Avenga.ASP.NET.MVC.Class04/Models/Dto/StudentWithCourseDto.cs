namespace Avenga.ASP.NET.MVC.Class04.Models.Dto
{
    public class StudentWithCourseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        public string NameOfCourse { get; set; }

        public StudentWithCourseDto(int id, string firstName, string lastName, DateTime dateOfBirth, int courseId, string nameOfCourse ) 
        {
            Id = id;
            FullName = $"{firstName} {lastName}";
            Age = DateTime.Now.Year - dateOfBirth.Year;
            CourseId = courseId;
            NameOfCourse = nameOfCourse;
        }
    }
}
