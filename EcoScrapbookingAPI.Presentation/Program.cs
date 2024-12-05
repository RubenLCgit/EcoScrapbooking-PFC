using System.Text;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Business.Services;
using EcoScrapbookingAPI.Data.Context;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Data.Repositories;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Abstracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy("MyPolicy",
  policyBuilder =>
  {
    policyBuilder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
  });
});

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
builder.Services.AddScoped<IRepositoryGeneric<Publication>, PublicationRepository>();
builder.Services.AddScoped<IRepositoryGeneric<Transaction>, TransactionRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ISustainableActivityService, SustainableActivityService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITutorialService, TutorialService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IPublicationService, PublicationService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var key = builder.Configuration["JwtSettings:SecretKey"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ClockSkew = TimeSpan.Zero
      };
    });


builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo { Title = "EcoScrapbooking API", Version = "v1" });

  var securitySchema = new OpenApiSecurityScheme
  {
    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT",
    Reference = new OpenApiReference
    {
      Type = ReferenceType.SecurityScheme,
      Id = "Bearer"
    }
  };

  options.AddSecurityDefinition("Bearer", securitySchema);

  var securityRequirement = new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    };

  options.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Delete if the API is in Docker
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();