using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Services;

public class AdminService(IUserRepository _userRepository) : IAdminService
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

  /// <summary>
  /// Supprime définitivement un user du systeme après la vérification de son existence.
  /// </summary>
  /// <param name="userId">L'identifiant unique du user.</param>
  /// <returns>True si le user est trouvé et delete; sinon, false.</returns>
  public async Task<bool> HardDeleteUserAsync(Guid userId)
  {
    User? user = await _userRepository.GetByIdAsync(userId);

    if (user is null)
    {
      return false;
    }
    
    await _userRepository.HardDeleteAsync(user);

    return true;
  }
}

