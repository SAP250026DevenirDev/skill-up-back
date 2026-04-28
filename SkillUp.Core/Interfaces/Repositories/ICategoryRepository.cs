using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {

        Task<Category?> GetByIdsAsync(Guid Id);
        Task<Category> Addasync(Category category);
        Task GetByIdsAsync(object id);
    }
}
