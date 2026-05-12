using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Mappers;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Domaine.Entities;
using System.Security.Claims;

namespace SkillUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IEvaluateService _evaluateService;

        public SkillController(ISkillService skillService, IEvaluateService evaluateService)
        {
            _skillService = skillService;
            _evaluateService = evaluateService;
        }
        /// <summary>
        /// Crée une nouvelle skill (réservé à l'Administrator).
        /// POST api/skill
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Create([FromBody] SkillRequestDto requestDto)
        {
            Skill skillCreated = _skillService.Create(requestDto.ToModel());

            return Ok(skillCreated);
        }
        /// <summary>
        /// Ajoute une skill existante au profil du collaborateur connecté.
        /// POST api/skill/profile
        /// </summary>

        /// <summary>
        /// Ajoute une skill existante au profil du collaborateur connecté.
        /// POST api/skill/profile
        /// </summary>
        [HttpPost("profile")]
        [Authorize(Roles = "Collaborator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSkillToProfile([FromBody] AddSkillToProfileRequestDto dto)
        {
            try
            {
                // Récupère l'Id du collaborateur depuis le token JWT
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var evaluate = await _evaluateService.AddSkillToProfileAsync(userId, dto.SkillId, dto.Level);

                return Created(string.Empty, EvaluateMapper.ToDto(evaluate));
            }
            catch (InvalidOperationException ex)
            {
                // Skill déjà dans le profil → 409
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                // Erreur inattendue → 500
                return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
            }
        }
    }
}