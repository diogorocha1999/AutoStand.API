using AutoStand.BAL.Interfaces;
using AutoStand.BAL.Services;
using AutoStand.BOL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoStand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                var user = await _authService.Register(userForRegisterDto);
                return StatusCode(201);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var token = await _authService.Login(userForLoginDto);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}