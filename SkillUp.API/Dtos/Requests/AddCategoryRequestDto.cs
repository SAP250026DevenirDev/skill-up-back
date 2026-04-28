using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests;

public class AddCategoryRequestDto
{
    [Required(ErrorMessage = "the name of the category is needed")]
    public string CategoryName { get; set; } = null!;
    public string? CategoryDescription { get; set; }
}
