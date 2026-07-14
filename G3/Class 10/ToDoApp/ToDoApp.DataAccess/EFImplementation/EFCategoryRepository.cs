using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFCategoryRepository : IRepository<Category>
    {
        //The repo uses the fb context to interact with the db using EF
        private readonly ToDoAppDbContext _dbContext;

        public EFCategoryRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Category item cannot be null");
            }

            _dbContext.Categories.Add(entity); //with this line only, the changes are not applied in the db. It's like writing the query, but not executing it
            _dbContext.SaveChanges(); //with SaveChanges the db is updated and the new item is added (Execute the query)
        }

        public void Delete(int id)
        {
            //find the entity in the db
            //var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            var category = GetById(id);
            if(category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges(); //here we want to change something, we have changes that we want to affect the db, so we need saveChanges
            }
        }

        public List<Category> GetAll()
        {
            //SELECT *
            //FROM Categories

            return _dbContext.Categories.ToList(); //here we don't need save changes because we are not changing anything
        }

        public Category GetById(int id)
        {
            //SELECT *
            //FROM Categories c
            //WHERE c.Id == id
            return _dbContext.Categories.FirstOrDefault(x => x.Id == id); 
        }

        public void Update(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Category item cannot be null");
            }

            _dbContext.Categories.Update(entity);
            _dbContext.SaveChanges(); //here we have changes that we want to apply to the db, so we must call saveChanges in order for these changes to affect the db
        }
    }
}
