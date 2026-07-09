using System.ComponentModel.DataAnnotations;

namespace ModelBindingsAndDataAnnotations.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Display(Name="Full name")]
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
