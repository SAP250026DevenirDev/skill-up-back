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
        /// <remarks>Requires authentication. Only users with appropriate permissions can create new
        /// skills. The request body must contain valid skill data.</remarks>
        /// <param name="requestDto">The data transfer object containing the information required to create a new skill. Cannot be null.</param>
        /// <returns>An HTTP 201 Created response if the skill is successfully created; otherwise, an appropriate error response
        /// such as 400 Bad Request, 401 Unauthorized, or 500 Internal Server Error.</returns>
        [HttpPost("newSkill")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        {

            return Ok(skillCreated);
        }
    }
}
