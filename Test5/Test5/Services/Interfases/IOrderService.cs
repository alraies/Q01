using Test5.Models;

namespace Test5.Services.Interfases
{
    public interface IOrderService
    {
        Task<Order> GetById(int Id);
        Task<OrderDetail> GetLineById(int Id);
        IEnumerable<Order> GetList();
        IEnumerable<OrderDetail> GetDetailsList();

        Task<int> Insert(IEnumerable<OrderDetail> obj);
        Task<int> Insert(Order obj);

        int Update(Order obj);

        int Delete(int id);
        int DeleteLine(int id);
    }
}
