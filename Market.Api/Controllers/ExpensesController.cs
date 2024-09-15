using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController(IExpenseService expenseService) : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] Expense expense)
        {
            var result = await expenseService.CreateAsync(expense);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await Task.Run(expenseService.GetAll);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await expenseService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] Expense expense)
        {
            var result = await expenseService.UpdateAsync(expense);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var result = await expenseService.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}
