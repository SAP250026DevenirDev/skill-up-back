using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Repositories
{
    public interface ISkillsRepository
    {
        Task<Skill> CreateAsync(Skill skill);
    }
}
