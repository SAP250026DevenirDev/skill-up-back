using System;
using System.Threading.Tasks;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdsAsync(Guid Id);
        Task<Category?> GetByNameAsync(string name);
        Task<Category> AddAsync(Category category);
        Task<Category?> UpdateAsync(Guid id, Category category);
    }
}
