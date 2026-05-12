using Microsoft.EntityFrameworkCore;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Infrastructure.Repositories;

public class EvaluateRepository (SkillUpDbContext _context): IEvaluateRepository
{
    /// <summary>
    /// Insère une nouvelle évaluation en base et charge les navigations Skill et Category.
    /// </summary>
    public async Task<Evaluate> AddAsync(Evaluate evaluate)
    {
        await _context.Evaluates.AddAsync(evaluate);
        await _context.SaveChangesAsync();

        return await _context.Evaluates
            .Include(e => e.Skill)
            .ThenInclude(s => s.Category)
            .FirstAsync(e => e.UserId == evaluate.UserId && e.SkillId == evaluate.SkillId);
    }

    /// <summary>
    /// Vérifie si un collaborateur a déjà cette skill dans son profil.
    /// </summary>
    public async Task<bool> ExistAsync(Guid userId, Guid skillId)
    {
        return await _context.Evaluates
            .AnyAsync(e => e.UserId == userId && e.SkillId == skillId);
    }
}
