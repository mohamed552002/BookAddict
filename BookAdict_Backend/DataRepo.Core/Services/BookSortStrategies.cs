using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Ef.Services
{
    public class BaseSort
    {
        protected readonly ApplicationDbContext _context;

        public BaseSort(ApplicationDbContext context)
        {
            _context = context;
        }
    }
    public class DefaultSortStrategy : BaseSort , IBookSortStrategy
    {
        public DefaultSortStrategy(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> SortBookAsync(string? categoryName = null)
        {
            return await _context.Books
                .Include(b => b.Authors).ThenInclude(ba => ba.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

    }
    public class PriceSortStrategy : BaseSort, IBookSortStrategy
    {

        public PriceSortStrategy(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> SortBookAsync(string? categoryName = null)
        {
            return await _context.Books
                .OrderBy(b => b.Price)
                .Include(b => b.Authors).ThenInclude(ba => ba.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }
    }
    public class CategorySortStrategy : BaseSort, IBookSortStrategy
    {

        public CategorySortStrategy(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> SortBookAsync(string? categoryName = null)
        {
            return await _context.Books
                   .Include(b => b.Authors).ThenInclude(ba => ba.Author).Include(b => b.Category).Where(b => b.Category.Name == categoryName)
                   .ToListAsync();
        }
    }
}
