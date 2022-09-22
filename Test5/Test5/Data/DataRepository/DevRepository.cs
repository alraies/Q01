using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test5.Data;

namespace Data.DataRepository
{
    public class DevRepository<T> : IDevRepository<T> where T : class
    {
        protected readonly Test5DbContext _context;
        public DevRepository(Test5DbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task AddRange(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _context.Set<T>().Where(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception) { throw; }

        }

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.

        public async Task Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveById(int Id)
        {
            try
            {
                T? obj =  _context.Set<T>().Find(Id);

                if(obj is null)
                    return;
                 _context.Set<T>().Remove(obj);
                _context.SaveChanges();



            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<T> entity)
        {
            try
            {
                _context.Set<T>().UpdateRange(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
    }
}
