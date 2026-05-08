using System;

namespace SkillUp.API.Dtos.Responses
{
    public class UpdateCategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}