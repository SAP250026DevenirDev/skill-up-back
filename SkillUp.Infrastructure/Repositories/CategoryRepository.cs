using Microsoft.EntityFrameworkCore;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Infrastructure.Repositories
{
    public class CategoryRepository(SkillUpDbContext _context) : ICategoryRepository

    {
        protected readonly SkillUpDbContext _dbContext = _context;

        public async Task<Category> Addasync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetByIdsAsync(Guid Id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
