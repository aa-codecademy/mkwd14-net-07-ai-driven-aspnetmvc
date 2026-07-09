namespace ModelBindingsAndDataAnnotations.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
       public string GetFullName()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
