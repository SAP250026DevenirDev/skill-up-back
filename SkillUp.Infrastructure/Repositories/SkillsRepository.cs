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
        public Skill Create(Skill skill)
        {
            EntityEntry<Skill> skillCreated = _context.Skills.Add(skill);
            _context.SaveChanges();

            return skillCreated.Entity;
        }
    }
}
