using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;
using SkillUp.Domaine.Enums;

namespace SkillUp.Infrastructure.Database.Configurations;

public class MentoringConfiguration : IEntityTypeConfiguration<Mentoring>
{
  public void Configure(EntityTypeBuilder<Mentoring> builder)
  {
    builder.HasKey(m => m.Id);
    
    builder.HasOne(m => m.Mentor)
      .WithMany(u => u.MentoringsAsMentor)
      .HasForeignKey(m => m.MentorId)
      .OnDelete(DeleteBehavior.Restrict);
    
    builder.HasOne(m => m.Collaborator)
      .WithMany(u => u.MentoringsAsCollaborator)
      .HasForeignKey(m => m.CollaboratorId)
      .OnDelete(DeleteBehavior.Cascade);
    
    builder.HasOne(m => m.Skill)
      .WithMany(s => s.Mentorings)
      .HasForeignKey(m => m.SkillId);

    builder.HasData(
      new Mentoring
      {
        Id = Guid.Parse("1a2b3c4d-5e6f-4a7b-8c9d-0e1f2a3b4c5d"),
        Status = MentoringStatus.Waiting,
        CreatedAt = new DateTime(2026, 4, 25),
        MentorId = UserConfiguration.UserJeanId,
        CollaboratorId = UserConfiguration.UserAliceId,
        SkillId = SkillConfiguration.SkillCSharpId,
      });
  }
}