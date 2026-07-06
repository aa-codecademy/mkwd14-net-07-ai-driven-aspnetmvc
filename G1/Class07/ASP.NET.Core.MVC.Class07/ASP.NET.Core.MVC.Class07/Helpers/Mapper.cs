using ASP.NET.Core.MVC.Class07.Models.Domain;
using ASP.NET.Core.MVC.Class07.Models.ViewModels;

namespace ASP.NET.Core.MVC.Class07.Helpers
{
    public static class Mapper
    {
        public static StudentVM MapToStudentVM(Student student)
        {
            return new StudentVM
            {
                Id = student.Id,
                FullName = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Email = student.Email
            };
        }
    }
}
