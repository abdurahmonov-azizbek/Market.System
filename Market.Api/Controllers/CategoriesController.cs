using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] Category category)
        {
            var result = await categoryService.CreateAsync(category);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await Task.Run(categoryService.GetAll);
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await categoryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] Category category)
        {
            var result = await categoryService.UpdateAsync(category);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var result = await categoryService.DeleteAsync(id);
            return Ok(result);
        }
    }
}