using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillsRepository _skillsRepository;

        public SkillService(ISkillsRepository skillsRepository)
        {
            _skillsRepository = skillsRepository;   
        }
        public Skill Create(Skill skill)
        {
            return _skillsRepository.Create(skill);
        }
    }
}
