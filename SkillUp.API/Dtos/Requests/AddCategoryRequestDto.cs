using System.ComponentModel.DataAnnotations;

namespace SkillUp.API.Dtos.Requests;

public class AddCategoryRequestDto
{
    [Required(ErrorMessage = "the name of the category is needed")]
    public  string Name { get; set; }
    public string? Description { get; set; }
}
