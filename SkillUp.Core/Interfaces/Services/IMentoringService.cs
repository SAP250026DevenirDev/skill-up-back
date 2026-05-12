using SkillUp.Core.Models;
using SkillUp.Domaine.Entities;
using SkillUp.Domaine.Enums;

namespace SkillUp.Core.Interfaces.Services
{
    /// <summary>
    /// Définit les opérations métier liées à la gestion des mentorats.
    /// </summary>
    public interface IMentoringService
    {
        /// <summary>
        /// Crée un nouveau mentorat entre un mentor et un collaborateur.
        /// </summary>
        /// <param name="mentoring">L'entité mentorat à créer.</param>
        /// <returns>Le mentorat créé.</returns>
        Task<Mentoring> Create(Mentoring mentoring);

        /// <summary>
        /// Récupère une page de mentorats.
        /// </summary>
        /// <param name="page">Numéro de page (commence à 1).</param>
        /// <param name="pageSize">Nombre d'éléments par page.</param>
        /// <returns>Un résultat paginé contenant les mentorats et les métadonnées de pagination.</returns>
        Task<PagedResult<Mentoring>> GetAll(int page, int pageSize);

        /// <summary>
        /// Met à jour le statut d'un mentorat en respectant les transitions autorisées.
        /// </summary>
        /// <param name="id">L'identifiant unique du mentorat.</param>
        /// <param name="status">Le nouveau statut à appliquer.</param>
        /// <returns>Le mentorat mis à jour.</returns>
        Task<Mentoring> UpdateStatus(Guid id, MentoringStatus status, Guid requesterId);
    }
}
