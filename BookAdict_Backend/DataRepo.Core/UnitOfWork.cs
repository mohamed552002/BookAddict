using DataRepo.Ef.CacheMemoryServices;
using DataRepo.Ef.Repositories;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookAddict.Persistance.Repositories;

namespace DataRepo.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly UserManager<ApplicationUser> _userManager;
        public IBookRepo Books { get; private set; }
        public ICategoryRepo Category { get; private set; }
        public IAuthorRepo Author {  get; private set; }
        public IUnitOfWork unitOfWork { get; private set; }
        public ICartServices cartServices { get; private set; }
        public IUserRepo User { get; private set; }
        public IOrderServices Order { get; private set; }

        public IWishlistItemRepo WishlistItem { get; private set; }

        public UnitOfWork(ApplicationDbContext context, IMemoryCache memoryCache, UserManager<ApplicationUser> userManager, IWishlistItemRepo wishlistItem)
        {
            _context = context;
            _userManager = userManager;
            _memoryCache = memoryCache;
            Books = new BookRepo(_context);
            Category = new CategoryRepo(_context, Books);
            Author = new AuthorRepo(_context);
            User = new UserRepo(_userManager);
            cartServices = new CartServices(_memoryCache, User, Books);
            Order = new OrderRepo(_context);
            WishlistItem = new WishlistItemRepo(_context);
        }
        public void OnComplete()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
        public void ActionOnComplete()
        {
            OnComplete();
            Dispose();
        }
    }
}
