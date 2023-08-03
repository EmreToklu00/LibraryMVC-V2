using System;
using System.Collections.Generic;
using System.Linq;
using library.data.Abstract;
using library.entity;
using Microsoft.EntityFrameworkCore;

namespace library.data.Concrete.EfCore
{
    public class EfCoreBookRepository : EfCoreGenericRepository<Book, BookContext>, IBookRepository
    {
        public Book getBookDetails(string url)
        {
            using (var context = new BookContext())
            {
                return context.Books.Where(i => i.Url == url).Include(i => i.BookCategories).ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public List<Book> getBooksByCategory(string name, int page, int pageSize)
        {

            using (var context = new BookContext())
            {
                var books = context.Books
                .Where(i => i.IsApproved)
                .AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    books = books.Include(i => i.BookCategories).ThenInclude(i => i.Category).Where(i => i.BookCategories.Any(a => a.Category.Url == name));
                }
                return books.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public Book GetByIdWithCategories(int Id)
        {
            using (var context = new BookContext())
            {
                return context.Books.Where(i => i.Id == Id).Include(i => i.BookCategories).ThenInclude(i => i.Category).FirstOrDefault();

            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new BookContext())
            {
                var books = context.Books
                .AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    books = books.Include(i => i.BookCategories).ThenInclude(i => i.Category).Where(i => i.BookCategories.Any(a => a.Category.Url == category));
                }
                return books.Count();
            }
        }

        public List<Book> GetHomePageBooks()
        {
            using (var context = new BookContext())
            {
                return context.Books.Where(i => i.IsApproved && i.IsHome).ToList();
            }
        }

        public List<Book> GetSearchResult(string searchString)
        {
            using (var context = new BookContext())
            {
                var books = context.Books
                .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                .AsQueryable();

                return books.ToList();
            }
        }

        public void Update(Book entity, int[] categoryIds)
        {
            using (var context = new BookContext())
            {
                var item = context.Books.Include(i => i.BookCategories).FirstOrDefault(i => i.Id == entity.Id);
                if (item != null)
                {
                    item.Name = entity.Name;
                    item.Price = entity.Price;
                    item.ImageUrl = entity.ImageUrl;
                    item.Description = entity.Description;
                    item.Url = entity.Url;
                    item.IsApproved = entity.IsApproved;
                    item.IsHome = entity.IsHome;

                    item.BookCategories = categoryIds.Select(catId => new BookCategory()
                    {
                        BookId = entity.Id,
                        CategoryId = catId,
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}