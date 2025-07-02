using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReecsPortal.Application.Auth.Commands;
using ReecsPortal.Application.DTOs.Auth;

namespace ReecsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(ISender sender) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await sender.Send(new LoginCommand(loginDto));

            if (!result.Status)
                return Unauthorized(result.Message);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await sender.Send(new RegisterCommand(registerDto));

            if (!result.Status)
                return Unauthorized(result.Message);

            return Ok(result);
        }
    }
}
