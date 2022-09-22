using Data.DataRepository;
using System.Security.Cryptography;
using Test5.Data;
using Test5.Models;
using Test5.Services.Interfases;

namespace Test5.Services
{
    public class OrderService : IOrderService
    {
        #region Private Properties
        private readonly IDevRepository<Order> _orderDevRepository;
        private readonly IDevRepository<OrderDetail> _orderDetailsDevRepository;
        private readonly Test5DbContext _context;
        #endregion

        #region Ctor
        public OrderService(
            IDevRepository<Order> orderDevRepository
            , IDevRepository<OrderDetail> orderDetailsDevRepository
,
Test5DbContext context)
        {
            _orderDevRepository = orderDevRepository;
            _orderDetailsDevRepository = orderDetailsDevRepository;
            _context = context;
        }
        #endregion

        #region Retrive Data

        public async Task<Order> GetById(int Id)
        {
            try
            {
                return await _orderDevRepository.GetById(Id);
            }
            catch (Exception)
            {
                //TODO:Write To Logger
                throw;
            }
        }
        public async Task<OrderDetail> GetLineById(int Id)
        {
            try
            {
                return await _orderDetailsDevRepository.GetById(Id);
            }
            catch (Exception)
            {
                //TODO:Write To Logger
                throw;
            }
        }



        public IEnumerable<Order> GetList()
        {
            try

            {
                //Test 6

                //var x = from d in _context.OrderDetails
                //        where d.UnitPrice > 1000
                //group d by d.OrderId into d2
                //        orderby d2.Key descending
                //        select d2;

                       

                //var y = _context.OrderDetails.GroupBy(t => t.OrderId)
                //           .Select(t => new OrderDetail
                //           {
                //               UnitPrice = t.Sum(ta => ta.UnitPrice),
                //           }).ToList();


                return _orderDevRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<OrderDetail> GetDetailsList()
        {
            try
            {
                return _orderDetailsDevRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region CUD
        public async Task<int> Insert(Order obj)
        {
            try
            {
                await _orderDevRepository.Add(obj);
                //if Success

                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> Insert(IEnumerable<OrderDetail> obj)
        {
            try
            {
                await _orderDetailsDevRepository.AddRange(obj);
                //if Success

                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Order obj)
        {
            try
            {
                _orderDevRepository.Update(obj);
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
                _orderDevRepository.RemoveById(id);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteLine(int id)
        {
            try
            {
                _orderDetailsDevRepository.RemoveById(id);
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
