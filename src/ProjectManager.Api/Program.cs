global using ProjectManager.Api.Models;
global using ProjectManager.Api.Data;
global using ProjectManager.Api.Models.Dto;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Api;
using ProjectManager.Api.Services.ProjectService;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjectManagerDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectManagerDb")));
builder.Services.AddScoped<IProjectService,ProjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();