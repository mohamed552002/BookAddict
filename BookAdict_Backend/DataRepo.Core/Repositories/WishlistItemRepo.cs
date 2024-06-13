using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using DataRepo.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Persistance.Repositories
{
    public class WishlistItemRepo : IWishlistItemRepo
    {
        private readonly ApplicationDbContext _context;

        public WishlistItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WishlistItem> AddWishlistItemAsync(WishlistItem wishlistItem)
        {
            var result =await _context.WishlistItems.AddAsync(wishlistItem);
            return result.Entity;
        }
        public async Task<IEnumerable<WishlistItem>> GetWishlistItemsAsync(string userId)
        {
           return await _context.WishlistItems.Where(i => i.UserId == userId).Include(i => i.Book).ToListAsync();
        }
        public async Task<WishlistItem> GetWishlistItemAsync(string userId ,int bookId)
        {
            return await _context.WishlistItems.FindAsync(bookId, userId);
        }
        public void DeleteWishlistItem(WishlistItem wishlistItem)
        {
            _context.WishlistItems.Remove(wishlistItem);
        }

        public async Task<bool> IsWishlistItemExists(int bookId, string userId)
        {
           return await _context.WishlistItems.AnyAsync(i => i.UserId == userId && i.BookId == bookId);
        }
    }
}
