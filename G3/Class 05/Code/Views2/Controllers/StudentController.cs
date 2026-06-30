using Microsoft.AspNetCore.Mvc;
using Views2.Database;
using Views2.Models.Domain;
using Views2.Models.ViewModels;

namespace Views2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            //1. get students from db
            List<Student> studentsDb = StaticDb.Students;

            //2. map to corresponding ViewModel
            List<StudentViewModel> mappedStudents = studentsDb.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Fullname = $"{x.Firstname} {x.Lastname}",
                Age = DateTime.Now.Year - x.DateOfBirth.Year,
                ActiveCourseName = x.ActiveCourse?.Name
            }).ToList();

            ViewData["CurrentDate"] = DateTime.Now.ToShortDateString();
            ViewBag.WelcomeMessage = "Welcome to the student management system";
            return View(mappedStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateStudentViewModel createStudentViewModel = new CreateStudentViewModel();
            createStudentViewModel.Courses = StaticDb.Courses.Select(x => new CourseOptionViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return View(createStudentViewModel); //we need to send an empty view model to the view in the get call, and later on the user will populate the form (the viewmodel) and will send the data back to the controller so that that data can be saved in the db
        }

        [HttpPost]
        public IActionResult Create(CreateStudentViewModel model)
        {
            Student student = new Student
            {
                Id = StaticDb.Students.LastOrDefault() != null ? StaticDb.Students.LastOrDefault().Id + 1 : 0,
                Firstname = model.FirstName,
                Lastname = model.LastName,
                DateOfBirth = model.DateOfBirth,
                ActiveCourse = StaticDb.Courses.FirstOrDefault(x => x.Id == model.ActiveCourseId)
            };

            StaticDb.Students.Add(student);
            TempData["StudentCreated"] = "Student successfully created!";

            return RedirectToAction("Index");
        }

        public IActionResult GetStudentById(int studentId)
        {
            Student student = StaticDb.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                return View();
            }

            //we need different data here than the one that we needed in the index, so we created a new ViewModel
            StudentCourseViewModel mappedStudent = new StudentCourseViewModel
            {
                Id = student.Id,
                FirstName = student.Firstname,
                LastName = student.Lastname,
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Coursename = student.ActiveCourse.Name,
                NumberOfClasses = student.ActiveCourse.NumberOfClasses
            };

            //send the mapped student to the view
            return View(mappedStudent);
        }
    }
}
