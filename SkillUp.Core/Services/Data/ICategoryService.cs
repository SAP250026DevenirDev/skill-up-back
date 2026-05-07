using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.Core.Services.Data;

public interface ICategoryService
{
    Task<Category?> GetByIdsAsync(Guid id);
    Task<Category?> GetByNameAsync(string Name);
    Task AddAsync (Category category);
    Task<Category?> UpdateAsync(Guid id, Category category);
}
