using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Imlementations
{
    public class StatusRepository : IRepository<Status>
    {
        public void Create(Status entity)
        {
            if (entity == null)
            {
                throw new Exception("Status item cannot be null!");
            }
            entity.Id = StaticDb.Statuses.Last().Id + 1;
            StaticDb.Statuses.Add(entity);
        }

        public void Delete(int id)
        {
            Status status = StaticDb.Statuses.FirstOrDefault(s => s.Id == id);
            if(status == null)
            {
                throw new Exception("Status item with this id does not exist!");
            }
            StaticDb.Statuses.Remove(status);
        }

        public List<Status> GetAll()
        {
            return StaticDb.Statuses;
        }

        public Status GetById(int id)
        {
            var status = StaticDb.Statuses.FirstOrDefault(s => s.Id == id);
            if(status == null)
            {
               throw new Exception("Status item with this id does not exist!");
            }
            return status;
        }

        public void Update(Status entity)
        {
            if(entity == null)
            {
                throw new Exception("Status item cannot be null!");
            }
            Status status = GetById(entity.Id);
            int index = StaticDb.Statuses.IndexOf(status);
            StaticDb.Statuses[index] = entity;
        }
    }
}
