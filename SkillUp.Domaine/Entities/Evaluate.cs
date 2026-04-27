namespace SkillUp.Domaine.Entities;

public class Evaluate
{
  public required int Level { get; set; }
  public string Comment { get; set; } = string.Empty;
<<<<<<< HEAD
  
  public Guid UserId { get; set; }
  public virtual User User { get; set; } = null!;

  public Guid SkillId { get; set; }
=======
  public int UserId { get; set; }
  public virtual User User { get; set; } = null!;

  public int SkillId { get; set; }
>>>>>>> 17aa230 (feat: add nav and fk to entities)
  public virtual Skill Skill { get; set; } = null!;

  
  public DateTime LastUpdate { get; set; }
  
}