using SkillUp.API.Dtos.Requests;
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

    /// <summary>
    /// Transforme le DTO reçu par l'API en entité User pour le domaine.
    /// </summary>
    /// <param name="dto">Le DTO de création envoyé par l'admin.</param>
    /// <returns>Une instance de User prête à être traitée par le service.</returns>
    public static User ToEntity(this CreateUserRequestDto dto)
    {
      return new User
      {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        Role = dto.Role,
        HashedPassword = "To_Be_Hashed",
        // pas de Password ici, il sera haché dans la couche Security avant d'être mis dans HashedPassword
      };
    }
  }
}