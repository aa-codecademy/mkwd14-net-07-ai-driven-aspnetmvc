using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Imlementations
{
    public class EFToDoRepository : IToDoRepository
    {
        private readonly ToDoAppDbContext _context;
        public EFToDoRepository(ToDoAppDbContext context)
        {
            _context = context;
        }
        public void Create(ToDo entity)
        {
           _context.ToDo.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if(todo != null)
            {
                _context.ToDo.Remove(todo);
                _context.SaveChanges();
            }
        }

        public List<ToDo> GetAll()
        {
            var toDos = _context.ToDo
                .Include(x=>x.Status)
                .Include(x=>x.Category)
                .ToList();
            return toDos;
        }

        public ToDo GetById(int id)
        {
            var toDo = _context.ToDo
                    .Include(x => x.Status)
                    .Include(x => x.Category)
                    .FirstOrDefault(x=>x.Id == id);

            return toDo;
        }

        public List<ToDo> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo entity)
        {
            _context.ToDo.Update(entity);
               _context.SaveChanges();
        }
    }
}
