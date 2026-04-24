namespace SkillUp.Domaine.Entities;

public class Skill
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public string Description { get; set; } = string.Empty;
}