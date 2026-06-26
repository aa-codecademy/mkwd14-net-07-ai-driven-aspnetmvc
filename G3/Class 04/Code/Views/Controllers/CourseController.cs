using Microsoft.AspNetCore.Mvc;
using Views.Database;
using Views.Models.ViewModels;

namespace Views.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            List<CourseWithStudentsViewModel> courses = StaticDb.Courses.Select(x => new CourseWithStudentsViewModel
            {
                CourseName = x.Name,
                NumberOfClasses = x.NumberOfClasses,
                Students = StaticDb.Students
                .Where(s => s.ActiveCourse.Id == x.Id)
                .Select(s => new StudentInfoViewModel
                {
                    FirstName = s.Firstname,
                    LastName = s.Lastname,
                    Age = DateTime.Now.Year - s.DateOfBirth.Year
                }).ToList()
            }).ToList();

            return View(courses);
        }
    }
}
