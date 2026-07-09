using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.ViewModels;

namespace ToDoApp.Services.Interfaces
{
    public interface IToDoService
    {
        List<ToDosVM> GetAllTodos(int? categoryId, int? statusId);
    }
}
