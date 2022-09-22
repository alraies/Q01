using Data.DataRepository;
using Test5.Models;
using Test5.Services.Interfases;

namespace Test5.Services
{
    public class CustomerService : ICustomerService
    {
        #region Private Properties
        private readonly IDevRepository<Customer> _devRepository;
        #endregion

        #region Ctor
        public CustomerService(IDevRepository<Customer> devRepository)
        {
            _devRepository = devRepository;
        }
        #endregion

        #region Retrive Data

        public async Task<Customer> GetById(int Id)
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

        public Task<Customer> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetList()
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
        public async Task<int> Insert(Customer obj)
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

        public int Update(Customer obj)
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
        public int Delete(int Id)
        {
            try
            {
                _devRepository.RemoveById(Id);
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
