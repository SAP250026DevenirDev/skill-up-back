using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Services;

public class AdminService(
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService) : IAdminService
{
    public async Task<User?> DisableUserAsync(Guid userId, Guid adminId)
    {
        if (userId == adminId) return null;

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null || !user.IsActive) return null;

        user.IsActive = false;
        user.UpdatedAt = DateTime.UtcNow;

        var success = await _userRepository.UpdateAsync(user);

        return success ? user : null;
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

    #region HardDeleteUserAsync

    public async Task<bool> HardDeleteUserAsync(Guid userId)
    {
        User? user = await _userRepository.GetByIdAsync(userId);
        
        if (user is null)
        {
            return false;
        }
        
        await _userRepository.DeleteAsync(user);
        
        return true;
    }

    #endregion
}
