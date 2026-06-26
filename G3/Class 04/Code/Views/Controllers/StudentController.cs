using Microsoft.AspNetCore.Mvc;
using Views.Database;
using Views.Models.Domain;
using Views.Models.ViewModels;

namespace Views.Controllers
{
    public class StudentController : Controller
    {
        //route: /student/index
        //we need to make a folder with the name of our controller into the views folder
        //and in that folder we need to add a new view with the name of the action that returns a view - Index.cshtml because our action is Index
        public IActionResult Index()
        {
            //1. Get all students from DB
            List<Student> studentsDb = StaticDb.Students;

            //we don't want to send to the view the domain model, but only the data that the view needs
            //2. map the domain model into the corresponding ViewModel

            List<StudentViewModel> mappedStudents = studentsDb.Select(x => new StudentViewModel
            {
                Fullname = $"{x.Firstname} {x.Lastname}",
                Age = DateTime.Now.Year - x.DateOfBirth.Year,
                ActiveCourseName = x.ActiveCourse.Name
            }).ToList(); //with LINQ we iterate through our list of students and select only what we need into a list of view model
        
           //3. send the mapped objects to the view
           return View(mappedStudents);
        }

        //route: /student/getstudentbyid/1
        public IActionResult GetStudentById(int id)
        {
            Student student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return View();
            }

            //we need different data here than the one that we needed in the index, so we created a new ViewModel
            StudentCourseViewModel mappedStudent = new StudentCourseViewModel
            {
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
