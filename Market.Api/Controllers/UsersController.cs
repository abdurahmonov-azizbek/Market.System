using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] User user)
        {
            var result = await userService.CreateAsync(user);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            var result = await Task.Run(userService.GetAll);
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{userId:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
        {
            var result = await userService.GetByIdAsync(userId);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] User user)
        {
            var result = await userService.UpdateAsync(user);
            return Ok(result);
        }

        [HttpDelete("{userId:guid}")]
        public async ValueTask<IActionResult> DeleteById([FromRoute] Guid userId)
        {
            var result = await userService.DeleteAsync(userId);
            return Ok(result);
        }
    }
}
