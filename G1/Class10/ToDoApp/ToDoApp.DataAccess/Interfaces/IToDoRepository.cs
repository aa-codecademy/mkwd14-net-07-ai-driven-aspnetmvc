using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces
{
    //public interface IToDoRepository
    public interface IToDoRepository : IRepository<ToDo>
    {
        List<ToDo> GetByName(string name);
    }
}
