using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.business.Abstract
{
    public interface ICategoryService : IValidator<Category>
    {
        Category GetById(int Id);

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);

        void Delete(Category entity);
        Category GetByIdWithBooks(int Id);

        void DeleteFromCategory(int BookId, int CategoryId);
    }
}