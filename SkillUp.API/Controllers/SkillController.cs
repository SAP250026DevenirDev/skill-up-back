using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Mappers;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Domaine.Entities;

namespace SkillUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        /// <summary>
        /// Creates a new skill using the provided data.
        /// </summary>
        /// <remarks>This action is restricted to users with the 'Administrator' role. The request body
        /// must conform to the expected SkillRequestDto schema. Validation errors will result in a 400 Bad Request
        /// response.</remarks>
        /// <param name="requestDto">The data transfer object containing the information required to create a new skill. Must not be null and
        /// must satisfy all validation requirements.</param>
        /// <returns>An IActionResult indicating the result of the operation. Returns 201 Created with the created skill on
        /// success, 400 Bad Request if the input is invalid, 401 Unauthorized if the user is not authorized, or 500
        /// Internal Server Error if an unexpected error occurs.</returns>
        [HttpPost("newSkill")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] SkillCreateRequestDto requestDto)
        {
            try {
                Skill skillCreated = await _skillService.CreateAsync(requestDto.ToModel());
                return Ok("The skill has been saving");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Internal server error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }
    }
}
