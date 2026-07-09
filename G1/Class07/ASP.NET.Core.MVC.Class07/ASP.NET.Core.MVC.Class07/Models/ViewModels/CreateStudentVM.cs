using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Core.MVC.Class07.Models.ViewModels
{
    public class CreateStudentVM
    {
        [Required]
        [MinLength(2, ErrorMessage = "The first name must have at least two charachters")]
        [MaxLength(50, ErrorMessage = "The first name must have at most 50 charachters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must have at least two charachters and at most 50 charachters")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
