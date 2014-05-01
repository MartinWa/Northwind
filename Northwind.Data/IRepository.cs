using System.Linq;

namespace Northwind.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}