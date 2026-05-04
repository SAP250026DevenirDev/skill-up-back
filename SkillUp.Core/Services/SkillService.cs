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

        /// <summary>
        /// Creates a new skill asynchronously.
        /// </summary>
        /// <param name="skill">The skill entity to be created. Must not be null.</param>
        /// <returns>The created skill entity.</returns>
        /// <exception cref="ArgumentException">Thrown when the skill parameter is null.</exception>
        public async Task<Skill> CreateAsync(Skill skill)
        {
            if(skill == null)
            {
                throw new ArgumentException("Skill cannot be null.");
            }
            return await _skillsRepository.CreateAsync(skill);
        }
    }
}
