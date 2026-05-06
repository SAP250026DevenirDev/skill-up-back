using Microsoft.EntityFrameworkCore;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.Infrastructure.Repositories
{
    public class UserRepository(SkillUpDbContext _context) : IUserRepository
    {
        /// <summary>
        /// Persists a new user entity to the database.
        /// </summary>
        /// <param name="user">The user entity to be added. Can be null.</param>
        /// <returns>
        /// The added <see cref="User"/> entity with its database-generated state (like primary keys), 
        /// or <see langword="null"/> if the input user was null.
        /// </returns>
        /// <remarks>
        /// This method performs an asynchronous insert operation and immediately commits the changes to the database.
        /// </remarks>
        public async Task<User?> AddAsync(User user)
        {
            if (user is null) return null;
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            if (email is null) return null;
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Ajouts pour la fonctionnalité Admin
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