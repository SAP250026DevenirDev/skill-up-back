using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Security.Services
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        public async Task<User> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
