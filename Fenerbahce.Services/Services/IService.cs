using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface IService<T>
    {
        T GetById(long id);
        void Create(T entity);
        void Delete(T entity);
        void Delete(object id);
        IList<T> GetAll();
        void Update(T entity);
    }
}
