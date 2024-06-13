using BookAddict.Application.DTOS.CartDtos;
using BookAddict.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Ef.CacheMemoryServices
{
    public class CartServices : ICartServices
    {
        private readonly IMemoryCache _cache;
        private List<CartItem> cartItems;
        private readonly IUserRepo _userRepo;
        private readonly IBookRepo _bookRepo;

        public CartServices(IMemoryCache cache, IUserRepo userRepo, IBookRepo bookRepo)
        {
            _cache = cache;
            _userRepo = userRepo;
            _bookRepo = bookRepo;
        }
        public async Task<IEnumerable<CartItem>> AddToCart(CartItem item)
        {
            if ( await _userRepo.IsUserExist(item.UserId) && _bookRepo.IsBookExist(item.BookId))
            {
                if (!_cache.TryGetValue($"Cart{item.UserId}", out cartItems))
                {
                    cartItems = new List<CartItem>();
                }
                cartItems.Add(item);
                _cache.Set($"Cart{item.UserId}", cartItems);
                return cartItems;
            }
            return Enumerable.Empty<CartItem>();
        }

        public IEnumerable<CartItem> GetCart(string UserId)
        {
            _cache.TryGetValue($"Cart{UserId}", out cartItems);
            return cartItems ?? Enumerable.Empty<CartItem>();
        }

        public bool DeleteCartItem(CartItem item)
        {
            if (_cache.TryGetValue($"Cart{item.UserId}", out cartItems))
            {
               cartItems.Remove(cartItems.Where(ci => ci.BookId == item.BookId).First());
                _cache.Remove($"Cart{item.UserId}");
               _cache.Set($"Cart{item.UserId}", cartItems);
                return true;
            }
            return false;
        }
    }
}
