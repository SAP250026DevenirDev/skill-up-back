using System;
using System.Collections.Generic;
using System.Text;
using SkillUp.Domaine.Entities;

namespace SkillUp.Core.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string email, string password);
        Task<User?> RegisterAsync(string email, string FirstName, string LastName, string Role);
    }
}
