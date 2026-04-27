namespace SkillUp.Domaine.Entities;

public class Skill
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public string Description { get; set; } = string.Empty;
  
<<<<<<< HEAD
  public Guid CategoryId { get; set; }
  public virtual Category Category { get; set; } = null!;
=======
  public int CategoryId { get; set; }
  public virtual required Category Category { get; set; }
>>>>>>> 17aa230 (feat: add nav and fk to entities)

  public virtual ICollection<Evaluate> Evaluations { get; set; } = new List<Evaluate>();
  public virtual ICollection<Mentoring> Mentorings { get; set; } = new List<Mentoring>();
}