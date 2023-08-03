using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace library.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {

        private ICategoryRepository _categoryRepository;

        public CategoriesViewComponent(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {

            if (RouteData.Values["category"] != null)
            {
                ViewBag.SelectedCategory = RouteData?.Values["category"];

            }
            List<Category> categories = _categoryRepository.GetAll();
            return View(categories);
        }
    }
}