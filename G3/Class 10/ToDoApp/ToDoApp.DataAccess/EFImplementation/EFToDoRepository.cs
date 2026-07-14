using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DataAccess.Migrations;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFToDoRepository : IRepository<ToDo>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFToDoRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ToDo entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Todo item cannot be null");
            }
            _dbContext.ToDos.Add(entity);
            _dbContext.SaveChanges(); //we have changes that we want to be added in the db so we must call SaveChanges
        }

        public void Delete(int id)
        {
            var todo = _dbContext.ToDos.FirstOrDefault(x => x.Id == id);
            if(todo != null)
            {
                _dbContext.ToDos.Remove(todo);
                _dbContext.SaveChanges();
            }
        }

        public List<ToDo> GetAll()
        {
            //SQL: SELECT *
            //     FROM ToDos 

            // var toDOs = _dbContext.ToDos.ToList();

            //SQL:   SELECT *
            //       FROM ToDos T
            //       JOIN Categories c ON c.Id == T.CategoryId
            //       JOIN Statuses s ON s.Id == T.StatusId

            var todos = _dbContext.ToDos
                  .Include(x => x.Status) //join
                  .Include(x => x.Category) //join -> if we wanr ro access todo.Category.Name we need to include (join) the category, so that we have the whole object with this one call to the db instead of making multiple calls
                  .ToList();

            return todos;
        }

        public ToDo GetById(int id)
        {
            //SQL:   SELECT *
            //       FROM ToDos T
            //       JOIN Categories c ON c.Id == T.CategoryId
            //       JOIN Statuses s ON s.Id == T.StatusId
            //       WHERE T.Id = @id

            var todo = _dbContext.ToDos
                .Include(x => x.Category)
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Id == id);
            return todo;
        }

        public void Update(ToDo entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Todo item cannot be null");
            }
            _dbContext.ToDos.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
