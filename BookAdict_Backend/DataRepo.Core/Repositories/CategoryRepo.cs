using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Ef.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookRepo _bookRepo;

        public CategoryRepo(ApplicationDbContext context, IBookRepo bookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
        }

        public async Task AddCategoryAsync(Category category)
        {
            category.CreationDate = DateTime.Now;
            category.LastUpdatedAt = DateTime.Now;
           await _context.AddAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category =await GetCategoryAsync(id);
            _context.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories() {
             //await _bookRepo.GetAllBooksAsync(); // getting all books to get its all details
           return await _context.Categories.ToListAsync();
                }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> IsCategoryExist(int id)
        {
            await _bookRepo.GetBookByCategoryIdAsync(id); // getting all books to get its all details
            return  _context.Categories.Where(b => b.Id == id).Any();
        }

        public void UpdateCategory(Category category)
        {
            category.LastUpdatedAt = DateTime.Now;
            _context.Categories.Update(category);
        }
    }
}
