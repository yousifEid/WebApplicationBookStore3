using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Repositories;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        public List<Category> GetAllCategories()
        {
            var category = db.Categories.ToList();

            return category;
        }

        public Category Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();

            return category;
        }

        public Category Edit(int id)
        {
            var category = db.Categories.Find(id);
            return category;
        }

        public Category Modify(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            var category = db.Categories.Find(id);
            return category;
        }

        public Category ConfirmDelete(int id)
        {
            var category=  db.Categories.Find(id);
            db.Entry(category).State = EntityState.Deleted;
            db.Categories.Remove(category);
            db.SaveChanges();
            return category;
        }
    }
}
