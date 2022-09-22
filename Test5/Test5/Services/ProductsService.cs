using Data.DataRepository;
using Test5.Models;
using Test5.Services.Interfases;

namespace Test5.Services
{
    public class ProductService : IProductService
    {
        #region Private Properties
        private readonly IDevRepository<Product> _devRepository;
        #endregion

        #region Ctor
        public ProductService(IDevRepository<Product> devRepository)
        {
            _devRepository = devRepository;
        }
        #endregion

        #region Retrive Data

        public async Task<Product> GetById(int Id)
        {
            try
            {
                return await _devRepository.GetById(Id);
            }
            catch (Exception)
            {
                //TODO:Write To Logger
                throw;
            }
        }

        public Task<Product> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetList()
        {
            try
            {
                return _devRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region CUD
        public async Task<int> Insert(Product obj)
        {
            try
            {
                await _devRepository.Add(obj);
                //if Success

                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Product obj)
        {
            try
            {
                _devRepository.Update(obj);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Delete(int id)
        {
            try
            {
                _devRepository.RemoveById(id);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
