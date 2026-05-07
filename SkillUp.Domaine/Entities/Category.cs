using SkillUp.Domaine.Enums;

namespace SkillUp.Domaine.Entities;

public class Category
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }

  public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}