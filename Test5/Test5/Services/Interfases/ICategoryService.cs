using Test5.Models;

namespace Test5.Services.Interfases
{
    public interface ICategoryService
    {
        Task<Category> GetById(int Id);

        Task<Category> GetByName(string Name);

        IEnumerable<Category> GetList();

        Task<int> Insert(Category obj);

        int Update(Category obj);

        int Delete(int id);
    }
}
