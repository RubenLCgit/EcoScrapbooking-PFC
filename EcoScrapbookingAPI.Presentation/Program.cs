using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Business.Services;
using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Data.Repositories;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddDbContext<EcoScrapbookingDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerDB_localhost")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<IRepositoryGeneric<User>, UserRepository>();
builder.Services.AddScoped<IRepositoryGeneric<Address>, AddressRepository>();
builder.Services.AddScoped<IRepositoryGeneric<SustainableActivity>, SustainableActivityRepository>();
builder.Services.AddScoped<IRepositoryGeneric<Project>, ProjectRepository>();
builder.Services.AddScoped<IRepositoryGeneric<Tutorial>, TutorialRepository>();
builder.Services.AddScoped<IRepositoryGeneric<Material>, MaterialRepository>();
builder.Services.AddScoped<IRepositoryGeneric<Tool>, ToolRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ISustainableActivityService, SustainableActivityService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITutorialService, TutorialService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IToolService, ToolService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Delete if the API is in Docker
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();