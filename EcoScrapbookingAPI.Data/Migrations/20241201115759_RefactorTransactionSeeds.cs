using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTransactionSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                column: "ImageTransactionUrl",
                value: "https://default-transaction1.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "ImageTransactionUrl",
                value: "https://default-transaction2.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "ImageTransactionUrl",
                value: "https://default-transaction3.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "ImageTransactionUrl",
                value: "https://default-transaction4.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 5,
                column: "ImageTransactionUrl",
                value: "https://default-transaction5.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 6,
                column: "ImageTransactionUrl",
                value: "https://default-transaction6.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 7,
                column: "ImageTransactionUrl",
                value: "https://default-transaction7.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 8,
                column: "ImageTransactionUrl",
                value: "https://default-transaction8.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 9,
                column: "ImageTransactionUrl",
                value: "https://default-transaction9.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 10,
                column: "ImageTransactionUrl",
                value: "https://default-transaction10.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 11,
                column: "ImageTransactionUrl",
                value: "https://default-transaction11.com");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                column: "ImageTransactionUrl",
                value: "https://default-transaction12.com");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 5,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 6,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 7,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 8,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 9,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 10,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 11,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 12,
                column: "ImageTransactionUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$H9DIHAxxt4X/TmfSgkPZD.tPwC8VYlG26uY5vKTEa4nuMpC5SO3re");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Ml0EneDgBzeAH4gYEx4up.qFaoc3Hu5DUqAZnbZAiwvl3XJmlCZCW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$960/7yDZ211YZhbHxcH50eF4a2EZuJVhw4pASQTqzgsZuMrNLLUUO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$H2twcPZDtLpayT5eLjK53ued5QabXFikDnG3qYILUBZykGhC5aFT6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$zoIEdA1dxKKW9bupHVQJreoOGRDLnuJY83cgWk1Z7dlg85JOq.eoe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$MMiTYXJ5XJrlKzZzKDEeYOwvyOv.N6N86A3aIV1eTr8FjlT6gy8sK");
        }
    }
}
