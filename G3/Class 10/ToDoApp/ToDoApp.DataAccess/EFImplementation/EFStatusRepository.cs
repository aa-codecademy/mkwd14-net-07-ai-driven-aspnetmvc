using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFStatusRepository : IRepository<Status>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFStatusRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Status entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Status item cannot be null");
            }

            _dbContext.Statuses.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var status = _dbContext.Statuses.FirstOrDefault(x => x.Id == id);
            if(status != null)
            {
                _dbContext.Statuses.Remove(status);
                _dbContext.SaveChanges();
            }
        }

        public List<Status> GetAll()
        {
            return _dbContext.Statuses.ToList();
        }

        public Status GetById(int id)
        {
            return _dbContext.Statuses.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Status entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Status item cannot be null");
            }

            _dbContext.Statuses.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
