using DataRepo.Ef.Services;
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
            try
            {
                await _context.Books.AddAsync(book);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(string? sortBy,string? categoryId)
        {
            var allBooks = "";
            switch (sortBy)
            {
                case "price":
                    var priceSortStrategy = new PriceSortStrategy(_context);
                    return await priceSortStrategy.SortBookAsync();
            }
            return categoryId == null ? await new DefaultSortStrategy(_context).SortBookAsync() : 
                await new CategorySortStrategy(_context).SortBookAsync(categoryId);
                   
        }

        public async Task<IEnumerable<Book>> SearchBookByName(string searchText) => await _context.Books.Where(book => book.Title.Contains(searchText)).ToListAsync();

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
            return _context.Books.FirstOrDefault(b => b.Id == id) is not null;
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int CategoryId)
        {
            return await _context.Books.Where(b => b.CategoryId == CategoryId)
                        .Include(b => b.Authors).ThenInclude(ba => ba.Author)
                        .Include(b => b.Category)
                        .ToListAsync();
        }


    }
}
