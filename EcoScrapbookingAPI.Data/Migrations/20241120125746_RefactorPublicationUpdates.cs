using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPublicationUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
