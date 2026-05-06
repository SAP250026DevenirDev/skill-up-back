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
    }
}
