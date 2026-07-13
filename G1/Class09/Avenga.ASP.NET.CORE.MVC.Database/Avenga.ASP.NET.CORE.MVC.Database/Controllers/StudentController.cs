using Avenga.ASP.NET.CORE.MVC.Database.DataAccess;
using Avenga.ASP.NET.CORE.MVC.Database.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avenga.ASP.NET.CORE.MVC.Database.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly DemoDbContext _context;
        public StudentController(DemoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            //SELECET * FROM STUDENTS
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var courses = _context.Courses.ToList();
            ViewBag.Courses = new SelectList(courses,"Id", "Name");
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm]Student student)
        {
            return View(student);
        }
    }
}
