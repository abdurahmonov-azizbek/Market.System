using Market.Application.Interfaces;
using Market.Domain.Common.Constants;
using Market.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async ValueTask<IActionResult> Register([FromBody] RegisterDetails registerDetails)
        {
            var result = await authService.RegisterAsync(registerDetails);

            return Ok(result);
        }

        [HttpGet("login")]
        public async ValueTask<IActionResult> Login([FromQuery] LoginDetails loginDetails)
        {
            var result = await authService.LoginAsync(loginDetails);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async ValueTask<IActionResult> Me()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)!.Value);

            var user = await authService.Me(userId);

            return Ok(user);
        }
    }
}
