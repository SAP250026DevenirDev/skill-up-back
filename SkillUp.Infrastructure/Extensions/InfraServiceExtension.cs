using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Core.Services;
using SkillUp.Infrastructure.Database.Context;
using SkillUp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillUp.Infrastructure.Extensions
{
    public static class InfraServiceExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SkillUpDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            // Add Skill
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();

        }
    }
}
