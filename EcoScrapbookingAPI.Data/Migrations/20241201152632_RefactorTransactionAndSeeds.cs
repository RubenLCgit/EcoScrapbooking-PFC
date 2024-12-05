using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTransactionAndSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticlesDescription",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                column: "ArticlesDescription",
                value: "Pegamento en barra para sellos sin apenas uso.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "ArticlesDescription",
                value: "Regla metálica y capsulas de cafe usadas.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "ArticlesDescription",
                value: "Tijeras de precisión muy usadas pero sin daños.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "ArticlesDescription",
                value: "Cartones de embalaje para crear una caja de recuerdos.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 5,
                column: "ArticlesDescription",
                value: "Pumones de colores + Botellas de plastico + Revistas de decoración viejas.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 6,
                column: "ArticlesDescription",
                value: "Maquina de coser, papel de revistas y latas de aluminio.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 7,
                column: "ArticlesDescription",
                value: "Cuter electrico y cartulinas recicladas. Busco guillotina o laminadora.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 8,
                column: "ArticlesDescription",
                value: "Laminadora sin apenas uso. Busco papel kraft o cintas recicladas.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 9,
                column: "ArticlesDescription",
                value: "Pistola de calor para manualidades y packde papel kraft. Buso rotuladores de colores para scrapbooking.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 10,
                column: "ArticlesDescription",
                value: "Citas recicladas para la mejor decoradora eco-friendly.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 11,
                column: "ArticlesDescription",
                value: "Rotuladores de punta fina de colores. Necesito troqueladora.");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                column: "ArticlesDescription",
                value: "Pistola de pegamento caliente + pack de papel periódico. Busco compás de precisión.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$MxZ/pUhxyfBWVSQnhcq/HuC6/kI1FBqkT4nzjlUn.qV6a4hs9YGKm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$JwqAf.asirGbfKJNgL0FIulY1jMtEmCxbZbH2IWtFnkSmqShMyLuO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$4BPCLnz4kW9D8K0Hs5wPeO1xnLEh6ThXvRUX.BjdJfQi/tE6CxvP.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$8Ia1zibhvT3I1RUCBLIgx.sOEJ5EAo6.MVYdAroh2orFbggr2BK6m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$j/cEonBH6Meb.x9YQ22Bk./msAiIzVZ//DlfdqV7S1HmBLBDjHNIq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$y1GTYKtQTkWW6zqJ.uQQROwrjwQsJi8Guemhg9RwqTwpFIKo2I./y");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticlesDescription",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$IGFo313PO6AmMQs0FzILQ.At7ji64pT6Ent9qV27kgxEjIBIubQka");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$UXAfrNNBq2LvPctT5F7yeuwMNBwBelNdhG6RSjHUDfA91ej6Cf1l2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$wfrWwDThQG4PNenvc4yChOtHbspo97oL3HWd3Nvb5vayDAz6MHi5K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$VLSj9Qlgn6veBduTqHj9ge54fN2csGotemfvrl19j1fn0zECUAXqC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$UdlmTTkuZTLn.ykczEIdceo5aNs5WLWDlfuq2bzqTes2l9AJ8H7wa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$cIZOl.RRUH/MEH3psGxZz.Q.b.dhxxaT0awKvPzJ.kMRxslm6SrWy");
        }
    }
}
