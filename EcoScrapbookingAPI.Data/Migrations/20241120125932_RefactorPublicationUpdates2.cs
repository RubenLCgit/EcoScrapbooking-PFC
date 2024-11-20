using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPublicationUpdates2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$RJKXCuIvsQulJj6O41hmCeV7eleRn4IWeMLK.9dSPd3zqejUzMPCu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$AzCEsse4u1a9s3z0Q2obh.yI.YxTxiAa0//CzGhDzVPFFn5uw03PG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$35nw9rCzOFYYDi0rVWE.Euy6Qij.NyRYUqU4teniJ4tf4gycpTX4O");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$FmXRkqpEou/R4/zGew7XmO8aC7fyh9Wu46Fp8bsavKt2YK92JfckC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$g/PgVAPgsnMfjrBtDvlRuur.clBkXKW6M5b/XWvFgtvYaD3awh7aa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$zu1ap3dPJss5YBWKVIM1F.BNmYAAZ8TZsaKAJ2NN7HbtZeo9bI4Q2");
        }
    }
}
