namespace SkillUp.Domaine.Entities;

public class Skill
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public string Description { get; set; } = string.Empty;
  
  public int CategoryId { get; set; }
  public virtual required Category Category { get; set; }

  public virtual ICollection<Evaluate> Evaluations { get; set; } = new List<Evaluate>();
  public virtual ICollection<Mentoring> Mentorings { get; set; } = new List<Mentoring>();
}