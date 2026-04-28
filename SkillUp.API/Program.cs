using Scalar.AspNetCore;

using Microsoft.EntityFrameworkCore;
using SkillUp.Infrastructure.Database.Context;
using SkillUp.Core.Interfaces.Repositories;
using SkillUp.Infrastructure.Repositories;
using SkillUp.Core.Services.Data;
using SkillUp.Core.Interfaces.Services.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<SkillUpDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
