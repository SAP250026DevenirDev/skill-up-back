using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Services.Data;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Interfaces.Services.Data;

public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
{
    public async Task<Category?> GetByIdsAsync(Guid id)
    {
        try
        {
            return await _categoryRepository.GetByIdsAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the category by id: {ex.Message}", ex);
        }
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            return await _categoryRepository.GetByNameAsync(name);
        }
        catch (ArgumentException) { throw; }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the category by name: {ex.Message}", ex);
        }
    }

    public async Task AddAsync(Category category)
    {
        try
        {
            if (category is null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null");

            var existing = await GetByNameAsync(category.Name);
            if (existing is not null)
                throw new InvalidOperationException($"A category with the name '{category.Name}' already exists");

            await _categoryRepository.AddAsync(category);
        }
        catch (ArgumentNullException) { throw; }
        catch (ArgumentException) { throw; }
        catch (InvalidOperationException) { throw; }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while adding the category : {ex.Message}", ex);
        }
    }
}