using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Core.Interfaces.Services.Tools
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string storedPassword);
    }
}
