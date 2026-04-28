using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SkillUp.Infrastructure.Database.Context;
using SkillUp.Core.Interfaces.Services;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Infrastructure.Repositories;
using SkillUp.Core.Services;
using SkillUp.Infrastructure.Extensions;
using SkillUp.Security.Extensions;


using SkillUp.Core.Services.Data;
using SkillUp.Core.Interfaces.Services.Data;

var builder = WebApplication.CreateBuilder(args);

//PasswordHasherService hasher = new PasswordHasherService();
//Console.WriteLine("Jean: " + hasher.HashPassword("hash"));
//Console.WriteLine("Alice: " + hasher.HashPassword("hash"));
//Console.WriteLine("Admin: " + hasher.HashPassword("hash"));

//scopes
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSecurityServices(builder.Configuration);

// Add Skill
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();

//Add Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();



// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
