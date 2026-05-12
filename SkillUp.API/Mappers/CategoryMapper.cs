using SkillUp.API.Dtos.Requests;
using SkillUp.API.Dtos.Responses;
using SkillUp.Domaine.Entities;
using System;

namespace SkillUp.API.Mappers;

public static class CategoryMapper
{

    public static Category ToModel(this AddCategoryRequestDto dto)
    {
        return new Category()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
        };
    }

    public static AddCategoryResponsesDto ToDto(this Category category)
    {
        return new AddCategoryResponsesDto()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
        };
    }

    public static Category ToModel(this UpdateCategoryRequestDto dto)
    {
        return new Category()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
        };
    }

    public static UpdateCategoryResponseDto ToDto(this Category category, bool isUpdate)
    {
        return new UpdateCategoryResponseDto()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
        };
    }
}

