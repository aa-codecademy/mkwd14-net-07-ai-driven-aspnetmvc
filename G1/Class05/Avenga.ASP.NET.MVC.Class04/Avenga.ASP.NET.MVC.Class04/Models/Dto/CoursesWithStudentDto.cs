namespace Avenga.ASP.NET.MVC.Class04.Models.Dto
{
    public class CoursesWithStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Descrption { get; set; }
        public string? Subscribe { get; set; }
        public string? Role { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
