using SkillUp.API.Dtos.Requests;
using SkillUp.Domaine.Entities;

namespace SkillUp.API.Mappers
{
    public static class SkillMapper
    {
        public static Skill ToModel(this SkillRequestDto dto)
        {
            return new Skill()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
            };
        }
    }
}
