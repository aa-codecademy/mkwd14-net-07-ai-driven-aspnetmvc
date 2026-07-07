using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Mapper;
using ToDoApp.Models.Dtos;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services.Implementation
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public FilterService(IRepository<Category> categoryRepository,
            IRepository<Status> statusRepository)
        {
            _categoryRepository = categoryRepository;
             _statusRepository = statusRepository;
        }
        public List<CategoryDto> GetCategories()
        {
            //we need to add a reference to the Mapper project in order to be able to call and use the Map extenstion method
            //if it does not recognize it go-> right click on services -> add project reference -> mappers
             return _categoryRepository.GetAll().Select(x => x.Map()).ToList(); 
        }

        public List<StatusDto> GetStatuses()
        {
            return _statusRepository.GetAll().Select(x => x.Map()).ToList();
        }
    }
}
