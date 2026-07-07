using ToDoApp.Models.Dtos;

namespace ToDoApp.Services.Interfaces
{
    public interface IFilterService
    {
        List<CategoryDto> GetCategories();
        List<StatusDto> GetStatuses();
    }
}
