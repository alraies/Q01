using Test5.Models;

namespace Test5.Services.Interfases
{
    public interface IProductService
    {
        Task<Product> GetById(int Id);

        Task<Product> GetByName(string Name);

        IEnumerable<Product> GetList();

        Task<int> Insert(Product obj);

        int Update(Product obj);

        int Delete(int id);
    }
}
