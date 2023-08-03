using library.data.Abstract;
using Microsoft.AspNetCore.Mvc;
using library.entity;
using library.webui.Models;

namespace library.webui.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }


        public IActionResult Index()
        {
            var books = new BookListViewModel()
            {
                books = _bookRepository.GetHomePageBooks()
            };
            return View(books);
        }

        public IActionResult Details(int Id)
        {
            return View(_bookRepository.GetById(Id));
        }
    }
}