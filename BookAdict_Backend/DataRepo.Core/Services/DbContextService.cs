using BookAddict.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Ef.Services
{
    public class DbContextService : IDBContext
    {
        private readonly ApplicationDbContext _context;

        public DbContextService(ApplicationDbContext context)
        {
            _context = context;
        }

        public object GetDbContext()
        {
            return _context;
        }
    }
}
