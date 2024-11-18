using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class HashSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$D2h2a7dlZueAjnA6s3QAjOaisYZxMKpNaF0n/BIOCN5/AEF5/JHMy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$JXjkEOFqvABvmVGYIsKva.RY9jRtQ/.adDlccTaPGd2B2S37yNLeu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Pp9pQam0ruqIXultJd.V8eEB/TdKDPgxZVWEusseEOB13Fz.Myiee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$KIX9sQw9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$7Hj3Lr9l3m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAf");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$9Hk4Ms8k1m3Hj1fYjGmFeGq9FhS/jl5kH5Qe6y1UOZk2ZbqYJxAg");
        }
    }
}
