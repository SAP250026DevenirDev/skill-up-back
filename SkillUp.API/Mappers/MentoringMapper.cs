using SkillUp.API.Dtos.Requests;
using SkillUp.Domaine.Entities;
using SkillUp.Domaine.Enums;

namespace SkillUp.API.Mappers
{
    /// <summary>
    /// Méthodes d'extension pour la conversion des DTOs de mentorat vers les entités domaine.
    /// </summary>
    public static class MentoringMapper
    {
        /// <summary>
        /// Convertit un <see cref="MentoringRequestDto"/> en entité <see cref="Mentoring"/> avec un statut initial <c>Waiting</c>.
        /// </summary>
        /// <param name="dto">Le DTO source.</param>
        /// <returns>L'entité mentorat prête à être persistée.</returns>
        public static Mentoring ToModel(this MentoringRequestDto dto)
        {
            return new Mentoring
            {
                Status = MentoringStatus.Waiting,
                CollaboratorId = dto.CollaboratorId,
                SkillId = dto.SkillId,
            };
        }
    }
}
