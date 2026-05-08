using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;
using SkillUp.Core.Models;


namespace SkillUp.Infrastructure.Repositories
{
    /// <summary>
    /// Accès aux données des mentorats via Entity Framework Core.
    /// </summary>
    public class MentoringRepository (SkillUpDbContext _context) : IMentoringRepository
    {

        /// <summary>
        /// Insère un nouveau mentorat et persiste les changements.
        /// </summary>
        /// <param name="mentoring">L'entité à insérer.</param>
        /// <returns>L'entité créée telle que retournée par EF Core.</returns>
        public async Task<Mentoring> Create(Mentoring mentoring)
        {
            EntityEntry<Mentoring> MentoringCreated = _context.Mentorings.Add(mentoring);
            await _context.SaveChangesAsync();

            return MentoringCreated.Entity;
        }

        public async Task<PagedResult<Mentoring>> GetAll(int page, int pageSize)
        {
            var query = _context.Mentorings
                .Include(m => m.Skill)
                .Include(m => m.Mentor)
                .Include(m => m.Collaborator);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Mentoring>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<Mentoring?> GetById(Guid id) =>
        await _context.Mentorings.Include(m => m.Skill).Include(m => m.Mentor).Include(m => m.Collaborator)
            .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<Mentoring> Update(Mentoring mentoring)
        {
            _context.Mentorings.Update(mentoring);
            await _context.SaveChangesAsync();
            return mentoring;
        }
    }
}
