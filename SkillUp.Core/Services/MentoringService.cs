using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Core.Models;
using SkillUp.Domaine.Entities;
using SkillUp.Domaine.Enums;


namespace SkillUp.Core.Services
{
    /// <summary>
    /// Implémente la logique métier de gestion des mentorats.
    /// </summary>
    public class MentoringService(IMentoringRepository _mentoringRepository) : IMentoringService
    {
        /// <summary>
        /// Crée un mentorat après avoir vérifié que le mentor et le collaborateur sont deux personnes distinctes.
        /// </summary>
        /// <param name="mentoring">L'entité mentorat à créer.</param>
        /// <returns>Le mentorat persisté.</returns>
        /// <exception cref="InvalidOperationException">Levée si le mentor et le collaborateur sont identiques.</exception>
        public async Task<Mentoring> Create(Mentoring mentoring)
        {
            if (mentoring.MentorId == mentoring.CollaboratorId)
                throw new InvalidOperationException("Le mentor et le collaborateur ne peuvent pas être la même personne.");

            return await _mentoringRepository.Create(mentoring);
        }

        /// <summary>
        /// Récupère une page de mentorats.
        /// </summary>
        public async Task<PagedResult<Mentoring>> GetAll(int page, int pageSize)
        {
            return await _mentoringRepository.GetAll(page, pageSize);
        }

        /// <summary>
        /// Met à jour le statut d'un mentorat en vérifiant l'identité du demandeur et la validité de la transition.
        /// </summary>
        /// <param name="id">L'identifiant du mentorat.</param>
        /// <param name="status">Le nouveau statut souhaité.</param>
        /// <param name="requesterId">L'identifiant de l'utilisateur effectuant la demande.</param>
        /// <returns>Le mentorat mis à jour.</returns>
        /// <exception cref="KeyNotFoundException">Levée si le mentorat est introuvable.</exception>
        /// <exception cref="UnauthorizedAccessException">Levée si le demandeur n'est pas le mentor.</exception>
        /// <exception cref="InvalidOperationException">Levée si la transition de statut est invalide.</exception>
        public async Task<Mentoring> UpdateStatus(Guid id, MentoringStatus status, Guid requesterId)
        {
            var mentoring = await _mentoringRepository.GetById(id)
                ?? throw new KeyNotFoundException($"Mentoring introuvable pour l'id {id}.");

            if (mentoring.MentorId != requesterId)
                throw new UnauthorizedAccessException("Seul le mentor concerné peut modifier le statut de ce mentorat.");

            if (!IsValidTransition(mentoring.Status, status))
                throw new InvalidOperationException(
                    $"Transition de statut invalide : {mentoring.Status} -> {status}.");

            mentoring.Status = status;
            return await _mentoringRepository.Update(mentoring);
        }

        /// <summary>
        /// Vérifie qu'une transition de statut est autorisée selon le cycle de vie d'un mentorat (Waiting → Started → Finished).
        /// </summary>
        private static bool IsValidTransition(MentoringStatus current, MentoringStatus next) =>
            (current, next) switch
            {
                (MentoringStatus.Waiting, MentoringStatus.Started) => true,
                (MentoringStatus.Started, MentoringStatus.Finished) => true,
                _ => false
            };
    }
}
