using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Dtos.Responses;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using SkillUp.Security.Services;

namespace SkillUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService,
        IJwtService _jwtService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto _loginRequest)
        {
            try
            {
                User user = await _authService.LoginAsync(_loginRequest.Email, _loginRequest.HashedPassword);
                string token = _jwtService.GenerateToken(user);
                return Ok(new LoginResponseDto { Token = token });
            }

            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { ex.Message });
            }
        }

    }
}
