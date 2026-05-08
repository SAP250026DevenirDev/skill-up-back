using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Repositories;

public interface IEvaluateRepository
{
    Task<Evaluate> AddAsync(Evaluate evaluate);
    Task<bool> ExistAsync(Guid UserId, Guid skillId);
}
