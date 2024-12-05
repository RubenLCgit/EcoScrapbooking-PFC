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
          Password = BCrypt.Net.BCrypt.HashPassword("password1"),
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
          Password = BCrypt.Net.BCrypt.HashPassword("password2"),
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
          Password = BCrypt.Net.BCrypt.HashPassword("password3"),
          Gender = "Masculino",
          BirthDate = new DateTime(1992, 12, 1),
          RegistrationDate = new DateTime(2023, 3, 12),
          IsActive = true,
          GreenPoints = 300.75m
        },
        new User
        {
          UserId = 4,
          Role = "User",
          AvatarImageUrl = "https://luciaf.com/avatar.jpg",
          Name = "Lucía",
          Lastname = "Fernández",
          Nickname = "luciaf",
          Email = "lucia.fernandez@example.com",
          Password = BCrypt.Net.BCrypt.HashPassword("password4"),
          Gender = "Femenino",
          BirthDate = new DateTime(1988, 7, 22),
          RegistrationDate = new DateTime(2023, 4, 18),
          IsActive = true,
          GreenPoints = 220.00m
        },
        new User
        {
          UserId = 5,
          Role = "User",
          AvatarImageUrl = "https://miguelr.com/avatar.jpg",
          Name = "Miguel",
          Lastname = "Ramírez",
          Nickname = "miguelr",
          Email = "miguel.ramirez@example.com",
          Password = BCrypt.Net.BCrypt.HashPassword("password5"),
          Gender = "Masculino",
          BirthDate = new DateTime(1995, 3, 30),
          RegistrationDate = new DateTime(2023, 5, 25),
          IsActive = true,
          GreenPoints = 190.25m
        },
        new User
        {
          UserId = 6,
          Role = "User",
          AvatarImageUrl = "https://saraq.com/avatar.jpg",
          Name = "Sara",
          Lastname = "Quintero",
          Nickname = "saraq",
          Email = "sara.quintero@example.com",
          Password = BCrypt.Net.BCrypt.HashPassword("password6"),
          Gender = "Femenino",
          BirthDate = new DateTime(1993, 11, 10),
          RegistrationDate = new DateTime(2023, 6, 30),
          IsActive = true,
          GreenPoints = 210.50m
        }
      );

      // Data seed for Addresses
      modelBuilder.Entity<Address>().HasData(
        // Addresses for User 1
        new Address
        {
          AddressId = 1,
          Street = "Calle Falsa",
          Number = "123",
          City = "Madrid",
          State = "Madrid",
          Country = "España",
          ZipCode = "28001",
          Description = "Residencia Principal",
          ContactPhone = "555-1234",
          IsMainDeliveryAddress = true,
          UserId = 1,
        },
        new Address
        {
          AddressId = 2,
          Street = "Avenida Siempre Viva",
          Number = "742",
          City = "Barcelona",
          State = "Cataluña",
          Country = "España",
          ZipCode = "08002",
          Description = "Oficina",
          ContactPhone = "555-5678",
          IsMainDeliveryAddress = false,
          UserId = 1,
        },
        // Addresses for User 2
        new Address
        {
          AddressId = 3,
          Street = "Gran Vía",
          Number = "45",
          City = "Valencia",
          State = "Valencia",
          Country = "España",
          ZipCode = "46001",
          Description = "Residencia Principal",
          ContactPhone = "555-2345",
          IsMainDeliveryAddress = true,
          UserId = 2,
        },
        new Address
        {
          AddressId = 4,
          Street = "Paseo de la Castellana",
          Number = "789",
          City = "Sevilla",
          State = "Andalucía",
          Country = "España",
          ZipCode = "41001",
          Description = "Oficina",
          ContactPhone = "555-6789",
          IsMainDeliveryAddress = false,
          UserId = 2,
        },
        // Addresses for User 3
        new Address
        {
          AddressId = 5,
          Street = "Calle de Alcalá",
          Number = "10",
          City = "Bilbao",
          State = "País Vasco",
          Country = "España",
          ZipCode = "48001",
          Description = "Residencia Principal",
          ContactPhone = "555-3456",
          IsMainDeliveryAddress = true,
          UserId = 3,
        },
        new Address
        {
          AddressId = 6,
          Street = "Ronda de Sant Antoni",
          Number = "321",
          City = "Zaragoza",
          State = "Aragón",
          Country = "España",
          ZipCode = "50001",
          Description = "Oficina",
          ContactPhone = "555-7890",
          IsMainDeliveryAddress = false,
          UserId = 3,
        },
        // Addresses for User 4
        new Address
        {
          AddressId = 7,
          Street = "Calle de las Flores",
          Number = "55",
          City = "Málaga",
          State = "Andalucía",
          Country = "España",
          ZipCode = "29001",
          Description = "Residencia Principal",
          ContactPhone = "555-4567",
          IsMainDeliveryAddress = true,
          UserId = 4,
        },
        new Address
        {
          AddressId = 8,
          Street = "Avenida del Mediterráneo",
          Number = "88",
          City = "Murcia",
          State = "Región de Murcia",
          Country = "España",
          ZipCode = "30001",
          Description = "Taller",
          ContactPhone = "555-8901",
          IsMainDeliveryAddress = false,
          UserId = 4,
        },
        // Addresses for User 5
        new Address
        {
          AddressId = 9,
          Street = "Calle Mayor",
          Number = "200",
          City = "Granada",
          State = "Andalucía",
          Country = "España",
          ZipCode = "18001",
          Description = "Residencia Principal",
          ContactPhone = "555-5678",
          IsMainDeliveryAddress = true,
          UserId = 5,
        },
        new Address
        {
          AddressId = 10,
          Street = "Plaza de España",
          Number = "150",
          City = "Córdoba",
          State = "Andalucía",
          Country = "España",
          ZipCode = "14001",
          Description = "Estudio",
          ContactPhone = "555-9012",
          IsMainDeliveryAddress = false,
          UserId = 5,
        },
        // Addresses for User 6
        new Address
        {
          AddressId = 11,
          Street = "Calle del Sol",
          Number = "77",
          City = "Alicante",
          State = "Comunidad Valenciana",
          Country = "España",
          ZipCode = "03001",
          Description = "Residencia Principal",
          ContactPhone = "555-6789",
          IsMainDeliveryAddress = true,
          UserId = 6,
        },
        new Address
        {
          AddressId = 12,
          Street = "Avenida de la Paz",
          Number = "99",
          City = "Las Palmas",
          State = "Canarias",
          Country = "España",
          ZipCode = "35001",
          Description = "Oficina",
          ContactPhone = "555-0123",
          IsMainDeliveryAddress = false,
          UserId = 6,
        }
      );

      // Data seed for Tools
      modelBuilder.Entity<Tool>().HasData(
        // Tools for User 1
        new Tool
        {
          ResourceId = 1,
          TransactionId = null, // To be assigned in Transactions
          Name = "Tijeras de precisión",
          Type = "Corte",
          Brand = "CraftMaster",
          Quantity = 5,
          Description = "Tijeras ideales para cortes detallados en scrapbooking.",
          ImageResourceUrl = "https://image-tijeras.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 1,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 2,
          TransactionId = null,
          Name = "Cúter",
          Type = "Corte",
          Brand = "SharpEdge",
          Quantity = 3,
          Description = "Cúter de alta precisión para recortes complejos.",
          ImageResourceUrl = "https://image-Cuter.com",
          Condition = "Usada",
          Warranty = false,
          OwnerUserId = 1,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 3,
          TransactionId = 2,
          Name = "Regla metálica",
          Type = "Medición",
          Brand = "MeasurePro",
          Quantity = 10,
          Description = "Regla de 30 cm para medidas exactas.",
          ImageResourceUrl = "https://image-Regla.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 1,
          IsSent = true,
        },
        // Tools for User 2
        new Tool
        {
          ResourceId = 4,
          TransactionId = null,
          Name = "Pegamento en barra",
          Type = "Adhesivo",
          Brand = "GlueIt",
          Quantity = 20,
          Description = "Pegamento en barra sin tóxicos para scrapbooking.",
          ImageResourceUrl = "https://image-Pegamento.com",
          Condition = "Nueva",
          Warranty = false,
          OwnerUserId = 2,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 5,
          TransactionId = null,
          Name = "Pistola de silicona",
          Type = "Adhesivo",
          Brand = "HotGlue",
          Quantity = 2,
          Description = "Pistola de silicona para fijar materiales.",
          ImageResourceUrl = "https://image-Pistola.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 2,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 6,
          TransactionId = null,
          Name = "Cinta adhesiva decorativa",
          Type = "Adhesivo",
          Brand = "DecorTape",
          Quantity = 15,
          Description = "Cinta adhesiva con diseños para decoración.",
          ImageResourceUrl = "https://image-Cinta.com",
          Condition = "Usada",
          Warranty = false,
          OwnerUserId = 2,
          IsSent = true,
        },
        // Tools for User 3
        new Tool
        {
          ResourceId = 7,
          TransactionId = null,
          Name = "Sellos de goma",
          Type = "Decoración",
          Brand = "StampMaster",
          Quantity = 10,
          Description = "Set de sellos de goma para personalizar álbumes.",
          ImageResourceUrl = "https://image-Sellos.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 3,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 8,
          TransactionId = 6,
          Name = "Máquina de coser portátil",
          Type = "Coser",
          Brand = "SewEasy",
          Quantity = 1,
          Description = "Máquina de coser portátil para proyectos pequeños.",
          ImageResourceUrl = "https://image-Maquina.com",
          Condition = "Usada",
          Warranty = false,
          OwnerUserId = 3,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 9,
          TransactionId = 5,
          Name = "Plumones de colores",
          Type = "Dibujo",
          Brand = "ColorArt",
          Quantity = 50,
          Description = "Plumones permanentes de varios colores.",
          ImageResourceUrl = "https://image-Plumones.com",
          Condition = "Nueva",
          Warranty = false,
          OwnerUserId = 3,
          IsSent = true,
        },
        // Tools for User 4
        new Tool
        {
          ResourceId = 10,
          TransactionId = 7,
          Name = "Cutter eléctrico",
          Type = "Corte",
          Brand = "ElectricCut",
          Quantity = 1,
          Description = "Cutter eléctrico para cortes rápidos y precisos.",
          ImageResourceUrl = "https://image-Cutter.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 4,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 11,
          TransactionId = 8,
          Name = "Laminadora",
          Type = "Laminación",
          Brand = "LamiPro",
          Quantity = 2,
          Description = "Laminadora para proteger y embellecer trabajos.",
          ImageResourceUrl = "https://image-Laminadora.com",
          Condition = "Usada",
          Warranty = false,
          OwnerUserId = 4,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 12,
          TransactionId = null,
          Name = "Troqueladora",
          Type = "Corte",
          Brand = "PunchMaster",
          Quantity = 1,
          Description = "Troqueladora para formas personalizadas.",
          ImageResourceUrl = "https://image-Troqueladora.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 4,
          IsSent = true,
        },
        // Tools for User 5
        new Tool
        {
          ResourceId = 13,
          TransactionId = null,
          Name = "Regla flexible",
          Type = "Medición",
          Brand = "FlexiMeasure",
          Quantity = 10,
          Description = "Regla flexible para curvas y diseños complejos.",
          ImageResourceUrl = "https://image-Regla.com",
          Condition = "Nueva",
          Warranty = false,
          OwnerUserId = 5,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 14,
          TransactionId = null,
          Name = "Rotuladores finos",
          Type = "Dibujo",
          Brand = "FineLine",
          Quantity = 100,
          Description = "Rotuladores finos para detalles precisos.",
          ImageResourceUrl = "https://image-Rotuladores.com",
          Condition = "Nueva",
          Warranty = false,
          OwnerUserId = 5,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 15,
          TransactionId = 9,
          Name = "Pistola de calor",
          Type = "Adhesivo",
          Brand = "HeatGlue",
          Quantity = 1,
          Description = "Pistola de calor para fusión de materiales.",
          ImageResourceUrl = "https://image-Pistola.com",
          Condition = "Usada",
          Warranty = false,
          OwnerUserId = 5,
          IsSent = true,
        },
        // Tools for User 6
        new Tool
        {
          ResourceId = 16,
          TransactionId = 12,
          Name = "Pistola de pegamento caliente",
          Type = "Adhesivo",
          Brand = "HotGluePro",
          Quantity = 3,
          Description = "Pistola de pegamento caliente para proyectos rápidos.",
          ImageResourceUrl = "https://image-Pistola.com",
          Condition = "Nueva",
          Warranty = true,
          OwnerUserId = 6,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 17,
          TransactionId = null,
          Name = "Compás de precisión",
          Type = "Medición",
          Brand = "PrecisionCompass",
          Quantity = 15,
          Description = "Compás de precisión para diseños circulares.",
          ImageResourceUrl = "https://image-Compas.com",
          Condition = "Nueva",
          Warranty = false,
          OwnerUserId = 6,
          IsSent = true,
        },
        new Tool
        {
          ResourceId = 18,
          TransactionId = null,
          Name = "Pegatinas decorativas",
          Type = "Decoración",
          Brand = "StickerArt",
          Quantity = 200,
          Description = "Pegatinas decorativas para personalizar álbumes.",
          ImageResourceUrl = "https://image-Pegatinas.com",
          Condition = "Nueva",
          Warranty = false,
          OwnerUserId = 6,
          IsSent = true,
        }
      );

      // Data seed for Materials
      modelBuilder.Entity<Material>().HasData(
        // Materials for User 1
        new Material
        {
          ResourceId = 19,
          TransactionId = 2,
          Name = "Cápsulas de café usadas",
          Type = "Reciclaje",
          Brand = "EcoCaps",
          Quantity = 100,
          Description = "Cápsulas de café recicladas para crear decoraciones.",
          ImageResourceUrl = "https://image-Capsulas.com",
          OwnerUserId = 1,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 20,
          TransactionId = null,
          Name = "Cajas de TetraBrik",
          Type = "Reciclaje",
          Brand = "EcoBox",
          Quantity = 50,
          Description = "Cajas de TetraBrik recicladas para proyectos de scrapbooking.",
          ImageResourceUrl = "https://image-Cajas.com",
          OwnerUserId = 1,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 21,
          TransactionId = null,
          Name = "Papel reciclado",
          Type = "Reciclaje",
          Brand = "RePaper",
          Quantity = 200,
          Description = "Papel reciclado para crear fondos y decoraciones.",
          ImageResourceUrl = "https://image-Papel.com",
          OwnerUserId = 1,
          IsSent = true,
        },
        // Materials for User 2
        new Material
        {
          ResourceId = 22,
          TransactionId = 5,
          Name = "Botellas de plástico",
          Type = "Reciclaje",
          Brand = "EcoBottle",
          Quantity = 80,
          Description = "Botellas de plástico recicladas para crear accesorios.",
          ImageResourceUrl = "https://image-Botellas.com",
          OwnerUserId = 2,
          IsSent = false,
        },
        new Material
        {
          ResourceId = 23,
          TransactionId = 4,
          Name = "Cartones de embalaje",
          Type = "Reciclaje",
          Brand = "PackCard",
          Quantity = 150,
          Description = "Cartones de embalaje reciclados para bases de álbumes.",
          ImageResourceUrl = "https://image-Cartones.com",
          OwnerUserId = 2,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 24,
          TransactionId = 5,
          Name = "Tapas de botellas",
          Type = "Reciclaje",
          Brand = "EcoCap",
          Quantity = 300,
          Description = "Tapas de botellas recicladas para decoraciones diversas.",
          ImageResourceUrl = "https://image-Tapas.com",
          OwnerUserId = 2,
          IsSent = false,
        },
        // Materials for User 3
        new Material
        {
          ResourceId = 25,
          TransactionId = 6,
          Name = "Papel de revistas",
          Type = "Reciclaje",
          Brand = "MagPaper",
          Quantity = 250,
          Description = "Papel de revistas recicladas para collages.",
          ImageResourceUrl = "https://image-Papel.com",
          OwnerUserId = 3,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 26,
          TransactionId = 6,
          Name = "Latas de aluminio",
          Type = "Reciclaje",
          Brand = "AluCan",
          Quantity = 120,
          Description = "Latas de aluminio recicladas para marcos y decoraciones.",
          ImageResourceUrl = "https://image-Latas.com",
          OwnerUserId = 3,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 27,
          TransactionId = 7,
          Name = "Papel de seda",
          Type = "Decorativo",
          Brand = "SilkPaper",
          Quantity = 500,
          Description = "Papel de seda para crear fondos y detalles suaves.",
          ImageResourceUrl = "https://image-Papel.com",
          OwnerUserId = 3,
          IsSent = false,
        },
        // Materials for User 4
        new Material
        {
          ResourceId = 28,
          TransactionId = 7,
          Name = "Cartulinas recicladas",
          Type = "Reciclaje",
          Brand = "EcoCard",
          Quantity = 300,
          Description = "Cartulinas recicladas para tarjetas y decoraciones.",
          ImageResourceUrl = "https://image-Cartulinas.com",
          OwnerUserId = 4,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 29,
          TransactionId = null,
          Name = "Revistas viejas",
          Type = "Reciclaje",
          Brand = "OldMag",
          Quantity = 100,
          Description = "Revistas viejas para recortes y collages.",
          ImageResourceUrl = "https://image-Revistas.com",
          OwnerUserId = 4,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 30,
          TransactionId = null,
          Name = "Botones reutilizados",
          Type = "Reciclaje",
          Brand = "ReuseButtons",
          Quantity = 400,
          Description = "Botones reutilizados para adornar álbumes.",
          ImageResourceUrl = "https://image-Botones.com",
          OwnerUserId = 4,
          IsSent = true,
        },
        // Materials for User 5
        new Material
        {
          ResourceId = 31,
          TransactionId = 9,
          Name = "Papel kraft",
          Type = "Reciclaje",
          Brand = "KraftPaper",
          Quantity = 200,
          Description = "Papel kraft reciclado para crear sobres y bases.",
          ImageResourceUrl = "https://image-Papel.com",
          OwnerUserId = 5,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 32,
          TransactionId = 10,
          Name = "Cintas recicladas",
          Type = "Reciclaje",
          Brand = "EcoRibbon",
          Quantity = 250,
          Description = "Cintas recicladas para atar y decorar.",
          ImageResourceUrl = "https://image-Cintas.com",
          OwnerUserId = 5,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 33,
          TransactionId = null,
          Name = "Etiquetas de productos",
          Type = "Reciclaje",
          Brand = "LabelReuse",
          Quantity = 500,
          Description = "Etiquetas de productos recicladas para personalizar.",
          ImageResourceUrl = "https://image-Etiquetas.com",
          OwnerUserId = 5,
          IsSent = true,
        },
        // Materials for User 6
        new Material
        {
          ResourceId = 34,
          TransactionId = 12,
          Name = "Papel periódico",
          Type = "Reciclaje",
          Brand = "NewsPaper",
          Quantity = 300,
          Description = "Papel periódico para crear fondos y texturas.",
          ImageResourceUrl = "https://image-Papel.com",
          OwnerUserId = 6,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 35,
          TransactionId = null,
          Name = "Botellas de vidrio pequeñas",
          Type = "Reciclaje",
          Brand = "GlassReuse",
          Quantity = 60,
          Description = "Botellas de vidrio pequeñas para crear decoraciones.",
          ImageResourceUrl = "https://image-Botellas.com",
          OwnerUserId = 6,
          IsSent = true,
        },
        new Material
        {
          ResourceId = 36,
          TransactionId = null,
          Name = "CDs viejos",
          Type = "Reciclaje",
          Brand = "OldCD",
          Quantity = 100,
          Description = "CDs viejos para crear mosaicos y decoraciones brillantes.",
          ImageResourceUrl = "https://image-CDs.com",
          OwnerUserId = 6,
          IsSent = true,
        }
      );

      // Data seed for Publications
      modelBuilder.Entity<Publication>().HasData(
        // Publications for User 1
        new Publication
        {
          PublicationId = 1,
          AuthorId = 1,
          CreatedAt = new DateTime(2023, 4, 5, 10, 20, 15),
          Category = "Reciclaje",
          Title = "Consejos para Reciclar mientras Decoras",
          Description = @"¡Hola a todos!

          Combinar reciclaje con decoración es una excelente forma de ser creativo y sostenible. Aquí algunos consejos:

          Reutiliza Frascos: Transforma frascos de vidrio en elegantes porta-velas.
          Papel Reciclado: Usa papel reciclado para crear pósters o murales.
          Muebles Upcycled: Restaura muebles viejos con pintura ecológica.
          Adornos Naturales: Incorpora elementos como ramas o piedras en tus decoraciones.
          ¡Anímate a decorar de manera sostenible!",
        },
        new Publication
        {
          PublicationId = 2,
          AuthorId = 1,
          CreatedAt = new DateTime(2023, 5, 10, 14, 30, 25),
          Category = "Scrapbooking",
          Title = "Creando tu Primer Álbum",
          Description = @"¡Bienvenidos!

          Iniciar tu primer álbum de scrapbooking es sencillo con estos pasos:

          Selecciona un Álbum: Elige uno que se adapte a tus necesidades.
          Reúne Materiales: Fotos, papel decorativo, y adornos.
          Diseña las Páginas: Planifica la disposición antes de pegar.
          Añade Detalles: Escribe notas o utiliza stickers para personalizar.
          ¡Disfruta creando tus recuerdos!",
        },
        new Publication
        {
          PublicationId = 3,
          AuthorId = 1,
          CreatedAt = new DateTime(2023, 5, 12, 16, 45, 30),
          Category = "Respuesta",
          Title = "Respuesta: Plantando Árboles",
          Description = @"¡Hola!

          Me encanta tu guía para 'Creando tu Primer Álbum'. ¡Gran iniciativa! Me gustaría integrar elementos naturales como hojas secas en mis páginas.

          ¿Has considerado usar materiales reciclados en tus proyectos de scrapbooking ? ¡Sería genial compartir ideas!

          ¡Gracias por inspirar!",
          ReplyPostID = 2
        },
        // Publications for User 2
        new Publication
        {
          PublicationId = 4,
          AuthorId = 2,
          CreatedAt = new DateTime(2023, 4, 8, 12, 15, 30),
          Category = "Jardinería",
          Title = "Maceta fabricada con Material Reciclado",
          Description = @"¡Hola jardineros!

          Crear una maceta reciclada es fácil y ecológico:

          Materiales: Usa botellas de plástico o latas.
          Preparación: Haz agujeros para el drenaje.
          Decoración: Pinta o decora a tu gusto.
          Planta: Añade tierra y tus plantas favoritas.
          ¡Disfruta de tus creaciones verdes!",
        },
        new Publication
        {
          PublicationId = 5,
          AuthorId = 2,
          CreatedAt = new DateTime(2023, 5, 18, 11, 25, 40),
          Category = "Decoración",
          Title = "Ideas para Decorar con Material Reciclado",
          Description = @"¡Hola creativos!

          Transformar materiales reciclados en decoraciones es muy sencillo:

          Latas Pintadas: Úsalas como floreros o porta velas.
          CDs Viejos: Crea mosaicos brillantes para espejos.
          Botellas de Vidrio: Transfórmalas en lámparas únicas.
          Papel Reciclado: Diseña murales o cuadros decorativos.
          ¡Dale una segunda vida a tus materiales!",
        },
        new Publication
        {
          PublicationId = 6,
          AuthorId = 2,
          CreatedAt = new DateTime(2023, 5, 20, 13, 35, 50),
          Category = "Respuesta",
          Title = "Respuesta: Creando tu Primer Álbum",
          Description = @" Tu guía para 'Creando tu Primer Álbum' es ¡excelente! Gracias por compartir pasos tan claros.

          Estoy empezando y tus consejos sobre la organización me han sido muy útiles.

          ¿Tienes algún truco para mantener todo en orden ? ¡Agradecería mucho tus sugerencias!

          ¡Gracias nuevamente!",
          ReplyPostID = 2
        },
        // Publications for User 3
        new Publication
        {
          PublicationId = 7,
          AuthorId = 3,
          CreatedAt = new DateTime(2023, 4, 12, 15, 30, 20),
          Category = "Jardinería",
          Title = "Usar materiales impermeables para la maceta",
          Description = @" Excelente idea sobre las macetas recicladas. Usar materiales impermeables es clave para la durabilidad.

          Te recomiendo utilizar botellas de plástico resistentes o latas tratadas para evitar filtraciones.

          ¿Has probado algún otro material? ¡Me encantaría conocer tu experiencia!

          ¡Saludos!",
          ReplyPostID = 4
        },
        new Publication
        {
          PublicationId = 8,
          AuthorId = 3,
          CreatedAt = new DateTime(2023, 6, 5, 10, 50, 10),
          Category = "Scrapbooking",
          Title = "Técnicas Avanzadas de Scrapbooking",
          Description = @"¡Hola scrapbookers!

          Lleva tus álbumes al siguiente nivel con estas técnicas avanzadas:

          Capas de Transparente: Añade profundidad superponiendo papeles translúcidos.
          Elementos 3D: Incorpora botones y cintas para un efecto tridimensional.
          Integración Digital: Utiliza impresiones de alta calidad y collage digital.
          Caligrafía Personalizada: Escribe mensajes con estilos de letra únicos.
          ¡Experimenta y crea obras únicas!",
        },
        new Publication
        {
          PublicationId = 9,
          AuthorId = 3,
          CreatedAt = new DateTime(2023, 6, 7, 12, 00, 00),
          Category = "Respuesta",
          Title = "Respuesta: Ideas para Decorar con Material Reciclado",
          Description = @"¡Ey!

          ¡Muy creativas las ideas para decorar con materiales reciclados! Me inspiraron a probar las lámparas de botellas de vidrio.

          Gracias por compartir tus innovadoras propuestas.

          ¿Tienes alguna otra idea para reutilizar materiales cotidianos? ¡Me encantaría saber más!

          ¡Saludos!",
          ReplyPostID = 5
        },
        // Publications for User 4
        new Publication
        {
          PublicationId = 10,
          AuthorId = 4,
          CreatedAt = new DateTime(2023, 6, 15, 9, 15, 45),
          Category = "Decoración",
          Title ="Cómo Utilizar Botones Reciclados",
          Description = @"¡Hola creativos!

          Los botones reciclados son perfectos para decorar:

          Collares y Pulseras: Crea accesorios únicos ensartando botones.
          Cuadros Decorativos: Forma patrones o mandalas pegando botones en un lienzo.
          Candelabros: Decora portavelas con botones para un toque colorido.
          Adornos para Espejos: Pega botones alrededor del marco para personalizar.
          ¡Deja volar tu imaginación con botones reciclados!

          ",
        },
        new Publication
        {
          PublicationId = 11,
          AuthorId = 4,
          CreatedAt = new DateTime(2023, 6, 20, 14, 25, 55),
          Category = "Scrapbooking",
          Title = "Consejo a la hora de crear Tarjetas Personalizadas",
          Description = @"¡Hola scrapbookers!

          Al crear tarjetas personalizadas, un buen consejo es enfocarse en la simplicidad:

          Elige un Tema: Define el motivo central de la tarjeta.
          Usa Materiales Reciclados: Integra papel reciclado o telas viejas.
          Añade Detalles: Usa botones, cintas o stickers para embellecer.
          Mantén la Coherencia: Asegúrate de que todos los elementos combinen bien.
          ¡Crea tarjetas únicas y significativas!",
        },
        new Publication
        {
          PublicationId = 12,
          AuthorId = 4,
          CreatedAt = new DateTime(2023, 6, 22, 16, 35, 05),
          Category = "Respuesta",
          Title = @"Respuesta: Técnicas Avanzadas de Scrapbooking",
          Description = @"¡Buenasss!

          ¡Fantásticas técnicas de scrapbooking! Estoy emocionado por probar las capas transparentes y los elementos 3D en mi próximo álbum.

          Gracias por compartir estos métodos avanzados.

          ¿Tienes algún consejo para mantener todo bien organizado mientras aplico estas técnicas?

          ¡Saludos!",
          ReplyPostID = 8
        },
        // Publications for User 5
        new Publication
        {
          PublicationId = 13,
          AuthorId = 5,
          CreatedAt = new DateTime(2023, 7, 1, 10, 00, 00),
          Category = "Reciclaje",
          Title = "Beneficios del Papel Reciclado",
          Description = @"¡Hola a todos!

          El papel reciclado ofrece múltiples beneficios:

          Conserva Recursos Naturales: Reduce la necesidad de talar árboles.
          Ahorra Energía: La producción consume menos energía.
          Reduce Residuos: Disminuye la cantidad de basura en vertederos.
          Menor Emisión de CO₂: Contribuye a combatir el cambio climático.
          ¡Optar por papel reciclado es una decisión ecológica!",
        },
        new Publication
        {
          PublicationId = 14,
          AuthorId = 5,
          CreatedAt = new DateTime(2023, 7, 5, 11, 10, 10),
          Category = "Scrapbooking",
          Title = "Creando Sellos Personalizados",
          Description = @"¡Hola scrapbookers!

          Diseñar sellos personalizados es sencillo:

          Materiales: Goma para sellos, bloques de madera, tinta.
          Diseña: Dibuja tu diseño en la goma.
          Graba: Usa herramientas para esculpir el diseño.
          Monta: Adhiere la goma al bloque de madera.
          Prueba: Realiza una prueba de estampado.
          ¡Crea sellos únicos para tus proyectos!",
        },
        new Publication
        {
          PublicationId = 15,
          AuthorId = 5,
          CreatedAt = new DateTime(2023, 7, 7, 13, 20, 20),
          Category = "Respuesta",
          Title = "Respuesta: Creación de Tarjetas Personalizadas",
          Description = @"¡Hola [Usuario 4]!

          Seguí tu consejo para crear tarjetas personalizadas y ¡quedaron geniales!

          Me encantó cómo integraste materiales reciclados, especialmente las telas viejas.

          ¡Gracias por compartir tu sencillo pero efectivo método.

          ¿Tienes más ideas para añadir detalles sin complicar el diseño?

          ¡Saludos!",
          ReplyPostID = 11
        },
        // Publications for User 6
        new Publication
        {
          PublicationId = 16,
          AuthorId = 6,
          CreatedAt = new DateTime(2023, 7, 15, 9, 30, 30),
          Category = "Decoración",
          Title = "Uso Creativo de CDs Viejos",
          Description = @"¡Hola artesanos!

          Reutiliza tus CDs viejos con estas ideas:

          Mosaicos: Crea patrones brillantes en marcos de fotos.
          Móviles: Cuelga CDs para un efecto luminoso.
          Espejos Decorados: Decora marcos con CDs para reflejar luz.
          Arte de Pared: Forma diseños abstractos pegando CDs en lienzos.
          ¡Dale nueva vida a tus CDs reciclados!",
        },
        new Publication
        {
          PublicationId = 17,
          AuthorId = 6,
          CreatedAt = new DateTime(2023, 7, 20, 14, 40, 40),
          Category = "Scrapbooking",
          Title = "Incorporando Botellas de Vidrio",
          Description = @"¡Hola scrapbookers!

          Integra botellas de vidrio recicladas en tus álbumes con estas ideas:

          Insertos Transparentes: Guarda pequeños recuerdos dentro de botellas.
          Fondos Decorativos: Usa botellas como fondo para fotos.
          Detalles: Añade fragmentos rotos para embellecer las páginas.
          Temas Específicos: Dedica páginas a eventos usando botellas relacionadas.
          ¡Añade elegancia con botellas de vidrio recicladas!",
        },
        new Publication
        {
          PublicationId = 18,
          AuthorId = 6,
          CreatedAt = new DateTime(2023, 7, 22, 16, 50, 50),
          Category = "Respuesta",
          Title = "Respuesta: Beneficios del Papel Reciclado",
          Description = @"¡Buenos días!

          Tu publicación sobre los 'Beneficios del Papel Reciclado' es ¡muy informativa! Ahora estoy convencido de reciclar más.

          Especialmente me impactó cómo reduce las emisiones de CO₂.

          ¿Tienes algún consejo para motivar a otros a reciclar ?

          ¡Gracias por compartir!",
          ReplyPostID = 13
        }
      );

      // Data seed for Transactions
      modelBuilder.Entity<Transaction>().HasData(
        // Transactions for User 1
        new Transaction
        {
          ArticlesDescription = "Pegamento en barra para sellos sin apenas uso.",
          TransactionID = 1,
          Type = TransactionType.Exchange,
          Status = TransactionStatus.Completed,
          DateInitiated = new DateTime(2024, 1, 10),
          DateCompleted = new DateTime(2024, 1, 15),
          InitiatorUserID = 1,
          ReceiverUserID = 2,
          IsActive = false,
          ImageTransactionUrl = "https://default-transaction1.com",
        },
        new Transaction
        {
          ArticlesDescription = "Regla metálica y capsulas de cafe usadas.",
          TransactionID = 2,
          Type = TransactionType.Gift,
          Status = TransactionStatus.Accepted,
          DateInitiated = new DateTime(2024, 2, 20),
          InitiatorUserID = 1,
          ReceiverUserID = 3,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction2.com",
        },
        // Transactions for User 2
        new Transaction
        {
          ArticlesDescription = "Tijeras de precisión muy usadas pero sin daños.",
          TransactionID = 3,
          Type = TransactionType.Exchange,
          Status = TransactionStatus.Completed,
          DateInitiated = new DateTime(2024, 3, 5),
          DateCompleted = new DateTime(2024, 3, 10),
          InitiatorUserID = 2,
          ReceiverUserID = 1,
          IsActive = false,
          ImageTransactionUrl = "https://default-transaction3.com",
        },
        new Transaction
        {
          ArticlesDescription = "Cartones de embalaje para crear una caja de recuerdos.",
          TransactionID = 4,
          Type = TransactionType.Gift,
          Status = TransactionStatus.Pending,
          DateInitiated = new DateTime(2024, 4, 15),
          InitiatorUserID = 2,
          ReceiverUserID = 3,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction4.com",
        },
        // Transactions for User 3
        new Transaction
        {
          ArticlesDescription = "Pumones de colores + Botellas de plastico + Revistas de decoración viejas.",
          TransactionID = 5,
          Type = TransactionType.Exchange,
          Status = TransactionStatus.Rejected,
          DateInitiated = new DateTime(2024, 5, 10),
          DateCompleted = new DateTime(2024, 5, 15),
          InitiatorUserID = 3,
          ReceiverUserID = 2,
          IsActive = false,
          ImageTransactionUrl = "https://default-transaction5.com",
        },
        new Transaction
        {
          ArticlesDescription = "Maquina de coser, papel de revistas y latas de aluminio.",
          TransactionID = 6,
          Type = TransactionType.Gift,
          Status = TransactionStatus.Accepted,
          DateInitiated = new DateTime(2024, 6, 20),
          InitiatorUserID = 3,
          ReceiverUserID = 5,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction6.com",
        },
        // Transactions for User 4
        new Transaction
        {
          ArticlesDescription = "Cuter electrico y cartulinas recicladas. Busco guillotina o laminadora.",
          TransactionID = 7,
          Type = TransactionType.Exchange,
          Status = TransactionStatus.Accepted,
          DateInitiated = new DateTime(2024, 7, 5),
          InitiatorUserID = 4,
          ReceiverUserID = 3,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction7.com",
        },
        new Transaction
        {
          ArticlesDescription = "Laminadora sin apenas uso. Busco papel kraft o cintas recicladas.",
          TransactionID = 8,
          Type = TransactionType.Gift,
          Status = TransactionStatus.Pending,
          DateInitiated = new DateTime(2024, 8, 15),
          InitiatorUserID = 4,
          ReceiverUserID = 2,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction8.com",
        },
        // Transactions for User 5
        new Transaction
        {
          ArticlesDescription = "Pistola de calor para manualidades y packde papel kraft. Buso rotuladores de colores para scrapbooking.",
          TransactionID = 9,
          Type = TransactionType.Exchange,
          Status = TransactionStatus.Pending,
          DateInitiated = new DateTime(2024, 9, 10),
          InitiatorUserID = 5,
          ReceiverUserID = null,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction9.com",
        },
        new Transaction
        {
          ArticlesDescription = "Citas recicladas para la mejor decoradora eco-friendly.",
          TransactionID = 10,
          Type = TransactionType.Gift,
          Status = TransactionStatus.Pending,
          DateInitiated = new DateTime(2024, 10, 20),
          InitiatorUserID = 5,
          ReceiverUserID = 6,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction10.com",
        },
        // Transactions for User 6
        new Transaction
        {
          ArticlesDescription = "Rotuladores de punta fina de colores. Necesito troqueladora.",
          TransactionID = 11,
          Type = TransactionType.Exchange,
          Status = TransactionStatus.Completed,
          DateInitiated = new DateTime(2024, 11, 5),
          DateCompleted = new DateTime(2024, 11, 10),
          InitiatorUserID = 6,
          ReceiverUserID = 5,
          IsActive = false,
          ImageTransactionUrl = "https://default-transaction11.com",
        },
        new Transaction
        {
          ArticlesDescription = "Pistola de pegamento caliente + pack de papel periódico. Busco compás de precisión.",
          TransactionID = 12,
          Type = TransactionType.Gift,
          Status = TransactionStatus.Pending,
          DateInitiated = new DateTime(2024, 12, 15),
          InitiatorUserID = 6,
          ReceiverUserID = 1,
          IsActive = true,
          ImageTransactionUrl = "https://default-transaction12.com",
        }
      );

      // Data seed for Projects
      modelBuilder.Entity<Project>().HasData(
        // Projects for User 1
        new Project
        {
          ActivityId = 1,
          Title = "Caja de recuerdos",
          Description = "Creación de una cajita para guardar recuerdos.",
          MaxParticipants = 4,
          CreatedAt = new DateTime(2024, 1, 1, 10, 20, 35),
          StartDate = new DateTime(2024, 1, 5),
          FinishDate = new DateTime(2024, 6, 5),
          IsActive = true,
          GreenPointsValue = 100.0m,
          ProjectType = "Manualidades",
          CreatorUserId = 1,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 2,
          Title = "Álbum de Vacaciones",
          Description = "Diseño de un álbum personalizado con fotos de vacaciones.",
          MaxParticipants = 1,
          CreatedAt = new DateTime(2024, 2, 1, 11, 15, 25),
          StartDate = new DateTime(2024, 2, 10),
          FinishDate = new DateTime(2024, 5, 10),
          IsActive = true,
          GreenPointsValue = 80.0m,
          ProjectType = "Álbumes",
          CreatorUserId = 1,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 3,
          Title = "Sellos Personalizados",
          Description = "Creación de sellos únicos para decorar álbumes.",
          CreatedAt = new DateTime(2024, 3, 1, 9, 30, 45),
          StartDate = new DateTime(2024, 3, 5),
          FinishDate = new DateTime(2024, 4, 15),
          IsActive = true,
          GreenPointsValue = 60.0m,
          ProjectType = "Decoración",
          CreatorUserId = 1,
          HomeImageUrl = "https://default-homepage.com",
        },
        // Projects for User 2
        new Project
        {
          ActivityId = 4,
          Title = "Tarjetas de Cumpleaños",
          Description = "Diseño de tarjetas personalizadas para cumpleaños.",
          CreatedAt = new DateTime(2024, 4, 1, 10, 10, 10),
          StartDate = new DateTime(2024, 4, 5),
          FinishDate = new DateTime(2024, 5, 20),
          IsActive = true,
          GreenPointsValue = 70.0m,
          ProjectType = "Tarjetas",
          CreatorUserId = 2,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 5,
          Title = "Marco Decorativo",
          Description = "Creación de marcos decorativos con materiales reciclados.",
          MaxParticipants = 2,
          CreatedAt = new DateTime(2024, 4, 15, 12, 20, 30),
          StartDate = new DateTime(2024, 4, 20),
          FinishDate = new DateTime(2024, 6, 10),
          IsActive = true,
          GreenPointsValue = 90.0m,
          ProjectType = "Decoración",
          CreatorUserId = 2,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 6,
          Title = "Álbum de Graduación",
          Description = "Diseño de un álbum especial para graduación.",
          MaxParticipants = 3,
          CreatedAt = new DateTime(2024, 5, 1, 14, 30, 40),
          StartDate = new DateTime(2024, 5, 5),
          FinishDate = new DateTime(2024, 7, 15),
          IsActive = true,
          GreenPointsValue = 85.0m,
          ProjectType = "Álbumes",
          CreatorUserId = 2,
          HomeImageUrl = "https://default-homepage.com",
        },
        // Projects for User 3
        new Project
        {
          ActivityId = 7,
          Title = "Decoración con Latas",
          Description = "Transformar latas de aluminio en decoraciones artísticas.",
          CreatedAt = new DateTime(2024, 6, 1, 11, 45, 50),
          StartDate = new DateTime(2024, 6, 5),
          FinishDate = new DateTime(2024, 8, 20),
          IsActive = true,
          GreenPointsValue = 95.0m,
          ProjectType = "Decoración",
          CreatorUserId = 3,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 8,
          Title = "Collage de Recortes",
          Description = "Creación de collages artísticos con recortes de revistas.",
          MaxParticipants = 2,
          CreatedAt = new DateTime(2024, 6, 15, 13, 55, 00),
          StartDate = new DateTime(2024, 6, 20),
          FinishDate = new DateTime(2024, 9, 25),
          IsActive = true,
          GreenPointsValue = 75.0m,
          ProjectType = "Collages",
          CreatorUserId = 3,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 9,
          Title = "Album Temático de Primavera",
          Description = "Diseño de un álbum temático inspirado en la primavera.",
          MaxParticipants = 10,
          CreatedAt = new DateTime(2024, 7, 1, 15, 05, 10),
          StartDate = new DateTime(2024, 7, 5),
          FinishDate = new DateTime(2024, 10, 10),
          IsActive = true,
          GreenPointsValue = 100.0m,
          ProjectType = "Álbumes",
          CreatorUserId = 3,
          HomeImageUrl = "https://default-homepage.com",
        },
        // Projects for User 4
        new Project
        {
          ActivityId = 10,
          Title = "Marcos con Botones",
          Description = "Crear marcos decorativos utilizando botones reciclados.",
          CreatedAt = new DateTime(2024, 8, 1, 10, 30, 20),
          StartDate = new DateTime(2024, 8, 5),
          FinishDate = new DateTime(2024, 9, 15),
          IsActive = true,
          GreenPointsValue = 80.0m,
          ProjectType = "Decoración",
          CreatorUserId = 4,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 11,
          Title = "Tarjetas de Aniversario",
          Description = "Diseño de tarjetas de aniversario con materiales reutilizados.",
          CreatedAt = new DateTime(2024, 8, 15, 12, 40, 30),
          StartDate = new DateTime(2024, 8, 20),
          FinishDate = new DateTime(2024, 10, 25),
          IsActive = true,
          GreenPointsValue = 85.0m,
          ProjectType = "Tarjetas",
          CreatorUserId = 4,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 12,
          Title = "Album de Recuerdos",
          Description = "Creación de un álbum para conservar recuerdos especiales.",
          MaxParticipants = 5,
          CreatedAt = new DateTime(2024, 9, 1, 14, 50, 40),
          StartDate = new DateTime(2024, 9, 5),
          FinishDate = new DateTime(2024, 11, 10),
          IsActive = true,
          GreenPointsValue = 90.0m,
          ProjectType = "Álbumes",
          CreatorUserId = 4,
          HomeImageUrl = "https://default-homepage.com",
        },
        // Projects for User 5
        new Project
        {
          ActivityId = 13,
          Title = "Sobres Personalizados",
          Description = "Diseño de sobres personalizados con papel kraft reciclado.",
          CreatedAt = new DateTime(2024, 10, 1, 10, 00, 00),
          StartDate = new DateTime(2024, 10, 5),
          FinishDate = new DateTime(2024, 12, 15),
          IsActive = true,
          GreenPointsValue = 75.0m,
          ProjectType = "Tarjetas",
          CreatorUserId = 5,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 14,
          Title = "Cintas Decorativas",
          Description = "Creación de cintas decorativas utilizando materiales reciclados.",
          CreatedAt = new DateTime(2024, 10, 15, 12, 10, 10),
          StartDate = new DateTime(2024, 10, 20),
          FinishDate = new DateTime(2025, 1, 25),
          IsActive = true,
          GreenPointsValue = 80.0m,
          ProjectType = "Decoración",
          CreatorUserId = 5,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 15,
          Title = "Sellos con Recortes",
          Description = "Crear sellos personalizados utilizando recortes de etiquetas.",
          CreatedAt = new DateTime(2024, 11, 1, 14, 20, 20),
          StartDate = new DateTime(2024, 11, 5),
          FinishDate = new DateTime(2025, 2, 10),
          IsActive = true,
          GreenPointsValue = 85.0m,
          ProjectType = "Decoración",
          CreatorUserId = 5,
          HomeImageUrl = "https://default-homepage.com",
        },
        // Projects for User 6
        new Project
        {
          ActivityId = 16,
          Title = "Mosaicos con CDs",
          Description = "Creación de mosaicos brillantes utilizando CDs reciclados.",
          MaxParticipants = 3,
          CreatedAt = new DateTime(2024, 12, 1, 10, 30, 30),
          StartDate = new DateTime(2024, 12, 5),
          FinishDate = new DateTime(2025, 2, 15),
          IsActive = true,
          GreenPointsValue = 90.0m,
          ProjectType = "Decoración",
          CreatorUserId = 6,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 17,
          Title = "Decoración con Botellas de Vidrio",
          Description = "Transformar botellas de vidrio en piezas decorativas.",
          CreatedAt = new DateTime(2024, 12, 15, 12, 40, 40),
          StartDate = new DateTime(2024, 12, 20),
          FinishDate = new DateTime(2025, 3, 25),
          IsActive = true,
          GreenPointsValue = 95.0m,
          ProjectType = "Decoración",
          CreatorUserId = 6,
          HomeImageUrl = "https://default-homepage.com",
        },
        new Project
        {
          ActivityId = 18,
          Title = "Álbum Brillante",
          Description = "Diseño de un álbum con detalles brillantes utilizando CDs.",
          MaxParticipants = 2,
          CreatedAt = new DateTime(2025, 1, 1, 14, 50, 50),
          StartDate = new DateTime(2025, 1, 5),
          FinishDate = new DateTime(2025, 4, 10),
          IsActive = true,
          GreenPointsValue = 100.0m,
          ProjectType = "Álbumes",
          CreatorUserId = 6,
          HomeImageUrl = "https://default-homepage.com",
        }
      );

      // Data seed for SustainableActivities
      modelBuilder.Entity<SustainableActivity>().HasData(
        // Sustainable Activities for User 1
        new SustainableActivity
        {
          ActivityId = 19,
          Title = "Recolección de Papel",
          Description = "Recolecta papel reciclable para proyectos de scrapbooking.",
          CreatedAt = new DateTime(2024, 1, 10, 9, 00, 00),
          MaxParticipants = 20,
          StartDate = new DateTime(2024, 1, 15),
          FinishDate = new DateTime(2024, 1, 16),
          IsActive = true,
          GreenPointsValue = 50.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoMadrid",
          AddressId = 1,
          CreatorUserId = 1
        },
        new SustainableActivity
        {
          ActivityId = 20,
          Title = "Recogida de Materiales Desechables",
          Description = "Recoge materiales desechables para reutilización en decoraciones.",
          CreatedAt = new DateTime(2024, 2, 10, 10, 30, 00),
          MaxParticipants = 25,
          StartDate = new DateTime(2024, 2, 15),
          FinishDate = new DateTime(2024, 2, 16),
          IsActive = true,
          GreenPointsValue = 55.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoBarcelona",
          AddressId = 2,
          CreatorUserId = 1
        },
        // Sustainable Activities for User 2
        new SustainableActivity
        {
          ActivityId = 21,
          Title = "Recolección de Botellas",
          Description = "Recolecta botellas de plástico para proyectos creativos.",
          CreatedAt = new DateTime(2024, 3, 10, 11, 00, 00),
          MaxParticipants = 15,
          StartDate = new DateTime(2024, 3, 15),
          FinishDate = new DateTime(2024, 3, 16),
          IsActive = true,
          GreenPointsValue = 60.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoValencia",
          AddressId = 3,
          CreatorUserId = 2
        },
        new SustainableActivity
        {
          ActivityId = 22,
          Title = "Recogida de Tapas de Botellas",
          Description = "Recoge tapas de botellas para decorar proyectos.",
          CreatedAt = new DateTime(2024, 4, 15, 12, 30, 00),
          MaxParticipants = 18,
          StartDate = new DateTime(2024, 4, 20),
          FinishDate = new DateTime(2024, 4, 21),
          IsActive = true,
          GreenPointsValue = 58.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoSevilla",
          AddressId = 4,
          CreatorUserId = 2
        },
        // Sustainable Activities for User 3
        new SustainableActivity
        {
          ActivityId = 23,
          Title = "Recolección de Latas",
          Description = "Recolecta latas de aluminio para reutilización.",
          CreatedAt = new DateTime(2024, 5, 10, 13, 00, 00),
          MaxParticipants = 20,
          StartDate = new DateTime(2024, 5, 15),
          FinishDate = new DateTime(2024, 5, 16),
          IsActive = true,
          GreenPointsValue = 65.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoBilbao",
          AddressId = 5,
          CreatorUserId = 3
        },
        new SustainableActivity
        {
          ActivityId = 24,
          Title = "Recogida de Papeles de Revistas",
          Description = "Recoge papeles de revistas para crear collages.",
          CreatedAt = new DateTime(2024, 6, 15, 14, 30, 00),
          MaxParticipants = 22,
          StartDate = new DateTime(2024, 6, 20),
          FinishDate = new DateTime(2024, 6, 21),
          IsActive = true,
          GreenPointsValue = 62.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoZaragoza",
          AddressId = 6,
          CreatorUserId = 3
        },
        // Sustainable Activities for User 4
        new SustainableActivity
        {
          ActivityId = 25,
          Title = "Recolección de Botones",
          Description = "Recolecta botones para proyectos de decoración.",
          CreatedAt = new DateTime(2024, 7, 10, 15, 00, 00),
          MaxParticipants = 25,
          StartDate = new DateTime(2024, 7, 15),
          FinishDate = new DateTime(2024, 7, 16),
          IsActive = true,
          GreenPointsValue = 55.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoMálaga",
          AddressId = 7,
          CreatorUserId = 4
        },
        new SustainableActivity
        {
          ActivityId = 26,
          Title = "Recogida de Cintas",
          Description = "Recoge cintas recicladas para reutilización en proyectos.",
          CreatedAt = new DateTime(2024, 8, 15, 16, 30, 00),
          MaxParticipants = 20,
          StartDate = new DateTime(2024, 8, 20),
          FinishDate = new DateTime(2024, 8, 21),
          IsActive = true,
          GreenPointsValue = 58.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoMurcia",
          AddressId = 8,
          CreatorUserId = 4
        },
        // Sustainable Activities for User 5
        new SustainableActivity
        {
          ActivityId = 27,
          Title = "Recolección de Etiquetas",
          Description = "Recoge etiquetas de productos para personalización.",
          CreatedAt = new DateTime(2024, 9, 10, 17, 00, 00),
          MaxParticipants = 18,
          StartDate = new DateTime(2024, 9, 15),
          FinishDate = new DateTime(2024, 9, 16),
          IsActive = true,
          GreenPointsValue = 50.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoGranada",
          AddressId = 9,
          CreatorUserId = 5
        },
        new SustainableActivity
        {
          ActivityId = 28,
          Title = "Recogida de Cintas Recicladas",
          Description = "Recoge cintas recicladas para reutilización en decoraciones.",
          CreatedAt = new DateTime(2024, 10, 15, 18, 30, 00),
          MaxParticipants = 20,
          StartDate = new DateTime(2024, 10, 20),
          FinishDate = new DateTime(2024, 10, 21),
          IsActive = true,
          GreenPointsValue = 52.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoCórdoba",
          AddressId = 10,
          CreatorUserId = 5
        },
        // Sustainable Activities for User 6
        new SustainableActivity
        {
          ActivityId = 29,
          Title = "Recolección de CDs",
          Description = "Recolecta CDs viejos para proyectos de mosaicos.",
          CreatedAt = new DateTime(2024, 11, 10, 19, 00, 00),
          MaxParticipants = 15,
          StartDate = new DateTime(2024, 11, 15),
          FinishDate = new DateTime(2024, 11, 16),
          IsActive = true,
          GreenPointsValue = 60.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoAlicante",
          AddressId = 11,
          CreatorUserId = 6
        },
        new SustainableActivity
        {
          ActivityId = 30,
          Title = "Recogida de Botellas de Vidrio",
          Description = "Recoge botellas de vidrio pequeñas para reutilización.",
          CreatedAt = new DateTime(2024, 12, 15, 20, 30, 00),
          MaxParticipants = 18,
          StartDate = new DateTime(2024, 12, 20),
          FinishDate = new DateTime(2024, 12, 21),
          IsActive = true,
          GreenPointsValue = 62.0m,
          HomeImageUrl = "https://default-homepage.com",
          NameCollaborator = "EcoLasPalmas",
          AddressId = 12,
          CreatorUserId = 6
        }
      );

      // Data seed for Tutorials
      modelBuilder.Entity<Tutorial>().HasData(
        // Tutorials for User 1
        new Tutorial
        {
          ActivityId = 31,
          Title = "Cómo Crear un Álbum de Fotos Reciclado",
          Description = "Tutorial para diseñar un álbum utilizando materiales reciclados.",
          CreatedAt = new DateTime(2024, 1, 20, 9, 00, 00),
          MaxParticipants = 2,
          StartDate = new DateTime(2024, 1, 25),
          FinishDate = new DateTime(2024, 1, 26),
          IsActive = true,
          GreenPointsValue = 40.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 45,
          VideoUrl = "https://tutorials.com/album-reciclado",
          CreatorUserId = 1
        },
        new Tutorial
        {
          ActivityId = 32,
          Title = "Decoración con Cápsulas de Café",
          Description = "Aprende a decorar tus proyectos usando cápsulas de café recicladas.",
          CreatedAt = new DateTime(2024, 2, 10, 10, 30, 00),
          MaxParticipants = 1,
          StartDate = new DateTime(2024, 2, 15),
          FinishDate = new DateTime(2024, 2, 16),
          IsActive = true,
          GreenPointsValue = 35.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 30,
          VideoUrl = "https://tutorials.com/capsulas-de-cafe",
          CreatorUserId = 1
        },
        // Tutorials for User 2
        new Tutorial
        {
          ActivityId = 33,
          Title = "Creación de Tarjetas con Materiales Reutilizados",
          Description = "Tutorial para diseñar tarjetas únicas usando materiales reciclados.",
          CreatedAt = new DateTime(2024, 3, 20, 11, 00, 00),
          MaxParticipants = 3,
          StartDate = new DateTime(2024, 3, 25),
          FinishDate = new DateTime(2024, 3, 26),
          IsActive = true,
          GreenPointsValue = 40.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 50,
          VideoUrl = "https://tutorials.com/tarjetas-reutilizadas",
          CreatorUserId = 2
        },
        new Tutorial
        {
          ActivityId = 34,
          Title = "Diseño de Marcos con Materiales Reciclados",
          Description = "Aprende a crear marcos decorativos utilizando materiales reciclados.",
          CreatedAt = new DateTime(2024, 4, 10, 12, 30, 00),
          StartDate = new DateTime(2024, 4, 15),
          FinishDate = new DateTime(2024, 4, 16),
          IsActive = true,
          GreenPointsValue = 38.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 55,
          VideoUrl = "https://tutorials.com/marcos-reciclados",
          CreatorUserId = 2
        },
        // Tutorials for User 3
        new Tutorial
        {
          ActivityId = 35,
          Title = "Creación de Collages con Recortes de Revistas",
          Description = "Tutorial para diseñar collages artísticos utilizando recortes de revistas.",
          CreatedAt = new DateTime(2024, 5, 20, 13, 00, 00),
          MaxParticipants = 2,
          StartDate = new DateTime(2024, 5, 25),
          FinishDate = new DateTime(2024, 5, 26),
          IsActive = true,
          GreenPointsValue = 45.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 60,
          VideoUrl = "https://tutorials.com/collages-revistados",
          CreatorUserId = 3
        },
        new Tutorial
        {
          ActivityId = 36,
          Title = "Transformación de Latas en Decoraciones",
          Description = "Aprende a reutilizar latas de aluminio en proyectos de decoración.",
          CreatedAt = new DateTime(2024, 6, 10, 14, 30, 00),
          StartDate = new DateTime(2024, 6, 15),
          FinishDate = new DateTime(2024, 6, 16),
          IsActive = true,
          GreenPointsValue = 42.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 50,
          VideoUrl = "https://tutorials.com/latas-decorativas",
          CreatorUserId = 3
        },
        // Tutorials for User 4
        new Tutorial
        {
          ActivityId = 37,
          Title = "Uso Creativo de Botones en Scrapbooking",
          Description = "Tutorial para incorporar botones reciclados en tus proyectos.",
          CreatedAt = new DateTime(2024, 7, 20, 15, 00, 00),
          MaxParticipants = 2,
          StartDate = new DateTime(2024, 7, 25),
          FinishDate = new DateTime(2024, 7, 26),
          IsActive = true,
          GreenPointsValue = 35.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 40,
          VideoUrl = "https://tutorials.com/botones-scrapbooking",
          CreatorUserId = 4
        },
        new Tutorial
        {
          ActivityId = 38,
          Title = "Creación de Cintas Decorativas Recicladas",
          Description = "Aprende a diseñar cintas decorativas usando materiales reciclados.",
          CreatedAt = new DateTime(2024, 8, 10, 16, 30, 00),
          MaxParticipants = 1,
          StartDate = new DateTime(2024, 8, 15),
          FinishDate = new DateTime(2024, 8, 16),
          IsActive = true,
          GreenPointsValue = 38.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 45,
          VideoUrl = "https://tutorials.com/cintas-decorativas",
          CreatorUserId = 4
        },
        // Tutorials for User 5
        new Tutorial
        {
          ActivityId = 39,
          Title = "Diseño de Sellos Personalizados",
          Description = "Tutorial para crear sellos únicos para tus álbumes.",
          CreatedAt = new DateTime(2024, 9, 20, 17, 00, 00),
          MaxParticipants = 2,
          StartDate = new DateTime(2024, 9, 25),
          FinishDate = new DateTime(2024, 9, 26),
          IsActive = true,
          GreenPointsValue = 40.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 50,
          VideoUrl = "https://tutorials.com/sellos-personalizados",
          CreatorUserId = 5
        },
        new Tutorial
        {
          ActivityId = 40,
          Title = "Creación de Sobres con Papel Kraft",
          Description = "Aprende a diseñar sobres personalizados usando papel kraft reciclado.",
          CreatedAt = new DateTime(2024, 10, 10, 18, 30, 00),
          StartDate = new DateTime(2024, 10, 15),
          FinishDate = new DateTime(2024, 10, 16),
          IsActive = true,
          GreenPointsValue = 38.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 45,
          VideoUrl = "https://tutorials.com/sobres-papel-kraft",
          CreatorUserId = 5
        },
        // Tutorials for User 6
        new Tutorial
        {
          ActivityId = 41,
          Title = "Creación de Mosaicos con CDs",
          Description = "Tutorial para diseñar mosaicos brillantes utilizando CDs reciclados.",
          CreatedAt = new DateTime(2024, 11, 20, 19, 00, 00),
          StartDate = new DateTime(2024, 11, 25),
          FinishDate = new DateTime(2024, 11, 26),
          IsActive = true,
          GreenPointsValue = 45.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 60,
          VideoUrl = "https://tutorials.com/mosaicos-cds",
          CreatorUserId = 6
        },
        new Tutorial
        {
          ActivityId = 42,
          Title = "Decoración con Botellas de Vidrio",
          Description = "Aprende a reutilizar botellas de vidrio en tus proyectos de scrapbooking.",
          CreatedAt = new DateTime(2024, 12, 10, 20, 30, 00),
          MaxParticipants = 1,
          StartDate = new DateTime(2024, 12, 15),
          FinishDate = new DateTime(2024, 12, 16),
          IsActive = true,
          GreenPointsValue = 42.0m,
          HomeImageUrl = "https://default-homepage.com",
          Duration = 50,
          VideoUrl = "https://tutorials.com/botellas-decorativas",
          CreatorUserId = 6
        }
      );

      // Data seed for UserActivities
      modelBuilder.Entity("UserActivities").HasData(

          new { ActivitiesParticipatedActivityId = 1, ParticipantsUserId = 2 },
          new { ActivitiesParticipatedActivityId = 1, ParticipantsUserId = 3 },

          new { ActivitiesParticipatedActivityId = 2, ParticipantsUserId = 2 },

          new { ActivitiesParticipatedActivityId = 5, ParticipantsUserId = 1 },

          new { ActivitiesParticipatedActivityId = 6, ParticipantsUserId = 5 },
          new { ActivitiesParticipatedActivityId = 6, ParticipantsUserId = 4 },

          new { ActivitiesParticipatedActivityId = 9, ParticipantsUserId = 1 },
          new { ActivitiesParticipatedActivityId = 9, ParticipantsUserId = 2 },
          new { ActivitiesParticipatedActivityId = 9, ParticipantsUserId = 4 },
          new { ActivitiesParticipatedActivityId = 9, ParticipantsUserId = 5 },
          new { ActivitiesParticipatedActivityId = 9, ParticipantsUserId = 6 },

          new { ActivitiesParticipatedActivityId = 12, ParticipantsUserId = 6 },
          new { ActivitiesParticipatedActivityId = 12, ParticipantsUserId = 1 },

          new { ActivitiesParticipatedActivityId = 16, ParticipantsUserId = 2 },

          new { ActivitiesParticipatedActivityId = 18, ParticipantsUserId = 3 },

          new { ActivitiesParticipatedActivityId = 19, ParticipantsUserId = 4 },
          new { ActivitiesParticipatedActivityId = 19, ParticipantsUserId = 5 },
          new { ActivitiesParticipatedActivityId = 19, ParticipantsUserId = 6 },

          new { ActivitiesParticipatedActivityId = 21, ParticipantsUserId = 1 },

          new { ActivitiesParticipatedActivityId = 23, ParticipantsUserId = 2 },
          new { ActivitiesParticipatedActivityId = 23, ParticipantsUserId = 6 },

          new { ActivitiesParticipatedActivityId = 26, ParticipantsUserId = 3 },
          new { ActivitiesParticipatedActivityId = 26, ParticipantsUserId = 5 },

          new { ActivitiesParticipatedActivityId = 28, ParticipantsUserId = 6 },

          new { ActivitiesParticipatedActivityId = 30, ParticipantsUserId = 1 },
          new { ActivitiesParticipatedActivityId = 30, ParticipantsUserId = 2 },
          new { ActivitiesParticipatedActivityId = 30, ParticipantsUserId = 3 },

          new { ActivitiesParticipatedActivityId = 35, ParticipantsUserId = 4 },

          new { ActivitiesParticipatedActivityId = 37, ParticipantsUserId = 5 },

          new { ActivitiesParticipatedActivityId = 39, ParticipantsUserId = 6 }

      );

      modelBuilder.Entity("ActivityResources").HasData(

          new { ActivitiesActivityId = 1, ActivityResourcesResourceId = 1 },
          new { ActivitiesActivityId = 1, ActivityResourcesResourceId = 19 },


          new { ActivitiesActivityId = 2, ActivityResourcesResourceId = 2 },
          new { ActivitiesActivityId = 2, ActivityResourcesResourceId = 20 },


          new { ActivitiesActivityId = 4, ActivityResourcesResourceId = 4 },
          new { ActivitiesActivityId = 4, ActivityResourcesResourceId = 22 },

          new { ActivitiesActivityId = 7, ActivityResourcesResourceId = 9 },
          new { ActivitiesActivityId = 7, ActivityResourcesResourceId = 25 },

          new { ActivitiesActivityId = 31, ActivityResourcesResourceId = 3 },
          new { ActivitiesActivityId = 31, ActivityResourcesResourceId = 20 },

          new { ActivitiesActivityId = 33, ActivityResourcesResourceId = 6 },
          new { ActivitiesActivityId = 33, ActivityResourcesResourceId = 23 }

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
