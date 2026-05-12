using SkillUp.Core.Models;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Interfaces.Repositories
{
    /// <summary>
    /// Définit les opérations d'accès aux données pour les mentorats.
    /// </summary>
    public interface IMentoringRepository
    {
        /// <summary>
        /// Persiste un nouveau mentorat en base de données.
        /// </summary>
        /// <param name="mentoring">L'entité mentorat à insérer.</param>
        /// <returns>Le mentorat créé avec son identifiant généré.</returns>
        Task<Mentoring> Create(Mentoring mentoring);

        /// <summary>
        /// Récupère une page de mentorats avec leurs entités liées (mentor, collaborateur, compétence).
        /// </summary>
        /// <param name="page">Numéro de page (commence à 1).</param>
        /// <param name="pageSize">Nombre d'éléments par page.</param>
        /// <returns>Un résultat paginé contenant les mentorats et les métadonnées de pagination.</returns>
        Task<PagedResult<Mentoring>> GetAll(int page, int pageSize);

        /// <summary>
        /// Récupère un mentorat par son identifiant unique, ou <c>null</c> s'il n'existe pas.
        /// </summary>
        /// <param name="id">L'identifiant unique du mentorat.</param>
        /// <returns>Le mentorat correspondant, ou <c>null</c>.</returns>
        Task<Mentoring?> GetById(Guid id);

        /// <summary>
        /// Met à jour un mentorat existant en base de données.
        /// </summary>
        /// <param name="mentoring">L'entité mentorat avec les modifications à persister.</param>
        /// <returns>Le mentorat mis à jour.</returns>
        Task<Mentoring> Update(Mentoring mentoring);
    }
}
