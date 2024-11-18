using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 10, 20, 35, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 1, 10, 10, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 1, 10, 15, 20, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 10, 20, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 12, 15, 30, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 12, 15, 30, 20, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "PublicationID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 15, 10, 30, 45, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "AvatarImageUrl",
                value: "https://juanito123.com/avatar.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AvatarImageUrl",
                value: "https://maryg.com/avatar.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "AvatarImageUrl",
                value: "https://carlosl.com/avatar.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "AvatarImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AvatarImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "AvatarImageUrl",
                value: null);
        }
    }
}
