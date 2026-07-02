using Avenga.ASP.NET.MVC.Class04.Database;
using Avenga.ASP.NET.MVC.Class04.Models.Dto;
using Avenga.ASP.NET.MVC.Class04.Models.Entities;
using Avenga.ASP.NET.MVC.Class04.Models.ViewModels;
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

        [HttpGet("create")] // GET: /students/create
        public IActionResult CreateStudent() 
        { 
            return View();
        }

        [HttpPost("create")] // POST: /students/create
        public IActionResult CreateStudent(CreateStudentVM model)
        {
            var entity = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Id = InMemoryDatabase.Students.Count + 1,
                ActiveCourse = InMemoryDatabase.Courses[1]
            };

            InMemoryDatabase.Students.Add(entity);

            return RedirectToAction("GetAllStudents");
        }
    }
}
