namespace Avenga.ASP.NET.MVC.Class04.Models.Dto
{
    public class CoursesWithStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
