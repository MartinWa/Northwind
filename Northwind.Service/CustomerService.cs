using System.Linq;
using Northwind.Data;
using Northwind.Model;

namespace Northwind.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Customer> GetAll()
        {
            return _unitOfWork.Repository<Customer>().GetAll();
        }

        public Customer Find(int id)
        {
            return _unitOfWork.Repository<Customer>().Find(id);
        }

        public void Add(Customer entity)
        {
            _unitOfWork.Repository<Customer>().Add(entity);
        }

        public void Update(Customer entity)
        {
            _unitOfWork.Repository<Customer>().Update(entity);
        }

        public void Delete(Customer entity)
        {
            _unitOfWork.Repository<Customer>().Delete(entity);
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<Customer>().Delete(id);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
