using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
  public static readonly Guid SkillCSharpId = Guid.Parse("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e");
  public static readonly Guid SkillSqlId = Guid.Parse("c1d2e3f4-a5b6-4c7d-8e9f-0a1b2c3d4e5f");

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

    builder.HasData(
      new Skill { Id = SkillCSharpId, Name = "C# / EF Core", CategoryId = CategoryConfiguration.CatDevId },
      new Skill { Id = SkillSqlId , Name = "SQL Server", CategoryId = CategoryConfiguration.CatDevId });
  }
}