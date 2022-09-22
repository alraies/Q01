using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test5.Models;
using Test5.Services.Interfases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Private Properties
        private readonly ICustomerService _customerService;
        #endregion
        #region Ctor
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Customer> data = _customerService.GetList();
                if(data is null)
                    return Ok(Enumerable.Empty<Customer>());
                return Ok(data);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
            
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Customer data = await _customerService.GetById(id);
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

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer obj)
        {
            try
            {
             await   _customerService.Insert(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Update( [FromBody] Customer obj)
        {
            try
            {
                _customerService.Update(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _customerService.Delete(id);
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
