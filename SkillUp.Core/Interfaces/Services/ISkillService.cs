using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Services
{
    public interface ISkillService
    {
        Skill Create(Skill skill);
    }
}
