using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid Id);
        Task<Category?> GetByNameAsync(string name);
        Task<Category> AddAsync(Category category);
        Task<Category?> UpdateAsync(Guid id, Category category);
        Task DeleteAsync(Guid id);
    }
}
