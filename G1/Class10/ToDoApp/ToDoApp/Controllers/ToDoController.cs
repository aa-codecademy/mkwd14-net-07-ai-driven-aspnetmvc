using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Implementations;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todos")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        public ToDoController( IToDoService toDoService)
        {
            //_toDoService = new ToDoService();
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult GetAllToDos([FromQuery] int? categoryId, [FromQuery] int? statusId)
        {
            var todos = _toDoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }
    }
}
