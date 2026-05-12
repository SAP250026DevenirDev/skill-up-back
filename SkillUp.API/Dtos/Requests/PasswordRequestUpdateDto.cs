using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests
{
    public class PasswordRequestUpdateDto
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(4, ErrorMessage = "New password must be at least 4 characters.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
