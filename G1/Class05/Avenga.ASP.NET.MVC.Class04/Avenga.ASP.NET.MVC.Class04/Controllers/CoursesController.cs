using Avenga.ASP.NET.MVC.Class04.Database;
using Avenga.ASP.NET.MVC.Class04.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.ASP.NET.MVC.Class04.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            var courses = InMemoryDatabase.Courses;
            var coursesList = new List<CoursesWithStudentDto>();

            foreach (var course in courses)
            {
                var students = InMemoryDatabase.Students.Where(x => x.ActiveCourse.Id == course.Id)
                    .Select(x => new StudentDto()
                    {
                        FullName = $"{x.FirstName} {x.LastName}",
                        Age = DateTime.Now.Year - x.DateOfBirth.Year
                    }).ToList();
                coursesList.Add(new CoursesWithStudentDto()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Students = students
                });
            }
            return View(coursesList);
        }
    }
}
