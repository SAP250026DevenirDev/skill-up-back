using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests;

public class AddCategoryRequestDto
{
    [Required(ErrorMessage = "the name of the category is needed")]

    [MinLength (3)][MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(500)]
    public string? Description { get; set; }
}
