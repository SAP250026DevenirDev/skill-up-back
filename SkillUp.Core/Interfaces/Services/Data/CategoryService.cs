using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Services.Data;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Interfaces.Services.Data;

public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
{
    public async Task AddAsync(Category category)
    {
        await _categoryRepository.AddAsync(category);
        
    }
}