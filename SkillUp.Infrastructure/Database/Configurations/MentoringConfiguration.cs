using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;

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
      .OnDelete(DeleteBehavior.Restrict);
    
    builder.HasOne(m => m.Skill)
      .WithMany(s => s.Mentorings)
      .HasForeignKey(m => m.SkillId);
  }
}