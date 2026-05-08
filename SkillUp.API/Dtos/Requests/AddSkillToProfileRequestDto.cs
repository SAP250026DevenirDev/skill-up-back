using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests
{
    public class AddSkillToProfileRequestDto
    {
        [Required]
        public Guid SkillId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Level must be between 1 and 5.")]
        public int Level { get; set; }


    }
}
