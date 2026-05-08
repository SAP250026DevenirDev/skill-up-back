using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services.Data;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Services.Data
{
    public class UserService(IUserRepository _repository, IPasswordHasherService _passwordHasher) : IUserService
    {
        /// <summary>
        /// Performs the business logic for changing a password, including current password verification, 
        /// account status validation, and new password hashing.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="currentPassword">The plain-text current password provided by the user for authentication.</param>
        /// <param name="newPassword">The new plain-text password to be hashed and stored.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the user cannot be found in the database.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if the provided current password does not match the stored hash.</exception>
        /// <exception cref="AccessViolationException">Thrown if the user account is currently inactive or disabled.</exception>
        public async Task UpdatePassword(Guid id, string currentPassword, string newPassword)
        {
            var entity = await _repository.GetByIdAsync(id);
            if(entity is null)
            {
                throw new KeyNotFoundException("No user found");
            }
            if (!entity.IsActive)
            {
                throw new AccessViolationException("your account is not active");
            }
            bool isValid = _passwordHasher.VerifyPassword(currentPassword, entity.HashedPassword);

            if (!isValid)
            {
                throw new UnauthorizedAccessException("The current password provided is incorrect.");
            }
                string PasswordHashed = _passwordHasher.HashPassword(newPassword);
                await _repository.UpdatePassword(id, PasswordHashed);
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
