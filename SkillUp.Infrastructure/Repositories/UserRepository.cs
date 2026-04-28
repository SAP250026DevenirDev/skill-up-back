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
    }
}
