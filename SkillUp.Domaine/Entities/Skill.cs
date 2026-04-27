namespace SkillUp.Domaine.Entities;

public class Skill
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public string Description { get; set; } = string.Empty;
  
  public Guid CategoryId { get; set; }
  public virtual Category Category { get; set; } = null!;

  public virtual ICollection<Evaluate> Evaluations { get; set; } = new List<Evaluate>();
  public virtual ICollection<Mentoring> Mentorings { get; set; } = new List<Mentoring>();
}