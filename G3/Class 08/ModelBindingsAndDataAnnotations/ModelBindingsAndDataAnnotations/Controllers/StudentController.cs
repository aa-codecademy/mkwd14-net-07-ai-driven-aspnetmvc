using Microsoft.AspNetCore.Mvc;
using ModelBindingsAndDataAnnotations.Database;
using ModelBindingsAndDataAnnotations.Mapper;
using ModelBindingsAndDataAnnotations.Models;
using ModelBindingsAndDataAnnotations.Models.ViewModels;
using System.Diagnostics;

namespace ModelBindingsAndDataAnnotations.Controllers
{
    //In this class we don't use the n-tier arch to focus on the model bindings and data annotations
    [Route("students")]
    public class StudentController : Controller
    {
        //students
        public IActionResult Index()
        {
            //from the db we get the Student domain model, we need to map it in view model and send it to the view
            
            List<StudentViewModel> students = StaticDb.Students.Select(x => x.MapToStudentViewModel()).ToList();
            return View(students);
        }

        //students/1 - we tell the action that the id will be sent in the route so that it looks for it and maps it from there
        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);

            StudentDetailsViewModel studentDetails = student.MapToStudentDetailsVM();
            return View("StudentDetails", studentDetails); //we tell it to return a view named StudentDetails (instead of GetStudentById)
        }

        //First way
        //[HttpGet("filterBy")] //students/filterBy?fullname=Petko Petkovski&age=30
        //public IActionResult GetStudentByQueryFilter([FromQuery]string fullname, [FromQuery] int age)
        //{
        //    var student = StaticDb.Students.FirstOrDefault(x => x.GetFullName().ToLower() == fullname.ToLower()
        //                                                     && (DateTime.Now.Year - x.DateOfBirth.Year) == age);

        //    StudentDetailsViewModel studentDetails = student.MapToStudentDetailsVM();
        //    return View("StudentDetails", studentDetails);
        //}

        [HttpGet("filterBy")] //students/filterBy?fullname=Petko Petkovski&age=30
        public IActionResult GetStudentByQueryFilter([FromQuery] StudentFilterViewModel model)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.GetFullName().ToLower() == model.Fullname.ToLower()
                                                             && (DateTime.Now.Year - x.DateOfBirth.Year) == model.Age);

            StudentDetailsViewModel studentDetails = student.MapToStudentDetailsVM();
            return View("StudentDetails", studentDetails);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var model = new CreateViewModel();
            return View(model);
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CreateViewModel createViewModel)
        {
            if(createViewModel == null)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            if (ModelState.IsValid)
            {
                StaticDb.Students.Add(createViewModel.ToStudent());
                return RedirectToAction("Index"); //if the validation of the model was successful, add the new item and redirect to index to list all the students including the newly added
            }

            return View(createViewModel); //if the model is not valid, return the model with all the validation messages (errors)
        }
    }
}
