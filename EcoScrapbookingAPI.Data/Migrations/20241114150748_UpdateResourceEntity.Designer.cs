﻿// <auto-generated />
using System;
using EcoScrapbookingAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    [DbContext(typeof(EcoScrapbookingDBContext))]
    [Migration("20241114150748_UpdateResourceEntity")]
    partial class UpdateResourceEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivityResources", b =>
                {
                    b.Property<int>("ActivitiesActivityId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityResourcesResourceId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesActivityId", "ActivityResourcesResourceId");

                    b.HasIndex("ActivityResourcesResourceId");

                    b.ToTable("ActivityResources", (string)null);
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GreenPointsValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HomeImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Activities");

                    b.HasDiscriminator<string>("ActivityType").HasValue("Activity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Abstracts.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageResourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerUserId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ResourceType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceId");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Resources");

                    b.HasDiscriminator<string>("ResourceType").HasValue("Resource");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "CiudadA",
                            ContactPhone = "555-1234",
                            Country = "PaísA",
                            Description = "Residencia Principal",
                            Number = "123",
                            State = "EstadoA",
                            Street = "Calle Falsa",
                            UserId = 1,
                            ZipCode = "10001"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "CiudadB",
                            ContactPhone = "555-5678",
                            Country = "PaísB",
                            Description = "Oficina",
                            Number = "742",
                            State = "EstadoB",
                            Street = "Avenida Siempre Viva",
                            UserId = 2,
                            ZipCode = "20002"
                        },
                        new
                        {
                            AddressId = 3,
                            City = "CiudadC",
                            ContactPhone = "555-9012",
                            Country = "PaísC",
                            Description = "Lugar de Eventos",
                            Number = "456",
                            State = "EstadoC",
                            Street = "Boulevard de los Sueños",
                            UserId = 3,
                            ZipCode = "30003"
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Publication", b =>
                {
                    b.Property<int>("PublicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublicationID"));

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePostUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReplyPostID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublicationID");

                    b.HasIndex("ActivityId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ReplyPostID");

                    b.ToTable("Publications");

                    b.HasData(
                        new
                        {
                            PublicationID = 1,
                            AuthorId = 1,
                            Category = "Reciclaje",
                            Description = "Métodos efectivos para reciclar en casa.",
                            Title = "Consejos para Reciclar"
                        },
                        new
                        {
                            PublicationID = 2,
                            AuthorId = 2,
                            Category = "Jardinería",
                            Description = "Cómo y dónde plantar árboles.",
                            Title = "Plantando Árboles"
                        },
                        new
                        {
                            PublicationID = 3,
                            AuthorId = 3,
                            Category = "Jardinería",
                            Description = "¡Me encantaría participar!",
                            ReplyPostID = 2,
                            Title = "Respuesta: Plantando Árboles"
                        },
                        new
                        {
                            PublicationID = 4,
                            ActivityId = 1,
                            AuthorId = 1,
                            Category = "Paso de proyecto",
                            Description = "Hemos terminado de cortar las piezas.",
                            ImagePostUrl = "https://image-post.com",
                            Title = "Avance: Caja de recuerdos"
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInitiated")
                        .HasColumnType("datetime2");

                    b.Property<int>("InitiatorUserID")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiverUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionID");

                    b.HasIndex("InitiatorUserID");

                    b.HasIndex("ReceiverUserID");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionID = 1,
                            DateCompleted = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateInitiated = new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitiatorUserID = 1,
                            ReceiverUserID = 2,
                            Status = "Completed",
                            Type = "Exchange"
                        },
                        new
                        {
                            TransactionID = 2,
                            DateInitiated = new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitiatorUserID = 2,
                            ReceiverUserID = 3,
                            Status = "Pending",
                            Type = "Gift"
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("AvatarImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GreenPoints")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BirthDate = new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "juan.perez@example.com",
                            Gender = "Masculino",
                            GreenPoints = 250.00m,
                            IsActive = true,
                            Lastname = "Pérez",
                            Name = "Juan",
                            Nickname = "juanito123",
                            Password = "$2a$12$KIX9sQw9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAe",
                            RegistrationDate = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            BirthDate = new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "maria.gomez@example.com",
                            Gender = "Femenino",
                            GreenPoints = 180.50m,
                            IsActive = true,
                            Lastname = "Gómez",
                            Name = "María",
                            Nickname = "maryg",
                            Password = "$2a$12$7Hj3Lr9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAf",
                            RegistrationDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User"
                        },
                        new
                        {
                            UserId = 3,
                            BirthDate = new DateTime(1992, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carlos.lopez@example.com",
                            Gender = "Masculino",
                            GreenPoints = 300.75m,
                            IsActive = true,
                            Lastname = "López",
                            Name = "Carlos",
                            Nickname = "carlosl",
                            Password = "$2a$12$9Hk4Ms8k1m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAg",
                            RegistrationDate = new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "User"
                        });
                });

            modelBuilder.Entity("UserActivities", b =>
                {
                    b.Property<int>("ActivitiesParticipatedActivityId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsUserId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesParticipatedActivityId", "ParticipantsUserId");

                    b.HasIndex("ParticipantsUserId");

                    b.ToTable("UserActivities", (string)null);
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Project", b =>
                {
                    b.HasBaseType("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity");

                    b.Property<string>("ProjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Project");

                    b.HasData(
                        new
                        {
                            ActivityId = 1,
                            CreatorUserId = 1,
                            Description = "Creación de una cajita para guardar recuerdos.",
                            FinishDate = new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GreenPointsValue = 100.0m,
                            HomeImageUrl = "https://default-homepage.com",
                            IsActive = true,
                            StartDate = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Caja de recuerdos",
                            ProjectType = "Manualidades"
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.SustainableActivity", b =>
                {
                    b.HasBaseType("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("NameCollaborator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AddressId");

                    b.HasDiscriminator().HasValue("SustainableActivity");

                    b.HasData(
                        new
                        {
                            ActivityId = 2,
                            CreatorUserId = 2,
                            Description = "Actividad para plantar árboles en parques.",
                            FinishDate = new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GreenPointsValue = 75.0m,
                            HomeImageUrl = "https://default-homepage.com",
                            IsActive = true,
                            MaxParticipants = 30,
                            StartDate = new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Plantación de Árboles",
                            AddressId = 1,
                            NameCollaborator = "Parques y Jardines"
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Tutorial", b =>
                {
                    b.HasBaseType("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Tutorial");

                    b.HasData(
                        new
                        {
                            ActivityId = 3,
                            CreatorUserId = 3,
                            Description = "Tutorial para hacer pegamento casero con materiales reciclados.",
                            FinishDate = new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GreenPointsValue = 50.0m,
                            HomeImageUrl = "https://default-homepage.com",
                            IsActive = true,
                            MaxParticipants = 20,
                            StartDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pegamento Casero Reciclado",
                            Duration = 300
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Material", b =>
                {
                    b.HasBaseType("EcoScrapbookingAPI.Domain.Models.Abstracts.Resource");

                    b.HasDiscriminator().HasValue("Material");

                    b.HasData(
                        new
                        {
                            ResourceId = 3,
                            Brand = "PinturasVerdes",
                            Description = "Papel de muestrario de pinturas para reutilizar.",
                            Name = "Papel de muestrario de Pinturas",
                            OwnerUserId = 3,
                            Quantity = 50,
                            TransactionId = 2,
                            Type = "Reciclaje"
                        });
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Tool", b =>
                {
                    b.HasBaseType("EcoScrapbookingAPI.Domain.Models.Abstracts.Resource");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Warranty")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Tool");

                    b.HasData(
                        new
                        {
                            ResourceId = 1,
                            Brand = "HerramientasPro",
                            Description = "Pala resistente para jardinería.",
                            Name = "Pala",
                            OwnerUserId = 1,
                            Quantity = 10,
                            TransactionId = 1,
                            Type = "Jardinería",
                            Condition = "Nueva",
                            Warranty = true
                        },
                        new
                        {
                            ResourceId = 2,
                            Brand = "GardenMaster",
                            Description = "Rastrillo de alta calidad.",
                            Name = "Rastrillo",
                            OwnerUserId = 2,
                            Quantity = 5,
                            Type = "Jardinería",
                            Condition = "Usada",
                            Warranty = false
                        });
                });

            modelBuilder.Entity("ActivityResources", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesActivityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Abstracts.Resource", null)
                        .WithMany()
                        .HasForeignKey("ActivityResourcesResourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", "CreatorUser")
                        .WithMany("ActivitiesCreated")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Abstracts.Resource", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", "OwnerUser")
                        .WithMany("Resources")
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Transaction", "Transaction")
                        .WithMany("Resources")
                        .HasForeignKey("TransactionId");

                    b.Navigation("OwnerUser");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Address", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", "AddressUser")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");

                    b.Navigation("AddressUser");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Publication", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity", "Activity")
                        .WithMany("Publications")
                        .HasForeignKey("ActivityId");

                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Publication", "ReplyTo")
                        .WithMany("Replies")
                        .HasForeignKey("ReplyPostID");

                    b.Navigation("Activity");

                    b.Navigation("Author");

                    b.Navigation("ReplyTo");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Transaction", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", "InitiatorUser")
                        .WithMany("TransactionsInitiated")
                        .HasForeignKey("InitiatorUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", "ReceiverUser")
                        .WithMany("TransactionsReceived")
                        .HasForeignKey("ReceiverUserID");

                    b.Navigation("InitiatorUser");

                    b.Navigation("ReceiverUser");
                });

            modelBuilder.Entity("UserActivities", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesParticipatedActivityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EcoScrapbookingAPI.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.SustainableActivity", b =>
                {
                    b.HasOne("EcoScrapbookingAPI.Domain.Models.Address", "Ubication")
                        .WithMany("SustainableActivities")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ubication");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Abstracts.Activity", b =>
                {
                    b.Navigation("Publications");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Address", b =>
                {
                    b.Navigation("SustainableActivities");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Publication", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.Transaction", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("EcoScrapbookingAPI.Domain.Models.User", b =>
                {
                    b.Navigation("ActivitiesCreated");

                    b.Navigation("Addresses");

                    b.Navigation("Posts");

                    b.Navigation("Resources");

                    b.Navigation("TransactionsInitiated");

                    b.Navigation("TransactionsReceived");
                });
#pragma warning restore 612, 618
        }
    }
}
