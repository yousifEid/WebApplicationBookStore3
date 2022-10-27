using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class CategoryDomain
    {
        public CategoryRepository categoryRepository = new CategoryRepository();

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }
        public Category Insert(Category category)
        {
            return categoryRepository.Insert(category);
        }

        public Category Edit(int id)
        {
            return categoryRepository.Edit(id);
        }

        public Category Modify(Category category)
        {
            return categoryRepository.Modify(category);
        }

        public Category Delete(int id)
        {
            return categoryRepository.Delete(id);
        }

        public Category ConfirmDelete(int id)
        {
            return categoryRepository.ConfirmDelete(id);
        }
    }
}
