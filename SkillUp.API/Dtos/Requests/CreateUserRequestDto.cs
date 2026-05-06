using System.Text.Json.Serialization;
using SkillUp.Domaine.Enums;

namespace SkillUp.API.Dtos.Requests;

public class CreateUserRequestDto
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  [JsonConverter(typeof(JsonStringEnumConverter))]  // conversion des entiers de l'enum en texte
  public Roles Role { get; set; } = Roles.Collaborator; //ici, j'ajoute un champ role pour que l'admin puisse choisir le role
}