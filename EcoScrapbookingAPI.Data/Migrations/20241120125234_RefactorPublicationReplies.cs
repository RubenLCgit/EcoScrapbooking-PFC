using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPublicationReplies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$6VVKYN4qTHWGWNZsp7Z7v.omm8xlp8v9/NY/.efIWktxj68TmVlW6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$CufF9l8HPAuuT5dTUG732e8QdfazFDCFsXRIRolc4FpH4818rVIIa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$FmIzTcM6ptmrugs9X1nzkec6V5AF5POWn4z.0tFhqAyO2RAEZAR7.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$cyXDg/ISaH/d4Xg00ZTEAe4.xdoSprtVoYS1hoVvP7IBQkOFzTT/m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$ugQmwa9foZGYu5DURGRDouo4V0GSdjuy6ovc3YpxkcBfaVmllYIRK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$neC7xAFDdZ8UmrvaPb6GtuH8bDZRdpKT0tnYGEPvw.CbwG6BmD2Ke");
        }
    }
}
