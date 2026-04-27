using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.Domaine.Entities;
using SkillUp.Domaine.Enums;

namespace SkillUp.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public static readonly Guid UserJeanId = Guid.Parse("e1f2a3b4-c5d6-4e7f-8a9b-0c1d2e3f4a5b");
  public static readonly Guid UserAliceId = Guid.Parse("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c");

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

    builder.HasData(
      new User
      {
        Id = UserJeanId, FirstName = "Jean", LastName = "Mentor", Email = "jean@skillup.com",
        HashedPassword = "hash", Role = Roles.Collaborator, IsActive = true,
        CreatedAt = new DateTime(2026, 1, 1), UpdatedAt = new DateTime(2026, 1, 1)
      },
      new User
      {
        Id = UserAliceId, FirstName = "Alice", LastName = "Collab", Email = "alice@skillup.com",
        HashedPassword = "hash", Role = Roles.Collaborator, IsActive = true,
        CreatedAt = new DateTime(2026, 1, 1), UpdatedAt = new DateTime(2026, 1, 1)
      });
  }
}