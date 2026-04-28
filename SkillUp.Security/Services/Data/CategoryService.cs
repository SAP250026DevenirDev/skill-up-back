
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Services.Data;

public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
{
    public async Task AddAsync(Category category)
    {
        await _categoryRepository.Addasync(category);
    }
}