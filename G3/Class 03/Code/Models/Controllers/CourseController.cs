using Microsoft.AspNetCore.Mvc;
using Models.Models.ViewModels;
using Models.Services;

namespace Models.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet("getCourses")]
        public IActionResult GetCourses() //we need a view with the same name as the action in the controller
        {
            List<CourseViewModel> courses = _courseService.GetCoursesWithMoreThanNineClasses();
            if(courses != null && courses.Any())
            {
                return View(courses); //here we pass the view model to the view, the view does not come in contact with the domain model
            }

            return Content("No courses available");
        }
    }
}
