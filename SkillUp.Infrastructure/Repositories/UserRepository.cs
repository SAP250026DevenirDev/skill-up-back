using Microsoft.EntityFrameworkCore;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Infrastructure.Repositories
{
    public class UserRepository(SkillUpDbContext _context) : IUserRepository
    {
        public async Task<User?> GetByEmailAsync(string email)
        {
            if (email is null) return null;
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        //Ajouts pour la fonctionnalité Admin

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
