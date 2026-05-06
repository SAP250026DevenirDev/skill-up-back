using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Mappers;
using SkillUp.Core.Services.Data;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{

    [HttpPost]
    //[Authorize(Roles = "Administrator")]
    public async Task<IActionResult> AddCategory(AddCategoryRequestDto dto)
    {
        try
        {
            var category = CategoryMapper.ToModel(dto);

            await _categoryService.AddAsync(category);

            var response = CategoryMapper.ToDto(category);

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            // ArgumentNullException et ArgumentException → 400
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            // Catégorie déjà existante → 409
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            // Erreur inattendue (ex: DB inaccessible) → 500
            return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
        }
    }
}