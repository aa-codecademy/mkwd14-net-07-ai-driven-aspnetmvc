using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    //we need to create a folder named ToDo in the Views folder
    //and add a view for each method that returns its own view
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;
        private readonly IFilterService _filterService;

        public ToDoController(IToDoService todoService, IFilterService filterService)
        {
            // _todoService = new ToDoService(); - we dont want to depend on a concrete impl
            _todoService = todoService;
            _filterService = filterService;
        }
        public IActionResult Index()
        {
            
            int? categoryId = null;
            int? statusId = null;
            ViewBag.Filter = new FilterDto();

            //this way we can pass on the selected filter to the GetAllToDos method
            categoryId = (int?)TempData["Category"];
            statusId = (int?)TempData["Status"];

            //this way we pass on the selected filter to the view, because we call this action again after filtering
            ViewBag.Filter.CategoryId = categoryId; 
            ViewBag.Filter.StatusId = statusId;

            ViewBag.Filter.Categories = _filterService.GetCategories();
            ViewBag.Filter.Statuses = _filterService.GetStatuses();

            List<ToDosViewModel> todos = _todoService.GetAllToDos(categoryId, statusId);
            return View(todos);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterViewModel filters)
        {
            //we need to pass on the filtered data
            //we use temp data because we want to transfer data between actions, on redirect
            TempData["Category"] = filters.CategoryId;
            TempData["Status"] = filters.StatusId;

            return RedirectToAction("Index");
        }

        [HttpGet("markComplete")]
        public IActionResult MarkComplete(int id)
        {
            var success = _todoService.MarkComplete(id);

            if (!success)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return RedirectToAction("Index");   
        }

        [HttpGet("removeComplete")]
        public IActionResult RemoveComplete()
        {
            _todoService.RemoveComplete();
            return RedirectToAction("Index");
        }

        [HttpGet("add")]
        public IActionResult AddToDo()
        {
            ViewBag.Categories = _filterService.GetCategories();
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddToDo(CreateToDoViewModel model)
        {
            if(model.CategoryId == 0) //if the user did not choose a category
            {
                ViewBag.Categories = _filterService.GetCategories();
                return View();
            }
            
            _todoService.AddToDo(model);
            return RedirectToAction("Index");
        }
    }
}
