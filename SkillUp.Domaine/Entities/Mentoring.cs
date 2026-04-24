using SkillUp.Domaine.Enums;

namespace SkillUp.Domaine.Entities;

public class Mentoring
{
  public required MentoringStatus Type { get; set; }
  public DateTime CreatedAt { get; set; }
}