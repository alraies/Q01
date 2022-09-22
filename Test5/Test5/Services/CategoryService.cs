using Data.DataRepository;
using Test5.Models;
using Test5.Services.Interfases;

namespace Test5.Services
{
    public class CategoryService : ICategoryService
    {
        #region Private Properties
        private readonly IDevRepository<Category> _devRepository;
        #endregion

        #region Ctor
        public CategoryService(IDevRepository<Category> devRepository)
        {
            _devRepository = devRepository;
        }
        #endregion

        #region Retrive Data

        public async Task<Category> GetById(int Id)
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

        public Task<Category> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetList()
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
        public async Task<int> Insert(Category obj)
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

        public int Update(Category obj)
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
