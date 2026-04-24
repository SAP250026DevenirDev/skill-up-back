using SkillUp.Domaine.Enums;

namespace SkillUp.Domaine.Entities;

public class Mentoring
{
  public required MentoringStatus Type { get; set; }
  public DateTime CreatedAt { get; set; }
  
  public int MentorId { get; set; }
  public  virtual User Mentor { get; set; } = null!;

  public int CollaboratorId { get; set; }
  public virtual User Collaborator { get; set; } = null!;

  public int SkillId { get; set; }
  public virtual Skill Skill { get; set; } = null!;
}