using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using library.business.Abstract;
using library.webui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace library.webui.Controllers
{
    public class AdminController : Controller
    {
        private IBookService _bookService;
        private ICategoryService _categoryService;
        public AdminController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }
        public IActionResult BookList()
        {
            return View(new BookListViewModel()
            {
                books = _bookService.GetAll()
            }
            );
        }

        [HttpGet]
        public IActionResult BookCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookCreate(BookModel model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            Book entity = new Book()
            {
                Name = model.Name,
                Url = model.Url,
                Price = (double)model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            bool response = _bookService.Create(entity);

            if (!(response))
            {
                CreateMessage(_bookService.ErrorMessage, "danger");
                return View(model);
            }
            CreateMessage($"{entity.Name} Added ", "success");
            return RedirectToAction("BookList");
        }


        [HttpGet]
        public IActionResult BookEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _bookService.GetByIdWithCategories((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new BookModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
                SelectedCategories = entity.BookCategories.Select(i => i.Category).ToList(),
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookEdit(BookModel model, int[] categoryIds, IFormFile file)
        {
            ViewBag.Categories = _categoryService.GetAll();

            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            Book entity = _bookService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Url = model.Url;
            entity.Price = (double)model.Price;
            entity.Description = model.Description;
            entity.IsApproved = model.IsApproved;
            entity.IsHome = model.IsHome;

            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.ImageUrl = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            bool response = _bookService.Update(entity, categoryIds);
            if (!(response))
            {
                CreateMessage(_bookService.ErrorMessage, "danger");
                return View(model);
            }
            CreateMessage($"{entity.Name} Updated ", "success");
            return RedirectToAction("BookList");
        }

        [HttpPost]
        public IActionResult DeleteBook(int Id)
        {
            var entity = _bookService.GetById(Id);

            if (entity != null)
            {
                _bookService.Delete(entity);
            }

            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün silindi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("BookList");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            }
            );
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            Category entity = new Category()
            {
                Name = model.Name,
                Url = model.Url,
            };
            _categoryService.Create(entity);

            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori eklendi. ",
                AlertType = "success",
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetByIdWithBooks((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                Books = entity.BookCategories.Select(p => p.Book).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Url = model.Url;

            _categoryService.Update(entity);

            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori güncellendi. ",
                AlertType = "success",
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int Id)
        {
            var entity = _categoryService.GetById(Id);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori silindi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int BookId, int CategoryId)
        {
            _categoryService.DeleteFromCategory(BookId, CategoryId);

            return Redirect("/admin/categories/" + CategoryId);
        }
        private void CreateMessage(string message, string alerttype)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }
    }
}