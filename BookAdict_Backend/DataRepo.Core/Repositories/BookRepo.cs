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

        public async Task UpdateBookAsync(Book book, List<int> authorsIds)
        {
            book.LastUpdatedAt = DateTime.Now;
            EditBookAuthors(book, authorsIds);
            _context.Books.Update(book);
        }


        public async Task<Book> DeleteBookAsync(int id)
        {
           var book = await GetBookAsync(id);
            if (book == null)
                return null;
            _context.Books.Remove(book);
            return book;
        }
        //Private Functions
        private void SetBookAuthors(Book book, List<int> authorsIds)
        {
            book.Authors = authorsIds.Select(AId => new Books_Authors { AuthorId = AId }).ToList();
        }
        private void EditBookAuthors(Book book, List<int> authorsIds)
        {
            var bookAuthors = _context.Books_Authors.Where(ba => ba.BookId == book.Id).ToList();
            book.Authors = new List<Books_Authors>();
            authorsIds.ForEach(AId =>
            {
                if ( !bookAuthors.Where(ba => ba.AuthorId == AId).Any())
                    book.Authors.Add(new Books_Authors { AuthorId = AId });
            });
            HandleBookAuthorDeletion(bookAuthors, authorsIds);
        }
        private void HandleBookAuthorDeletion(List<Books_Authors> bookAuthors, List<int> authorsIds)
        {
            foreach (var bookAuthor in bookAuthors)
            {
                if (!authorsIds.Contains(bookAuthor.AuthorId))
                {
                    _context.Books_Authors.Remove(bookAuthor);
                }
            }
        }

        public bool IsBookExist(int id)
        {
           return _context.Books.Where(b => b.Id == id).Any();
        }

        public async Task<Book> GetBookByCategoryIdAsync(int CategoryId)
        {
            return await _context.Books.Where(b => b.CategoryId == CategoryId)
                        .Include(b => b.Authors).ThenInclude(ba => ba.Author)
                        .Include(b => b.Category)
                        .FirstOrDefaultAsync();
        }
    }
}
