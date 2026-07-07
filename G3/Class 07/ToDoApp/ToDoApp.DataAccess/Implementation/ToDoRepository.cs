using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class ToDoRepository : IRepository<ToDo>
    {
        public void Create(ToDo entity)
        {
            //ALWAYS do a validtion when you have a whole object that you need to access
            if(entity == null)
            {
                throw new ArgumentNullException("ToDo item cannot be null");
            }

            //we need to increment the id ourselves
            entity.Id = StaticDb.ToDos.LastOrDefault() != null ? StaticDb.ToDos.Last().Id + 1 : 1;
            StaticDb.ToDos.Add(entity);
        }

        public void Delete(int id)
        {
            //first we need to find the entity that we want to delete and then remove it
            ToDo toDoFromDb = StaticDb.ToDos.FirstOrDefault(x => x.Id == id); //GetById
            if(toDoFromDb != null)
            {
                StaticDb.ToDos.Remove(toDoFromDb);
            }
            else
            {
                throw new Exception("To do item was not found");
            }
        }

        public List<ToDo> GetAll()
        {
            return StaticDb.ToDos; //return all todos from staticDb
        }

        public ToDo GetById(int id)
        {
            return StaticDb.ToDos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ToDo entity)
        {
            //ALWAYS do a validtion when you have a whole object that you need to access
            if (entity == null)
            {
                throw new ArgumentNullException("ToDo item cannot be null");
            }

            ToDo toDoFromDb = GetById(entity.Id);
            int index = StaticDb.ToDos.IndexOf(toDoFromDb);
            StaticDb.ToDos[index] = entity;
        }
    }
}
