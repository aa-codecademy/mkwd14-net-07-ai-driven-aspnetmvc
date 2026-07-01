using System.Collections.Generic;

namespace Avenga.Asp.Net.Mvc.Class04.Views.Models.DtoModels
{
    public class CoursesWithStudentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentDto> Students { get; set; }
        public CoursesWithStudentsDto()
        {
            Students = new List<StudentDto>();
        }
    }
}
