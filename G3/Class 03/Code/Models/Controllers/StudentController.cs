using Microsoft.AspNetCore.Mvc;
using Models.Database;
using Models.Services;

namespace Models.Controllers
{
    //because here we do not use the attribute routing, the routing that is defined in the Program.cs is valid
    //so, to acces the actions here we use ControllerName/ActionName
    public class StudentController : Controller
    {
        private StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        //Bad practice - avoid accessing the db and using the domain models in the controller
        public IActionResult GetAllStudents()
        {
            return Json(StaticDb.Students); 
        }

        public IActionResult GetStudentById(int id)
        {
            var studentDto = _studentService.GetStudentById(id); //here the service returns a DTO, not the domain model

            if(studentDto != null)
            {
                return Json(studentDto);
            }

            return Content("Student not found");
        }
    }
}
