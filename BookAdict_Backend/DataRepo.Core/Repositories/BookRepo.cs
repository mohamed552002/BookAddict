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
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext _context;
        public BookRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book, List<int> authorsIds)
        {
            book.AddedAt = DateTime.Now;
            book.LastUpdatedAt = DateTime.Now;
            SetBookAuthors(book, authorsIds);
            await _context.Books.AddAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _context.Books
                   .Include(b => b.Authors).ThenInclude(ba => ba.Author).Include(b=>b.Category)
                   .ToListAsync();

        public async Task<Book> GetBookAsync(int id) => await _context.Books.Where(b=>b.Id ==id).Include(b => b.Authors).ThenInclude(ba => ba.Author).Include(b => b.Category).FirstOrDefaultAsync(p=>p.Id==id);
        private void SetBookAuthors(Book book, List<int> authorsIds)
        {
            book.Authors = authorsIds.Select(AId => new Books_Authors { AuthorId = AId }).ToList();
        }
       

    }
}
