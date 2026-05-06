using System;
using System.Collections.Generic;
using System.Text;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string email, string password);
        Task<User?> RegisterAsync(string email, string FirstName, string LastName, string Role);

        #region CreateUserByAdmin

        /// <summary>
        /// Allows an administrator to manually create a new user in the system.
        /// </summary>
        /// <param name="user">The user entity containing basic information and the assigned role.</param>
        /// <param name="password">The plain-text password to be hashed before storage.</param>
        /// <returns>A task representing the asynchronous operation, containing the created user with their generated ID.</returns>
        /// <exception cref="Exception">Thrown if the email is already in use or if the data is invalid.</exception>
        Task<User> CreateUserByAdminAsync(User user, string password);

        #endregion
    }
}
