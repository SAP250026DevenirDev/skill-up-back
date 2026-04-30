using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync (string email);
        Task<User?> AddAsync(User user);
    }
}
