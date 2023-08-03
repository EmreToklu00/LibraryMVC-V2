using System.Collections.Generic;
using library.business.Abstract;
using library.data.Abstract;

namespace library.business.Concrete
{
    public class BookManager : IBookService
    {

        private IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public bool Create(Book entity)
        {
            if (Validation(entity))
            {
                _bookRepository.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Book entity)
        {
            _bookRepository.Delete(entity);
        }


        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookDetails(string url)
        {
            return _bookRepository.getBookDetails(url);
        }

        public List<Book> GetBooksByCategory(string name, int page, int pageSize)
        {
            return _bookRepository.getBooksByCategory(name, page, pageSize);
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public Book GetByIdWithCategories(int Id)
        {
            return _bookRepository.GetByIdWithCategories(Id);
        }

        public int GetCountByCategory(string category)
        {
            return _bookRepository.GetCountByCategory(category);
        }

        public List<Book> GetHomePageBooks()
        {
            return _bookRepository.GetHomePageBooks();
        }

        public List<Book> GetSearchResult(string searchString)
        {
            return _bookRepository.GetSearchResult(searchString);
        }

        public void Update(Book entity)
        {
            _bookRepository.Update(entity);
        }

        public bool Update(Book entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "You must select at least one category for the product.";
                    return false;
                }
                _bookRepository.Update(entity, categoryIds);
                return true;
            }
            return false;
        }

        public string ErrorMessage { get; set; }

        public bool Validation(Book entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Enter Book Name\n";
                isValid = false;
            }

            if (entity.Price < 0)
            {
                ErrorMessage += "The product price cannot be negative.\n";
                isValid = false;
            }

            return isValid;
        }


    }
}