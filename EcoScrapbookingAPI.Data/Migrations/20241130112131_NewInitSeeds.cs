using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewInitSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "MaxParticipants",
                value: 4);

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatedAt", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "ProjectType", "StartDate", "Title" },
                values: new object[,]
                {
                    { 2, "Project", new DateTime(2024, 2, 1, 11, 15, 25, 0, DateTimeKind.Unspecified), 1, "Diseño de un álbum personalizado con fotos de vacaciones.", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0m, "https://default-homepage.com", true, 1, "Álbumes", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Álbum de Vacaciones" },
                    { 3, "Project", new DateTime(2024, 3, 1, 9, 30, 45, 0, DateTimeKind.Unspecified), 1, "Creación de sellos únicos para decorar álbumes.", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0m, "https://default-homepage.com", true, null, "Decoración", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sellos Personalizados" },
                    { 4, "Project", new DateTime(2024, 4, 1, 10, 10, 10, 0, DateTimeKind.Unspecified), 2, "Diseño de tarjetas personalizadas para cumpleaños.", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0m, "https://default-homepage.com", true, null, "Tarjetas", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarjetas de Cumpleaños" },
                    { 5, "Project", new DateTime(2024, 4, 15, 12, 20, 30, 0, DateTimeKind.Unspecified), 2, "Creación de marcos decorativos con materiales reciclados.", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0m, "https://default-homepage.com", true, 2, "Decoración", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marco Decorativo" },
                    { 6, "Project", new DateTime(2024, 5, 1, 14, 30, 40, 0, DateTimeKind.Unspecified), 2, "Diseño de un álbum especial para graduación.", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0m, "https://default-homepage.com", true, 3, "Álbumes", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Álbum de Graduación" },
                    { 7, "Project", new DateTime(2024, 6, 1, 11, 45, 50, 0, DateTimeKind.Unspecified), 3, "Transformar latas de aluminio en decoraciones artísticas.", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.0m, "https://default-homepage.com", true, null, "Decoración", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decoración con Latas" },
                    { 8, "Project", new DateTime(2024, 6, 15, 13, 55, 0, 0, DateTimeKind.Unspecified), 3, "Creación de collages artísticos con recortes de revistas.", new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0m, "https://default-homepage.com", true, 2, "Collages", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collage de Recortes" },
                    { 9, "Project", new DateTime(2024, 7, 1, 15, 5, 10, 0, DateTimeKind.Unspecified), 3, "Diseño de un álbum temático inspirado en la primavera.", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0m, "https://default-homepage.com", true, 10, "Álbumes", new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Album Temático de Primavera" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "AddressId", "CreatedAt", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "NameCollaborator", "StartDate", "Title" },
                values: new object[,]
                {
                    { 19, "SustainableActivity", 1, new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Recolecta papel reciclable para proyectos de scrapbooking.", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0m, "https://default-homepage.com", true, 20, "EcoMadrid", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recolección de Papel" },
                    { 20, "SustainableActivity", 2, new DateTime(2024, 2, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, "Recoge materiales desechables para reutilización en decoraciones.", new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.0m, "https://default-homepage.com", true, 25, "EcoBarcelona", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recogida de Materiales Desechables" },
                    { 21, "SustainableActivity", 3, new DateTime(2024, 3, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, "Recolecta botellas de plástico para proyectos creativos.", new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0m, "https://default-homepage.com", true, 15, "EcoValencia", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recolección de Botellas" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatedAt", "CreatorUserId", "Description", "Duration", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "StartDate", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 31, "Tutorial", new DateTime(2024, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tutorial para diseñar un álbum utilizando materiales reciclados.", 45, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0m, "https://default-homepage.com", true, 2, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cómo Crear un Álbum de Fotos Reciclado", "https://tutorials.com/album-reciclado" },
                    { 32, "Tutorial", new DateTime(2024, 2, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, "Aprende a decorar tus proyectos usando cápsulas de café recicladas.", 30, new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0m, "https://default-homepage.com", true, 1, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decoración con Cápsulas de Café", "https://tutorials.com/capsulas-de-cafe" },
                    { 33, "Tutorial", new DateTime(2024, 3, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tutorial para diseñar tarjetas únicas usando materiales reciclados.", 50, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0m, "https://default-homepage.com", true, 3, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creación de Tarjetas con Materiales Reutilizados", "https://tutorials.com/tarjetas-reutilizadas" },
                    { 34, "Tutorial", new DateTime(2024, 4, 10, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, "Aprende a crear marcos decorativos utilizando materiales reciclados.", 55, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.0m, "https://default-homepage.com", true, null, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diseño de Marcos con Materiales Reciclados", "https://tutorials.com/marcos-reciclados" },
                    { 35, "Tutorial", new DateTime(2024, 5, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 3, "Tutorial para diseñar collages artísticos utilizando recortes de revistas.", 60, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0m, "https://default-homepage.com", true, 2, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creación de Collages con Recortes de Revistas", "https://tutorials.com/collages-revistados" },
                    { 36, "Tutorial", new DateTime(2024, 6, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 3, "Aprende a reutilizar latas de aluminio en proyectos de decoración.", 50, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.0m, "https://default-homepage.com", true, null, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transformación de Latas en Decoraciones", "https://tutorials.com/latas-decorativas" }
                });

            migrationBuilder.InsertData(
                table: "ActivityResources",
                columns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1,
                columns: new[] { "City", "Country", "State", "ZipCode" },
                values: new object[] { "Madrid", "España", "Madrid", "28001" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2,
                columns: new[] { "City", "Country", "State", "UserId", "ZipCode" },
                values: new object[] { "Barcelona", "España", "Cataluña", 1, "08002" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3,
                columns: new[] { "City", "ContactPhone", "Country", "Description", "Number", "State", "Street", "UserId", "ZipCode" },
                values: new object[] { "Valencia", "555-2345", "España", "Residencia Principal", "45", "Valencia", "Gran Vía", 2, "46001" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "ContactPhone", "Country", "Description", "Number", "State", "Street", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 4, "Sevilla", "555-6789", "España", "Oficina", "789", "Andalucía", "Paseo de la Castellana", 2, "41001" },
                    { 5, "Bilbao", "555-3456", "España", "Residencia Principal", "10", "País Vasco", "Calle de Alcalá", 3, "48001" },
                    { 6, "Zaragoza", "555-7890", "España", "Oficina", "321", "Aragón", "Ronda de Sant Antoni", 3, "50001" }
                });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "¡Hola a todos!\r\n\r\n          Combinar reciclaje con decoración es una excelente forma de ser creativo y sostenible. Aquí algunos consejos:\r\n\r\n          Reutiliza Frascos: Transforma frascos de vidrio en elegantes porta-velas.\r\n          Papel Reciclado: Usa papel reciclado para crear pósters o murales.\r\n          Muebles Upcycled: Restaura muebles viejos con pintura ecológica.\r\n          Adornos Naturales: Incorpora elementos como ramas o piedras en tus decoraciones.\r\n          ¡Anímate a decorar de manera sostenible!", "Consejos para Reciclar mientras Decoras" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 2,
                columns: new[] { "AuthorId", "Category", "CreatedAt", "Description", "Title" },
                values: new object[] { 1, "Scrapbooking", new DateTime(2023, 5, 10, 14, 30, 25, 0, DateTimeKind.Unspecified), "¡Bienvenidos!\r\n\r\n          Iniciar tu primer álbum de scrapbooking es sencillo con estos pasos:\r\n\r\n          Selecciona un Álbum: Elige uno que se adapte a tus necesidades.\r\n          Reúne Materiales: Fotos, papel decorativo, y adornos.\r\n          Diseña las Páginas: Planifica la disposición antes de pegar.\r\n          Añade Detalles: Escribe notas o utiliza stickers para personalizar.\r\n          ¡Disfruta creando tus recuerdos!", "Creando tu Primer Álbum" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 3,
                columns: new[] { "AuthorId", "Category", "CreatedAt", "Description" },
                values: new object[] { 1, "Respuesta", new DateTime(2023, 5, 12, 16, 45, 30, 0, DateTimeKind.Unspecified), "¡Hola!\r\n\r\n          Me encanta tu guía para 'Creando tu Primer Álbum'. ¡Gran iniciativa! Me gustaría integrar elementos naturales como hojas secas en mis páginas.\r\n\r\n          ¿Has considerado usar materiales reciclados en tus proyectos de scrapbooking ? ¡Sería genial compartir ideas!\r\n\r\n          ¡Gracias por inspirar!" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 4,
                columns: new[] { "ActivityId", "AuthorId", "Category", "CreatedAt", "Description", "ImagePostUrl", "Title" },
                values: new object[] { null, 2, "Jardinería", new DateTime(2023, 4, 8, 12, 15, 30, 0, DateTimeKind.Unspecified), "¡Hola jardineros!\r\n\r\n          Crear una maceta reciclada es fácil y ecológico:\r\n\r\n          Materiales: Usa botellas de plástico o latas.\r\n          Preparación: Haz agujeros para el drenaje.\r\n          Decoración: Pinta o decora a tu gusto.\r\n          Planta: Añade tierra y tus plantas favoritas.\r\n          ¡Disfruta de tus creaciones verdes!", null, "Maceta fabricada con Material Reciclado" });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PublicationId", "ActivityId", "AuthorId", "Category", "CreatedAt", "Description", "ImagePostUrl", "ReplyPostID", "Title" },
                values: new object[,]
                {
                    { 5, null, 2, "Decoración", new DateTime(2023, 5, 18, 11, 25, 40, 0, DateTimeKind.Unspecified), "¡Hola creativos!\r\n\r\n          Transformar materiales reciclados en decoraciones es muy sencillo:\r\n\r\n          Latas Pintadas: Úsalas como floreros o porta velas.\r\n          CDs Viejos: Crea mosaicos brillantes para espejos.\r\n          Botellas de Vidrio: Transfórmalas en lámparas únicas.\r\n          Papel Reciclado: Diseña murales o cuadros decorativos.\r\n          ¡Dale una segunda vida a tus materiales!", null, null, "Ideas para Decorar con Material Reciclado" },
                    { 6, null, 2, "Respuesta", new DateTime(2023, 5, 20, 13, 35, 50, 0, DateTimeKind.Unspecified), " Tu guía para 'Creando tu Primer Álbum' es ¡excelente! Gracias por compartir pasos tan claros.\r\n\r\n          Estoy empezando y tus consejos sobre la organización me han sido muy útiles.\r\n\r\n          ¿Tienes algún truco para mantener todo en orden ? ¡Agradecería mucho tus sugerencias!\r\n\r\n          ¡Gracias nuevamente!", null, 2, "Respuesta: Creando tu Primer Álbum" },
                    { 7, null, 3, "Jardinería", new DateTime(2023, 4, 12, 15, 30, 20, 0, DateTimeKind.Unspecified), " Excelente idea sobre las macetas recicladas. Usar materiales impermeables es clave para la durabilidad.\r\n\r\n          Te recomiendo utilizar botellas de plástico resistentes o latas tratadas para evitar filtraciones.\r\n\r\n          ¿Has probado algún otro material? ¡Me encantaría conocer tu experiencia!\r\n\r\n          ¡Saludos!", null, 4, "Usar materiales impermeables para la maceta" },
                    { 8, null, 3, "Scrapbooking", new DateTime(2023, 6, 5, 10, 50, 10, 0, DateTimeKind.Unspecified), "¡Hola scrapbookers!\r\n\r\n          Lleva tus álbumes al siguiente nivel con estas técnicas avanzadas:\r\n\r\n          Capas de Transparente: Añade profundidad superponiendo papeles translúcidos.\r\n          Elementos 3D: Incorpora botones y cintas para un efecto tridimensional.\r\n          Integración Digital: Utiliza impresiones de alta calidad y collage digital.\r\n          Caligrafía Personalizada: Escribe mensajes con estilos de letra únicos.\r\n          ¡Experimenta y crea obras únicas!", null, null, "Técnicas Avanzadas de Scrapbooking" }
                });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "ImageResourceUrl", "Name", "Quantity", "TransactionId", "Type" },
                values: new object[] { "CraftMaster", "Tijeras ideales para cortes detallados en scrapbooking.", "https://image-tijeras.com", "Tijeras de precisión", 5, null, "Corte" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ImageResourceUrl", "Name", "OwnerUserId", "Quantity", "Type" },
                values: new object[] { "SharpEdge", "Cúter de alta precisión para recortes complejos.", "https://image-Cuter.com", "Cúter", 1, 3, "Corte" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Condition", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type", "Warranty" },
                values: new object[,]
                {
                    { 3, "MeasurePro", "Nueva", "Regla de 30 cm para medidas exactas.", "https://image-Regla.com", true, "Regla metálica", 1, 10, "Tool", 2, "Medición", true },
                    { 4, "GlueIt", "Nueva", "Pegamento en barra sin tóxicos para scrapbooking.", "https://image-Pegamento.com", true, "Pegamento en barra", 2, 20, "Tool", null, "Adhesivo", false },
                    { 5, "HotGlue", "Nueva", "Pistola de silicona para fijar materiales.", "https://image-Pistola.com", true, "Pistola de silicona", 2, 2, "Tool", null, "Adhesivo", true },
                    { 6, "DecorTape", "Usada", "Cinta adhesiva con diseños para decoración.", "https://image-Cinta.com", true, "Cinta adhesiva decorativa", 2, 15, "Tool", null, "Adhesivo", false },
                    { 7, "StampMaster", "Nueva", "Set de sellos de goma para personalizar álbumes.", "https://image-Sellos.com", true, "Sellos de goma", 3, 10, "Tool", null, "Decoración", true }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type" },
                values: new object[,]
                {
                    { 19, "EcoCaps", "Cápsulas de café recicladas para crear decoraciones.", "https://image-Capsulas.com", true, "Cápsulas de café usadas", 1, 100, "Material", 2, "Reciclaje" },
                    { 20, "EcoBox", "Cajas de TetraBrik recicladas para proyectos de scrapbooking.", "https://image-Cajas.com", true, "Cajas de TetraBrik", 1, 50, "Material", null, "Reciclaje" },
                    { 21, "RePaper", "Papel reciclado para crear fondos y decoraciones.", "https://image-Papel.com", true, "Papel reciclado", 1, 200, "Material", null, "Reciclaje" }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DateInitiated", "IsActive" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                columns: new[] { "DateInitiated", "InitiatorUserID", "Status" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Accepted" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "DateCompleted", "DateInitiated", "InitiatorUserID", "IsActive", "ReceiverUserID", "Status", "Type" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1, "Completed", "Exchange" },
                    { 4, null, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 3, "Pending", "Gift" },
                    { 5, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, 2, "Rejected", "Exchange" }
                });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$99MBCG4.LMiInLKOfCcdEO5nWe8jLTK6nljDDj2n4t3XJA7dnabEy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$AFV3kuudAhiI5hv47AhlTOwYrZqdHdVqN.P/b7YnffuyrzToD/Fp.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$WxwwQl/LpTMYJ/KSFLgIKODVcB3CZ.wHm4U2XYNCpqOw37PkxOPzC");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AvatarImageUrl", "BirthDate", "Email", "Gender", "GreenPoints", "IsActive", "Lastname", "Name", "Nickname", "Password", "RegistrationDate", "Role" },
                values: new object[,]
                {
                    { 4, "https://luciaf.com/avatar.jpg", new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucia.fernandez@example.com", "Femenino", 220.00m, true, "Fernández", "Lucía", "luciaf", "$2a$11$C.yc/.xwtwvNgTnmNTmJYe6nAho5J3mMfjj6g2ATwzpdDILpj27ua", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "User" },
                    { 5, "https://miguelr.com/avatar.jpg", new DateTime(1995, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "miguel.ramirez@example.com", "Masculino", 190.25m, true, "Ramírez", "Miguel", "miguelr", "$2a$11$UV21bN3624LeJlCouyhjKe1RbDMvon/fFOgYebm/Waz8Iuq5G4VPm", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "User" },
                    { 6, "https://saraq.com/avatar.jpg", new DateTime(1993, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.quintero@example.com", "Femenino", 210.50m, true, "Quintero", "Sara", "saraq", "$2a$11$cRYjbtrE0l/hFwiALzH3quaWJKgVNd6OlZrnX82jl0PTnskHYOsWu", new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatedAt", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "ProjectType", "StartDate", "Title" },
                values: new object[,]
                {
                    { 10, "Project", new DateTime(2024, 8, 1, 10, 30, 20, 0, DateTimeKind.Unspecified), 4, "Crear marcos decorativos utilizando botones reciclados.", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0m, "https://default-homepage.com", true, null, "Decoración", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcos con Botones" },
                    { 11, "Project", new DateTime(2024, 8, 15, 12, 40, 30, 0, DateTimeKind.Unspecified), 4, "Diseño de tarjetas de aniversario con materiales reutilizados.", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0m, "https://default-homepage.com", true, null, "Tarjetas", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarjetas de Aniversario" },
                    { 12, "Project", new DateTime(2024, 9, 1, 14, 50, 40, 0, DateTimeKind.Unspecified), 4, "Creación de un álbum para conservar recuerdos especiales.", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0m, "https://default-homepage.com", true, 5, "Álbumes", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Album de Recuerdos" },
                    { 13, "Project", new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, "Diseño de sobres personalizados con papel kraft reciclado.", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0m, "https://default-homepage.com", true, null, "Tarjetas", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sobres Personalizados" },
                    { 14, "Project", new DateTime(2024, 10, 15, 12, 10, 10, 0, DateTimeKind.Unspecified), 5, "Creación de cintas decorativas utilizando materiales reciclados.", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0m, "https://default-homepage.com", true, null, "Decoración", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cintas Decorativas" },
                    { 15, "Project", new DateTime(2024, 11, 1, 14, 20, 20, 0, DateTimeKind.Unspecified), 5, "Crear sellos personalizados utilizando recortes de etiquetas.", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0m, "https://default-homepage.com", true, null, "Decoración", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sellos con Recortes" },
                    { 16, "Project", new DateTime(2024, 12, 1, 10, 30, 30, 0, DateTimeKind.Unspecified), 6, "Creación de mosaicos brillantes utilizando CDs reciclados.", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0m, "https://default-homepage.com", true, 3, "Decoración", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mosaicos con CDs" },
                    { 17, "Project", new DateTime(2024, 12, 15, 12, 40, 40, 0, DateTimeKind.Unspecified), 6, "Transformar botellas de vidrio en piezas decorativas.", new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.0m, "https://default-homepage.com", true, null, "Decoración", new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decoración con Botellas de Vidrio" },
                    { 18, "Project", new DateTime(2025, 1, 1, 14, 50, 50, 0, DateTimeKind.Unspecified), 6, "Diseño de un álbum con detalles brillantes utilizando CDs.", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0m, "https://default-homepage.com", true, 2, "Álbumes", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Álbum Brillante" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "AddressId", "CreatedAt", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "NameCollaborator", "StartDate", "Title" },
                values: new object[,]
                {
                    { 22, "SustainableActivity", 4, new DateTime(2024, 4, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, "Recoge tapas de botellas para decorar proyectos.", new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.0m, "https://default-homepage.com", true, 18, "EcoSevilla", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recogida de Tapas de Botellas" },
                    { 23, "SustainableActivity", 5, new DateTime(2024, 5, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), 3, "Recolecta latas de aluminio para reutilización.", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0m, "https://default-homepage.com", true, 20, "EcoBilbao", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recolección de Latas" },
                    { 24, "SustainableActivity", 6, new DateTime(2024, 6, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), 3, "Recoge papeles de revistas para crear collages.", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.0m, "https://default-homepage.com", true, 22, "EcoZaragoza", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recogida de Papeles de Revistas" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatedAt", "CreatorUserId", "Description", "Duration", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "StartDate", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 37, "Tutorial", new DateTime(2024, 7, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 4, "Tutorial para incorporar botones reciclados en tus proyectos.", 40, new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0m, "https://default-homepage.com", true, 2, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uso Creativo de Botones en Scrapbooking", "https://tutorials.com/botones-scrapbooking" },
                    { 38, "Tutorial", new DateTime(2024, 8, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), 4, "Aprende a diseñar cintas decorativas usando materiales reciclados.", 45, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.0m, "https://default-homepage.com", true, 1, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creación de Cintas Decorativas Recicladas", "https://tutorials.com/cintas-decorativas" },
                    { 39, "Tutorial", new DateTime(2024, 9, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), 5, "Tutorial para crear sellos únicos para tus álbumes.", 50, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0m, "https://default-homepage.com", true, 2, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diseño de Sellos Personalizados", "https://tutorials.com/sellos-personalizados" },
                    { 40, "Tutorial", new DateTime(2024, 10, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), 5, "Aprende a diseñar sobres personalizados usando papel kraft reciclado.", 45, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.0m, "https://default-homepage.com", true, null, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creación de Sobres con Papel Kraft", "https://tutorials.com/sobres-papel-kraft" },
                    { 41, "Tutorial", new DateTime(2024, 11, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, "Tutorial para diseñar mosaicos brillantes utilizando CDs reciclados.", 60, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0m, "https://default-homepage.com", true, null, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creación de Mosaicos con CDs", "https://tutorials.com/mosaicos-cds" },
                    { 42, "Tutorial", new DateTime(2024, 12, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), 6, "Aprende a reutilizar botellas de vidrio en tus proyectos de scrapbooking.", 50, new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.0m, "https://default-homepage.com", true, 1, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decoración con Botellas de Vidrio", "https://tutorials.com/botellas-decorativas" }
                });

            migrationBuilder.InsertData(
                table: "ActivityResources",
                columns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                values: new object[,]
                {
                    { 1, 19 },
                    { 2, 2 },
                    { 2, 20 },
                    { 4, 4 },
                    { 31, 3 },
                    { 31, 20 },
                    { 33, 6 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "ContactPhone", "Country", "Description", "Number", "State", "Street", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 7, "Málaga", "555-4567", "España", "Residencia Principal", "55", "Andalucía", "Calle de las Flores", 4, "29001" },
                    { 8, "Murcia", "555-8901", "España", "Taller", "88", "Región de Murcia", "Avenida del Mediterráneo", 4, "30001" },
                    { 9, "Granada", "555-5678", "España", "Residencia Principal", "200", "Andalucía", "Calle Mayor", 5, "18001" },
                    { 10, "Córdoba", "555-9012", "España", "Estudio", "150", "Andalucía", "Plaza de España", 5, "14001" },
                    { 11, "Alicante", "555-6789", "España", "Residencia Principal", "77", "Comunidad Valenciana", "Calle del Sol", 6, "03001" },
                    { 12, "Las Palmas", "555-0123", "España", "Oficina", "99", "Canarias", "Avenida de la Paz", 6, "35001" }
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PublicationId", "ActivityId", "AuthorId", "Category", "CreatedAt", "Description", "ImagePostUrl", "ReplyPostID", "Title" },
                values: new object[,]
                {
                    { 9, null, 3, "Respuesta", new DateTime(2023, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), "¡Ey!\r\n\r\n          ¡Muy creativas las ideas para decorar con materiales reciclados! Me inspiraron a probar las lámparas de botellas de vidrio.\r\n\r\n          Gracias por compartir tus innovadoras propuestas.\r\n\r\n          ¿Tienes alguna otra idea para reutilizar materiales cotidianos? ¡Me encantaría saber más!\r\n\r\n          ¡Saludos!", null, 5, "Respuesta: Ideas para Decorar con Material Reciclado" },
                    { 10, null, 4, "Decoración", new DateTime(2023, 6, 15, 9, 15, 45, 0, DateTimeKind.Unspecified), "¡Hola creativos!\r\n\r\n          Los botones reciclados son perfectos para decorar:\r\n\r\n          Collares y Pulseras: Crea accesorios únicos ensartando botones.\r\n          Cuadros Decorativos: Forma patrones o mandalas pegando botones en un lienzo.\r\n          Candelabros: Decora portavelas con botones para un toque colorido.\r\n          Adornos para Espejos: Pega botones alrededor del marco para personalizar.\r\n          ¡Deja volar tu imaginación con botones reciclados!\r\n\r\n          ", null, null, "Cómo Utilizar Botones Reciclados" },
                    { 11, null, 4, "Scrapbooking", new DateTime(2023, 6, 20, 14, 25, 55, 0, DateTimeKind.Unspecified), "¡Hola scrapbookers!\r\n\r\n          Al crear tarjetas personalizadas, un buen consejo es enfocarse en la simplicidad:\r\n\r\n          Elige un Tema: Define el motivo central de la tarjeta.\r\n          Usa Materiales Reciclados: Integra papel reciclado o telas viejas.\r\n          Añade Detalles: Usa botones, cintas o stickers para embellecer.\r\n          Mantén la Coherencia: Asegúrate de que todos los elementos combinen bien.\r\n          ¡Crea tarjetas únicas y significativas!", null, null, "Consejo a la hora de crear Tarjetas Personalizadas" },
                    { 12, null, 4, "Respuesta", new DateTime(2023, 6, 22, 16, 35, 5, 0, DateTimeKind.Unspecified), "¡Buenasss!\r\n\r\n          ¡Fantásticas técnicas de scrapbooking! Estoy emocionado por probar las capas transparentes y los elementos 3D en mi próximo álbum.\r\n\r\n          Gracias por compartir estos métodos avanzados.\r\n\r\n          ¿Tienes algún consejo para mantener todo bien organizado mientras aplico estas técnicas?\r\n\r\n          ¡Saludos!", null, 8, "Respuesta: Técnicas Avanzadas de Scrapbooking" },
                    { 13, null, 5, "Reciclaje", new DateTime(2023, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "¡Hola a todos!\r\n\r\n          El papel reciclado ofrece múltiples beneficios:\r\n\r\n          Conserva Recursos Naturales: Reduce la necesidad de talar árboles.\r\n          Ahorra Energía: La producción consume menos energía.\r\n          Reduce Residuos: Disminuye la cantidad de basura en vertederos.\r\n          Menor Emisión de CO₂: Contribuye a combatir el cambio climático.\r\n          ¡Optar por papel reciclado es una decisión ecológica!", null, null, "Beneficios del Papel Reciclado" },
                    { 14, null, 5, "Scrapbooking", new DateTime(2023, 7, 5, 11, 10, 10, 0, DateTimeKind.Unspecified), "¡Hola scrapbookers!\r\n\r\n          Diseñar sellos personalizados es sencillo:\r\n\r\n          Materiales: Goma para sellos, bloques de madera, tinta.\r\n          Diseña: Dibuja tu diseño en la goma.\r\n          Graba: Usa herramientas para esculpir el diseño.\r\n          Monta: Adhiere la goma al bloque de madera.\r\n          Prueba: Realiza una prueba de estampado.\r\n          ¡Crea sellos únicos para tus proyectos!", null, null, "Creando Sellos Personalizados" },
                    { 16, null, 6, "Decoración", new DateTime(2023, 7, 15, 9, 30, 30, 0, DateTimeKind.Unspecified), "¡Hola artesanos!\r\n\r\n          Reutiliza tus CDs viejos con estas ideas:\r\n\r\n          Mosaicos: Crea patrones brillantes en marcos de fotos.\r\n          Móviles: Cuelga CDs para un efecto luminoso.\r\n          Espejos Decorados: Decora marcos con CDs para reflejar luz.\r\n          Arte de Pared: Forma diseños abstractos pegando CDs en lienzos.\r\n          ¡Dale nueva vida a tus CDs reciclados!", null, null, "Uso Creativo de CDs Viejos" },
                    { 17, null, 6, "Scrapbooking", new DateTime(2023, 7, 20, 14, 40, 40, 0, DateTimeKind.Unspecified), "¡Hola scrapbookers!\r\n\r\n          Integra botellas de vidrio recicladas en tus álbumes con estas ideas:\r\n\r\n          Insertos Transparentes: Guarda pequeños recuerdos dentro de botellas.\r\n          Fondos Decorativos: Usa botellas como fondo para fotos.\r\n          Detalles: Añade fragmentos rotos para embellecer las páginas.\r\n          Temas Específicos: Dedica páginas a eventos usando botellas relacionadas.\r\n          ¡Añade elegancia con botellas de vidrio recicladas!", null, null, "Incorporando Botellas de Vidrio" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Condition", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type", "Warranty" },
                values: new object[,]
                {
                    { 9, "ColorArt", "Nueva", "Plumones permanentes de varios colores.", "https://image-Plumones.com", true, "Plumones de colores", 3, 50, "Tool", 5, "Dibujo", false },
                    { 12, "PunchMaster", "Nueva", "Troqueladora para formas personalizadas.", "https://image-Troqueladora.com", true, "Troqueladora", 4, 1, "Tool", null, "Corte", true },
                    { 13, "FlexiMeasure", "Nueva", "Regla flexible para curvas y diseños complejos.", "https://image-Regla.com", true, "Regla flexible", 5, 10, "Tool", null, "Medición", false },
                    { 14, "FineLine", "Nueva", "Rotuladores finos para detalles precisos.", "https://image-Rotuladores.com", true, "Rotuladores finos", 5, 100, "Tool", null, "Dibujo", false },
                    { 17, "PrecisionCompass", "Nueva", "Compás de precisión para diseños circulares.", "https://image-Compas.com", true, "Compás de precisión", 6, 15, "Tool", null, "Medición", false },
                    { 18, "StickerArt", "Nueva", "Pegatinas decorativas para personalizar álbumes.", "https://image-Pegatinas.com", true, "Pegatinas decorativas", 6, 200, "Tool", null, "Decoración", false }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type" },
                values: new object[,]
                {
                    { 22, "EcoBottle", "Botellas de plástico recicladas para crear accesorios.", "https://image-Botellas.com", false, "Botellas de plástico", 2, 80, "Material", 5, "Reciclaje" },
                    { 23, "PackCard", "Cartones de embalaje reciclados para bases de álbumes.", "https://image-Cartones.com", true, "Cartones de embalaje", 2, 150, "Material", 4, "Reciclaje" },
                    { 24, "EcoCap", "Tapas de botellas recicladas para decoraciones diversas.", "https://image-Tapas.com", false, "Tapas de botellas", 2, 300, "Material", 5, "Reciclaje" },
                    { 29, "OldMag", "Revistas viejas para recortes y collages.", "https://image-Revistas.com", true, "Revistas viejas", 4, 100, "Material", null, "Reciclaje" },
                    { 30, "ReuseButtons", "Botones reutilizados para adornar álbumes.", "https://image-Botones.com", true, "Botones reutilizados", 4, 400, "Material", null, "Reciclaje" },
                    { 33, "LabelReuse", "Etiquetas de productos recicladas para personalizar.", "https://image-Etiquetas.com", true, "Etiquetas de productos", 5, 500, "Material", null, "Reciclaje" },
                    { 35, "GlassReuse", "Botellas de vidrio pequeñas para crear decoraciones.", "https://image-Botellas.com", true, "Botellas de vidrio pequeñas", 6, 60, "Material", null, "Reciclaje" },
                    { 36, "OldCD", "CDs viejos para crear mosaicos y decoraciones brillantes.", "https://image-CDs.com", true, "CDs viejos", 6, 100, "Material", null, "Reciclaje" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "DateCompleted", "DateInitiated", "InitiatorUserID", "IsActive", "ReceiverUserID", "Status", "Type" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 5, "Accepted", "Gift" },
                    { 7, null, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 3, "Accepted", "Exchange" },
                    { 8, null, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 2, "Pending", "Gift" },
                    { 9, null, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, null, "Pending", "Exchange" },
                    { 10, null, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 6, "Pending", "Gift" },
                    { 11, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, 5, "Completed", "Exchange" },
                    { 12, null, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true, 1, "Pending", "Gift" }
                });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 5, 2 },
                    { 6, 4 },
                    { 6, 5 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 5 },
                    { 19, 4 },
                    { 19, 5 },
                    { 19, 6 },
                    { 21, 1 },
                    { 35, 4 }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "AddressId", "CreatedAt", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "NameCollaborator", "StartDate", "Title" },
                values: new object[,]
                {
                    { 25, "SustainableActivity", 7, new DateTime(2024, 7, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 4, "Recolecta botones para proyectos de decoración.", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.0m, "https://default-homepage.com", true, 25, "EcoMálaga", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recolección de Botones" },
                    { 26, "SustainableActivity", 8, new DateTime(2024, 8, 15, 16, 30, 0, 0, DateTimeKind.Unspecified), 4, "Recoge cintas recicladas para reutilización en proyectos.", new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.0m, "https://default-homepage.com", true, 20, "EcoMurcia", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recogida de Cintas" },
                    { 27, "SustainableActivity", 9, new DateTime(2024, 9, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), 5, "Recoge etiquetas de productos para personalización.", new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0m, "https://default-homepage.com", true, 18, "EcoGranada", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recolección de Etiquetas" },
                    { 28, "SustainableActivity", 10, new DateTime(2024, 10, 15, 18, 30, 0, 0, DateTimeKind.Unspecified), 5, "Recoge cintas recicladas para reutilización en decoraciones.", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.0m, "https://default-homepage.com", true, 20, "EcoCórdoba", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recogida de Cintas Recicladas" },
                    { 29, "SustainableActivity", 11, new DateTime(2024, 11, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, "Recolecta CDs viejos para proyectos de mosaicos.", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0m, "https://default-homepage.com", true, 15, "EcoAlicante", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recolección de CDs" },
                    { 30, "SustainableActivity", 12, new DateTime(2024, 12, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), 6, "Recoge botellas de vidrio pequeñas para reutilización.", new DateTime(2024, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.0m, "https://default-homepage.com", true, 18, "EcoLasPalmas", new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recogida de Botellas de Vidrio" }
                });

            migrationBuilder.InsertData(
                table: "ActivityResources",
                columns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                values: new object[,]
                {
                    { 4, 22 },
                    { 7, 9 },
                    { 33, 23 }
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PublicationId", "ActivityId", "AuthorId", "Category", "CreatedAt", "Description", "ImagePostUrl", "ReplyPostID", "Title" },
                values: new object[,]
                {
                    { 15, null, 5, "Respuesta", new DateTime(2023, 7, 7, 13, 20, 20, 0, DateTimeKind.Unspecified), "¡Hola [Usuario 4]!\r\n\r\n          Seguí tu consejo para crear tarjetas personalizadas y ¡quedaron geniales!\r\n\r\n          Me encantó cómo integraste materiales reciclados, especialmente las telas viejas.\r\n\r\n          ¡Gracias por compartir tu sencillo pero efectivo método.\r\n\r\n          ¿Tienes más ideas para añadir detalles sin complicar el diseño?\r\n\r\n          ¡Saludos!", null, 11, "Respuesta: Creación de Tarjetas Personalizadas" },
                    { 18, null, 6, "Respuesta", new DateTime(2023, 7, 22, 16, 50, 50, 0, DateTimeKind.Unspecified), "¡Buenos días!\r\n\r\n          Tu publicación sobre los 'Beneficios del Papel Reciclado' es ¡muy informativa! Ahora estoy convencido de reciclar más.\r\n\r\n          Especialmente me impactó cómo reduce las emisiones de CO₂.\r\n\r\n          ¿Tienes algún consejo para motivar a otros a reciclar ?\r\n\r\n          ¡Gracias por compartir!", null, 13, "Respuesta: Beneficios del Papel Reciclado" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Condition", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type", "Warranty" },
                values: new object[,]
                {
                    { 8, "SewEasy", "Usada", "Máquina de coser portátil para proyectos pequeños.", "https://image-Maquina.com", true, "Máquina de coser portátil", 3, 1, "Tool", 6, "Coser", false },
                    { 10, "ElectricCut", "Nueva", "Cutter eléctrico para cortes rápidos y precisos.", "https://image-Cutter.com", true, "Cutter eléctrico", 4, 1, "Tool", 7, "Corte", true },
                    { 11, "LamiPro", "Usada", "Laminadora para proteger y embellecer trabajos.", "https://image-Laminadora.com", true, "Laminadora", 4, 2, "Tool", 8, "Laminación", false },
                    { 15, "HeatGlue", "Usada", "Pistola de calor para fusión de materiales.", "https://image-Pistola.com", true, "Pistola de calor", 5, 1, "Tool", 9, "Adhesivo", false },
                    { 16, "HotGluePro", "Nueva", "Pistola de pegamento caliente para proyectos rápidos.", "https://image-Pistola.com", true, "Pistola de pegamento caliente", 6, 3, "Tool", 12, "Adhesivo", true }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type" },
                values: new object[,]
                {
                    { 25, "MagPaper", "Papel de revistas recicladas para collages.", "https://image-Papel.com", true, "Papel de revistas", 3, 250, "Material", 6, "Reciclaje" },
                    { 26, "AluCan", "Latas de aluminio recicladas para marcos y decoraciones.", "https://image-Latas.com", true, "Latas de aluminio", 3, 120, "Material", 6, "Reciclaje" },
                    { 27, "SilkPaper", "Papel de seda para crear fondos y detalles suaves.", "https://image-Papel.com", false, "Papel de seda", 3, 500, "Material", 7, "Decorativo" },
                    { 28, "EcoCard", "Cartulinas recicladas para tarjetas y decoraciones.", "https://image-Cartulinas.com", true, "Cartulinas recicladas", 4, 300, "Material", 7, "Reciclaje" },
                    { 31, "KraftPaper", "Papel kraft reciclado para crear sobres y bases.", "https://image-Papel.com", true, "Papel kraft", 5, 200, "Material", 9, "Reciclaje" },
                    { 32, "EcoRibbon", "Cintas recicladas para atar y decorar.", "https://image-Cintas.com", true, "Cintas recicladas", 5, 250, "Material", 10, "Reciclaje" },
                    { 34, "NewsPaper", "Papel periódico para crear fondos y texturas.", "https://image-Papel.com", true, "Papel periódico", 6, 300, "Material", 12, "Reciclaje" }
                });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                values: new object[,]
                {
                    { 12, 1 },
                    { 12, 6 },
                    { 16, 2 },
                    { 18, 3 },
                    { 23, 2 },
                    { 23, 3 },
                    { 37, 5 },
                    { 39, 6 }
                });

            migrationBuilder.InsertData(
                table: "ActivityResources",
                columns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                values: new object[] { 7, 25 });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                values: new object[,]
                {
                    { 26, 4 },
                    { 26, 5 },
                    { 28, 6 },
                    { 30, 1 },
                    { 30, 2 },
                    { 30, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 7, 25 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 31, 3 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 31, 20 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 33, 6 });

            migrationBuilder.DeleteData(
                table: "ActivityResources",
                keyColumns: new[] { "ActivitiesActivityId", "ActivityResourcesResourceId" },
                keyValues: new object[] { 33, 23 });

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 19, 4 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 19, 6 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 23, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 26, 4 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 26, 5 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 28, 6 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 35, 4 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 37, 5 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 39, 6 });

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "MaxParticipants",
                value: null);

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "AddressId", "CreatedAt", "CreatorUserId", "Description", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "NameCollaborator", "StartDate", "Title" },
                values: new object[] { 2, "SustainableActivity", 1, new DateTime(2024, 2, 1, 10, 10, 12, 0, DateTimeKind.Unspecified), 2, "Actividad para plantar árboles en parques.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0m, "https://default-homepage.com", true, 30, "Parques y Jardines", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plantación de Árboles" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityType", "CreatedAt", "CreatorUserId", "Description", "Duration", "FinishDate", "GreenPointsValue", "HomeImageUrl", "IsActive", "MaxParticipants", "StartDate", "Title" },
                values: new object[] { 3, "Tutorial", new DateTime(2024, 3, 1, 10, 15, 20, 0, DateTimeKind.Unspecified), 3, "Tutorial para hacer pegamento casero con materiales reciclados.", 300, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0m, "https://default-homepage.com", true, 20, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegamento Casero Reciclado" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1,
                columns: new[] { "City", "Country", "State", "ZipCode" },
                values: new object[] { "CiudadA", "PaísA", "EstadoA", "10001" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2,
                columns: new[] { "City", "Country", "State", "UserId", "ZipCode" },
                values: new object[] { "CiudadB", "PaísB", "EstadoB", 2, "20002" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3,
                columns: new[] { "City", "ContactPhone", "Country", "Description", "Number", "State", "Street", "UserId", "ZipCode" },
                values: new object[] { "CiudadC", "555-9012", "PaísC", "Lugar de Eventos", "456", "EstadoC", "Boulevard de los Sueños", 3, "30003" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Métodos efectivos para reciclar en casa.", "Consejos para Reciclar" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 2,
                columns: new[] { "AuthorId", "Category", "CreatedAt", "Description", "Title" },
                values: new object[] { 2, "Jardinería", new DateTime(2023, 4, 8, 12, 15, 30, 0, DateTimeKind.Unspecified), "Cómo y dónde plantar árboles.", "Plantando Árboles" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 3,
                columns: new[] { "AuthorId", "Category", "CreatedAt", "Description" },
                values: new object[] { 3, "Jardinería", new DateTime(2023, 4, 12, 15, 30, 20, 0, DateTimeKind.Unspecified), "¡Me encantaría participar!" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationId",
                keyValue: 4,
                columns: new[] { "ActivityId", "AuthorId", "Category", "CreatedAt", "Description", "ImagePostUrl", "Title" },
                values: new object[] { 1, 1, "Paso de proyecto", new DateTime(2023, 4, 15, 10, 30, 45, 0, DateTimeKind.Unspecified), "Hemos terminado de cortar las piezas.", "https://image-post.com", "Avance: Caja de recuerdos" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "ImageResourceUrl", "Name", "Quantity", "TransactionId", "Type" },
                values: new object[] { "HerramientasPro", "Pala resistente para jardinería.", null, "Pala", 10, 1, "Jardinería" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ImageResourceUrl", "Name", "OwnerUserId", "Quantity", "Type" },
                values: new object[] { "GardenMaster", "Rastrillo de alta calidad.", null, "Rastrillo", 2, 5, "Jardinería" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "Brand", "Description", "ImageResourceUrl", "IsSent", "Name", "OwnerUserId", "Quantity", "ResourceType", "TransactionId", "Type" },
                values: new object[] { 3, "PinturasVerdes", "Papel de muestrario de pinturas para reutilizar.", null, true, "Papel de muestrario de Pinturas", 3, 50, "Material", 2, "Reciclaje" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                columns: new[] { "DateCompleted", "DateInitiated", "IsActive" },
                values: new object[] { new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                columns: new[] { "DateInitiated", "InitiatorUserID", "Status" },
                values: new object[] { new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Pending" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zOB38Hnh5LTLq06GFSdJsuoBFghvqwty8Cqoaa96lXLES990A05OW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OpodsY2v.AplwPhQS/u1eeiWp4GvKOX.U/7Sz0DLR/S.r.6lcJ/M6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$kpiSyFTxELoK88ysRIs1TuGidgFzXiraFTiOjsAIzABaf7O5.8gXi");
        }
    }
}
