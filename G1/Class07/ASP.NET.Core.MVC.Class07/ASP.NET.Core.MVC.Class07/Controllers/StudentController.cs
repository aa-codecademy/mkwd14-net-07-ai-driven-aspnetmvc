using ASP.NET.Core.MVC.Class07.Database;
using ASP.NET.Core.MVC.Class07.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ASP.NET.Core.MVC.Class07.Helpers;

namespace ASP.NET.Core.MVC.Class07.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentVM> students = StaticDb.Students.Select(x =>
            Mapper.MapToStudentVM(x)
            ).ToList();

            return View(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute]int id)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentVM(student);
            return View("StudentDetails", studentVM);
        }
    }
}
