using Avenga.ASP.NET.MVC.Class03.DataAccess;
using Avenga.ASP.NET.MVC.Class03.Models.Domains;
using Avenga.ASP.NET.MVC.Class03.Models.DTOs;

namespace Avenga.ASP.NET.MVC.Class03.Services
{
    public class StudentService
    {

        // BAD EXAMPLE
        //public Student GetStudentWithActiveCourse(int id)
        //{
        //    var student = InMemoryDb.Students.FirstOrDefault(x=>x.Id == id);

        //    if(student == null)
        //    {
        //        return null;
        //    }

        //    return student;
        //}

        public StudentWithCourseDto GetStudentWithActiveCourse(int id)
        {
            var student = InMemoryDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return null;
            }


            var studentDto = new StudentWithCourseDto()
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                NameOfActiveCourse = student.ActiveCourse.Name

            };

            return studentDto;
        }
    }
}
