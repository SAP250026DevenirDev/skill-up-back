using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Services.Data
{
    public interface IUserService
    {
        Task UpdatePassword (Guid id, string currentPassword, string newPassword);
        Task<User?> GetByIdAsync(Guid id);
    }
}
