using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Core.Services;
using SkillUp.Domaine.Entities;
using System.Security.Claims;
using SkillUp.API.Mappers;

namespace SkillUp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrator")] 
public class AdminController(IAdminService _adminService) : ControllerBase
{

[HttpDelete("users/{id:guid}")]
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

[HttpDelete("users/{id:guid}/HardDeleteUser")]
[EndpointSummary("Hard Delete User in database")]
[EndpointDescription("Allows the admin to delete a user in db if asked. (right to be forgotten)")]
[ProducesResponseType(StatusCodes.Status204NoContent)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<IActionResult> HardDeleteUserAsync(Guid id)
{
  var result = await _adminService.HardDeleteUserAsync(id);
  if (!result) return NotFound(new {Message = $"User with id {id} not found."});
  return NoContent();
}
}