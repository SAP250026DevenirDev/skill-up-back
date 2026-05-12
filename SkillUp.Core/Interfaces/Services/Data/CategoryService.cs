using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Services.Data;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillUp.Core.Interfaces.Services.Data;

public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
{
    /// <summary>
    /// Récupère toutes les catégories.
    /// </summary>
    public async Task<List<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }
    /// <summary>
    /// Récupère une catégorie par son identifiant unique.
    /// Lance une KeyNotFoundException si aucune catégorie n'est trouvée.
    /// </summary>
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        Category? category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) throw new KeyNotFoundException();
        return category;
    }

    /// <summary>
    /// Récupère une catégorie par son nom.
    /// Lance une ArgumentException si le nom est vide ou null.
    /// </summary>
    public async Task<Category?> GetByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));

        return await _categoryRepository.GetByNameAsync(name);
    }

    /// <summary>
    /// Ajoute une nouvelle catégorie en base de données.
    /// Vérifie que la catégorie n'est pas null, que son nom n'est pas vide
    /// et qu'aucune catégorie avec le même nom n'existe déjà.
    /// </summary>
    public async Task AddAsync(Category category)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");

        var existing = await GetByNameAsync(category.Name);
        if (existing is not null)
            throw new InvalidOperationException($"A category with the name '{category.Name}' already exists");

        await _categoryRepository.AddAsync(category);
    }

    /// <summary>
    /// Met à jour une catégorie par son identifiant.
    /// Lance une KeyNotFoundException si la catégorie n'est pas trouvée.
    /// </summary>
    public async Task<Category?> UpdateAsync(Guid id, Category category)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");

        return await _categoryRepository.UpdateAsync(id, category);
    }

    /// <summary>
    /// Supprime une catégorie par son identifiant.
    /// Lance une KeyNotFoundException si la catégorie n'est pas trouvée.
    /// </summary>
    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}