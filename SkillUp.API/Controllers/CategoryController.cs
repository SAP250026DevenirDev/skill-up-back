using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.API.Dtos.Requests;
using SkillUp.API.Mappers;
using SkillUp.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    /// <summary>
    /// Crée une nouvelle catégorie.
    /// POST api/category
    /// Retourne 200 OK avec la catégorie créée,
    /// 400 BadRequest si les données sont invalides,
    /// 409 Conflict si la catégorie existe déjà,
    /// 500 en cas d'erreur inattendue.
    /// </summary>

    [HttpPost]
    [Authorize(Roles = "Administrator")]
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
    /// <summary>
    /// Met à jour une catégorie existante.
    /// PATCH api/category/{id}
    /// Retourne 200 OK avec la catégorie mise à jour,
    /// 400 BadRequest si les données sont invalides,
    /// 404 NotFound si la catégorie n'existe pas,
    /// 500 en cas d'erreur inattendue.
    /// </summary>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryRequestDto dto)
    {
        try
        {
            var category = CategoryMapper.ToModel(dto);

            var updated = await _categoryService.UpdateAsync(id, category);

            var response = CategoryMapper.ToDto(updated!, true);

            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Category with id {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
        }
    }
    /// <summary>
    /// Récupère toutes les catégories.
    /// GET api/category
    /// Retourne 200 OK avec la liste des catégories.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
        }
    }
    /// <summary>
    /// Récupère une catégorie par son identifiant.
    /// </summary>
    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound($"Category with id {id} not found");
            return Ok(CategoryMapper.ToDto(category));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
        }
    }
    /// <summary>
    /// Supprime une catégorie existante.
    /// DELETE api/category/{id}
    /// Retourne 204 NoContent si supprimée,
    /// 404 NotFound si la catégorie n'existe pas,
    /// 500 en cas d'erreur inattendue.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Category with id {id} not found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
        }
    }
}