using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class StatusRepository : IRepository<Status>
    {
        public void Create(Status entity)
        {
            //ALWAYS do a validtion when you have a whole object that you need to access
            if (entity == null)
            {
                throw new ArgumentNullException("Status item cannot be null");
            }

            //we need to increment the id ourselves
            entity.Id = StaticDb.Statuses.LastOrDefault() != null ? StaticDb.Statuses.Last().Id + 1 : 1;
            StaticDb.Statuses.Add(entity);
        }

        public void Delete(int id)
        {
            //first we need to find the entity that we want to delete and then remove it
            Status status = StaticDb.Statuses.FirstOrDefault(x => x.Id == id); //GetById
            if (status != null)
            {
                StaticDb.Statuses.Remove(status);
            }
            else
            {
                throw new Exception("Status item was not found");
            }
        }

        public List<Status> GetAll()
        {
            return StaticDb.Statuses; //return all statuses from staticDb
        }

        public Status GetById(int id)
        {
            return StaticDb.Statuses.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Status entity)
        {
            //ALWAYS do a validtion when you have a whole object that you need to access
            if (entity == null)
            {
                throw new ArgumentNullException("Status item cannot be null");
            }

            Status status = GetById(entity.Id);
            int index = StaticDb.Statuses.IndexOf(status);
            StaticDb.Statuses[index] = entity;
        }
    }
}
