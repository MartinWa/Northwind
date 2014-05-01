namespace Northwind.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        void Commit();
        void Dispose();
    }
}