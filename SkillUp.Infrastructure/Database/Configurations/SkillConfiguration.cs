using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
  public void Configure(EntityTypeBuilder<Skill> builder)
  {
    builder.HasKey(s => s.Id);
    
    builder.Property(s => s.Name)
      .IsRequired()
      .HasColumnType("nvarchar");
    
    builder.Property(s => s.Description)
      .HasColumnType("nvarchar");
    
    builder.HasOne(s => s.Category)
      .WithMany(c => c.Skills)
      .HasForeignKey(s => s.CategoryId)
      .OnDelete(DeleteBehavior.Cascade);
    
    builder.ToTable("Skills");
  }
}