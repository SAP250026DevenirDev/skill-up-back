
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Dtos.Responses;
using SkillUp.Core.Services.Data;
using SkillUp.Domaine.Entities;

[ApiController]
[Route("api/categories")]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCategory(AddCategoryRequestDto dto)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = dto.CategoryName,
            Description = dto.CategoryDescription ?? string.Empty
        };

        await _categoryService.AddAsync(category);

        var response = new AddCategoryResponsesDto
        {
            Id = category.Id,
            Name = category.Name,
            CategoryDescription = category.Description
        };

        return Ok(response);
    }
}