using ASP.NET.MVC.Class02.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.MVC.Class02.Controllers
{
    public class CoursesController : Controller
    {

        private List<Course> _courses = new List<Course>()
        {
            new Course { Id = 1, Name = "C# Basics", NumberOfClasses = 10 },
            new Course { Id = 2, Name = "ASP.NET Core MVC", NumberOfClasses = 15 },
            new Course { Id = 3, Name = "Entity Framework Core", NumberOfClasses = 12 }
        };

        //default HTTPGET method
        public IActionResult GetAllCourses()
        {
            return Json(_courses);
        }

        public IActionResult GetCourseById(int id)  //localhost:port/courses/getCoursesById/10
        {
            return Json(_courses.FirstOrDefault(x => x.Id == id));
        }

        public JsonResult GetCourseByName(string name) //localhost:port/courses/ASP.NET%20Core%20MVC -- custome
        {
            return Json(_courses.FirstOrDefault(x => x.Name == name));
        }

        public IActionResult GetCourseByIdAndName(int id, string name) //localhost:port/courses/getCourseByIdAndName/1/C%23%20Basics
        {
            return Json(_courses.FirstOrDefault(x => x.Id == id && x.Name == name));
        }
    }
}
