using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces
{
    //CRUD methods for accessing the db
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById (int id);
        void Create (T entity); 
        void Update (T entity);
        void Delete(int id);
    }
}
