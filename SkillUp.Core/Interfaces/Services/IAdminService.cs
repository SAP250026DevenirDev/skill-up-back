using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SkillUp.Core.Interfaces.Services
{
    public interface IAdminService
    {
        /// <summary>
        /// Désactive le compte d'un utilisateur (Soft Delete).
        /// Seul un utilisateur avec le rôle Administrator peut déclencher cette logique via le Controller.
        /// </summary>
        /// <param name="userId">L'identifiant unique de l'utilisateur à désactiver.</param>
        /// <returns>True si l'utilisateur a été trouvé et désactivé, sinon False.</returns>


        Task<User?> DisableUserAsync(Guid userId, Guid adminId);
        
        /// <summary>
        /// Crée un nouvel utilisateur (action réservée à l'Admin).
        /// </summary>
        /// <param name="user">L'entité User contenant les infos de base (et le rôle).</param>
        /// <param name="password">Le mot de passe en clair (qui sera haché dans l'implémentation).</param>
        /// <returns>L'utilisateur créé.</returns>
        Task<User?> CreateUserByAdminAsync(User user, string password);
        
        /// <summary>
        /// Supprime définitivement un utilisateur de la base de données pour répondre aux exigences RGPD.
        /// </summary>
        /// <param name="id">L'identifiant unique (Guid) de l'utilisateur à supprimer.</param>
        /// <returns>Une tâche représentant l'opération, contenant true si la suppression est réussie, sinon false.</returns>
        Task<bool> HardDeleteUserAsync(Guid id);
        
    }
}
