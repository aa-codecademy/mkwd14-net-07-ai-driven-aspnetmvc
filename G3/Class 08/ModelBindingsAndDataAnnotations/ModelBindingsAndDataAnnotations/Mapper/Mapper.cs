using ModelBindingsAndDataAnnotations.Database;
using ModelBindingsAndDataAnnotations.Models;
using ModelBindingsAndDataAnnotations.Models.ViewModels;

namespace ModelBindingsAndDataAnnotations.Mapper
{
    public static class Mapper
    {
        public static StudentViewModel MapToStudentViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                Email = student.Email,
                Fullname = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year
            };
        }

        public static StudentDetailsViewModel MapToStudentDetailsVM(this Student student)
        {
            return new StudentDetailsViewModel
            {
                Id = student.Id,
                Email = student.Email,
                Fullname = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Phone = student.PhoneNumber
            };
        }

        public static Student ToStudent(this CreateViewModel model)
        {
            return new Student
            {
                Id = StaticDb.Students.LastOrDefault() != null ? StaticDb.Students.LastOrDefault().Id + 1 : 1,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}
