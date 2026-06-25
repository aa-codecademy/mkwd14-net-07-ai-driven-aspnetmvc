using Models.Database;
using Models.Models.Domain;
using Models.Models.DTOs;

namespace Models.Services
{
    public class StudentService
    {
        public StudentWithCourseDto GetStudentById(int id)
        {
            //here we are working with the domain model
            Student student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if(student == null) {

                return null;
            }

            //we need to map the data from the domain model into a DTO that we will return as a result from the controller
            //the outside world that calls our controller must not be able to access the domain model, but only the DTO and the data that we want to show to the rest of the world
            StudentWithCourseDto studentDto = new StudentWithCourseDto
            {
                Id = student.Id,
                Fullname = $"{student.Firstname} {student.Lastname}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                NameOfActiveCourse = student.Course.Name
            };

            return studentDto;  
        }
    }
}
