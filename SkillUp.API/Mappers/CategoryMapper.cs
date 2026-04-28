using SkillUp.API.Dtos.Requests;
using SkillUp.Domaine.Entities;

namespace SkillUp.API.Mappers;

public static class CategoryMapper
{

    public static Category ToModel(this AddCategoryRequestDto dto)
    {
        return new Category()
        {
            Id = Guid.NewGuid(),
            Name = dto.CategoryName,
            Description = dto.CategoryDescription,
        };
    }
}

