using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Interfaces
{
    public interface ICategoryRepo
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategoryAsync(int id);
        public Task<bool> IsCategoryExist(int id);
        public Task AddCategoryAsync(Category category);
        public void UpdateCategory(Category category);
        public Task DeleteCategoryAsync(int id);
    }
}
