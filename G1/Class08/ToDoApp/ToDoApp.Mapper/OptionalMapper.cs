using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain;
using ToDoApp.Models.ViewModels;

namespace ToDoApp.Mapper
{
    public static class OptionalMapper
    {
        public static ToDosVM MapToToDosVM(ToDo todo)
        {
            return new ToDosVM
            {
                Id = todo.Id,
                Description = todo.Description,
                DueDate = todo.DueDate,
                StatusName = todo.Status?.Name ?? string.Empty,
                StatusId = todo.Status.Id,
                CategoryName = todo.Category?.Name ?? string.Empty,
                CategoryId = todo.Category.Id
            };
        }
    }
}
