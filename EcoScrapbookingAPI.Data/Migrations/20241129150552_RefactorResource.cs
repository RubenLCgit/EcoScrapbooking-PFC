using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "Resources",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                column: "IsSent",
                value: true);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2,
                column: "IsSent",
                value: true);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 3,
                column: "IsSent",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zOB38Hnh5LTLq06GFSdJsuoBFghvqwty8Cqoaa96lXLES990A05OW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OpodsY2v.AplwPhQS/u1eeiWp4GvKOX.U/7Sz0DLR/S.r.6lcJ/M6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$kpiSyFTxELoK88ysRIs1TuGidgFzXiraFTiOjsAIzABaf7O5.8gXi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "Resources");

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
    }
}
