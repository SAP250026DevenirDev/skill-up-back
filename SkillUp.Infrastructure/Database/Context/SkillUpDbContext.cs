using Microsoft.EntityFrameworkCore;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Context;

public class SkillUpDbContext(DbContextOptions<SkillUpDbContext> options) : DbContext(options)
{
  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Evaluate> Evaluates { get; set; } = null!;
  public DbSet<Mentoring> Mentorings { get; set; } = null!;
  public DbSet<Skill> Skills { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillUpDbContext).Assembly);
    
  }
  
  
}