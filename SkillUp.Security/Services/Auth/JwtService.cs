using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkillUp.Security.Services.Auth
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
        public string GenerateToken(User user)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"]!;
            var expiration = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpirationMinutes"] ?? "30"));


            
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("role", user.Role.ToString() ?? "User"),
            new Claim("isPasswordChanged", user.IsPasswordChanged.ToString()), // ajout de isPasswordChanged pour premier login
            new Claim("isActive", user.IsActive.ToString()) 
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // string

            /* Différence avec le token qu'on a toujours utilisé:
             * 
             * LA VERSION ANCIENNE à la fin retourne
             * return Task.FromResult(new LoginResponseDto
                {
                    Token = tokenString,
                    Expiration = expiration
                });
             * ça veut dire qu'elle emballe le string token dans un objet DTO avec l'expiration
             * 
             * LA NOUVELLE VERSION à la fin retourne
             * 
             * return new JwtSecurityTokenHandler().WriteToken(token);
             * 
             * ça veut dire qu'elle retourne directement le string du token
             * et l'expiration est dans le token 
             * 
             */
        }
    }
}
    

