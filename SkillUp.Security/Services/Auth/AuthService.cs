using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using SkillUp.Domaine.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SkillUp.Security.Services.Auth
{
    public class AuthService(
        IUserRepository _userRepository,
        IPasswordHasherService _passwordHasherService) : IAuthService
    {
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("The email/password is not correct");
            }

            
            bool isPasswordOk = _passwordHasherService.VerifyPassword(password, user.HashedPassword);
            if (!isPasswordOk)
            {
                throw new UnauthorizedAccessException("The email/password is not correct");
            }
            return user;
        }
        /// <summary>
        /// Orchestrates the registration process for a new user.
        /// Validates email uniqueness, parses the security role, and initializes the user entity with default settings.
        /// </summary>
        /// <param name="email">The unique email address for the new account.</param>
        /// <param name="FirstName">The user's first name.</param>
        /// <param name="LastName">The user's last name.</param>
        /// <param name="Role">The string representation of the user's role (e.g., "Administrator", "User").</param>
        /// <returns>The newly created <see cref="User"/> entity after it has been persisted to the database.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown when the provided email is already associated with an existing account.</exception>
        /// <exception cref="ArgumentException">Thrown when the provided role string does not match any valid <see cref="Roles"/> enum value.</exception>
        public async Task<User?> RegisterAsync(string email, string FirstName, string LastName, string Role)
        {
            var userExisting = await _userRepository.GetByEmailAsync(email);
            if (userExisting is not null)
            {
                throw new UnauthorizedAccessException("The email already exist");
            }

            if (!Enum.TryParse<Roles>(Role, true, out var RoleEnum))
            {
                throw new ArgumentException($"The role is not a valid");
            }

            User user = new User()
            {
                Email = email,
                FirstName = FirstName,
                LastName = LastName,
                HashedPassword = _passwordHasherService.HashPassword("ChangeMe"),
                Role = RoleEnum,
                IsActive = true,
                IsPasswordChanged = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            return await _userRepository.AddAsync(user);
        }

        #region CreateUserByAdminAsync

        /// <summary>
        /// Allows an administrator to manually create a new user in the system.
        /// </summary>
        /// <param name="user">The user entity containing basic information and the assigned role.</param>
        /// <param name="password">The plain-text password to be hashed before storage.</param>
        /// <returns>A task representing the asynchronous operation, containing the created user with their generated ID.</returns>
        /// <exception cref="Exception">Thrown if the email is already in use or if the data is invalid.</exception>
        public async Task<User?> CreateUserByAdminAsync(User user, string password)
        {
            User? userExist = await _userRepository.GetByEmailAsync(user.Email);
            if (userExist is not null) //is not null pour ignorer les surcharches d'operateurs (!=) si il y en a un jour
            {
                throw new InvalidOperationException("The email is already in use");
            }

            user.HashedPassword = _passwordHasherService.HashPassword(password);
            user.IsActive = true;
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            return await _userRepository.AddAsync(user);
        }

        #endregion
    }
}
