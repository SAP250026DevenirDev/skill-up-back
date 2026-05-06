using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync (string email);
        //ce  qui suit me permettra de mettre à jour l'entité au moment de la desactivation
        Task<User?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(User user);
        Task<User?> AddAsync(User user);
        Task DeleteAsync(User user);
    }
}
