using System.Linq;
using library.data.Abstract;
using library.webui.Models;
using Microsoft.AspNetCore.Mvc;


namespace library.webui.Controllers
{
    public class LibraryController : Controller
    {
        private IBookRepository _bookRepository;

        public LibraryController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }



        public IActionResult List(string category, int page = 1)
        {
            int pageSize = 4;
            var bookViewModel = new BookListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _bookRepository.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category

                },
                books = _bookRepository.getBooksByCategory(category, page, pageSize)
            };

            return View(bookViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }

            Book book = _bookRepository.getBookDetails(url);

            if (book == null)
            {
                return NotFound();
            }
            return View(new BookDetailModel()
            {
                book = book,
                categories = book.BookCategories.Select(i => i.Category).ToList()
            });
        }

        public IActionResult Search(string q)
        {

            if (string.IsNullOrEmpty(q))
            {
                return RedirectToAction("List");
            }

            var bookViewModel = new BookListViewModel()
            {
                books = _bookRepository.GetSearchResult(q)
            };
            return View(bookViewModel);
        }

    }
}