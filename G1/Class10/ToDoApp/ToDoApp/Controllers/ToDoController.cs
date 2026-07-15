using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Implementations;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todos")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IFilterService _filterService;
        public ToDoController(IToDoService toDoService, IFilterService filterService)
        {
            //_toDoService = new ToDoService();
            _toDoService = toDoService;
            _filterService = filterService;
        }

        [HttpGet]
        public IActionResult GetAllToDos([FromQuery] int? categoryId, [FromQuery] int? statusId)
        {
            ViewBag.Filter = new FilterDto();

            ViewBag.Filter.Categories = _filterService.GetCategories();
            ViewBag.Filter.Statuses = _filterService.GetStatuses();

            if (TempData["HasFilter"] != null)
            {
                ViewBag.Filter.CategoryId = categoryId;
                ViewBag.Filter.StatusId = statusId;
            }

            var todos = _toDoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterVM filterVM)
        {
            if(filterVM.StatusId > 0 || filterVM.CategoryId > 0)
            {
                TempData["HasFilter"] = true;
                return RedirectToAction("GetAllToDos", new { categoryId = filterVM.CategoryId, statusId = filterVM.StatusId });
            }
            
            return RedirectToAction("GetAllToDos");
        }
    }
}
