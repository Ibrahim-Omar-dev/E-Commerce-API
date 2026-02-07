using E_Commerce.Application.Categorys;
using E_Commerce.Application.Dto;
using E_Commerce.Application.Dto.Categorys;
using E_Commerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryServices.GetAll();

            if (!categories.Any())
                return NotFound("No categories found.");

            return Ok(categories);
        }

        // GET: api/category/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await categoryServices.GetById(id);

            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }

        // GET: api/category/by-name/{name}
        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var category = await categoryServices.GetByName(name);

            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ServicesResponse response = await categoryServices.AddAsync(category);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // PUT: api/category
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ServicesResponse response = await categoryServices.Update(category);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            ServicesResponse response = await categoryServices.DeleteById(id);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok(response);
        }

        // DELETE: api/category/by-name/{name}
        [HttpDelete("by-name/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            ServicesResponse response = await categoryServices.DeleteByName(name);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok(response);
        }
    }
}
