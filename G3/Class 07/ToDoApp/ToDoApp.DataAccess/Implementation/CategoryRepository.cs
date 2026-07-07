using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class CategoryRepository : IRepository<Category>
    {
        public void Create(Category entity)
        {
            //ALWAYS do a validtion when you have a whole object that you need to access
            if (entity == null)
            {
                throw new ArgumentNullException("Category item cannot be null");
            }

            //we need to increment the id ourselves
            entity.Id = StaticDb.Categories.LastOrDefault() != null ? StaticDb.ToDos.Last().Id + 1 : 1;
            StaticDb.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            //first we need to find the entity that we want to delete and then remove it
            Category category = StaticDb.Categories.FirstOrDefault(x => x.Id == id); //GetById
            if (category != null)
            {
                StaticDb.Categories.Remove(category);
            }
            else
            {
                throw new Exception("Category item was not found");
            }
        }

        public List<Category> GetAll()
        {
            return StaticDb.Categories; //return all categories from staticDb
        }

        public Category GetById(int id)
        {
            return StaticDb.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Category entity)
        {
            //ALWAYS do a validtion when you have a whole object that you need to access
            if (entity == null)
            {
                throw new ArgumentNullException("Category item cannot be null");
            }

            Category category = GetById(entity.Id);
            int index = StaticDb.Categories.IndexOf(category);
            StaticDb.Categories[index] = entity;
        }
    }
}
