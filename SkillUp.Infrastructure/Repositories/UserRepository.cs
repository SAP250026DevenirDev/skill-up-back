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

        /// <summary>
        /// Comme je n'ai pas encore acces à tout ce qui touche aux mentoring (service, repo etc), j'ai décidé de supprimer directement en db afin de pouvoir avancer.
        /// La methode ici ira effacer les lignes qui sont en rapport avec le user. Mentoring et Collaborator qui est en mentorat etc.
        /// </summary>
        /// <param name="user">The user entity to be permanently removed.</param>
        public async Task HardDeleteAsync(User user)
        { 
          
          //si le user est un mentor
          IEnumerable<Mentoring> mentoringsAsMentor = _context.Mentorings.Where(m => m.MentorId == user.Id); 
          
          //si le user est un collaborateur qui a demande un mentorat.
          IEnumerable<Mentoring> mentoringsAsCollaborator = _context.Mentorings.Where(m => m.CollaboratorId == user.Id);

          //remove range pour retirer tous les objets (liste de mentor) de la collection renvoyée par le _context
          _context.Mentorings.RemoveRange(mentoringsAsMentor); 
          
          //idem ici, mais pour collaborator 
          _context.Mentorings.RemoveRange(mentoringsAsCollaborator);

          _context.Users.Remove(user);

          await _context.SaveChangesAsync();
        }
    }
}
