
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Dtos.Responses;
using SkillUp.Core.Services.Data;
using SkillUp.Domaine.Entities;
using SkillUp.API.Mappers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    [HttpPost]
    //[Authorize(Roles = "Administrator")]
    public async Task<IActionResult> AddCategory(AddCategoryRequestDto dto)
    {
        var category = dto.ToModel();

        await _categoryService.AddAsync(category);

        var response = new AddCategoryResponsesDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return CreatedAtAction(nameof(AddCategory), new { id = category.Id }, response);
    }
}