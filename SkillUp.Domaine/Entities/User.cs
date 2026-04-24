using SkillUp.Domaine.Enums;

namespace SkillUp.Domaine.Entities;

public class User
{
  public Guid Id { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required string HashedPassword { get; set; }
  public required Roles Role { get; set; }
  public required string Email { get; set; }
  public bool IsPasswordChanged { get; set; }
  public bool IsActive { get; set; }
  
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  
  
  public virtual ICollection<Evaluate> Evaluations { get; set; } = new List<Evaluate>();
  
  public virtual ICollection<Mentoring> MentoringsAsMentor { get; set; } = new List<Mentoring>();
  public virtual ICollection<Mentoring> MentoringsAsCollaborator { get; set; } = new List<Mentoring>();
  
  
}