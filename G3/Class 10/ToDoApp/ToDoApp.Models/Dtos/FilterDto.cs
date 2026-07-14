namespace ToDoApp.Models.Dtos
{
    public class FilterDto
    {
        public List<CategoryDto> Categories { get; set; }
        public List<StatusDto> Statuses { get; set; }
        public int? CategoryId {  get; set; }
        public int? StatusId {  get; set; }
    }
}
