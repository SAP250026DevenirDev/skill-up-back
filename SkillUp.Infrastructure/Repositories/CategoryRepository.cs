using SkillUp.Domaine.Entities;
using SkillUp.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Infrastructure.Repositories
{
    public class CategoryRepository (SkillUpDbContext _context)

    {
        protected readonly SkillUpDbContext _dbContext = _context;

        public async Task<Category> Addasync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

    }
}
