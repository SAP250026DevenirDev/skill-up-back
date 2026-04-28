using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests
{
    public class SkillRequestDto
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public Guid CategoryId { get; set; }
    }
}
