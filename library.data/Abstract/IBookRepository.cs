using System.Collections.Generic;
using library.entity;


namespace library.data.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {

        Book getBookDetails(string url);

        Book GetByIdWithCategories(int Id);
        List<Book> getBooksByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        List<Book> GetSearchResult(string searchString);
        List<Book> GetHomePageBooks();

        void Update(Book entity, int[] categoryIds);

    }
}