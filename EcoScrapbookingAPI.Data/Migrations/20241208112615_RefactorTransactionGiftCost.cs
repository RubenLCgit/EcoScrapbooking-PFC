using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTransactionGiftCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GreenPointCost",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 5,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 6,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 7,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 8,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 9,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 10,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 11,
                column: "GreenPointCost",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                columns: new[] { "GreenPointCost", "ReceiverUserID" },
                values: new object[] { 50m, null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreenPointCost",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                column: "ReceiverUserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$P3j0gWRWNsryioOpQg6nj.uLaRXW47ugcCKi8UpRLxWIP9yQf/T9G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$JkQaNQK4twQTjCr1rTkV9.b/1zTMlqvjSwV8CwY5mKKoSsG6VP1Ga");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$oZpWhvnqTGiE7T4JB.2zl.TqBPWZumDc5fb3/5ra7bH5.sZEfQYTm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$1ZvlviGq58nuhJucivOYLOjT39UNZK120vh5hlxXN3yQP4Q8BNIWK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$cmJC6.iocGDnCfNXeADKy.j9LMvuanUcYVxZy4pEl27HXCe4ifW46");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$b9qeV9XANZf3qYCXKwVDz.e/UiAMNpegIWaCyN8StBLSpCPbdF1ei");
        }
    }
}
