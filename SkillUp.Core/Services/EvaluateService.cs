using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Services;

public class EvaluateService(IEvaluateRepository _evaluateRepository) : IEvaluateService
{
    /// <summary>
    /// Ajoute une skill au profil du collaborateur.
    /// Lance InvalidOperationException si la skill est déjà dans son profil.
    /// </summary>

    public async Task<Evaluate> AddSkillToProfileAsync(Guid userId, Guid SkillId, int level)
{
    if (await _evaluateRepository.ExistAsync(userId, SkillId))
        throw new InvalidOperationException("Cette compétence est déjà dans votre profil.");

    var evaluate = new Evaluate
    {
        UserId = userId,
        SkillId = SkillId,
        Level = level,
        LastUpdate = DateTime.UtcNow
    };
    return await _evaluateRepository.AddAsync(evaluate);
}
}
