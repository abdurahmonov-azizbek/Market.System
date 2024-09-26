using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] Order order)
        {
            var result = await orderService.CreateAsync(order);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await Task.Run(orderService.GetAll);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await orderService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] Order order)
        {
            var result = await orderService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var result = await orderService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
