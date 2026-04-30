using SkillUp.Domaine.Enums;

namespace SkillUp.Domaine.Entities;

public class Mentoring
{

  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  
  public MentoringStatus Status { get; set; }
  
  public Guid MentorId { get; set; }
  public  virtual User Mentor { get; set; } = null!;

  public Guid CollaboratorId { get; set; }
  public virtual User Collaborator { get; set; } = null!;

  public Guid SkillId { get; set; }
  public virtual Skill Skill { get; set; } = null!;

}