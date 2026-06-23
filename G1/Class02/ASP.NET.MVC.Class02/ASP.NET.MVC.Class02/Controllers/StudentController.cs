using ASP.NET.MVC.Class02.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.MVC.Class02.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private List<Student> _students = new List<Student>
        {
            new Student()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobski",
                DateOfBirth = DateTime.Now.AddYears(-27)
            },
            new Student()
            {
                Id = 2,
                FirstName = "Jill",
                LastName = "Jilski",
                DateOfBirth = DateTime.Now.AddYears(-37)
            },
            new Student()
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now.AddYears(-45)
            },
            new Student()
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Doe",
                DateOfBirth = DateTime.Now.AddYears(-17)
            },
        };
        [Route("all")] // students/all
        [HttpGet("all")] // students/all
        public IActionResult GetAllStudents()
        {
            return Json(_students);
        }

        // students/getById/1 or students/1 -- custome route
        [HttpGet("getById/{id:int}")]
        public IActionResult GetById(int id) 
        {
            return Json(_students.FirstOrDefault(x => x.Id == id));
        }
    }
}
