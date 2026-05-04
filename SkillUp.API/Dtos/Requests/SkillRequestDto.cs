using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests
{
    public class SkillCreateRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public required string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
