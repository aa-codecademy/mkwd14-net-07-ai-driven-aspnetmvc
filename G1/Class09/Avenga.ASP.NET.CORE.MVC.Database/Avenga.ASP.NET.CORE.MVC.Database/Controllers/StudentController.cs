using Avenga.ASP.NET.CORE.MVC.Database.DataAccess;
using Avenga.ASP.NET.CORE.MVC.Database.Models.Domains;
using Microsoft.AspNetCore.Mvc;

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
            List<Student> students = _context.Students.ToList();
            return View(students);
        }
    }
}
