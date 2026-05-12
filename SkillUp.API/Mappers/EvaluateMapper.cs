// SkillUp.API/Mappers/EvaluateMapper.cs
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Dtos.Responses;
using SkillUp.Domaine.Entities;

namespace SkillUp.API.Mappers;

public static class EvaluateMapper
{
    /// <summary>
    /// Convertit un AddSkillToProfileRequestDto en entité Evaluate
    /// avec le UserId du collaborateur connecté et la date du jour.
    /// </summary>
    public static Evaluate ToModel(this AddSkillToProfileRequestDto dto, Guid userId)
    {
        return new Evaluate
        {
            UserId = userId,
            SkillId = dto.SkillId,
            Level = dto.Level,
            LastUpdate = DateTime.UtcNow,
        };
    }

    /// <summary>
    /// Convertit une entité Evaluate en AddSkillToProfileResponseDto.
    /// Nécessite que les navigations Skill et Skill.Category soient chargées.
    /// </summary>
    public static AddSkillToProfileResponseDto ToDto(this Evaluate evaluate)
    {
        return new AddSkillToProfileResponseDto
        {
            SkillId = evaluate.SkillId,
            SkillName = evaluate.Skill.Name,
            CategoryName = evaluate.Skill.Category.Name,
            Level = evaluate.Level,
            LastUpdate = evaluate.LastUpdate
        };
    }
}