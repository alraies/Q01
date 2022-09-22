using Test5.Models;

namespace Test5.Services.Interfases
{
    public interface ICustomerService
    {
        Task<Customer> GetById(int Id);

        Task<Customer> GetByName(string Name);

        IEnumerable<Customer> GetList();

        Task<int> Insert(Customer obj);

        int Update(Customer obj);

        int Delete(int Id);
    }
}
