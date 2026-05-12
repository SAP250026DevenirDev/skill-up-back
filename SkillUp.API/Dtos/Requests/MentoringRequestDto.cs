using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests
{
    /// <summary>
    /// Corps de la requête pour la création d'un mentorat.
    /// </summary>
    public class MentoringRequestDto
    {
        /// <summary>L'identifiant du collaborateur à encadrer.</summary>
        [Required]
        public Guid CollaboratorId { get; set; }

        /// <summary>L'identifiant de la compétence sur laquelle porte le mentorat.</summary>
        [Required]
        public Guid SkillId { get; set; }
    }
}
