using E_Commerce.Application.Dto.Product;
using E_Commerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productServices.GetAll();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await productServices.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }
        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var products = await productServices.GetByName(name);
            if (products == null)
            {
                return NotFound($"No products found with name '{name}'.");
            }
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProduct product)
        {
            var result = await productServices.AddAsync(product);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await productServices.Update(product);

            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await productServices.DeleteById(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
        [HttpDelete]
        [Route("DeleteByName/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            var result = await productServices.DeleteByName(name);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
    }
}
