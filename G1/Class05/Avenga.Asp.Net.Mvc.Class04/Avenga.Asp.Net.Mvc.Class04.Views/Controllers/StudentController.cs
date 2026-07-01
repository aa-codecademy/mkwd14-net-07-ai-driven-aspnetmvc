using Avenga.Asp.Net.Mvc.Class04.Views.Database;
using Avenga.Asp.Net.Mvc.Class04.Views.Models.DtoModels;
using Avenga.Asp.Net.Mvc.Class04.Views.Models.Entities;
using Avenga.Asp.Net.Mvc.Class04.Views.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Avenga.Asp.Net.Mvc.Class04.Views.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        
        public ActionResult Index()
        {
            return View(InMemoryDatabase.Students.Select(x => new StudentWithCourseDto(x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.ActiveCourse.Id, x.ActiveCourse.Name)));
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var student = InMemoryDatabase.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return View();
            }

            var studentWithCourse = new StudentWithCourseDto(student.Id, student.FirstName, student.LastName, student.DateOfBirth, student.ActiveCourse.Id, student.ActiveCourse.Name);

            return View(studentWithCourse);
        }
        [HttpGet("create")]
        public ActionResult CreateStudent()
        {
            return View();
        }


        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentVM viewModel)
        {
            // Map view model to your entity model
            var entity = new Student
            {
                DateOfBirth = viewModel.DateOfBirth,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Id = InMemoryDatabase.Students.Count + 1,
                ActiveCourse = InMemoryDatabase.Courses[3]
            };

            InMemoryDatabase.Students.Add(entity);

            return RedirectToAction("Index"); // Redirect to index action after successful creation
        }
        //[HttpGet("create")]
        //public IActionResult CreateStudent()
        //{
        //    var courses = InMemoryDatabase.Courses;
        //    var model = new CreateStudentVM
        //    {
        //        Courses = courses.Select(c => new SelectListItem
        //        {
        //            Value = c.Id.ToString(),
        //            Text = c.Name
        //        }).ToList()
        //    };
        //    return View(model);
        //}

        //[HttpPost("create")]
        //public IActionResult CreateStudent(CreateStudentVM viewModel)
        //{
        //    var selectedCourse = InMemoryDatabase.Courses.FirstOrDefault(c => c.Id == viewModel.SelectedCourseId);

        //    var entity = new Student
        //    {
        //        DateOfBirth = viewModel.DateOfBirth,
        //        FirstName = viewModel.FirstName,
        //        LastName = viewModel.LastName,
        //        Id = InMemoryDatabase.Students.Count + 1,
        //        ActiveCourse = selectedCourse
        //    };

        //    InMemoryDatabase.Students.Add(entity);

        //    return RedirectToAction("Index");
        //}


    }
}
