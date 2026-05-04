using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;

namespace SkillUp.Infrastructure.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly SkillUpDbContext _context;

        public SkillsRepository(SkillUpDbContext skillUpDbContext)
        {
            _context = skillUpDbContext;
        }

        /// <summary>
        /// Asynchronously adds a new skill to the data store.
        /// </summary>
        /// <param name="skill">The skill entity to add. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added skill entity.</returns>
        public async Task<Skill> CreateAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill;
        }
    }
}
