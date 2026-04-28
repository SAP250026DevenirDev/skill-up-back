using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillUp.Core.Interfaces.Services.Auth;
using SkillUp.Core.Interfaces.Services.Tools;
using SkillUp.Security.Services.Auth;
using SkillUp.Security.Services.Tools;
using SkillUp.Security.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Security.Extensions
{
    public static class SecuServiceExtension
    {
        public static void AddSecurityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>();
            services.AddSingleton(jwtSettings);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
