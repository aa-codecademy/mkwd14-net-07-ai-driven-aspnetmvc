using ToDoApp.Models.ViewModels;

namespace ToDoApp.Services.Interfaces
{
    public interface IToDoService
    {
        //categoryId and statusId are optional - we can filter, but we don't always have to do it - we can just list all the todos
        List<ToDosViewModel> GetAllToDos(int? categoryId, int? statusId);

        bool MarkComplete(int todoId);
        void RemoveComplete();

        void AddToDo(CreateToDoViewModel viewModel);
    }
}
