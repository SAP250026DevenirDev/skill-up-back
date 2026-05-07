using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SkillUp.Security.Services.Auth
{
    public class AuthService(
        IUserRepository _userRepository,
        IJwtService _jwtService,
        IPasswordHasherService _passwordHasherService) : IAuthService
    {
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("The email/password is not correct");
            }

            if (!user.IsActive)
            {
                throw new UnauthorizedAccessException("Compte désactivé");
            }


            bool isPasswordOk = _passwordHasherService.VerifyPassword(password, user.HashedPassword);
            if (!isPasswordOk)
            {
                throw new UnauthorizedAccessException("The email/password is not correct");
            }
            return user;


        }
    }
}
