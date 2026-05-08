using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Mappers;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Domaine.Enums;
using System.Security.Claims;

namespace SkillUp.API.Controllers
{
    /// <summary>
    /// Expose les endpoints REST pour la gestion des mentorats.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MentoringController(IMentoringService _mentoringService) : ControllerBase
    {
        /// <summary>
        /// Crée un nouveau mentorat. Le mentor est déduit du token JWT de l'utilisateur connecté.
        /// </summary>
        /// <param name="requestDto">Les données nécessaires à la création du mentorat.</param>
        /// <returns>201 avec le mentorat créé, 400 si la requête est invalide, 401 si non authentifié.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] MentoringRequestDto requestDto)
        {
            var mentorIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(mentorIdClaim, out Guid mentorId))
                return Unauthorized();

            var mentoring = requestDto.ToModel();
            mentoring.MentorId = mentorId;

            try
            {
                var created = await _mentoringService.Create(mentoring);
                return CreatedAtAction(nameof(GetAll), created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retourne une page de mentorats.
        /// </summary>
        /// <param name="page">Numéro de page (commence à 1, défaut : 1).</param>
        /// <param name="pageSize">Nombre d'éléments par page (défaut : 20).</param>
        /// <returns>200 avec les mentorats paginés et les métadonnées, 401 si non authentifié.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            if (page < 1 || pageSize < 1)
                return BadRequest("Les paramètres page et pageSize doivent être supérieurs à 0.");

            var result = await _mentoringService.GetAll(page, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Met à jour le statut d'un mentorat. Seul le mentor concerné peut effectuer cette action.
        /// </summary>
        /// <param name="id">L'identifiant du mentorat à modifier.</param>
        /// <param name="status">Le nouveau statut à appliquer.</param>
        /// <returns>200 avec le mentorat mis à jour, 400 si la transition est invalide, 403 si l'utilisateur n'est pas le mentor, 404 si introuvable.</returns>
        [HttpPatch("{id:guid}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] MentoringStatus status)
        {
            var requesterIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(requesterIdClaim, out Guid requesterId))
                return Unauthorized();

            try
            {
                var updated = await _mentoringService.UpdateStatus(id, status, requesterId);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
