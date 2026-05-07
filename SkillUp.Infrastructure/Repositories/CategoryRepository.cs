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
    public class CategoryRepository(SkillUpDbContext _context) : ICategoryRepository

    {
        protected readonly SkillUpDbContext _dbContext = _context;

        public async Task<Category> AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetByIdsAsync(Guid Id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
        /// <summary>
        /// Met à jour une catégorie existante.
        /// Lance une KeyNotFoundException si la catégorie n'est pas trouvée.
        /// </summary>
        public async Task<Category?> UpdateAsync(Guid id, Category category)
        {
            Category? existing = await GetByIdsAsync(id);
            if (existing == null) throw new KeyNotFoundException();

            existing.Name = category.Name;
            existing.Description = category.Description;

            await _dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
