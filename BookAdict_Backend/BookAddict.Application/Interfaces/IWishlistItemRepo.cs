using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Interfaces
{
    public interface IWishlistItemRepo
    {
        Task<WishlistItem> AddWishlistItemAsync(WishlistItem wishlistItem);
        Task<IEnumerable<WishlistItem>> GetWishlistItemsAsync(string userId);
        void DeleteWishlistItem(WishlistItem wishlistItem);
        Task<bool> IsWishlistItemExists(int bookId, string userId);
        Task<WishlistItem> GetWishlistItemAsync(string userId, int bookId);
    }
}
