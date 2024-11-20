using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPublicationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicationID",
                table: "Publications",
                newName: "PublicationId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicationId",
                table: "Publications",
                newName: "PublicationID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$jnHC6miO8ENgJ3ZRgcmkvumXpVF5aqQvwjQTkFeSic4izV21nan.O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$AA.N41Boe45eRJvAzm2gfeAFcjSQ096hApP2ULP42q.69prbaUbaS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$fyRLpSgPxn.1dQ1zOAHZauzKxpaf4mxIa7bwr1lLqu5r6vGGNR8ie");
        }
    }
}
