using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;

namespace ToDoApp.Mapper
{
    public static class OptionalMapper
    {
        public static ToDosVM MapToToDosVM(ToDo todo, string categoryName, string statusName)
        {
            return new ToDosVM
            {
                Id = todo.Id,
                Description = todo.Description,
                DueDate = todo.DueDate,
                StatusName = statusName ?? string.Empty,
                CategoryName = categoryName ?? string.Empty
            };
        }
        public static CategoryDto MapToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public static StatusDto MapToStatusDto(Status status)
        {
            return new StatusDto
            {
                Id = status.Id,
                Name = status.Name
            };
        }

        public static ToDo CreateTodoVMToToDo(CreateToDoVM createToDoVM)
        {
            return new ToDo
            {
                Description = createToDoVM.Description,
                DueDate = createToDoVM.DueDate,
                CategoryId = createToDoVM.CategoryId,
                StatusId = 1//DEFAULT STATUS: OPEN
            };
        }
    }
}
