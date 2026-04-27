using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Configurations;

public class EvaluateConfiguration : IEntityTypeConfiguration<Evaluate>
{
  public void Configure(EntityTypeBuilder<Evaluate> builder)
  {
    builder.HasKey(e => new { e.UserId, e.SkillId });

    builder.Property(e => e.Level)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(e => e.Comment)
      .HasMaxLength(500);

    builder.Property(e => e.LastUpdate)
      .IsRequired();

    builder.HasOne(e => e.User)
      .WithMany(u => u.Evaluations)
      .HasForeignKey(e => e.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(e => e.Skill)
      .WithMany(s => s.Evaluations)
      .HasForeignKey(e => e.SkillId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasData(
      new Evaluate
      {
        UserId = UserConfiguration.UserJeanId,
        SkillId = SkillConfiguration.SkillCSharpId,
        Level = 5, LastUpdate = new DateTime(2026, 4, 20)
      },
      new Evaluate
      {
        UserId = UserConfiguration.UserAliceId,
        SkillId = SkillConfiguration.SkillCSharpId,
        Level = 1, LastUpdate = new DateTime(2026, 4, 20)
      });
  }
}