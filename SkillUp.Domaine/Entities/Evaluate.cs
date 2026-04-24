namespace SkillUp.Domaine.Entities;

public class Evaluate
{
  public required int Level { get; set; }
  public string Comment { get; set; } = string.Empty;
  
  public int UserId { get; set; }
  public virtual User User { get; set; } = null!;

  public int SkillId { get; set; }
  public virtual Skill Skill { get; set; } = null!;

  
  public DateTime LastUpdate { get; set; }
  
}