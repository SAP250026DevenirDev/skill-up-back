using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public static readonly Guid CatDevId = Guid.Parse("37a5b39e-8c6c-4f7f-871d-6b5d9e5b5f5a");
  public static readonly Guid CatSoftId = Guid.Parse("a2d8e4c1-4b1a-4d9a-9e1a-5f1e8a9d1c2b");
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.HasKey(c => c.Id);

    builder.Property(c => c.Name).IsRequired()
      .HasColumnType("nvarchar")
      .HasMaxLength(100);
    builder.Property(c => c.Description)
      .HasColumnType("nvarchar")
      .HasMaxLength(500);
    
    builder.HasData(
      new Category { Id = CatDevId , Name = "Développement", Description = "Langages et frameworks" },
      new Category { Id = CatSoftId , Name = "Soft Skills", Description = "Communication et leadership" });
  }
}