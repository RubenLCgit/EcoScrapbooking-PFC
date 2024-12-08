using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSeedTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                column: "TransactionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 16,
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 34,
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                columns: new[] { "ArticlesDescription", "InitiatorUserID" },
                values: new object[] { "Tijeras de precision nuevas y precintadas.", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$LOJUSRsjdHE5G2Wz5qAMp.hHAl/6o2LrrkAeLjL1cHo4uGKrQxKx2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$g1n7qrzaO8n4O/Zg9jYVxOQVvdyXdTGWuTsdHVaFmQoVebGN6E3xO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$XJLnaeOnORyar7kMUncHBO/S0JmOfIjcyIo5NKsLaaGR9fY64z2aG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$2V0mqCnpgptIyrya56ZLOuzbq20PeNPVEIkYGqCRVarmpHWn/gEOO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$89lwVeJyq44oeI6RdqaB9ur.XxzqLQODD4gDuDCz4IHFuXfZua.yq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$pO7hlU5fPOQrdKmwwtqhUelBhvr4NFGLvkhYtMoDs5N9E2xv6fh62");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 16,
                column: "TransactionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 34,
                column: "TransactionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                columns: new[] { "ArticlesDescription", "InitiatorUserID" },
                values: new object[] { "Pistola de pegamento caliente + pack de papel periódico. Busco compás de precisión.", 6 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$wGzYU9jOdfEulWvsHjqEAujmByJl7Y0MxXmoB9iI49KsMm/AaSYzm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$BnkyPE2rxUTtCZp38HPhtuhEtP5n..htYODtEVGMpBp4QPAzKHUl6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$AZFI6ylRW7LHMMfkzMmtrOsnz8H1LW1YUNbRijCLnKcUMNLg/GDVm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$HMrkx0alruk6RZGtpW893.71tBD1chNeUFdyTnYdK2A7UGoXs.9aG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$EW7ymS5ylg.gCaRSPk2vSu.PkiccFmAwcgcTdc0KxcwjXl61CC9P.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$J3r1g8yaZPkKlAdThZzukeCmuaJSVoRJkKVZmGk2g7ulwJgKejGje");
        }
    }
}
