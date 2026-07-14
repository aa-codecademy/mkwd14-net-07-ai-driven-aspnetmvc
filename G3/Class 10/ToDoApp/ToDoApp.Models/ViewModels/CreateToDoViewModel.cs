namespace ToDoApp.Models.ViewModels
{
    public class CreateToDoViewModel
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
    }
}
