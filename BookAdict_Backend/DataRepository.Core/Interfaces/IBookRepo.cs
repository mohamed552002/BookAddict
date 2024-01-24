using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Interfaces
{
    public interface IBookRepo
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book> GetBookAsync(int id);
        public Task AddBookAsync(Book book, List<int> authorsIds);
        public Task UpdateBookAsync(Book book, List<int> authorsIds);
        public Task<Book> DeleteBookAsync(int id);
        public Task<Book> GetBookByCategoryIdAsync(int CategoryId);
        public bool IsBookExist(int id);
    }
}
