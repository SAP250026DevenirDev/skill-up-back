using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Dtos.Responses;
using SkillUp.API.Mappers;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using SkillUp.Security.Services;

namespace SkillUp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController(
    IAuthService _authService,
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

    /// <summary>
    /// Registers a new user in the system with a default password.
    /// This endpoint is restricted to users with the 'Administrator' role.
    /// </summary>
    /// <param name="_registerRequest">The user registration data including email, name, and role.</param>
    /// <returns>The newly created user details.</returns>
    /// <response code="200">Returns the created user object.</response>
    /// <response code="400">Returned if the email already exists, the role is invalid, or a validation error occurs.</response>
    /// <response code="401">Returned if the requester is not authenticated or does not have Administrator privileges.</response>
    [HttpPost("register")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register(RegisterRequestDto _registerRequest)
    {
      try
      {
        User? user = await _authService.RegisterAsync(_registerRequest.Email, _registerRequest.FirstName,
          _registerRequest.LastName, _registerRequest.Role);
        return Ok(user);
      }
      catch (UnauthorizedAccessException ex)
      {
        return Unauthorized(ex.Message);
      }
      catch (ArgumentException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    /// <summary>
    /// Endpoint réservé aux administrateurs pour créer un nouveau compte utilisateur.
    /// </summary>
    [HttpPost("admin/create-user")]
    [Authorize(Roles = "Administrator")]
    [EndpointSummary("Create user by admin")]
    [EndpointDescription("allows the admin to manually create a user or admin account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
    {
      User userEntity = request.ToEntity();

      try
      {
        User? createdUser = await _authService.CreateUserByAdminAsync(userEntity, request.Password);
        if (createdUser is null) //is null = pareil que is not null pour ignorer la surcharge d'op
        {
          return BadRequest(new { Error = "User creation failed." });
        }

        return Ok(new
        {
          Message = "User created successfully.",
          UserId = createdUser.Id,
          Email = createdUser.Email
        });
      }
      catch (InvalidOperationException ex)
      {
        return Conflict(new { ex.Message }); //mail deja utilisé
      }
      catch (Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }
  }
}