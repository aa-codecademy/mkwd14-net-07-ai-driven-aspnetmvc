using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    //Attribute routing examples
    [Route("students")] //this part is a rule for all actions in this controller
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Firstname = "Petko",
                Lastname = "Petkovski",
                DateOfBirth = DateTime.Now.AddYears(-25)
            },
             new Student()
            {
                Id = 2,
                Firstname = "Trajko",
                Lastname = "Trajkovski",
                DateOfBirth = DateTime.Now.AddYears(-30)
            },
              new Student()
            {
                Id = 3,
                Firstname = "Marko",
                Lastname = "Markovski",
                DateOfBirth = DateTime.Now.AddYears(-20)
            }
        };

        //route: /students
        public string GetStudentFirstName()
        {
            return students.First().Firstname;
        }

        //AmbiguousMatchException: The request matched multiple endpoints. Matches:
        //Controllers.Controllers.StudentController.GetStudentFirstName(Controllers)
        //Controllers.Controllers.StudentController.GetStudentLastName(Controllers)
        //public string GetStudentLastName()
        //{
        //    return students.First().Lastname;
        //}


        //route: /students/lastname
        [Route("lastname")]
        public string Getstudentlastname()
        {
            return students.First().Lastname;
        }

        //route: /students/all 
        //[Route("all")]  - standard way by usinh the route attribute
        [HttpGet("all")] //another way we can specify the route is by combining the http method and the route
        public List<Student> GetAll()
        {
            return students;
        }

        //with route params
        //route: /students/1
        [HttpGet("{id}")] //in curly brackets we specify the name of the param 
        public Student GetStudentById (int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        //route: /students/byId/1
        //[HttpGet("byId/{id}")] 
        [Route("byId/{id}")]
        public Student GetStudentByIdWithRouteText(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        //route: /students/1/Petko
        //with constraint that the type of id must be int and the type od name must be string
        [Route("{id:int}/{name}")]
        public Student GetStudentByIdAndNameMultipleParams(int id, string name)
        {
            return students.FirstOrDefault(x => x.Id == id && x.Firstname == name);
        }

        //route: /students/Petko/1
        [Route("{name}/{id:int}")]
        public Student GetStudentByIdAndNameDifferentOrder(int id, string name)
        {
            return students.FirstOrDefault(x => x.Id == id && x.Firstname == name);
        }

        //route: /students/1/search/Petko
        [Route("{id}/search/{name}")]
        public Student GetStudentByIdAndNameWithText(int id, string name)
        {
            return students.FirstOrDefault(x => x.Id == id && x.Firstname == name);
        }
    }
}


