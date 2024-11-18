using Microsoft.EntityFrameworkCore;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Abstracts;
using Microsoft.Extensions.Logging;
using EcoScrapbookingAPI.Domain.Models.Enums;

namespace EcoScrapbookingAPI.Data.Context
{
  public class EcoScrapbookingDBContext : DbContext
  {
    public EcoScrapbookingDBContext(DbContextOptions<EcoScrapbookingDBContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<SustainableActivity> SustainableActivities { get; set; }
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Material> Materials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      // Inheritance configuration for Activity
      modelBuilder.Entity<Activity>()
          .HasDiscriminator<string>("ActivityType")
          .HasValue<Project>("Project")
          .HasValue<SustainableActivity>("SustainableActivity")
          .HasValue<Tutorial>("Tutorial");

      // Inheritance configuration for Resource
      modelBuilder.Entity<Resource>()
          .HasDiscriminator<string>("ResourceType")
          .HasValue<Tool>("Tool")
          .HasValue<Material>("Material");

      // Single index configuration for Email
      modelBuilder.Entity<User>()
          .HasIndex(u => u.Email)
          .IsUnique();

      // One to Many Relationships: User -> Addresses
      modelBuilder.Entity<User>()
          .HasMany(u => u.Addresses)
          .WithOne(a => a.AddressUser)
          .HasForeignKey(a => a.UserId)
          .OnDelete(DeleteBehavior.NoAction);

      // One to Many Relationships: User -> ActivitiesCreated
      modelBuilder.Entity<User>()
          .HasMany(u => u.ActivitiesCreated)
          .WithOne(a => a.CreatorUser)
          .HasForeignKey(a => a.CreatorUserId)
          .OnDelete(DeleteBehavior.Cascade);

      // Many-to-many relationship: User -> ActivitiesParticipated
      modelBuilder.Entity<User>()
          .HasMany(u => u.ActivitiesParticipated)
          .WithMany(a => a.Participants)
          .UsingEntity<Dictionary<string, object>>(
              "UserActivities",
              j => j.HasOne<Activity>()
                    .WithMany()
                    .HasForeignKey("ActivitiesParticipatedActivityId")
                    .OnDelete(DeleteBehavior.Cascade),
              j => j.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("ParticipantsUserId")
                    .OnDelete(DeleteBehavior.NoAction),
              j =>
              {
                j.HasKey("ActivitiesParticipatedActivityId", "ParticipantsUserId");
                j.ToTable("UserActivities");
              }
          );

      // One to Many Relationships: User -> Resources
      modelBuilder.Entity<User>()
          .HasMany(u => u.Resources)
          .WithOne(r => r.OwnerUser)
          .HasForeignKey(r => r.OwnerUserId)
          .OnDelete(DeleteBehavior.Cascade);

      // One to Many Relationships: User -> Transactions Iniciadas
      modelBuilder.Entity<User>()
          .HasMany(u => u.TransactionsInitiated)
          .WithOne(t => t.InitiatorUser)
          .HasForeignKey(t => t.InitiatorUserID)
          .OnDelete(DeleteBehavior.NoAction);

      // One to Many Relationships: User -> Transactions Recibidas
      modelBuilder.Entity<User>()
          .HasMany(u => u.TransactionsReceived)
          .WithOne(t => t.ReceiverUser)
          .HasForeignKey(t => t.ReceiverUserID)
          .OnDelete(DeleteBehavior.NoAction);

      // One to Many Relationships: User -> Publication
      modelBuilder.Entity<User>()
          .HasMany(u => u.Posts)
          .WithOne(p => p.Author)
          .HasForeignKey(p => p.AuthorId)
          .OnDelete(DeleteBehavior.NoAction);

      // One to Many Relationships: Publication -> Replies
      modelBuilder.Entity<Publication>()
          .HasMany(p => p.Replies)
          .WithOne(p => p.ReplyTo)
          .HasForeignKey(p => p.ReplyPostID)
          .OnDelete(DeleteBehavior.NoAction);

      // One to Many Relationships: Publication -> Activity
      modelBuilder.Entity<Publication>()
          .HasOne(p => p.Activity)
          .WithMany(a => a.Publications)
          .HasForeignKey(p => p.ActivityId)
          .OnDelete(DeleteBehavior.NoAction);

      // One to Many Relationships: Address -> SustainableActivity
      modelBuilder.Entity<Address>()
          .HasMany(a => a.SustainableActivities)
          .WithOne(sa => sa.Ubication)
          .HasForeignKey(sa => sa.AddressId)
          .OnDelete(DeleteBehavior.SetNull);

      // One to Many Relationships: Transaction -> Resources
      modelBuilder.Entity<Transaction>()
          .HasMany(t => t.Resources)
          .WithOne(r => r.Transaction)
          .HasForeignKey(r => r.TransactionId)
          .OnDelete(DeleteBehavior.NoAction);

      // Many-to-many relationship: Activity -> Resources
      modelBuilder.Entity<Activity>()
          .HasMany(a => a.ActivityResources)
          .WithMany(r => r.Activities)
          .UsingEntity<Dictionary<string, object>>(
              "ActivityResources",
              j => j.HasOne<Resource>()
                    .WithMany()
                    .HasForeignKey("ActivityResourcesResourceId")
                    .OnDelete(DeleteBehavior.Restrict),
              j => j.HasOne<Activity>()
                    .WithMany()
                    .HasForeignKey("ActivitiesActivityId")
                    .OnDelete(DeleteBehavior.Cascade),
              j =>
              {
                j.HasKey("ActivitiesActivityId", "ActivityResourcesResourceId");
                j.ToTable("ActivityResources");
              }
          );


      // Data seed for Users
      modelBuilder.Entity<User>().HasData(
          new User
          {
            UserId = 1,
            Role = "Admin",
            AvatarImageUrl = "https://juanito123.com/avatar.jpg",
            Name = "Juan",
            Lastname = "Pérez",
            Nickname = "juanito123",
            Email = "juan.perez@example.com",
            Password = "$2a$12$KIX9sQw9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAe", // Hash "Contraseña1"
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
            AvatarImageUrl = "https://maryg.com/avatar.jpg",
            Name = "María",
            Lastname = "Gómez",
            Nickname = "maryg",
            Email = "maria.gomez@example.com",
            Password = "$2a$12$7Hj3Lr9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAf", // Hash "Contraseña2"
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
            AvatarImageUrl = "https://carlosl.com/avatar.jpg",
            Name = "Carlos",
            Nickname = "carlosl",
            Lastname = "López",
            Email = "carlos.lopez@example.com",
            Password = "$2a$12$9Hk4Ms8k1m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAg", // Hash "Contraseña3"
            Gender = "Masculino",
            BirthDate = new DateTime(1992, 12, 1),
            RegistrationDate = new DateTime(2023, 3, 12),
            IsActive = true,
            GreenPoints = 300.75m
          }
      );

      // Data seed for Addresses
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
          }
      );

      // Data seed for Tools
      modelBuilder.Entity<Tool>().HasData(
          new Tool
          {
            ResourceId = 1,
            TransactionId = 1,
            Name = "Pala",
            Type = "Jardinería",
            Brand = "HerramientasPro",
            Quantity = 10,
            Description = "Pala resistente para jardinería.",
            Condition = "Nueva",
            Warranty = true,
            OwnerUserId = 1,
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
          }
      );

      // Data seed for Materials
      modelBuilder.Entity<Material>().HasData(
          new Material
          {
            ResourceId = 3,
            TransactionId = 2,
            Name = "Papel de muestrario de Pinturas",
            Type = "Reciclaje",
            Brand = "PinturasVerdes",
            Quantity = 50,
            Description = "Papel de muestrario de pinturas para reutilizar.",
            OwnerUserId = 3,
          }
      );

      // Data seed for Publications
      modelBuilder.Entity<Publication>().HasData(
          new Publication
          {
            PublicationID = 1,
            AuthorId = 1,
            CreatedAt = new DateTime(2023, 4, 5, 10, 20, 15),
            Category = "Reciclaje",
            Title = "Consejos para Reciclar",
            Description = "Métodos efectivos para reciclar en casa.",
          },
          new Publication
          {
            PublicationID = 2,
            AuthorId = 2,
            CreatedAt = new DateTime(2023, 4, 8, 12, 15, 30),
            Category = "Jardinería",
            Title = "Plantando Árboles",
            Description = "Cómo y dónde plantar árboles.",
          },
          new Publication
          {
            PublicationID = 3,
            AuthorId = 3,
            CreatedAt = new DateTime(2023, 4, 12, 15, 30, 20),
            Category = "Jardinería",
            Title = "Respuesta: Plantando Árboles",
            Description = "¡Me encantaría participar!",
            ReplyPostID = 2
          },
          new Publication
          {
            PublicationID = 4,
            AuthorId = 1,
            CreatedAt = new DateTime(2023, 4, 15, 10, 30, 45),
            ActivityId = 1,
            Category = "Paso de proyecto",
            Title = "Avance: Caja de recuerdos",
            Description = "Hemos terminado de cortar las piezas.",
            ImagePostUrl = "https://image-post.com"
          }
      );

      // Data seed for Transactions
      modelBuilder.Entity<Transaction>().HasData(
          new Transaction
          {
            TransactionID = 1,
            Type = TransactionType.Exchange,
            Status = TransactionStatus.Completed,
            DateInitiated = new DateTime(2023, 4, 10),
            DateCompleted = new DateTime(2023, 4, 15),
            InitiatorUserID = 1,
            ReceiverUserID = 2,
          },
          new Transaction
          {
            TransactionID = 2,
            Type = TransactionType.Gift,
            Status = TransactionStatus.Pending,
            DateInitiated = new DateTime(2023, 5, 20),
            InitiatorUserID = 2,
            ReceiverUserID = 3,
          }
      );

      // Data seed for Projects
      modelBuilder.Entity<Project>().HasData(
          new Project
          {
            ActivityId = 1,
            Title = "Caja de recuerdos",
            Description = "Creación de una cajita para guardar recuerdos.",
            CreatedAt = new DateTime(2024, 1, 1, 10, 20, 35),
            StartDate = new DateTime(2024, 1, 5),
            FinishDate = new DateTime(2024, 6, 5),
            IsActive = true,
            GreenPointsValue = 100.0m,
            ProjectType = "Manualidades",
            CreatorUserId = 1,
            HomeImageUrl = "https://default-homepage.com",
          }
      );

      // Data seed for SustainableActivities
      modelBuilder.Entity<SustainableActivity>().HasData(
          new SustainableActivity
          {
            ActivityId = 2,
            Title = "Plantación de Árboles",
            Description = "Actividad para plantar árboles en parques.",
            CreatedAt = new DateTime(2024, 2, 1, 10, 10, 12),
            MaxParticipants = 30,
            StartDate = new DateTime(2024, 2, 10),
            FinishDate = new DateTime(2024, 2, 11),
            IsActive = true,
            GreenPointsValue = 75.0m,
            HomeImageUrl = "https://default-homepage.com",
            NameCollaborator = "Parques y Jardines",
            AddressId = 1,
            CreatorUserId = 2
          }
      );

      // Data seed for Tutorials
      modelBuilder.Entity<Tutorial>().HasData(
          new Tutorial
          {
            ActivityId = 3,
            Title = "Pegamento Casero Reciclado",
            Description = "Tutorial para hacer pegamento casero con materiales reciclados.",
            CreatedAt = new DateTime(2024, 3, 1, 10, 15, 20),
            MaxParticipants = 20,
            StartDate = new DateTime(2024, 3, 15),
            FinishDate = new DateTime(2024, 3, 16),
            IsActive = true,
            GreenPointsValue = 50.0m,
            HomeImageUrl = "https://default-homepage.com",
            Duration = 300,
            CreatorUserId = 3
          }
      );

      // Data type settings for decimals
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

      // Data type settings for types and status
      modelBuilder.Entity<Transaction>()
          .Property(t => t.Type)
          .HasConversion<string>();

      modelBuilder.Entity<Transaction>()
          .Property(t => t.Status)
          .HasConversion<string>();

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging();
    }
  }
}
