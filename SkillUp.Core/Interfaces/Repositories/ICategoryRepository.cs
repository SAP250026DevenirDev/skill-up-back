using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<Guid> ids);
    }
}
