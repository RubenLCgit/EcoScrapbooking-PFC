using Microsoft.EntityFrameworkCore;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Abstracts;
using System;

namespace EcoScrapbookingAPI.Data.Context
{
  public class EcoScrapbookingDBContext : DbContext
  {
    public EcoScrapbookingDBContext(DbContextOptions<EcoScrapbookingDBContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Publication> Publications { get; set; }

    public DbSet<Project> Projects { get; set; }
    public DbSet<SustainableActivity> SustainableActivities { get; set; }
    public DbSet<Tutorial> Tutorials { get; set; }

    public DbSet<Tool> Tools { get; set; }
    public DbSet<Material> Materials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Configuración de la herencia para Activity (TPH)
      modelBuilder.Entity<Activity>()
          .HasDiscriminator<string>("ActivityType")
          .HasValue<Project>("Project")
          .HasValue<SustainableActivity>("SustainableActivity")
          .HasValue<Tutorial>("Tutorial");

      // Configuración de la herencia para Resource (TPH)
      modelBuilder.Entity<Resource>()
          .HasDiscriminator<string>("ResourceType")
          .HasValue<Tool>("Tool")
          .HasValue<Material>("Material");

      // Configuración de índice único para Email
      modelBuilder.Entity<User>()
          .HasIndex(u => u.Email)
          .IsUnique();

      // Semilla de datos para Users
      modelBuilder.Entity<User>().HasData(
          new User
          {
            UserId = 1,
            Role = "Admin",
            Name = "Juan",
            Lastname = "Pérez",
            Email = "juan.perez@example.com",
            Password = "$2a$12$KIX9sQw9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAe", // Hash de "Contraseña1"
            Gender = "Masculino",
            BirthDate = new DateTime(1985, 5, 20),
            RegistrationDate = new DateTime(2023, 1, 10),
            IsActive = true,
            GreenPoints = 250.00m
          },
          new User
          {
            UserId = 2,
            Role = "User",
            Name = "María",
            Lastname = "Gómez",
            Email = "maria.gomez@example.com",
            Password = "$2a$12$7Hj3Lr9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAf", // Hash de "Contraseña2"
            Gender = "Femenino",
            BirthDate = new DateTime(1990, 8, 15),
            RegistrationDate = new DateTime(2023, 2, 5),
            IsActive = true,
            GreenPoints = 180.50m
          },
          new User
          {
            UserId = 3,
            Role = "User",
            Name = "Carlos",
            Lastname = "López",
            Email = "carlos.lopez@example.com",
            Password = "$2a$12$9Hk4Ms8k1m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAg", // Hash de "Contraseña3"
            Gender = "Masculino",
            BirthDate = new DateTime(1992, 12, 1),
            RegistrationDate = new DateTime(2023, 3, 12),
            IsActive = true,
            GreenPoints = 300.75m
          }
      );

      // Semilla de datos para Addresses
      modelBuilder.Entity<Address>().HasData(
          new Address
          {
            AddressId = 1,
            Street = "Calle Falsa",
            Number = "123",
            City = "CiudadA",
            State = "EstadoA",
            Country = "PaísA",
            ZipCode = "10001",
            Description = "Residencia Principal",
            ContactPhone = "555-1234",
            UserId = 1,
            SustainableActivityId = null
          },
          new Address
          {
            AddressId = 2,
            Street = "Avenida Siempre Viva",
            Number = "742",
            City = "CiudadB",
            State = "EstadoB",
            Country = "PaísB",
            ZipCode = "20002",
            Description = "Oficina",
            ContactPhone = "555-5678",
            UserId = 2,
            SustainableActivityId = null
          },
          new Address
          {
            AddressId = 3,
            Street = "Boulevard de los Sueños",
            Number = "456",
            City = "CiudadC",
            State = "EstadoC",
            Country = "PaísC",
            ZipCode = "30003",
            Description = "Lugar de Eventos",
            ContactPhone = "555-9012",
            UserId = 3,
            SustainableActivityId = null
          }
      );

      // Semilla de datos para Tools
      modelBuilder.Entity<Tool>().HasData(
          new Tool
          {
            ResourceId = 1,
            Name = "Pala",
            Type = "Jardinería",
            Brand = "HerramientasPro",
            Quantity = 10,
            Description = "Pala resistente para jardinería.",
            Condition = "Nueva",
            Warranty = true,
            OwnerUserId = 1,
            ActivityId = null
          },
          new Tool
          {
            ResourceId = 2,
            Name = "Rastrillo",
            Type = "Jardinería",
            Brand = "GardenMaster",
            Quantity = 5,
            Description = "Rastrillo de alta calidad.",
            Condition = "Usada",
            Warranty = false,
            OwnerUserId = 2,
            ActivityId = null
          }
      );

      // Semilla de datos para Materials
      modelBuilder.Entity<Material>().HasData(
          new Material
          {
            ResourceId = 3,
            Name = "Compost",
            Type = "Orgánico",
            Brand = "EcoSustentable",
            Quantity = 50,
            Description = "Compost rico en nutrientes.",
            duration = 30,
            OwnerUserId = 3,
            ActivityId = null
          }
      );

      // Semilla de datos para Publications
      modelBuilder.Entity<Publication>().HasData(
          new Publication
          {
            PublicationID = 1,
            Category = "Reciclaje",
            Title = "Consejos para Reciclar",
            Description = "Métodos efectivos para reciclar en casa.",
            ReplyPostID = null
          },
          new Publication
          {
            PublicationID = 2,
            Category = "Jardinería",
            Title = "Plantando Árboles",
            Description = "Cómo y dónde plantar árboles.",
            ReplyPostID = null
          },
          new Publication
          {
            PublicationID = 3,
            Category = "Jardinería",
            Title = "Respuesta: Plantando Árboles",
            Description = "¡Me encantaría participar!",
            ReplyPostID = 2
          }
      );

      // Semilla de datos para Transactions
      modelBuilder.Entity<Transaction>().HasData(
          new Transaction
          {
            TransactionID = 1,
            Quantity = 2,
            Date = new DateTime(2023, 4, 10),
            OldOwnerUserID = 1,
            NewOwnerUserID = 2,
            ResourceID = 1
          },
          new Transaction
          {
            TransactionID = 2,
            Quantity = 1,
            Date = new DateTime(2023, 5, 15),
            OldOwnerUserID = 2,
            NewOwnerUserID = 3,
            ResourceID = 2
          }
      );

      // Semilla de datos para Projects
      modelBuilder.Entity<Project>().HasData(
          new Project
          {
            ActivityId = 1,
            Title = "Huerto Comunitario",
            Description = "Creación y mantenimiento de un huerto comunitario.",
            MaxParticipants = 25,
            StartDate = new DateTime(2024, 1, 5),
            FinishDate = new DateTime(2024, 6, 5),
            IsActive = true,
            GreenPointsValue = 100.0m,
            ProjectType = "Agricultura Urbana",
            CreatorUserId = 1 // Renombrado
          }
      );

      // Semilla de datos para SustainableActivities
      modelBuilder.Entity<SustainableActivity>().HasData(
          new SustainableActivity
          {
            ActivityId = 2,
            Title = "Limpieza de Playa",
            Description = "Organización de jornadas para limpiar la playa local.",
            MaxParticipants = 40,
            StartDate = new DateTime(2024, 2, 10),
            FinishDate = new DateTime(2024, 2, 10),
            IsActive = true,
            GreenPointsValue = 75.0m,
            NameCollaborator = "ONG Verde",
            CreatorUserId = 2 // Renombrado
          }
      );

      // Semilla de datos para Tutorials
      modelBuilder.Entity<Tutorial>().HasData(
          new Tutorial
          {
            ActivityId = 3,
            Title = "Compostaje Casero",
            Description = "Guía para hacer compost en casa.",
            MaxParticipants = 20,
            StartDate = new DateTime(2024, 3, 15),
            FinishDate = new DateTime(2024, 3, 16),
            IsActive = true,
            GreenPointsValue = 50.0m,
            Duration = 3, // Duración en horas
            CreatorUserId = 3 // Renombrado
          }
      );

      // Configuración de tipos de datos para decimales
      modelBuilder.Entity<User>()
          .Property(u => u.GreenPoints)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<Project>()
          .Property(p => p.GreenPointsValue)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<SustainableActivity>()
          .Property(sa => sa.GreenPointsValue)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<Tutorial>()
          .Property(t => t.GreenPointsValue)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<Transaction>()
          .Property(t => t.Quantity)
          .IsRequired();

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // Si estás utilizando inyección de dependencias, puedes dejar este método vacío
      // Si no, configura la cadena de conexión aquí
      // Ejemplo sin DI:
      // if (!optionsBuilder.IsConfigured)
      // {
      //     optionsBuilder.UseSqlServer("Your_Connection_String_Here");
      // }
    }
  }
}
