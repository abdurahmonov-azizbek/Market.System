using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnedProductsController(IReturnedProductService returnedProductService) : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] ReturnedProduct returnedProduct)
        {
            var result = await returnedProductService.Create(returnedProduct);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await Task.Run(returnedProductService.GetAll);
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await returnedProductService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] ReturnedProduct returnedProduct)
        {
            var result = await returnedProductService.UpdateAsync(returnedProduct);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var result = await returnedProductService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
