using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MilleniumRecruitmentTask.Domain;
using MilleniumRecruitmentTask.Domain.Models;
using MilleniumRecruitmentTask.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilleniumRecruitmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const int ErrorStatusCode = 500;

        private readonly ILogger<ProductController> _logger;
        private readonly IRepository<Product> _repository;
        public ProductController(ILogger<ProductController> logger,
            IRepository<Product> repository
           )
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product getAll exception: {ex}");
                return StatusCode(ErrorStatusCode, ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
                var result = await _repository.Get(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product get exception: {ex}");
                return StatusCode(ErrorStatusCode, ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] ProductCreateUpdateDto product)
        {
            try
            {
                var id = await _repository.Create(
                  Product.Create(
                     product.Name,
                     product.Price));

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product create exception: {ex}");
                return StatusCode(ErrorStatusCode, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductCreateUpdateDto body)
        {
            try
            {
                var current = await _repository.Get(id);

                if (current == null)
                    return NotFound();

                await _repository.Update(id, Product.Update(body.Name, body.Price, current));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product update exception: {ex}");
                return StatusCode(ErrorStatusCode, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product delete exception: {ex}");
                return StatusCode(ErrorStatusCode, ex.Message);
            }
        }
    }
}
