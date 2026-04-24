using Microsoft.EntityFrameworkCore;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Context;

public class SkillUpDbContext(DbContextOptions<SkillUpDbContext> options) : DbContext(options)
{
  public DbSet<Category> Category { get; set; } = null!;
  public DbSet<Evaluate> Evaluate { get; set; } = null!;
  public DbSet<Mentoring> Mentoring { get; set; } = null!;
  public DbSet<Skill> Skill { get; set; } = null!;
  public DbSet<User> User { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillUpDbContext).Assembly);
  }
}