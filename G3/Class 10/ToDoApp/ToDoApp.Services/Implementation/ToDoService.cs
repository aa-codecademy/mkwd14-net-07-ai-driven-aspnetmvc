using ToDoApp.DataAccess.Implementation;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services.Implementation
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public ToDoService(IRepository<ToDo> toDoRepository, 
            IRepository<Category> categoryRepository,
            IRepository<Status> statusRepository)
        {
            //this way we need to create a concrete instance of the implementation
            //this way our service is tightly couples to a concrete impl.
            //_toDoRepository = new ToDoRepository();

            _toDoRepository = toDoRepository;
            _categoryRepository = categoryRepository;
            _statusRepository = statusRepository;
        }

        public void AddToDo(CreateToDoViewModel viewModel)
        {
            if(viewModel == null)
            {
                throw new ArgumentNullException("Model cannot be null");
            }

            //in the service we have a view model. The repo expects a domain model. We need to map it
            var todo = new ToDo //we don't need to add the id, we have identity (1,1) in the db
            {
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                DueDate = viewModel.DueDate,
                StatusId = 1 //new
            };

            _toDoRepository.Create(todo);
        }

        public List<ToDosViewModel> GetAllToDos(int? categoryId, int? statusId)
        {
            //get all todos - use the repo to get all the data (the service does not communicate with the db directly)
            List<ToDo> todosDb = _toDoRepository.GetAll();

            //filter - we can filter by both category and status, only category, only status or neither
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                todosDb = todosDb.Where(x => x.CategoryId == categoryId.Value).ToList();
            }
            if(statusId.HasValue && statusId.Value > 0)
            {
                todosDb = todosDb.Where(x => x.StatusId == statusId.Value).ToList();
            }

            //we need to map the domain model to view model
            var result = new List<ToDosViewModel>();
            foreach(ToDo toDo in todosDb)
            {
                result.Add(new ToDosViewModel
                {
                    Id = toDo.Id,
                    Description = toDo.Description,
                    DueDate = toDo.DueDate,
                    //in the service we cannot access the db. We need a repo for everything connected to the db
                    //CategoryName = _categoryRepository.GetById(toDo.CategoryId)?.Name ?? string.Empty,
                    CategoryName = toDo.Category?.Name ?? string.Empty,
                    StatusName = _statusRepository.GetById(toDo.StatusId)?.Name ?? string.Empty
                });

            }
            return result;
        }

        public bool MarkComplete(int todoId)
        {
            //find the item that we want to mark as complete
            var todo = _toDoRepository.GetById(todoId); //we use the repo to get the data

            if(todo == null)
            {
                return false;
            }

            todo.StatusId = 2; //completed/done

            //we need to call the update method from the repo to actually update the db
            _toDoRepository.Update(todo);
            return true;
        }

        public void RemoveComplete()
        {
            //get all todos that have status Done
            var completedTodos = _toDoRepository.GetAll().Where(x => x.StatusId == 2).ToList();

            foreach(var todo in completedTodos)
            {
                _toDoRepository.Delete(todo.Id); //delete all the items that have status Done
            }
        }
    }
}
