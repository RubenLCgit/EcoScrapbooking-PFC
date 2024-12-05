using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageTransactionUrl",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageTransactionUrl",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$97FLVsw4wSJkMxEuSbBFROh1i/3VzM8ARcnwnELlEDSV6lrqzYwcG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$l3ux2gX22TcBdxj7xTrqVuDQhefNBbHEXYSaoIZRLEIru0eGx8Qm2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ljivgwi7HgbHxhTO7aMZE.II.j2irElhnCyzPefQVHgDIxOF0gGMm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$77GF3D3tT0/wikyP.XogG.rrt1WU7QlyvfXgC6Wpe0DVJiwQk1YeC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$aijPI8Kd1rAiXWu0ma217./Tjkhy3r6ckhX817yXcy7.9pUqYZ7.u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$eOOL/9LclP2CqNm82X4vwebVPY3go9dBwHIDzzdvpX5XrvpWKV2fW");
        }
    }
}
