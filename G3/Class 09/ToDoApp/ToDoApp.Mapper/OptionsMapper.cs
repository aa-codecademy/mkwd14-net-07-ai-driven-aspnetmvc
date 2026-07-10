using ToDoApp.Domain;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Mapper
{
    public static class OptionsMapper
    {
        public static CategoryDto Map(this Category category)
        {
            return new CategoryDto { Id = category.Id, Name = category.Name };
        }

        public static StatusDto Map(this Status status)
        {
            return new StatusDto { Id = status.Id, Name = status.Name };
        }
    }
}
