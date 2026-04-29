
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


        return Ok(Response);
    }
}