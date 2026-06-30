using Avenga.ASP.NET.MVC.Class04.Database;
using Avenga.ASP.NET.MVC.Class04.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.ASP.NET.MVC.Class04.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        public IActionResult GetAllStudents()
        {
            var students = InMemoryDatabase.Students.Select(x=> 
            new StudentWithCourseDto(x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.ActiveCourse.Id, x.ActiveCourse.Name)
            );
            return View(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = InMemoryDatabase.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return View();
            }
            var studentDto = new StudentWithCourseDto(student.Id, student.FirstName, student.LastName, student.DateOfBirth, student.ActiveCourse.Id, student.ActiveCourse.Name);
            return View(studentDto);
        }
    }
}
