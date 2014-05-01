using Northwind.Data;
using Northwind.Model;

namespace Northwind.Service
{
    public interface ICustomerService : IRepository<Customer>{}
}