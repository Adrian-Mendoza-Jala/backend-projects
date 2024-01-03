using Microsoft.AspNetCore.Mvc;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Domain.Entities;

namespace SkillMasteryAPI.Presentation.Controllers
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
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterUserAsync(model);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var token = await _authService.LoginUserAsync(model);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

}
