

using System.Collections.Generic;
using System.Linq;
using library.data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace library.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, BookContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int BookId, int CategoryId)
        {
            using (var context = new BookContext())
            {
                var cmd = "delete from bookcategory where BookId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, BookId, CategoryId);
            }

        }

        public Category GetByIdWithBooks(int Id)
        {
            using (var context = new BookContext())
            {
                return context.Categories.Where(i => i.Id == Id).Include(i => i.BookCategories).ThenInclude(i => i.Book).FirstOrDefault();
            }
        }


    }
}