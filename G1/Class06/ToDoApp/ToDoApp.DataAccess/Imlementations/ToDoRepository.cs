using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Imlementations
{
    //public class ToDoRepository : IRepository<ToDo>, IToDoRepository
    public class ToDoRepository : IToDoRepository
    {
        public void Create(ToDo entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.Id = StaticDb.Todos.Last().Id + 1;
            StaticDb.Todos.Add(entity);
        }

        public void Delete(int id)
        {
            ToDo toDo = StaticDb.Todos.FirstOrDefault(t => t.Id == id);
            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            StaticDb.Todos.Remove(toDo);
        }

        public List<ToDo> GetAll()
        {
            return StaticDb.Todos;
        }

        public ToDo GetById(int id)
        {
            var toDo = StaticDb.Todos.FirstOrDefault(t => t.Id == id);
            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return toDo;
        }

        public List<ToDo> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            ToDo toDo = GetById(entity.Id);
            int index = StaticDb.Todos.IndexOf(toDo);
            StaticDb.Todos[index] = entity;
        }
    }
}
