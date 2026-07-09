using System.ComponentModel.DataAnnotations;

namespace ModelBindingsAndDataAnnotations.Models.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage ="The first name must have at least three characters")]
        [MaxLength(50)]
        [Display(Name ="First name")]
        public string Firstname {  get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The last name must have at least 3 characters and maximum 50 characters")]
        [Display(Name = "Last name")]
        public string Lastname {  get; set; }

        [Required (ErrorMessage = "Date of birth is a required field")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth {  get; set; }

        [EmailAddress] //validates that the email is in a valid format
        public string Email {  get; set; }

        [Phone] //validates that the phone is in correct format (with numbers)
        [Display(Name = "Phone number")]
        public string PhoneNumber {  get; set; }
    }
}
