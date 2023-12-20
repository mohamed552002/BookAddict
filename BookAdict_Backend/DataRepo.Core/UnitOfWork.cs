using DataRepo.Ef.Repositories;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookRepo Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepo(_context);
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
