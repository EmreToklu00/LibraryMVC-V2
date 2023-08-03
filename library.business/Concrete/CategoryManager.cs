using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.business.Abstract;
using library.data.Abstract;

namespace library.business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int BookId, int CategoryId)
        {
            _categoryRepository.DeleteFromCategory(BookId, CategoryId);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int Id)
        {
            return _categoryRepository.GetById(Id);
        }

        public Category GetByIdWithBooks(int Id)
        {
            return _categoryRepository.GetByIdWithBooks(Id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public string ErrorMessage { get; set; }

        public bool Validation(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}