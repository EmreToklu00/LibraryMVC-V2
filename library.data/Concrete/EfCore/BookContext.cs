using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.entity;
using Microsoft.EntityFrameworkCore;

namespace library.data.Concrete.EfCore
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LibrarDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>().HasKey(c => new { c.CategoryId, c.BookId });

        }



    }
}