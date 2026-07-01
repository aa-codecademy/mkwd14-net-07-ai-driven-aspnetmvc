using Microsoft.AspNetCore.Mvc;
using Avenga.Asp.Net.Mvc.Class04.Views.Database;
using Avenga.Asp.Net.Mvc.Class04.Views.Models.DtoModels;
using System.Collections.Generic;
using System.Linq;

namespace Avenga.Asp.Net.Mvc.Class04.Views.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var courses = InMemoryDatabase.Courses;
            var coursesList = new List<CoursesWithStudentsDto>();
            foreach (var course in courses) 
            {
                var students = InMemoryDatabase.Students.Where(y => y.ActiveCourse.Id == course.Id)
                     .Select(z => new StudentDto { FullName = z.FirstName + " " + z.LastName });
                coursesList.Add(new CoursesWithStudentsDto
                { Id = course.Id, Name = course.Name, Students = students.ToList() });
            }
            return View(coursesList);
        }
    }
}
