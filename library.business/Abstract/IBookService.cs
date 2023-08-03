using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.business.Abstract
{
    public interface IBookService : IValidator<Book>
    {
        Book GetById(int id);
        Book GetBookDetails(string url);

        Book GetByIdWithCategories(int Id);

        List<Book> GetBooksByCategory(string name, int page, int pageSize);
        List<Book> GetHomePageBooks();

        List<Book> GetSearchResult(string searchString);
        int GetCountByCategory(string category);

        List<Book> GetAll();

        bool Create(Book entity);

        bool Update(Book entity, int[] categoryIds);

        void Delete(Book entity);
    }
}