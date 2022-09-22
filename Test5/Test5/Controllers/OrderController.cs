using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test5.Models;
using Test5.Services.Interfases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Private Properties
        private readonly IOrderService _OrderService;
        #endregion
        #region Ctor
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        #endregion
        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Order> data = _OrderService.GetList();
                if(data is null)
                    return Ok(Enumerable.Empty<Order>());
                return Ok(data);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
            
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Order data = await _OrderService.GetById(id);
                if (data is null)
                    return NotFound(id);
                return Ok(data);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order obj)
        {
            try
            {
             await   _OrderService.Insert(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public IActionResult Update( [FromBody] Order obj)
        {
            try
            {
                _OrderService.Update(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _OrderService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }
    }
}
