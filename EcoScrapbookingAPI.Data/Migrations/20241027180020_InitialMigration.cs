using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GreenPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvatarImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInitiated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitiatorUserID = table.Column<int>(type: "int", nullable: false),
                    ReceiverUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_InitiatorUserID",
                        column: x => x.InitiatorUserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_ReceiverUserID",
                        column: x => x.ReceiverUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GreenPointsValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HomeImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCollaborator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageResourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    ResourceType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warranty = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID");
                    table.ForeignKey(
                        name: "FK_Resources_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    PublicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReplyPostID = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.PublicationID);
                    table.ForeignKey(
                        name: "FK_Publications_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId");
                    table.ForeignKey(
                        name: "FK_Publications_Publications_ReplyPostID",
                        column: x => x.ReplyPostID,
                        principalTable: "Publications",
                        principalColumn: "PublicationID");
                    table.ForeignKey(
                        name: "FK_Publications_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    ActivitiesParticipatedActivityId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => new { x.ActivitiesParticipatedActivityId, x.ParticipantsUserId });
                    table.ForeignKey(
                        name: "FK_UserActivities_Activities_ActivitiesParticipatedActivityId",
                        column: x => x.ActivitiesParticipatedActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserActivities_Users_ParticipantsUserId",
                        column: x => x.ParticipantsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityResources",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    ActivityResourcesResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityResources", x => new { x.ActivitiesActivityId, x.ActivityResourcesResourceId });
                    table.ForeignKey(
                        name: "FK_ActivityResources_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityResources_Resources_ActivityResourcesResourceId",
                        column: x => x.ActivityResourcesResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AvatarImageUrl", "BirthDate", "Email", "Gender", "GreenPoints", "IsActive", "Lastname", "Name", "Password", "RegistrationDate", "Role" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "juan.perez@example.com", "Masculino", 250.00m, true, "Pérez", "Juan", "$2a$12$KIX9sQw9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAe", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { 2, null, new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.gomez@example.com", "Femenino", 180.50m, true, "Gómez", "María", "$2a$12$7Hj3Lr9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAf", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "User" },
                    { 3, null, new DateTime(1992, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.lopez@example.com", "Masculino", 300.75m, true, "López", "Carlos", "$2a$12$9Hk4Ms8k1m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAg", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "ProjectType", "StartDate", "Title" },
                values: new object[] { 1, "Project", 1, "Creación de una cajita para guardar recuerdos.", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0m, "https://default-homepage.com", true, null, "Manualidades", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caja de recuerdos" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatorUserId", "Description", "Duration", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "StartDate", "Title" },
                values: new object[] { 3, "Tutorial", 3, "Tutorial para hacer pegamento casero con materiales reciclados.", 300, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0m, "https://default-homepage.com", true, 20, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegamento Casero Reciclado" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "ContactPhone", "Country", "Description", "Number", "State", "Street", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "CiudadA", "555-1234", "PaísA", "Residencia Principal", "123", "EstadoA", "Calle Falsa", 1, "10001" },
                    { 2, "CiudadB", "555-5678", "PaísB", "Oficina", "742", "EstadoB", "Avenida Siempre Viva", 2, "20002" },
                    { 3, "CiudadC", "555-9012", "PaísC", "Lugar de Eventos", "456", "EstadoC", "Boulevard de los Sueños", 3, "30003" }
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PublicationID", "ActivityId", "AuthorId", "Category", "Description", "ImagePostUrl", "ReplyPostID", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, "Reciclaje", "Métodos efectivos para reciclar en casa.", null, null, "Consejos para Reciclar" },
                    { 2, null, 2, "Jardinería", "Cómo y dónde plantar árboles.", null, null, "Plantando Árboles" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Condition", "Description", "ImageResourceUrl", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type", "Warranty" },
                values: new object[] { 2, "GardenMaster", "Usada", "Rastrillo de alta calidad.", null, "Rastrillo", 2, 5, "Tool", null, "Jardinería", false });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "DateCompleted", "DateInitiated", "InitiatorUserID", "ReceiverUserID", "Status", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Completed", "Exchange" },
                    { 2, null, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "Pending", "Gift" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "AddressId", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "NameCollaborator", "StartDate", "Title" },
                values: new object[] { 2, "SustainableActivity", 1, 2, "Actividad para plantar árboles en parques.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0m, "https://default-homepage.com", true, 30, "Parques y Jardines", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plantación de Árboles" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PublicationID", "ActivityId", "AuthorId", "Category", "Description", "ImagePostUrl", "ReplyPostID", "Title" },
                values: new object[,]
                {
                    { 3, null, 3, "Jardinería", "¡Me encantaría participar!", null, 2, "Respuesta: Plantando Árboles" },
                    { 4, 1, 1, "Paso de proyecto", "Hemos terminado de cortar las piezas.", "https://image-post.com", null, "Avance: Caja de recuerdos" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Condition", "Description", "ImageResourceUrl", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type", "Warranty" },
                values: new object[] { 1, "HerramientasPro", "Nueva", "Pala resistente para jardinería.", null, "Pala", 1, 10, "Tool", 1, "Jardinería", true });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Description", "ImageResourceUrl", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type" },
                values: new object[] { 3, "PinturasVerdes", "Papel de muestrario de pinturas para reutilizar.", null, "Papel de muestrario de Pinturas", 3, 50, "Material", 2, "Reciclaje" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AddressId",
                table: "Activities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatorUserId",
                table: "Activities",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityResources_ActivityResourcesResourceId",
                table: "ActivityResources",
                column: "ActivityResourcesResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ActivityId",
                table: "Publications",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AuthorId",
                table: "Publications",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ReplyPostID",
                table: "Publications",
                column: "ReplyPostID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_OwnerUserId",
                table: "Resources",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_TransactionId",
                table: "Resources",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InitiatorUserID",
                table: "Transactions",
                column: "InitiatorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverUserID",
                table: "Transactions",
                column: "ReceiverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_ParticipantsUserId",
                table: "UserActivities",
                column: "ParticipantsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityResources");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
