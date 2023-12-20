using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataRepo.Ef
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Books_Authors>().HasKey(ba => new { ba.AuthorId, ba.BookId });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Books_Authors> Books_Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
