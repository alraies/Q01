using System.Linq.Expressions;

namespace Data.DataRepository
{
    public interface IDevRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entity);
        Task Remove(T entity);
        Task RemoveById(int Id);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
