using SkillUp.API.Dtos.Responses;
using SkillUp.Domaine.Entities;

namespace SkillUp.API.Mappers
{
    public static class UserMapper
    {
        public static UserDisableResponseDto ToDisableResponseDto(this User user)
        {
            return new UserDisableResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                IsActive = user.IsActive,
                UpdatedAt = user.UpdatedAt,
                Message = "Le compte utilisateur a été désactivé."
            };
        }
    }
}
