using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainDeliveryAddress",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1,
                column: "IsMainDeliveryAddress",
                value: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2,
                column: "IsMainDeliveryAddress",
                value: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3,
                column: "IsMainDeliveryAddress",
                value: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4,
                column: "IsMainDeliveryAddress",
                value: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 5,
                column: "IsMainDeliveryAddress",
                value: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 6,
                column: "IsMainDeliveryAddress",
                value: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 7,
                column: "IsMainDeliveryAddress",
                value: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 8,
                column: "IsMainDeliveryAddress",
                value: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 9,
                column: "IsMainDeliveryAddress",
                value: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 10,
                column: "IsMainDeliveryAddress",
                value: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 11,
                column: "IsMainDeliveryAddress",
                value: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 12,
                column: "IsMainDeliveryAddress",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$N/JKgQrlXiuTtno93aCojerKRqOikXx2kbmUmmBm8i2N61/KBt7i2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$LA0dgoQb150cyB6Ppe1lJOITf1QkjzBHvO/3h3OTnUmD8raMzTqlK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$UZi5nCUdIlCpNTYNHqAhWeac541rkRfuWqKeXptwlD8T5E4j83C32");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$qebQlBHBhiDDv8c7L0PQdObeVwU6DSM5QkcpLY2iWQzyNtgiGu6gO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$2CD4/Fje9GpVcj0GSrOVlOEX9ODtTkgJH.BuJENdy4kV3nxPXk5y.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$ebfx7lNrGYFWt1LBPiIRXOD8x/Tx0LkKpppk07y/cOYJGyR0RJUVa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainDeliveryAddress",
                table: "Addresses");

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
    }
}
