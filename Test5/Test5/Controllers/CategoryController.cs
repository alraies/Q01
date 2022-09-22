using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test5.Models;
using Test5.Services.Interfases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Private Properties
        private readonly ICategoryService _CategoryService;
        #endregion
        #region Ctor
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        #endregion
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Category> data = _CategoryService.GetList();
                if(data is null)
                    return Ok(Enumerable.Empty<Category>());
                return Ok(data);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
            
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Category data = await _CategoryService.GetById(id);
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

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category obj)
        {
            try
            {
             await   _CategoryService.Insert(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Update( [FromBody] Category obj)
        {
            try
            {
                _CategoryService.Update(obj);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                DevLogger.Write(ex);
                return StatusCode(500);
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _CategoryService.Delete(id);
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
