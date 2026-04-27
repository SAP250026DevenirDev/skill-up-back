using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SkillUp.Security.Services
{
    public class AuthService(
        IUserRepository _userRepository,
        IJwtService _jwtService) : IAuthService
    {
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Email or password is not correct");
            }

            //Hashage mot de passe à faire
            bool isPasswordOk = _passwordHasherService.VerifyPasswordAsync(password, user.HashedPassword);
            if (!isPasswordOk)
            {
                throw new UnauthorizedAccessException("Email or password is not correct");
            }
            return user;


        }
    }
}
