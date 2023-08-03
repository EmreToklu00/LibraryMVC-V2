using System.Collections.Generic;
using library.entity;

namespace library.data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdWithBooks(int Id);

        void DeleteFromCategory(int BookId, int CategoryId);
    }
}