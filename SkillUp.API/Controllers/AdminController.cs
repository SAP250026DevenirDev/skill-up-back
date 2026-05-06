using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Core.Services;
using SkillUp.Domaine.Entities;
using System.Security.Claims;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Mappers;
using SkillUp.Core.Interfaces.Services.Auth;

namespace SkillUp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrator")]
public class AdminController(
  IAdminService _adminService) : ControllerBase
{
  [HttpPatch("users/{id:guid}")]
  public async Task<IActionResult> DisableUser(Guid id)
  {
    var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (!Guid.TryParse(adminIdClaim, out Guid adminId)) return Unauthorized();
    //var adminId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d");

    var user = await _adminService.DisableUserAsync(id, adminId);

    if (user == null)
    {
      return BadRequest("Action impossible.");
    }

    var response = user.ToDisableResponseDto();

    return Ok(response);
  }

  #region CreateUser

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
      User? createdUser = await _adminService.CreateUserByAdminAsync(userEntity, request.Password);
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
  #endregion

  #region HardDeleteUser

  [HttpDelete("users/{id:guid}/HardDeleteUser")]
  [Authorize(Roles = "Administrator")]
  [EndpointDescription("allows the admin to manually delete a user or admin account completely in the database")]
  [EndpointSummary("Hard delete user by id")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> HardDeleteUser(Guid id)
  {
    var result = await _adminService.HardDeleteUserAsync(id);

    if (!result)
    {
      return NotFound(new { Message = $"User with ID {id} not found." });
    }

    return NoContent();
  }

  #endregion
}