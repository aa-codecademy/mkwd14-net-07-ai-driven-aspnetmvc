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

        [HttpGet("{id}/{age}")]
        public IActionResult GetStudentById([FromRoute]int id, int age)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentDetailsVM(student);
            return View("StudentDetails", studentVM);
        }
        [HttpGet("id")]
        public IActionResult GetStudentByIdWithQuery([FromQuery] int id)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentDetailsVM(student);
            return View("StudentDetails", studentVM);
        }

        [HttpGet("filterBy")]
        public IActionResult GetStudentFilter([FromQuery] StudentFilterViewModel studentFilterViewModel)
        {
            var student = StaticDb.Students.FirstOrDefault(x => (DateTime.Now.Year - x.DateOfBirth.Year) == studentFilterViewModel.Age && x.GetFullName().ToLower() == studentFilterViewModel.FullName.ToLower());
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentDetailsVM(student);
            return View("StudentDetails", studentVM);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CreateStudentVM createStudentVM)
        {
            if(ModelState.IsValid)
            {
                StaticDb.Students.Add(Mapper.MapToStudent(createStudentVM));
                return RedirectToAction("Index");
            }
            return View(createStudentVM);
        }
    }
}
