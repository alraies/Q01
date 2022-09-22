using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test5.Models;
using Test5.Services.Interfases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Private Properties
        private readonly IProductService _ProductService;
        #endregion
        #region Ctor
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        #endregion
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Product> data = _ProductService.GetList();
                if(data is null)
                    return Ok(Enumerable.Empty<Product>());
                return Ok(data);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
            
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Product data = await _ProductService.GetById(id);
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

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product obj)
        {
            try
            {
             await   _ProductService.Insert(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public IActionResult Update( [FromBody] Product obj)
        {
            try
            {
                _ProductService.Update(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ProductService.Delete(id);
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
