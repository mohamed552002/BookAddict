using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Ef.Repositories
{
    public class OrderRepo : IOrderServices
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _context.AddAsync(order);
            _context.SaveChanges();
            return order;
        }
    }
}
