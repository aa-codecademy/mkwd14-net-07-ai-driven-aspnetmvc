using System.ComponentModel.DataAnnotations;
using Views2.Models.ViewModels;

namespace Views2.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        [Display(Name = "First Name")] //with display we tell the view what to display as label for this property. If we don't specify the display it will take the name of the property
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Course")]
        public int ActiveCourseId { get; set; }
        public List<CourseOptionViewModel> Courses { get; set; }
    }
}
