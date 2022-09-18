using Application.Features.Auth.Commands.LoginUser;
using Application.Features.Auth.Commands.RegisterUser;
using Application.Features.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            LoginedDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegisteredDto result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }
    }
}
