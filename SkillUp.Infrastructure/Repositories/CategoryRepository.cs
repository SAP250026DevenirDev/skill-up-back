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
        /// <summary>
        /// Récupère toutes les catégories.
        /// </summary>
        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
        /// <summary>
        /// Ajoute une nouvelle catégorie en base de données.
        /// </summary>
        public async Task<Category> AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
        /// <summary>
        /// Récupère une catégorie par son identifiant unique.
        /// Lance une KeyNotFoundException si aucune catégorie n'est trouvée.
        /// </summary>
        public async Task<Category?> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);
        }
        /// <summary>
        /// Récupère une catégorie par son nom.
        /// </summary>
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
            Category? existing = await GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException();

            existing.Name = category.Name;
            existing.Description = category.Description;

            await _dbContext.SaveChangesAsync();
            return existing;
        }
        /// <summary>
        /// Supprime une catégorie existante.
        /// Lance une KeyNotFoundException si la catégorie n'est pas trouvée.
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            Category? category = await GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException();
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
