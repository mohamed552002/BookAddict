using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataRepo.Ef.Repositories
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly IImageService _imageServices;

        public AuthorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _context.Author.AddAsync(author);
            await  _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            _context.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _context.Author.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
          return await _context.Author.ToListAsync();
        }

        public async Task<IEnumerable<Author>> SearchAuthors(string searchText)
        {
            return await _context.Author.Where(author => author.Name.ToLower().Contains(searchText.ToLower())).ToListAsync();
        }
        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
