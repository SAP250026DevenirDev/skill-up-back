using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Services.Data;

public interface ICategoryService
{
    Task AddAsync (Category category);

}
