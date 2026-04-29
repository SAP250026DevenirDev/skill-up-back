namespace SkillUp.API.Extensions
{
    public static class CorsExpencyExtensions
    {
        public static void ConfigurePolicyCors(this IServiceCollection services, IConfiguration configuration)
        {
            var AllowedOrigin = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ??
                throw new InvalidOperationException("L'origine n'existe pas");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins(AllowedOrigin ?? Array.Empty<string>())
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials();
                });
            });
        }
    }
}
