using System.Collections.Generic;

namespace library.data.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int Id);

        List<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}