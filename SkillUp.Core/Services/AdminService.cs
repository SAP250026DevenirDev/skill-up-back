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
}
