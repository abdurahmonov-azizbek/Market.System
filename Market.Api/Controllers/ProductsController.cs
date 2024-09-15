using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] Product product)
        {
            var result = await productService.CreateAsync(product);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await Task.Run(productService.GetAll);
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] Product product)
        {
            var result = await productService.UpdateAsync(product);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var result = await productService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
