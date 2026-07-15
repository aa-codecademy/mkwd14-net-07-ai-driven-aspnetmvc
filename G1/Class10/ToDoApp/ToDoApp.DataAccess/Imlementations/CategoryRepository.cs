using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Imlementations
{
    public class CategoryRepository : IRepository<Category>
    {
        public void Create(Category entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Category entity cannot be null.");
            }
            entity.Id = StaticDb.Categories.Last().Id + 1;
            StaticDb.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            Category category = StaticDb.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                throw new ArgumentNullException("Category with id does not exist!");
            }
            StaticDb.Categories.Remove(category);
        }

        public List<Category> GetAll()
        {
            return StaticDb.Categories;
        }

        public Category GetById(int id)
        {
            var staticDbCategory = StaticDb.Categories.FirstOrDefault(c => c.Id == id);
            if (staticDbCategory == null) 
            {
                throw new ArgumentNullException("Category with id does not exist!");

            }
            return staticDbCategory;
        }

        public void Update(Category entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Category entity cannot be null.");
            }
            Category category = GetById(entity.Id);
            int index = StaticDb.Categories.IndexOf(category);
            StaticDb.Categories[index] = entity;
        }
    }
}
