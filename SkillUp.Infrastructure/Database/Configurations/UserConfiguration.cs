using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;

namespace SkillUp.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.Property(u => u.FirstName)
      .IsRequired();

    builder.Property(u => u.LastName)
      .IsRequired();

    builder.Property(u => u.Email)
      .IsRequired();

    builder.Property(u => u.HashedPassword)
      .IsRequired();

    builder.Property(u => u.Role)
      .IsRequired();

    builder.HasKey(u => u.Id);
    builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
    builder.HasIndex(u => u.Email).IsUnique();
  }
}